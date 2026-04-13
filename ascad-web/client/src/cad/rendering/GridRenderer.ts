import type { ViewportState } from './ViewportState';

/**
 * Compute adaptive grid spacing based on zoom level.
 * Finds a "nice" spacing that results in grid lines ~50-200px apart.
 */
export function getGridSpacing(zoom: number): { major: number; minor: number } {
  const targetPixelSpacing = 100;
  const worldSpacing = targetPixelSpacing / zoom;
  const magnitude = Math.pow(10, Math.floor(Math.log10(worldSpacing)));
  const normalized = worldSpacing / magnitude;

  let major: number;
  if (normalized < 2) major = magnitude;
  else if (normalized < 5) major = 2 * magnitude;
  else major = 5 * magnitude;

  return { major, minor: major / 10 };
}

/**
 * Renders the background grid on the canvas.
 */
export class GridRenderer {
  private minorColor = 'rgba(255, 255, 255, 0.05)';
  private majorColor = 'rgba(255, 255, 255, 0.15)';
  private axisColor = 'rgba(255, 255, 255, 0.3)';

  render(ctx: CanvasRenderingContext2D, viewport: ViewportState): void {
    const bounds = viewport.getVisibleBounds();
    const { major, minor } = getGridSpacing(viewport.zoom);

    // Draw minor grid lines
    this.drawGridLines(ctx, viewport, bounds, minor, this.minorColor, 0.5);

    // Draw major grid lines
    this.drawGridLines(ctx, viewport, bounds, major, this.majorColor, 1);

    // Draw origin axes
    this.drawAxis(ctx, viewport, bounds);
  }

  private drawGridLines(
    ctx: CanvasRenderingContext2D,
    viewport: ViewportState,
    bounds: { minX: number; minY: number; maxX: number; maxY: number },
    spacing: number,
    color: string,
    lineWidth: number
  ): void {
    if (spacing <= 0) return;

    ctx.strokeStyle = color;
    ctx.lineWidth = lineWidth;
    ctx.beginPath();

    // Vertical lines (varying X)
    const startX = Math.floor(bounds.minX / spacing) * spacing;
    for (let wx = startX; wx <= bounds.maxX; wx += spacing) {
      const s0 = viewport.worldToScreen(wx, bounds.minY);
      const s1 = viewport.worldToScreen(wx, bounds.maxY);
      ctx.moveTo(Math.round(s0.x) + 0.5, s0.y);
      ctx.lineTo(Math.round(s1.x) + 0.5, s1.y);
    }

    // Horizontal lines (varying Y)
    const startY = Math.floor(bounds.minY / spacing) * spacing;
    for (let wy = startY; wy <= bounds.maxY; wy += spacing) {
      const s0 = viewport.worldToScreen(bounds.minX, wy);
      const s1 = viewport.worldToScreen(bounds.maxX, wy);
      ctx.moveTo(s0.x, Math.round(s0.y) + 0.5);
      ctx.lineTo(s1.x, Math.round(s1.y) + 0.5);
    }

    ctx.stroke();
  }

  private drawAxis(
    ctx: CanvasRenderingContext2D,
    viewport: ViewportState,
    bounds: { minX: number; minY: number; maxX: number; maxY: number }
  ): void {
    ctx.strokeStyle = this.axisColor;
    ctx.lineWidth = 1.5;
    ctx.beginPath();

    // X axis (Y=0)
    if (bounds.minY <= 0 && bounds.maxY >= 0) {
      const s0 = viewport.worldToScreen(bounds.minX, 0);
      const s1 = viewport.worldToScreen(bounds.maxX, 0);
      ctx.moveTo(s0.x, Math.round(s0.y) + 0.5);
      ctx.lineTo(s1.x, Math.round(s1.y) + 0.5);
    }

    // Y axis (X=0)
    if (bounds.minX <= 0 && bounds.maxX >= 0) {
      const s0 = viewport.worldToScreen(0, bounds.minY);
      const s1 = viewport.worldToScreen(0, bounds.maxY);
      ctx.moveTo(Math.round(s0.x) + 0.5, s0.y);
      ctx.lineTo(Math.round(s1.x) + 0.5, s1.y);
    }

    ctx.stroke();
  }
}
