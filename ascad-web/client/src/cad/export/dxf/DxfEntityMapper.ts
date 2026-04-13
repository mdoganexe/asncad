import type {
  CadEntity,
  LineEntity,
  PolylineEntity,
  CircleEntity,
  ArcEntity,
  TextEntity,
  DimensionEntity,
  HatchEntity,
  BlockReferenceEntity,
} from '../../core/types';
import { DxfWriter } from './DxfWriter';

/**
 * Maps CadEntity objects to DXF entity representations.
 */
export class DxfEntityMapper {
  /** Dispatch entity to the appropriate mapper. */
  writeEntity(writer: DxfWriter, entity: CadEntity): void {
    switch (entity.type) {
      case 'line':
        this.writeLine(writer, entity as LineEntity);
        break;
      case 'circle':
        this.writeCircle(writer, entity as CircleEntity);
        break;
      case 'arc':
        this.writeArc(writer, entity as ArcEntity);
        break;
      case 'polyline':
        this.writePolyline(writer, entity as PolylineEntity);
        break;
      case 'text':
        this.writeText(writer, entity as TextEntity);
        break;
      case 'dimension':
        this.writeDimension(writer, entity as DimensionEntity);
        break;
      case 'hatch':
        this.writeHatch(writer, entity as HatchEntity);
        break;
      case 'block_reference':
        this.writeInsert(writer, entity as BlockReferenceEntity);
        break;
    }
  }

  /** Write common entity properties (layer, color). */
  private writeCommon(writer: DxfWriter, entity: CadEntity): void {
    writer.writeGroupCode(8, entity.layerName);
  }

  /** LINE entity: 10/20 start, 11/21 end. */
  writeLine(writer: DxfWriter, entity: LineEntity): void {
    writer.writeGroupCode(0, 'LINE');
    this.writeCommon(writer, entity);
    writer.writeGroupCode(10, entity.start.x);
    writer.writeGroupCode(20, entity.start.y);
    writer.writeGroupCode(30, 0);
    writer.writeGroupCode(11, entity.end.x);
    writer.writeGroupCode(21, entity.end.y);
    writer.writeGroupCode(31, 0);
  }

  /** CIRCLE entity: 10/20 center, 40 radius. */
  writeCircle(writer: DxfWriter, entity: CircleEntity): void {
    writer.writeGroupCode(0, 'CIRCLE');
    this.writeCommon(writer, entity);
    writer.writeGroupCode(10, entity.center.x);
    writer.writeGroupCode(20, entity.center.y);
    writer.writeGroupCode(30, 0);
    writer.writeGroupCode(40, entity.radius);
  }

  /** ARC entity: 10/20 center, 40 radius, 50 startAngle°, 51 endAngle°. */
  writeArc(writer: DxfWriter, entity: ArcEntity): void {
    writer.writeGroupCode(0, 'ARC');
    this.writeCommon(writer, entity);
    writer.writeGroupCode(10, entity.center.x);
    writer.writeGroupCode(20, entity.center.y);
    writer.writeGroupCode(30, 0);
    writer.writeGroupCode(40, entity.radius);
    // DXF uses degrees
    writer.writeGroupCode(50, (entity.startAngle * 180) / Math.PI);
    writer.writeGroupCode(51, (entity.endAngle * 180) / Math.PI);
  }

  /** LWPOLYLINE entity: 90 vertex count, 70 closed flag, 10/20 per vertex. */
  writePolyline(writer: DxfWriter, entity: PolylineEntity): void {
    writer.writeGroupCode(0, 'LWPOLYLINE');
    this.writeCommon(writer, entity);
    writer.writeGroupCode(90, entity.vertices.length);
    writer.writeGroupCode(70, entity.closed ? 1 : 0);
    for (const v of entity.vertices) {
      writer.writeGroupCode(10, v.x);
      writer.writeGroupCode(20, v.y);
    }
  }

