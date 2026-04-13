import type {
  Point2D,
  SnapMode,
  SnapResult,
  CadEntity,
  LineEntity,
  PolylineEntity,
  CircleEntity,
  ArcEntity,
} from '../core/types';
import type { EntityModel } from '../core/EntityModel';
import type { ViewportState } from '../rendering/ViewportState';

/** Snap priority order (highest first) */
const SNAP_PRIORITY: SnapMode[] = [
  'endpoint',
  'intersection',
  'center',
  'midpoint',
  'perpendicular',
  'nearest',
  'grid',
];

/**
 * Detects snap points on existing geometry within an aperture radius.
 */
export class SnapManager {
  private enabledModes: Set<SnapMode> = new Set([
    'endpoint', 'midpoint', 'center', 'intersection', 'nearest', 'grid',
  ]);
  private apertureRadius = 10; // pixels
  private orthoEnabled = false;
  private entityModel: EntityModel | null = null;
  private viewport: ViewportState | null = null;
  private gridSpacing = 10; // world units

  setEntityModel(model: EntityModel): void {
    this.entityModel = model;
  }

  setViewport(viewport: ViewportState): void {
    this.viewport = viewport;
  }

  setGridSpacing(spacing: number): void {
    this.gridSpacing = spacing;
  }

  setMode(mode: SnapMode, enabled: boolean): void {
    if (enabled) {
      this.enabledModes.add(mode);
    } else {
      this.enabledModes.delete(mode);
    }
  }

  setApertureRadius(pixels: number): void {
    this.apertureRadius = pixels;
  }

  setOrthoEnabled(enabled: boolean): void {
    this.orthoEnabled = enabled;
  }

  isOrthoEnabled(): boolean {
    return this.orthoEnabled;
  }

  /**
   * Find the best snap point near the cursor.
   * Checks all enabled modes in priority order and returns the first match within aperture.
   */
  findSnap(
    _screenPoint: Point2D,
    worldPoint: Point2D,
    lastPoint?: Point2D
  ): SnapResult | null {
    if (!this.entityModel || !this.viewport) return null;

    const worldTolerance = this.apertureRadius / this.viewport.zoom;

    // Get nearby entities
    const candidates = this.entityModel.queryPoint(worldPoint, worldTolerance);

    // Check each snap mode in priority order
    for (const mode of SNAP_PRIORITY) {
      if (!this.enabledModes.has(mode)) continue;

      let result: SnapResult | null = null;

      switch (mode) {
        case 'endpoint':
          result = this.findEndpointSnap(worldPoint, worldTolerance, candidates);
          break;
        case 'intersection':
          result = this.findIntersectionSnap(worldPoint, worldTolerance, candidates);
          break;
        case 'center':
          result = this.findCenterSnap(worldPoint, worldTolerance, candidates);
          break;
        case 'midpoint':
          result = this.findMidpointSnap(worldPoint, worldTolerance, candidates);
          break;
        case 'perpendicular':
          result = lastPoint
            ? this.findPerpendicularSnap(worldPoint, worldTolerance, candidates, lastPoint)
            : null;
          break;
        case 'nearest':
          result = this.findNearestSnap(worldPoint, worldTolerance, candidates);
          break;
        case 'grid':
          result = this.findGridSnap(worldPoint, worldTolerance);
          break;
      }

      if (result) return result;
    }

    return null;
  }

  /**
   * Apply ortho constraint: constrain to horizontal or vertical based on larger delta.
   */
  applyOrtho(point: Point2D, lastPoint: Point2D): Point2D {
    const dx = Math.abs(point.x - lastPoint.x);
    const dy = Math.abs(point.y - lastPoint.y);
    if (dx >= dy) {
      return { x: point.x, y: lastPoint.y }; // horizontal
    } else {
      return { x: lastPoint.x, y: point.y }; // vertical
    }
  }

  // =========================================================================
  // Individual snap calculations
  // =========================================================================

  private findEndpointSnap(
    worldPoint: Point2D,
    tolerance: number,
    candidates: CadEntity[]
  ): SnapResult | null {
    let bestDist = tolerance;
    let bestResult: SnapResult | null = null;

    for (const entity of candidates) {
      const endpoints = getEntityEndpoints(entity);
      for (const ep of endpoints) {
        const dist = distance(worldPoint, ep);
        if (dist < bestDist) {
          bestDist = dist;
          bestResult = { point: ep, mode: 'endpoint', entityId: entity.id };
        }
      }
    }

    return bestResult;
  }

