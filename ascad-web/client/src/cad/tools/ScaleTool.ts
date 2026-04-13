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
 * Scale tool: base point + factor → scale selected entities.
 */
export class ScaleTool extends BaseTool {
  readonly name: ToolName = 'scale';
  readonly prompt = 'Specify base point';

  private basePoint: Point2D | null = null;
  private referenceDistance: number | null = null;
  private currentPoint: Point2D | null = null;

  activate(): void {
    super.activate();
    this.basePoint = null;
    this.referenceDistance = null;
    this.currentPoint = null;
    this.setState('idle');
  }

  cancel(): void {
    this.basePoint = null;
    this.referenceDistance = null;
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
      const dist = distance(this.basePoint!, pt);
      if (this.referenceDistance === null) {
        this.referenceDistance = dist > 0 ? dist : 1;
        this.setState('preview');
      } else {
        const factor = dist / this.referenceDistance;
        if (factor > 0) {
          this.scaleSelected(this.basePoint!, factor);
        }
        this.basePoint = null;
        this.referenceDistance = null;
        this.currentPoint = null;
        this.setState('idle');
      }
    }
  }

  onMouseMove(event: CadMouseEvent): void {
    if (this.state === 'first_point' || this.state === 'preview') {
      this.currentPoint = this.applySnap(event, this.basePoint ?? undefined);
    }
  }

  onMouseUp(_event: CadMouseEvent): void {}

  onKeyDown(event: KeyboardEvent): void {
    if (event.key === 'Escape') this.cancel();
  }

  onNumericInput(value: number): void {
    if (!this.basePoint || value <= 0) return;
    this.scaleSelected(this.basePoint, value);
    this.basePoint = null;
    this.referenceDistance = null;
    this.currentPoint = null;
    this.setState('idle');
  }

  getPreviewEntities(): CadEntity[] {
    return [];
  }

  private scaleSelected(center: Point2D, factor: number): void {
    const entities = this.selectionManager.getSelectedEntities();
    const scalable = entities.filter((e) => !this.isOnLockedLayer(e));
    if (scalable.length === 0) return;

    this.commandStack.beginGroup('Scale entities');
    for (const entity of scalable) {
      const oldValues = captureGeometry(entity);
      applyScale(entity, center, factor);
      const newValues = captureGeometry(entity);
      applyGeometry(entity, oldValues);
      const cmd = new ScaleCommand(entity.id, oldValues, newValues, this.entityModel);
      this.commandStack.execute(cmd);
    }
    this.commandStack.endGroup();
  }

  private isOnLockedLayer(entity: CadEntity): boolean {
    const layer = this.entityModel.getLayer(entity.layerName);
    return layer?.locked === true;
  }
}

function distance(a: Point2D, b: Point2D): number {
  return Math.sqrt((a.x - b.x) ** 2 + (a.y - b.y) ** 2);
}

function scalePoint(p: Point2D, center: Point2D, factor: number): Point2D {
  return {
    x: center.x + (p.x - center.x) * factor,
    y: center.y + (p.y - center.y) * factor,
  };
}

function captureGeometry(entity: CadEntity): Record<string, any> {
  switch (entity.type) {
    case 'line': { const l = entity as LineEntity; return { start: { ...l.start }, end: { ...l.end } }; }
    case 'polyline': { const p = entity as PolylineEntity; return { vertices: p.vertices.map((v) => ({ ...v })) }; }
    case 'circle': { const c = entity as CircleEntity; return { center: { ...c.center }, radius: c.radius }; }
    case 'arc': { const a = entity as ArcEntity; return { center: { ...a.center }, radius: a.radius }; }
    case 'dimension': { const d = entity as DimensionEntity; return { defPoint1: { ...d.defPoint1 }, defPoint2: { ...d.defPoint2 }, dimLinePoint: { ...d.dimLinePoint }, measurementValue: d.measurementValue }; }
    case 'text': { const t = entity as TextEntity; return { position: { ...t.position }, fontSize: t.fontSize }; }
    case 'block_reference': { const b = entity as BlockReferenceEntity; return { insertionPoint: { ...b.insertionPoint }, scaleX: b.scaleX, scaleY: b.scaleY }; }
    default: return {};
  }
}

function applyGeometry(entity: CadEntity, values: Record<string, any>): void {
  Object.assign(entity, values);
}

function applyScale(entity: CadEntity, center: Point2D, factor: number): void {
  switch (entity.type) {
    case 'line': {
      const l = entity as LineEntity;
      l.start = scalePoint(l.start, center, factor);
      l.end = scalePoint(l.end, center, factor);
      break;
    }
    case 'polyline': {
      const p = entity as PolylineEntity;
      p.vertices = p.vertices.map((v) => scalePoint(v, center, factor));
      break;
    }
    case 'circle': {
      const c = entity as CircleEntity;
      c.center = scalePoint(c.center, center, factor);
      c.radius *= factor;
      break;
    }
    case 'arc': {
      const a = entity as ArcEntity;
      a.center = scalePoint(a.center, center, factor);
      a.radius *= factor;
      break;
    }
    case 'dimension': {
      const d = entity as DimensionEntity;
      d.defPoint1 = scalePoint(d.defPoint1, center, factor);
      d.defPoint2 = scalePoint(d.defPoint2, center, factor);
      d.dimLinePoint = scalePoint(d.dimLinePoint, center, factor);
      d.measurementValue *= factor;
      break;
    }
    case 'text': {
      const t = entity as TextEntity;
      t.position = scalePoint(t.position, center, factor);
      t.fontSize *= factor;
      break;
    }
    case 'block_reference': {
      const b = entity as BlockReferenceEntity;
      b.insertionPoint = scalePoint(b.insertionPoint, center, factor);
      b.scaleX *= factor;
      b.scaleY *= factor;
      break;
    }
  }
}

class ScaleCommand implements Command {
  readonly description = 'Scale entity';
  constructor(
    private entityId: string,
    private oldValues: Record<string, any>,
    private newValues: Record<string, any>,
    private entityModel: import('../core/EntityModel').EntityModel
  ) {}

  execute(): void { this.entityModel.updateEntity(this.entityId, this.newValues); }
  undo(): void { this.entityModel.updateEntity(this.entityId, this.oldValues); }
}
