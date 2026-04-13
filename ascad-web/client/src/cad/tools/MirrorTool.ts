import { v4 } from 'uuid';
import type {
  CadEntity,
  CadMouseEvent,
  ToolName,
  Point2D,
  Command,
  LineEntity,
  PolylineEntity,
  CircleEntity,
  ArcEntity,
  DimensionEntity,
  TextEntity,
  BlockReferenceEntity,
} from '../core/types';
import { BaseTool } from './BaseTool';

/**
 * Mirror tool: two points defining mirror line → mirror selected entities.
 */
export class MirrorTool extends BaseTool {
  readonly name: ToolName = 'mirror';
  readonly prompt = 'Specify first point of mirror line';

  private mirrorPoint1: Point2D | null = null;
  private currentPoint: Point2D | null = null;

  activate(): void {
    super.activate();
    this.mirrorPoint1 = null;
    this.currentPoint = null;
    this.setState('idle');
  }

  cancel(): void {
    this.mirrorPoint1 = null;
    this.currentPoint = null;
    super.cancel();
  }

  onMouseDown(event: CadMouseEvent): void {
    if (event.button !== 0) return;

    const pt = this.applySnap(event, this.mirrorPoint1 ?? undefined);

    if (this.state === 'idle') {
      if (this.selectionManager.getSelectionCount() === 0) return;
      this.mirrorPoint1 = pt;
      this.setState('first_point');
    } else if (this.state === 'first_point' || this.state === 'preview') {
      this.mirrorSelected(this.mirrorPoint1!, pt);
      this.mirrorPoint1 = null;
      this.currentPoint = null;
      this.setState('idle');
    }
  }

  onMouseMove(event: CadMouseEvent): void {
    if (this.state === 'first_point' || this.state === 'preview') {
      this.currentPoint = this.applySnap(event, this.mirrorPoint1 ?? undefined);
      this.setState('preview');
    }
  }

  onMouseUp(_event: CadMouseEvent): void {}

  onKeyDown(event: KeyboardEvent): void {
    if (event.key === 'Escape') this.cancel();
  }

  onNumericInput(_value: number): void {}

  getPreviewEntities(): CadEntity[] {
    return [];
  }

  private mirrorSelected(p1: Point2D, p2: Point2D): void {
    const entities = this.selectionManager.getSelectedEntities();
    const mirrorable = entities.filter((e) => !this.isOnLockedLayer(e));
    if (mirrorable.length === 0) return;

    this.commandStack.beginGroup('Mirror entities');
    for (const entity of mirrorable) {
      const oldValues = captureGeometry(entity);
      applyMirror(entity, p1, p2);
      const newValues = captureGeometry(entity);
      applyGeometry(entity, oldValues);
      const cmd = new MirrorCommand(entity.id, oldValues, newValues, this.entityModel);
      this.commandStack.execute(cmd);
    }
    this.commandStack.endGroup();
  }

  private isOnLockedLayer(entity: CadEntity): boolean {
    const layer = this.entityModel.getLayer(entity.layerName);
    return layer?.locked === true;
  }
}

/**
 * Mirror a point across a line defined by two points.
 */
export function mirrorPoint(p: Point2D, lineP1: Point2D, lineP2: Point2D): Point2D {
  const dx = lineP2.x - lineP1.x;
  const dy = lineP2.y - lineP1.y;
  const lenSq = dx * dx + dy * dy;
  if (lenSq === 0) return { ...p };

  const t = ((p.x - lineP1.x) * dx + (p.y - lineP1.y) * dy) / lenSq;
  const projX = lineP1.x + t * dx;
  const projY = lineP1.y + t * dy;

  return {
    x: 2 * projX - p.x,
    y: 2 * projY - p.y,
  };
}

function captureGeometry(entity: CadEntity): Record<string, any> {
  switch (entity.type) {
    case 'line': { const l = entity as LineEntity; return { start: { ...l.start }, end: { ...l.end } }; }
    case 'polyline': { const p = entity as PolylineEntity; return { vertices: p.vertices.map((v) => ({ ...v })) }; }
    case 'circle': { const c = entity as CircleEntity; return { center: { ...c.center } }; }
    case 'arc': { const a = entity as ArcEntity; return { center: { ...a.center }, startAngle: a.startAngle, endAngle: a.endAngle }; }
    case 'dimension': { const d = entity as DimensionEntity; return { defPoint1: { ...d.defPoint1 }, defPoint2: { ...d.defPoint2 }, dimLinePoint: { ...d.dimLinePoint } }; }
    case 'text': { const t = entity as TextEntity; return { position: { ...t.position } }; }
    case 'block_reference': { const b = entity as BlockReferenceEntity; return { insertionPoint: { ...b.insertionPoint } }; }
    default: return {};
  }
}

function applyGeometry(entity: CadEntity, values: Record<string, any>): void {
  Object.assign(entity, values);
}

function applyMirror(entity: CadEntity, p1: Point2D, p2: Point2D): void {
  switch (entity.type) {
    case 'line': {
      const l = entity as LineEntity;
      l.start = mirrorPoint(l.start, p1, p2);
      l.end = mirrorPoint(l.end, p1, p2);
      break;
    }
    case 'polyline': {
      const p = entity as PolylineEntity;
      p.vertices = p.vertices.map((v) => mirrorPoint(v, p1, p2));
      break;
    }
    case 'circle': {
      const c = entity as CircleEntity;
      c.center = mirrorPoint(c.center, p1, p2);
      break;
    }
    case 'arc': {
      const a = entity as ArcEntity;
      a.center = mirrorPoint(a.center, p1, p2);
      // Mirror angles: reflect across the mirror line
      const lineAngle = Math.atan2(p2.y - p1.y, p2.x - p1.x);
      a.startAngle = 2 * lineAngle - a.startAngle;
      a.endAngle = 2 * lineAngle - a.endAngle;
      // Swap start and end since mirroring reverses direction
      const tmp = a.startAngle;
      a.startAngle = a.endAngle;
      a.endAngle = tmp;
      break;
    }
    case 'dimension': {
      const d = entity as DimensionEntity;
      d.defPoint1 = mirrorPoint(d.defPoint1, p1, p2);
      d.defPoint2 = mirrorPoint(d.defPoint2, p1, p2);
      d.dimLinePoint = mirrorPoint(d.dimLinePoint, p1, p2);
      break;
    }
    case 'text': {
      const t = entity as TextEntity;
      t.position = mirrorPoint(t.position, p1, p2);
      break;
    }
    case 'block_reference': {
      const b = entity as BlockReferenceEntity;
      b.insertionPoint = mirrorPoint(b.insertionPoint, p1, p2);
      break;
    }
  }
}

class MirrorCommand implements Command {
  readonly description = 'Mirror entity';
  constructor(
    private entityId: string,
    private oldValues: Record<string, any>,
    private newValues: Record<string, any>,
    private entityModel: import('../core/EntityModel').EntityModel
  ) {}

  execute(): void { this.entityModel.updateEntity(this.entityId, this.newValues); }
  undo(): void { this.entityModel.updateEntity(this.entityId, this.oldValues); }
}
