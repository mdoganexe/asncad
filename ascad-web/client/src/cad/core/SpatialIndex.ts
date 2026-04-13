import RBush from 'rbush';
import type {
  BoundingBox,
  CadEntity,
  LineEntity,
  PolylineEntity,
  CircleEntity,
  ArcEntity,
  DimensionEntity,
  TextEntity,
  HatchEntity,
  BlockReferenceEntity,
  Point2D,
} from './types';

interface RBushItem {
  minX: number;
  minY: number;
  maxX: number;
  maxY: number;
  entityId: string;
}

/**
 * Wraps rbush library for spatial indexing of CAD entities.
 */
export class SpatialIndex {
  private tree: RBush<RBushItem>;
  private items: Map<string, RBushItem>;

  constructor() {
    this.tree = new RBush<RBushItem>();
    this.items = new Map();
  }

  insert(entity: CadEntity): void {
    const bbox = computeBoundingBox(entity);
    if (!bbox) return;
    const item: RBushItem = {
      minX: bbox.minX,
      minY: bbox.minY,
      maxX: bbox.maxX,
      maxY: bbox.maxY,
      entityId: entity.id,
    };
    this.items.set(entity.id, item);
    this.tree.insert(item);
  }

  remove(entity: CadEntity): void {
    const item = this.items.get(entity.id);
    if (item) {
      this.tree.remove(item, (a, b) => a.entityId === b.entityId);
      this.items.delete(entity.id);
    }
  }

  update(entity: CadEntity): void {
    this.remove(entity);
    this.insert(entity);
  }

  queryRect(bounds: BoundingBox): string[] {
    const results = this.tree.search({
      minX: bounds.minX,
      minY: bounds.minY,
      maxX: bounds.maxX,
      maxY: bounds.maxY,
    });
    return results.map((item) => item.entityId);
  }

  queryPoint(point: Point2D, tolerance: number): string[] {
    return this.queryRect({
      minX: point.x - tolerance,
      minY: point.y - tolerance,
      maxX: point.x + tolerance,
      maxY: point.y + tolerance,
    });
  }

  clear(): void {
    this.tree.clear();
    this.items.clear();
  }
}

/**
 * Compute the axis-aligned bounding box for any CadEntity type.
 */
export function computeBoundingBox(entity: CadEntity): BoundingBox | null {
  switch (entity.type) {
    case 'line':
      return computeLineBBox(entity as LineEntity);
    case 'polyline':
      return computePolylineBBox(entity as PolylineEntity);
    case 'circle':
      return computeCircleBBox(entity as CircleEntity);
    case 'arc':
      return computeArcBBox(entity as ArcEntity);
    case 'dimension':
      return computeDimensionBBox(entity as DimensionEntity);
    case 'text':
      return computeTextBBox(entity as TextEntity);
    case 'hatch':
      return computeHatchBBox(entity as HatchEntity);
    case 'block_reference':
      return computeBlockRefBBox(entity as BlockReferenceEntity);
    default:
      return null;
  }
}

function computeLineBBox(e: LineEntity): BoundingBox {
  return {
    minX: Math.min(e.start.x, e.end.x),
    minY: Math.min(e.start.y, e.end.y),
    maxX: Math.max(e.start.x, e.end.x),
    maxY: Math.max(e.start.y, e.end.y),
  };
}

function computePolylineBBox(e: PolylineEntity): BoundingBox | null {
  if (e.vertices.length === 0) return null;
  let minX = Infinity, minY = Infinity, maxX = -Infinity, maxY = -Infinity;
  for (const v of e.vertices) {
    if (v.x < minX) minX = v.x;
    if (v.y < minY) minY = v.y;
    if (v.x > maxX) maxX = v.x;
    if (v.y > maxY) maxY = v.y;
  }
  return { minX, minY, maxX, maxY };
}

function computeCircleBBox(e: CircleEntity): BoundingBox {
  return {
    minX: e.center.x - e.radius,
    minY: e.center.y - e.radius,
    maxX: e.center.x + e.radius,
    maxY: e.center.y + e.radius,
  };
}

