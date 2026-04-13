import { useState, useEffect, useCallback } from 'react';
import type { CadEngine } from '../core/CadEngine';
import type { CadEntity, LineEntity, CircleEntity, ArcEntity, PolylineEntity, TextEntity, DimensionEntity } from '../core/types';

interface PropertyPanelProps {
  engine: CadEngine | null;
}

/**
 * Displays and allows editing of selected entity properties.
 */
export default function PropertyPanel({ engine }: PropertyPanelProps) {
  const [selected, setSelected] = useState<CadEntity[]>([]);

  const refresh = useCallback(() => {
    if (!engine) return;
    setSelected(engine.selectionManager.getSelectedEntities().map((e) => ({ ...e } as CadEntity)));
  }, [engine]);

  useEffect(() => {
    refresh();
    if (!engine) return;
    engine.on('selectionChanged', refresh);
    return () => { engine.off('selectionChanged', refresh); };
  }, [engine, refresh]);

  if (selected.length === 0) {
    return (
      <div style={{ padding: 8 }}>
        <div style={{ fontWeight: 600, fontSize: 14, marginBottom: 8 }}>Özellikler</div>
        <div style={{ fontSize: 12, color: 'var(--text-light)' }}>Seçili nesne yok</div>
      </div>
    );
  }

  if (selected.length > 1) {
    return (
      <div style={{ padding: 8 }}>
        <div style={{ fontWeight: 600, fontSize: 14, marginBottom: 8 }}>Özellikler</div>
        <div style={{ fontSize: 12 }}>{selected.length} nesne seçili</div>
      </div>
    );
  }

  const entity = selected[0];

  const labelStyle: React.CSSProperties = { fontSize: 11, color: 'var(--text-light)', marginBottom: 2 };
  const valStyle: React.CSSProperties = { fontSize: 13, fontWeight: 500, marginBottom: 8 };

  return (
    <div style={{ padding: 8 }}>
      <div style={{ fontWeight: 600, fontSize: 14, marginBottom: 8 }}>Özellikler</div>

      <div style={labelStyle}>Tip</div>
      <div style={valStyle}>{entity.type}</div>

      <div style={labelStyle}>Katman</div>
      <div style={valStyle}>{entity.layerName}</div>

      <div style={labelStyle}>Renk</div>
      <div style={{ ...valStyle, display: 'flex', alignItems: 'center', gap: 6 }}>
        <span style={{ width: 14, height: 14, borderRadius: 2, background: entity.color, border: '1px solid #555' }} />
        {entity.color}
      </div>

      <div style={labelStyle}>Çizgi Tipi</div>
      <div style={valStyle}>{entity.lineType}</div>

      {/* Type-specific properties */}
      {entity.type === 'line' && <LineProps entity={entity as LineEntity} />}
      {entity.type === 'circle' && <CircleProps entity={entity as CircleEntity} />}
      {entity.type === 'arc' && <ArcProps entity={entity as ArcEntity} />}
      {entity.type === 'polyline' && <PolylineProps entity={entity as PolylineEntity} />}
      {entity.type === 'text' && <TextProps entity={entity as TextEntity} />}
      {entity.type === 'dimension' && <DimProps entity={entity as DimensionEntity} />}
    </div>
  );
}

function LineProps({ entity }: { entity: LineEntity }) {
  const dx = entity.end.x - entity.start.x;
  const dy = entity.end.y - entity.start.y;
  const len = Math.sqrt(dx * dx + dy * dy);
  return (
    <>
      <PropRow label="Başlangıç" value={`${entity.start.x.toFixed(1)}, ${entity.start.y.toFixed(1)}`} />
      <PropRow label="Bitiş" value={`${entity.end.x.toFixed(1)}, ${entity.end.y.toFixed(1)}`} />
      <PropRow label="Uzunluk" value={`${len.toFixed(1)} mm`} />
    </>
  );
}

function CircleProps({ entity }: { entity: CircleEntity }) {
  return (
    <>
      <PropRow label="Merkez" value={`${entity.center.x.toFixed(1)}, ${entity.center.y.toFixed(1)}`} />
      <PropRow label="Yarıçap" value={`${entity.radius.toFixed(1)} mm`} />
    </>
  );
}

function ArcProps({ entity }: { entity: ArcEntity }) {
  return (
    <>
      <PropRow label="Merkez" value={`${entity.center.x.toFixed(1)}, ${entity.center.y.toFixed(1)}`} />
      <PropRow label="Yarıçap" value={`${entity.radius.toFixed(1)} mm`} />
      <PropRow label="Başlangıç Açısı" value={`${((entity.startAngle * 180) / Math.PI).toFixed(1)}°`} />
      <PropRow label="Bitiş Açısı" value={`${((entity.endAngle * 180) / Math.PI).toFixed(1)}°`} />
    </>
  );
}

function PolylineProps({ entity }: { entity: PolylineEntity }) {
  return (
    <>
      <PropRow label="Köşe Sayısı" value={`${entity.vertices.length}`} />
      <PropRow label="Kapalı" value={entity.closed ? 'Evet' : 'Hayır'} />
    </>
  );
}

function TextProps({ entity }: { entity: TextEntity }) {
  return (
    <>
      <PropRow label="İçerik" value={entity.content} />
      <PropRow label="Yazı Boyutu" value={`${entity.fontSize} mm`} />
      <PropRow label="Konum" value={`${entity.position.x.toFixed(1)}, ${entity.position.y.toFixed(1)}`} />
    </>
  );
}

function DimProps({ entity }: { entity: DimensionEntity }) {
  return (
    <>
      <PropRow label="Ölçü Tipi" value={entity.dimensionType} />
      <PropRow label="Değer" value={`${entity.measurementValue.toFixed(entity.decimalPrecision)} mm`} />
    </>
  );
}

function PropRow({ label, value }: { label: string; value: string }) {
  return (
    <>
      <div style={{ fontSize: 11, color: 'var(--text-light)', marginBottom: 2 }}>{label}</div>
      <div style={{ fontSize: 13, fontWeight: 500, marginBottom: 8 }}>{value}</div>
    </>
  );
}
