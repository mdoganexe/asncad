import type { EntityModel } from '../core/EntityModel';
import type { BlockDefinition } from '../core/types';
import { DxfWriter } from './dxf/DxfWriter';
import { DxfLayerMapper } from './dxf/DxfLayerMapper';
import { DxfEntityMapper } from './dxf/DxfEntityMapper';

/**
 * Orchestrates full DXF file generation: HEADER → TABLES → BLOCKS → ENTITIES → EOF.
 */
export class DxfExporter {
  private layerMapper = new DxfLayerMapper();
  private entityMapper = new DxfEntityMapper();

  /** Export the entire entity model to a DXF string. */
  export(model: EntityModel): string {
    const writer = new DxfWriter();
    const entities = model.getAllEntities();
    const layers = model.getAllLayers();
    const blockDefs = model.getAllBlockDefs();

    // Compute extents
    const ext = this.computeExtents(model);

    // 1. HEADER
    writer.writeHeader(ext.min, ext.max);

    // 2. TABLES (LTYPE + LAYER)
    writer.writeTablesStart();
    writer.writeLineTypes();
    this.layerMapper.writeLayerTable(writer, layers);
    writer.writeTablesEnd();

    // 3. BLOCKS
    writer.writeBlocksStart();
    for (const def of blockDefs) {
      this.writeBlockDef(writer, def);
    }
    writer.writeBlocksEnd();

    // 4. ENTITIES
    writer.writeEntitiesStart();
    for (const entity of entities) {
      this.entityMapper.writeEntity(writer, entity);
    }
    writer.writeEntitiesEnd();

    // 5. EOF
    writer.writeEof();

    return writer.toString();
  }

  /** Write a block definition as BLOCK/ENDBLK pair. */
  private writeBlockDef(writer: DxfWriter, def: BlockDefinition): void {
    writer.writeGroupCode(0, 'BLOCK');
    writer.writeGroupCode(2, def.name);
    writer.writeGroupCode(70, 0);
    writer.writeGroupCode(10, def.basePoint.x);
    writer.writeGroupCode(20, def.basePoint.y);
    writer.writeGroupCode(30, 0);

    // Write child entities
    for (const entity of def.entities) {
      this.entityMapper.writeEntity(writer, entity);
    }

    writer.writeGroupCode(0, 'ENDBLK');
  }

  /** Compute drawing extents from all entities. */
  private computeExtents(model: EntityModel): { min: { x: number; y: number }; max: { x: number; y: number } } {
    let minX = Infinity, minY = Infinity, maxX = -Infinity, maxY = -Infinity;
    for (const entity of model.getAllEntities()) {
      if (entity.type === 'line') {
        const e = entity as any;
        minX = Math.min(minX, e.start.x, e.end.x);
        minY = Math.min(minY, e.start.y, e.end.y);
        maxX = Math.max(maxX, e.start.x, e.end.x);
        maxY = Math.max(maxY, e.start.y, e.end.y);
      } else if (entity.type === 'circle') {
        const e = entity as any;
        minX = Math.min(minX, e.center.x - e.radius);
        minY = Math.min(minY, e.center.y - e.radius);
        maxX = Math.max(maxX, e.center.x + e.radius);
        maxY = Math.max(maxY, e.center.y + e.radius);
      } else if (entity.type === 'polyline') {
        const e = entity as any;
        for (const v of e.vertices) {
          minX = Math.min(minX, v.x);
          minY = Math.min(minY, v.y);
          maxX = Math.max(maxX, v.x);
          maxY = Math.max(maxY, v.y);
        }
      }
    }
    if (!isFinite(minX)) { minX = 0; minY = 0; maxX = 1000; maxY = 1000; }
    return { min: { x: minX, y: minY }, max: { x: maxX, y: maxY } };
  }
}
