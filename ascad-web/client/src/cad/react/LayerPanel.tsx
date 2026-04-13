import { useState, useEffect, useCallback } from 'react';
import type { CadEngine } from '../core/CadEngine';
import type { Layer } from '../core/types';

interface LayerPanelProps {
  engine: CadEngine | null;
}

/**
 * Layer list with visibility/lock toggles, active layer selector, add/delete.
 */
export default function LayerPanel({ engine }: LayerPanelProps) {
  const [layers, setLayers] = useState<Layer[]>([]);
  const [activeLayer, setActiveLayer] = useState('0');
  const [newLayerName, setNewLayerName] = useState('');

  const refresh = useCallback(() => {
    if (!engine) return;
    setLayers(engine.entityModel.getAllLayers().map((l) => ({ ...l })));
    setActiveLayer(engine.entityModel.getActiveLayerName());
  }, [engine]);

  useEffect(() => {
    refresh();
    if (!engine) return;
    engine.on('layerChanged', refresh);
    return () => { engine.off('layerChanged', refresh); };
  }, [engine, refresh]);

  const toggleVisibility = (name: string) => {
    if (!engine) return;
    const layer = engine.entityModel.getLayer(name);
    if (layer) engine.setLayerVisibility(name, !layer.visible);
    refresh();
  };

  const toggleLock = (name: string) => {
    if (!engine) return;
    const layer = engine.entityModel.getLayer(name);
    if (layer) engine.setLayerLock(name, !layer.locked);
    refresh();
  };

  const selectActive = (name: string) => {
    if (!engine) return;
    engine.setActiveLayer(name);
    setActiveLayer(name);
  };

  const addLayer = () => {
    if (!engine || !newLayerName.trim()) return;
    engine.createLayer({
      name: newLayerName.trim(),
      visible: true,
      locked: false,
      color: '#FFFFFF',
      lineType: 'continuous',
      lineWeight: 0.25,
    });
    setNewLayerName('');
    refresh();
  };

  const deleteLayer = (name: string) => {
    if (!engine || name === '0') return;
    engine.deleteLayer(name);
    refresh();
  };

  const rowStyle = (isActive: boolean): React.CSSProperties => ({
    display: 'flex',
    alignItems: 'center',
    gap: 6,
    padding: '4px 6px',
    background: isActive ? 'rgba(37,99,235,0.15)' : 'transparent',
    borderRadius: 4,
    cursor: 'pointer',
    fontSize: 13,
  });

  const iconBtn: React.CSSProperties = {
    background: 'none', border: 'none', cursor: 'pointer', padding: 2, fontSize: 14,
  };

  return (
    <div style={{ padding: 8 }}>
      <div style={{ fontWeight: 600, fontSize: 14, marginBottom: 8 }}>Katmanlar</div>

      {/* Add layer */}
      <div style={{ display: 'flex', gap: 4, marginBottom: 8 }}>
        <input
          value={newLayerName}
          onChange={(e) => setNewLayerName(e.target.value)}
          placeholder="Yeni katman..."
          style={{ flex: 1, padding: '4px 6px', fontSize: 12 }}
          onKeyDown={(e) => e.key === 'Enter' && addLayer()}
        />
        <button onClick={addLayer} style={{ padding: '4px 8px', fontSize: 12, background: 'var(--primary)', color: 'white', borderRadius: 4, border: 'none', cursor: 'pointer' }}>+</button>
      </div>

      {/* Layer list */}
      <div style={{ maxHeight: 300, overflowY: 'auto' }}>
        {layers.map((layer) => (
          <div key={layer.name} style={rowStyle(activeLayer === layer.name)} onClick={() => selectActive(layer.name)}>
            <span style={{ width: 12, height: 12, borderRadius: 2, background: layer.color, border: '1px solid #555', flexShrink: 0 }} />
            <button style={iconBtn} onClick={(e) => { e.stopPropagation(); toggleVisibility(layer.name); }} title={layer.visible ? 'Gizle' : 'Göster'}>
              {layer.visible ? '👁' : '🚫'}
            </button>
            <button style={iconBtn} onClick={(e) => { e.stopPropagation(); toggleLock(layer.name); }} title={layer.locked ? 'Kilidi Aç' : 'Kilitle'}>
              {layer.locked ? '🔒' : '🔓'}
            </button>
            <span style={{ flex: 1, overflow: 'hidden', textOverflow: 'ellipsis', whiteSpace: 'nowrap' }}>{layer.name}</span>
            {layer.name !== '0' && (
              <button style={{ ...iconBtn, color: 'var(--danger)' }} onClick={(e) => { e.stopPropagation(); deleteLayer(layer.name); }} title="Sil">×</button>
            )}
          </div>
        ))}
      </div>
    </div>
  );
}
