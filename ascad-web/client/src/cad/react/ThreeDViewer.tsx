import { useRef, useEffect, useState } from 'react';
import { Renderer3D } from '../rendering/Renderer3D';
import type { LiftParams, ComponentCategory } from '../core/types';

interface ThreeDViewerProps {
  liftParams: LiftParams | null;
}

const components: { key: ComponentCategory; label: string }[] = [
  { key: 'shaft', label: 'Kuyu' },
  { key: 'cabin', label: 'Kabin' },
  { key: 'rails', label: 'Raylar' },
  { key: 'counterweight', label: 'Karşı Ağırlık' },
  { key: 'machine', label: 'Makine' },
  { key: 'doors', label: 'Kapılar' },
  { key: 'buffers', label: 'Tamponlar' },
];

/**
 * Three.js 3D viewer wrapper with render mode selector, component toggles, and section plane slider.
 */
export default function ThreeDViewer({ liftParams }: ThreeDViewerProps) {
  const containerRef = useRef<HTMLDivElement>(null);
  const rendererRef = useRef<Renderer3D | null>(null);
  const [renderMode, setRenderMode] = useState<'wireframe' | 'solid' | 'transparent'>('solid');
  const [visibility, setVisibility] = useState<Record<ComponentCategory, boolean>>({
    shaft: true, cabin: true, rails: true, counterweight: true, machine: true, doors: true, buffers: true,
  });
  const [sectionHeight, setSectionHeight] = useState<number | null>(null);

  useEffect(() => {
    if (!containerRef.current) return;
    const renderer = new Renderer3D(containerRef.current);
    rendererRef.current = renderer;

    renderer.initialize().then(() => {
      if (liftParams) renderer.buildFromParams(liftParams);
    });

    const resizeObserver = new ResizeObserver(() => renderer.resize());
    resizeObserver.observe(containerRef.current);

    return () => {
      resizeObserver.disconnect();
      renderer.dispose();
      rendererRef.current = null;
    };
  }, []);

  useEffect(() => {
    if (rendererRef.current && liftParams) {
      rendererRef.current.updateParams(liftParams);
    }
  }, [liftParams]);

  useEffect(() => {
    if (!rendererRef.current) return;
    rendererRef.current.setRenderMode(renderMode);
  }, [renderMode]);

  useEffect(() => {
    if (!rendererRef.current) return;
    for (const [key, visible] of Object.entries(visibility)) {
      rendererRef.current.setComponentVisible(key as ComponentCategory, visible);
    }
  }, [visibility]);

  useEffect(() => {
    if (!rendererRef.current) return;
    rendererRef.current.setSectionPlane(sectionHeight);
  }, [sectionHeight]);

  const toggleBtn = (active: boolean): React.CSSProperties => ({
    padding: '3px 8px', fontSize: 11, fontWeight: 600,
    background: active ? 'var(--primary)' : 'var(--border)',
    color: active ? 'white' : 'var(--text)',
    borderRadius: 3, border: 'none', cursor: 'pointer',
  });

  return (
    <div style={{ display: 'flex', flexDirection: 'column', height: '100%' }}>
      {/* Controls */}
      <div style={{ display: 'flex', flexWrap: 'wrap', gap: 4, padding: '6px 8px', background: '#f1f5f9', borderBottom: '1px solid var(--border)', alignItems: 'center' }}>
        {/* Render mode */}
        {(['solid', 'wireframe', 'transparent'] as const).map((m) => (
          <button key={m} style={toggleBtn(renderMode === m)} onClick={() => setRenderMode(m)}>
            {m === 'solid' ? 'Katı' : m === 'wireframe' ? 'Tel' : 'Şeffaf'}
          </button>
        ))}

        <span style={{ width: 1, height: 20, background: 'var(--border)', margin: '0 4px' }} />

        {/* Component toggles */}
        {components.map((c) => (
          <button key={c.key} style={toggleBtn(visibility[c.key])} onClick={() => setVisibility((v) => ({ ...v, [c.key]: !v[c.key] }))}>
            {c.label}
          </button>
        ))}

        <span style={{ width: 1, height: 20, background: 'var(--border)', margin: '0 4px' }} />

        {/* Section plane */}
        <span style={{ fontSize: 11, color: 'var(--text-light)' }}>Kesit:</span>
        <input
          type="range"
          min={0}
          max={20000}
          step={100}
          value={sectionHeight ?? 20000}
          onChange={(e) => {
            const v = parseInt(e.target.value);
            setSectionHeight(v >= 20000 ? null : v);
          }}
          style={{ width: 80 }}
        />

        <button style={toggleBtn(false)} onClick={() => rendererRef.current?.resetCamera()}>
          Kamera Sıfırla
        </button>
      </div>

      {/* 3D viewport */}
      <div ref={containerRef} style={{ flex: 1, minHeight: 300 }} />
    </div>
  );
}
