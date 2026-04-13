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
 * Rotate tool: base point + angle → rotate selected entities.
 */
export class RotateTool extends BaseTool {
  readonly name: ToolName = 'rotate';
  readonly prompt = 'Specify base point';

  private basePoint: Point2D | null = null;
  private currentPoint: Point2D | null = null;

  activate(): void {
    super.activate();
    this.basePoint = null;
    this.currentPoint = null;
    this.setState('idle');
  }

  cancel(): void {
    this.basePoint = null;
    this.currentPoint = null;
    super.cancel();
  }

  onMouseDown(event: CadMouseEvent): void {
    if (event.button !== 0) return;

    const pt = this.applySnap(event, this.basePoint ?? undefined);

    if (this.state === 'idle') {
      if (this.selectionManager.getSelectionCount() === 0) return;
      this.basePoint = pt;
      this.setState('first_point');
    } else if (this.state === 'first_point' || this.state === 'preview') {
      const angle = Math.atan2(pt.y - this.basePoint!.y, pt.x - this.basePoint!.x);
      this.rotateSelected(this.basePoint!, angle);
      this.basePoint = null;
      this.currentPoint = null;
      this.setState('idle');
    }
  }

  onMouseMove(event: CadMouseEvent): void {
    if (this.state === 'first_point' || this.state === 'preview') {
      this.currentPoint = this.applySnap(event, this.basePoint ?? undefined);
      this.setState('preview');
    }
  }

  onMouseUp(_event: CadMouseEvent): void {}

  onKeyDown(event: KeyboardEvent): void {
    if (event.key === 'Escape') this.cancel();
  }

  onNumericInput(value: number): void {
    if (!this.basePoint) return;
    const angleRad = (value * Math.PI) / 180;
    this.rotateSelected(this.basePoint, angleRad);
    this.basePoint = null;
    this.currentPoint = null;
    this.setState('idle');
  }

  getPreviewEntities(): CadEntity[] {
    return [];
  }

  private rotateSelected(center: Point2D, angle: number): void {
    const entities = this.selectionManager.getSelectedEntities();
    const rotatable = entities.filter((e) => !this.isOnLockedLayer(e));
    if (rotatable.length === 0) return;

    this.commandStack.beginGroup('Rotate entities');
    for (const entity of rotatable) {
      const oldValues = captureGeometry(entity);
      applyRotation(entity, center, angle);
      const newValues = captureGeometry(entity);
      // Revert to old, let command apply new
      applyGeometry(entity, oldValues);
      const cmd = new RotateCommand(entity.id, oldValues, newValues, this.entityModel);
      this.commandStack.execute(cmd);
    }
    this.commandStack.endGroup();
  }

  private isOnLockedLayer(entity: CadEntity): boolean {
    const layer = this.entityModel.getLayer(entity.layerName);
    return layer?.locked === true;
  }
}

function rotatePoint(p: Point2D, center: Point2D, angle: number): Point2D {
  const cos = Math.cos(angle);
  const sin = Math.sin(angle);
  const dx = p.x - center.x;
  const dy = p.y - center.y;
  return {
    x: center.x + dx * cos - dy * sin,
    y: center.y + dx * sin + dy * cos,
  };
}

function captureGeometry(entity: CadEntity): Record<string, any> {
  switch (entity.type) {
    case 'line': { const l = entity as LineEntity; return { start: { ...l.start }, end: { ...l.end } }; }
    case 'polyline': { const p = entity as PolylineEntity; return { vertices: p.vertices.map((v) => ({ ...v })) }; }
    case 'circle': { const c = entity as CircleEntity; return { center: { ...c.center } }; }
    case 'arc': { const a = entity as ArcEntity; return { center: { ...a.center }, startAngle: a.startAngle, endAngle: a.endAngle }; }
    case 'dimension': { const d = entity as DimensionEntity; return { defPoint1: { ...d.defPoint1 }, defPoint2: { ...d.defPoint2 }, dimLinePoint: { ...d.dimLinePoint } }; }
    case 'text': { const t = entity as TextEntity; return { position: { ...t.position }, rotation: t.rotation }; }
    case 'block_reference': { const b = entity as BlockReferenceEntity; return { insertionPoint: { ...b.insertionPoint }, rotation: b.rotation }; }
    default: return {};
  }
}

function applyGeometry(entity: CadEntity, values: Record<string, any>): void {
  Object.assign(entity, values);
}

function applyRotation(entity: CadEntity, center: Point2D, angle: number): void {
  switch (entity.type) {
    case 'line': {
      const l = entity as LineEntity;
      l.start = rotatePoint(l.start, center, angle);
      l.end = rotatePoint(l.end, center, angle);
      break;
    }
    case 'polyline': {
      const p = entity as PolylineEntity;
      p.vertices = p.vertices.map((v) => rotatePoint(v, center, angle));
      break;
    }
    case 'circle': {
      const c = entity as CircleEntity;
      c.center = rotatePoint(c.center, center, angle);
      break;
    }
    case 'arc': {
      const a = entity as ArcEntity;
      a.center = rotatePoint(a.center, center, angle);
      a.startAngle += angle;
      a.endAngle += angle;
      break;
    }
    case 'dimension': {
      const d = entity as DimensionEntity;
      d.defPoint1 = rotatePoint(d.defPoint1, center, angle);
      d.defPoint2 = rotatePoint(d.defPoint2, center, angle);
      d.dimLinePoint = rotatePoint(d.dimLinePoint, center, angle);
      break;
    }
    case 'text': {
      const t = entity as TextEntity;
      t.position = rotatePoint(t.position, center, angle);
      t.rotation += angle;
      break;
    }
    case 'block_reference': {
      const b = entity as BlockReferenceEntity;
      b.insertionPoint = rotatePoint(b.insertionPoint, center, angle);
      b.rotation += angle;
      break;
    }
  }
}

class RotateCommand implements Command {
  readonly description = 'Rotate entity';
  constructor(
    private entityId: string,
    private oldValues: Record<string, any>,
    private newValues: Record<string, any>,
    private entityModel: import('../core/EntityModel').EntityModel
  ) {}

  execute(): void { this.entityModel.updateEntity(this.entityId, this.newValues); }
  undo(): void { this.entityModel.updateEntity(this.entityId, this.oldValues); }
}
