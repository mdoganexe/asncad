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
 * Move tool: base point + destination → translate selected entities.
 * Rejects locked layer entities.
 */
export class MoveTool extends BaseTool {
  readonly name: ToolName = 'move';
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
      const dx = pt.x - this.basePoint!.x;
      const dy = pt.y - this.basePoint!.y;
      this.moveSelected(dx, dy);
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

  onNumericInput(_value: number): void {}

  getPreviewEntities(): CadEntity[] {
    return [];
  }

  private moveSelected(dx: number, dy: number): void {
    const entities = this.selectionManager.getSelectedEntities();
    const movable = entities.filter((e) => !this.isOnLockedLayer(e));
    if (movable.length === 0) return;

    this.commandStack.beginGroup('Move entities');
    for (const entity of movable) {
      const oldValues = this.captureTranslatable(entity);
      const newValues = this.translateEntity(entity, dx, dy);
      const cmd = new MoveCommand(entity.id, oldValues, newValues, this.entityModel);
      this.commandStack.execute(cmd);
    }
    this.commandStack.endGroup();
  }

  private isOnLockedLayer(entity: CadEntity): boolean {
    const layer = this.entityModel.getLayer(entity.layerName);
    return layer?.locked === true;
  }

  private captureTranslatable(entity: CadEntity): Partial<CadEntity> {
    switch (entity.type) {
      case 'line': {
        const l = entity as LineEntity;
        return { start: { ...l.start }, end: { ...l.end } } as any;
      }
      case 'polyline': {
        const p = entity as PolylineEntity;
        return { vertices: p.vertices.map((v) => ({ ...v })) } as any;
      }
      case 'circle': {
        const c = entity as CircleEntity;
        return { center: { ...c.center } } as any;
      }
      case 'arc': {
        const a = entity as ArcEntity;
        return { center: { ...a.center } } as any;
      }
      case 'dimension': {
        const d = entity as DimensionEntity;
        return { defPoint1: { ...d.defPoint1 }, defPoint2: { ...d.defPoint2 }, dimLinePoint: { ...d.dimLinePoint } } as any;
      }
      case 'text': {
        const t = entity as TextEntity;
        return { position: { ...t.position } } as any;
      }
      case 'block_reference': {
        const b = entity as BlockReferenceEntity;
        return { insertionPoint: { ...b.insertionPoint } } as any;
      }
      default:
        return {};
    }
  }

  private translateEntity(entity: CadEntity, dx: number, dy: number): Partial<CadEntity> {
    switch (entity.type) {
      case 'line': {
        const l = entity as LineEntity;
        return { start: { x: l.start.x + dx, y: l.start.y + dy }, end: { x: l.end.x + dx, y: l.end.y + dy } } as any;
      }
      case 'polyline': {
        const p = entity as PolylineEntity;
        return { vertices: p.vertices.map((v) => ({ x: v.x + dx, y: v.y + dy })) } as any;
      }
      case 'circle': {
        const c = entity as CircleEntity;
        return { center: { x: c.center.x + dx, y: c.center.y + dy } } as any;
      }
      case 'arc': {
        const a = entity as ArcEntity;
        return { center: { x: a.center.x + dx, y: a.center.y + dy } } as any;
      }
      case 'dimension': {
        const d = entity as DimensionEntity;
        return {
          defPoint1: { x: d.defPoint1.x + dx, y: d.defPoint1.y + dy },
          defPoint2: { x: d.defPoint2.x + dx, y: d.defPoint2.y + dy },
          dimLinePoint: { x: d.dimLinePoint.x + dx, y: d.dimLinePoint.y + dy },
        } as any;
      }
      case 'text': {
        const t = entity as TextEntity;
        return { position: { x: t.position.x + dx, y: t.position.y + dy } } as any;
      }
      case 'block_reference': {
        const b = entity as BlockReferenceEntity;
        return { insertionPoint: { x: b.insertionPoint.x + dx, y: b.insertionPoint.y + dy } } as any;
      }
      default:
        return {};
    }
  }
}

class MoveCommand implements Command {
  readonly description = 'Move entity';
  constructor(
    private entityId: string,
    private oldValues: Partial<CadEntity>,
    private newValues: Partial<CadEntity>,
    private entityModel: import('../core/EntityModel').EntityModel
  ) {}

  execute(): void {
    this.entityModel.updateEntity(this.entityId, this.newValues);
  }

  undo(): void {
    this.entityModel.updateEntity(this.entityId, this.oldValues);
  }
}