  /** TEXT entity: 10/20 insertion, 40 height, 1 content, 50 rotation°. */
  writeText(writer: DxfWriter, entity: TextEntity): void {
    writer.writeGroupCode(0, 'TEXT');
    this.writeCommon(writer, entity);
    writer.writeGroupCode(10, entity.position.x);
    writer.writeGroupCode(20, entity.position.y);
    writer.writeGroupCode(30, 0);
    writer.writeGroupCode(40, entity.fontSize);
    writer.writeGroupCode(1, entity.content);
    writer.writeGroupCode(50, (entity.rotation * 180) / Math.PI);
  }

  /** DIMENSION entity: 10/20 def point, 13/23 def point 2, 14/24 dim line, 1 text, 70 type. */
  writeDimension(writer: DxfWriter, entity: DimensionEntity): void {
    writer.writeGroupCode(0, 'DIMENSION');
    this.writeCommon(writer, entity);
    // Dimension type flag
    const typeFlag = entity.dimensionType === 'angular' ? 2
      : entity.dimensionType === 'radial' ? 4
      : 0; // linear/aligned
    writer.writeGroupCode(70, typeFlag);
    // Definition point (dimension line location)
    writer.writeGroupCode(10, entity.dimLinePoint.x);
    writer.writeGroupCode(20, entity.dimLinePoint.y);
    writer.writeGroupCode(30, 0);
    // First definition point
    writer.writeGroupCode(13, entity.defPoint1.x);
    writer.writeGroupCode(23, entity.defPoint1.y);
    writer.writeGroupCode(33, 0);
    // Second definition point
    writer.writeGroupCode(14, entity.defPoint2.x);
    writer.writeGroupCode(24, entity.defPoint2.y);
    writer.writeGroupCode(34, 0);
    // Text override
    const text = entity.textOverride || entity.measurementValue.toFixed(entity.decimalPrecision);
    writer.writeGroupCode(1, text);
  }

  /** HATCH entity: 2 pattern name, 41 scale, 52 angle, boundary path data. */
  writeHatch(writer: DxfWriter, entity: HatchEntity): void {
    writer.writeGroupCode(0, 'HATCH');
    this.writeCommon(writer, entity);
    writer.writeGroupCode(2, entity.pattern);
    writer.writeGroupCode(70, entity.pattern === 'SOLID' ? 1 : 0); // solid fill flag
    writer.writeGroupCode(71, 0); // associativity
    // Number of boundary paths
    writer.writeGroupCode(91, 1);
    // Boundary path type: polyline
    writer.writeGroupCode(92, 2);
    writer.writeGroupCode(72, 1); // has bulge
    writer.writeGroupCode(73, 1); // is closed
    writer.writeGroupCode(93, entity.boundaryPoints.length);
    for (const p of entity.boundaryPoints) {
      writer.writeGroupCode(10, p.x);
      writer.writeGroupCode(20, p.y);
      writer.writeGroupCode(42, 0); // bulge
    }
    // Pattern data
    writer.writeGroupCode(41, entity.patternScale);
    writer.writeGroupCode(52, (entity.patternAngle * 180) / Math.PI);
  }

  /** INSERT entity: 2 block name, 10/20 insertion, 41/42 scale, 50 rotation°. */
  writeInsert(writer: DxfWriter, entity: BlockReferenceEntity): void {
    writer.writeGroupCode(0, 'INSERT');
    this.writeCommon(writer, entity);
    writer.writeGroupCode(2, entity.blockDefName);
    writer.writeGroupCode(10, entity.insertionPoint.x);
    writer.writeGroupCode(20, entity.insertionPoint.y);
    writer.writeGroupCode(30, 0);
    writer.writeGroupCode(41, entity.scaleX);
    writer.writeGroupCode(42, entity.scaleY);
    writer.writeGroupCode(50, (entity.rotation * 180) / Math.PI);
  }
}