  private findMidpointSnap(
    worldPoint: Point2D,
    tolerance: number,
    candidates: CadEntity[]
  ): SnapResult | null {
    let bestDist = tolerance;
    let bestResult: SnapResult | null = null;

    for (const entity of candidates) {
      const midpoints = getEntityMidpoints(entity);
      for (const mp of midpoints) {
        const dist = distance(worldPoint, mp);
        if (dist < bestDist) {
          bestDist = dist;
          bestResult = { point: mp, mode: 'midpoint', entityId: entity.id };
        }
      }
    }

    return bestResult;
  }

  private findCenterSnap(
    worldPoint: Point2D,
    tolerance: number,
    candidates: CadEntity[]
  ): SnapResult | null {
    let bestDist = tolerance;
    let bestResult: SnapResult | null = null;

    for (const entity of candidates) {
      if (entity.type === 'circle' || entity.type === 'arc') {
        const center = (entity as CircleEntity | ArcEntity).center;
        const dist = distance(worldPoint, center);
        if (dist < bestDist) {
          bestDist = dist;
          bestResult = { point: center, mode: 'center', entityId: entity.id };
        }
      }
    }

    return bestResult;
  }

  private findIntersectionSnap(
    worldPoint: Point2D,
    tolerance: number,
    candidates: CadEntity[]
  ): SnapResult | null {
    // Check pairwise intersections of nearby entities
    let bestDist = tolerance;
    let bestResult: SnapResult | null = null;

    for (let i = 0; i < candidates.length; i++) {
      for (let j = i + 1; j < candidates.length; j++) {
        const intersections = computeIntersections(candidates[i], candidates[j]);
        for (const pt of intersections) {
          const dist = distance(worldPoint, pt);
          if (dist < bestDist) {
            bestDist = dist;
            bestResult = { point: pt, mode: 'intersection', entityId: candidates[i].id };
          }
        }
      }
    }

    return bestResult;
  }

  private findPerpendicularSnap(
    worldPoint: Point2D,
    tolerance: number,
    candidates: CadEntity[],
    lastPoint: Point2D
  ): SnapResult | null {
    let bestDist = tolerance;
    let bestResult: SnapResult | null = null;

    for (const entity of candidates) {
      if (entity.type === 'line') {
        const line = entity as LineEntity;
        const foot = perpendicularFoot(lastPoint, line.start, line.end);
        if (foot && isOnSegment(foot, line.start, line.end)) {
          const dist = distance(worldPoint, foot);
          if (dist < bestDist) {
            bestDist = dist;
            bestResult = { point: foot, mode: 'perpendicular', entityId: entity.id };
          }
        }
      }
    }

    return bestResult;
  }

  private findNearestSnap(
    worldPoint: Point2D,
    tolerance: number,
    candidates: CadEntity[]
  ): SnapResult | null {
    let bestDist = tolerance;
    let bestResult: SnapResult | null = null;

    for (const entity of candidates) {
      const nearest = nearestPointOnEntity(worldPoint, entity);
      if (nearest) {
        const dist = distance(worldPoint, nearest);
        if (dist < bestDist) {
          bestDist = dist;
          bestResult = { point: nearest, mode: 'nearest', entityId: entity.id };
        }
      }
    }

    return bestResult;
  }

  private findGridSnap(worldPoint: Point2D, tolerance: number): SnapResult | null {
    const spacing = this.gridSpacing;
    if (spacing <= 0) return null;

    const snappedX = Math.round(worldPoint.x / spacing) * spacing;
    const snappedY = Math.round(worldPoint.y / spacing) * spacing;
    const snapped = { x: snappedX, y: snappedY };

    const dist = distance(worldPoint, snapped);
    if (dist <= tolerance) {
      return { point: snapped, mode: 'grid' };
    }

    return null;
  }
}

// =============================================================================
// Geometry helpers
// =============================================================================

function distance(a: Point2D, b: Point2D): number {
  const dx = a.x - b.x;
  const dy = a.y - b.y;
  return Math.sqrt(dx * dx + dy * dy);
}

function getEntityEndpoints(entity: CadEntity): Point2D[] {
  switch (entity.type) {
    case 'line': {
      const line = entity as LineEntity;
      return [line.start, line.end];
    }
    case 'polyline': {
      const poly = entity as PolylineEntity;
      return [...poly.vertices];
    }
    case 'arc': {
      const arc = entity as ArcEntity;
      return [
        {
          x: arc.center.x + arc.radius * Math.cos(arc.startAngle),
          y: arc.center.y + arc.radius * Math.sin(arc.startAngle),
        },
        {
          x: arc.center.x + arc.radius * Math.cos(arc.endAngle),
          y: arc.center.y + arc.radius * Math.sin(arc.endAngle),
        },
      ];
    }
    default:
      return [];
  }
}