function computeArcBBox(e: ArcEntity): BoundingBox {
  // Conservative: use full circle bbox
  // A more precise implementation would check which quadrant angles the arc passes through
  const points: Point2D[] = [
    { x: e.center.x + e.radius * Math.cos(e.startAngle), y: e.center.y + e.radius * Math.sin(e.startAngle) },
    { x: e.center.x + e.radius * Math.cos(e.endAngle), y: e.center.y + e.radius * Math.sin(e.endAngle) },
  ];

  // Check cardinal directions (0, π/2, π, 3π/2)
  const cardinals = [0, Math.PI / 2, Math.PI, (3 * Math.PI) / 2];
  for (const angle of cardinals) {
    if (isAngleInArc(angle, e.startAngle, e.endAngle)) {
      points.push({
        x: e.center.x + e.radius * Math.cos(angle),
        y: e.center.y + e.radius * Math.sin(angle),
      });
    }
  }

  let minX = Infinity, minY = Infinity, maxX = -Infinity, maxY = -Infinity;
  for (const p of points) {
    if (p.x < minX) minX = p.x;
    if (p.y < minY) minY = p.y;
    if (p.x > maxX) maxX = p.x;
    if (p.y > maxY) maxY = p.y;
  }
  return { minX, minY, maxX, maxY };
}

function isAngleInArc(angle: number, start: number, end: number): boolean {
  // Normalize angles to [0, 2π)
  const TWO_PI = Math.PI * 2;
  const normalize = (a: number) => ((a % TWO_PI) + TWO_PI) % TWO_PI;
  const a = normalize(angle);
  const s = normalize(start);
  const e = normalize(end);

  if (s <= e) {
    return a >= s && a <= e;
  } else {
    return a >= s || a <= e;
  }
}

function computeDimensionBBox(e: DimensionEntity): BoundingBox {
  const points = [e.defPoint1, e.defPoint2, e.dimLinePoint];
  if (e.angleVertex) points.push(e.angleVertex);
  if (e.centerPoint) points.push(e.centerPoint);

  let minX = Infinity, minY = Infinity, maxX = -Infinity, maxY = -Infinity;
  for (const p of points) {
    if (p.x < minX) minX = p.x;
    if (p.y < minY) minY = p.y;
    if (p.x > maxX) maxX = p.x;
    if (p.y > maxY) maxY = p.y;
  }
  // Add some padding for text and arrows
  const pad = Math.max(e.textHeight, e.arrowSize) * 2;
  return { minX: minX - pad, minY: minY - pad, maxX: maxX + pad, maxY: maxY + pad };
}

function computeTextBBox(e: TextEntity): BoundingBox {
  // Approximate text bounding box based on font size and content length
  const charWidth = e.fontSize * 0.6;
  const width = e.content.length * charWidth;
  const height = e.fontSize * 1.2;

  let offsetX = 0;
  if (e.alignment === 'center') offsetX = -width / 2;
  else if (e.alignment === 'right') offsetX = -width;

  return {
    minX: e.position.x + offsetX,
    minY: e.position.y,
    maxX: e.position.x + offsetX + width,
    maxY: e.position.y + height,
  };
}

function computeHatchBBox(e: HatchEntity): BoundingBox | null {
  if (e.boundaryPoints.length === 0) return null;
  let minX = Infinity, minY = Infinity, maxX = -Infinity, maxY = -Infinity;
  for (const p of e.boundaryPoints) {
    if (p.x < minX) minX = p.x;
    if (p.y < minY) minY = p.y;
    if (p.x > maxX) maxX = p.x;
    if (p.y > maxY) maxY = p.y;
  }
  return { minX, minY, maxX, maxY };
}

function computeBlockRefBBox(e: BlockReferenceEntity): BoundingBox {
  // Without resolving the block definition, use a default size around insertion point
  // In practice, the EntityModel would resolve the block and compute the real bbox
  const defaultSize = 100;
  return {
    minX: e.insertionPoint.x - defaultSize * Math.abs(e.scaleX),
    minY: e.insertionPoint.y - defaultSize * Math.abs(e.scaleY),
    maxX: e.insertionPoint.x + defaultSize * Math.abs(e.scaleX),
    maxY: e.insertionPoint.y + defaultSize * Math.abs(e.scaleY),
  };
}
