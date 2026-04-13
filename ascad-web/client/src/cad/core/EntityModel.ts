import type {
  CadEntity,
  Layer,
  BlockDefinition,
  BoundingBox,
  Point2D,
} from './types';
import { DEFAULT_LAYERS } from './types';
import { SpatialIndex } from './SpatialIndex';

/**
 * Stores all entities, manages layers, and maintains the spatial index.
 * Single source of truth for drawing data.
 */
export class EntityModel {
  private entities: Map<string, CadEntity>;
  private layers: Map<string, Layer>;
  private blockDefs: Map<string, BlockDefinition>;
  private spatialIndex: SpatialIndex;
  private activeLayerName: string;

  constructor() {
    this.entities = new Map();
    this.layers = new Map();
    this.blockDefs = new Map();
    this.spatialIndex = new SpatialIndex();
    this.activeLayerName = '0';

    // Initialize with default layers
    for (const layer of DEFAULT_LAYERS) {
      this.layers.set(layer.name, { ...layer });
    }
  }

  // =========================================================================
  // Entity CRUD
  // =========================================================================

  addEntity(entity: CadEntity): void {
    this.entities.set(entity.id, entity);
    this.spatialIndex.insert(entity);
  }

  removeEntity(id: string): CadEntity | undefined {
    const entity = this.entities.get(id);
    if (entity) {
      this.entities.delete(id);
      this.spatialIndex.remove(entity);
    }
    return entity;
  }

  getEntity(id: string): CadEntity | undefined {
    return this.entities.get(id);
  }

  updateEntity(id: string, updates: Partial<CadEntity>): void {
    const entity = this.entities.get(id);
    if (!entity) return;
    Object.assign(entity, updates);
    this.spatialIndex.update(entity);
  }

  getAllEntities(): CadEntity[] {
    return Array.from(this.entities.values());
  }

  getEntitiesByLayer(layerName: string): CadEntity[] {
    return this.getAllEntities().filter((e) => e.layerName === layerName);
  }

  // =========================================================================
  // Spatial Queries (delegate to SpatialIndex)
  // =========================================================================

  queryRect(bounds: BoundingBox): CadEntity[] {
    const ids = this.spatialIndex.queryRect(bounds);
    return ids
      .map((id) => this.entities.get(id))
      .filter((e): e is CadEntity => e !== undefined);
  }

  queryPoint(point: Point2D, tolerance: number): CadEntity[] {
    const ids = this.spatialIndex.queryPoint(point, tolerance);
    return ids
      .map((id) => this.entities.get(id))
      .filter((e): e is CadEntity => e !== undefined);
  }

  hitTest(point: Point2D, tolerance: number): CadEntity | undefined {
    const candidates = this.queryPoint(point, tolerance);
    // Return the first visible, unlocked entity (topmost)
    return candidates.find((e) => {
      const layer = this.layers.get(e.layerName);
      return e.visible && layer?.visible !== false;
    });
  }

  // =========================================================================
  // Layer Management
  // =========================================================================

  addLayer(layer: Layer): void {
    this.layers.set(layer.name, { ...layer });
  }

  removeLayer(name: string): boolean {
    // Prevent deletion of default layer "0"
    if (name === '0') return false;
    if (!this.layers.has(name)) return false;
    this.layers.delete(name);
    // If the active layer was removed, switch to "0"
    if (this.activeLayerName === name) {
      this.activeLayerName = '0';
    }
    return true;
  }

  getLayer(name: string): Layer | undefined {
    return this.layers.get(name);
  }

  getAllLayers(): Layer[] {
    return Array.from(this.layers.values());
  }

  setActiveLayer(name: string): void {
    if (this.layers.has(name)) {
      this.activeLayerName = name;
    }
  }

  getActiveLayer(): Layer {
    return this.layers.get(this.activeLayerName)!;
  }

  getActiveLayerName(): string {
    return this.activeLayerName;
  }

  // =========================================================================
  // Block Definition Registry
  // =========================================================================

  addBlockDef(def: BlockDefinition): void {
    this.blockDefs.set(def.name, def);
  }

  getBlockDef(name: string): BlockDefinition | undefined {
    return this.blockDefs.get(name);
  }

  getAllBlockDefs(): BlockDefinition[] {
    return Array.from(this.blockDefs.values());
  }

  // =========================================================================
  // Bulk Operations
  // =========================================================================

  getVisibleEntities(): CadEntity[] {
    return this.getAllEntities().filter((entity) => {
      if (!entity.visible) return false;
      const layer = this.layers.get(entity.layerName);
      return layer ? layer.visible : true;
    });
  }

  getEntityCount(): number {
    return this.entities.size;
  }

  clear(): void {
    this.entities.clear();
    this.spatialIndex.clear();
  }
}
