import type {
  CadEntity,
  LineEntity,
  PolylineEntity,
  CircleEntity,
  ArcEntity,
  DimensionEntity,
  TextEntity,
  HatchEntity,
  BlockReferenceEntity,
  Layer,
  BlockDefinition,
  LineType,
} from '../core/types';
import type { ViewportState } from './ViewportState';

/** Dash patterns for line types (in screen pixels) */
const DASH_PATTERNS: Record<LineType, number[]> = {
  continuous: [],
  dashed: [10, 5],
  center: [20, 5, 5, 5],
  hidden: [5, 5],
};

/**
 * Apply entity styling (color, line type, line weight) to the canvas context.
 */
function applyEntityStyle(
  ctx: CanvasRenderingContext2D,
  entity: CadEntity,
  layer: Layer | undefined,
  viewport: ViewportState
): void {
  const color = entity.color !== '#FFFFFF' || !layer ? entity.color : layer.color;
  ctx.strokeStyle = color;
  ctx.fillStyle = color;

  const lineWeight = entity.lineWeight > 0 ? entity.lineWeight : (layer?.lineWeight ?? 0.25);
  ctx.lineWidth = Math.max(1, lineWeight * viewport.zoom);

  const lineType = entity.lineType || layer?.lineType || 'continuous';
  ctx.setLineDash(DASH_PATTERNS[lineType] || []);
}

/**
 * Dispatch rendering to the appropriate per-type renderer.
 */
export function renderEntity(
  ctx: CanvasRenderingContext2D,
  entity: CadEntity,
  viewport: ViewportState,
  layer?: Layer,
  blockDefs?: Map<string, BlockDefinition>
): void {
  ctx.save();
  applyEntityStyle(ctx, entity, layer, viewport);

  switch (entity.type) {
    case 'line':
      renderLine(ctx, entity as LineEntity, viewport);
      break;
    case 'polyline':
      renderPolyline(ctx, entity as PolylineEntity, viewport);
      break;
    case 'circle':
      renderCircle(ctx, entity as CircleEntity, viewport);
      break;
    case 'arc':
      renderArc(ctx, entity as ArcEntity, viewport);
      break;
    case 'dimension':
      renderDimension(ctx, entity as DimensionEntity, viewport);
      break;
    case 'text':
      renderText(ctx, entity as TextEntity, viewport);
      break;
    case 'hatch':
      renderHatch(ctx, entity as HatchEntity, viewport);
      break;
    case 'block_reference':
      renderBlockRef(ctx, entity as BlockReferenceEntity, viewport, blockDefs);
      break;
  }

  ctx.restore();
}

function renderLine(ctx: CanvasRenderingContext2D, entity: LineEntity, viewport: ViewportState): void {
  const s0 = viewport.worldToScreen(entity.start.x, entity.start.y);
  const s1 = viewport.worldToScreen(entity.end.x, entity.end.y);
  ctx.beginPath();
  ctx.moveTo(s0.x, s0.y);
  ctx.lineTo(s1.x, s1.y);
  ctx.stroke();
}

function renderPolyline(ctx: CanvasRenderingContext2D, entity: PolylineEntity, viewport: ViewportState): void {
  if (entity.vertices.length < 2) return;
  ctx.beginPath();
  const first = viewport.worldToScreen(entity.vertices[0].x, entity.vertices[0].y);
  ctx.moveTo(first.x, first.y);
  for (let i = 1; i < entity.vertices.length; i++) {
    const s = viewport.worldToScreen(entity.vertices[i].x, entity.vertices[i].y);
    ctx.lineTo(s.x, s.y);
  }
  if (entity.closed) ctx.closePath();
  ctx.stroke();
}

function renderCircle(ctx: CanvasRenderingContext2D, entity: CircleEntity, viewport: ViewportState): void {
  const sc = viewport.worldToScreen(entity.center.x, entity.center.y);
  const screenRadius = entity.radius * viewport.zoom;
  ctx.beginPath();
  ctx.arc(sc.x, sc.y, screenRadius, 0, Math.PI * 2);
  ctx.stroke();
}

function renderArc(ctx: CanvasRenderingContext2D, entity: ArcEntity, viewport: ViewportState): void {
  const sc = viewport.worldToScreen(entity.center.x, entity.center.y);
  const screenRadius = entity.radius * viewport.zoom;
  // Canvas arc goes clockwise, but our world Y is flipped, so negate angles
  ctx.beginPath();
  ctx.arc(sc.x, sc.y, screenRadius, -entity.startAngle, -entity.endAngle, true);
  ctx.stroke();
}

