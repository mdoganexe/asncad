import type {
  CadEvent,
  CadEventHandler,
  CadMouseEvent,
  DrawingType,
  DrawingJson,
  LiftParams,
  Point2D,
  PdfScale,
  ToolName,
  Layer,
} from './types';
import { EntityModel } from './EntityModel';
import { CommandStack } from './CommandStack';
import { SelectionManager } from './SelectionManager';
import { ViewportState } from '../rendering/ViewportState';
import { SnapManager } from '../tools/SnapManager';
import { ToolManager } from '../tools/ToolManager';
import { BlockLibrary } from '../blocks/BlockLibrary';
import { AutoDrawingGenerator } from '../generation/AutoDrawingGenerator';

// Import tools
import { SelectTool } from '../tools/SelectTool';
import { LineTool } from '../tools/LineTool';
import { PolylineTool } from '../tools/PolylineTool';
import { RectangleTool } from '../tools/RectangleTool';
import { CircleTool } from '../tools/CircleTool';
import { ArcTool } from '../tools/ArcTool';
import { DimensionTool } from '../tools/DimensionTool';
import { TextTool } from '../tools/TextTool';
import { MoveTool } from '../tools/MoveTool';
import { CopyTool } from '../tools/CopyTool';
import { RotateTool } from '../tools/RotateTool';
import { ScaleTool } from '../tools/ScaleTool';
import { MirrorTool } from '../tools/MirrorTool';
import { OffsetTool } from '../tools/OffsetTool';

import type { ToolContext } from '../tools/BaseTool';

/**
 * Main CAD engine orchestrator.
 * Owns all subsystems, handles lifecycle, and exposes the public API.
 */
export class CadEngine {
  readonly entityModel: EntityModel;
  readonly commandStack: CommandStack;
  readonly toolManager: ToolManager;
  readonly selectionManager: SelectionManager;
  readonly snapManager: SnapManager;
  readonly blockLibrary: BlockLibrary;
  readonly viewportState: ViewportState;
  readonly autoDrawingGenerator: AutoDrawingGenerator;

  private eventHandlers: Map<CadEvent, Set<CadEventHandler>> = new Map();
  private liftParams: LiftParams | null = null;
  private _snapEnabled = true;

  constructor() {
    this.entityModel = new EntityModel();
    this.commandStack = new CommandStack();
    this.selectionManager = new SelectionManager(this.entityModel);
    this.viewportState = new ViewportState();
    this.snapManager = new SnapManager();
    this.toolManager = new ToolManager();
    this.blockLibrary = new BlockLibrary();
    this.autoDrawingGenerator = new AutoDrawingGenerator(this.entityModel, this.blockLibrary);

    // Wire snap manager
    this.snapManager.setEntityModel(this.entityModel);
    this.snapManager.setViewport(this.viewportState);

    // Create tool context
    const toolContext: ToolContext = {
      entityModel: this.entityModel,
      commandStack: this.commandStack,
      snapManager: this.snapManager,
      selectionManager: this.selectionManager,
      viewport: this.viewportState,
      emitEvent: (event: string, data?: any) => this.emit(event as CadEvent, data),
      requestRender: () => {},
    };

    this.toolManager.setContext(toolContext);

    // Register all tools
    this.registerTools();

    // Register built-in blocks
    this.blockLibrary.registerBuiltins();
  }

  // =========================================================================
  // Lifecycle
  // =========================================================================

  initialize(): void {
    this.toolManager.activateTool('select');
  }

  dispose(): void {
    this.toolManager.deactivateTool();
    this.eventHandlers.clear();
  }

  // =========================================================================
  // Drawing tools
  // =========================================================================

  activateTool(toolName: ToolName): void {
    this.toolManager.activateTool(toolName);
    this.emit('toolChanged', { tool: toolName });
  }

  cancelCurrentTool(): void {
    const tool = this.toolManager.getActiveTool();
    if (tool) {
      tool.cancel();
    }
  }

  // =========================================================================
  // Commands (undo/redo)
  // =========================================================================

  undo(): void {
    if (this.commandStack.undo()) {
      this.emit('undoRedoChanged', {});
      this.emit('commandExecuted', { action: 'undo' });
    }
  }

  redo(): void {
    if (this.commandStack.redo()) {
      this.emit('undoRedoChanged', {});
      this.emit('commandExecuted', { action: 'redo' });
    }
  }

  // =========================================================================
  // Selection operations
  // =========================================================================

