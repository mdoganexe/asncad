import type {
  CadEntity,
  LineEntity,
  PolylineEntity,
  CircleEntity,
  ArcEntity,
  TextEntity,
  DimensionEntity,
  HatchEntity,
  Layer,
  LineType,
} from '../core/types';
import type { EntityModel } from '../core/EntityModel';

const SVG_DASH: Record<LineType, string> = {
  continuous: '',
  dashed: '10,5',
  center: '20,5,5,5',
  hidden: '5,5',
};

/**
 * Produces an SVG string from all visible entities with layer colors.
 */
export class SvgExporter {
  export(model: EntityModel): string {
    const entities = model.getVisibleEntities();
    const layers = new Map(model.getAllLayers().map((l) => [l.name, l]));

    // Compute viewBox from entity extents
    const ext = this.computeExtents(entities);
    const margin = 50;
    const vbX = ext.minX - margin;
    const vbY = -(ext.maxY + margin); // SVG Y is flipped
    const vbW = ext.maxX - ext.minX + margin * 2;
    const vbH = ext.maxY - ext.minY + margin * 2;

    const parts: string[] = [];
    parts.push(`<svg xmlns="http://www.w3.org/2000/svg" viewBox="${vbX} ${vbY} ${vbW} ${vbH}" width="${vbW}" height="${vbH}">`);
    parts.push(`<rect x="${vbX}" y="${vbY}" width="${vbW}" height="${vbH}" fill="#1a1a2e"/>`);

    for (const entity of entities) {
      const layer = layers.get(entity.layerName);
      const svg = this.entityToSvg(entity, layer);
      if (svg) parts.push(svg);
    }

    parts.push('</svg>');
    return parts.join('\n');
  }

  private entityToSvg(entity: CadEntity, layer?: Layer): string | null {
    const color = entity.color !== '#FFFFFF' || !layer ? entity.color : layer.color;
    const lw = entity.lineWeight > 0 ? entity.lineWeight : (layer?.lineWeight ?? 0.25);
    const lt = entity.lineType || layer?.lineType || 'continuous';
    const dash = SVG_DASH[lt] ? ` stroke-dasharray="${SVG_DASH[lt]}"` : '';
    const style = `stroke="${color}" stroke-width="${lw}" fill="none"${dash}`;

    switch (entity.type) {
      case 'line': {
        const e = entity as LineEntity;
        return `<line x1="${e.start.x}" y1="${-e.start.y}" x2="${e.end.x}" y2="${-e.end.y}" ${style}/>`;
      }
      case 'polyline': {
        const e = entity as PolylineEntity;
        if (e.vertices.length < 2) return null;
        const pts = e.vertices.map((v) => `${v.x},${-v.y}`).join(' ');
        const tag = e.closed ? 'polygon' : 'polyline';
        return `<${tag} points="${pts}" ${style}/>`;
      }
      case 'circle': {
        const e = entity as CircleEntity;
        return `<circle cx="${e.center.x}" cy="${-e.center.y}" r="${e.radius}" ${style}/>`;
      }
      case 'arc': {
        const e = entity as ArcEntity;
        const sx = e.center.x + e.radius * Math.cos(e.startAngle);
        const sy = -(e.center.y + e.radius * Math.sin(e.startAngle));
        const ex = e.center.x + e.radius * Math.cos(e.endAngle);
        const ey = -(e.center.y + e.radius * Math.sin(e.endAngle));
        let sweep = e.endAngle - e.startAngle;
        if (sweep < 0) sweep += Math.PI * 2;
        const largeArc = sweep > Math.PI ? 1 : 0;
        return `<path d="M ${sx} ${sy} A ${e.radius} ${e.radius} 0 ${largeArc} 0 ${ex} ${ey}" ${style}/>`;
      }
      case 'text': {
        const e = entity as TextEntity;
        const anchor = e.alignment === 'center' ? 'middle' : e.alignment === 'right' ? 'end' : 'start';
        return `<text x="${e.position.x}" y="${-e.position.y}" fill="${color}" font-size="${e.fontSize}" text-anchor="${anchor}" font-family="${e.fontFamily || 'sans-serif'}" font-weight="${e.fontWeight}" font-style="${e.fontStyle}">${this.escapeXml(e.content)}</text>`;
      }
      case 'dimension': {
        const e = entity as DimensionEntity;
        // Simplified dimension rendering as lines + text
        const p1 = e.defPoint1;
        const p2 = e.defPoint2;
        const dl = e.dimLinePoint;
        const text = e.textOverride || e.measurementValue.toFixed(e.decimalPrecision);
        const midX = (p1.x + p2.x) / 2;
        const midY = (p1.y + p2.y) / 2;
        return [
          `<line x1="${p1.x}" y1="${-p1.y}" x2="${dl.x}" y2="${-dl.y}" ${style}/>`,
          `<line x1="${p2.x}" y1="${-p2.y}" x2="${dl.x}" y2="${-dl.y}" ${style}/>`,
          `<text x="${midX}" y="${-midY - 3}" fill="${color}" font-size="${e.textHeight}" text-anchor="middle">${text}</text>`,
        ].join('\n');
      }
      case 'hatch': {
        const e = entity as HatchEntity;
        if (e.boundaryPoints.length < 3) return null;
        const pts = e.boundaryPoints.map((v) => `${v.x},${-v.y}`).join(' ');
        return `<polygon points="${pts}" fill="${color}" fill-opacity="0.2" ${style}/>`;
      }
      default:
        return null;
    }
  }

  private escapeXml(str: string): string {
    return str.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
  }

  private computeExtents(entities: CadEntity[]): { minX: number; minY: number; maxX: number; maxY: number } {
    let minX = Infinity, minY = Infinity, maxX = -Infinity, maxY = -Infinity;
    for (const entity of entities) {
      if (entity.type === 'line') {
        const e = entity as LineEntity;
        minX = Math.min(minX, e.start.x, e.end.x);
        minY = Math.min(minY, e.start.y, e.end.y);
        maxX = Math.max(maxX, e.start.x, e.end.x);
        maxY = Math.max(maxY, e.start.y, e.end.y);
      } else if (entity.type === 'circle') {
        const e = entity as CircleEntity;
        minX = Math.min(minX, e.center.x - e.radius);
        minY = Math.min(minY, e.center.y - e.radius);
        maxX = Math.max(maxX, e.center.x + e.radius);
        maxY = Math.max(maxY, e.center.y + e.radius);
      } else if (entity.type === 'polyline') {
        const e = entity as PolylineEntity;
        for (const v of e.vertices) {
          minX = Math.min(minX, v.x);
          minY = Math.min(minY, v.y);
          maxX = Math.max(maxX, v.x);
          maxY = Math.max(maxY, v.y);
        }
      } else if (entity.type === 'text') {
        const e = entity as TextEntity;
        minX = Math.min(minX, e.position.x);
        minY = Math.min(minY, e.position.y);
        maxX = Math.max(maxX, e.position.x + 100);
        maxY = Math.max(maxY, e.position.y + e.fontSize);
      }
    }
    if (!isFinite(minX)) { minX = 0; minY = 0; maxX = 1000; maxY = 1000; }
    return { minX, minY, maxX, maxY };
  }
}