function renderDimension(ctx: CanvasRenderingContext2D, entity: DimensionEntity, viewport: ViewportState): void {
  const p1 = viewport.worldToScreen(entity.defPoint1.x, entity.defPoint1.y);
  const p2 = viewport.worldToScreen(entity.defPoint2.x, entity.defPoint2.y);
  const dl = viewport.worldToScreen(entity.dimLinePoint.x, entity.dimLinePoint.y);

  const extOffset = entity.extensionLineOffset * viewport.zoom;
  const arrowSize = entity.arrowSize * viewport.zoom;

  // Extension lines from definition points to dimension line
  ctx.beginPath();

  // For linear/aligned dimensions, project def points onto the dimension line
  const isHorizontal = Math.abs(dl.y - p1.y) > Math.abs(dl.x - p1.x);

  let ext1End: { x: number; y: number };
  let ext2End: { x: number; y: number };

  if (entity.dimensionType === 'linear' || entity.dimensionType === 'aligned') {
    if (isHorizontal) {
      // Horizontal dimension line at dl.y
      ext1End = { x: p1.x, y: dl.y };
      ext2End = { x: p2.x, y: dl.y };
    } else {
      // Vertical dimension line at dl.x
      ext1End = { x: dl.x, y: p1.y };
      ext2End = { x: dl.x, y: p2.y };
    }
  } else {
    ext1End = { x: p1.x, y: dl.y };
    ext2End = { x: p2.x, y: dl.y };
  }

  // Draw extension lines
  ctx.moveTo(p1.x, p1.y + (p1.y < ext1End.y ? extOffset : -extOffset));
  ctx.lineTo(ext1End.x, ext1End.y);
  ctx.moveTo(p2.x, p2.y + (p2.y < ext2End.y ? extOffset : -extOffset));
  ctx.lineTo(ext2End.x, ext2End.y);

  // Draw dimension line
  ctx.moveTo(ext1End.x, ext1End.y);
  ctx.lineTo(ext2End.x, ext2End.y);
  ctx.stroke();

  // Draw arrows at both ends
  drawArrow(ctx, ext1End, ext2End, arrowSize);
  drawArrow(ctx, ext2End, ext1End, arrowSize);

  // Draw measurement text
  const textHeight = entity.textHeight * viewport.zoom;
  const midX = (ext1End.x + ext2End.x) / 2;
  const midY = (ext1End.y + ext2End.y) / 2;
  const text = entity.textOverride || entity.measurementValue.toFixed(entity.decimalPrecision);

  ctx.font = `${Math.max(8, textHeight)}px sans-serif`;
  ctx.textAlign = 'center';
  ctx.textBaseline = 'bottom';
  ctx.fillText(text, midX, midY - 2);
}

function drawArrow(
  ctx: CanvasRenderingContext2D,
  from: { x: number; y: number },
  to: { x: number; y: number },
  size: number
): void {
  const dx = to.x - from.x;
  const dy = to.y - from.y;
  const len = Math.sqrt(dx * dx + dy * dy);
  if (len === 0) return;

  const ux = dx / len;
  const uy = dy / len;

  ctx.beginPath();
  ctx.moveTo(from.x, from.y);
  ctx.lineTo(from.x + ux * size + uy * size * 0.3, from.y + uy * size - ux * size * 0.3);
  ctx.moveTo(from.x, from.y);
  ctx.lineTo(from.x + ux * size - uy * size * 0.3, from.y + uy * size + ux * size * 0.3);
  ctx.stroke();
}

function renderText(ctx: CanvasRenderingContext2D, entity: TextEntity, viewport: ViewportState): void {
  const sp = viewport.worldToScreen(entity.position.x, entity.position.y);
  const screenFontSize = Math.max(8, entity.fontSize * viewport.zoom);

  ctx.save();
  ctx.translate(sp.x, sp.y);
  // Negate rotation because screen Y is flipped
  ctx.rotate(-entity.rotation);

  ctx.font = `${entity.fontStyle === 'italic' ? 'italic ' : ''}${entity.fontWeight === 'bold' ? 'bold ' : ''}${screenFontSize}px ${entity.fontFamily || 'sans-serif'}`;
  ctx.textAlign = entity.alignment;
  ctx.textBaseline = 'alphabetic';
  ctx.fillText(entity.content, 0, 0);

  ctx.restore();
}