  deleteSelected(): void {
    const selected = this.selectionManager.getSelectedEntities();
    if (selected.length === 0) return;

    this.commandStack.beginGroup('Delete selected');
    for (const entity of selected) {
      const layer = this.entityModel.getLayer(entity.layerName);
      if (layer?.locked) continue;
      this.entityModel.removeEntity(entity.id);
    }
    this.commandStack.endGroup();
    this.selectionManager.clearSelection();
    this.emit('selectionChanged', {});
  }

  // =========================================================================
  // Layer operations (Task 14.1)
  // =========================================================================

  /** Set the active layer. New entities will inherit this layer's properties. */
  setActiveLayer(layerName: string): void {
    const layer = this.entityModel.getLayer(layerName);
    if (!layer) return;
    this.entityModel.setActiveLayer(layerName);
    this.emit('layerChanged', { action: 'activeChanged', layerName });
  }

  /** Toggle layer visibility. */
  setLayerVisibility(layerName: string, visible: boolean): void {
    const layer = this.entityModel.getLayer(layerName);
    if (!layer) return;
    layer.visible = visible;
    this.emit('layerChanged', { action: 'visibilityChanged', layerName, visible });
  }

  /** Toggle layer lock. Locked layers prevent entity modification. */
  setLayerLock(layerName: string, locked: boolean): void {
    const layer = this.entityModel.getLayer(layerName);
    if (!layer) return;
    layer.locked = locked;
    this.emit('layerChanged', { action: 'lockChanged', layerName, locked });
  }

  /** Create a new custom layer. */
  createLayer(layer: Layer): void {
    this.entityModel.addLayer(layer);
    this.emit('layerChanged', { action: 'created', layerName: layer.name });
  }

  /** Rename a layer (not "0"). */
  renameLayer(oldName: string, newName: string): void {
    if (oldName === '0') return;
    const layer = this.entityModel.getLayer(oldName);
    if (!layer) return;

    // Update all entities on this layer
    const entities = this.entityModel.getEntitiesByLayer(oldName);
    for (const entity of entities) {
      this.entityModel.updateEntity(entity.id, { layerName: newName });
    }

    // Remove old, add new
    this.entityModel.removeLayer(oldName);
    this.entityModel.addLayer({ ...layer, name: newName });
    this.emit('layerChanged', { action: 'renamed', oldName, newName });
  }

  /** Delete a custom layer (not "0"). Entities move to "0". */
  deleteLayer(layerName: string): void {
    if (layerName === '0') return;

    // Move entities to layer "0"
    const entities = this.entityModel.getEntitiesByLayer(layerName);
    for (const entity of entities) {
      this.entityModel.updateEntity(entity.id, { layerName: '0' });
    }

    this.entityModel.removeLayer(layerName);
    this.emit('layerChanged', { action: 'deleted', layerName });
  }

  // =========================================================================
  // Block operations
  // =========================================================================

  insertBlock(defName: string, insertionPoint: Point2D, rotation = 0): void {
    if (!this.liftParams) return;
    const entities = this.blockLibrary.resolve(defName, this.liftParams);
    for (const entity of entities) {
      // Offset by insertion point
      this.entityModel.addEntity(entity);
    }
    this.emit('entityAdded', { count: entities.length });
  }

  // =========================================================================
  // Auto-generation
  // =========================================================================

  generateDrawing(type: DrawingType): void {
    if (!this.liftParams) return;
    this.autoDrawingGenerator.clearAutoGenerated();
    this.autoDrawingGenerator.generate(type, this.liftParams);
    this.emit('entityAdded', { type });
  }

  // =========================================================================
  // Parameter sync
  // =========================================================================

  updateLiftParams(params: LiftParams): void {
    const oldParams = this.liftParams;
    this.liftParams = params;

    // Forward sync: if params changed and we have auto-generated entities, regenerate
    if (oldParams && this.autoDrawingGenerator.getAutoGeneratedEntityIds().length > 0) {
      // Check if any relevant params changed
      const changed = oldParams.kuyuGenisligi !== params.kuyuGenisligi ||
        oldParams.kuyuDerinligi !== params.kuyuDerinligi ||
        oldParams.kabinGenisligi !== params.kabinGenisligi ||
        oldParams.kabinDerinligi !== params.kabinDerinligi ||
        oldParams.kapiGenisligi !== params.kapiGenisligi ||
        oldParams.kuyuDibi !== params.kuyuDibi ||
        oldParams.kuyuKafa !== params.kuyuKafa ||
        oldParams.beyanYuk !== params.beyanYuk;

      if (changed) {
        // Re-generate auto entities with new params
        this.autoDrawingGenerator.clearAutoGenerated();
        // Determine current drawing type from metadata or default
        this.emit('parameterChanged', { params, regenerate: true });
      }
    }

    this.emit('parameterChanged', { params });
  }

