import type { Layer } from '../../core/types';
import { COLOR_TO_ACI, LINETYPE_TO_DXF } from '../../core/types';
import { DxfWriter } from './DxfWriter';

/**
 * Maps Layer objects to DXF LAYER table entries.
 */
export class DxfLayerMapper {
  /**
   * Write a LAYER table containing all provided layers.
   */
  writeLayerTable(writer: DxfWriter, layers: Layer[]): void {
    writer.writeGroupCode(0, 'TABLE');
    writer.writeGroupCode(2, 'LAYER');
    writer.writeGroupCode(70, layers.length);

    for (const layer of layers) {
      this.writeLayer(writer, layer);
    }

    writer.writeGroupCode(0, 'ENDTAB');
  }

  /**
   * Write a single LAYER table entry.
   */
  writeLayer(writer: DxfWriter, layer: Layer): void {
    writer.writeGroupCode(0, 'LAYER');
    // Layer name
    writer.writeGroupCode(2, layer.name);
    // Flags: 0 = normal, 1 = frozen, 4 = locked
    let flags = 0;
    if (layer.locked) flags |= 4;
    if (!layer.visible) flags |= 1;
    writer.writeGroupCode(70, flags);
    // ACI color
    writer.writeGroupCode(62, this.getAciColor(layer.color));
    // Line type name
    writer.writeGroupCode(6, LINETYPE_TO_DXF[layer.lineType] || 'CONTINUOUS');
    // Line weight (in 100ths of mm)
    writer.writeGroupCode(370, Math.round(layer.lineWeight * 100));
  }

  /**
   * Convert hex color to ACI color number.
   */
  private getAciColor(hexColor: string): number {
    const upper = hexColor.toUpperCase();
    return COLOR_TO_ACI[upper] ?? 7; // default to white
  }
}
