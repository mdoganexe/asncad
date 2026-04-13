import type {
  CadEntity,
  Layer,
  BlockDefinition,
  DrawingJson,
  DrawingState,
  ViewportStateJson,
  DrawingMetadata,
  DrawingType,
} from '../core/types';
import type { EntityModel } from '../core/EntityModel';
import type { ViewportState } from '../rendering/ViewportState';

/**
 * Converts the entity model to/from JSON for server persistence.
 */
export class DrawingSerializer {
  /**
   * Serialize the full drawing state to a DrawingJson object.
   */
  serialize(
    model: EntityModel,
    viewport: ViewportState,
    drawingType: DrawingType = 'cross-section',
    liftId = ''
  ): DrawingJson {
    const entities = model.getAllEntities().map((e) => this.serializeEntity(e));
    const layers = model.getAllLayers().map((l) => this.serializeLayer(l));
    const blockDefinitions = model.getAllBlockDefs().map((b) => this.serializeBlockDef(b));

    const viewportJson: ViewportStateJson = {
      centerX: viewport.centerX,
      centerY: viewport.centerY,
      zoom: viewport.zoom,
    };

    const metadata: DrawingMetadata = {
      drawingType,
      liftId,
      createdAt: new Date().toISOString(),
      updatedAt: new Date().toISOString(),
      version: 1,
    };

    const state: DrawingState = {
      entities: entities as CadEntity[],
      layers: layers as Layer[],
      blockDefinitions: blockDefinitions as BlockDefinition[],
      activeLayerName: model.getActiveLayerName(),
      viewport: viewportJson,
      metadata,
    };

    return { version: 1, state };
  }

  /**
   * Deserialize a DrawingJson object into the entity model and viewport.
   */
  deserialize(json: DrawingJson, model: EntityModel, viewport: ViewportState): void {
    if (!json || !json.state) return;

    const { state } = json;

    // Clear existing data
    model.clear();

    // Restore layers (clear defaults first, then add from JSON)
    for (const layerJson of state.layers) {
      const layer = this.deserializeLayer(layerJson);
      model.addLayer(layer);
    }

    // Set active layer
    if (state.activeLayerName) {
      model.setActiveLayer(state.activeLayerName);
    }

    // Restore block definitions
    for (const blockJson of state.blockDefinitions || []) {
      const blockDef = this.deserializeBlockDef(blockJson);
      model.addBlockDef(blockDef);
    }

    // Restore entities
    for (const entityJson of state.entities) {
      const entity = this.deserializeEntity(entityJson);
      model.addEntity(entity);
    }

    // Restore viewport
    if (state.viewport) {
      viewport.centerX = state.viewport.centerX;
      viewport.centerY = state.viewport.centerY;
      viewport.zoom = state.viewport.zoom;
    }
  }

  /** Serialize a single entity (identity for JSON-compatible objects). */
  serializeEntity(entity: CadEntity): CadEntity {
    // Deep clone to avoid mutation
    return JSON.parse(JSON.stringify(entity));
  }

  /** Deserialize a single entity from JSON. */
  deserializeEntity(json: CadEntity): CadEntity {
    return JSON.parse(JSON.stringify(json));
  }

  /** Serialize a layer. */
  serializeLayer(layer: Layer): Layer {
    return { ...layer };
  }

  /** Deserialize a layer. */
  deserializeLayer(json: Layer): Layer {
    return { ...json };
  }

  /** Serialize a block definition. */
  serializeBlockDef(def: BlockDefinition): BlockDefinition {
    return JSON.parse(JSON.stringify(def));
  }

  /** Deserialize a block definition. */
  deserializeBlockDef(json: BlockDefinition): BlockDefinition {
    return JSON.parse(JSON.stringify(json));
  }
}
