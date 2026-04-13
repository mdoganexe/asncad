import { v4 } from 'uuid';
import type {
  CadEntity,
  CadMouseEvent,
  ToolName,
  Point2D,
  BoundingBox,
} from '../core/types';
import { BaseTool } from './BaseTool';

/**
 * Selection tool: click to select, drag for box selection.
 * Left-to-right = window (fully contained), right-to-left = crossing (intersecting).
 * Shift+click = toggle selection.
 */
export class SelectTool extends BaseTool {
  readonly name: ToolName = 'select';
  readonly prompt = 'Select objects';

  private dragStart: Point2D | null = null;
  private dragCurrent: Point2D | null = null;
  private isDragging = false;
  private readonly DRAG_THRESHOLD = 5; // pixels

  activate(): void {
    super.activate();
    this.dragStart = null;
    this.dragCurrent = null;
    this.isDragging = false;
  }

  cancel(): void {
    super.cancel();
    this.dragStart = null;
    this.dragCurrent = null;
    this.isDragging = false;
  }

  onMouseDown(event: CadMouseEvent): void {
    if (event.button === 0) {
      this.dragStart = { x: event.screenX, y: event.screenY };
      this.dragCurrent = null;
      this.isDragging = false;
    }
  }

  onMouseMove(event: CadMouseEvent): void {
    if (!this.dragStart) return;

    const dx = event.screenX - this.dragStart.x;
    const dy = event.screenY - this.dragStart.y;

    if (Math.abs(dx) > this.DRAG_THRESHOLD || Math.abs(dy) > this.DRAG_THRESHOLD) {
      this.isDragging = true;
      this.dragCurrent = { x: event.screenX, y: event.screenY };
    }
  }

  onMouseUp(event: CadMouseEvent): void {
    if (event.button !== 0) return;

    if (this.isDragging && this.dragStart && this.dragCurrent) {
      // Box selection
      const startWorld = this.viewport.screenToWorld(this.dragStart.x, this.dragStart.y);
      const endWorld = this.viewport.screenToWorld(this.dragCurrent.x, this.dragCurrent.y);

      const bounds: BoundingBox = {
        minX: Math.min(startWorld.x, endWorld.x),
        minY: Math.min(startWorld.y, endWorld.y),
        maxX: Math.max(startWorld.x, endWorld.x),
        maxY: Math.max(startWorld.y, endWorld.y),
      };

      if (!event.shiftKey) {
        this.selectionManager.clearSelection();
      }

      // Left-to-right = window, right-to-left = crossing
      if (this.dragCurrent.x >= this.dragStart.x) {
        this.selectionManager.selectByWindow(bounds);
      } else {
        this.selectionManager.selectByCrossing(bounds);
      }
    } else {
      // Click selection
      const worldPt: Point2D = { x: event.worldX, y: event.worldY };
      const tolerance = 5 / this.viewport.zoom;
      const hit = this.entityModel.hitTest(worldPt, tolerance);

      if (event.shiftKey) {
        if (hit) {
          this.selectionManager.toggleEntity(hit.id);
        }
      } else {
        this.selectionManager.clearSelection();
        if (hit) {
          this.selectionManager.selectEntity(hit.id);
        }
      }
    }

    this.dragStart = null;
    this.dragCurrent = null;
    this.isDragging = false;
  }

  onKeyDown(_event: KeyboardEvent): void {
    // No key handling for select tool
  }

  onNumericInput(_value: number): void {
    // No numeric input for select tool
  }

  getPreviewEntities(): CadEntity[] {
    // Could return a selection rectangle preview, but keeping it simple
    return [];
  }
}
