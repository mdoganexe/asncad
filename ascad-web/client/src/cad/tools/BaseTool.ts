import type {
  CadEntity,
  CadMouseEvent,
  ToolName,
  ToolState,
  Point2D,
  Command,
} from '../core/types';
import type { EntityModel } from '../core/EntityModel';
import type { CommandStack } from '../core/CommandStack';
import type { SelectionManager } from '../core/SelectionManager';
import type { SnapManager } from './SnapManager';
import type { ViewportState } from '../rendering/ViewportState';

/**
 * Engine modules that tools need access to.
 */
export interface ToolContext {
  entityModel: EntityModel;
  commandStack: CommandStack;
  snapManager: SnapManager;
  selectionManager: SelectionManager;
  viewport: ViewportState;
  emitEvent?: (event: string, data?: any) => void;
  requestRender?: () => void;
}

/**
 * Abstract base class for all CAD drawing/manipulation tools.
 * Implements a state machine: idle → first_point → preview → complete → idle.
 */
export abstract class BaseTool {
  abstract readonly name: ToolName;
  abstract readonly prompt: string;

  protected state: ToolState = 'idle';
  protected context!: ToolContext;

  /** Set the engine context (called by ToolManager on registration). */
  setContext(context: ToolContext): void {
    this.context = context;
  }

  // =========================================================================
  // State machine
  // =========================================================================

  getState(): ToolState {
    return this.state;
  }

  protected setState(newState: ToolState): void {
    this.state = newState;
  }

  // =========================================================================
  // Lifecycle
  // =========================================================================

  /** Called when the tool becomes active. */
  activate(): void {
    this.state = 'idle';
  }

  /** Called when the tool is deactivated (another tool takes over). */
  deactivate(): void {
    this.cancel();
    this.state = 'idle';
  }

  /** Cancel the current operation and reset to idle. */
  cancel(): void {
    this.state = 'idle';
  }

  // =========================================================================
  // Abstract input handlers — subclasses must implement
  // =========================================================================

  abstract onMouseDown(event: CadMouseEvent): void;
  abstract onMouseMove(event: CadMouseEvent): void;
  abstract onMouseUp(event: CadMouseEvent): void;
  abstract onKeyDown(event: KeyboardEvent): void;
  abstract onNumericInput(value: number): void;

  /**
   * Return preview entities to be rendered during tool operation
   * (e.g., rubber-band line, preview circle).
   */
  abstract getPreviewEntities(): CadEntity[];

  // =========================================================================
  // Helpers
  // =========================================================================

  protected get entityModel(): EntityModel {
    return this.context.entityModel;
  }

  protected get commandStack(): CommandStack {
    return this.context.commandStack;
  }

  protected get selectionManager(): SelectionManager {
    return this.context.selectionManager;
  }

  protected get snapManager(): SnapManager {
    return this.context.snapManager;
  }

  protected get viewport(): ViewportState {
    return this.context.viewport;
  }

  /** Get the active layer properties for new entities. */
  protected getActiveLayerDefaults() {
    const layer = this.entityModel.getActiveLayer();
    return {
      layerName: layer.name,
      color: layer.color,
      lineType: layer.lineType,
      lineWeight: layer.lineWeight,
    };
  }

  /** Apply snap to a world point, returning the snapped point. */
  protected applySnap(event: CadMouseEvent, lastPoint?: Point2D): Point2D {
    const screenPt: Point2D = { x: event.screenX, y: event.screenY };
    const worldPt: Point2D = { x: event.worldX, y: event.worldY };

    const snap = this.snapManager.findSnap(screenPt, worldPt, lastPoint);
    let result = snap ? snap.point : worldPt;

    if (lastPoint && this.snapManager.isOrthoEnabled()) {
      result = this.snapManager.applyOrtho(result, lastPoint);
    }

    return result;
  }
}

/**
 * Command to create a single entity.
 */
export class CreateEntityCommand implements Command {
  readonly description: string;
  private entity: CadEntity;
  private entityModel: EntityModel;

  constructor(entity: CadEntity, entityModel: EntityModel) {
    this.entity = entity;
    this.entityModel = entityModel;
    this.description = `Create ${entity.type}`;
  }

  execute(): void {
    this.entityModel.addEntity(this.entity);
  }

  undo(): void {
    this.entityModel.removeEntity(this.entity.id);
  }
}

/**
 * Command to remove a single entity.
 */
export class RemoveEntityCommand implements Command {
  readonly description: string;
  private entity: CadEntity;
  private entityModel: EntityModel;

  constructor(entity: CadEntity, entityModel: EntityModel) {
    this.entity = entity;
    this.entityModel = entityModel;
    this.description = `Remove ${entity.type}`;
  }

  execute(): void {
    this.entityModel.removeEntity(this.entity.id);
  }

  undo(): void {
    this.entityModel.addEntity(this.entity);
  }
}

/**
 * Command to modify an entity's properties.
 */
export class ModifyEntityCommand implements Command {
  readonly description: string;
  private entityId: string;
  private oldValues: Partial<CadEntity>;
  private newValues: Partial<CadEntity>;
  private entityModel: EntityModel;

  constructor(
    entityId: string,
    oldValues: Partial<CadEntity>,
    newValues: Partial<CadEntity>,
    entityModel: EntityModel
  ) {
    this.entityId = entityId;
    this.oldValues = oldValues;
    this.newValues = newValues;
    this.entityModel = entityModel;
    this.description = 'Modify entity';
  }

  execute(): void {
    this.entityModel.updateEntity(this.entityId, this.newValues);
  }

  undo(): void {
    this.entityModel.updateEntity(this.entityId, this.oldValues);
  }
}