  /**
   * Reverse sync: when a dimension entity is edited, propagate the new value
   * back to the corresponding lift parameter.
   * Returns the parameter name and new value if applicable.
   */
  reverseSyncDimension(entityId: string, newValue: number): { paramName: string; value: number } | null {
    const mapping = this.autoDrawingGenerator.getParameterMapping();
    const paramName = mapping.get(entityId);
    if (!paramName || !this.liftParams) return null;

    // Update the lift param
    const params = { ...this.liftParams } as any;
    if (paramName in params) {
      params[paramName] = newValue;
      this.liftParams = params;
      return { paramName, value: newValue };
    }
    return null;
  }

  getLiftParams(): LiftParams | null {
    return this.liftParams;
  }

  // =========================================================================
  // Event system
  // =========================================================================

  on(event: CadEvent, handler: CadEventHandler): void {
    if (!this.eventHandlers.has(event)) {
      this.eventHandlers.set(event, new Set());
    }
    this.eventHandlers.get(event)!.add(handler);
  }

  off(event: CadEvent, handler: CadEventHandler): void {
    this.eventHandlers.get(event)?.delete(handler);
  }

  private emit(event: CadEvent, data?: any): void {
    const handlers = this.eventHandlers.get(event);
    if (handlers) {
      for (const handler of handlers) {
        handler(data);
      }
    }
  }

  // =========================================================================
  // Input routing (called from canvas event listeners)
  // =========================================================================

  handleMouseDown(event: CadMouseEvent): void {
    this.toolManager.handleMouseDown(event);
  }

  handleMouseMove(event: CadMouseEvent): void {
    this.toolManager.handleMouseMove(event);
  }

  handleMouseUp(event: CadMouseEvent): void {
    this.toolManager.handleMouseUp(event);
  }

  handleKeyDown(event: KeyboardEvent): void {
    // Global shortcuts
    if (event.key === 'Escape') {
      this.cancelCurrentTool();
      return;
    }
    if (event.ctrlKey && event.key === 'z') {
      event.preventDefault();
      this.undo();
      return;
    }
    if (event.ctrlKey && (event.key === 'y' || (event.shiftKey && event.key === 'Z'))) {
      event.preventDefault();
      this.redo();
      return;
    }
    if (event.key === 'Delete') {
      this.deleteSelected();
      return;
    }
    if (event.ctrlKey && event.key === 'a') {
      event.preventDefault();
      this.selectionManager.selectAll();
      this.emit('selectionChanged', {});
      return;
    }
    if (event.key === 'F8') {
      event.preventDefault();
      const current = this.snapManager.isOrthoEnabled();
      this.snapManager.setOrthoEnabled(!current);
      return;
    }
    if (event.key === 'F3') {
      event.preventDefault();
      // Toggle all snap modes
      const modes = ['endpoint', 'midpoint', 'center', 'intersection', 'perpendicular', 'nearest', 'grid'] as const;
      // Toggle: disable all if currently enabled, enable all if currently disabled
      this._snapEnabled = !this._snapEnabled;
      for (const mode of modes) {
        this.snapManager.setMode(mode, this._snapEnabled);
      }
      return;
    }

    this.toolManager.handleKeyDown(event);
  }

  handleNumericInput(value: number): void {
    this.toolManager.handleNumericInput(value);
  }

  // =========================================================================
  // Private
  // =========================================================================

  private registerTools(): void {
    this.toolManager.registerTool(new SelectTool());
    this.toolManager.registerTool(new LineTool());
    this.toolManager.registerTool(new PolylineTool());
    this.toolManager.registerTool(new RectangleTool());
    this.toolManager.registerTool(new CircleTool());
    this.toolManager.registerTool(new ArcTool());
    this.toolManager.registerTool(new DimensionTool());
    this.toolManager.registerTool(new TextTool());
    this.toolManager.registerTool(new MoveTool());
    this.toolManager.registerTool(new CopyTool());
    this.toolManager.registerTool(new RotateTool());
    this.toolManager.registerTool(new ScaleTool());
    this.toolManager.registerTool(new MirrorTool());
    this.toolManager.registerTool(new OffsetTool());
  }
}
