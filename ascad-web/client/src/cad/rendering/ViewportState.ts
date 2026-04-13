import type { Point2D, BoundingBox } from '../core/types';

/**
 * Manages the 2D viewport transform (world ↔ screen coordinate conversion).
 * World Y increases upward (CAD convention), screen Y increases downward.
 */
export class ViewportState {
  centerX: number;
  centerY: number;
  zoom: number;
  canvasWidth: number;
  canvasHeight: number;

  static readonly MIN_ZOOM = 0.01;
  static readonly MAX_ZOOM = 100;

  constructor(
    canvasWidth = 800,
    canvasHeight = 600,
    centerX = 0,
    centerY = 0,
    zoom = 1
  ) {
    this.canvasWidth = canvasWidth;
    this.canvasHeight = canvasHeight;
    this.centerX = centerX;
    this.centerY = centerY;
    this.zoom = Math.max(ViewportState.MIN_ZOOM, Math.min(ViewportState.MAX_ZOOM, zoom));
  }

  /**
   * Convert world coordinates to screen coordinates.
   * screenX = (wx - centerX) * zoom + canvasWidth / 2
   * screenY = -(wy - centerY) * zoom + canvasHeight / 2
   */
  worldToScreen(wx: number, wy: number): Point2D {
    return {
      x: (wx - this.centerX) * this.zoom + this.canvasWidth / 2,
      y: -(wy - this.centerY) * this.zoom + this.canvasHeight / 2,
    };
  }

  /**
   * Convert screen coordinates to world coordinates (inverse of worldToScreen).
   */
  screenToWorld(sx: number, sy: number): Point2D {
    return {
      x: (sx - this.canvasWidth / 2) / this.zoom + this.centerX,
      y: -(sy - this.canvasHeight / 2) / this.zoom + this.centerY,
    };
  }

  /**
   * Pan the viewport by a screen-space delta.
   * Shifts center by (-dx/zoom, dy/zoom) to account for Y-axis flip.
   */
  pan(screenDx: number, screenDy: number): void {
    this.centerX -= screenDx / this.zoom;
    this.centerY += screenDy / this.zoom;
  }

  /**
   * Zoom at a specific screen position, preserving the world point under the cursor.
   * Clamps zoom to [MIN_ZOOM, MAX_ZOOM].
   */
  zoomAt(screenX: number, screenY: number, factor: number): void {
    // Get world point under cursor before zoom
    const worldBefore = this.screenToWorld(screenX, screenY);

    // Apply zoom factor with clamping
    this.zoom = Math.max(
      ViewportState.MIN_ZOOM,
      Math.min(ViewportState.MAX_ZOOM, this.zoom * factor)
    );

    // Get world point under cursor after zoom (with new zoom but old center)
    const worldAfter = this.screenToWorld(screenX, screenY);

    // Adjust center so the world point stays under the cursor
    this.centerX += worldBefore.x - worldAfter.x;
    this.centerY += worldBefore.y - worldAfter.y;
  }

  /**
   * Fit the viewport to contain the given bounding box with a margin.
   * @param bounds The bounding box to fit
   * @param margin Fraction of extra space (default 0.1 = 10%)
   */
  zoomExtents(bounds: BoundingBox, margin = 0.1): void {
    const bw = bounds.maxX - bounds.minX;
    const bh = bounds.maxY - bounds.minY;

    if (bw <= 0 && bh <= 0) return;

    // Center on the bounding box
    this.centerX = (bounds.minX + bounds.maxX) / 2;
    this.centerY = (bounds.minY + bounds.maxY) / 2;

    // Compute zoom to fit with margin
    const marginFactor = 1 + margin * 2;
    const zoomX = this.canvasWidth / (bw * marginFactor || 1);
    const zoomY = this.canvasHeight / (bh * marginFactor || 1);

    this.zoom = Math.max(
      ViewportState.MIN_ZOOM,
      Math.min(ViewportState.MAX_ZOOM, Math.min(zoomX, zoomY))
    );
  }

  /**
   * Compute the world-space bounding box of the current viewport.
   */
  getVisibleBounds(): BoundingBox {
    const topLeft = this.screenToWorld(0, 0);
    const bottomRight = this.screenToWorld(this.canvasWidth, this.canvasHeight);

    return {
      minX: Math.min(topLeft.x, bottomRight.x),
      minY: Math.min(topLeft.y, bottomRight.y),
      maxX: Math.max(topLeft.x, bottomRight.x),
      maxY: Math.max(topLeft.y, bottomRight.y),
    };
  }

  /**
   * Return a transform matrix for the viewport.
   * Uses a simple object with a/b/c/d/e/f properties compatible with Canvas2D setTransform.
   */
  getTransformMatrix(): { a: number; b: number; c: number; d: number; e: number; f: number } {
    // Canvas2D transform: [a c e; b d f; 0 0 1]
    // screenX = a * worldX + c * worldY + e
    // screenY = b * worldX + d * worldY + f
    //
    // From our formulas:
    // screenX = zoom * worldX - zoom * centerX + canvasWidth/2
    // screenY = -zoom * worldY + zoom * centerY + canvasHeight/2
    return {
      a: this.zoom,
      b: 0,
      c: 0,
      d: -this.zoom,
      e: -this.centerX * this.zoom + this.canvasWidth / 2,
      f: this.centerY * this.zoom + this.canvasHeight / 2,
    };
  }
}
