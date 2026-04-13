import { useState } from 'react';
import type { CadEngine } from '../core/CadEngine';
import type { ToolName } from '../core/types';

interface CadToolbarProps {
  engine: CadEngine | null;
  onExportDxf?: () => void;
  onExportPdf?: () => void;
  onExportSvg?: () => void;
}

const drawingTools: { name: ToolName; icon: string; label: string }[] = [
  { name: 'select', icon: '⬚', label: 'Seç' },
  { name: 'line', icon: '╱', label: 'Çizgi' },
  { name: 'polyline', icon: '⏤', label: 'Polyline' },
  { name: 'rectangle', icon: '▭', label: 'Dikdörtgen' },
  { name: 'circle', icon: '○', label: 'Daire' },
  { name: 'arc', icon: '◠', label: 'Yay' },
  { name: 'dimension', icon: '↔', label: 'Ölçü' },
  { name: 'text', icon: 'A', label: 'Yazı' },
];

const manipTools: { name: ToolName; icon: string; label: string }[] = [
  { name: 'move', icon: '✥', label: 'Taşı' },
  { name: 'copy', icon: '⧉', label: 'Kopyala' },
  { name: 'rotate', icon: '↻', label: 'Döndür' },
  { name: 'scale', icon: '⤢', label: 'Ölçekle' },
  { name: 'mirror', icon: '⇿', label: 'Ayna' },
  { name: 'offset', icon: '⟺', label: 'Ofset' },
];

/**
 * Toolbar with drawing tools, manipulation tools, action buttons, and export buttons.
 */
export default function CadToolbar({ engine, onExportDxf, onExportPdf, onExportSvg }: CadToolbarProps) {
  const [activeTool, setActiveTool] = useState<ToolName>('select');
  const [gridOn, setGridOn] = useState(true);
  const [snapOn, setSnapOn] = useState(true);
  const [orthoOn, setOrthoOn] = useState(false);

  const selectTool = (name: ToolName) => {
    if (!engine) return;
    engine.activateTool(name);
    setActiveTool(name);
  };

  const btnStyle = (active: boolean): React.CSSProperties => ({
    padding: '6px 8px',
    fontSize: 13,
    fontWeight: 600,
    background: active ? 'var(--primary)' : 'var(--border)',
    color: active ? 'white' : 'var(--text)',
    borderRadius: 4,
    border: 'none',
    cursor: 'pointer',
    minWidth: 32,
  });

  const smallBtn: React.CSSProperties = {
    padding: '4px 8px', fontSize: 12, background: 'var(--border)',
    color: 'var(--text)', borderRadius: 4, border: 'none', cursor: 'pointer',
  };

  return (
    <div style={{ display: 'flex', flexWrap: 'wrap', gap: 4, padding: '6px 8px', background: '#f1f5f9', borderBottom: '1px solid var(--border)', alignItems: 'center' }}>
      {/* Drawing tools */}
      {drawingTools.map((t) => (
        <button key={t.name} style={btnStyle(activeTool === t.name)} onClick={() => selectTool(t.name)} title={t.label}>
          {t.icon}
        </button>
      ))}

      <span style={{ width: 1, height: 24, background: 'var(--border)', margin: '0 4px' }} />

      {/* Manipulation tools */}
      {manipTools.map((t) => (
        <button key={t.name} style={btnStyle(activeTool === t.name)} onClick={() => selectTool(t.name)} title={t.label}>
          {t.icon}
        </button>
      ))}

      <span style={{ width: 1, height: 24, background: 'var(--border)', margin: '0 4px' }} />

      {/* Action buttons */}
      <button style={smallBtn} onClick={() => engine?.undo()} title="Geri Al (Ctrl+Z)">↩</button>
      <button style={smallBtn} onClick={() => engine?.redo()} title="Yinele (Ctrl+Y)">↪</button>
      <button style={smallBtn} onClick={() => engine?.deleteSelected()} title="Sil (Delete)">🗑</button>
      <button style={smallBtn} onClick={() => {
        if (!engine) return;
        const bounds = engine.viewportState.getVisibleBounds();
        engine.viewportState.zoomExtents(bounds);
      }} title="Tümüne Sığdır">⊞</button>

      <span style={{ width: 1, height: 24, background: 'var(--border)', margin: '0 4px' }} />

      {/* Export buttons */}
      <button style={smallBtn} onClick={onExportDxf} title="DXF İndir">DXF</button>
      <button style={smallBtn} onClick={onExportPdf} title="PDF İndir">PDF</button>
      <button style={smallBtn} onClick={onExportSvg} title="SVG İndir">SVG</button>

      <span style={{ width: 1, height: 24, background: 'var(--border)', margin: '0 4px' }} />

      {/* Toggle buttons */}
      <button style={btnStyle(gridOn)} onClick={() => setGridOn(!gridOn)} title="Izgara (G)">Grid</button>
      <button style={btnStyle(snapOn)} onClick={() => {
        setSnapOn(!snapOn);
        // Toggle all snap modes
      }} title="Yakalama (F3)">Snap</button>
      <button style={btnStyle(orthoOn)} onClick={() => {
        const next = !orthoOn;
        setOrthoOn(next);
        engine?.snapManager.setOrthoEnabled(next);
      }} title="Ortho (F8)">Ortho</button>
    </div>
  );
}
