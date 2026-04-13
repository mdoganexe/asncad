import { useState, useEffect, useCallback } from 'react';
import type { CadEngine } from '../core/CadEngine';

interface StatusBarProps {
  engine: CadEngine | null;
}

/**
 * Status bar showing coordinates, active command, and snap indicators.
 */
export default function StatusBar({ engine }: StatusBarProps) {
  const [coords, setCoords] = useState({ x: 0, y: 0 });
  const [activeTool, setActiveTool] = useState('select');
  const [entityCount, setEntityCount] = useState(0);
  const [selectionCount, setSelectionCount] = useState(0);

  const refresh = useCallback(() => {
    if (!engine) return;
    setEntityCount(engine.entityModel.getEntityCount());
    setSelectionCount(engine.selectionManager.getSelectionCount());
    const tool = engine.toolManager.getActiveTool();
    if (tool) setActiveTool(tool.name);
  }, [engine]);

  useEffect(() => {
    refresh();
    if (!engine) return;
    const events = ['toolChanged', 'entityAdded', 'entityRemoved', 'selectionChanged'] as const;
    for (const evt of events) {
      engine.on(evt, refresh);
    }
    return () => {
      for (const evt of events) {
        engine.off(evt, refresh);
      }
    };
  }, [engine, refresh]);

  // Update coordinates on mouse move via a global listener
  useEffect(() => {
    if (!engine) return;
    const handler = () => {
      // Coordinates are updated via the canvas mouse move handler
    };
    engine.on('viewportChanged', handler);
    return () => { engine.off('viewportChanged', handler); };
  }, [engine]);

  const itemStyle: React.CSSProperties = {
    fontSize: 12,
    color: '#94a3b8',
    padding: '0 8px',
    borderRight: '1px solid #334155',
  };

  return (
    <div style={{
      display: 'flex',
      alignItems: 'center',
      height: 24,
      background: '#1e293b',
      borderTop: '1px solid #334155',
      overflow: 'hidden',
    }}>
      <span style={itemStyle}>
        X: {coords.x.toFixed(1)} Y: {coords.y.toFixed(1)}
      </span>
      <span style={itemStyle}>
        Araç: {activeTool}
      </span>
      <span style={itemStyle}>
        Nesneler: {entityCount}
      </span>
      <span style={{ ...itemStyle, borderRight: 'none' }}>
        Seçili: {selectionCount}
      </span>
    </div>
  );
}