function getEntityMidpoints(entity: CadEntity): Point2D[] {
  switch (entity.type) {
    case 'line': {
      const line = entity as LineEntity;
      return [
        {
          x: (line.start.x + line.end.x) / 2,
          y: (line.start.y + line.end.y) / 2,
        },
      ];
    }
    case 'polyline': {
      const poly = entity as PolylineEntity;
      const midpoints: Point2D[] = [];
      for (let i = 0; i < poly.vertices.length - 1; i++) {
        midpoints.push({
          x: (poly.vertices[i].x + poly.vertices[i + 1].x) / 2,
          y: (poly.vertices[i].y + poly.vertices[i + 1].y) / 2,
        });
      }
      if (poly.closed && poly.vertices.length > 1) {
        const last = poly.vertices[poly.vertices.length - 1];
        const first = poly.vertices[0];
        midpoints.push({
          x: (last.x + first.x) / 2,
          y: (last.y + first.y) / 2,
        });
      }
      return midpoints;
    }
    default:
      return [];
  }
}

function computeIntersections(e1: CadEntity, e2: CadEntity): Point2D[] {
  // Only handle line-line intersections for now
  if (e1.type === 'line' && e2.type === 'line') {
    return lineLineIntersection(e1 as LineEntity, e2 as LineEntity);
  }
  return [];
}

function lineLineIntersection(l1: LineEntity, l2: LineEntity): Point2D[] {
  const x1 = l1.start.x, y1 = l1.start.y;
  const x2 = l1.end.x, y2 = l1.end.y;
  const x3 = l2.start.x, y3 = l2.start.y;
  const x4 = l2.end.x, y4 = l2.end.y;

  const denom = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
  if (Math.abs(denom) < 1e-10) return []; // parallel

  const t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / denom;
  const u = -((x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3)) / denom;

  if (t >= 0 && t <= 1 && u >= 0 && u <= 1) {
    return [{ x: x1 + t * (x2 - x1), y: y1 + t * (y2 - y1) }];
  }

  return [];
}

function perpendicularFoot(point: Point2D, lineStart: Point2D, lineEnd: Point2D): Point2D | null {
  const dx = lineEnd.x - lineStart.x;
  const dy = lineEnd.y - lineStart.y;
  const lenSq = dx * dx + dy * dy;
  if (lenSq === 0) return null;

  const t = ((point.x - lineStart.x) * dx + (point.y - lineStart.y) * dy) / lenSq;
  return {
    x: lineStart.x + t * dx,
    y: lineStart.y + t * dy,
  };
}

function isOnSegment(point: Point2D, start: Point2D, end: Point2D): boolean {
  const minX = Math.min(start.x, end.x) - 1e-6;
  const maxX = Math.max(start.x, end.x) + 1e-6;
  const minY = Math.min(start.y, end.y) - 1e-6;
  const maxY = Math.max(start.y, end.y) + 1e-6;
  return point.x >= minX && point.x <= maxX && point.y >= minY && point.y <= maxY;
}

function nearestPointOnEntity(point: Point2D, entity: CadEntity): Point2D | null {
  switch (entity.type) {
    case 'line': {
      const line = entity as LineEntity;
      return nearestPointOnSegment(point, line.start, line.end);
    }
    case 'polyline': {
      const poly = entity as PolylineEntity;
      let bestDist = Infinity;
      let bestPoint: Point2D | null = null;
      const verts = poly.vertices;
      const count = poly.closed ? verts.length : verts.length - 1;
      for (let i = 0; i < count; i++) {
        const j = (i + 1) % verts.length;
        const np = nearestPointOnSegment(point, verts[i], verts[j]);
        if (np) {
          const d = distance(point, np);
          if (d < bestDist) {
            bestDist = d;
            bestPoint = np;
          }
        }
      }
      return bestPoint;
    }
    case 'circle': {
      const circle = entity as CircleEntity;
      const dx = point.x - circle.center.x;
      const dy = point.y - circle.center.y;
      const dist = Math.sqrt(dx * dx + dy * dy);
      if (dist === 0) return { x: circle.center.x + circle.radius, y: circle.center.y };
      return {
        x: circle.center.x + (dx / dist) * circle.radius,
        y: circle.center.y + (dy / dist) * circle.radius,
      };
    }
    default:
      return null;
  }
}

function nearestPointOnSegment(point: Point2D, start: Point2D, end: Point2D): Point2D {
  const dx = end.x - start.x;
  const dy = end.y - start.y;
  const lenSq = dx * dx + dy * dy;
  if (lenSq === 0) return { ...start };

  let t = ((point.x - start.x) * dx + (point.y - start.y) * dy) / lenSq;
  t = Math.max(0, Math.min(1, t));

  return {
    x: start.x + t * dx,
    y: start.y + t * dy,
  };
}
