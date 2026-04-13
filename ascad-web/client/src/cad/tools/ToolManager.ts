import type { CadMouseEvent, ToolName, Point2D } from '../core/types';
import type { BaseTool, ToolContext } from './BaseTool';

/**
 * Manages the active drawing tool and routes input events.
 */
export class ToolManager {
  private tools: Map<ToolName, BaseTool> = new Map();
  private activeTool: BaseTool | null = null;
  private context: ToolContext | null = null;

  /** Set the shared tool context (engine modules). */
  setContext(context: ToolContext): void {
    this.context = context;
    // Update context on all registered tools
    for (const tool of this.tools.values()) {
      tool.setContext(context);
    }
  }

  /** Register a tool instance. */
  registerTool(tool: BaseTool): void {
    this.tools.set(tool.name, tool);
    if (this.context) {
      tool.setContext(this.context);
    }
  }

  /** Activate a tool by name. Deactivates the current tool first. */
  activateTool(name: ToolName): void {
    const tool = this.tools.get(name);
    if (!tool) return;

    if (this.activeTool) {
      this.activeTool.deactivate();
    }

    this.activeTool = tool;
    tool.activate();
  }

  /** Deactivate the current tool. */
  deactivateTool(): void {
    if (this.activeTool) {
      this.activeTool.deactivate();
      this.activeTool = null;
    }
  }

  /** Get the currently active tool. */
  getActiveTool(): BaseTool | null {
    return this.activeTool;
  }

  /** Get a registered tool by name. */
  getTool(name: ToolName): BaseTool | undefined {
    return this.tools.get(name);
  }

  // =========================================================================
  // Input routing — applies snap before forwarding to active tool
  // =========================================================================

  handleMouseDown(event: CadMouseEvent): void {
    if (!this.activeTool) return;
    const snapped = this.applySnapToEvent(event);
    this.activeTool.onMouseDown(snapped);
  }

  handleMouseMove(event: CadMouseEvent): void {
    if (!this.activeTool) return;
    const snapped = this.applySnapToEvent(event);
    this.activeTool.onMouseMove(snapped);
  }

  handleMouseUp(event: CadMouseEvent): void {
    if (!this.activeTool) return;
    const snapped = this.applySnapToEvent(event);
    this.activeTool.onMouseUp(snapped);
  }

  handleKeyDown(event: KeyboardEvent): void {
    if (!this.activeTool) return;
    this.activeTool.onKeyDown(event);
  }

  handleNumericInput(value: number): void {
    if (!this.activeTool) return;
    this.activeTool.onNumericInput(value);
  }

  // =========================================================================
  // Snap integration
  // =========================================================================

  private applySnapToEvent(event: CadMouseEvent): CadMouseEvent {
    if (!this.context) return event;

    const screenPt: Point2D = { x: event.screenX, y: event.screenY };
    const worldPt: Point2D = { x: event.worldX, y: event.worldY };

    const snap = this.context.snapManager.findSnap(screenPt, worldPt);
    if (snap) {
      return {
        ...event,
        worldX: snap.point.x,
        worldY: snap.point.y,
      };
    }

    return event;
  }
}
