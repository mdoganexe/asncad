import type { Point2D, SnapResult, SnapMode } from '../core/types';
import type { ViewportState } from './ViewportState';

const CROSSHAIR_SIZE = 20; // pixels
const SNAP_INDICATOR_SIZE = 8; // pixels

/** Snap indicator colors by mode */
const SNAP_COLORS: Record<SnapMode, string> = {
  endpoint: '#00FF00',
  midpoint: '#00FF00',
  center: '#00FF00',
  intersection: '#FFFF00',
  perpendicular: '#00FFFF',
  nearest: '#FF8800',
  grid: '#888888',
};

/**
 * Renders the crosshair cursor, snap indicators, and coordinate readout.
 */
export class CursorRenderer {
  /**
   * Render crosshair at the current world position.
   */
  renderCrosshair(ctx: CanvasRenderingContext2D, worldPos: Point2D, viewport: ViewportState): void {
    const sp = viewport.worldToScreen(worldPos.x, worldPos.y);

    ctx.save();
    ctx.strokeStyle = '#FFFFFF';
    ctx.lineWidth = 1;
    ctx.setLineDash([]);

    ctx.beginPath();
    // Horizontal line
    ctx.moveTo(sp.x - CROSSHAIR_SIZE, sp.y);
    ctx.lineTo(sp.x + CROSSHAIR_SIZE, sp.y);
    // Vertical line
    ctx.moveTo(sp.x, sp.y - CROSSHAIR_SIZE);
    ctx.lineTo(sp.x, sp.y + CROSSHAIR_SIZE);
    ctx.stroke();

    ctx.restore();
  }

  /**
   * Render snap indicator icon at the snap point.
   */
  renderSnapIndicator(ctx: CanvasRenderingContext2D, snap: SnapResult, viewport: ViewportState): void {
    const sp = viewport.worldToScreen(snap.point.x, snap.point.y);
    const s = SNAP_INDICATOR_SIZE;
    const color = SNAP_COLORS[snap.mode] || '#00FF00';

    ctx.save();
    ctx.strokeStyle = color;
    ctx.lineWidth = 2;
    ctx.setLineDash([]);

    switch (snap.mode) {
      case 'endpoint':
        // Square marker
        ctx.strokeRect(sp.x - s, sp.y - s, s * 2, s * 2);
        break;
      case 'midpoint':
        // Triangle marker
        ctx.beginPath();
        ctx.moveTo(sp.x, sp.y - s);
        ctx.lineTo(sp.x - s, sp.y + s);
        ctx.lineTo(sp.x + s, sp.y + s);
        ctx.closePath();
        ctx.stroke();
        break;
      case 'center':
        // Circle marker
        ctx.beginPath();
        ctx.arc(sp.x, sp.y, s, 0, Math.PI * 2);
        ctx.stroke();
        break;
      case 'intersection':
        // X marker
        ctx.beginPath();
        ctx.moveTo(sp.x - s, sp.y - s);
        ctx.lineTo(sp.x + s, sp.y + s);
        ctx.moveTo(sp.x + s, sp.y - s);
        ctx.lineTo(sp.x - s, sp.y + s);
        ctx.stroke();
        break;
      case 'perpendicular':
        // Right angle marker
        ctx.beginPath();
        ctx.moveTo(sp.x - s, sp.y);
        ctx.lineTo(sp.x - s, sp.y - s);
        ctx.lineTo(sp.x, sp.y - s);
        ctx.stroke();
        break;
      case 'nearest':
        // Diamond marker
        ctx.beginPath();
        ctx.moveTo(sp.x, sp.y - s);
        ctx.lineTo(sp.x + s, sp.y);
        ctx.lineTo(sp.x, sp.y + s);
        ctx.lineTo(sp.x - s, sp.y);
        ctx.closePath();
        ctx.stroke();
        break;
      case 'grid':
        // Plus marker
        ctx.beginPath();
        ctx.moveTo(sp.x - s / 2, sp.y);
        ctx.lineTo(sp.x + s / 2, sp.y);
        ctx.moveTo(sp.x, sp.y - s / 2);
        ctx.lineTo(sp.x, sp.y + s / 2);
        ctx.stroke();
        break;
    }

    ctx.restore();
  }

  /**
   * Render coordinate readout text near the cursor.
   */
  renderCoordinateReadout(ctx: CanvasRenderingContext2D, worldPos: Point2D, viewport: ViewportState): void {
    const sp = viewport.worldToScreen(worldPos.x, worldPos.y);
    const text = `${worldPos.x.toFixed(1)}, ${worldPos.y.toFixed(1)}`;

    ctx.save();
    ctx.font = '11px monospace';
    ctx.fillStyle = '#CCCCCC';
    ctx.textAlign = 'left';
    ctx.textBaseline = 'top';
    ctx.fillText(text, sp.x + CROSSHAIR_SIZE + 4, sp.y + CROSSHAIR_SIZE + 4);
    ctx.restore();
  }
}