function renderHatch(ctx: CanvasRenderingContext2D, entity: HatchEntity, viewport: ViewportState): void {
  if (entity.boundaryPoints.length < 3) return;

  ctx.beginPath();
  const first = viewport.worldToScreen(entity.boundaryPoints[0].x, entity.boundaryPoints[0].y);
  ctx.moveTo(first.x, first.y);
  for (let i = 1; i < entity.boundaryPoints.length; i++) {
    const s = viewport.worldToScreen(entity.boundaryPoints[i].x, entity.boundaryPoints[i].y);
    ctx.lineTo(s.x, s.y);
  }
  ctx.closePath();

  if (entity.pattern === 'SOLID') {
    ctx.globalAlpha = 0.3;
    ctx.fill();
    ctx.globalAlpha = 1;
  } else {
    // For pattern hatches, draw diagonal lines within the boundary
    ctx.save();
    ctx.clip();
    drawHatchPattern(ctx, entity, viewport);
    ctx.restore();
  }

  ctx.stroke();
}

function drawHatchPattern(
  ctx: CanvasRenderingContext2D,
  entity: HatchEntity,
  viewport: ViewportState
): void {
  // Compute screen-space bounding box of boundary
  let minX = Infinity, minY = Infinity, maxX = -Infinity, maxY = -Infinity;
  for (const p of entity.boundaryPoints) {
    const s = viewport.worldToScreen(p.x, p.y);
    if (s.x < minX) minX = s.x;
    if (s.y < minY) minY = s.y;
    if (s.x > maxX) maxX = s.x;
    if (s.y > maxY) maxY = s.y;
  }

  const spacing = Math.max(4, entity.patternScale * viewport.zoom * 3);
  const angle = entity.patternAngle + (entity.pattern === 'ANSI32' ? Math.PI / 4 : Math.PI / 4);

  ctx.beginPath();
  const cos = Math.cos(angle);
  const sin = Math.sin(angle);
  const diag = Math.sqrt((maxX - minX) ** 2 + (maxY - minY) ** 2);
  const cx = (minX + maxX) / 2;
  const cy = (minY + maxY) / 2;

  for (let d = -diag; d <= diag; d += spacing) {
    const x0 = cx + d * cos - diag * sin;
    const y0 = cy + d * sin + diag * cos;
    const x1 = cx + d * cos + diag * sin;
    const y1 = cy + d * sin - diag * cos;
    ctx.moveTo(x0, y0);
    ctx.lineTo(x1, y1);
  }
  ctx.stroke();
}

function renderBlockRef(
  ctx: CanvasRenderingContext2D,
  entity: BlockReferenceEntity,
  viewport: ViewportState,
  blockDefs?: Map<string, BlockDefinition>
): void {
  const def = blockDefs?.get(entity.blockDefName);
  if (!def) {
    // Draw a placeholder marker
    const sp = viewport.worldToScreen(entity.insertionPoint.x, entity.insertionPoint.y);
    ctx.strokeRect(sp.x - 5, sp.y - 5, 10, 10);
    return;
  }

  // Render each child entity of the block definition with the insertion transform
  ctx.save();
  const sp = viewport.worldToScreen(entity.insertionPoint.x, entity.insertionPoint.y);
  ctx.translate(sp.x, sp.y);
  ctx.rotate(-entity.rotation); // negate for screen Y flip
  ctx.scale(entity.scaleX, entity.scaleY);

  for (const childEntity of def.entities) {
    // Render child entities relative to block base point
    // Create a temporary viewport that maps from block-local coords
    const localViewport = {
      ...viewport,
      centerX: def.basePoint.x,
      centerY: def.basePoint.y,
      zoom: 1,
      canvasWidth: 0,
      canvasHeight: 0,
      worldToScreen: (wx: number, wy: number) => ({
        x: (wx - def.basePoint.x) * viewport.zoom,
        y: -(wy - def.basePoint.y) * viewport.zoom,
      }),
    } as unknown as ViewportState;

    renderEntity(ctx, childEntity, localViewport, undefined, blockDefs);
  }

  ctx.restore();
}
