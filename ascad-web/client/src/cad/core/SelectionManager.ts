import type {
  BoundingBox,
  CadEntity,
  GripPoint,
  LineEntity,
  PolylineEntity,
  CircleEntity,
  ArcEntity,
} from './types';
import type { EntityModel } from './EntityModel';
import { computeBoundingBox } from './SpatialIndex';

/**
 * Manages the current selection set and provides selection operations.
 */
export class SelectionManager {
  private selected: Set<string> = new Set();
  private entityModel: EntityModel;

  constructor(entityModel: EntityModel) {
    this.entityModel = entityModel;
  }

  // =========================================================================
  // Selection operations
  // =========================================================================

  selectEntity(id: string): void {
    this.selected.add(id);
  }

  deselectEntity(id: string): void {
    this.selected.delete(id);
  }

  toggleEntity(id: string): void {
    if (this.selected.has(id)) {
      this.selected.delete(id);
    } else {
      this.selected.add(id);
    }
  }

  selectAll(): void {
    for (const entity of this.entityModel.getAllEntities()) {
      this.selected.add(entity.id);
    }
  }

  clearSelection(): void {
    this.selected.clear();
  }

  // =========================================================================
  // Box selection
  // =========================================================================

  /**
   * Window selection: select only entities fully contained within the bounds.
   */
  selectByWindow(bounds: BoundingBox): void {
    const entities = this.entityModel.getAllEntities();
    for (const entity of entities) {
      const bbox = computeBoundingBox(entity);
      if (bbox && isFullyContained(bbox, bounds)) {
        this.selected.add(entity.id);
      }
    }
  }

  /**
   * Crossing selection: select entities that intersect or are contained within the bounds.
   */
  selectByCrossing(bounds: BoundingBox): void {
    const entities = this.entityModel.getAllEntities();
    for (const entity of entities) {
      const bbox = computeBoundingBox(entity);
      if (bbox && intersects(bbox, bounds)) {
        this.selected.add(entity.id);
      }
    }
  }

  // =========================================================================
  // Query
  // =========================================================================

  getSelectedIds(): string[] {
    return Array.from(this.selected);
  }

  getSelectedEntities(): CadEntity[] {
    return this.getSelectedIds()
      .map((id) => this.entityModel.getEntity(id))
      .filter((e): e is CadEntity => e !== undefined);
  }

  isSelected(id: string): boolean {
    return this.selected.has(id);
  }

  getSelectionCount(): number {
    return this.selected.size;
  }

  // =========================================================================
  // Grips
  // =========================================================================

  /**
   * Get grip points (key points) for all selected entities.
   */
  getGripPoints(): GripPoint[] {
    const grips: GripPoint[] = [];

    for (const entity of this.getSelectedEntities()) {
      const entityGrips = getEntityGripPoints(entity);
      grips.push(...entityGrips);
    }

    return grips;
  }
}

// =============================================================================
// Geometry helpers
// =============================================================================

function isFullyContained(entityBBox: BoundingBox, selectionBounds: BoundingBox): boolean {
  return (
    entityBBox.minX >= selectionBounds.minX &&
    entityBBox.minY >= selectionBounds.minY &&
    entityBBox.maxX <= selectionBounds.maxX &&
    entityBBox.maxY <= selectionBounds.maxY
  );
}

function intersects(a: BoundingBox, b: BoundingBox): boolean {
  return (
    a.minX <= b.maxX &&
    a.maxX >= b.minX &&
    a.minY <= b.maxY &&
    a.maxY >= b.minY
  );
}

function getEntityGripPoints(entity: CadEntity): GripPoint[] {
  switch (entity.type) {
    case 'line': {
      const line = entity as LineEntity;
      return [
        { point: line.start, entityId: entity.id, gripType: 'endpoint' },
        { point: line.end, entityId: entity.id, gripType: 'endpoint' },
        {
          point: {
            x: (line.start.x + line.end.x) / 2,
            y: (line.start.y + line.end.y) / 2,
          },
          entityId: entity.id,
          gripType: 'midpoint',
        },
      ];
    }
    case 'polyline': {
      const poly = entity as PolylineEntity;
      return poly.vertices.map((v) => ({
        point: v,
        entityId: entity.id,
        gripType: 'vertex',
      }));
    }
    case 'circle': {
      const circle = entity as CircleEntity;
      return [
        { point: circle.center, entityId: entity.id, gripType: 'center' },
        { point: { x: circle.center.x + circle.radius, y: circle.center.y }, entityId: entity.id, gripType: 'quadrant' },
        { point: { x: circle.center.x - circle.radius, y: circle.center.y }, entityId: entity.id, gripType: 'quadrant' },
        { point: { x: circle.center.x, y: circle.center.y + circle.radius }, entityId: entity.id, gripType: 'quadrant' },
        { point: { x: circle.center.x, y: circle.center.y - circle.radius }, entityId: entity.id, gripType: 'quadrant' },
      ];
    }
    case 'arc': {
      const arc = entity as ArcEntity;
      return [
        { point: arc.center, entityId: entity.id, gripType: 'center' },
        {
          point: {
            x: arc.center.x + arc.radius * Math.cos(arc.startAngle),
            y: arc.center.y + arc.radius * Math.sin(arc.startAngle),
          },
          entityId: entity.id,
          gripType: 'endpoint',
        },
        {
          point: {
            x: arc.center.x + arc.radius * Math.cos(arc.endAngle),
            y: arc.center.y + arc.radius * Math.sin(arc.endAngle),
          },
          entityId: entity.id,
          gripType: 'endpoint',
        },
      ];
    }
    default:
      return [];
  }
}
