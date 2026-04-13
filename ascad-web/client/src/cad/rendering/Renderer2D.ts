import type {
  CadEntity,
  Point2D,
  SnapResult,
  GripPoint,
} from '../core/types';
import type { EntityModel } from '../core/EntityModel';
import type { ViewportState } from './ViewportState';
import { GridRenderer } from './GridRenderer';
import { CursorRenderer } from './CursorRenderer';
import { renderEntity } from './EntityRenderers';

/**
 * Full 2D rendering pipeline using Canvas2D.
 * Pipeline: clear → transform → grid → entities → selection → grips → preview → snap → cursor
 */
export class Renderer2D {
  private ctx: CanvasRenderingContext2D;
  private viewport: ViewportState;
  private entityModel: EntityModel;
  private gridRenderer: GridRenderer;
  private cursorRenderer: CursorRenderer;

  // External state references (set by CadEngine)
  private selectedIds: Set<string> = new Set();
  private gripPoints: GripPoint[] = [];
  private previewEntities: CadEntity[] = [];
  private currentSnap: SnapResult | null = null;
  private cursorWorldPos: Point2D = { x: 0, y: 0 };

  private renderScheduled = false;
  private backgroundColor = '#1a1a2e';
  private selectionColor = '#4488FF';
  private gripColor = '#00FF00';
  private gripSize = 4; // pixels

  constructor(
    ctx: CanvasRenderingContext2D,
    viewport: ViewportState,
    entityModel: EntityModel
  ) {
    this.ctx = ctx;
    this.viewport = viewport;
    this.entityModel = entityModel;
    this.gridRenderer = new GridRenderer();
    this.cursorRenderer = new CursorRenderer();
  }

  // =========================================================================
  // State setters (called by CadEngine)
  // =========================================================================

  setSelectedIds(ids: Set<string>): void {
    this.selectedIds = ids;
  }

  setGripPoints(grips: GripPoint[]): void {
    this.gripPoints = grips;
  }

  setPreviewEntities(entities: CadEntity[]): void {
    this.previewEntities = entities;
  }

  setCurrentSnap(snap: SnapResult | null): void {
    this.currentSnap = snap;
  }

  setCursorWorldPos(pos: Point2D): void {
    this.cursorWorldPos = pos;
  }

  // =========================================================================
  // Render scheduling
  // =========================================================================

  requestRender(): void {
    if (this.renderScheduled) return;
    this.renderScheduled = true;
    requestAnimationFrame(() => {
      this.renderScheduled = false;
      this.render();
    });
  }

  // =========================================================================
  // Full render pipeline
  // =========================================================================

  render(): void {
    const { ctx, viewport } = this;
    const { canvasWidth, canvasHeight } = viewport;

    // 1. Clear canvas
    ctx.save();
    ctx.setTransform(1, 0, 0, 1, 0, 0);
    ctx.fillStyle = this.backgroundColor;
    ctx.fillRect(0, 0, canvasWidth, canvasHeight);
    ctx.restore();

    // 2. Render grid (uses its own world-to-screen transforms)
    this.gridRenderer.render(ctx, viewport);

    // 3. Query visible entities using spatial index
    const visibleBounds = viewport.getVisibleBounds();
    const allVisible = this.entityModel.queryRect(visibleBounds);

    // 4. Filter by layer visibility
    const layers = new Map(
      this.entityModel.getAllLayers().map((l) => [l.name, l])
    );
    const blockDefs = new Map(
      this.entityModel.getAllBlockDefs().map((b) => [b.name, b])
    );

    const entitiesToRender = allVisible.filter((e) => {
      if (!e.visible) return false;
      const layer = layers.get(e.layerName);
      return layer ? layer.visible : true;
    });

    // 5. Render entities
    for (const entity of entitiesToRender) {
      const layer = layers.get(entity.layerName);
      renderEntity(ctx, entity, viewport, layer, blockDefs);
    }

    // 6. Render selection highlights
    this.renderSelectionHighlights(entitiesToRender);

    // 7. Render grips
    this.renderGrips();

    // 8. Render tool preview entities
    this.renderToolPreview();

    // 9. Render snap indicator
    if (this.currentSnap) {
      this.cursorRenderer.renderSnapIndicator(ctx, this.currentSnap, viewport);
    }

    // 10. Render cursor
    this.cursorRenderer.renderCrosshair(ctx, this.cursorWorldPos, viewport);
    this.cursorRenderer.renderCoordinateReadout(ctx, this.cursorWorldPos, viewport);
  }

  private renderSelectionHighlights(visibleEntities: CadEntity[]): void {
    if (this.selectedIds.size === 0) return;

    const { ctx, viewport } = this;
    ctx.save();
    ctx.strokeStyle = this.selectionColor;
    ctx.lineWidth = 2;
    ctx.setLineDash([4, 4]);

    for (const entity of visibleEntities) {
      if (this.selectedIds.has(entity.id)) {
        const layer = this.entityModel.getLayer(entity.layerName);
        const blockDefs = new Map(
          this.entityModel.getAllBlockDefs().map((b) => [b.name, b])
        );
        renderEntity(ctx, entity, viewport, layer, blockDefs);
      }
    }

    ctx.restore();
  }

  private renderGrips(): void {
    if (this.gripPoints.length === 0) return;

    const { ctx, viewport } = this;
    ctx.save();

    for (const grip of this.gripPoints) {
      const sp = viewport.worldToScreen(grip.point.x, grip.point.y);
      ctx.fillStyle = this.gripColor;
      ctx.fillRect(
        sp.x - this.gripSize,
        sp.y - this.gripSize,
        this.gripSize * 2,
        this.gripSize * 2
      );
      ctx.strokeStyle = '#000000';
      ctx.lineWidth = 1;
      ctx.setLineDash([]);
      ctx.strokeRect(
        sp.x - this.gripSize,
        sp.y - this.gripSize,
        this.gripSize * 2,
        this.gripSize * 2
      );
    }

    ctx.restore();
  }

  private renderToolPreview(): void {
    if (this.previewEntities.length === 0) return;

    const { ctx, viewport } = this;
    ctx.save();
    ctx.globalAlpha = 0.6;
    ctx.setLineDash([5, 5]);

    for (const entity of this.previewEntities) {
      renderEntity(ctx, entity, viewport);
    }

    ctx.restore();
  }
}
