import React, { useRef, useEffect, useState, useCallback, useMemo } from 'react';
import Elevator3DViewer from './Elevator3DViewer';
import { generateFullReport } from './EngineeringCalcs';

// ═══════════════════════════════════════════════════════════════════════════════
// ASNCAD CAD APPLICATION — Self-contained elevator CAD drawing app
// Enhanced with ALL 12 features from original ASNCAD project
// No external ./cad/ imports. React + Canvas2D only.
// ═══════════════════════════════════════════════════════════════════════════════

// ─── Types ───────────────────────────────────────────────────────────────────
interface Point { x: number; y: number }

type EntityType = 'line' | 'rect' | 'circle' | 'arc' | 'text' | 'dimension' | 'hatch' | 'polyline';
type DrawingTab = 'kuyu-kesiti' | 'boyuna-kesit' | 'makine-dairesi' | 'kabin-plani' | 'hesap-raporu' | 'hesap-ozeti' | 'tkaa' | 'tkbb' | 'tum-proje' | 'kapi-detay' | 'aski-diyagram' | '3d-gorunum';
type ToolName = 'select' | 'line' | 'rect' | 'circle' | 'dimension' | 'text' | 'move' | 'copy' | 'rotate' | 'scale' | 'mirror' | 'pan' | 'dd';

// Feature 2: XData System
interface XData {
  blockName: string;    // e.g., "Kabin", "KabinRay", "Kapi"
  liftNumber: number;   // 1 or 2
  sectionCode: string;  // "KK", "KD", "TK-AA", "TK-BB", "MD"
  paramName?: string;   // linked parameter name for dimension editing
}

interface CadEntity {
  id: string;
  type: EntityType;
  layer: string;
  color: string;
  lineWidth: number;
  dash?: number[];
  x1?: number; y1?: number; x2?: number; y2?: number;
  x?: number; y?: number; w?: number; h?: number;
  cx?: number; cy?: number; r?: number;
  text?: string; fontSize?: number; anchor?: 'left' | 'center' | 'right';
  hatchAngle?: number; hatchSpacing?: number;
  dimText?: string; dimOffset?: number; dimDir?: 'h' | 'v';
  points?: Point[];
  fill?: string;
  rotation?: number;
  xdata?: XData;
  selected?: boolean;
  userDrawn?: boolean;
}

interface KatBilgi {
  katNo: number;
  rumuz: string;
  yukseklik: number;
  mimariKot: number;
}

interface FirmaBilgi {
  firmaAdi: string;
  adres: string;
  tel: string;
  muhendis: string;
}

interface SnapPoint { x: number; y: number; type: 'endpoint' | 'midpoint' | 'center' | 'intersection' | 'perpendicular' | 'nearest' | 'extension' | 'quadrant' }

// Feature 3: Layer Management System
interface LayerDef {
  name: string;
  color: string;
  visible: boolean;
  locked: boolean;
}

const DEFAULT_LAYERS: LayerDef[] = [
  { name: 'KUYU', color: '#94a3b8', visible: true, locked: false },
  { name: 'KABIN', color: '#60a5fa', visible: true, locked: false },
  { name: 'RAY', color: '#f59e0b', visible: true, locked: false },
  { name: 'KAPI', color: '#34d399', visible: true, locked: false },
  { name: 'AGIRLIK', color: '#f87171', visible: true, locked: false },
  { name: 'KASNAK', color: '#a78bfa', visible: true, locked: false },
  { name: 'TAMPON', color: '#fbbf24', visible: true, locked: false },
  { name: 'DIM', color: '#e2e8f0', visible: true, locked: false },
  { name: 'HATCH', color: '#475569', visible: true, locked: false },
  { name: 'LABEL', color: '#f1f5f9', visible: true, locked: false },
  { name: 'SINIR', color: '#6366f1', visible: true, locked: false },
  { name: 'HALAT', color: '#a3e635', visible: true, locked: false },
  { name: 'MAKINE', color: '#a78bfa', visible: true, locked: false },
  { name: 'REGULATOR', color: '#f472b6', visible: true, locked: false },
  { name: 'HIDROLIK', color: '#06b6d4', visible: true, locked: false },
  { name: 'SOLDUBEL', color: '#94a3b8', visible: true, locked: false },
  { name: 'SAGDUBEL', color: '#94a3b8', visible: true, locked: false },
  { name: 'USER', color: '#f1f5f9', visible: true, locked: false },
];

// Feature 9: Product Catalog — Rail Profiles
const RAIL_PROFILES: Record<string, { weight: number; ix: number; iy: number }> = {
  'T50/A': { weight: 3.7, ix: 7.1, iy: 7.1 },
  'T70/A': { weight: 5.5, ix: 22.9, iy: 7.7 },
  'T70/B': { weight: 5.5, ix: 22.9, iy: 7.7 },
  'T82/B': { weight: 9.5, ix: 52.0, iy: 11.0 },
  'T89/B': { weight: 12.3, ix: 79.7, iy: 14.5 },
  'T127/B': { weight: 22.3, ix: 280.0, iy: 30.0 },
};

// ─── Theme Constants ─────────────────────────────────────────────────────────
const THEME = {
  bg: '#1e1e2e',
  panelBg: '#252536',
  ribbonBg: '#2d2d3f',
  canvasBg: '#0d0d1a',
  statusBg: '#1a1a2e',
  border: '#3d3d5c',
  text: '#e2e8f0',
  textSecondary: '#94a3b8',
  textMuted: '#64748b',
  accent: '#00b4d8',
  accentHover: '#0ea5e9',
  toolbarHover: '#3d3d5c',
  activeTabBg: '#1e1e2e',
  buttonBg: 'transparent',
  buttonActiveBg: '#00b4d820',
  crosshair: '#ffffff33',
} as const;

// ─── Ribbon Types & Constants ────────────────────────────────────────────────
type RibbonTabId = 'cizim' | 'duzenle' | 'aciklama' | 'gorunum';

interface RibbonToolDef {
  name: string;
  icon: string;
  label: string;
  action?: () => void;
}

const RIBBON_GROUPS: Record<RibbonTabId, RibbonToolDef[]> = {
  cizim: [
    { name: 'line', icon: '╱', label: 'Çizgi' },
    { name: 'rect', icon: '▭', label: 'Dikdörtgen' },
    { name: 'circle', icon: '○', label: 'Daire' },
    { name: 'dimension', icon: '↔', label: 'Ölçü' },
    { name: 'text', icon: 'A', label: 'Metin' },
  ],
  duzenle: [
    { name: 'select', icon: '⬚', label: 'Seç' },
    { name: 'select-all', icon: '⊞', label: 'Hepsini Seç' },
    { name: 'deselect-all', icon: '⊟', label: 'Seçimi Kaldır' },
    { name: 'move', icon: '✥', label: 'Taşı' },
    { name: 'copy', icon: '⧉', label: 'Kopyala' },
    { name: 'rotate', icon: '↻', label: 'Döndür' },
    { name: 'scale', icon: '⤢', label: 'Ölçekle' },
    { name: 'mirror', icon: '⇿', label: 'Aynala' },
    { name: 'delete', icon: '🗑', label: 'Sil' },
  ],
  aciklama: [
    { name: 'dimension', icon: '↔', label: 'Ölçü' },
    { name: 'text', icon: 'A', label: 'Metin' },
    { name: 'dd', icon: 'DD', label: 'Ölçü Düzenle' },
  ],
  gorunum: [
    { name: 'zoom-extents', icon: '⊞', label: 'Tümünü Göster' },
    { name: 'grid-toggle', icon: '▦', label: 'Izgara' },
    { name: 'snap-toggle', icon: '⊕', label: 'Snap' },
    { name: 'ortho-toggle', icon: '⊥', label: 'Ortho' },
  ],
};

// ─── QuickAccessToolbar ──────────────────────────────────────────────────────
interface QuickAccessToolbarProps {
  onNew: () => void;
  onSave: () => void;
  onOpen: () => void;
  onUndo: () => void;
  onRedo: () => void;
  onExportDXF: () => void;
  onExportSVG: () => void;
  onExportJSON: () => void;
  canUndo: boolean;
  canRedo: boolean;
}

function QuickAccessToolbar({
  onNew, onSave, onOpen, onUndo, onRedo,
  onExportDXF, onExportSVG, onExportJSON,
  canUndo, canRedo,
}: QuickAccessToolbarProps) {
  const btnStyle: React.CSSProperties = {
    background: 'transparent',
    border: 'none',
    color: THEME.text,
    cursor: 'pointer',
    padding: '2px 8px',
    fontSize: 13,
    borderRadius: 3,
    lineHeight: '28px',
  };
  const hoverBg = THEME.toolbarHover;
  const disabledStyle: React.CSSProperties = { opacity: 0.3, pointerEvents: 'none' as const };

  const Btn = ({ label, onClick, disabled }: { label: string; onClick: () => void; disabled?: boolean }) => (
    <button
      style={{ ...btnStyle, ...(disabled ? disabledStyle : {}) }}
      onClick={onClick}
      onMouseEnter={e => { if (!disabled) (e.currentTarget.style.background = hoverBg); }}
      onMouseLeave={e => { e.currentTarget.style.background = 'transparent'; }}
      title={label}
    >
      {label}
    </button>
  );

  return (
    <div style={{
      display: 'flex', alignItems: 'center', height: 32,
      background: THEME.bg, borderBottom: `1px solid ${THEME.border}`,
      padding: '0 8px', gap: 2,
    }}>
      <Btn label="📄 Yeni" onClick={onNew} />
      <Btn label="💾 Kaydet" onClick={onSave} />
      <Btn label="📂 Aç" onClick={onOpen} />
      <Btn label="↩ Geri Al" onClick={onUndo} disabled={!canUndo} />
      <Btn label="↪ Yinele" onClick={onRedo} disabled={!canRedo} />
      <span style={{ width: 1, height: 18, background: THEME.border, margin: '0 6px' }} />
      <Btn label="DXF" onClick={onExportDXF} />
      <Btn label="SVG" onClick={onExportSVG} />
      <Btn label="JSON" onClick={onExportJSON} />
      <span style={{ flex: 1 }} />
      <span style={{ color: THEME.accent, fontWeight: 700, fontSize: 14, letterSpacing: 2 }}>
        ASNCAD
      </span>
    </div>
  );
}

// ─── RibbonToolbar ───────────────────────────────────────────────────────────
interface RibbonToolbarProps {
  activeRibbonTab: RibbonTabId;
  onTabChange: (tab: RibbonTabId) => void;
  activeTool: string;
  onToolSelect: (tool: string) => void;
  onPreset: (preset: string) => void;
  onOpenParams: () => void;
  showSnap: boolean;
  showGrid: boolean;
  showOrtho: boolean;
  onToggleSnap: () => void;
  onToggleGrid: () => void;
  onToggleOrtho: () => void;
  onZoomExtents: () => void;
  onDelete: () => void;
  onSelectAll: () => void;
  onDeselectAll: () => void;
}

const RIBBON_TAB_LABELS: Record<RibbonTabId, string> = {
  cizim: 'Çizim',
  duzenle: 'Düzenle',
  aciklama: 'Açıklama',
  gorunum: 'Görünüm',
};

function RibbonToolbar({
  activeRibbonTab, onTabChange, activeTool, onToolSelect,
  onPreset, onOpenParams,
  showSnap, showGrid, showOrtho,
  onToggleSnap, onToggleGrid, onToggleOrtho,
  onZoomExtents, onDelete, onSelectAll, onDeselectAll,
}: RibbonToolbarProps) {
  const tabIds: RibbonTabId[] = ['cizim', 'duzenle', 'aciklama', 'gorunum'];
  const tools = RIBBON_GROUPS[activeRibbonTab];

  const handleToolClick = (tool: RibbonToolDef) => {
    if (tool.name === 'delete') { onDelete(); return; }
    if (tool.name === 'select-all') { onSelectAll(); return; }
    if (tool.name === 'deselect-all') { onDeselectAll(); return; }
    if (tool.name === 'zoom-extents') { onZoomExtents(); return; }
    if (tool.name === 'grid-toggle') { onToggleGrid(); return; }
    if (tool.name === 'snap-toggle') { onToggleSnap(); return; }
    if (tool.name === 'ortho-toggle') { onToggleOrtho(); return; }
    onToolSelect(tool.name);
  };

  const isToolActive = (tool: RibbonToolDef): boolean => {
    if (tool.name === 'grid-toggle') return showGrid;
    if (tool.name === 'snap-toggle') return showSnap;
    if (tool.name === 'ortho-toggle') return showOrtho;
    return activeTool === tool.name;
  };

  return (
    <div style={{ background: THEME.ribbonBg, borderBottom: `1px solid ${THEME.border}` }}>
      {/* Tab row */}
      <div style={{ display: 'flex', alignItems: 'center', gap: 0, borderBottom: `1px solid ${THEME.border}`, padding: '0 8px' }}>
        {tabIds.map(id => (
          <button
            key={id}
            onClick={() => onTabChange(id)}
            style={{
              background: 'transparent',
              border: 'none',
              borderBottom: activeRibbonTab === id ? `2px solid ${THEME.accent}` : '2px solid transparent',
              color: activeRibbonTab === id ? THEME.text : THEME.textSecondary,
              cursor: 'pointer',
              padding: '6px 16px',
              fontSize: 12,
              fontWeight: activeRibbonTab === id ? 600 : 400,
            }}
          >
            {RIBBON_TAB_LABELS[id]}
          </button>
        ))}
      </div>
      {/* Tool panel row */}
      <div style={{ display: 'flex', alignItems: 'center', padding: '4px 8px', gap: 2 }}>
        {/* Tool buttons */}
        <div style={{ display: 'flex', alignItems: 'center', gap: 2, flex: 1 }}>
          {tools.map(tool => {
            const active = isToolActive(tool);
            return (
              <button
                key={tool.name}
                onClick={() => handleToolClick(tool)}
                onMouseEnter={e => { if (!active) e.currentTarget.style.background = THEME.toolbarHover; }}
                onMouseLeave={e => { if (!active) e.currentTarget.style.background = 'transparent'; }}
                style={{
                  display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center',
                  width: 48, height: 56,
                  background: active ? THEME.buttonActiveBg : 'transparent',
                  border: 'none',
                  borderRadius: 4,
                  color: active ? THEME.accent : THEME.text,
                  cursor: 'pointer',
                  padding: 0,
                }}
                title={tool.label}
              >
                <span style={{ fontSize: 20, lineHeight: 1 }}>{tool.icon}</span>
                <span style={{ fontSize: 10, marginTop: 2, whiteSpace: 'nowrap' }}>{tool.label}</span>
              </button>
            );
          })}
        </div>
        {/* Separator */}
        <span style={{ width: 1, height: 44, background: THEME.border, margin: '0 8px' }} />
        {/* Şablonlar + Parametreler */}
        <div style={{ display: 'flex', alignItems: 'center', gap: 4 }}>
          {[
            { key: 'konut', icon: '🏠', label: 'Konut' },
            { key: 'ofis', icon: '🏢', label: 'Ofis' },
            { key: 'hastane', icon: '🏥', label: 'Hastane' },
            { key: 'otel', icon: '🏨', label: 'Otel' },
          ].map(p => (
            <button
              key={p.key}
              onClick={() => onPreset(p.key)}
              onMouseEnter={e => { e.currentTarget.style.background = THEME.toolbarHover; }}
              onMouseLeave={e => { e.currentTarget.style.background = 'transparent'; }}
              style={{
                display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center',
                width: 48, height: 56,
                background: 'transparent',
                border: 'none',
                borderRadius: 4,
                color: THEME.text,
                cursor: 'pointer',
                padding: 0,
              }}
              title={p.label}
            >
              <span style={{ fontSize: 20, lineHeight: 1 }}>{p.icon}</span>
              <span style={{ fontSize: 10, marginTop: 2 }}>{p.label}</span>
            </button>
          ))}
          <button
            onClick={onOpenParams}
            onMouseEnter={e => { e.currentTarget.style.background = THEME.toolbarHover; }}
            onMouseLeave={e => { e.currentTarget.style.background = 'transparent'; }}
            style={{
              display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center',
              width: 48, height: 56,
              background: 'transparent',
              border: 'none',
              borderRadius: 4,
              color: THEME.text,
              cursor: 'pointer',
              padding: 0,
            }}
            title="Parametreler"
          >
            <span style={{ fontSize: 20, lineHeight: 1 }}>⚙</span>
            <span style={{ fontSize: 10, marginTop: 2 }}>Parametreler</span>
          </button>
        </div>
      </div>
    </div>
  );
}

function DrawingTabBar({ activeTab, onTabChange }: { activeTab: string; onTabChange: (tab: string) => void }) {
  const tabs = [
    { key: 'kk', label: 'Kuyu Kesiti' }, { key: 'bd', label: 'Boyuna Kesit' },
    { key: 'md', label: 'Makine Dairesi' }, { key: 'kabin', label: 'Kabin Planı' },
    { key: 'tk-aa', label: 'TTK-AA' }, { key: 'tk-bb', label: 'TTK-BB' },
    { key: 'kapi-detay', label: 'Kapı Detayı' }, { key: 'aski', label: 'Askı Diyagramı' },
    { key: 'tum-proje', label: 'Tüm Proje' }, { key: 'hesap-raporu', label: 'Hesap Raporu' },
    { key: 'hesap-ozeti', label: 'Hesap Özeti' }, { key: '3d-gorunum', label: '3D Görünüm' },
  ];
  return (
    <div style={{ display: 'flex', background: THEME.bg, borderBottom: `1px solid ${THEME.border}`, padding: '0 4px', overflowX: 'auto' }}>
      {tabs.map(t => (
        <button key={t.key} onClick={() => onTabChange(t.key)} style={{
          background: 'transparent', border: 'none', cursor: 'pointer', padding: '5px 12px', fontSize: 11,
          color: activeTab === t.key ? THEME.text : THEME.textMuted, fontWeight: activeTab === t.key ? 600 : 400,
          borderBottom: activeTab === t.key ? `2px solid ${THEME.accent}` : '2px solid transparent', whiteSpace: 'nowrap',
        }}>{t.label}</button>
      ))}
    </div>
  );
}

function ObjectPropertiesPanel({ entity, collapsed, onToggle }: { entity: any | null; collapsed: boolean; onToggle: () => void }) {
  return (
    <div style={{ borderBottom: `1px solid ${THEME.border}` }}>
      <div onClick={onToggle} style={{ display: 'flex', alignItems: 'center', padding: '6px 10px', cursor: 'pointer', background: THEME.ribbonBg, fontSize: 12, fontWeight: 600, color: THEME.text }}>
        <span style={{ marginRight: 6 }}>{collapsed ? '▶' : '▼'}</span>Object Properties
      </div>
      {!collapsed && (
        <div style={{ padding: '8px 10px', fontSize: 11, color: THEME.textSecondary }}>
          {entity ? (
            <div style={{ display: 'flex', flexDirection: 'column', gap: 4 }}>
              <div style={{ display: 'flex', justifyContent: 'space-between' }}><span>Tip:</span><span style={{ color: THEME.text }}>{entity.type}</span></div>
              <div style={{ display: 'flex', justifyContent: 'space-between' }}><span>Katman:</span><span style={{ color: THEME.text }}>{entity.layer}</span></div>
              <div style={{ display: 'flex', justifyContent: 'space-between' }}><span>Renk:</span><span style={{ color: entity.color || THEME.text }}>■ {entity.color}</span></div>
              {entity.x !== undefined && <div style={{ display: 'flex', justifyContent: 'space-between' }}><span>X:</span><span style={{ color: THEME.text }}>{Math.round(entity.x)}</span></div>}
              {entity.y !== undefined && <div style={{ display: 'flex', justifyContent: 'space-between' }}><span>Y:</span><span style={{ color: THEME.text }}>{Math.round(entity.y)}</span></div>}
            </div>
          ) : (
            <span style={{ color: THEME.textMuted, fontStyle: 'italic' }}>Nesne seçilmedi</span>
          )}
        </div>
      )}
    </div>
  );
}

function LeftPanel({ children, collapsed, onToggle }: { children: React.ReactNode; collapsed: boolean; onToggle: () => void }) {
  return (
    <div style={{
      width: collapsed ? 36 : 260, minWidth: collapsed ? 36 : 260,
      background: THEME.panelBg, borderRight: `1px solid ${THEME.border}`,
      transition: 'width 0.2s ease, min-width 0.2s ease', overflow: 'hidden', display: 'flex', flexDirection: 'column',
    }}>
      <div onClick={onToggle} style={{ padding: '6px 10px', cursor: 'pointer', background: THEME.ribbonBg, borderBottom: `1px solid ${THEME.border}`, fontSize: 11, color: THEME.textSecondary, textAlign: 'center' }}>
        {collapsed ? '▶' : '◀ Panel'}
      </div>
      {!collapsed && children}
    </div>
  );
}

function LayerPanelSection({ layers, onToggleVisibility, onToggleLock, collapsed, onToggle }: {
  layers: { name: string; color: string; visible: boolean; locked: boolean }[];
  onToggleVisibility: (name: string) => void;
  onToggleLock: (name: string) => void;
  collapsed: boolean;
  onToggle: () => void;
}) {
  return (
    <div>
      <div onClick={onToggle} style={{ display: 'flex', alignItems: 'center', padding: '6px 10px', cursor: 'pointer', background: THEME.ribbonBg, borderBottom: `1px solid ${THEME.border}`, fontSize: 12, fontWeight: 600, color: THEME.text }}>
        <span style={{ marginRight: 6 }}>{collapsed ? '▶' : '▼'}</span>Katmanlar
      </div>
      {!collapsed && (
        <div style={{ maxHeight: 300, overflowY: 'auto' }}>
          {layers.map(l => (
            <div key={l.name} style={{ display: 'flex', alignItems: 'center', padding: '3px 10px', fontSize: 11, gap: 6, borderBottom: `1px solid ${THEME.border}22` }}>
              <span style={{ width: 10, height: 10, borderRadius: 2, background: l.color, flexShrink: 0 }} />
              <span style={{ flex: 1, color: THEME.text, overflow: 'hidden', textOverflow: 'ellipsis', whiteSpace: 'nowrap' }}>{l.name}</span>
              <span onClick={() => onToggleVisibility(l.name)} style={{ cursor: 'pointer', fontSize: 13, opacity: l.visible ? 1 : 0.3 }}>👁</span>
              <span onClick={() => onToggleLock(l.name)} style={{ cursor: 'pointer', fontSize: 13, opacity: l.locked ? 1 : 0.3 }}>🔒</span>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

function CommandLineBar({ value, onChange, onExecute }: { value: string; onChange: (v: string) => void; onExecute: (cmd: string) => void }) {
  return (
    <div style={{ display: 'flex', alignItems: 'center', height: 28, background: THEME.statusBg, borderTop: `1px solid ${THEME.border}`, padding: '0 10px', gap: 6 }}>
      <span style={{ color: THEME.textMuted, fontSize: 11, flexShrink: 0 }}>Komut:</span>
      <input
        value={value}
        onChange={e => onChange(e.target.value)}
        onKeyDown={e => { if (e.key === 'Enter' && value.trim()) { onExecute(value.trim().toLowerCase()); onChange(''); } }}
        style={{ flex: 1, background: 'transparent', border: 'none', outline: 'none', color: THEME.accent, fontFamily: 'monospace', fontSize: 12 }}
        placeholder="param, kk, dd, save, konut, ofis, hastane, otel, ze, dall, export-json, load"
      />
    </div>
  );
}

function CadStatusBar({ mouseWorld, activeTool, entityCount, showSnap, showGrid, showOrtho,
  onToggleSnap, onToggleGrid, onToggleOrtho, modelLayoutTab, onModelLayoutChange,
  beyanYuk, kabinGen, kabinDer, kuyuGen, kuyuDer, statusInfo }: {
  mouseWorld: { x: number; y: number }; activeTool: string; entityCount: number;
  showSnap: boolean; showGrid: boolean; showOrtho: boolean;
  onToggleSnap: () => void; onToggleGrid: () => void; onToggleOrtho: () => void;
  modelLayoutTab: 'model' | 'layout1'; onModelLayoutChange: (t: 'model' | 'layout1') => void;
  beyanYuk: number; kabinGen: number; kabinDer: number; kuyuGen: number; kuyuDer: number; statusInfo: string;
}) {
  const toggleBtn = (label: string, active: boolean, onClick: () => void) => (
    <button onClick={onClick} style={{
      background: active ? THEME.buttonActiveBg : 'transparent', border: 'none', color: active ? THEME.accent : THEME.textMuted,
      cursor: 'pointer', padding: '2px 8px', fontSize: 10, fontWeight: 600, borderRadius: 3,
    }}>{label}</button>
  );
  return (
    <div style={{ display: 'flex', alignItems: 'center', height: 24, background: THEME.statusBg, borderTop: `1px solid ${THEME.border}`, padding: '0 8px', gap: 4, fontSize: 10 }}>
      {/* Model/Layout tabs */}
      <button onClick={() => onModelLayoutChange('model')} style={{ background: modelLayoutTab === 'model' ? THEME.accent : 'transparent', color: modelLayoutTab === 'model' ? '#fff' : THEME.textMuted, border: 'none', cursor: 'pointer', padding: '2px 10px', fontSize: 10, fontWeight: 600, borderRadius: 3 }}>Model</button>
      <button onClick={() => onModelLayoutChange('layout1')} style={{ background: modelLayoutTab === 'layout1' ? THEME.accent : 'transparent', color: modelLayoutTab === 'layout1' ? '#fff' : THEME.textMuted, border: 'none', cursor: 'pointer', padding: '2px 10px', fontSize: 10, fontWeight: 600, borderRadius: 3 }}>Layout1</button>
      <span style={{ width: 1, height: 14, background: THEME.border, margin: '0 4px' }} />
      {/* Coordinates */}
      <span style={{ fontFamily: 'monospace', color: THEME.text }}>X: {mouseWorld.x.toFixed(0)}</span>
      <span style={{ fontFamily: 'monospace', color: THEME.text }}>Y: {mouseWorld.y.toFixed(0)}</span>
      <span style={{ width: 1, height: 14, background: THEME.border, margin: '0 4px' }} />
      {/* Toggles */}
      {toggleBtn('SNAP', showSnap, onToggleSnap)}
      {toggleBtn('GRID', showGrid, onToggleGrid)}
      {toggleBtn('ORTHO', showOrtho, onToggleOrtho)}
      <span style={{ width: 1, height: 14, background: THEME.border, margin: '0 4px' }} />
      {/* Info */}
      <span style={{ color: THEME.textSecondary }}>{activeTool.toUpperCase()}</span>
      <span style={{ color: THEME.textMuted }}>|</span>
      <span style={{ color: THEME.textMuted }}>{entityCount} eleman</span>
      <span style={{ flex: 1 }} />
      <span style={{ color: THEME.textMuted }}>Q:{beyanYuk}kg</span>
      <span style={{ color: THEME.textMuted }}>Kabin:{kabinGen}×{kabinDer}</span>
      <span style={{ color: THEME.textMuted }}>Kuyu:{kuyuGen}×{kuyuDer}</span>
      {statusInfo && <span style={{ color: THEME.accent }}>{statusInfo}</span>}
    </div>
  );
}

interface ElevatorParams {
  asansorTipi: 'EA' | 'HA';
  tahrikKodu: 'DA' | 'MDDUZ' | 'MDCAP' | 'YA' | 'SD';
  yonKodu: 'SOL' | 'SAG' | 'ARKA';
  kuyuGen: number;
  kuyuDer: number;
  kuyuDibi: number;
  kuyuKafa: number;
  duvarKal: number;
  kapiGen: number;
  kapiH: number;
  kapiTipi: string;
  kabinYEksen: number;
  kabinRayUcu: number;
  kizakKalin: number;
  krx: number;
  agrGen: number;
  agrDuv: number;
  agrU: number;
  agrUz: number;
  tahrikKas: number;
  sapKas: number;
  katlar: KatBilgi[];
  firma: FirmaBilgi;
  kabinRayTipi: string;
  agrRayTipi: string;
  tamponTipi: string;
  regYeri: number;
  kabinP: number;
  hiz: number;
  dengeOrani: number;
  halatCapi: number;
  halatSayisi: number;
  frenTipi: string;
  motorGucu: number;
  calisYuksek: number;
  mDaireH: number;
  // Feature 1: Multi-Elevator Support
  asansorSayisi: number;
  araBolme: number;
  // Feature 4: Panoramic Elevator
  panoramik: boolean;
  // Feature 5: Scale System
  olcek: number;
  // EN81-1 Calculation Parameters
  konsolMesafe: number;    // Konsol mesafesi (mm)
  kapiAgirlik: number;     // Kapı ağırlığı (kg)
  motorVerim: number;      // Motor verimi (%)
  binaKisiSayisi: number;  // Bina kişi sayısı
  binaKullanimTipi: number; // 0=Konut, 1=Ofis, 2=Hastane, 3=Otel
  Xc: number; Yc: number; // Kabin ağırlık merkezi
  Xs: number; Ys: number; // Askı noktası
  Xp: number; Yp: number; // Paten noktası
  // Kapı detay
  esikKalin: number;       // Eşik kalınlığı (mm)
  kasaGen: number;         // Kasa genişliği (mm)
  kasaDer: number;         // Kasa derinliği (mm)
  mentese: 'SOL' | 'SAG';  // Menteşe yönü
  kapiFlip: boolean;       // Kapı ters
  // Kabin detay
  kabinDuvar: number;      // Kabin duvar kalınlığı (mm)
  kabinYanDuv: number;     // Kabin yan duvar (mm)
  aydinMesafe: number;     // Aydınlatma mesafesi (mm)
  // Ek özellikler
  iskeleVar: boolean;      // İskele var mı
  dengeZinciri: boolean;   // Denge zinciri var mı
  // Hidrolik parametreleri
  hamdGen: number;         // HA Makine Dairesi Genişliği (mm)
  hamdDer: number;         // HA Makine Dairesi Derinliği (mm)
  hidrolikGen: number;     // Hidrolik silindir genişliği (mm)
  // Ölçek parametreleri
  kkOlcek: number;         // KK ölçeği
  kdOlcek: number;         // KD ölçeği
  mdOlcek: number;         // MD ölçeği
  tkOlcek: number;         // TK ölçeği
}

// ─── Default Parameters ──────────────────────────────────────────────────────
const defaultParams = (): ElevatorParams => ({
  asansorTipi: 'EA',
  tahrikKodu: 'DA',
  yonKodu: 'SOL',
  kuyuGen: 2000,
  kuyuDer: 2500,
  kuyuDibi: 1500,
  kuyuKafa: 3600,
  duvarKal: 200,
  kapiGen: 900,
  kapiH: 2100,
  kapiTipi: 'KK-OT',
  kabinYEksen: 100,
  kabinRayUcu: 15,
  kizakKalin: 16,
  krx: 70,
  agrGen: 200,
  agrDuv: 50,
  agrU: 50,
  agrUz: 80,
  tahrikKas: 400,
  sapKas: 200,
  katlar: [
    { katNo: -1, rumuz: 'B1', yukseklik: 3000, mimariKot: -3.00 },
    { katNo: 0, rumuz: 'Z', yukseklik: 3200, mimariKot: 0.00 },
    { katNo: 1, rumuz: '1', yukseklik: 3000, mimariKot: 3.20 },
    { katNo: 2, rumuz: '2', yukseklik: 3000, mimariKot: 6.20 },
    { katNo: 3, rumuz: '3', yukseklik: 3000, mimariKot: 9.20 },
  ],
  firma: { firmaAdi: 'ASNCAD Asansör', adres: 'İstanbul, Türkiye', tel: '+90 212 000 0000', muhendis: 'Müh. Ahmet Yılmaz' },
  kabinRayTipi: 'T89/B',
  agrRayTipi: 'T50/A',
  tamponTipi: 'Yay',
  regYeri: 1,
  kabinP: 800,
  hiz: 1.0,
  dengeOrani: 0.5,
  halatCapi: 10,
  halatSayisi: 4,
  frenTipi: 'Disk',
  motorGucu: 7.5,
  calisYuksek: 2100,
  mDaireH: 3500,
  asansorSayisi: 1,
  araBolme: 100,
  panoramik: false,
  olcek: 1,
  konsolMesafe: 2500,
  kapiAgirlik: 120,
  motorVerim: 85,
  binaKisiSayisi: 100,
  binaKullanimTipi: 0,
  Xc: 0, Yc: 0,
  Xs: 0, Ys: 0,
  Xp: 0, Yp: 0,
  // Kapı detay
  esikKalin: 30,
  kasaGen: 60,
  kasaDer: 80,
  mentese: 'SOL',
  kapiFlip: false,
  // Kabin detay
  kabinDuvar: 15,
  kabinYanDuv: 15,
  aydinMesafe: 300,
  // Ek özellikler
  iskeleVar: false,
  dengeZinciri: false,
  // Hidrolik parametreleri
  hamdGen: 2000,
  hamdDer: 2000,
  hidrolikGen: 120,
  // Ölçek parametreleri
  kkOlcek: 1,
  kdOlcek: 1,
  mdOlcek: 1,
  tkOlcek: 20,
});

// ─── BeyanYük Lookup (EN81-1 Table 1.1) ─────────────────────────────────────
const BEYAN_TABLE: [number, number, number, number][] = [
  [0.49, 0.58, 180, 3], [0.60, 0.70, 225, 3], [0.79, 0.90, 300, 4],
  [0.90, 0.98, 320, 5], [0.98, 1.10, 375, 5], [1.10, 1.17, 400, 5],
  [1.17, 1.30, 450, 6], [1.31, 1.45, 525, 7], [1.45, 1.60, 600, 8],
  [1.60, 1.66, 630, 8], [1.59, 1.75, 675, 9], [1.73, 1.90, 750, 10],
  [1.90, 2.00, 800, 10], [1.87, 2.05, 825, 11], [2.01, 2.20, 900, 12],
  [2.15, 2.35, 975, 13], [2.35, 2.40, 1000, 13], [2.29, 2.50, 1050, 14],
  [2.43, 2.65, 1125, 15], [2.57, 2.80, 1200, 16], [2.80, 2.90, 1250, 16],
  [2.71, 2.95, 1275, 17], [2.85, 3.10, 1350, 18], [2.99, 3.25, 1425, 19],
  [3.13, 3.40, 1500, 20], [3.24, 3.45, 1575, 21], [3.36, 3.56, 1600, 22],
  [3.36, 3.68, 1650, 22], [3.47, 3.80, 1725, 23], [3.59, 3.92, 1800, 24],
  [3.70, 4.04, 1875, 25], [3.82, 4.16, 1950, 26], [3.87, 4.20, 2000, 26],
  [3.93, 4.32, 2025, 27],
];

const EN81_TABLE6: [number, number][] = [
  [100, 0.37], [180, 0.58], [225, 0.70], [300, 0.90], [375, 1.10],
  [400, 1.17], [450, 1.30], [525, 1.45], [600, 1.60], [630, 1.66],
  [675, 1.75], [750, 1.90], [800, 2.00], [900, 2.20], [1000, 2.40],
  [1050, 2.50], [1125, 2.65], [1200, 2.80], [1250, 2.90], [1275, 2.95],
  [1350, 3.10], [1425, 3.25], [1500, 3.40], [1600, 3.56], [1800, 3.92],
  [2000, 4.20], [2500, 5.00],
];

function beyanYukBul(kabinGenMM: number, kabinDerMM: number): { yuk: number; kisi: number } {
  const alan = (kabinGenMM * kabinDerMM) / 1_000_000;
  for (const [min, max, yuk, kisi] of BEYAN_TABLE) {
    if (alan >= min && alan <= max) return { yuk, kisi };
  }
  if (alan < 0.49) return { yuk: 100, kisi: 1 };
  return { yuk: 2500, kisi: 33 };
}

function maxKabinAlani(beyanYuk: number): number {
  for (const [yuk, alan] of EN81_TABLE6) {
    if (beyanYuk <= yuk) return alan;
  }
  return 5.0;
}

function hesaplaKabinBoyutlari(p: ElevatorParams) {
  let kabinGen: number, kabinDer: number;
  if (p.yonKodu === 'SOL' || p.yonKodu === 'SAG') {
    kabinDer = p.kuyuDer - p.kabinYEksen - 100;
    kabinGen = p.kuyuGen - (p.agrDuv + p.agrGen + p.agrU + 70 + 200) - ((p.krx + p.kabinRayUcu) * 2);
  } else {
    kabinGen = p.kuyuGen - ((p.krx + p.kabinRayUcu) * 2) - 200;
    kabinDer = p.kuyuDer - p.kabinYEksen - (p.agrDuv + p.agrGen + p.agrU + 70) - 100;
  }
  return { kabinGen: Math.max(kabinGen, 400), kabinDer: Math.max(kabinDer, 400) };
}

function hesaplaSeyirMesafesi(katlar: KatBilgi[]): number {
  if (katlar.length < 2) return 0;
  let total = 0;
  for (let i = 0; i < katlar.length - 1; i++) total += katlar[i].yukseklik;
  return total;
}

function hesaplaKuyuMesafesi(p: ElevatorParams): number {
  return p.kuyuDibi + hesaplaSeyirMesafesi(p.katlar) + p.kuyuKafa;
}

let _eid = 0;
function eid(): string { return `e${++_eid}`; }

const C = {
  wall: '#ffffff', cabin: '#00ffff', rail: '#ffff00', door: '#00ff00',
  cw: '#ff0000', cwRail: '#ff8800', sheave: '#ff00ff', buffer: '#ffff00',
  limit: '#0088ff', dim: '#00ffff', hatch: '#666666', label: '#ffffff',
  grid: '#1a1a2e', gridMajor: '#2a2a4a', crosshair: '#38bdf8', bg: '#000000',
  rope: '#00ff00', machine: '#ff00ff', governor: '#ff00ff', beam: '#888888',
  mirror: '#8888ff', handrail: '#cccccc', buttonPanel: '#ffff00',
  lightFixture: '#ffff88', sill: '#aaaaaa', uygun: '#00ff00', uygunDegil: '#ff0000',
  hydraulic: '#00ffff', piston: '#00cccc', selected: '#ff0', panoramic: '#00ffff',
};

// ═══════════════════════════════════════════════════════════════════════════════
// CROSS-SECTION GENERATOR — with Multi-Elevator, Panoramic, XData, Scale
// ═══════════════════════════════════════════════════════════════════════════════

function generateSingleCrossSection(p: ElevatorParams, offsetX: number, liftNum: number, sectionCode: string): CadEntity[] {
  const ents: CadEntity[] = [];
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const kG = p.kuyuGen, kD = p.kuyuDer, dK = p.duvarKal;
  const sc = 1 / (p.olcek > 1 ? p.olcek : 1);
  const mk = (v: number) => v * sc;

  const xd = (blockName: string, paramName?: string): XData => ({
    blockName, liftNumber: liftNum, sectionCode, paramName,
  });

  // ── 1. Kuyu Duvarları ──
  ents.push({ id: eid(), type: 'rect', layer: 'KUYU', color: C.wall, lineWidth: 3, x: mk(offsetX), y: 0, w: mk(kG), h: mk(kD), xdata: xd('Kuyu') });
  ents.push({ id: eid(), type: 'rect', layer: 'KUYU', color: C.wall, lineWidth: 1.5, x: mk(offsetX + dK), y: mk(dK), w: mk(kG - 2 * dK), h: mk(kD - 2 * dK), xdata: xd('KuyuIc') });

  // ── Hatch ──
  const hS = 60;
  ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: mk(offsetX), y: 0, w: mk(dK), h: mk(kD), hatchAngle: 45, hatchSpacing: hS, xdata: xd('KuyuHatch') });
  ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: mk(offsetX + kG - dK), y: 0, w: mk(dK), h: mk(kD), hatchAngle: 45, hatchSpacing: hS, xdata: xd('KuyuHatch') });

  // Feature 4: Panoramic — back wall
  if (p.panoramik) {
    // Dashed glass back wall, no hatch
    ents.push({ id: eid(), type: 'line', layer: 'KUYU', color: C.panoramic, lineWidth: 2, dash: [20, 10],
      x1: mk(offsetX + dK), y1: mk(kD - dK), x2: mk(offsetX + kG - dK), y2: mk(kD - dK), xdata: xd('PanCam') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.panoramic, lineWidth: 1,
      x: mk(offsetX + kG / 2), y: mk(kD - dK / 2), text: 'CAM', fontSize: 30, anchor: 'center', xdata: xd('PanLabel') });
  } else {
    ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: mk(offsetX + dK), y: mk(kD - dK), w: mk(kG - 2 * dK), h: mk(dK), hatchAngle: 45, hatchSpacing: hS, xdata: xd('KuyuHatch') });
  }

  // Front wall hatch with door opening
  const doorOpeningStart = dK + (kG - 2 * dK - p.kapiGen) / 2;
  ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: mk(offsetX + dK), y: 0, w: mk(doorOpeningStart - dK), h: mk(dK), hatchAngle: 45, hatchSpacing: hS, xdata: xd('KuyuHatch') });
  ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: mk(offsetX + doorOpeningStart + p.kapiGen), y: 0, w: mk(kG - dK - (doorOpeningStart + p.kapiGen)), h: mk(dK), hatchAngle: 45, hatchSpacing: hS, xdata: xd('KuyuHatch') });

  // ── 2. Kabin ──
  let cabinX: number, cabinY: number;
  if (p.yonKodu === 'SOL') {
    cabinX = offsetX + dK + p.krx + p.kabinRayUcu;
    cabinY = dK + p.kabinYEksen;
  } else if (p.yonKodu === 'SAG') {
    cabinX = offsetX + dK + p.agrDuv + p.agrGen + p.agrU + 70;
    cabinY = dK + p.kabinYEksen;
  } else {
    cabinX = offsetX + dK + p.krx + p.kabinRayUcu;
    cabinY = dK + p.kabinYEksen;
  }
  ents.push({ id: eid(), type: 'rect', layer: 'KABIN', color: C.cabin, lineWidth: 3, x: mk(cabinX), y: mk(cabinY), w: mk(kabinGen), h: mk(kabinDer), xdata: xd('Kabin') });

  // ── 3. Kabin Rayları ──
  const railW = 16, railH = 80, railFlangeW = 50, railFlangeH = 10;
  const lrx = cabinX - p.kabinRayUcu - railW;
  const lry = cabinY + kabinDer / 2 - railH / 2;
  ents.push({ id: eid(), type: 'rect', layer: 'RAY', color: C.rail, lineWidth: 2, x: mk(lrx), y: mk(lry), w: mk(railW), h: mk(railH), xdata: xd('KabinRay', 'kabinRayTipi') });
  ents.push({ id: eid(), type: 'rect', layer: 'RAY', color: C.rail, lineWidth: 2, x: mk(lrx - (railFlangeW - railW) / 2), y: mk(lry + railH - railFlangeH), w: mk(railFlangeW), h: mk(railFlangeH), xdata: xd('KabinRay') });
  const rrx = cabinX + kabinGen + p.kabinRayUcu;
  ents.push({ id: eid(), type: 'rect', layer: 'RAY', color: C.rail, lineWidth: 2, x: mk(rrx), y: mk(lry), w: mk(railW), h: mk(railH), xdata: xd('KabinRay', 'kabinRayTipi') });
  ents.push({ id: eid(), type: 'rect', layer: 'RAY', color: C.rail, lineWidth: 2, x: mk(rrx - (railFlangeW - railW) / 2), y: mk(lry + railH - railFlangeH), w: mk(railFlangeW), h: mk(railFlangeH), xdata: xd('KabinRay') });

  // ── 4. Kapı ──
  const doorY = cabinY - 20;
  const doorCenterX = cabinX + kabinGen / 2;
  const doorPanelW = p.kapiGen / 2;
  if (p.kapiTipi.includes('KK')) {
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 2, x: mk(doorCenterX - doorPanelW - 5), y: mk(doorY), w: mk(doorPanelW), h: mk(12), xdata: xd('Kapi', 'kapiTipi') });
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 2, x: mk(doorCenterX + 5), y: mk(doorY), w: mk(doorPanelW), h: mk(12), xdata: xd('Kapi', 'kapiTipi') });
  } else {
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 2, x: mk(doorCenterX - p.kapiGen / 2), y: mk(doorY), w: mk(p.kapiGen * 0.6), h: mk(12), xdata: xd('Kapi', 'kapiTipi') });
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 2, x: mk(doorCenterX - p.kapiGen / 2), y: mk(doorY - 14), w: mk(p.kapiGen * 0.4), h: mk(12), xdata: xd('Kapi', 'kapiTipi') });
  }
  ents.push({ id: eid(), type: 'line', layer: 'KAPI', color: C.door, lineWidth: 1, dash: [20, 10],
    x1: mk(doorCenterX - p.kapiGen / 2), y1: mk(dK), x2: mk(doorCenterX + p.kapiGen / 2), y2: mk(dK), xdata: xd('KapiEsik') });

  // ── 5. Ağırlık (EA only) ──
  let cwX = 0, cwY = 0;
  const cwW = p.agrGen, cwH = p.agrUz;
  if (p.asansorTipi === 'EA') {
    if (p.yonKodu === 'SOL') {
      cwX = offsetX + kG - dK - p.agrDuv - cwW;
      cwY = cabinY + (kabinDer - cwH) / 2;
    } else if (p.yonKodu === 'SAG') {
      cwX = offsetX + dK + p.agrDuv;
      cwY = cabinY + (kabinDer - cwH) / 2;
    } else {
      cwX = cabinX + (kabinGen - cwW) / 2;
      cwY = kD - dK - p.agrDuv - cwH;
    }
    ents.push({ id: eid(), type: 'rect', layer: 'AGIRLIK', color: C.cw, lineWidth: 2, x: mk(cwX), y: mk(cwY), w: mk(cwW), h: mk(cwH), xdata: xd('Agirlik') });
    ents.push({ id: eid(), type: 'hatch', layer: 'AGIRLIK', color: C.cw, lineWidth: 0.5, x: mk(cwX), y: mk(cwY), w: mk(cwW), h: mk(cwH), hatchAngle: -45, hatchSpacing: 30, xdata: xd('AgirlikHatch') });

    // CW Rails
    const arW = 10, arH = 50, arFW = 35, arFH = 8;
    const ar1x = cwX - 20 - arW, ar1y = cwY + cwH / 2 - arH / 2;
    ents.push({ id: eid(), type: 'rect', layer: 'RAY', color: C.cwRail, lineWidth: 1, x: mk(ar1x), y: mk(ar1y), w: mk(arW), h: mk(arH), xdata: xd('AgrRay', 'agrRayTipi') });
    ents.push({ id: eid(), type: 'rect', layer: 'RAY', color: C.cwRail, lineWidth: 1, x: mk(ar1x - (arFW - arW) / 2), y: mk(ar1y + arH - arFH), w: mk(arFW), h: mk(arFH), xdata: xd('AgrRay') });
    const ar2x = cwX + cwW + 20;
    ents.push({ id: eid(), type: 'rect', layer: 'RAY', color: C.cwRail, lineWidth: 1, x: mk(ar2x), y: mk(ar1y), w: mk(arW), h: mk(arH), xdata: xd('AgrRay', 'agrRayTipi') });
    ents.push({ id: eid(), type: 'rect', layer: 'RAY', color: C.cwRail, lineWidth: 1, x: mk(ar2x - (arFW - arW) / 2), y: mk(ar1y + arH - arFH), w: mk(arFW), h: mk(arFH), xdata: xd('AgrRay') });

    // Sheaves
    if (p.tahrikKodu === 'MDDUZ' || p.tahrikKodu === 'MDCAP') {
      const sheaveR = p.sapKas / 2;
      ents.push({ id: eid(), type: 'circle', layer: 'KASNAK', color: C.sheave, lineWidth: 1.5, cx: mk(cwX + cwW / 2), cy: mk(cwY + cwH + sheaveR + 30), r: mk(sheaveR), xdata: xd('AgrKasnak') });
    }
    if (p.tahrikKodu === 'MDDUZ') {
      const cSheaveR = p.tahrikKas / 2;
      ents.push({ id: eid(), type: 'circle', layer: 'KASNAK', color: C.sheave, lineWidth: 1.5, cx: mk(cabinX + kabinGen / 2), cy: mk(cabinY - cSheaveR - 30), r: mk(cSheaveR), xdata: xd('KabinKasnak') });
    }
    if (p.tahrikKodu === 'MDCAP') {
      const sheaveR = p.sapKas / 2;
      ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: '#e879f9', lineWidth: 1, dash: [30, 15],
        x1: mk(cabinX + kabinGen / 2), y1: mk(cabinY + kabinDer / 2), x2: mk(cwX + cwW / 2), y2: mk(cwY + cwH + sheaveR + 30), xdata: xd('Capraz') });
    }
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: mk(cwX + cwW / 2), y: mk(cwY + cwH / 2), text: 'AĞIRLIK', fontSize: 40, anchor: 'center', xdata: xd('AgirlikLabel') });
  }

  // ── 5b. Hidrolik ──
  if (p.asansorTipi === 'HA') {
    let hSemerX: number, hSemerY: number;
    const hSemerW = 120, hSemerH = 60, pistonR = 40;
    if (p.yonKodu === 'SOL') { hSemerX = cabinX - hSemerW - 30; hSemerY = cabinY + kabinDer / 2 - hSemerH / 2; }
    else if (p.yonKodu === 'SAG') { hSemerX = cabinX + kabinGen + 30; hSemerY = cabinY + kabinDer / 2 - hSemerH / 2; }
    else { hSemerX = cabinX + kabinGen / 2 - hSemerW / 2; hSemerY = kD - dK - hSemerH - 30; }
    ents.push({ id: eid(), type: 'rect', layer: 'HIDROLIK', color: C.hydraulic, lineWidth: 2, x: mk(hSemerX), y: mk(hSemerY), w: mk(hSemerW), h: mk(hSemerH), xdata: xd('HidrolikSemer') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.hydraulic, lineWidth: 1, x: mk(hSemerX + hSemerW / 2), y: mk(hSemerY + hSemerH / 2), text: 'SEMER', fontSize: 25, anchor: 'center', xdata: xd('SemerLabel') });
    ents.push({ id: eid(), type: 'line', layer: 'HIDROLIK', color: C.piston, lineWidth: 1, dash: [15, 8, 5, 8],
      x1: mk(hSemerX + hSemerW / 2), y1: 0, x2: mk(hSemerX + hSemerW / 2), y2: mk(kD), xdata: xd('HidrolikEksen') });
    ents.push({ id: eid(), type: 'circle', layer: 'HIDROLIK', color: C.piston, lineWidth: 2, cx: mk(hSemerX + hSemerW / 2), cy: mk(hSemerY + hSemerH / 2), r: mk(pistonR), xdata: xd('Piston') });
  }

  // ── 10. Tamponlar ──
  const bufferH = 60, bufferW = 30;
  const cbx = cabinX + kabinGen / 2 - bufferW / 2;
  const cby = cabinY - bufferH - 10;
  ents.push({ id: eid(), type: 'rect', layer: 'TAMPON', color: C.buffer, lineWidth: 1, x: mk(cbx), y: mk(cby), w: mk(bufferW), h: mk(bufferH), xdata: xd('KabinTampon', 'tamponTipi') });
  const springPts: Point[] = [];
  for (let i = 0; i <= 6; i++) springPts.push({ x: mk(cbx + (i % 2 === 0 ? 5 : bufferW - 5)), y: mk(cby + (i * bufferH) / 6) });
  ents.push({ id: eid(), type: 'polyline', layer: 'TAMPON', color: C.buffer, lineWidth: 1, points: springPts, xdata: xd('KabinTamponYay') });
  if (p.asansorTipi === 'EA' && p.yonKodu !== 'ARKA') {
    const cwbx = cwX + cwW / 2 - bufferW / 2;
    const cwby = cwY - bufferH - 10;
    ents.push({ id: eid(), type: 'rect', layer: 'TAMPON', color: C.buffer, lineWidth: 1, x: mk(cwbx), y: mk(cwby), w: mk(bufferW), h: mk(bufferH), xdata: xd('AgrTampon', 'tamponTipi') });
    const cwSpring: Point[] = [];
    for (let i = 0; i <= 6; i++) cwSpring.push({ x: mk(cwbx + (i % 2 === 0 ? 5 : bufferW - 5)), y: mk(cwby + (i * bufferH) / 6) });
    ents.push({ id: eid(), type: 'polyline', layer: 'TAMPON', color: C.buffer, lineWidth: 1, points: cwSpring, xdata: xd('AgrTamponYay') });
  }

  // ── 11. Sınır Çizgileri ──
  const limOff = 50;
  ents.push({ id: eid(), type: 'rect', layer: 'SINIR', color: C.limit, lineWidth: 1, dash: [15, 10, 5, 10],
    x: mk(cabinX - limOff), y: mk(cabinY - limOff), w: mk(kabinGen + 2 * limOff), h: mk(kabinDer + 2 * limOff), xdata: xd('Sinir') });

  // ── 12. Ölçülendirme ──
  const dimOff = 80;
  const dimMul = p.olcek > 1 ? p.olcek : 1;
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: mk(offsetX), y1: mk(-dimOff), x2: mk(offsetX + kG), y2: mk(-dimOff), dimText: `${kG * dimMul}`, dimDir: 'h', dimOffset: 0, xdata: xd('DimKuyuGen', 'kuyuGen') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: mk(offsetX - dimOff), y1: 0, x2: mk(offsetX - dimOff), y2: mk(kD), dimText: `${kD * dimMul}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKuyuDer', 'kuyuDer') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: mk(cabinX), y1: mk(-dimOff * 2), x2: mk(cabinX + kabinGen), y2: mk(-dimOff * 2), dimText: `${kabinGen * dimMul}`, dimDir: 'h', dimOffset: 0, xdata: xd('DimKabinGen') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: mk(offsetX - dimOff * 2), y1: mk(cabinY), x2: mk(offsetX - dimOff * 2), y2: mk(cabinY + kabinDer), dimText: `${kabinDer * dimMul}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKabinDer') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: mk(doorCenterX - p.kapiGen / 2), y1: mk(-dimOff * 3), x2: mk(doorCenterX + p.kapiGen / 2), y2: mk(-dimOff * 3), dimText: `${p.kapiGen * dimMul}`, dimDir: 'h', dimOffset: 0, xdata: xd('DimKapiGen', 'kapiGen') });

  // ── Labels ──
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: mk(cabinX + kabinGen / 2), y: mk(cabinY + kabinDer / 2), text: 'KABİN', fontSize: 60, anchor: 'center', xdata: xd('KabinLabel') });
  const alanM2 = ((kabinGen * kabinDer) / 1_000_000).toFixed(2);
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.cabin, lineWidth: 1, x: mk(cabinX + kabinGen / 2), y: mk(cabinY + kabinDer / 2 - 70), text: `${alanM2} m²`, fontSize: 45, anchor: 'center', xdata: xd('AlanLabel') });

  return ents;
}

function generateCrossSection(p: ElevatorParams): CadEntity[] {
  const ents: CadEntity[] = [];
  const sc = 1 / (p.olcek > 1 ? p.olcek : 1);
  const mk = (v: number) => v * sc;

  if (p.asansorSayisi === 2) {
    // Feature 1: Two elevators side by side
    const ents1 = generateSingleCrossSection(p, 0, 1, 'KK');
    const ents2 = generateSingleCrossSection(p, p.kuyuGen + p.araBolme, 2, 'KK');
    ents.push(...ents1, ...ents2);

    // Ara bölme wall between elevators
    const abX = p.kuyuGen;
    ents.push({ id: eid(), type: 'rect', layer: 'KUYU', color: C.wall, lineWidth: 2, x: mk(abX), y: 0, w: mk(p.araBolme), h: mk(p.kuyuDer),
      xdata: { blockName: 'AraBolme', liftNumber: 0, sectionCode: 'KK' } });
    ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: mk(abX), y: 0, w: mk(p.araBolme), h: mk(p.kuyuDer), hatchAngle: 45, hatchSpacing: 60,
      xdata: { blockName: 'AraBolmeHatch', liftNumber: 0, sectionCode: 'KK' } });

    // Title
    const totalW = p.kuyuGen * 2 + p.araBolme;
    let titleText = p.panoramik ? 'PANORAMİK KUYU KESİTİ (2 ASANSÖR)' : 'KUYU KESİTİ (2 ASANSÖR)';
    if (p.olcek > 1) titleText += ` Ö:1/${p.olcek}`;
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: mk(totalW / 2), y: mk(p.kuyuDer + 120), text: titleText, fontSize: 80, anchor: 'center' });
  } else {
    ents.push(...generateSingleCrossSection(p, 0, 1, 'KK'));
    let titleText = p.panoramik ? 'PANORAMİK KUYU KESİTİ' : 'KUYU KESİTİ';
    if (p.olcek > 1) titleText += ` Ö:1/${p.olcek}`;
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: mk(p.kuyuGen / 2), y: mk(p.kuyuDer + 120), text: titleText, fontSize: 80, anchor: 'center' });
  }

  return ents;
}


// ═══════════════════════════════════════════════════════════════════════════════
// LONGITUDINAL SECTION GENERATOR
// ═══════════════════════════════════════════════════════════════════════════════

function generateLongitudinalSection(p: ElevatorParams): CadEntity[] {
  const ents: CadEntity[] = [];
  const { kabinGen } = hesaplaKabinBoyutlari(p);
  const seyirMesafesi = hesaplaSeyirMesafesi(p.katlar);
  const kuyuMesafesi = hesaplaKuyuMesafesi(p);
  const totalH = kuyuMesafesi;
  const shaftW = p.kuyuGen;
  const kapiH = p.kapiH;
  const cabinH = 2200;

  const xd = (bn: string, pn?: string): XData => ({ blockName: bn, liftNumber: 1, sectionCode: 'BK', paramName: pn });

  ents.push({ id: eid(), type: 'rect', layer: 'KUYU', color: C.wall, lineWidth: 2, x: 0, y: 0, w: shaftW, h: totalH, xdata: xd('Kuyu') });
  ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: 0, y: 0, w: shaftW, h: 80, hatchAngle: 45, hatchSpacing: 40, xdata: xd('KuyuDibiHatch') });

  // Machine room (EA)
  const mdFloorY = totalH - p.mDaireH;
  if (p.asansorTipi === 'EA') {
    ents.push({ id: eid(), type: 'line', layer: 'KUYU', color: C.wall, lineWidth: 2, x1: 0, y1: mdFloorY, x2: shaftW, y2: mdFloorY, xdata: xd('MDFloor') });
    ents.push({ id: eid(), type: 'line', layer: 'KUYU', color: C.wall, lineWidth: 2, x1: 0, y1: totalH, x2: shaftW, y2: totalH, xdata: xd('MDCeiling') });
    ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: 0, y: mdFloorY - 80, w: shaftW, h: 80, hatchAngle: 45, hatchSpacing: 40, xdata: xd('MDFloorHatch') });
    ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: shaftW + 350, y1: mdFloorY, x2: shaftW + 350, y2: mdFloorY + p.calisYuksek, dimText: `Çalışma Yük.: ${p.calisYuksek}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimCalisYuksek', 'calisYuksek') });
    ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: shaftW + 450, y1: mdFloorY, x2: shaftW + 450, y2: totalH, dimText: `MD Yük.: ${p.mDaireH}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimMDaireH', 'mDaireH') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.machine, lineWidth: 1, x: shaftW / 2, y: mdFloorY + p.mDaireH / 2, text: 'MAKİNE DAİRESİ', fontSize: 60, anchor: 'center', xdata: xd('MDLabel') });
    const machY = mdFloorY + 200, machR = 80;
    ents.push({ id: eid(), type: 'circle', layer: 'MAKINE', color: C.machine, lineWidth: 2, cx: shaftW / 2, cy: machY + machR, r: machR, xdata: xd('Makine') });
    ents.push({ id: eid(), type: 'line', layer: 'MAKINE', color: C.machine, lineWidth: 1, x1: shaftW / 2 - machR, y1: machY + machR, x2: shaftW / 2 + machR, y2: machY + machR, xdata: xd('MakineAxis') });
  }

  // Floor lines
  let currentY = p.kuyuDibi;
  const firstStopY = currentY;
  let lastStopY = currentY;
  for (let i = 0; i < p.katlar.length; i++) {
    const kat = p.katlar[i];
    ents.push({ id: eid(), type: 'line', layer: 'KUYU', color: '#94a3b8', lineWidth: 1.5, x1: -100, y1: currentY, x2: shaftW + 100, y2: currentY, xdata: xd('KatCizgi') });
    const doorBottom = currentY;
    const doorTop = currentY + kapiH;
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 1.5, x: -40, y: doorBottom, w: 40, h: kapiH, xdata: xd('DurakKapi') });
    ents.push({ id: eid(), type: 'line', layer: 'KAPI', color: C.door, lineWidth: 0.8, dash: [10, 5], x1: -40, y1: doorTop, x2: 0, y2: doorTop, xdata: xd('KapiUst') });
    if (i === 0) {
      ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.door, lineWidth: 0.6, x1: -80, y1: doorBottom, x2: -80, y2: doorTop, dimText: `${kapiH}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKapiH', 'kapiH') });
    }
    const kotStr = kat.mimariKot >= 0 ? `+${kat.mimariKot.toFixed(2)}` : kat.mimariKot.toFixed(2);
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: shaftW + 150, y: currentY + 30, text: `${kat.rumuz} (${kotStr})`, fontSize: 45, anchor: 'left', xdata: xd('KatLabel') });
    if (i < p.katlar.length - 1) {
      const nextY = currentY + kat.yukseklik;
      ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.6, x1: -150, y1: currentY, x2: -150, y2: nextY, dimText: `${kat.yukseklik}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKatYuk') });
    }
    lastStopY = currentY;
    currentY += kat.yukseklik;
  }

  // Seyir & Kuyu mesafesi
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: '#22d3ee', lineWidth: 1, x1: -250, y1: firstStopY, x2: -250, y2: lastStopY, dimText: `Seyir: ${seyirMesafesi}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimSeyir') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: '#a78bfa', lineWidth: 1, x1: -350, y1: 0, x2: -350, y2: totalH, dimText: `Kuyu: ${kuyuMesafesi}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKuyu') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: -150, y1: 0, x2: -150, y2: p.kuyuDibi, dimText: `${p.kuyuDibi}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKuyuDibi', 'kuyuDibi') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: shaftW + 250, y1: lastStopY, x2: shaftW + 250, y2: totalH, dimText: `${p.kuyuKafa}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKuyuKafa', 'kuyuKafa') });

  // Cabin at reference floor
  const refFloorIdx = Math.max(0, p.katlar.findIndex(k => k.katNo === 0));
  let cabinBottom = p.kuyuDibi;
  for (let i = 0; i < refFloorIdx; i++) cabinBottom += p.katlar[i].yukseklik;
  const cabinLeft = (shaftW - kabinGen) / 2;
  ents.push({ id: eid(), type: 'rect', layer: 'KABIN', color: C.cabin, lineWidth: 2, x: cabinLeft, y: cabinBottom, w: kabinGen, h: cabinH, xdata: xd('Kabin') });
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: cabinLeft + kabinGen / 2, y: cabinBottom + cabinH / 2, text: 'KABİN', fontSize: 60, anchor: 'center', xdata: xd('KabinLabel') });

  // CW (EA)
  if (p.asansorTipi === 'EA') {
    const cwH2 = 1200, cwBottom = totalH - p.kuyuKafa - cwH2 - 200;
    ents.push({ id: eid(), type: 'rect', layer: 'AGIRLIK', color: C.cw, lineWidth: 2, x: shaftW - 300, y: cwBottom, w: 200, h: cwH2, xdata: xd('Agirlik') });
    ents.push({ id: eid(), type: 'hatch', layer: 'AGIRLIK', color: C.cw, lineWidth: 0.3, x: shaftW - 300, y: cwBottom, w: 200, h: cwH2, hatchAngle: -45, hatchSpacing: 40, xdata: xd('AgirlikHatch') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.cw, lineWidth: 1, x: shaftW - 200, y: cwBottom + cwH2 / 2, text: 'AĞR.', fontSize: 40, anchor: 'center', xdata: xd('AgrLabel') });
    // Ropes
    if (p.asansorTipi === 'EA') {
      const machCX = shaftW / 2, machCY = mdFloorY + 200 + 80;
      ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: C.rope, lineWidth: 0.8, dash: [8, 4], x1: machCX - 20, y1: machCY, x2: cabinLeft + kabinGen / 2 - 20, y2: cabinBottom + cabinH, xdata: xd('Halat') });
      ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: C.rope, lineWidth: 0.8, dash: [8, 4], x1: machCX + 20, y1: machCY, x2: shaftW - 200, y2: cwBottom + cwH2, xdata: xd('Halat') });
    }
  }

  // Rails
  ents.push({ id: eid(), type: 'line', layer: 'RAY', color: C.rail, lineWidth: 1.5, x1: cabinLeft - 30, y1: 0, x2: cabinLeft - 30, y2: totalH, xdata: xd('KabinRay') });
  ents.push({ id: eid(), type: 'line', layer: 'RAY', color: C.rail, lineWidth: 1.5, x1: cabinLeft + kabinGen + 30, y1: 0, x2: cabinLeft + kabinGen + 30, y2: totalH, xdata: xd('KabinRay') });

  // Buffer
  const bufW = 40, bufH2 = 100, bufX = cabinLeft + kabinGen / 2 - bufW / 2;
  ents.push({ id: eid(), type: 'rect', layer: 'TAMPON', color: C.buffer, lineWidth: 1, x: bufX, y: 80, w: bufW, h: bufH2, xdata: xd('KabinTampon') });
  const bSpring: Point[] = [];
  for (let i = 0; i <= 8; i++) bSpring.push({ x: bufX + (i % 2 === 0 ? 5 : bufW - 5), y: 80 + (i * bufH2) / 8 });
  ents.push({ id: eid(), type: 'polyline', layer: 'TAMPON', color: C.buffer, lineWidth: 1, points: bSpring, xdata: xd('TamponYay') });

  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: shaftW / 2, y: totalH + 200, text: 'TÜM KUYU BOYUNA KESİT', fontSize: 80, anchor: 'center', xdata: xd('Title') });

  return ents;
}


// ═══════════════════════════════════════════════════════════════════════════════
// MACHINE ROOM GENERATOR
// ═══════════════════════════════════════════════════════════════════════════════

function generateMachineRoom(p: ElevatorParams): CadEntity[] {
  const ents: CadEntity[] = [];
  const kG = p.kuyuGen, kD = p.kuyuDer, dK = p.duvarKal;
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const beyan = beyanYukBul(kabinGen, kabinDer);
  const xd = (bn: string, pn?: string): XData => ({ blockName: bn, liftNumber: 1, sectionCode: 'MD', paramName: pn });

  ents.push({ id: eid(), type: 'rect', layer: 'KUYU', color: C.wall, lineWidth: 2, x: 0, y: 0, w: kG, h: kD, xdata: xd('Kuyu') });
  ents.push({ id: eid(), type: 'rect', layer: 'KUYU', color: C.wall, lineWidth: 1, x: dK, y: dK, w: kG - 2 * dK, h: kD - 2 * dK, xdata: xd('KuyuIc') });
  ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: 0, y: 0, w: dK, h: kD, hatchAngle: 45, hatchSpacing: 50, xdata: xd('WallHatch') });
  ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: kG - dK, y: 0, w: dK, h: kD, hatchAngle: 45, hatchSpacing: 50, xdata: xd('WallHatch') });
  ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: dK, y: 0, w: kG - 2 * dK, h: dK, hatchAngle: 45, hatchSpacing: 50, xdata: xd('WallHatch') });
  ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: dK, y: kD - dK, w: kG - 2 * dK, h: dK, hatchAngle: 45, hatchSpacing: 50, xdata: xd('WallHatch') });

  const openW = kG - 2 * dK - 200, openH = kD - 2 * dK - 200, openX = dK + 100, openY = dK + 100;
  ents.push({ id: eid(), type: 'rect', layer: 'KUYU', color: '#64748b', lineWidth: 1.5, dash: [15, 8], x: openX, y: openY, w: openW, h: openH, xdata: xd('KuyuAcikligi') });
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#64748b', lineWidth: 1, x: openX + openW / 2, y: openY + openH / 2 + 60, text: 'KUYU AÇIKLIĞI', fontSize: 35, anchor: 'center', xdata: xd('KuyuAcikligiLabel') });

  const machW = 500, machH = 400;
  let machX: number, machY: number;
  if (p.yonKodu === 'SOL') { machX = dK + 100; machY = kD / 2 - machH / 2; }
  else if (p.yonKodu === 'SAG') { machX = kG - dK - machW - 100; machY = kD / 2 - machH / 2; }
  else { machX = kG / 2 - machW / 2; machY = kD - dK - machH - 100; }
  ents.push({ id: eid(), type: 'rect', layer: 'MAKINE', color: C.machine, lineWidth: 2, x: machX, y: machY, w: machW, h: machH, xdata: xd('Makine') });
  ents.push({ id: eid(), type: 'circle', layer: 'MAKINE', color: C.machine, lineWidth: 1.5, cx: machX + machW / 2, cy: machY + machH / 2, r: p.tahrikKas / 2, xdata: xd('TahrikKasnak') });
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: machX + machW / 2, y: machY + machH / 2, text: 'TAHRİK', fontSize: 50, anchor: 'center', xdata: xd('TahrikLabel') });

  const beamH = 30;
  ents.push({ id: eid(), type: 'rect', layer: 'KUYU', color: C.beam, lineWidth: 1.5, x: machX - 50, y: machY - beamH - 10, w: machW + 100, h: beamH, xdata: xd('Kiris') });
  ents.push({ id: eid(), type: 'hatch', layer: 'KUYU', color: C.beam, lineWidth: 0.3, x: machX - 50, y: machY - beamH - 10, w: machW + 100, h: beamH, hatchAngle: 45, hatchSpacing: 20, xdata: xd('KirisHatch') });

  let sheaveX: number, sheaveY: number;
  if (p.yonKodu === 'SOL') { sheaveX = kG - dK - 200; sheaveY = kD / 2; }
  else if (p.yonKodu === 'SAG') { sheaveX = dK + 200; sheaveY = kD / 2; }
  else { sheaveX = kG / 2; sheaveY = dK + 200; }
  ents.push({ id: eid(), type: 'circle', layer: 'KASNAK', color: C.sheave, lineWidth: 1.5, cx: sheaveX, cy: sheaveY, r: p.sapKas / 2, xdata: xd('SapKasnak') });
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: sheaveX, y: sheaveY - p.sapKas / 2 - 30, text: 'SAP. KAS.', fontSize: 35, anchor: 'center', xdata: xd('SapKasnakLabel') });

  ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: C.rope, lineWidth: 1, dash: [10, 5], x1: machX + machW / 2, y1: machY + machH / 2, x2: sheaveX, y2: sheaveY, xdata: xd('Halat') });
  ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: C.rope, lineWidth: 1, dash: [10, 5], x1: sheaveX, y1: sheaveY, x2: openX + openW / 2, y2: openY + openH / 2, xdata: xd('Halat') });

  let regX: number, regY: number;
  const regR = 60;
  switch (p.regYeri) {
    case 1: regX = dK + 80 + regR; regY = kD - dK - 80 - regR; break;
    case 2: regX = kG - dK - 80 - regR; regY = kD - dK - 80 - regR; break;
    case 3: regX = kG - dK - 80 - regR; regY = dK + 80 + regR; break;
    case 4: default: regX = dK + 80 + regR; regY = dK + 80 + regR; break;
  }
  ents.push({ id: eid(), type: 'circle', layer: 'REGULATOR', color: C.governor, lineWidth: 2, cx: regX, cy: regY, r: regR, xdata: xd('Regulator') });
  ents.push({ id: eid(), type: 'line', layer: 'REGULATOR', color: C.governor, lineWidth: 1, x1: regX - regR, y1: regY, x2: regX + regR, y2: regY, xdata: xd('RegAxis') });
  ents.push({ id: eid(), type: 'line', layer: 'REGULATOR', color: C.governor, lineWidth: 1, x1: regX, y1: regY - regR, x2: regX, y2: regY + regR, xdata: xd('RegAxis') });
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.governor, lineWidth: 1, x: regX, y: regY - regR - 25, text: 'REG.', fontSize: 30, anchor: 'center', xdata: xd('RegLabel') });

  const psForce = ((2 * beyan.yuk + 1.5 * p.kabinP) * 9.81 + 400 * 9.81);
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#fbbf24', lineWidth: 1, x: machX + machW / 2, y: machY + machH + 40, text: `PS = ${Math.round(psForce)} N`, fontSize: 40, anchor: 'center', xdata: xd('PSLabel') });

  ents.push({ id: eid(), type: 'rect', layer: 'KUYU', color: '#22d3ee', lineWidth: 1.5, x: dK + 50, y: dK + 50, w: 300, h: 150, xdata: xd('Pano') });
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: dK + 200, y: dK + 125, text: 'PANO', fontSize: 40, anchor: 'center', xdata: xd('PanoLabel') });
  ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 2, x: kG / 2 - 400, y: -10, w: 800, h: 20, xdata: xd('MDKapi') });
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: kG / 2, y: -50, text: 'GİRİŞ', fontSize: 40, anchor: 'center', xdata: xd('GirisLabel') });

  let titleText = 'MAKİNE DAİRESİ ÜST GÖRÜNÜŞ';
  if (p.olcek > 1) titleText += ` Ö:1/${p.olcek}`;
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: kG / 2, y: kD + 120, text: titleText, fontSize: 70, anchor: 'center', xdata: xd('Title') });

  return ents;
}


// ═══════════════════════════════════════════════════════════════════════════════
// CABIN PLAN GENERATOR
// ═══════════════════════════════════════════════════════════════════════════════

function generateCabinPlan(p: ElevatorParams): CadEntity[] {
  const ents: CadEntity[] = [];
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const wallThick = 15;
  const xd = (bn: string, pn?: string): XData => ({ blockName: bn, liftNumber: 1, sectionCode: 'KP', paramName: pn });

  ents.push({ id: eid(), type: 'rect', layer: 'KABIN', color: C.cabin, lineWidth: 2, x: 0, y: 0, w: kabinGen, h: kabinDer, xdata: xd('Kabin') });
  ents.push({ id: eid(), type: 'rect', layer: 'KABIN', color: '#475569', lineWidth: 1, x: wallThick, y: wallThick, w: kabinGen - 2 * wallThick, h: kabinDer - 2 * wallThick, xdata: xd('KabinIc') });

  // Panoramic back wall
  if (p.panoramik) {
    ents.push({ id: eid(), type: 'line', layer: 'KABIN', color: C.panoramic, lineWidth: 2, dash: [15, 8],
      x1: wallThick, y1: kabinDer - wallThick, x2: kabinGen - wallThick, y2: kabinDer - wallThick, xdata: xd('PanCam') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.panoramic, lineWidth: 1, x: kabinGen / 2, y: kabinDer - wallThick - 20, text: 'CAM PANEL', fontSize: 25, anchor: 'center', xdata: xd('PanLabel') });
  }

  const doorW = p.kapiGen, doorStartX = (kabinGen - doorW) / 2;
  ents.push({ id: eid(), type: 'line', layer: 'KAPI', color: C.door, lineWidth: 2, x1: doorStartX, y1: 0, x2: doorStartX + doorW, y2: 0, xdata: xd('Kapi', 'kapiTipi') });
  const sillH = 20;
  ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.sill, lineWidth: 1.5, x: doorStartX - 20, y: -sillH, w: doorW + 40, h: sillH, xdata: xd('Esik') });

  // Handrail
  const hrOff = 60;
  ents.push({ id: eid(), type: 'line', layer: 'KABIN', color: C.handrail, lineWidth: 2, x1: hrOff, y1: kabinDer - hrOff, x2: kabinGen - hrOff, y2: kabinDer - hrOff, xdata: xd('Korkuluk') });
  ents.push({ id: eid(), type: 'line', layer: 'KABIN', color: C.handrail, lineWidth: 2, x1: hrOff, y1: hrOff, x2: hrOff, y2: kabinDer - hrOff, xdata: xd('Korkuluk') });
  ents.push({ id: eid(), type: 'line', layer: 'KABIN', color: C.handrail, lineWidth: 2, x1: kabinGen - hrOff, y1: hrOff, x2: kabinGen - hrOff, y2: kabinDer - hrOff, xdata: xd('Korkuluk') });

  // Mirror
  const mirrorW = kabinGen * 0.6, mirrorX = (kabinGen - mirrorW) / 2;
  ents.push({ id: eid(), type: 'rect', layer: 'KABIN', color: C.mirror, lineWidth: 1.5, x: mirrorX, y: kabinDer - wallThick - 15, w: mirrorW, h: 15, xdata: xd('Ayna') });

  // Button panel
  const bpW = 35, bpH = 250, bpX = kabinGen - wallThick - bpW - 10, bpY = kabinDer / 2 - bpH / 2;
  ents.push({ id: eid(), type: 'rect', layer: 'KABIN', color: C.buttonPanel, lineWidth: 1.5, x: bpX, y: bpY, w: bpW, h: bpH, xdata: xd('ButonPanel') });
  const btnCount = Math.min(p.katlar.length, 8);
  for (let i = 0; i < btnCount; i++) {
    const btnY = bpY + 20 + i * ((bpH - 40) / (btnCount - 1 || 1));
    ents.push({ id: eid(), type: 'circle', layer: 'KABIN', color: C.buttonPanel, lineWidth: 0.8, cx: bpX + bpW / 2, cy: btnY, r: 6, xdata: xd('Buton') });
  }

  // Lighting
  const lightCount = kabinGen > 1200 ? 3 : 2;
  for (let i = 0; i < lightCount; i++) {
    const lx = kabinGen / (lightCount + 1) * (i + 1), ly = kabinDer / 2, ls = 25;
    ents.push({ id: eid(), type: 'line', layer: 'KABIN', color: C.lightFixture, lineWidth: 1, x1: lx - ls, y1: ly - ls, x2: lx + ls, y2: ly + ls, xdata: xd('Aydinlatma') });
    ents.push({ id: eid(), type: 'line', layer: 'KABIN', color: C.lightFixture, lineWidth: 1, x1: lx + ls, y1: ly - ls, x2: lx - ls, y2: ly + ls, xdata: xd('Aydinlatma') });
    ents.push({ id: eid(), type: 'circle', layer: 'KABIN', color: C.lightFixture, lineWidth: 0.8, cx: lx, cy: ly, r: ls * 1.2, xdata: xd('Aydinlatma') });
  }

  // Dimensions
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: 0, y1: -80, x2: kabinGen, y2: -80, dimText: `${kabinGen}`, dimDir: 'h', dimOffset: 0, xdata: xd('DimKabinGen') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: -80, y1: 0, x2: -80, y2: kabinDer, dimText: `${kabinDer}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKabinDer') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.6, x1: doorStartX, y1: -40, x2: doorStartX + doorW, y2: -40, dimText: `${doorW}`, dimDir: 'h', dimOffset: 0, xdata: xd('DimKapiGen', 'kapiGen') });

  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: kabinGen / 2, y: kabinDer + 120, text: 'KABİN PLANI', fontSize: 70, anchor: 'center', xdata: xd('Title') });

  return ents;
}


// ═══════════════════════════════════════════════════════════════════════════════
// Feature 8: TTK-AA — Full Shaft Longitudinal Section A-A (Front View)
// ═══════════════════════════════════════════════════════════════════════════════

function generateTKAA(p: ElevatorParams): CadEntity[] {
  const ents: CadEntity[] = [];
  const { kabinGen } = hesaplaKabinBoyutlari(p);
  const seyirMesafesi = hesaplaSeyirMesafesi(p.katlar);
  const kuyuMesafesi = hesaplaKuyuMesafesi(p);
  const totalH = kuyuMesafesi;
  const totalW = p.asansorSayisi === 2 ? p.kuyuGen * 2 + p.araBolme : p.kuyuGen;
  const kapiH = p.kapiH;
  const cabinH = 2200;
  const sc = 1 / (p.olcek > 1 ? p.olcek : 1);
  const mk = (v: number) => v * sc;
  const xd = (bn: string, pn?: string): XData => ({ blockName: bn, liftNumber: 1, sectionCode: 'TK-AA', paramName: pn });

  // Shaft outline
  ents.push({ id: eid(), type: 'rect', layer: 'KUYU', color: C.wall, lineWidth: 2, x: 0, y: 0, w: mk(totalW), h: mk(totalH), xdata: xd('Kuyu') });

  // Pit hatch
  ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: 0, y: 0, w: mk(totalW), h: mk(80), hatchAngle: 45, hatchSpacing: 40, xdata: xd('PitHatch') });

  // Floor lines with door openings
  let currentY = p.kuyuDibi;
  for (let i = 0; i < p.katlar.length; i++) {
    const kat = p.katlar[i];
    ents.push({ id: eid(), type: 'line', layer: 'KUYU', color: '#94a3b8', lineWidth: 1.5, x1: mk(-100), y1: mk(currentY), x2: mk(totalW + 100), y2: mk(currentY), xdata: xd('KatCizgi') });
    // Door opening
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 1, x: mk(-40), y: mk(currentY), w: mk(40), h: mk(kapiH), xdata: xd('DurakKapi') });
    // Floor label
    const kotStr = kat.mimariKot >= 0 ? `+${kat.mimariKot.toFixed(2)}` : kat.mimariKot.toFixed(2);
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: mk(totalW + 150), y: mk(currentY + 30), text: `${kat.rumuz} (${kotStr})`, fontSize: 40, anchor: 'left', xdata: xd('KatLabel') });
    // Kat yüksekliği
    if (i < p.katlar.length - 1) {
      ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.6, x1: mk(-150), y1: mk(currentY), x2: mk(-150), y2: mk(currentY + kat.yukseklik), dimText: `${kat.yukseklik}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKatYuk') });
    }
    currentY += kat.yukseklik;
  }

  // Cabin at reference floor
  const refIdx = Math.max(0, p.katlar.findIndex(k => k.katNo === 0));
  let cabinBottom = p.kuyuDibi;
  for (let i = 0; i < refIdx; i++) cabinBottom += p.katlar[i].yukseklik;
  const cabinLeft = mk((totalW - kabinGen) / 2);
  ents.push({ id: eid(), type: 'rect', layer: 'KABIN', color: C.cabin, lineWidth: 2, x: cabinLeft, y: mk(cabinBottom), w: mk(kabinGen), h: mk(cabinH), xdata: xd('Kabin') });
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: cabinLeft + mk(kabinGen / 2), y: mk(cabinBottom + cabinH / 2), text: 'KABİN', fontSize: 50, anchor: 'center', xdata: xd('KabinLabel') });

  // CW
  if (p.asansorTipi === 'EA') {
    const cwH2 = 1200, cwBottom = totalH - p.kuyuKafa - cwH2 - 200;
    ents.push({ id: eid(), type: 'rect', layer: 'AGIRLIK', color: C.cw, lineWidth: 2, x: mk(totalW - 300), y: mk(cwBottom), w: mk(200), h: mk(cwH2), xdata: xd('Agirlik') });
    ents.push({ id: eid(), type: 'hatch', layer: 'AGIRLIK', color: C.cw, lineWidth: 0.3, x: mk(totalW - 300), y: mk(cwBottom), w: mk(200), h: mk(cwH2), hatchAngle: -45, hatchSpacing: 40, xdata: xd('AgirlikHatch') });
  }

  // Machine room at top (EA)
  if (p.asansorTipi === 'EA') {
    const mdFloorY = totalH - p.mDaireH;
    ents.push({ id: eid(), type: 'line', layer: 'KUYU', color: C.wall, lineWidth: 2, x1: 0, y1: mk(mdFloorY), x2: mk(totalW), y2: mk(mdFloorY), xdata: xd('MDFloor') });
    ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: 0, y: mk(mdFloorY - 80), w: mk(totalW), h: mk(80), hatchAngle: 45, hatchSpacing: 40, xdata: xd('MDFloorHatch') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.machine, lineWidth: 1, x: mk(totalW / 2), y: mk(mdFloorY + p.mDaireH / 2), text: 'MAKİNE DAİRESİ', fontSize: 50, anchor: 'center', xdata: xd('MDLabel') });
    // Machine
    const machR = 80;
    ents.push({ id: eid(), type: 'circle', layer: 'MAKINE', color: C.machine, lineWidth: 2, cx: mk(totalW / 2), cy: mk(mdFloorY + 200 + machR), r: mk(machR), xdata: xd('Makine') });
  }

  // Rails full height
  ents.push({ id: eid(), type: 'line', layer: 'RAY', color: C.rail, lineWidth: 1.5, x1: cabinLeft - mk(30), y1: 0, x2: cabinLeft - mk(30), y2: mk(totalH), xdata: xd('KabinRay') });
  ents.push({ id: eid(), type: 'line', layer: 'RAY', color: C.rail, lineWidth: 1.5, x1: cabinLeft + mk(kabinGen + 30), y1: 0, x2: cabinLeft + mk(kabinGen + 30), y2: mk(totalH), xdata: xd('KabinRay') });

  // Seyir & Kuyu dims
  const firstStopY = p.kuyuDibi;
  let lastStopY = p.kuyuDibi;
  for (let i = 0; i < p.katlar.length - 1; i++) lastStopY += p.katlar[i].yukseklik;
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: '#22d3ee', lineWidth: 1, x1: mk(-250), y1: mk(firstStopY), x2: mk(-250), y2: mk(lastStopY), dimText: `SEYİR MESAFESİ = ${seyirMesafesi} mm`, dimDir: 'v', dimOffset: 0, xdata: xd('DimSeyir') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: '#a78bfa', lineWidth: 1, x1: mk(-350), y1: 0, x2: mk(-350), y2: mk(totalH), dimText: `KUYU MESAFESİ = ${kuyuMesafesi} mm`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKuyu') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: mk(-150), y1: 0, x2: mk(-150), y2: mk(p.kuyuDibi), dimText: `${p.kuyuDibi}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKuyuDibi', 'kuyuDibi') });

  // Title
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: mk(totalW / 2), y: mk(totalH + 200), text: `TÜM KUYU AA KESİTİ Ö:1/${p.olcek > 1 ? p.olcek : 20}`, fontSize: 80, anchor: 'center', xdata: xd('Title') });

  return ents;
}


// ═══════════════════════════════════════════════════════════════════════════════
// Feature 8: TTK-BB — Full Shaft Longitudinal Section B-B (Side View)
// ═══════════════════════════════════════════════════════════════════════════════

function generateTKBB(p: ElevatorParams): CadEntity[] {
  const ents: CadEntity[] = [];
  const { kabinDer } = hesaplaKabinBoyutlari(p);
  const seyirMesafesi = hesaplaSeyirMesafesi(p.katlar);
  const kuyuMesafesi = hesaplaKuyuMesafesi(p);
  const totalH = kuyuMesafesi;
  const shaftW = p.kuyuDer; // Side view uses depth as width
  const kapiH = p.kapiH;
  const cabinH = 2200;
  const sc = 1 / (p.olcek > 1 ? p.olcek : 1);
  const mk = (v: number) => v * sc;
  const xd = (bn: string, pn?: string): XData => ({ blockName: bn, liftNumber: 1, sectionCode: 'TK-BB', paramName: pn });

  ents.push({ id: eid(), type: 'rect', layer: 'KUYU', color: C.wall, lineWidth: 2, x: 0, y: 0, w: mk(shaftW), h: mk(totalH), xdata: xd('Kuyu') });
  ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: 0, y: 0, w: mk(shaftW), h: mk(80), hatchAngle: 45, hatchSpacing: 40, xdata: xd('PitHatch') });

  // Floor lines
  let currentY = p.kuyuDibi;
  for (let i = 0; i < p.katlar.length; i++) {
    const kat = p.katlar[i];
    ents.push({ id: eid(), type: 'line', layer: 'KUYU', color: '#94a3b8', lineWidth: 1.5, x1: mk(-100), y1: mk(currentY), x2: mk(shaftW + 100), y2: mk(currentY), xdata: xd('KatCizgi') });
    // Door opening on side
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 1, x: mk(-40), y: mk(currentY), w: mk(40), h: mk(kapiH), xdata: xd('DurakKapi') });
    const kotStr = kat.mimariKot >= 0 ? `+${kat.mimariKot.toFixed(2)}` : kat.mimariKot.toFixed(2);
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: mk(shaftW + 150), y: mk(currentY + 30), text: `${kat.rumuz} (${kotStr})`, fontSize: 40, anchor: 'left', xdata: xd('KatLabel') });
    if (i === 0) {
      const ilkKotStr = kat.mimariKot >= 0 ? `+${kat.mimariKot.toFixed(2)}` : kat.mimariKot.toFixed(2);
      ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#f472b6', lineWidth: 1, x: mk(shaftW + 400), y: mk(currentY), text: `İlk Durak Kot: ${ilkKotStr}`, fontSize: 35, anchor: 'left', xdata: xd('IlkDurakKot') });
    }
    if (i === p.katlar.length - 1) {
      const sonKotStr = kat.mimariKot >= 0 ? `+${kat.mimariKot.toFixed(2)}` : kat.mimariKot.toFixed(2);
      ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#f472b6', lineWidth: 1, x: mk(shaftW + 400), y: mk(currentY), text: `Son Durak Kot: ${sonKotStr}`, fontSize: 35, anchor: 'left', xdata: xd('SonDurakKot') });
    }
    if (i < p.katlar.length - 1) {
      ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.6, x1: mk(-150), y1: mk(currentY), x2: mk(-150), y2: mk(currentY + kat.yukseklik), dimText: `${kat.yukseklik}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKatYuk') });
    }
    currentY += kat.yukseklik;
  }

  // Cabin
  const refIdx = Math.max(0, p.katlar.findIndex(k => k.katNo === 0));
  let cabinBottom = p.kuyuDibi;
  for (let i = 0; i < refIdx; i++) cabinBottom += p.katlar[i].yukseklik;
  const cabinLeft = mk((shaftW - kabinDer) / 2);
  ents.push({ id: eid(), type: 'rect', layer: 'KABIN', color: C.cabin, lineWidth: 2, x: cabinLeft, y: mk(cabinBottom), w: mk(kabinDer), h: mk(cabinH), xdata: xd('Kabin') });
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: cabinLeft + mk(kabinDer / 2), y: mk(cabinBottom + cabinH / 2), text: 'KABİN', fontSize: 50, anchor: 'center', xdata: xd('KabinLabel') });

  // Machine room (EA)
  if (p.asansorTipi === 'EA') {
    const mdFloorY = totalH - p.mDaireH;
    ents.push({ id: eid(), type: 'line', layer: 'KUYU', color: C.wall, lineWidth: 2, x1: 0, y1: mk(mdFloorY), x2: mk(shaftW), y2: mk(mdFloorY), xdata: xd('MDFloor') });
    ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: 0, y: mk(mdFloorY - 80), w: mk(shaftW), h: mk(80), hatchAngle: 45, hatchSpacing: 40, xdata: xd('MDFloorHatch') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.machine, lineWidth: 1, x: mk(shaftW / 2), y: mk(mdFloorY + p.mDaireH / 2), text: 'MAKİNE DAİRESİ', fontSize: 50, anchor: 'center', xdata: xd('MDLabel') });
    // MD Kot
    const mdKot = p.katlar[p.katlar.length - 1].mimariKot + p.katlar[p.katlar.length - 1].yukseklik / 1000 + p.kuyuKafa / 1000 - p.mDaireH / 1000;
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#f472b6', lineWidth: 1, x: mk(shaftW + 400), y: mk(mdFloorY), text: `MD Kot: +${mdKot.toFixed(2)}`, fontSize: 35, anchor: 'left', xdata: xd('MDKot') });
  }

  // Dims
  const firstStopY = p.kuyuDibi;
  let lastStopY = p.kuyuDibi;
  for (let i = 0; i < p.katlar.length - 1; i++) lastStopY += p.katlar[i].yukseklik;
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: '#22d3ee', lineWidth: 1, x1: mk(-250), y1: mk(firstStopY), x2: mk(-250), y2: mk(lastStopY), dimText: `SEYİR = ${seyirMesafesi} mm`, dimDir: 'v', dimOffset: 0, xdata: xd('DimSeyir') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: '#a78bfa', lineWidth: 1, x1: mk(-350), y1: 0, x2: mk(-350), y2: mk(totalH), dimText: `KUYU = ${kuyuMesafesi} mm`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKuyu') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: mk(-150), y1: 0, x2: mk(-150), y2: mk(p.kuyuDibi), dimText: `${p.kuyuDibi}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKuyuDibi', 'kuyuDibi') });
  // KapiH dimension
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.door, lineWidth: 0.6, x1: mk(-80), y1: mk(firstStopY), x2: mk(-80), y2: mk(firstStopY + kapiH), dimText: `${kapiH}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKapiH', 'kapiH') });

  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: mk(shaftW / 2), y: mk(totalH + 200), text: `TÜM KUYU BB KESİTİ Ö:1/${p.olcek > 1 ? p.olcek : 20}`, fontSize: 80, anchor: 'center', xdata: xd('Title') });

  return ents;
}


// ═══════════════════════════════════════════════════════════════════════════════
// ENHANCED EN81-1 CALCULATION ENGINE
// ═══════════════════════════════════════════════════════════════════════════════

const RAIL_PROFILE_DETAILS: Record<string, { weight: number; ix: number; iy: number; wx: number; wy: number; A: number; c: number }> = {
  'T50/A': { weight: 3.7, ix: 7.1, iy: 7.1, wx: 3.2, wy: 2.8, A: 4.71, c: 12.5 },
  'T70/A': { weight: 5.5, ix: 22.9, iy: 7.7, wx: 6.5, wy: 3.5, A: 7.01, c: 16.0 },
  'T70/B': { weight: 5.5, ix: 22.9, iy: 7.7, wx: 6.5, wy: 3.5, A: 7.01, c: 16.0 },
  'T82/B': { weight: 9.5, ix: 52.0, iy: 11.0, wx: 11.0, wy: 5.0, A: 12.1, c: 19.0 },
  'T89/B': { weight: 12.3, ix: 79.7, iy: 14.5, wx: 14.5, wy: 6.0, A: 15.7, c: 22.0 },
  'T127/B': { weight: 22.3, ix: 280.0, iy: 30.0, wx: 32.0, wy: 10.0, A: 28.4, c: 31.5 },
};

const OMEGA_TABLE: [number, number, number][] = [
  [20, 1.04, 1.02], [30, 1.09, 1.05], [40, 1.16, 1.09], [50, 1.26, 1.14],
  [60, 1.39, 1.21], [70, 1.56, 1.30], [80, 1.77, 1.42], [90, 2.02, 1.57],
  [100, 2.31, 1.75], [110, 2.64, 1.97], [120, 3.01, 2.22], [130, 3.42, 2.51],
  [140, 3.87, 2.84], [150, 4.36, 3.20], [160, 4.89, 3.60], [170, 5.46, 4.03],
  [180, 6.07, 4.50], [190, 6.72, 5.00], [200, 7.41, 5.54],
];

function interpolateOmega(narinlik: number, Rm: number): number {
  let omega370 = 1.0, omega520 = 1.0;
  if (narinlik <= OMEGA_TABLE[0][0]) {
    omega370 = OMEGA_TABLE[0][1]; omega520 = OMEGA_TABLE[0][2];
  } else if (narinlik >= OMEGA_TABLE[OMEGA_TABLE.length - 1][0]) {
    omega370 = OMEGA_TABLE[OMEGA_TABLE.length - 1][1]; omega520 = OMEGA_TABLE[OMEGA_TABLE.length - 1][2];
  } else {
    for (let i = 0; i < OMEGA_TABLE.length - 1; i++) {
      if (narinlik >= OMEGA_TABLE[i][0] && narinlik <= OMEGA_TABLE[i + 1][0]) {
        const t = (narinlik - OMEGA_TABLE[i][0]) / (OMEGA_TABLE[i + 1][0] - OMEGA_TABLE[i][0]);
        omega370 = OMEGA_TABLE[i][1] + t * (OMEGA_TABLE[i + 1][1] - OMEGA_TABLE[i][1]);
        omega520 = OMEGA_TABLE[i][2] + t * (OMEGA_TABLE[i + 1][2] - OMEGA_TABLE[i][2]);
        break;
      }
    }
  }
  return omega370 + ((omega520 - omega370) / 150) * (Rm - 370);
}

interface EN81CalcResult {
  trafikH: number; trafikSe: number; trafikTr: number; trafikR: number; trafikL: number;
  Ga: number; Smotor: number; hesaplananMotorGucu: number; motorUygun: boolean;
  P1: number; P2: number; F1: number; F2: number; Fk: number; Fc: number;
  Q1: number; Q2: number; Fs: number;
  narinlik: number; omega: number; Wr: number;
  gerilmeK: number; gerilmeM: number; gerilmeA: number; gerilmeF: number;
  gerilmeZul: number;
  tetaX: number; tetaY: number; tetaZul: number;
  gerilmeM1: number; gerilmeA2: number; gerilmeZul1: number;
  agrGerilmeA1: number; agrGerilmeF1: number; agrTetaX1: number; agrTetaY1: number;
  yukGerilmeM: number; yukGerilmeF: number; yukTetaX: number; yukGerilmeA: number;
  kontrolSonuclari: { no: number; aciklama: string; uygun: boolean }[];
  halatKutlesi: number; Gh: number;
  karsiAgirlik: number;
  beyanYuk: number; kisiSayisi: number;
}

function hesaplaEN81Full(p: ElevatorParams): EN81CalcResult {
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const beyan = beyanYukBul(kabinGen, kabinDer);
  const beyanYuk = beyan.yuk;
  const kisiSayisi = beyan.kisi;
  const seyirMesafesi = hesaplaSeyirMesafesi(p.katlar);
  const gn = 9.81;
  const KRA = 2;
  const Rm = 370; // Ray malzeme dayanımı N/mm²
  const St = 3; // Güvenlik katsayısı (güvenlikli kullanma)
  const St1 = 3.75; // Güvenlik katsayısı (normal kullanma)
  const E = 21000 * gn; // Elastisite modülü N/mm²
  const verim = p.motorVerim / 100;
  const q = 0.5; // Denge oranı katsayısı

  // Darbe katsayısı
  let darbe = 5;
  if (p.frenTipi === 'Kampana') darbe = 3;
  else if (p.frenTipi === 'Elektromanyetik') darbe = 2;

  // Halat kütlesi
  const halatKutlesiPerM = (Math.PI * (p.halatCapi / 2000) ** 2) * 7850; // kg/m
  const halatKutlesi = halatKutlesiPerM * seyirMesafesi / 1000 * p.halatSayisi;
  const Gh = halatKutlesi;
  const dhKut = Gh; // Halat dengeleme kütlesi

  // Karşı ağırlık
  const Ga = p.kabinP + p.kapiAgirlik + beyanYuk * q;
  const karsiAgirlik = Ga;

  // Motor hesabı
  const Smotor = (p.kabinP + p.kapiAgirlik + beyanYuk) - Ga - dhKut;
  const hesaplananMotorGucu = (1 / verim) * (Math.abs(Smotor) * gn * p.hiz / 1000);
  const motorUygun = p.motorGucu >= hesaplananMotorGucu;

  // Trafik analizi
  const trafikH = seyirMesafesi / 1000; // m
  const trafikSe = trafikH / p.hiz; // saniye
  const trafikTr = trafikSe + 10; // toplam tur süresi (kapı açma/kapama dahil)
  const trafikR = 3600 / trafikTr; // saat başına tur
  const trafikL = trafikR * kisiSayisi; // saat başına taşınan kişi

  // Ray kuvvetleri
  const P1 = 4 * gn * (p.kabinP + p.kapiAgirlik + beyanYuk + Gh);
  const P2 = 4 * gn * (p.kabinP + p.kapiAgirlik + Gh + q * beyanYuk);
  const F1 = (darbe * gn * (p.kabinP + p.kapiAgirlik + beyanYuk + Gh)) / KRA;
  const F2 = (darbe * gn * Ga) / KRA;

  // Kabin ağırlık merkezi ve askı noktası mesafeleri
  const kabinGenM = kabinGen / 1000;
  const kabinDerM = kabinDer / 1000;
  const Xc = p.Xc !== 0 ? p.Xc / 1000 : kabinGenM / 2;
  const Yc = p.Yc !== 0 ? p.Yc / 1000 : kabinDerM / 2;
  const Xs = p.Xs !== 0 ? p.Xs / 1000 : kabinGenM / 2;
  const Ys = p.Ys !== 0 ? p.Ys / 1000 : 0;
  const Xp = p.Xp !== 0 ? p.Xp / 1000 : 0;
  const Yp = p.Yp !== 0 ? p.Yp / 1000 : kabinDerM / 2;

  // Kuvvet bileşenleri
  const dx = Math.abs(Xc - Xs);
  const dy = Math.abs(Yc - Ys);
  const _patenOffset = Math.abs(Xp - Xc) + Math.abs(Yp - Yc); // Paten-ağırlık merkezi mesafesi
  void _patenOffset; // Used in advanced calculations
  const Fk = F1; // Frenleme kuvveti
  const Fc = F1 * 0.3; // Çarpma kuvveti

  // Eğilme momentleri (Durum 1 - Güvenlikli kullanma)
  const lk = p.konsolMesafe / 1000; // konsol mesafesi metre
  const Fx = Fk * dy + Fc * dx;
  const Fy = Fk * dx + Fc * dy;

  // Ray profil özellikleri
  const rayProfil = RAIL_PROFILE_DETAILS[p.kabinRayTipi] || RAIL_PROFILE_DETAILS['T89/B'];
  const Ix = rayProfil.ix; // cm⁴
  const Iy = rayProfil.iy; // cm⁴
  const Wx = rayProfil.wx; // cm³
  const Wy = rayProfil.wy; // cm³
  const A = rayProfil.A; // cm²
  const k3 = 1; // Yük katsayısı

  // Narinlik hesabı
  const eylemsizlikCapi = Math.sqrt(Ix / A); // cm
  const lkCm = lk * 100; // cm
  const narinlik = lkCm / eylemsizlikCapi;

  // Omega interpolasyonu
  const omega = interpolateOmega(narinlik, Rm);
  const Wr = omega;

  // Güvenlikli kullanma gerilmeleri
  const M = p.kabinP + p.kapiAgirlik + beyanYuk;
  const gerilmeK = ((Fk + k3 * M * gn) * Wr) / (A * 100); // N/mm² (A cm² -> mm²)
  const gerilmeM = (Fx * lk * 1000) / (4 * Wx * 1000) + (Fy * lk * 1000) / (4 * Wy * 1000); // N/mm²
  const gerilmeA = gerilmeK + gerilmeM; // Birleşik gerilme
  const gerilmeF = (Fc * lk * 1000) / (4 * Wy * 1000); // Ray boynu eğilmesi
  const gerilmeZul = Rm / St; // İzin verilen gerilme

  // Eğilme miktarları
  const tetaX = (0.7 * Fx * (lk * 1000) ** 3) / (48 * E * Iy * 10000); // mm
  const tetaY = (0.7 * Fy * (lk * 1000) ** 3) / (48 * E * Ix * 10000); // mm
  const tetaZul = 5; // mm

  // Normal kullanma hareket gerilmeleri
  const F1n = (gn * (p.kabinP + p.kapiAgirlik + beyanYuk + Gh)) / KRA;
  const Fxn = F1n * dy;
  const Fyn = F1n * dx;
  const gerilmeM1 = (Fxn * lk * 1000) / (4 * Wx * 1000) + (Fyn * lk * 1000) / (4 * Wy * 1000);
  const gerilmeK1 = ((F1n + k3 * M * gn) * Wr) / (A * 100);
  const gerilmeA2 = gerilmeK1 + gerilmeM1;
  const gerilmeZul1 = Rm / St1;

  // Normal kullanma eğilme
  const tetaXn = (0.7 * Fxn * (lk * 1000) ** 3) / (48 * E * Iy * 10000);
  const tetaYn = (0.7 * Fyn * (lk * 1000) ** 3) / (48 * E * Ix * 10000);

  // Karşı ağırlık ray hesabı
  const agrProfil = RAIL_PROFILE_DETAILS[p.agrRayTipi] || RAIL_PROFILE_DETAILS['T50/A'];
  const agrF = (darbe * gn * Ga) / KRA;
  const agrFx = agrF * 0.3;
  const agrFy = agrF * 0.2;
  const agrGerilmeM = (agrFx * lk * 1000) / (4 * agrProfil.wx * 1000) + (agrFy * lk * 1000) / (4 * agrProfil.wy * 1000);
  const agrGerilmeK = (agrF * Wr) / (agrProfil.A * 100);
  const agrGerilmeA1 = agrGerilmeK + agrGerilmeM;
  const agrGerilmeF1 = (agrFy * lk * 1000) / (4 * agrProfil.wy * 1000);
  const agrTetaX1 = (0.7 * agrFx * (lk * 1000) ** 3) / (48 * E * agrProfil.iy * 10000);
  const agrTetaY1 = (0.7 * agrFy * (lk * 1000) ** 3) / (48 * E * agrProfil.ix * 10000);

  // Normal kullanma yükleme
  const yukF = (gn * (p.kabinP + p.kapiAgirlik + beyanYuk)) / KRA;
  const yukFx = yukF * dy;
  const yukFy = yukF * dx;
  const yukGerilmeM = (yukFx * lk * 1000) / (4 * Wx * 1000) + (yukFy * lk * 1000) / (4 * Wy * 1000);
  const yukGerilmeK = (yukF * Wr) / (A * 100);
  const yukGerilmeF = (yukFy * lk * 1000) / (4 * Wy * 1000);
  const yukTetaX = (0.7 * yukFx * (lk * 1000) ** 3) / (48 * E * Iy * 10000);
  const yukGerilmeA = yukGerilmeK + yukGerilmeM;

  // Q1, Q2, Fs
  const Q1 = P1 / KRA;
  const Q2 = P2 / KRA;
  const Fs = F1;

  // 18 EN81-1 kontrol sonuçları
  const kontrolSonuclari: { no: number; aciklama: string; uygun: boolean }[] = [
    { no: 1, aciklama: 'Güvenlikli kullanma - Birleşik gerilme', uygun: gerilmeA <= gerilmeZul },
    { no: 2, aciklama: 'Güvenlikli kullanma - Basınç gerilmesi', uygun: gerilmeK <= gerilmeZul },
    { no: 3, aciklama: 'Güvenlikli kullanma - Ray boynu eğilmesi', uygun: gerilmeF <= gerilmeZul },
    { no: 4, aciklama: 'Güvenlikli kullanma - X ekseni eğilme miktarı', uygun: tetaX <= tetaZul },
    { no: 5, aciklama: 'Güvenlikli kullanma - Y ekseni eğilme miktarı', uygun: tetaY <= tetaZul },
    { no: 6, aciklama: 'Normal kullanma hareket - Birleşik gerilme', uygun: gerilmeA2 <= gerilmeZul1 },
    { no: 7, aciklama: 'Normal kullanma hareket - Basınç gerilmesi', uygun: gerilmeK1 <= gerilmeZul1 },
    { no: 8, aciklama: 'Normal kullanma hareket - Ray boynu eğilmesi', uygun: gerilmeM1 <= gerilmeZul1 },
    { no: 9, aciklama: 'Normal kullanma hareket - X ekseni eğilme', uygun: tetaXn <= tetaZul },
    { no: 10, aciklama: 'Normal kullanma hareket - Y ekseni eğilme', uygun: tetaYn <= tetaZul },
    { no: 11, aciklama: 'Karşı ağırlık ray - Birleşik gerilme', uygun: agrGerilmeA1 <= gerilmeZul },
    { no: 12, aciklama: 'Karşı ağırlık ray - Ray boynu eğilmesi', uygun: agrGerilmeF1 <= gerilmeZul },
    { no: 13, aciklama: 'Karşı ağırlık ray - X ekseni eğilme', uygun: agrTetaX1 <= tetaZul },
    { no: 14, aciklama: 'Karşı ağırlık ray - Y ekseni eğilme', uygun: agrTetaY1 <= tetaZul },
    { no: 15, aciklama: 'Normal kullanma yükleme - Birleşik gerilme', uygun: yukGerilmeA <= gerilmeZul1 },
    { no: 16, aciklama: 'Normal kullanma yükleme - Ray boynu eğilmesi', uygun: yukGerilmeF <= gerilmeZul1 },
    { no: 17, aciklama: 'Normal kullanma yükleme - X ekseni eğilme', uygun: yukTetaX <= tetaZul },
    { no: 18, aciklama: 'Normal kullanma yükleme - Basınç gerilmesi', uygun: yukGerilmeK <= gerilmeZul1 },
  ];

  return {
    trafikH, trafikSe, trafikTr, trafikR, trafikL,
    Ga, Smotor, hesaplananMotorGucu, motorUygun,
    P1, P2, F1, F2, Fk, Fc, Q1, Q2, Fs,
    narinlik, omega, Wr,
    gerilmeK, gerilmeM, gerilmeA, gerilmeF, gerilmeZul,
    tetaX, tetaY, tetaZul,
    gerilmeM1, gerilmeA2, gerilmeZul1,
    agrGerilmeA1, agrGerilmeF1, agrTetaX1, agrTetaY1,
    yukGerilmeM, yukGerilmeF, yukTetaX, yukGerilmeA,
    kontrolSonuclari,
    halatKutlesi, Gh, karsiAgirlik,
    beyanYuk, kisiSayisi,
  };
}


// ═══════════════════════════════════════════════════════════════════════════════
// HESAPLAMA RAPORU — Enhanced with Rail Force Calculations (Feature 10)
// ═══════════════════════════════════════════════════════════════════════════════

interface HesapRow {
  sno: number; parametre: string; standart: string; aciklama: string;
  formul: string; formulDeg: string; sonuc: string; durum: 'UY' | 'UD';
}

function hesaplaRapor(p: ElevatorParams): HesapRow[] {
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const beyan = beyanYukBul(kabinGen, kabinDer);
  const kabinAlani = (kabinGen * kabinDer) / 1_000_000;
  const maxAlan = maxKabinAlani(beyan.yuk);
  const seyirMesafesi = hesaplaSeyirMesafesi(p.katlar);
  const kuyuMesafesi = hesaplaKuyuMesafesi(p);
  // TS EN 81-20:2014 Madde 5.2.1.14 — Kuyu dibi minimum
  // Sığınak alanı: min 0.5m x 0.6m x 1.0m yükseklik + tampon stroku
  const tamponStrok = p.hiz <= 1.0 ? Math.ceil((p.hiz * p.hiz) / (2 * 9.81) * 1000) : Math.ceil((p.hiz * p.hiz) / (2 * 9.81) * 1000 * 1.15);
  const minKuyuDibi = Math.max(1200, tamponStrok + 500 + 350); // tampon + sığınak + boşluk
  // TS EN 81-20:2014 Madde 5.2.5.10 — Kuyu kafası minimum
  // Üst boşluk = 1.0 + 0.035*v² metre (min 3.6m)
  const minKuyuKafa = Math.max(3600, Math.ceil((1.0 + 0.035 * p.hiz * p.hiz) * 1000));
  const rows: HesapRow[] = [];
  let sno = 1;
  const en81 = hesaplaEN81Full(p);

  rows.push({ sno: sno++, parametre: 'Kuyu Dibi', standart: 'TS EN 81-20 5.2', aciklama: `Kuyu dibi min. ${minKuyuDibi} mm`, formul: `KuyuDibi ≥ ${minKuyuDibi}`, formulDeg: `${p.kuyuDibi} ≥ ${minKuyuDibi}`, sonuc: `${p.kuyuDibi} mm`, durum: p.kuyuDibi >= minKuyuDibi ? 'UY' : 'UD' });
  rows.push({ sno: sno++, parametre: 'Kuyu Kafası', standart: 'TS EN 81-20 5.2', aciklama: `Kuyu kafası min. ${minKuyuKafa} mm`, formul: `KuyuKafa ≥ ${minKuyuKafa}`, formulDeg: `${p.kuyuKafa} ≥ ${minKuyuKafa}`, sonuc: `${p.kuyuKafa} mm`, durum: p.kuyuKafa >= minKuyuKafa ? 'UY' : 'UD' });
  rows.push({ sno: sno++, parametre: 'Kabin Alanı', standart: 'TS EN 81-20 Tablo 6', aciklama: `Max. ${maxAlan.toFixed(2)} m²`, formul: `KabinAlanı ≤ MaxAlan`, formulDeg: `${kabinAlani.toFixed(2)} ≤ ${maxAlan.toFixed(2)}`, sonuc: `${kabinAlani.toFixed(2)} m²`, durum: kabinAlani <= maxAlan ? 'UY' : 'UD' });
  rows.push({ sno: sno++, parametre: 'Seyir Mesafesi', standart: 'GENEL', aciklama: 'İlk-Son durak arası', formul: 'Σ Kat Yükseklikleri', formulDeg: p.katlar.slice(0, -1).map(k => k.yukseklik).join('+'), sonuc: `${seyirMesafesi} mm`, durum: 'UY' });
  rows.push({ sno: sno++, parametre: 'Kuyu Mesafesi', standart: 'GENEL', aciklama: 'Kuyu dibi+Seyir+Kafa', formul: 'KD+S+KK', formulDeg: `${p.kuyuDibi}+${seyirMesafesi}+${p.kuyuKafa}`, sonuc: `${kuyuMesafesi} mm`, durum: 'UY' });
  rows.push({ sno: sno++, parametre: 'Beyan Yük', standart: 'TS EN 81-20 Tablo 1.1', aciklama: `${beyan.yuk} kg / ${beyan.kisi} kişi`, formul: 'Tablo 1.1', formulDeg: `Alan=${kabinAlani.toFixed(2)} m²`, sonuc: `${beyan.yuk} kg`, durum: 'UY' });
  rows.push({ sno: sno++, parametre: 'Kapı Yüksekliği', standart: 'TS EN 81-20 5.3', aciklama: 'Min. 2000 mm', formul: 'KapiH ≥ 2000', formulDeg: `${p.kapiH} ≥ 2000`, sonuc: `${p.kapiH} mm`, durum: p.kapiH >= 2000 ? 'UY' : 'UD' });

  // Motor hesabı
  rows.push({ sno: sno++, parametre: 'Motor Gücü', standart: 'TS EN 81-20', aciklama: 'Hesaplanan motor gücü', formul: '(1/η)×S×g×v/1000', formulDeg: `(1/${p.motorVerim/100})×${en81.Smotor.toFixed(0)}×9.81×${p.hiz}/1000`, sonuc: `${en81.hesaplananMotorGucu.toFixed(2)} kW`, durum: en81.motorUygun ? 'UY' : 'UD' });
  rows.push({ sno: sno++, parametre: 'Karşı Ağırlık', standart: 'TS EN 81-20', aciklama: 'KP+KapiAğ+Q×0.5', formul: 'KP+KapiAğ+Q×q', formulDeg: `${p.kabinP}+${p.kapiAgirlik}+${beyan.yuk}×0.5`, sonuc: `${en81.karsiAgirlik.toFixed(0)} kg`, durum: 'UY' });
  rows.push({ sno: sno++, parametre: 'Halat Kütlesi', standart: 'GENEL', aciklama: 'Toplam halat kütlesi', formul: 'π×r²×ρ×L×n', formulDeg: `Ø${p.halatCapi}×${p.halatSayisi}`, sonuc: `${en81.halatKutlesi.toFixed(1)} kg`, durum: 'UY' });

  // Ray kuvvetleri
  rows.push({ sno: sno++, parametre: 'P1 (Kabin Ray)', standart: 'TS EN 81-20', aciklama: 'Toplam kabin ray kuvveti', formul: '4×g×(KP+KapiAğ+Q+Gh)', formulDeg: `4×9.81×(${p.kabinP}+${p.kapiAgirlik}+${beyan.yuk}+${en81.Gh.toFixed(0)})`, sonuc: `${en81.P1.toFixed(0)} N`, durum: 'UY' });
  rows.push({ sno: sno++, parametre: 'F1 (Frenleme)', standart: 'TS EN 81-20', aciklama: 'Frenleme kuvveti/ray', formul: '(darbe×g×M)/KRA', formulDeg: `(${p.frenTipi === 'Disk' ? 5 : p.frenTipi === 'Kampana' ? 3 : 2}×9.81×M)/2`, sonuc: `${en81.F1.toFixed(0)} N`, durum: 'UY' });

  // 18 EN81-1 kontrolleri
  for (const k of en81.kontrolSonuclari) {
    rows.push({ sno: sno++, parametre: `Kontrol ${k.no}`, standart: 'TS EN 81-20', aciklama: k.aciklama, formul: k.no <= 5 ? 'σ ≤ σzul' : k.no <= 10 ? 'σ ≤ σzul1' : k.no <= 14 ? 'Ağr. σ ≤ σzul' : 'Yük σ ≤ σzul1', formulDeg: k.no <= 5 ? `σzul=${en81.gerilmeZul.toFixed(1)}` : `σzul=${en81.gerilmeZul1.toFixed(1)}`, sonuc: k.uygun ? 'UYGUN' : 'UYGUN DEĞİL', durum: k.uygun ? 'UY' : 'UD' });
  }

  // Kabin boyutları
  rows.push({ sno: sno++, parametre: 'Kabin Boyutları', standart: 'GENEL', aciklama: 'Hesaplanan boyutlar', formul: 'Kuyu-Boşluklar', formulDeg: `${kabinGen}×${kabinDer}`, sonuc: `${kabinGen}×${kabinDer} mm`, durum: kabinGen >= 400 && kabinDer >= 400 ? 'UY' : 'UD' });

  // Ray profil bilgileri
  const kabinRailProfile = RAIL_PROFILE_DETAILS[p.kabinRayTipi];
  const agrRailProfile = RAIL_PROFILE_DETAILS[p.agrRayTipi];
  if (kabinRailProfile) {
    rows.push({ sno: sno++, parametre: `Kabin Ray (${p.kabinRayTipi})`, standart: 'Katalog', aciklama: 'Ray profil özellikleri', formul: 'Ağ/Ix/Iy/Wx/Wy/A', formulDeg: `${kabinRailProfile.weight}/${kabinRailProfile.ix}/${kabinRailProfile.iy}/${kabinRailProfile.wx}/${kabinRailProfile.wy}/${kabinRailProfile.A}`, sonuc: `${kabinRailProfile.weight} kg/m`, durum: 'UY' });
  }
  if (agrRailProfile) {
    rows.push({ sno: sno++, parametre: `Ağırlık Ray (${p.agrRayTipi})`, standart: 'Katalog', aciklama: 'Ray profil özellikleri', formul: 'Ağ/Ix/Iy/Wx/Wy/A', formulDeg: `${agrRailProfile.weight}/${agrRailProfile.ix}/${agrRailProfile.iy}/${agrRailProfile.wx}/${agrRailProfile.wy}/${agrRailProfile.A}`, sonuc: `${agrRailProfile.weight} kg/m`, durum: 'UY' });
  }

  // Narinlik ve omega
  rows.push({ sno: sno++, parametre: 'Narinlik', standart: 'TS EN 81-20', aciklama: 'Ray narinlik oranı', formul: 'lk/i', formulDeg: `${(p.konsolMesafe/10).toFixed(1)}/${kabinRailProfile ? Math.sqrt(kabinRailProfile.ix/kabinRailProfile.A).toFixed(2) : '?'}`, sonuc: `λ = ${en81.narinlik.toFixed(1)}`, durum: en81.narinlik <= 200 ? 'UY' : 'UD' });
  rows.push({ sno: sno++, parametre: 'Omega (ω)', standart: 'TS EN 81-20', aciklama: 'Burkulma katsayısı', formul: 'Tablo interpolasyon', formulDeg: `λ=${en81.narinlik.toFixed(1)}, Rm=370`, sonuc: `ω = ${en81.omega.toFixed(3)}`, durum: 'UY' });

  return rows;
}
function generateHesapRaporu(p: ElevatorParams): CadEntity[] {
  const ents: CadEntity[] = [];
  const rows = hesaplaRapor(p);
  const startX = 0, startY = 0;
  const colWidths = [60, 200, 150, 350, 250, 250, 180, 80];
  const totalW = colWidths.reduce((a, b) => a + b, 0);
  const rowH = 55, headerH = 60, titleH = 80;

  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: startX + totalW / 2, y: startY + (rows.length + 1) * rowH + headerH + titleH + 30, text: 'EN81-1 HESAPLAMA RAPORU', fontSize: 70, anchor: 'center' });

  const tableH = headerH + rows.length * rowH;
  ents.push({ id: eid(), type: 'rect', layer: 'DIM', color: C.dim, lineWidth: 1.5, x: startX, y: startY, w: totalW, h: tableH });

  const headers = ['SNO', 'PARAMETRE', 'STANDART', 'AÇIKLAMA', 'FORMÜL', 'FORMÜL DEĞ.', 'SONUÇ', 'DURUM'];
  let hx = startX;
  const headerY = startY + tableH - headerH;
  for (let i = 0; i < headers.length; i++) {
    ents.push({ id: eid(), type: 'line', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: hx, y1: startY, x2: hx, y2: startY + tableH });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#60a5fa', lineWidth: 1, x: hx + colWidths[i] / 2, y: headerY + headerH / 2, text: headers[i], fontSize: 28, anchor: 'center' });
    hx += colWidths[i];
  }
  ents.push({ id: eid(), type: 'line', layer: 'DIM', color: C.dim, lineWidth: 1, x1: startX, y1: headerY, x2: startX + totalW, y2: headerY });

  for (let r = 0; r < rows.length; r++) {
    const row = rows[r];
    const ry = headerY - (r + 1) * rowH;
    ents.push({ id: eid(), type: 'line', layer: 'DIM', color: '#334155', lineWidth: 0.5, x1: startX, y1: ry, x2: startX + totalW, y2: ry });
    const vals = [`${row.sno}`, row.parametre, row.standart, row.aciklama, row.formul, row.formulDeg, row.sonuc, row.durum];
    let cx = startX;
    for (let c = 0; c < vals.length; c++) {
      const color = c === 7 ? (row.durum === 'UY' ? C.uygun : C.uygunDegil) : C.label;
      const fs = c === 7 ? 35 : 22;
      ents.push({ id: eid(), type: 'text', layer: 'LABEL', color, lineWidth: 1, x: cx + colWidths[c] / 2, y: ry + rowH / 2, text: vals[c], fontSize: fs, anchor: 'center' });
      cx += colWidths[c];
    }
  }
  return ents;
}


// ═══════════════════════════════════════════════════════════════════════════════
// HESAP ÖZETİ
// ═══════════════════════════════════════════════════════════════════════════════

function generateHesapOzeti(p: ElevatorParams): CadEntity[] {
  const ents: CadEntity[] = [];
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const beyan = beyanYukBul(kabinGen, kabinDer);
  const kabinAlani = (kabinGen * kabinDer) / 1_000_000;
  const maxAlan = maxKabinAlani(beyan.yuk);
  const seyirMesafesi = hesaplaSeyirMesafesi(p.katlar);
  const kuyuMesafesi = hesaplaKuyuMesafesi(p);
  // TS EN 81-20:2014 Madde 5.2.1.14 — Kuyu dibi minimum
  // Sığınak alanı: min 0.5m x 0.6m x 1.0m yükseklik + tampon stroku
  const tamponStrok = p.hiz <= 1.0 ? Math.ceil((p.hiz * p.hiz) / (2 * 9.81) * 1000) : Math.ceil((p.hiz * p.hiz) / (2 * 9.81) * 1000 * 1.15);
  const minKuyuDibi = Math.max(1200, tamponStrok + 500 + 350); // tampon + sığınak + boşluk
  // TS EN 81-20:2014 Madde 5.2.5.10 — Kuyu kafası minimum
  // Üst boşluk = 1.0 + 0.035*v² metre (min 3.6m)
  const minKuyuKafa = Math.max(3600, Math.ceil((1.0 + 0.035 * p.hiz * p.hiz) * 1000));
  const psForce = (2 * beyan.yuk + 1.5 * p.kabinP + 300 + 100) * 9.81;
  const P1 = (beyan.yuk + p.kabinP) * 39.24;
  const PR1 = P1 / 2;
  const P2 = (0.5 * beyan.yuk + p.kabinP) * 39.24;

  const pageW = 2100, pageH = 2970;
  const margin = 80, lineH = 55;
  let curY = pageH - margin;

  ents.push({ id: eid(), type: 'rect', layer: 'DIM', color: C.dim, lineWidth: 2, x: 0, y: 0, w: pageW, h: pageH });
  ents.push({ id: eid(), type: 'rect', layer: 'DIM', color: C.dim, lineWidth: 1, x: margin / 2, y: margin / 2, w: pageW - margin, h: pageH - margin });

  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#60a5fa', lineWidth: 1, x: pageW / 2, y: curY, text: p.firma.firmaAdi.toUpperCase(), fontSize: 60, anchor: 'center' });
  curY -= lineH;
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: pageW / 2, y: curY, text: p.firma.adres, fontSize: 35, anchor: 'center' });
  curY -= lineH * 0.7;
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: pageW / 2, y: curY, text: `Tel: ${p.firma.tel}`, fontSize: 30, anchor: 'center' });
  curY -= lineH;
  ents.push({ id: eid(), type: 'line', layer: 'DIM', color: '#334155', lineWidth: 1.5, x1: margin, y1: curY, x2: pageW - margin, y2: curY });
  curY -= lineH;

  const titleText = p.asansorTipi === 'EA' ? 'ELEKTRİKLİ ASANSÖR HESAP ÖZETİ' : 'HİDROLİK ASANSÖR HESAP ÖZETİ';
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: pageW / 2, y: curY, text: titleText, fontSize: 55, anchor: 'center' });
  curY -= lineH * 1.5;

  const infoLines: [string, string][] = [
    ['Asansör Tipi', p.asansorTipi === 'EA' ? 'Elektrikli Asansör' : 'Hidrolik Asansör'],
    ['Asansör Sayısı', `${p.asansorSayisi}`],
    ['Tahrik Tipi', p.tahrikKodu],
    ['Beyan Yük', `${beyan.yuk} kg / ${beyan.kisi} kişi`],
    ['Hız', `${p.hiz} m/s`],
    ['Durak Sayısı', `${p.katlar.length}`],
    ['Kuyu Boyutları', `${p.kuyuGen} × ${p.kuyuDer} mm`],
    ['Kabin Boyutları', `${kabinGen} × ${kabinDer} mm`],
    ['Kabin Alanı', `${kabinAlani.toFixed(2)} m²`],
    ['Kabin Ağırlığı', `${p.kabinP} kg`],
    ['Seyir Mesafesi', `${seyirMesafesi} mm`],
    ['Kuyu Mesafesi', `${kuyuMesafesi} mm`],
    ['Kuyu Dibi', `${p.kuyuDibi} mm`],
    ['Kuyu Kafası', `${p.kuyuKafa} mm`],
    ['Halat', `${p.halatSayisi} × Ø${p.halatCapi} mm`],
    ['Motor Gücü', `${p.motorGucu} kW`],
    ['Fren Tipi', p.frenTipi],
    ['Kabin Ray', `${p.kabinRayTipi}${RAIL_PROFILES[p.kabinRayTipi] ? ` (${RAIL_PROFILES[p.kabinRayTipi].weight} kg/m)` : ''}`],
    ['Ağırlık Ray', `${p.agrRayTipi}${RAIL_PROFILES[p.agrRayTipi] ? ` (${RAIL_PROFILES[p.agrRayTipi].weight} kg/m)` : ''}`],
    ['Panoramik', p.panoramik ? 'Evet' : 'Hayır'],
  ];

  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#60a5fa', lineWidth: 1, x: margin, y: curY, text: 'GENEL BİLGİLER', fontSize: 40, anchor: 'left' });
  curY -= lineH * 0.8;
  ents.push({ id: eid(), type: 'line', layer: 'DIM', color: '#334155', lineWidth: 0.8, x1: margin, y1: curY + lineH * 0.3, x2: pageW - margin, y2: curY + lineH * 0.3 });
  for (const [label, value] of infoLines) {
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: margin + 20, y: curY, text: label, fontSize: 30, anchor: 'left' });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: margin + 600, y: curY, text: `: ${value}`, fontSize: 30, anchor: 'left' });
    curY -= lineH * 0.75;
  }
  curY -= lineH * 0.5;

  // EN81-1 Checks
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#60a5fa', lineWidth: 1, x: margin, y: curY, text: 'EN81-1 KONTROLLER', fontSize: 40, anchor: 'left' });
  curY -= lineH * 0.8;
  const checks: [string, string, string, boolean][] = [
    ['Kuyu Dibi Minimum', `≥ ${minKuyuDibi} mm`, `${p.kuyuDibi} mm`, p.kuyuDibi >= minKuyuDibi],
    ['Kuyu Kafası Minimum', `≥ ${minKuyuKafa} mm`, `${p.kuyuKafa} mm`, p.kuyuKafa >= minKuyuKafa],
    ['Kabin Alanı (Tablo 6)', `≤ ${maxAlan.toFixed(2)} m²`, `${kabinAlani.toFixed(2)} m²`, kabinAlani <= maxAlan],
    ['Kapı Yüksekliği', '≥ 2000 mm', `${p.kapiH} mm`, p.kapiH >= 2000],
    ['Denge Oranı', '0.40 - 0.50', `${p.dengeOrani}`, p.dengeOrani >= 0.4 && p.dengeOrani <= 0.5],
  ];
  for (const [label, condition, value, pass] of checks) {
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: margin + 20, y: curY, text: label, fontSize: 28, anchor: 'left' });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: margin + 500, y: curY, text: condition, fontSize: 28, anchor: 'left' });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: margin + 900, y: curY, text: value, fontSize: 28, anchor: 'left' });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: pass ? C.uygun : C.uygunDegil, lineWidth: 1, x: margin + 1300, y: curY, text: pass ? 'UY' : 'UD', fontSize: 35, anchor: 'left' });
    curY -= lineH * 0.75;
  }
  curY -= lineH;

  // Rail forces
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#60a5fa', lineWidth: 1, x: margin, y: curY, text: 'RAY KUVVET HESABI', fontSize: 40, anchor: 'left' });
  curY -= lineH;
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: margin + 20, y: curY, text: `P1 = (Q + KabinP) × 39.24 = (${beyan.yuk} + ${p.kabinP}) × 39.24 = ${Math.round(P1)} N`, fontSize: 30, anchor: 'left' });
  curY -= lineH * 0.75;
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: margin + 20, y: curY, text: `PR1 = P1/2 = ${Math.round(PR1)} N — ${p.kabinRayTipi}`, fontSize: 30, anchor: 'left' });
  curY -= lineH * 0.75;
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: margin + 20, y: curY, text: `P2 = (0.5×Q + KabinP) × 39.24 = (0.5×${beyan.yuk} + ${p.kabinP}) × 39.24 = ${Math.round(P2)} N — ${p.agrRayTipi}`, fontSize: 30, anchor: 'left' });
  curY -= lineH;

  // PS Force
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#60a5fa', lineWidth: 1, x: margin, y: curY, text: 'STATİK YÜK HESABI', fontSize: 40, anchor: 'left' });
  curY -= lineH;
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: margin + 20, y: curY, text: `PS = (2×${beyan.yuk} + 1.5×${p.kabinP} + 300 + 100) × 9.81 = ${Math.round(psForce)} N`, fontSize: 30, anchor: 'left' });
  curY -= lineH * 1.5;

  // Floor info
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#60a5fa', lineWidth: 1, x: margin, y: curY, text: 'KAT BİLGİLERİ', fontSize: 40, anchor: 'left' });
  curY -= lineH * 0.8;
  for (const kat of p.katlar) {
    const kotStr = kat.mimariKot >= 0 ? `+${kat.mimariKot.toFixed(2)}` : kat.mimariKot.toFixed(2);
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: margin + 20, y: curY, text: `${kat.rumuz}. Kat — Yükseklik: ${kat.yukseklik} mm — Mimari Kot: ${kotStr}`, fontSize: 28, anchor: 'left' });
    curY -= lineH * 0.65;
  }
  curY -= lineH;

  // Signatures
  ents.push({ id: eid(), type: 'line', layer: 'DIM', color: '#334155', lineWidth: 1, x1: margin, y1: curY + lineH * 0.3, x2: pageW - margin, y2: curY + lineH * 0.3 });
  curY -= lineH * 0.5;
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: margin + 100, y: curY, text: 'HAZIRLAYAN', fontSize: 30, anchor: 'center' });
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: pageW - margin - 100, y: curY, text: 'ONAYLAYAN', fontSize: 30, anchor: 'center' });
  curY -= lineH;
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: margin + 100, y: curY, text: p.firma.muhendis, fontSize: 30, anchor: 'center' });
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: pageW - margin - 100, y: curY, text: '...........................', fontSize: 30, anchor: 'center' });

  return ents;
}


// ═══════════════════════════════════════════════════════════════════════════════
// CANVAS RENDERING ENGINE
// ═══════════════════════════════════════════════════════════════════════════════

// ═══════════════════════════════════════════════════════════════════════════════
// TÜM PROJE — All sections on single canvas
// ═══════════════════════════════════════════════════════════════════════════════

function generateTumProje(p: ElevatorParams): CadEntity[] {
  const ents: CadEntity[] = [];
  const gap = 800; // generous spacing between sections

  // Helper to shift entities by offset
  const shiftEnts = (source: CadEntity[], dx: number, dy: number): CadEntity[] => {
    return source.map(e => {
      const s = { ...e, id: eid() };
      if (s.x !== undefined) s.x = (s.x || 0) + dx;
      if (s.y !== undefined) s.y = (s.y || 0) + dy;
      if (s.x1 !== undefined) s.x1 = (s.x1 || 0) + dx;
      if (s.y1 !== undefined) s.y1 = (s.y1 || 0) + dy;
      if (s.x2 !== undefined) s.x2 = (s.x2 || 0) + dx;
      if (s.y2 !== undefined) s.y2 = (s.y2 || 0) + dy;
      if (s.cx !== undefined) s.cx = (s.cx || 0) + dx;
      if (s.cy !== undefined) s.cy = (s.cy || 0) + dy;
      if (s.points) s.points = s.points.map(pt => ({ x: pt.x + dx, y: pt.y + dy }));
      return s;
    });
  };

  // Helper: get bounding box then normalize to (0,0) origin
  const prepareSection = (genFn: () => CadEntity[]): { ents: CadEntity[]; w: number; h: number } => {
    const raw = genFn();
    let minX = Infinity, minY = Infinity, maxX = -Infinity, maxY = -Infinity;
    for (const e of raw) {
      const bb = getEntityBounds(e);
      if (bb) { minX = Math.min(minX, bb.minX); minY = Math.min(minY, bb.minY); maxX = Math.max(maxX, bb.maxX); maxY = Math.max(maxY, bb.maxY); }
    }
    if (!isFinite(minX)) return { ents: raw, w: 0, h: 0 };
    // Normalize: shift so that minX=0, minY=0
    const normalized = shiftEnts(raw, -minX, -minY);
    return { ents: normalized, w: maxX - minX, h: maxY - minY };
  };

  // Generate and normalize all sections
  const kk = prepareSection(() => generateCrossSection(p));
  const kd = prepareSection(() => generateLongitudinalSection(p));
  const kabin = prepareSection(() => generateCabinPlan(p));
  const kapi = prepareSection(() => generateKapiDetay(p));
  const hasMD = p.asansorTipi === 'EA' && p.tahrikKodu !== 'MDDUZ' && p.tahrikKodu !== 'MDCAP';
  const md = hasMD ? prepareSection(() => generateMachineRoom(p)) : { ents: [], w: 0, h: 0 };
  const tkaa = prepareSection(() => generateTKAA(p));
  const tkbb = prepareSection(() => generateTKBB(p));
  const aski = prepareSection(() => generateAskiDiyagram(p));

  // ═══ LAYOUT: 2 rows, left-to-right placement ═══
  // ROW 1: KK | KD | Kabin Planı
  let curX = 0;
  ents.push(...shiftEnts(kk.ents, curX, 0));
  curX += kk.w + gap;
  ents.push(...shiftEnts(kd.ents, curX, 0));
  curX += kd.w + gap;
  ents.push(...shiftEnts(kabin.ents, curX, 0));
  const row1RightEdge = curX + kabin.w;
  const row1Height = Math.max(kk.h, kd.h, kabin.h);

  // ROW 2: TK-AA | TK-BB | Kapı Detayı | Makine Dairesi
  const row2Y = row1Height + gap;
  curX = 0;
  ents.push(...shiftEnts(tkaa.ents, curX, row2Y));
  curX += tkaa.w + gap;
  ents.push(...shiftEnts(tkbb.ents, curX, row2Y));
  curX += tkbb.w + gap;
  ents.push(...shiftEnts(kapi.ents, curX, row2Y));
  curX += kapi.w + gap;
  if (hasMD) {
    ents.push(...shiftEnts(md.ents, curX, row2Y));
    curX += md.w;
  }
  const row2Height = Math.max(tkaa.h, tkbb.h, kapi.h, hasMD ? md.h : 0);

  // ROW 3: Askı Diyagramı + Antet
  const row3Y = row2Y + row2Height + gap;
  ents.push(...shiftEnts(aski.ents, 0, row3Y));

  // Antet / Bilgi kutusu to the right
  const antetX = aski.w + gap;
  const antetY = row3Y;
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const beyan = beyanYukBul(kabinGen, kabinDer);
  const antetW = 2500, antetH = 1800;
  ents.push({ id: eid(), type: 'rect', layer: 'DIM', color: C.dim, lineWidth: 2, x: antetX, y: antetY, w: antetW, h: antetH });
  // Firma bilgileri
  let ay = antetY + antetH - 60;
  const aLH = 55;
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#60a5fa', lineWidth: 1, x: antetX + antetW / 2, y: ay, text: p.firma.firmaAdi.toUpperCase(), fontSize: 55, anchor: 'center' });
  ay -= aLH;
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: antetX + antetW / 2, y: ay, text: p.firma.adres, fontSize: 30, anchor: 'center' });
  ay -= aLH;
  ents.push({ id: eid(), type: 'line', layer: 'DIM', color: '#334155', lineWidth: 1, x1: antetX + 40, y1: ay, x2: antetX + antetW - 40, y2: ay });
  ay -= aLH;
  const infoRows: [string, string][] = [
    ['Asansör Tipi', `${p.asansorTipi} — ${p.tahrikKodu}`],
    ['Beyan Yük', `${beyan.yuk} kg / ${beyan.kisi} kişi`],
    ['Hız', `${p.hiz} m/s`],
    ['Kuyu', `${p.kuyuGen} × ${p.kuyuDer} mm`],
    ['Kabin', `${kabinGen} × ${kabinDer} mm`],
    ['Durak Sayısı', `${p.katlar.length}`],
    ['Seyir Mesafesi', `${hesaplaSeyirMesafesi(p.katlar)} mm`],
    ['Kuyu Mesafesi', `${hesaplaKuyuMesafesi(p)} mm`],
    ['Kabin Ray', p.kabinRayTipi],
    ['Ağırlık Ray', p.agrRayTipi],
    ['Halat', `${p.halatSayisi} × Ø${p.halatCapi} mm`],
    ['Motor', `${p.motorGucu} kW — ${p.frenTipi}`],
    ['Mühendis', p.firma.muhendis],
  ];
  for (const [label, value] of infoRows) {
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: antetX + 50, y: ay, text: label, fontSize: 28, anchor: 'left' });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: antetX + 700, y: ay, text: `: ${value}`, fontSize: 28, anchor: 'left' });
    ay -= aLH * 0.8;
  }

  // ═══ BORDER FRAME — Tüm çizimlerin bounding box'ına göre otomatik boyut ═══
  // Calculate actual bounding box of all entities
  let bbMinX = Infinity, bbMinY = Infinity, bbMaxX = -Infinity, bbMaxY = -Infinity;
  for (const e of ents) {
    const bb = getEntityBounds(e);
    if (bb) {
      bbMinX = Math.min(bbMinX, bb.minX);
      bbMinY = Math.min(bbMinY, bb.minY);
      bbMaxX = Math.max(bbMaxX, bb.maxX);
      bbMaxY = Math.max(bbMaxY, bb.maxY);
    }
  }
  // Add margin around all content
  const margin = 500;
  const frameX = bbMinX - margin;
  const frameY = bbMinY - margin;
  const frameW = (bbMaxX - bbMinX) + margin * 2;
  const frameH = (bbMaxY - bbMinY) + margin * 2;
  // Outer frame
  ents.push({ id: eid(), type: 'rect', layer: 'DIM', color: '#475569', lineWidth: 3, x: frameX, y: frameY, w: frameW, h: frameH });
  // Inner frame
  ents.push({ id: eid(), type: 'rect', layer: 'DIM', color: '#334155', lineWidth: 1, x: frameX + 50, y: frameY + 50, w: frameW - 100, h: frameH - 100 });

  // Title block (centered at bottom)
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: frameX + frameW / 2, y: frameY + 100, text: 'TÜM PROJE — ASNCAD ASANSÖR ÇİZİM SİSTEMİ', fontSize: 90, anchor: 'center' });

  return ents;
}


// ═══════════════════════════════════════════════════════════════════════════════
// KAPI DETAY — Door Detail Drawing
// ═══════════════════════════════════════════════════════════════════════════════

function generateKapiDetay(p: ElevatorParams): CadEntity[] {
  const ents: CadEntity[] = [];
  const xd = (bn: string): XData => ({ blockName: bn, liftNumber: 1, sectionCode: 'KD' });
  const kapiH = p.kapiH;
  const kapiGen = p.kapiGen;
  const kasaW = 60;
  const kasaH = kapiH + 100;
  const sillH = 30;
  const sillW = kapiGen + 200;

  // Door frame (kasa)
  ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 2, x: -kasaW, y: 0, w: kapiGen + 2 * kasaW, h: kasaH, xdata: xd('KapiKasa') });
  ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: '#475569', lineWidth: 1.5, x: 0, y: 0, w: kapiGen, h: kapiH, xdata: xd('KapiAciklik') });

  // Sill detail
  ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.sill, lineWidth: 2, x: -100, y: -sillH, w: sillW, h: sillH, xdata: xd('Esik') });
  ents.push({ id: eid(), type: 'hatch', layer: 'HATCH', color: C.hatch, lineWidth: 0.5, x: -100, y: -sillH, w: sillW, h: sillH, hatchAngle: 45, hatchSpacing: 20, xdata: xd('EsikHatch') });

  // Door panels based on kapiTipi
  const panelGap = 10;
  if (p.kapiTipi === 'KK-OT' || p.kapiTipi === 'KK-KK') {
    // Center opening - 2 panels
    const panelW = (kapiGen - panelGap) / 2;
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 2, x: 0, y: 0, w: panelW, h: kapiH, xdata: xd('KapiPanel1') });
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 2, x: panelW + panelGap, y: 0, w: panelW, h: kapiH, xdata: xd('KapiPanel2') });
    // Opening arrows
    ents.push({ id: eid(), type: 'line', layer: 'DIM', color: '#60a5fa', lineWidth: 1, dash: [15, 8], x1: kapiGen / 2, y1: kapiH / 2, x2: 0, y2: kapiH / 2, xdata: xd('AcilmaYon') });
    ents.push({ id: eid(), type: 'line', layer: 'DIM', color: '#60a5fa', lineWidth: 1, dash: [15, 8], x1: kapiGen / 2, y1: kapiH / 2, x2: kapiGen, y2: kapiH / 2, xdata: xd('AcilmaYon') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: kapiGen / 2, y: kapiH / 2 + 60, text: p.kapiTipi, fontSize: 40, anchor: 'center', xdata: xd('KapiTipiLabel') });
  } else if (p.kapiTipi === 'OT-2') {
    // 2-panel telescopic
    const panel1W = kapiGen * 0.6;
    const panel2W = kapiGen * 0.4;
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 2, x: 0, y: 0, w: panel1W, h: kapiH, xdata: xd('KapiPanel1') });
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: '#4ade80', lineWidth: 2, x: panel1W + panelGap, y: 50, w: panel2W - panelGap, h: kapiH - 100, xdata: xd('KapiPanel2') });
    ents.push({ id: eid(), type: 'line', layer: 'DIM', color: '#60a5fa', lineWidth: 1, dash: [15, 8], x1: kapiGen, y1: kapiH / 2, x2: 0, y2: kapiH / 2, xdata: xd('AcilmaYon') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: kapiGen / 2, y: kapiH / 2 + 60, text: 'OT-2 Teleskopik', fontSize: 40, anchor: 'center', xdata: xd('KapiTipiLabel') });
  } else {
    // OT-3: 3-panel telescopic
    const panel1W = kapiGen * 0.45;
    const panel2W = kapiGen * 0.30;
    const panel3W = kapiGen * 0.20;
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: C.door, lineWidth: 2, x: 0, y: 0, w: panel1W, h: kapiH, xdata: xd('KapiPanel1') });
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: '#4ade80', lineWidth: 2, x: panel1W + panelGap, y: 30, w: panel2W, h: kapiH - 60, xdata: xd('KapiPanel2') });
    ents.push({ id: eid(), type: 'rect', layer: 'KAPI', color: '#22d3ee', lineWidth: 2, x: panel1W + panel2W + 2 * panelGap, y: 60, w: panel3W, h: kapiH - 120, xdata: xd('KapiPanel3') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: kapiGen / 2, y: kapiH / 2 + 60, text: 'OT-3 Teleskopik', fontSize: 40, anchor: 'center', xdata: xd('KapiTipiLabel') });
  }

  // Hinge positions
  const hingeR = 15;
  const hingePositions = [kapiH * 0.15, kapiH * 0.5, kapiH * 0.85];
  for (const hy of hingePositions) {
    ents.push({ id: eid(), type: 'circle', layer: 'KAPI', color: '#fbbf24', lineWidth: 1.5, cx: -kasaW / 2, cy: hy, r: hingeR, xdata: xd('Mentese') });
    ents.push({ id: eid(), type: 'circle', layer: 'KAPI', color: '#fbbf24', lineWidth: 1.5, cx: kapiGen + kasaW / 2, cy: hy, r: hingeR, xdata: xd('Mentese') });
  }

  // Dimensions
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: 0, y1: -100, x2: kapiGen, y2: -100, dimText: `${kapiGen}`, dimDir: 'h', dimOffset: 0, xdata: xd('DimKapiGen') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: kapiGen + kasaW + 80, y1: 0, x2: kapiGen + kasaW + 80, y2: kapiH, dimText: `${kapiH}`, dimDir: 'v', dimOffset: 0, xdata: xd('DimKapiH') });
  ents.push({ id: eid(), type: 'dimension', layer: 'DIM', color: C.dim, lineWidth: 0.8, x1: -kasaW, y1: -180, x2: kapiGen + kasaW, y2: -180, dimText: `${kapiGen + 2 * kasaW}`, dimDir: 'h', dimOffset: 0, xdata: xd('DimKasaGen') });

  // Title
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: kapiGen / 2, y: kasaH + 150, text: 'KAPI DETAYI', fontSize: 80, anchor: 'center', xdata: xd('Title') });

  return ents;
}


// ═══════════════════════════════════════════════════════════════════════════════
// ASKI DİYAGRAM — Suspension/Rope Diagram
// ═══════════════════════════════════════════════════════════════════════════════

function generateAskiDiyagram(p: ElevatorParams): CadEntity[] {
  const ents: CadEntity[] = [];
  const xd = (bn: string): XData => ({ blockName: bn, liftNumber: 1, sectionCode: 'AD' });
  const totalH = 3000;
  const machineY = totalH - 400;
  const cabinY = totalH * 0.4;
  const cwY = totalH * 0.55;
  const sheaveR = 80;
  const cabinW = 300, cabinH = 400;
  const cwW = 150, cwH = 300;

  if (p.tahrikKodu === 'DA') {
    // Direct suspension: Machine at top, cabin and CW hanging
    // Machine
    ents.push({ id: eid(), type: 'rect', layer: 'MAKINE', color: C.machine, lineWidth: 2, x: 200, y: machineY, w: 300, h: 200, xdata: xd('Makine') });
    ents.push({ id: eid(), type: 'circle', layer: 'KASNAK', color: C.sheave, lineWidth: 2, cx: 350, cy: machineY + 100, r: sheaveR, xdata: xd('TahrikKasnak') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: 350, y: machineY + 250, text: 'TAHRİK', fontSize: 40, anchor: 'center', xdata: xd('MakineLabel') });

    // Deflection sheave
    ents.push({ id: eid(), type: 'circle', layer: 'KASNAK', color: C.sheave, lineWidth: 1.5, cx: 700, cy: machineY + 100, r: sheaveR * 0.7, xdata: xd('SapKasnak') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: 700, y: machineY + 100 + sheaveR + 30, text: 'SAP.', fontSize: 30, anchor: 'center', xdata: xd('SapLabel') });

    // Cabin
    ents.push({ id: eid(), type: 'rect', layer: 'KABIN', color: C.cabin, lineWidth: 2, x: 200, y: cabinY, w: cabinW, h: cabinH, xdata: xd('Kabin') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: 200 + cabinW / 2, y: cabinY + cabinH / 2, text: 'KABİN', fontSize: 40, anchor: 'center', xdata: xd('KabinLabel') });

    // Counterweight
    ents.push({ id: eid(), type: 'rect', layer: 'AGIRLIK', color: C.cw, lineWidth: 2, x: 625, y: cwY, w: cwW, h: cwH, xdata: xd('Agirlik') });
    ents.push({ id: eid(), type: 'hatch', layer: 'AGIRLIK', color: C.cw, lineWidth: 0.5, x: 625, y: cwY, w: cwW, h: cwH, hatchAngle: -45, hatchSpacing: 25, xdata: xd('AgirlikHatch') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: 700, y: cwY + cwH / 2, text: 'AĞR.', fontSize: 35, anchor: 'center', xdata: xd('AgrLabel') });

    // Ropes
    ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: C.rope, lineWidth: 1.5, x1: 350, y1: machineY + 100, x2: 350, y2: cabinY + cabinH, xdata: xd('Halat1') });
    ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: C.rope, lineWidth: 1.5, x1: 350, y1: machineY + 100, x2: 700, y2: machineY + 100, xdata: xd('Halat2') });
    ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: C.rope, lineWidth: 1.5, x1: 700, y1: machineY + 100, x2: 700, y2: cwY + cwH, xdata: xd('Halat3') });

    // Rails
    ents.push({ id: eid(), type: 'line', layer: 'RAY', color: C.rail, lineWidth: 1.5, x1: 180, y1: 0, x2: 180, y2: totalH, xdata: xd('KabinRay') });
    ents.push({ id: eid(), type: 'line', layer: 'RAY', color: C.rail, lineWidth: 1.5, x1: 520, y1: 0, x2: 520, y2: totalH, xdata: xd('KabinRay') });
    ents.push({ id: eid(), type: 'line', layer: 'RAY', color: C.cwRail, lineWidth: 1, x1: 610, y1: 0, x2: 610, y2: totalH, xdata: xd('AgrRay') });
    ents.push({ id: eid(), type: 'line', layer: 'RAY', color: C.cwRail, lineWidth: 1, x1: 790, y1: 0, x2: 790, y2: totalH, xdata: xd('AgrRay') });

    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: 450, y: totalH + 150, text: 'DİREKT ASKI (DA)', fontSize: 70, anchor: 'center', xdata: xd('Title') });

  } else if (p.tahrikKodu === 'MDDUZ') {
    // Machine-roomless straight
    // Cabin sheave on top of cabin
    ents.push({ id: eid(), type: 'rect', layer: 'KABIN', color: C.cabin, lineWidth: 2, x: 200, y: cabinY, w: cabinW, h: cabinH, xdata: xd('Kabin') });
    ents.push({ id: eid(), type: 'circle', layer: 'KASNAK', color: C.sheave, lineWidth: 2, cx: 350, cy: cabinY + cabinH + sheaveR + 20, r: sheaveR, xdata: xd('KabinKasnak') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: 350, y: cabinY + cabinH / 2, text: 'KABİN', fontSize: 40, anchor: 'center', xdata: xd('KabinLabel') });

    // CW sheave
    ents.push({ id: eid(), type: 'rect', layer: 'AGIRLIK', color: C.cw, lineWidth: 2, x: 625, y: cwY, w: cwW, h: cwH, xdata: xd('Agirlik') });
    ents.push({ id: eid(), type: 'circle', layer: 'KASNAK', color: C.sheave, lineWidth: 1.5, cx: 700, cy: cwY + cwH + sheaveR + 20, r: sheaveR * 0.7, xdata: xd('AgrKasnak') });

    // Machine at top of shaft (no machine room)
    ents.push({ id: eid(), type: 'rect', layer: 'MAKINE', color: C.machine, lineWidth: 2, x: 100, y: machineY, w: 200, h: 150, xdata: xd('Makine') });
    ents.push({ id: eid(), type: 'circle', layer: 'KASNAK', color: C.machine, lineWidth: 2, cx: 200, cy: machineY + 75, r: 50, xdata: xd('TahrikKasnak') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: 200, y: machineY + 200, text: 'MD-DÜZ', fontSize: 35, anchor: 'center', xdata: xd('MakineLabel') });

    // Ropes: machine -> cabin sheave -> up -> CW sheave -> CW
    ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: C.rope, lineWidth: 1.5, x1: 200, y1: machineY + 75, x2: 350, y2: cabinY + cabinH + sheaveR + 20, xdata: xd('Halat1') });
    ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: C.rope, lineWidth: 1.5, x1: 350, y1: cabinY + cabinH + sheaveR + 20, x2: 700, y2: machineY, xdata: xd('Halat2') });
    ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: C.rope, lineWidth: 1.5, x1: 700, y1: machineY, x2: 700, y2: cwY + cwH + sheaveR + 20, xdata: xd('Halat3') });

    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: 450, y: totalH + 150, text: 'MAKİNE DAİRESİZ DÜZ (MDDUZ)', fontSize: 70, anchor: 'center', xdata: xd('Title') });

  } else {
    // MDCAP or other: diagonal
    ents.push({ id: eid(), type: 'rect', layer: 'KABIN', color: C.cabin, lineWidth: 2, x: 100, y: cabinY, w: cabinW, h: cabinH, xdata: xd('Kabin') });
    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: 100 + cabinW / 2, y: cabinY + cabinH / 2, text: 'KABİN', fontSize: 40, anchor: 'center', xdata: xd('KabinLabel') });

    ents.push({ id: eid(), type: 'rect', layer: 'AGIRLIK', color: C.cw, lineWidth: 2, x: 700, y: cwY, w: cwW, h: cwH, xdata: xd('Agirlik') });
    ents.push({ id: eid(), type: 'hatch', layer: 'AGIRLIK', color: C.cw, lineWidth: 0.5, x: 700, y: cwY, w: cwW, h: cwH, hatchAngle: -45, hatchSpacing: 25, xdata: xd('AgirlikHatch') });

    // Machine
    ents.push({ id: eid(), type: 'rect', layer: 'MAKINE', color: C.machine, lineWidth: 2, x: 350, y: machineY, w: 200, h: 150, xdata: xd('Makine') });
    ents.push({ id: eid(), type: 'circle', layer: 'KASNAK', color: C.machine, lineWidth: 2, cx: 450, cy: machineY + 75, r: 50, xdata: xd('TahrikKasnak') });

    // Diagonal rope
    ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: C.rope, lineWidth: 1.5, x1: 450, y1: machineY + 75, x2: 250, y2: cabinY + cabinH, xdata: xd('Halat1') });
    ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: '#e879f9', lineWidth: 1.5, dash: [20, 10], x1: 250, y1: cabinY + cabinH, x2: 775, y2: cwY + cwH, xdata: xd('HalatCapraz') });
    ents.push({ id: eid(), type: 'line', layer: 'HALAT', color: C.rope, lineWidth: 1.5, x1: 450, y1: machineY + 75, x2: 775, y2: cwY + cwH, xdata: xd('Halat2') });

    ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: C.label, lineWidth: 1, x: 450, y: totalH + 150, text: `ASKI DİYAGRAMI (${p.tahrikKodu})`, fontSize: 70, anchor: 'center', xdata: xd('Title') });
  }

  // Rope info
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#a3e635', lineWidth: 1, x: 50, y: -80, text: `Halat: ${p.halatSayisi} × Ø${p.halatCapi} mm`, fontSize: 35, anchor: 'left', xdata: xd('HalatInfo') });
  ents.push({ id: eid(), type: 'text', layer: 'LABEL', color: '#94a3b8', lineWidth: 1, x: 50, y: -140, text: `Tahrik Kasnağı: Ø${p.tahrikKas} mm | Saptırma: Ø${p.sapKas} mm`, fontSize: 30, anchor: 'left', xdata: xd('KasnakInfo') });

  return ents;
}


interface ViewState { panX: number; panY: number; zoom: number }

function worldToScreen(wx: number, wy: number, v: ViewState, canvasH: number): Point {
  return { x: wx * v.zoom + v.panX, y: canvasH - (wy * v.zoom + v.panY) };
}

function screenToWorld(sx: number, sy: number, v: ViewState, canvasH: number): Point {
  return { x: (sx - v.panX) / v.zoom, y: (canvasH - sy - v.panY) / v.zoom };
}

function renderGrid(ctx: CanvasRenderingContext2D, v: ViewState, w: number, h: number) {
  let baseSpacing = 100;
  const screenSpacing = baseSpacing * v.zoom;
  if (screenSpacing < 10) baseSpacing *= 10;
  else if (screenSpacing < 20) baseSpacing *= 5;
  else if (screenSpacing > 200) baseSpacing /= 5;
  else if (screenSpacing > 400) baseSpacing /= 10;
  const majorEvery = 5;
  const tl = screenToWorld(0, h, v, h);
  const br = screenToWorld(w, 0, v, h);
  const startX = Math.floor(tl.x / baseSpacing) * baseSpacing;
  const endX = Math.ceil(br.x / baseSpacing) * baseSpacing;
  const startY = Math.floor(tl.y / baseSpacing) * baseSpacing;
  const endY = Math.ceil(br.y / baseSpacing) * baseSpacing;
  for (let x = startX; x <= endX; x += baseSpacing) {
    const sx = worldToScreen(x, 0, v, h).x;
    const isMajor = Math.round(x / baseSpacing) % majorEvery === 0;
    ctx.strokeStyle = isMajor ? C.gridMajor : C.grid;
    ctx.lineWidth = isMajor ? 0.8 : 0.3;
    ctx.beginPath(); ctx.moveTo(sx, 0); ctx.lineTo(sx, h); ctx.stroke();
  }
  for (let y = startY; y <= endY; y += baseSpacing) {
    const sy = worldToScreen(0, y, v, h).y;
    const isMajor = Math.round(y / baseSpacing) % majorEvery === 0;
    ctx.strokeStyle = isMajor ? C.gridMajor : C.grid;
    ctx.lineWidth = isMajor ? 0.8 : 0.3;
    ctx.beginPath(); ctx.moveTo(0, sy); ctx.lineTo(w, sy); ctx.stroke();
  }
}

function renderCrosshair(ctx: CanvasRenderingContext2D, mx: number, my: number, w: number, h: number) {
  ctx.strokeStyle = THEME.crosshair; ctx.lineWidth = 0.5;
  ctx.setLineDash([8, 4]);
  ctx.beginPath();
  ctx.moveTo(mx, 0); ctx.lineTo(mx, h);
  ctx.moveTo(0, my); ctx.lineTo(w, my);
  ctx.stroke(); ctx.setLineDash([]);
}

function renderHatch(ctx: CanvasRenderingContext2D, x: number, y: number, w: number, h: number, angle: number, spacing: number, v: ViewState, canvasH: number) {
  const tl = worldToScreen(x, y + h, v, canvasH);
  const br = worldToScreen(x + w, y, v, canvasH);
  const sw = br.x - tl.x, sh = br.y - tl.y;
  if (sw < 2 || sh < 2) return;
  ctx.save();
  ctx.beginPath(); ctx.rect(tl.x, tl.y, sw, sh); ctx.clip();
  const rad = (angle * Math.PI) / 180;
  const screenSpacing = Math.max(spacing * v.zoom, 6);
  const diag = Math.sqrt(sw * sw + sh * sh);
  const cx = tl.x + sw / 2, cy = tl.y + sh / 2;
  const count = Math.ceil(diag / screenSpacing) * 2;
  ctx.beginPath();
  for (let i = -count; i <= count; i++) {
    const offset = i * screenSpacing;
    const cos = Math.cos(rad), sin = Math.sin(rad);
    const px = cx + offset * cos, py = cy + offset * sin;
    ctx.moveTo(px - diag * sin, py + diag * cos);
    ctx.lineTo(px + diag * sin, py - diag * cos);
  }
  ctx.stroke(); ctx.restore();
}

function renderEntity(ctx: CanvasRenderingContext2D, e: CadEntity, v: ViewState, canvasH: number, hoveredDimId?: string | null) {
  const isDimHovered = e.type === 'dimension' && e.id === hoveredDimId;
  ctx.strokeStyle = isDimHovered ? '#fbbf24' : (e.selected ? C.selected : e.color);
  ctx.fillStyle = isDimHovered ? '#fbbf24' : (e.selected ? C.selected : e.color);
  ctx.lineWidth = Math.max((e.selected ? e.lineWidth + 2 : e.lineWidth) * Math.min(v.zoom * 0.8, 3), 1);
  if (isDimHovered) ctx.lineWidth = ctx.lineWidth * 2;
  if (e.dash) ctx.setLineDash(e.dash.map(d => d * v.zoom));
  else ctx.setLineDash([]);

  switch (e.type) {
    case 'line': {
      const p1 = worldToScreen(e.x1!, e.y1!, v, canvasH);
      const p2 = worldToScreen(e.x2!, e.y2!, v, canvasH);
      ctx.beginPath(); ctx.moveTo(p1.x, p1.y); ctx.lineTo(p2.x, p2.y); ctx.stroke();
      break;
    }
    case 'rect': {
      const tl = worldToScreen(e.x!, e.y! + e.h!, v, canvasH);
      const sw = e.w! * v.zoom, sh = e.h! * v.zoom;
      ctx.strokeRect(tl.x, tl.y, sw, sh);
      if (e.fill) { ctx.fillStyle = e.fill; ctx.fillRect(tl.x, tl.y, sw, sh); }
      break;
    }
    case 'circle': {
      const c = worldToScreen(e.cx!, e.cy!, v, canvasH);
      const sr = e.r! * v.zoom;
      ctx.beginPath(); ctx.arc(c.x, c.y, sr, 0, Math.PI * 2); ctx.stroke();
      ctx.beginPath();
      ctx.moveTo(c.x - 5, c.y); ctx.lineTo(c.x + 5, c.y);
      ctx.moveTo(c.x, c.y - 5); ctx.lineTo(c.x, c.y + 5);
      ctx.stroke();
      break;
    }
    case 'text': {
      const p = worldToScreen(e.x!, e.y!, v, canvasH);
      const fs = Math.max((e.fontSize || 40) * v.zoom, 10);
      if (fs < 6) break;
      ctx.save();
      ctx.font = `600 ${fs}px 'Segoe UI', sans-serif`;
      ctx.textAlign = (e.anchor || 'left') as CanvasTextAlign;
      ctx.textBaseline = 'middle';
      if (e.rotation) {
        ctx.translate(p.x, p.y);
        ctx.rotate((e.rotation * Math.PI) / 180);
        ctx.fillText(e.text || '', 0, 0);
      } else {
        ctx.fillText(e.text || '', p.x, p.y);
      }
      ctx.restore();
      break;
    }
    case 'dimension': {
      const p1 = worldToScreen(e.x1!, e.y1!, v, canvasH);
      const p2 = worldToScreen(e.x2!, e.y2!, v, canvasH);
      ctx.beginPath(); ctx.moveTo(p1.x, p1.y); ctx.lineTo(p2.x, p2.y); ctx.stroke();
      const arrowLen = 12;
      const dx = p2.x - p1.x, dy = p2.y - p1.y;
      const len = Math.sqrt(dx * dx + dy * dy);
      if (len < 5) break;
      const ux = dx / len, uy = dy / len;
      ctx.beginPath();
      ctx.moveTo(p1.x, p1.y); ctx.lineTo(p1.x + arrowLen * ux - arrowLen * 0.3 * uy, p1.y + arrowLen * uy + arrowLen * 0.3 * ux);
      ctx.moveTo(p1.x, p1.y); ctx.lineTo(p1.x + arrowLen * ux + arrowLen * 0.3 * uy, p1.y + arrowLen * uy - arrowLen * 0.3 * ux);
      ctx.stroke();
      ctx.beginPath();
      ctx.moveTo(p2.x, p2.y); ctx.lineTo(p2.x - arrowLen * ux - arrowLen * 0.3 * uy, p2.y - arrowLen * uy + arrowLen * 0.3 * ux);
      ctx.moveTo(p2.x, p2.y); ctx.lineTo(p2.x - arrowLen * ux + arrowLen * 0.3 * uy, p2.y - arrowLen * uy - arrowLen * 0.3 * ux);
      ctx.stroke();
      if (e.dimDir === 'h') {
        const ext = 20;
        ctx.beginPath();
        ctx.moveTo(p1.x, p1.y - ext); ctx.lineTo(p1.x, p1.y + ext);
        ctx.moveTo(p2.x, p2.y - ext); ctx.lineTo(p2.x, p2.y + ext);
        ctx.stroke();
      } else {
        const ext = 20;
        ctx.beginPath();
        ctx.moveTo(p1.x - ext, p1.y); ctx.lineTo(p1.x + ext, p1.y);
        ctx.moveTo(p2.x - ext, p2.y); ctx.lineTo(p2.x + ext, p2.y);
        ctx.stroke();
      }
      const mx = (p1.x + p2.x) / 2, my = (p1.y + p2.y) / 2;
      const fs = Math.max(12, Math.min(18, 40 * v.zoom));
      ctx.font = `bold ${fs}px 'Segoe UI', sans-serif`;
      ctx.textAlign = 'center'; ctx.textBaseline = 'bottom'; ctx.fillStyle = e.selected ? C.selected : C.dim;
      if (e.dimDir === 'v') {
        ctx.save(); ctx.translate(mx - 10, my); ctx.rotate(-Math.PI / 2);
        ctx.fillText(e.dimText || '', 0, 0); ctx.restore();
      } else {
        ctx.fillText(e.dimText || '', mx, my - 4);
      }
      break;
    }
    case 'hatch': {
      renderHatch(ctx, e.x!, e.y!, e.w!, e.h!, e.hatchAngle || 45, e.hatchSpacing || 50, v, canvasH);
      break;
    }
    case 'polyline': {
      if (!e.points || e.points.length < 2) break;
      ctx.beginPath();
      const fp = worldToScreen(e.points[0].x, e.points[0].y, v, canvasH);
      ctx.moveTo(fp.x, fp.y);
      for (let i = 1; i < e.points.length; i++) {
        const pp = worldToScreen(e.points[i].x, e.points[i].y, v, canvasH);
        ctx.lineTo(pp.x, pp.y);
      }
      ctx.stroke();
      break;
    }
  }
  ctx.setLineDash([]);
}

// Feature 3: Filter by layer visibility
function renderAll(ctx: CanvasRenderingContext2D, entities: CadEntity[], v: ViewState, w: number, h: number, showGrid: boolean, layers: LayerDef[], hoveredDimId?: string | null) {
  ctx.clearRect(0, 0, w, h);
  ctx.fillStyle = C.bg; ctx.fillRect(0, 0, w, h);
  if (showGrid) renderGrid(ctx, v, w, h);
  const hiddenLayers = new Set(layers.filter(l => !l.visible).map(l => l.name));
  for (const e of entities) {
    if (hiddenLayers.has(e.layer)) continue;
    renderEntity(ctx, e, v, h, hoveredDimId);
  }
}

// ═══════════════════════════════════════════════════════════════════════════════
// Feature 7: Entity Hit Testing
// ═══════════════════════════════════════════════════════════════════════════════

function hitTestEntity(e: CadEntity, wx: number, wy: number, tolerance: number): boolean {
  const t = tolerance;
  if (e.type === 'rect' && e.x !== undefined) {
    return wx >= e.x! - t && wx <= e.x! + e.w! + t && wy >= e.y! - t && wy <= e.y! + e.h! + t &&
      (wx <= e.x! + t || wx >= e.x! + e.w! - t || wy <= e.y! + t || wy >= e.y! + e.h! - t);
  }
  if (e.type === 'line' || e.type === 'dimension') {
    const dx = e.x2! - e.x1!, dy = e.y2! - e.y1!;
    const len = Math.sqrt(dx * dx + dy * dy);
    if (len < 1) return false;
    const dist = Math.abs(dx * (e.y1! - wy) - (e.x1! - wx) * dy) / len;
    if (dist > t) return false;
    const dot = ((wx - e.x1!) * dx + (wy - e.y1!) * dy) / (len * len);
    return dot >= -0.1 && dot <= 1.1;
  }
  if (e.type === 'circle') {
    const dist = Math.sqrt((wx - e.cx!) ** 2 + (wy - e.cy!) ** 2);
    return Math.abs(dist - e.r!) < t;
  }
  if (e.type === 'text') {
    const fs = e.fontSize || 40;
    const tw = (e.text?.length || 1) * fs * 0.5;
    let tx = e.x!;
    if (e.anchor === 'center') tx -= tw / 2;
    else if (e.anchor === 'right') tx -= tw;
    return wx >= tx - t && wx <= tx + tw + t && wy >= e.y! - fs / 2 - t && wy <= e.y! + fs / 2 + t;
  }
  return false;
}

// ─── Entity Bounding Box (for window/crossing selection) ─────────────────────
function getEntityBounds(e: CadEntity): { minX: number; minY: number; maxX: number; maxY: number } | null {
  if (e.type === 'rect' && e.x !== undefined) {
    return { minX: e.x!, minY: e.y!, maxX: e.x! + e.w!, maxY: e.y! + e.h! };
  }
  if (e.type === 'line' || e.type === 'dimension') {
    return { minX: Math.min(e.x1!, e.x2!), minY: Math.min(e.y1!, e.y2!), maxX: Math.max(e.x1!, e.x2!), maxY: Math.max(e.y1!, e.y2!) };
  }
  if (e.type === 'circle') {
    return { minX: e.cx! - e.r!, minY: e.cy! - e.r!, maxX: e.cx! + e.r!, maxY: e.cy! + e.r! };
  }
  if (e.type === 'text') {
    const fs = e.fontSize || 40;
    const tw = (e.text?.length || 1) * fs * 0.5;
    let tx = e.x!;
    if (e.anchor === 'center') tx -= tw / 2;
    else if (e.anchor === 'right') tx -= tw;
    return { minX: tx, minY: e.y! - fs / 2, maxX: tx + tw, maxY: e.y! + fs / 2 };
  }
  return null;
}


// ═══════════════════════════════════════════════════════════════════════════════
// DXF / SVG EXPORT
// ═══════════════════════════════════════════════════════════════════════════════

function exportDXF(entities: CadEntity[]): string {
  let dxf = '0\nSECTION\n2\nHEADER\n0\nENDSEC\n';
  dxf += '0\nSECTION\n2\nENTITIES\n';
  for (const e of entities) {
    if (e.type === 'line' || e.type === 'dimension') {
      dxf += `0\nLINE\n8\n${e.layer}\n10\n${e.x1}\n20\n${e.y1}\n30\n0\n11\n${e.x2}\n21\n${e.y2}\n31\n0\n`;
    } else if (e.type === 'rect') {
      dxf += `0\nLWPOLYLINE\n8\n${e.layer}\n90\n4\n70\n1\n`;
      dxf += `10\n${e.x}\n20\n${e.y}\n10\n${e.x! + e.w!}\n20\n${e.y}\n10\n${e.x! + e.w!}\n20\n${e.y! + e.h!}\n10\n${e.x}\n20\n${e.y! + e.h!}\n`;
    } else if (e.type === 'circle') {
      dxf += `0\nCIRCLE\n8\n${e.layer}\n10\n${e.cx}\n20\n${e.cy}\n30\n0\n40\n${e.r}\n`;
    } else if (e.type === 'text') {
      dxf += `0\nTEXT\n8\n${e.layer}\n10\n${e.x}\n20\n${e.y}\n30\n0\n40\n${e.fontSize || 40}\n1\n${e.text}\n`;
    }
  }
  dxf += '0\nENDSEC\n0\nEOF\n';
  return dxf;
}

function exportSVG(entities: CadEntity[], width: number, height: number): string {
  let svg = `<svg xmlns="http://www.w3.org/2000/svg" viewBox="-400 -400 ${width + 800} ${height + 800}" width="${width + 800}" height="${height + 800}" style="background:#0f172a">\n`;
  svg += `<g transform="translate(0,${height}) scale(1,-1)">\n`;
  for (const e of entities) {
    const stroke = e.color, sw = e.lineWidth;
    if (e.type === 'line' || e.type === 'dimension') {
      svg += `<line x1="${e.x1}" y1="${e.y1}" x2="${e.x2}" y2="${e.y2}" stroke="${stroke}" stroke-width="${sw}" />\n`;
    } else if (e.type === 'rect') {
      svg += `<rect x="${e.x}" y="${e.y}" width="${e.w}" height="${e.h}" stroke="${stroke}" stroke-width="${sw}" fill="none" />\n`;
    } else if (e.type === 'circle') {
      svg += `<circle cx="${e.cx}" cy="${e.cy}" r="${e.r}" stroke="${stroke}" stroke-width="${sw}" fill="none" />\n`;
    } else if (e.type === 'text') {
      svg += `<text x="${e.x}" y="${e.y}" fill="${stroke}" font-size="${e.fontSize || 40}" text-anchor="${e.anchor || 'start'}" transform="scale(1,-1) translate(0,${-(e.y || 0) * 2})">${e.text}</text>\n`;
    }
  }
  svg += '</g>\n</svg>';
  return svg;
}

function downloadFile(content: string, filename: string, mime: string) {
  const blob = new Blob([content], { type: mime });
  const url = URL.createObjectURL(blob);
  const a = document.createElement('a');
  a.href = url; a.download = filename; a.click();
  URL.revokeObjectURL(url);
}


// ═══════════════════════════════════════════════════════════════════════════════
// PARAMETER DIALOG — Enhanced with all new fields
// ═══════════════════════════════════════════════════════════════════════════════

const inputStyle: React.CSSProperties = {
  background: '#1e293b', color: '#e2e8f0', border: '1px solid #334155',
  borderRadius: 4, padding: '6px 8px', fontSize: 13, width: '100%',
};
const selectStyle: React.CSSProperties = { ...inputStyle };
const labelStyle: React.CSSProperties = { color: '#94a3b8', fontSize: 12, marginBottom: 2, display: 'block' };
const fieldStyle: React.CSSProperties = { marginBottom: 8 };

function ParameterDialog({ params, onApply, onClose }: {
  params: ElevatorParams;
  onApply: (p: ElevatorParams) => void;
  onClose: () => void;
}) {
  const [p, setP] = useState<ElevatorParams>({ ...params, katlar: params.katlar.map(k => ({ ...k })), firma: { ...params.firma } });
  const [tab, setTab] = useState(0);

  const set = (key: keyof ElevatorParams, val: any) => setP(prev => ({ ...prev, [key]: val }));
  const setNum = (key: keyof ElevatorParams, val: string) => set(key, parseInt(val) || 0);
  const setFloat = (key: keyof ElevatorParams, val: string) => set(key, parseFloat(val) || 0);
  const setFirma = (key: keyof FirmaBilgi, val: string) => setP(prev => ({ ...prev, firma: { ...prev.firma, [key]: val } }));

  const tabNames = ['Kuyu & Kabin', 'Kat Bilgileri', 'Kapı & Bileşenler', 'Ağırlık & Kasnak', 'Makine & Halat', 'Hesaplama', 'Firma & Ölçek'];

  const handleApply = () => {
    let kot = p.katlar.length > 0 ? p.katlar[0].mimariKot : 0;
    const newKatlar = p.katlar.map((k, i) => {
      if (i === 0) return k;
      kot += p.katlar[i - 1].yukseklik / 1000;
      return { ...k, mimariKot: parseFloat(kot.toFixed(2)) };
    });
    onApply({ ...p, katlar: newKatlar });
  };

  const addKat = () => {
    const last = p.katlar[p.katlar.length - 1];
    setP(prev => ({
      ...prev,
      katlar: [...prev.katlar, { katNo: last.katNo + 1, rumuz: `${last.katNo + 1}`, yukseklik: 3000, mimariKot: last.mimariKot + last.yukseklik / 1000 }],
    }));
  };

  const removeKat = (i: number) => {
    if (p.katlar.length <= 2) return;
    setP(prev => ({ ...prev, katlar: prev.katlar.filter((_, idx) => idx !== i) }));
  };

  const updateKat = (i: number, key: keyof KatBilgi, val: any) => {
    setP(prev => {
      const katlar = [...prev.katlar];
      katlar[i] = { ...katlar[i], [key]: val };
      return { ...prev, katlar };
    });
  };

  const overlayStyle: React.CSSProperties = { position: 'fixed', inset: 0, background: 'rgba(0,0,0,0.7)', display: 'flex', alignItems: 'center', justifyContent: 'center', zIndex: 1000 };
  const dialogStyle: React.CSSProperties = { background: '#0f172a', border: '1px solid #334155', borderRadius: 12, width: 720, maxHeight: '85vh', overflow: 'auto', padding: 0, boxShadow: '0 25px 50px rgba(0,0,0,0.5)' };
  const headerStyle: React.CSSProperties = { padding: '16px 20px', borderBottom: '1px solid #334155', display: 'flex', justifyContent: 'space-between', alignItems: 'center' };
  const tabBarStyle: React.CSSProperties = { display: 'flex', borderBottom: '1px solid #334155', padding: '0 20px' };
  const tabBtnStyle = (active: boolean): React.CSSProperties => ({ padding: '10px 14px', background: 'none', border: 'none', color: active ? '#60a5fa' : '#94a3b8', borderBottom: active ? '2px solid #60a5fa' : '2px solid transparent', cursor: 'pointer', fontSize: 13, fontWeight: active ? 600 : 400 });
  const bodyStyle: React.CSSProperties = { padding: 20 };
  const gridStyle: React.CSSProperties = { display: 'grid', gridTemplateColumns: '1fr 1fr', gap: 12 };
  const btnStyle: React.CSSProperties = { padding: '8px 20px', borderRadius: 6, border: 'none', cursor: 'pointer', fontWeight: 600, fontSize: 13 };

  return (
    <div style={overlayStyle} onClick={onClose}>
      <div style={dialogStyle} onClick={e => e.stopPropagation()}>
        <div style={headerStyle}>
          <span style={{ color: '#f1f5f9', fontSize: 16, fontWeight: 700 }}>⚙️ Asansör Parametreleri</span>
          <button onClick={onClose} style={{ ...btnStyle, background: '#334155', color: '#94a3b8' }}>✕</button>
        </div>
        <div style={tabBarStyle}>
          {tabNames.map((t, i) => (
            <button key={i} style={tabBtnStyle(tab === i)} onClick={() => setTab(i)}>{t}</button>
          ))}
        </div>
        <div style={bodyStyle}>
          {tab === 0 && (
            <div style={gridStyle}>
              <div style={fieldStyle}>
                <label style={labelStyle}>Asansör Tipi</label>
                <select style={selectStyle} value={p.asansorTipi} onChange={e => set('asansorTipi', e.target.value)}>
                  <option value="EA">EA - Elektrikli Asansör</option>
                  <option value="HA">HA - Hidrolik Asansör</option>
                </select>
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>Tahrik Tipi</label>
                <select style={selectStyle} value={p.tahrikKodu} onChange={e => set('tahrikKodu', e.target.value)}>
                  <option value="DA">DA - Direkt Askı</option>
                  <option value="MDDUZ">MDDUZ - Makine Dairesiz Düz</option>
                  <option value="MDCAP">MDCAP - Makine Dairesiz Çapraz</option>
                  <option value="YA">YA - Yarı Askı</option>
                  <option value="SD">SD - Saptırma</option>
                </select>
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>Tahrik Yönü</label>
                <select style={selectStyle} value={p.yonKodu} onChange={e => set('yonKodu', e.target.value)}>
                  <option value="SOL">SOL</option>
                  <option value="SAG">SAĞ</option>
                  <option value="ARKA">ARKA</option>
                </select>
              </div>
              {/* Feature 1: Multi-Elevator */}
              <div style={fieldStyle}>
                <label style={labelStyle}>Asansör Sayısı</label>
                <select style={selectStyle} value={p.asansorSayisi} onChange={e => setNum('asansorSayisi', e.target.value)}>
                  <option value={1}>1 Asansör</option>
                  <option value={2}>2 Asansör (Yan Yana)</option>
                </select>
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>Ara Bölme Kalınlığı (mm)</label>
                <input style={inputStyle} type="number" value={p.araBolme} onChange={e => setNum('araBolme', e.target.value)} />
              </div>
              {/* Feature 4: Panoramic */}
              <div style={fieldStyle}>
                <label style={labelStyle}>Panoramik Asansör</label>
                <label style={{ display: 'flex', alignItems: 'center', gap: 8, color: '#e2e8f0', cursor: 'pointer' }}>
                  <input type="checkbox" checked={p.panoramik} onChange={e => set('panoramik', e.target.checked)} />
                  Panoramik (Cam Arka Duvar)
                </label>
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>Kuyu Genişliği (mm)</label>
                <input style={inputStyle} type="number" value={p.kuyuGen} onChange={e => setNum('kuyuGen', e.target.value)} />
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>Kuyu Derinliği (mm)</label>
                <input style={inputStyle} type="number" value={p.kuyuDer} onChange={e => setNum('kuyuDer', e.target.value)} />
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>Kuyu Dibi (mm)</label>
                <input style={inputStyle} type="number" value={p.kuyuDibi} onChange={e => setNum('kuyuDibi', e.target.value)} />
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>Kuyu Kafa (mm)</label>
                <input style={inputStyle} type="number" value={p.kuyuKafa} onChange={e => setNum('kuyuKafa', e.target.value)} />
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>Duvar Kalınlığı (mm)</label>
                <input style={inputStyle} type="number" value={p.duvarKal} onChange={e => setNum('duvarKal', e.target.value)} />
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>Kabin Y Eksen (mm)</label>
                <input style={inputStyle} type="number" value={p.kabinYEksen} onChange={e => setNum('kabinYEksen', e.target.value)} />
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>KRX (mm)</label>
                <input style={inputStyle} type="number" value={p.krx} onChange={e => setNum('krx', e.target.value)} />
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>Kabin Duvar Kalınlığı (mm)</label>
                <input style={inputStyle} type="number" value={p.kabinDuvar} onChange={e => setNum('kabinDuvar', e.target.value)} />
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>Kabin Yan Duvar (mm)</label>
                <input style={inputStyle} type="number" value={p.kabinYanDuv} onChange={e => setNum('kabinYanDuv', e.target.value)} />
              </div>
              <div style={fieldStyle}>
                <label style={labelStyle}>Aydınlatma Mesafesi (mm)</label>
                <input style={inputStyle} type="number" value={p.aydinMesafe} onChange={e => setNum('aydinMesafe', e.target.value)} />
              </div>
            </div>
          )}
          {tab === 1 && (
            <div>
              <table style={{ width: '100%', borderCollapse: 'collapse', fontSize: 13 }}>
                <thead>
                  <tr style={{ borderBottom: '1px solid #334155' }}>
                    <th style={{ color: '#94a3b8', padding: 6, textAlign: 'left' }}>Kat No</th>
                    <th style={{ color: '#94a3b8', padding: 6, textAlign: 'left' }}>Rumuz</th>
                    <th style={{ color: '#94a3b8', padding: 6, textAlign: 'left' }}>Yükseklik (mm)</th>
                    <th style={{ color: '#94a3b8', padding: 6, textAlign: 'left' }}>Mimari Kot</th>
                    <th style={{ color: '#94a3b8', padding: 6 }}></th>
                  </tr>
                </thead>
                <tbody>
                  {p.katlar.map((k, i) => (
                    <tr key={i} style={{ borderBottom: '1px solid #1e293b' }}>
                      <td style={{ padding: 4 }}><input style={{ ...inputStyle, width: 60 }} type="number" value={k.katNo} onChange={e => updateKat(i, 'katNo', parseInt(e.target.value) || 0)} /></td>
                      <td style={{ padding: 4 }}><input style={{ ...inputStyle, width: 80 }} value={k.rumuz} onChange={e => updateKat(i, 'rumuz', e.target.value)} /></td>
                      <td style={{ padding: 4 }}><input style={{ ...inputStyle, width: 100 }} type="number" value={k.yukseklik} onChange={e => updateKat(i, 'yukseklik', parseInt(e.target.value) || 0)} /></td>
                      <td style={{ padding: 4, color: '#94a3b8' }}>{k.mimariKot.toFixed(2)}</td>
                      <td style={{ padding: 4 }}><button onClick={() => removeKat(i)} style={{ ...btnStyle, background: '#7f1d1d', color: '#fca5a5', padding: '4px 8px', fontSize: 11 }}>Sil</button></td>
                    </tr>
                  ))}
                </tbody>
              </table>
              <button onClick={addKat} style={{ ...btnStyle, background: '#1e3a5f', color: '#60a5fa', marginTop: 8 }}>+ Kat Ekle</button>
            </div>
          )}
          {tab === 2 && (
            <div style={gridStyle}>
              <div style={{ ...fieldStyle, gridColumn: '1 / -1' }}><label style={{ ...labelStyle, color: '#60a5fa', fontWeight: 600 }}>Kapı Parametreleri</label></div>
              <div style={fieldStyle}><label style={labelStyle}>Kapı Genişliği (mm)</label><input style={inputStyle} type="number" value={p.kapiGen} onChange={e => setNum('kapiGen', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Kapı Yüksekliği (mm)</label><input style={inputStyle} type="number" value={p.kapiH} onChange={e => setNum('kapiH', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Kapı Tipi</label>
                <select style={selectStyle} value={p.kapiTipi} onChange={e => set('kapiTipi', e.target.value)}>
                  <option value="KK-OT">KK-OT (Ortadan Açılır Teleskopik)</option>
                  <option value="KK-KK">KK-KK (Ortadan Açılır)</option>
                  <option value="OT-2">OT-2 (2 Panel Teleskopik)</option>
                  <option value="OT-3">OT-3 (3 Panel Teleskopik)</option>
                </select>
              </div>
              <div style={fieldStyle}><label style={labelStyle}>Eşik Kalınlığı (mm)</label><input style={inputStyle} type="number" value={p.esikKalin} onChange={e => setNum('esikKalin', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Kasa Genişliği (mm)</label><input style={inputStyle} type="number" value={p.kasaGen} onChange={e => setNum('kasaGen', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Kasa Derinliği (mm)</label><input style={inputStyle} type="number" value={p.kasaDer} onChange={e => setNum('kasaDer', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Menteşe Yönü</label>
                <select style={selectStyle} value={p.mentese} onChange={e => set('mentese', e.target.value)}>
                  <option value="SOL">SOL</option><option value="SAG">SAĞ</option>
                </select>
              </div>
              <div style={fieldStyle}><label style={labelStyle}>Kapı Ters (Flip)</label>
                <label style={{ display: 'flex', alignItems: 'center', gap: 8, color: '#e2e8f0', cursor: 'pointer' }}>
                  <input type="checkbox" checked={p.kapiFlip} onChange={e => set('kapiFlip', e.target.checked)} /> Kapı Ters
                </label>
              </div>
              <div style={{ ...fieldStyle, gridColumn: '1 / -1' }}><label style={{ ...labelStyle, color: '#60a5fa', fontWeight: 600 }}>Ray Parametreleri</label></div>
              <div style={fieldStyle}><label style={labelStyle}>Kabin Ray Tipi</label>
                <select style={selectStyle} value={p.kabinRayTipi} onChange={e => set('kabinRayTipi', e.target.value)}>
                  {['T50/A', 'T70/A', 'T70/B', 'T82/B', 'T89/B', 'T127/B'].map(r => <option key={r} value={r}>{r}{RAIL_PROFILES[r] ? ` (${RAIL_PROFILES[r].weight} kg/m)` : ''}</option>)}
                </select>
              </div>
              <div style={fieldStyle}><label style={labelStyle}>Ağırlık Ray Tipi</label>
                <select style={selectStyle} value={p.agrRayTipi} onChange={e => set('agrRayTipi', e.target.value)}>
                  {['T50/A', 'T70/A', 'T70/B', 'T82/B', 'T89/B', 'T127/B'].map(r => <option key={r} value={r}>{r}{RAIL_PROFILES[r] ? ` (${RAIL_PROFILES[r].weight} kg/m)` : ''}</option>)}
                </select>
              </div>
              <div style={fieldStyle}><label style={labelStyle}>Kabin Ray Ucu (mm)</label><input style={inputStyle} type="number" value={p.kabinRayUcu} onChange={e => setNum('kabinRayUcu', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Kızak Kalınlığı (mm)</label><input style={inputStyle} type="number" value={p.kizakKalin} onChange={e => setNum('kizakKalin', e.target.value)} /></div>
              <div style={{ ...fieldStyle, gridColumn: '1 / -1' }}><label style={{ ...labelStyle, color: '#60a5fa', fontWeight: 600 }}>Tampon & Regülatör</label></div>
              <div style={fieldStyle}><label style={labelStyle}>Tampon Tipi</label>
                <select style={selectStyle} value={p.tamponTipi} onChange={e => set('tamponTipi', e.target.value)}>
                  <option value="Yay">Yay Tampon</option>
                  <option value="Hidrolik">Hidrolik Tampon</option>
                  <option value="Poliüretan">Poliüretan Tampon</option>
                </select>
              </div>
              <div style={fieldStyle}><label style={labelStyle}>Regülatör Yeri</label>
                <select style={selectStyle} value={p.regYeri} onChange={e => set('regYeri', parseInt(e.target.value))}>
                  <option value={1}>1 - Sol Üst</option><option value={2}>2 - Sağ Üst</option>
                  <option value={3}>3 - Sağ Alt</option><option value={4}>4 - Sol Alt</option>
                </select>
              </div>
            </div>
          )}
          {tab === 3 && (
            <div style={gridStyle}>
              <div style={fieldStyle}><label style={labelStyle}>Ağırlık Genişliği (mm)</label><input style={inputStyle} type="number" value={p.agrGen} onChange={e => setNum('agrGen', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Ağırlık Duvar Mesafesi (mm)</label><input style={inputStyle} type="number" value={p.agrDuv} onChange={e => setNum('agrDuv', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Ağırlık Üst Boşluk (mm)</label><input style={inputStyle} type="number" value={p.agrU} onChange={e => setNum('agrU', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Ağırlık Uzunluk (mm)</label><input style={inputStyle} type="number" value={p.agrUz} onChange={e => setNum('agrUz', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Tahrik Kasnağı Çapı (mm)</label><input style={inputStyle} type="number" value={p.tahrikKas} onChange={e => setNum('tahrikKas', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Saptırma Kasnağı Çapı (mm)</label><input style={inputStyle} type="number" value={p.sapKas} onChange={e => setNum('sapKas', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Denge Oranı</label><input style={inputStyle} type="number" step="0.05" value={p.dengeOrani} onChange={e => setFloat('dengeOrani', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Denge Zinciri</label>
                <label style={{ display: 'flex', alignItems: 'center', gap: 8, color: '#e2e8f0', cursor: 'pointer' }}>
                  <input type="checkbox" checked={p.dengeZinciri} onChange={e => set('dengeZinciri', e.target.checked)} /> Denge Zinciri Var
                </label>
              </div>
            </div>
          )}
          {tab === 4 && (
            <div style={gridStyle}>
              <div style={fieldStyle}><label style={labelStyle}>Kabin Ağırlığı (kg)</label><input style={inputStyle} type="number" value={p.kabinP} onChange={e => setNum('kabinP', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Hız (m/s)</label><input style={inputStyle} type="number" step="0.1" value={p.hiz} onChange={e => setFloat('hiz', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Halat Çapı (mm)</label><input style={inputStyle} type="number" value={p.halatCapi} onChange={e => setNum('halatCapi', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Halat Sayısı</label><input style={inputStyle} type="number" value={p.halatSayisi} onChange={e => setNum('halatSayisi', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Fren Tipi</label>
                <select style={selectStyle} value={p.frenTipi} onChange={e => set('frenTipi', e.target.value)}>
                  <option value="Disk">Disk Fren</option><option value="Kampana">Kampana Fren</option><option value="Elektromanyetik">Elektromanyetik Fren</option>
                </select>
              </div>
              <div style={fieldStyle}><label style={labelStyle}>Motor Gücü (kW)</label><input style={inputStyle} type="number" step="0.5" value={p.motorGucu} onChange={e => setFloat('motorGucu', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Motor Verimi (%)</label><input style={inputStyle} type="number" value={p.motorVerim} onChange={e => setNum('motorVerim', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Çalışma Yüksekliği (mm)</label><input style={inputStyle} type="number" value={p.calisYuksek} onChange={e => setNum('calisYuksek', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Makine Dairesi Yüksekliği (mm)</label><input style={inputStyle} type="number" value={p.mDaireH} onChange={e => setNum('mDaireH', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>İskele Var</label>
                <label style={{ display: 'flex', alignItems: 'center', gap: 8, color: '#e2e8f0', cursor: 'pointer' }}>
                  <input type="checkbox" checked={p.iskeleVar} onChange={e => set('iskeleVar', e.target.checked)} /> İskele Mevcut
                </label>
              </div>
              <div style={{ ...fieldStyle, gridColumn: '1 / -1' }}><label style={{ ...labelStyle, color: '#60a5fa', fontWeight: 600 }}>Hidrolik Parametreleri</label></div>
              <div style={fieldStyle}><label style={labelStyle}>HA Makine Dairesi Genişliği (mm)</label><input style={inputStyle} type="number" value={p.hamdGen} onChange={e => setNum('hamdGen', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>HA Makine Dairesi Derinliği (mm)</label><input style={inputStyle} type="number" value={p.hamdDer} onChange={e => setNum('hamdDer', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Hidrolik Silindir Genişliği (mm)</label><input style={inputStyle} type="number" value={p.hidrolikGen} onChange={e => setNum('hidrolikGen', e.target.value)} /></div>
            </div>
          )}
          {tab === 5 && (() => {
            const en81 = hesaplaEN81Full(p);
            const { kabinGen: kG, kabinDer: kD } = hesaplaKabinBoyutlari(p);
            const sM = hesaplaSeyirMesafesi(p.katlar);
            const kM = hesaplaKuyuMesafesi(p);
            const indicatorStyle = (ok: boolean): React.CSSProperties => ({ display: 'inline-block', width: 10, height: 10, borderRadius: '50%', background: ok ? '#22c55e' : '#ef4444', marginRight: 6 });
            return (
            <div>
              <div style={gridStyle}>
                <div style={fieldStyle}><label style={labelStyle}>Konsol Mesafesi (mm)</label><input style={inputStyle} type="number" value={p.konsolMesafe} onChange={e => setNum('konsolMesafe', e.target.value)} /></div>
                <div style={fieldStyle}><label style={labelStyle}>Kapı Ağırlığı (kg)</label><input style={inputStyle} type="number" value={p.kapiAgirlik} onChange={e => setNum('kapiAgirlik', e.target.value)} /></div>
                <div style={fieldStyle}><label style={labelStyle}>Bina Kişi Sayısı</label><input style={inputStyle} type="number" value={p.binaKisiSayisi} onChange={e => setNum('binaKisiSayisi', e.target.value)} /></div>
                <div style={fieldStyle}><label style={labelStyle}>Bina Kullanım Tipi</label>
                  <select style={selectStyle} value={p.binaKullanimTipi} onChange={e => setNum('binaKullanimTipi', e.target.value)}>
                    <option value={0}>Konut</option><option value={1}>Ofis</option><option value={2}>Hastane</option><option value={3}>Otel</option>
                  </select>
                </div>
                <div style={{ ...fieldStyle, gridColumn: '1 / -1' }}><label style={{ ...labelStyle, color: '#60a5fa', fontWeight: 600 }}>Ağırlık Merkezi & Askı Noktaları (mm, 0=otomatik)</label></div>
                <div style={fieldStyle}><label style={labelStyle}>Xc (Kabin Ağ. Merkezi X)</label><input style={inputStyle} type="number" value={p.Xc} onChange={e => setNum('Xc', e.target.value)} /></div>
                <div style={fieldStyle}><label style={labelStyle}>Yc (Kabin Ağ. Merkezi Y)</label><input style={inputStyle} type="number" value={p.Yc} onChange={e => setNum('Yc', e.target.value)} /></div>
                <div style={fieldStyle}><label style={labelStyle}>Xs (Askı Noktası X)</label><input style={inputStyle} type="number" value={p.Xs} onChange={e => setNum('Xs', e.target.value)} /></div>
                <div style={fieldStyle}><label style={labelStyle}>Ys (Askı Noktası Y)</label><input style={inputStyle} type="number" value={p.Ys} onChange={e => setNum('Ys', e.target.value)} /></div>
                <div style={fieldStyle}><label style={labelStyle}>Xp (Paten Noktası X)</label><input style={inputStyle} type="number" value={p.Xp} onChange={e => setNum('Xp', e.target.value)} /></div>
                <div style={fieldStyle}><label style={labelStyle}>Yp (Paten Noktası Y)</label><input style={inputStyle} type="number" value={p.Yp} onChange={e => setNum('Yp', e.target.value)} /></div>
              </div>
              <div style={{ marginTop: 16, padding: 12, background: '#1e293b', borderRadius: 8, border: '1px solid #334155' }}>
                <div style={{ color: '#60a5fa', fontWeight: 700, fontSize: 13, marginBottom: 8 }}>📊 Canlı Hesaplama Önizleme</div>
                <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: 6, fontSize: 12, color: '#e2e8f0', marginBottom: 10 }}>
                  <span>Kabin: {kG} x {kD} mm</span>
                  <span>Beyan Yük: {en81.beyanYuk} kg / {en81.kisiSayisi} kişi</span>
                  <span>Seyir Mesafesi: {sM} mm</span>
                  <span>Kuyu Mesafesi: {kM} mm</span>
                  <span>Motor Gücü: {en81.hesaplananMotorGucu.toFixed(2)} kW <span style={{ color: en81.motorUygun ? '#22c55e' : '#ef4444' }}>{en81.motorUygun ? '✓' : '✗'}</span></span>
                  <span>Karşı Ağırlık: {en81.karsiAgirlik.toFixed(0)} kg</span>
                </div>
                <div style={{ color: '#94a3b8', fontWeight: 600, fontSize: 12, marginBottom: 4 }}>EN81-1 Kontrol Sonuçları ({en81.kontrolSonuclari.filter(k => k.uygun).length}/18 uygun)</div>
                <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: 2, fontSize: 11 }}>
                  {en81.kontrolSonuclari.map(k => (
                    <div key={k.no} style={{ color: k.uygun ? '#86efac' : '#fca5a5', padding: '2px 0' }}>
                      <span style={indicatorStyle(k.uygun)}></span>{k.no}. {k.aciklama.length > 35 ? k.aciklama.slice(0, 35) + '…' : k.aciklama}
                    </div>
                  ))}
                </div>
              </div>
              <div style={{ marginTop: 12 }}>
                <button onClick={() => {
                  const report = generateFullReport(p);
                  const { kabinGen: kG2, kabinDer: kD2 } = hesaplaKabinBoyutlari(p);
                  const beyan2 = beyanYukBul(kG2, kD2);
                  const seyir2 = hesaplaSeyirMesafesi(p.katlar);
                  const kuyu2 = hesaplaKuyuMesafesi(p);
                  const pw = window.open('', '_blank', 'width=1000,height=800');
                  if (!pw) return;
                  const ok = (v: boolean) => v ? '<span style="color:#22c55e">✓ Uygun</span>' : '<span style="color:#ef4444">✗ Uygun Değil</span>';
                  pw.document.write(`<!DOCTYPE html><html><head><title>ASNCAD Detaylı Mühendislik Raporu</title>
<style>
body{font-family:Arial,sans-serif;padding:30px;color:#333;max-width:900px;margin:0 auto}
h1{font-size:20px;border-bottom:3px solid #1d4ed8;padding-bottom:8px;color:#1d4ed8}
h2{font-size:15px;color:#1e40af;margin-top:24px;border-bottom:1px solid #ddd;padding-bottom:4px}
h3{font-size:13px;color:#334155;margin-top:16px}
table{width:100%;border-collapse:collapse;margin:8px 0;font-size:12px}
td,th{border:1px solid #ddd;padding:5px 8px;text-align:left}
th{background:#f0f4ff;font-weight:600}
.ok{color:#22c55e;font-weight:bold}.fail{color:#ef4444;font-weight:bold}
.summary{background:#f0f4ff;border:2px solid #1d4ed8;border-radius:8px;padding:16px;margin:16px 0}
.summary h2{border:none;margin:0 0 8px 0}
.footer{margin-top:30px;font-size:10px;color:#999;border-top:1px solid #ccc;padding-top:10px}
@media print{body{padding:15px}h1{font-size:16px}}
</style></head><body>
<h1>📋 ASNCAD — DETAYLI MÜHENDİSLİK RAPORU</h1>
<div class="summary">
<h2>Proje Özeti</h2>
<table>
<tr><th>Firma</th><td>${p.firma.firmaAdi}</td><th>Mühendis</th><td>${p.firma.muhendis}</td></tr>
<tr><th>Asansör Tipi</th><td>${p.asansorTipi} — ${p.tahrikKodu}</td><th>Hız</th><td>${p.hiz} m/s</td></tr>
<tr><th>Kuyu</th><td>${p.kuyuGen} × ${p.kuyuDer} mm</td><th>Kabin</th><td>${kG2} × ${kD2} mm</td></tr>
<tr><th>Beyan Yük</th><td>${beyan2.yuk} kg / ${beyan2.kisi} kişi</td><th>Durak</th><td>${p.katlar.length}</td></tr>
<tr><th>Seyir Mesafesi</th><td>${seyir2} mm</td><th>Kuyu Mesafesi</th><td>${kuyu2} mm</td></tr>
<tr><th>Motor</th><td>${p.motorGucu} kW — ${p.frenTipi}</td><th>Halat</th><td>${p.halatSayisi} × Ø${p.halatCapi}</td></tr>
</table>
<p style="font-size:14px;font-weight:bold;margin-top:12px">
Uygunluk: <span style="color:${report.uygunlukOrani >= 80 ? '#22c55e' : '#ef4444'}">${report.uygunKontrol}/${report.toplamKontrol} (${report.uygunlukOrani.toFixed(1)}%)</span>
</p>
</div>

<h2>1. TS EN 81-20 Hesaplamaları</h2>
<table>
<tr><th>Hesaplanan Motor Gücü</th><td>${report.en81.hesaplananMotorGucu.toFixed(2)} kW</td><td>${ok(report.en81.motorUygun)}</td></tr>
<tr><th>Karşı Ağırlık</th><td>${report.en81.karsiAgirlik.toFixed(0)} kg</td><td>Denge: %${(p.dengeOrani * 100).toFixed(0)}</td></tr>
<tr><th>Beyan Yük</th><td>${report.en81.beyanYuk} kg / ${report.en81.kisiSayisi} kişi</td><td>—</td></tr>
</table>

<h3>EN81-1 Kontrol Sonuçları (${report.en81.kontrolSonuclari.filter(k=>k.uygun).length}/${report.en81.kontrolSonuclari.length})</h3>
<table>
<tr><th>#</th><th>Kontrol</th><th>Sonuç</th></tr>
${report.en81.kontrolSonuclari.map((k,i) => `<tr><td>${i+1}</td><td>${k.aciklama}</td><td class="${k.uygun?'ok':'fail'}">${k.uygun?'✓ Uygun':'✗ Uygun Değil'}</td></tr>`).join('')}
</table>

<h2>2. Halat Hesabı</h2>
<table>
<tr><th>Halat Güvenlik Katsayısı</th><td>${report.halat.halatGuvenlikKatsayisi.toFixed(2)}</td><td>${ok(report.halat.halatGuvenlikKatsayisi >= (p.asansorTipi === 'EA' ? 12 : 8))}</td></tr>
<tr><th>D/d Oranı</th><td>${report.halat.Dd_orani.toFixed(1)}</td><td>${ok(report.halat.Dd_uygun)}</td></tr>
<tr><th>Toplam Statik Yük</th><td>${report.halat.toplam_statik_yuk.toFixed(0)} N</td><td>—</td></tr>
<tr><th>Halat Kopma Kuvveti</th><td>${report.halat.halatKopmaKuvveti.toFixed(0)} N</td><td>—</td></tr>
</table>

<h2>3. Tampon Hesabı</h2>
<table>
<tr><th>Tampon Tipi</th><td>${p.tamponTipi === 'YAG' ? 'Yağlı' : 'Kauçuk/Yay'}</td><td>${ok(report.tampon.uygun)}</td></tr>
<tr><th>Açıklama</th><td colspan="2">${report.tampon.aciklama}</td></tr>
</table>

<h2>4. Trafik Analizi</h2>
<table>
<tr><th>RTT (Round Trip Time)</th><td>${report.trafik.beklemeArasi.toFixed(1)} s</td><td>—</td></tr>
<tr><th>HC% (Handling Capacity)</th><td>${report.trafik.handlingCapacityPct.toFixed(1)}%</td><td>${ok(report.trafik.uygun)}</td></tr>
<tr><th>Açıklama</th><td colspan="2">${report.trafik.aciklama}</td></tr>
</table>

<h2>5. Enerji Sınıfı (VDI 4707)</h2>
<table>
<tr><th>Enerji Sınıfı</th><td style="font-size:18px;font-weight:bold;color:#1d4ed8">${report.enerji.energySinifi}</td><td>—</td></tr>
<tr><th>Yıllık Tüketim</th><td>${report.enerji.yillikEnerji.toFixed(0)} kWh</td><td>—</td></tr>
<tr><th>Açıklama</th><td colspan="2">${report.enerji.aciklama}</td></tr>
</table>

<h2>6. Deprem Hesabı (EN 81-77)</h2>
<table>
<tr><th>Ray Ek Kuvvet</th><td>${report.deprem.rayEkKuvvet.toFixed(0)} N</td><td>${ok(report.deprem.uygun)}</td></tr>
<tr><th>Önlemler</th><td colspan="2">${report.deprem.onlemler.join(', ')}</td></tr>
</table>

${report.hidrolik ? `
<h2>7. Hidrolik Hesap</h2>
<table>
<tr><th>Piston Çapı</th><td>${report.hidrolik.pistonCapi.toFixed(1)} mm</td><td>—</td></tr>
<tr><th>Pompa Debisi</th><td>${report.hidrolik.pompaDegeri.toFixed(1)} l/dk</td><td>—</td></tr>
<tr><th>Hidrolik Güç</th><td>${report.hidrolik.hidrolikGucu.toFixed(2)} kW</td><td>—</td></tr>
<tr><th>Tank Hacmi</th><td>${report.hidrolik.tankHacmi.toFixed(0)} lt</td><td>—</td></tr>
</table>` : ''}

<h2>8. Maliyet Tahmini</h2>
<table>
<tr><th>Kalem</th><th>Birim</th><th>Miktar</th><th>Birim Fiyat</th><th>Toplam (₺)</th></tr>
${report.maliyet.birimFiyatlar.map((k: any) => `<tr><td>${k.kalem}</td><td>${k.birim}</td><td>${k.miktar.toFixed(2)}</td><td>${k.birimFiyat.toLocaleString('tr-TR')}</td><td style="text-align:right">${k.toplam.toLocaleString('tr-TR')}</td></tr>`).join('')}
<tr style="font-weight:bold;background:#f0f4ff"><td colspan="4">TOPLAM</td><td style="text-align:right">${report.maliyet.toplamMaliyet.toLocaleString('tr-TR')} ₺</td></tr>
</table>

<div class="footer">
Tarih: ${new Date().toLocaleDateString('tr-TR')} | ASNCAD Asansör Çizim ve Hesaplama Sistemi | ${p.firma.firmaAdi}<br>
Bu rapor TS EN 81-20:2014, EN 81-77, VDI 4707 standartlarına göre hazırlanmıştır.
</div>
</body></html>`);
                  pw.document.close();
                  setTimeout(() => pw.print(), 500);
                }} style={{ width: '100%', padding: '10px 16px', background: '#1d4ed8', color: '#fff', border: 'none', borderRadius: 6, cursor: 'pointer', fontWeight: 600, fontSize: 13 }}>
                  📋 Detaylı Rapor (Faz 2-4)
                </button>
              </div>
            </div>
            );
          })()}
          {tab === 6 && (
            <div style={gridStyle}>
              <div style={{ ...fieldStyle, gridColumn: '1 / -1' }}><label style={{ ...labelStyle, color: '#60a5fa', fontWeight: 600 }}>Firma Bilgileri</label></div>
              <div style={{ ...fieldStyle, gridColumn: '1 / -1' }}><label style={labelStyle}>Firma Adı</label><input style={inputStyle} value={p.firma.firmaAdi} onChange={e => setFirma('firmaAdi', e.target.value)} /></div>
              <div style={{ ...fieldStyle, gridColumn: '1 / -1' }}><label style={labelStyle}>Adres</label><input style={inputStyle} value={p.firma.adres} onChange={e => setFirma('adres', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Telefon</label><input style={inputStyle} value={p.firma.tel} onChange={e => setFirma('tel', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Mühendis</label><input style={inputStyle} value={p.firma.muhendis} onChange={e => setFirma('muhendis', e.target.value)} /></div>
              <div style={{ ...fieldStyle, gridColumn: '1 / -1' }}><label style={{ ...labelStyle, color: '#60a5fa', fontWeight: 600 }}>Çoklu Asansör & Görünüm</label></div>
              <div style={fieldStyle}><label style={labelStyle}>Asansör Sayısı</label>
                <select style={selectStyle} value={p.asansorSayisi} onChange={e => setNum('asansorSayisi', e.target.value)}>
                  <option value={1}>1 Asansör</option><option value={2}>2 Asansör (Yan Yana)</option>
                </select>
              </div>
              <div style={fieldStyle}><label style={labelStyle}>Ara Bölme Kalınlığı (mm)</label><input style={inputStyle} type="number" value={p.araBolme} onChange={e => setNum('araBolme', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>Panoramik Asansör</label>
                <label style={{ display: 'flex', alignItems: 'center', gap: 8, color: '#e2e8f0', cursor: 'pointer' }}>
                  <input type="checkbox" checked={p.panoramik} onChange={e => set('panoramik', e.target.checked)} /> Panoramik
                </label>
              </div>
              <div style={{ ...fieldStyle, gridColumn: '1 / -1' }}><label style={{ ...labelStyle, color: '#60a5fa', fontWeight: 600 }}>Ölçek Parametreleri</label></div>
              <div style={fieldStyle}><label style={labelStyle}>KK Ölçeği</label><input style={inputStyle} type="number" step="0.1" value={p.kkOlcek} onChange={e => setFloat('kkOlcek', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>KD Ölçeği</label><input style={inputStyle} type="number" step="0.1" value={p.kdOlcek} onChange={e => setFloat('kdOlcek', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>MD Ölçeği</label><input style={inputStyle} type="number" step="0.1" value={p.mdOlcek} onChange={e => setFloat('mdOlcek', e.target.value)} /></div>
              <div style={fieldStyle}><label style={labelStyle}>TK Ölçeği</label><input style={inputStyle} type="number" step="1" value={p.tkOlcek} onChange={e => setFloat('tkOlcek', e.target.value)} /></div>
            </div>
          )}
        </div>
        <div style={{ padding: '12px 20px', borderTop: '1px solid #334155', display: 'flex', justifyContent: 'flex-end', gap: 8 }}>
          <button onClick={onClose} style={{ ...btnStyle, background: '#334155', color: '#94a3b8' }}>İptal</button>
          <button onClick={handleApply} style={{ ...btnStyle, background: '#2563eb', color: '#fff' }}>Uygula</button>
        </div>
      </div>
    </div>
  );
}


// ═══════════════════════════════════════════════════════════════════════════════
// Feature 3: LAYER PANEL COMPONENT
// ═══════════════════════════════════════════════════════════════════════════════

function LayerPanel({ layers, onToggleVisibility, onToggleLock, collapsed, onToggleCollapse }: {
  layers: LayerDef[];
  onToggleVisibility: (name: string) => void;
  onToggleLock: (name: string) => void;
  collapsed: boolean;
  onToggleCollapse: () => void;
}) {
  const panelStyle: React.CSSProperties = {
    width: collapsed ? 32 : 180, background: '#0a0a1a', borderRight: '1px solid #333355',
    overflow: 'auto', transition: 'width 0.2s', flexShrink: 0,
  };
  const headerStyle: React.CSSProperties = {
    padding: '6px 8px', borderBottom: '1px solid #334155', display: 'flex',
    justifyContent: 'space-between', alignItems: 'center', cursor: 'pointer',
  };
  const rowStyle: React.CSSProperties = {
    display: 'flex', alignItems: 'center', gap: 4, padding: '3px 8px',
    fontSize: 11, borderBottom: '1px solid #0f172a',
  };
  const iconBtn: React.CSSProperties = {
    background: 'none', border: 'none', cursor: 'pointer', padding: 2, fontSize: 12, lineHeight: 1,
  };

  return (
    <div style={panelStyle}>
      <div style={headerStyle} onClick={onToggleCollapse}>
        <span style={{ color: '#94a3b8', fontSize: 11, fontWeight: 600, whiteSpace: 'nowrap' }}>
          {collapsed ? '▶' : '◀ KATMANLAR'}
        </span>
      </div>
      {!collapsed && layers.map(l => (
        <div key={l.name} style={rowStyle}>
          <button style={{ ...iconBtn, color: l.visible ? '#22c55e' : '#475569' }} onClick={() => onToggleVisibility(l.name)} title={l.visible ? 'Gizle' : 'Göster'}>
            {l.visible ? '👁' : '🚫'}
          </button>
          <button style={{ ...iconBtn, color: l.locked ? '#ef4444' : '#475569' }} onClick={() => onToggleLock(l.name)} title={l.locked ? 'Kilidi Aç' : 'Kilitle'}>
            {l.locked ? '🔒' : '🔓'}
          </button>
          <span style={{ width: 12, height: 12, borderRadius: 2, background: l.color, flexShrink: 0 }} />
          <span style={{ color: l.visible ? '#e2e8f0' : '#475569', flex: 1, overflow: 'hidden', textOverflow: 'ellipsis', whiteSpace: 'nowrap' }}>
            {l.name}
          </span>
        </div>
      ))}
    </div>
  );
}


// ═══════════════════════════════════════════════════════════════════════════════
// Feature 6: DIMENSION EDIT POPUP
// ═══════════════════════════════════════════════════════════════════════════════

function DimEditPopup({ x, y, currentValue, onApply, onClose }: {
  x: number; y: number; currentValue: string; onApply: (val: number) => void; onClose: () => void;
}) {
  const [val, setVal] = useState(currentValue);
  const inputRef = useRef<HTMLInputElement>(null);
  useEffect(() => { inputRef.current?.focus(); inputRef.current?.select(); }, []);
  const handleSubmit = () => { const n = parseInt(val); if (!isNaN(n)) onApply(n); onClose(); };
  return (
    <div style={{ position: 'absolute', left: x, top: y, zIndex: 999, background: '#1e293b', border: '1px solid #60a5fa', borderRadius: 6, padding: 8, display: 'flex', gap: 4 }}>
      <input ref={inputRef} style={{ ...inputStyle, width: 100 }} type="number" value={val} onChange={e => setVal(e.target.value)}
        onKeyDown={e => { if (e.key === 'Enter') handleSubmit(); if (e.key === 'Escape') onClose(); }} />
      <button onClick={handleSubmit} style={{ padding: '4px 8px', background: '#2563eb', color: '#fff', border: 'none', borderRadius: 4, cursor: 'pointer', fontSize: 12 }}>OK</button>
    </div>
  );
}


// ═══════════════════════════════════════════════════════════════════════════════
// Feature 12: CONTEXT MENU (Block Replacement)
// ═══════════════════════════════════════════════════════════════════════════════

function ContextMenu({ x, y, entity, onSelect, onClose }: {
  x: number; y: number; entity: CadEntity; onSelect: (paramName: string, value: string) => void; onClose: () => void;
}) {
  const blockName = entity.xdata?.blockName || '';
  let options: { label: string; paramName: string; value: string }[] = [];

  if (blockName.includes('Ray') || blockName === 'KabinRay') {
    options = ['T50/A', 'T70/A', 'T70/B', 'T82/B', 'T89/B', 'T127/B'].map(r => ({ label: r, paramName: 'kabinRayTipi', value: r }));
  } else if (blockName === 'AgrRay') {
    options = ['T50/A', 'T70/A', 'T70/B', 'T82/B', 'T89/B', 'T127/B'].map(r => ({ label: r, paramName: 'agrRayTipi', value: r }));
  } else if (blockName.includes('Tampon')) {
    options = [{ label: 'Yay', paramName: 'tamponTipi', value: 'Yay' }, { label: 'Hidrolik', paramName: 'tamponTipi', value: 'Hidrolik' }, { label: 'Poliüretan', paramName: 'tamponTipi', value: 'Poliüretan' }];
  } else if (blockName.includes('Kapi')) {
    options = [{ label: 'KK-OT', paramName: 'kapiTipi', value: 'KK-OT' }, { label: 'KK-KK', paramName: 'kapiTipi', value: 'KK-KK' }, { label: 'OT-2', paramName: 'kapiTipi', value: 'OT-2' }, { label: 'OT-3', paramName: 'kapiTipi', value: 'OT-3' }];
  }

  if (options.length === 0) { onClose(); return null; }

  const menuStyle: React.CSSProperties = { position: 'absolute', left: x, top: y, zIndex: 999, background: '#1e293b', border: '1px solid #334155', borderRadius: 6, padding: 4, minWidth: 150 };
  const itemStyle: React.CSSProperties = { padding: '6px 12px', cursor: 'pointer', fontSize: 12, color: '#e2e8f0', borderRadius: 4 };

  return (
    <div style={menuStyle} onMouseLeave={onClose}>
      <div style={{ padding: '4px 12px', fontSize: 11, color: '#94a3b8', borderBottom: '1px solid #334155', marginBottom: 4 }}>
        {blockName} — Değiştir
      </div>
      {options.map(o => (
        <div key={o.value} style={itemStyle}
          onMouseEnter={e => (e.currentTarget.style.background = '#334155')}
          onMouseLeave={e => (e.currentTarget.style.background = 'transparent')}
          onClick={() => { onSelect(o.paramName, o.value); onClose(); }}>
          {o.label}
        </div>
      ))}
    </div>
  );
}


// ═══════════════════════════════════════════════════════════════════════════════
// HELPER FUNCTIONS: Move, Rotate, Mirror, Snap, Ortho
// ═══════════════════════════════════════════════════════════════════════════════

function moveEntity(e: CadEntity, dx: number, dy: number): CadEntity {
  const moved = { ...e };
  if (moved.x !== undefined) moved.x = moved.x + dx;
  if (moved.y !== undefined) moved.y = moved.y + dy;
  if (moved.x1 !== undefined) { moved.x1 = moved.x1 + dx; moved.y1 = (moved.y1 || 0) + dy; }
  if (moved.x2 !== undefined) { moved.x2 = moved.x2 + dx; moved.y2 = (moved.y2 || 0) + dy; }
  if (moved.cx !== undefined) { moved.cx = moved.cx + dx; moved.cy = (moved.cy || 0) + dy; }
  if (moved.points) moved.points = moved.points.map(p => ({ x: p.x + dx, y: p.y + dy }));
  return moved;
}

function rotateEntity90(e: CadEntity, center: Point): CadEntity {
  const rot = { ...e };
  const r = (px: number, py: number) => ({ x: center.x - (py - center.y), y: center.y + (px - center.x) });
  if (rot.type === 'line' || rot.type === 'dimension') {
    const p1 = r(rot.x1!, rot.y1!); const p2 = r(rot.x2!, rot.y2!);
    rot.x1 = p1.x; rot.y1 = p1.y; rot.x2 = p2.x; rot.y2 = p2.y;
  }
  if (rot.type === 'rect') {
    const p = r(rot.x!, rot.y!);
    rot.x = p.x; rot.y = p.y;
    const tmp = rot.w; rot.w = rot.h; rot.h = tmp;
  }
  if (rot.type === 'circle') {
    const p = r(rot.cx!, rot.cy!);
    rot.cx = p.x; rot.cy = p.y;
  }
  if (rot.type === 'text') {
    const p = r(rot.x!, rot.y!);
    rot.x = p.x; rot.y = p.y;
    rot.rotation = ((rot.rotation || 0) + 90) % 360;
  }
  if (rot.points) rot.points = rot.points.map(p => r(p.x, p.y));
  return rot;
}

function mirrorEntityX(e: CadEntity, mirrorX: number): CadEntity {
  const m = { ...e };
  const mx = (v: number) => 2 * mirrorX - v;
  if (m.x !== undefined && m.w !== undefined) m.x = mx(m.x + m.w);
  if (m.x1 !== undefined) { m.x1 = mx(m.x1); m.x2 = mx(m.x2!); }
  if (m.cx !== undefined) m.cx = mx(m.cx);
  if (m.type === 'text' && m.x !== undefined) m.x = mx(m.x);
  if (m.points) m.points = m.points.map(p => ({ x: mx(p.x), y: p.y }));
  return m;
}

// Polar tracking angles (degrees) — AutoCAD style
const POLAR_ANGLES = [0, 45, 90, 135, 180, 225, 270, 315];
const POLAR_THRESHOLD = 8; // degrees tolerance for snapping to angle

function applyOrtho(start: Point, end: Point): Point {
  const dx = Math.abs(end.x - start.x);
  const dy = Math.abs(end.y - start.y);
  if (dx > dy) return { x: end.x, y: start.y };
  return { x: start.x, y: end.y };
}

function applyPolarTracking(start: Point, end: Point): { point: Point; angle: number; snapped: boolean } {
  const dx = end.x - start.x;
  const dy = end.y - start.y;
  const dist = Math.sqrt(dx * dx + dy * dy);
  if (dist < 0.001) return { point: end, angle: 0, snapped: false };

  const angleRad = Math.atan2(dy, dx);
  const angleDeg = ((angleRad * 180 / Math.PI) + 360) % 360;

  // Check if close to any polar angle
  for (const pa of POLAR_ANGLES) {
    let diff = Math.abs(angleDeg - pa);
    if (diff > 180) diff = 360 - diff;
    if (diff < POLAR_THRESHOLD) {
      const snapRad = (pa * Math.PI) / 180;
      return {
        point: { x: start.x + dist * Math.cos(snapRad), y: start.y + dist * Math.sin(snapRad) },
        angle: pa,
        snapped: true,
      };
    }
  }
  return { point: end, angle: angleDeg, snapped: false };
}

function findSnapPoint(entities: CadEntity[], wx: number, wy: number, tolerance: number): SnapPoint | null {
  let closest: SnapPoint | null = null;
  let minDist = tolerance;

  const check = (sp: SnapPoint) => {
    const dist = Math.sqrt((sp.x - wx) ** 2 + (sp.y - wy) ** 2);
    if (dist < minDist) { minDist = dist; closest = sp; }
  };

  // Collect all line segments for intersection detection
  const segments: { x1: number; y1: number; x2: number; y2: number }[] = [];

  for (const e of entities) {
    // ── Endpoint, Midpoint, Center ──
    if (e.type === 'line' || e.type === 'dimension') {
      check({ x: e.x1!, y: e.y1!, type: 'endpoint' });
      check({ x: e.x2!, y: e.y2!, type: 'endpoint' });
      check({ x: (e.x1! + e.x2!) / 2, y: (e.y1! + e.y2!) / 2, type: 'midpoint' });
      segments.push({ x1: e.x1!, y1: e.y1!, x2: e.x2!, y2: e.y2! });

      // ── Nearest point on line ──
      const dx = e.x2! - e.x1!, dy = e.y2! - e.y1!;
      const len2 = dx * dx + dy * dy;
      if (len2 > 0) {
        let t = ((wx - e.x1!) * dx + (wy - e.y1!) * dy) / len2;
        t = Math.max(0, Math.min(1, t));
        check({ x: e.x1! + t * dx, y: e.y1! + t * dy, type: 'nearest' });
      }

      // ── Extension (project beyond endpoints) ──
      if (len2 > 0) {
        const len = Math.sqrt(len2);
        const ux = dx / len, uy = dy / len;
        // Project cursor onto line direction from endpoint 2
        const t2 = ((wx - e.x2!) * ux + (wy - e.y2!) * uy);
        if (t2 > 0 && t2 < tolerance * 2) {
          check({ x: e.x2! + t2 * ux, y: e.y2! + t2 * uy, type: 'extension' });
        }
        // Project from endpoint 1 backwards
        const t1 = -((wx - e.x1!) * ux + (wy - e.y1!) * uy);
        if (t1 > 0 && t1 < tolerance * 2) {
          check({ x: e.x1! - t1 * ux, y: e.y1! - t1 * uy, type: 'extension' });
        }
      }
    }

    if (e.type === 'rect') {
      // Corners (endpoints)
      check({ x: e.x!, y: e.y!, type: 'endpoint' });
      check({ x: e.x! + e.w!, y: e.y!, type: 'endpoint' });
      check({ x: e.x! + e.w!, y: e.y! + e.h!, type: 'endpoint' });
      check({ x: e.x!, y: e.y! + e.h!, type: 'endpoint' });
      // Center
      check({ x: e.x! + e.w! / 2, y: e.y! + e.h! / 2, type: 'center' });
      // Edge midpoints
      check({ x: e.x! + e.w! / 2, y: e.y!, type: 'midpoint' });
      check({ x: e.x! + e.w! / 2, y: e.y! + e.h!, type: 'midpoint' });
      check({ x: e.x!, y: e.y! + e.h! / 2, type: 'midpoint' });
      check({ x: e.x! + e.w!, y: e.y! + e.h! / 2, type: 'midpoint' });
      // Rect edges as segments for intersection
      segments.push({ x1: e.x!, y1: e.y!, x2: e.x! + e.w!, y2: e.y! });
      segments.push({ x1: e.x! + e.w!, y1: e.y!, x2: e.x! + e.w!, y2: e.y! + e.h! });
      segments.push({ x1: e.x! + e.w!, y1: e.y! + e.h!, x2: e.x!, y2: e.y! + e.h! });
      segments.push({ x1: e.x!, y1: e.y! + e.h!, x2: e.x!, y2: e.y! });

      // ── Nearest on each edge ──
      const edges = [
        [e.x!, e.y!, e.x! + e.w!, e.y!],
        [e.x! + e.w!, e.y!, e.x! + e.w!, e.y! + e.h!],
        [e.x! + e.w!, e.y! + e.h!, e.x!, e.y! + e.h!],
        [e.x!, e.y! + e.h!, e.x!, e.y!],
      ];
      for (const [ax, ay, bx, by] of edges) {
        const edx = bx - ax, edy = by - ay;
        const el2 = edx * edx + edy * edy;
        if (el2 > 0) {
          let t = ((wx - ax) * edx + (wy - ay) * edy) / el2;
          t = Math.max(0, Math.min(1, t));
          check({ x: ax + t * edx, y: ay + t * edy, type: 'nearest' });
        }
      }
    }

    if (e.type === 'circle') {
      check({ x: e.cx!, y: e.cy!, type: 'center' });
      // Quadrant points
      check({ x: e.cx! + e.r!, y: e.cy!, type: 'quadrant' });
      check({ x: e.cx! - e.r!, y: e.cy!, type: 'quadrant' });
      check({ x: e.cx!, y: e.cy! + e.r!, type: 'quadrant' });
      check({ x: e.cx!, y: e.cy! - e.r!, type: 'quadrant' });

      // ── Nearest point on circle ──
      const dcx = wx - e.cx!, dcy = wy - e.cy!;
      const dLen = Math.sqrt(dcx * dcx + dcy * dcy);
      if (dLen > 0.001) {
        check({ x: e.cx! + (dcx / dLen) * e.r!, y: e.cy! + (dcy / dLen) * e.r!, type: 'nearest' });
      }

      // ── Perpendicular from cursor to circle (tangent point) ──
      if (dLen > e.r!) {
        const angle = Math.atan2(dcy, dcx);
        check({ x: e.cx! + e.r! * Math.cos(angle), y: e.cy! + e.r! * Math.sin(angle), type: 'perpendicular' });
      }
    }
  }

  // ── Intersection detection between all segment pairs ──
  for (let i = 0; i < segments.length; i++) {
    for (let j = i + 1; j < segments.length; j++) {
      const s1 = segments[i], s2 = segments[j];
      const ix = lineLineIntersection(s1.x1, s1.y1, s1.x2, s1.y2, s2.x1, s2.y1, s2.x2, s2.y2);
      if (ix) check({ x: ix.x, y: ix.y, type: 'intersection' });
    }
  }

  return closest;
}

function lineLineIntersection(x1: number, y1: number, x2: number, y2: number,
  x3: number, y3: number, x4: number, y4: number): Point | null {
  const denom = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
  if (Math.abs(denom) < 0.0001) return null; // parallel
  const t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4)) / denom;
  const u = -((x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3)) / denom;
  if (t >= -0.01 && t <= 1.01 && u >= -0.01 && u <= 1.01) {
    return { x: x1 + t * (x2 - x1), y: y1 + t * (y2 - y1) };
  }
  return null;
}

// ═══════════════════════════════════════════════════════════════════════════════
// MAIN APPLICATION COMPONENT
// ═══════════════════════════════════════════════════════════════════════════════

export default function AscadCadApp() {
  const canvasRef = useRef<HTMLCanvasElement>(null);
  const [params, setParams] = useState<ElevatorParams>(defaultParams());
  const [entities, setEntities] = useState<CadEntity[]>([]);
  const [view, setView] = useState<ViewState>({ panX: 300, panY: 300, zoom: 0.25 });
  const [activeTab, setActiveTab] = useState<DrawingTab>('kuyu-kesiti');
  const [activeTool, setActiveTool] = useState<ToolName>('select');
  const [showGrid, setShowGrid] = useState(true);
  const [showSnap, setShowSnap] = useState(true);
  const [showOrtho, setShowOrtho] = useState(false);
  const [showDialog, setShowDialog] = useState(false);
  const [mouseWorld, setMouseWorld] = useState<Point>({ x: 0, y: 0 });
  const [mouseScreen, setMouseScreen] = useState<Point>({ x: 0, y: 0 });
  const [undoStack, setUndoStack] = useState<CadEntity[][]>([]);
  const [redoStack, setRedoStack] = useState<CadEntity[][]>([]);

  // Feature 3: Layer state
  const [layers, setLayers] = useState<LayerDef[]>(DEFAULT_LAYERS.map(l => ({ ...l })));

  // Feature 7: Selection & Info
  const [selectedEntity, setSelectedEntity] = useState<CadEntity | null>(null);
  const [statusInfo, setStatusInfo] = useState('');

  // Feature 6: Dimension Edit
  const [dimEditPopup, setDimEditPopup] = useState<{ x: number; y: number; value: string; paramName: string } | null>(null);

  // Feature 12: Context Menu
  const [contextMenu, setContextMenu] = useState<{ x: number; y: number; entity: CadEntity } | null>(null);

  // Feature 6: DD Hover Detection
  const [hoveredDimId, setHoveredDimId] = useState<string | null>(null);

  // Faz 1: Snap & Preview state
  const [snapPoint, setSnapPoint] = useState<SnapPoint | null>(null);
  const [previewEntity, setPreviewEntity] = useState<CadEntity | null>(null);

  // Feature 11: Command Input
  const [cmdInput, setCmdInput] = useState('');

  // ─── AutoCAD Web UI state ─────────────────────────────────────────────────
  const [activeRibbonTab, setActiveRibbonTab] = useState<RibbonTabId>('cizim');
  const [leftPanelCollapsed, setLeftPanelCollapsed] = useState(false);
  const [objPropsCollapsed, setObjPropsCollapsed] = useState(false);
  const [layerSectionCollapsed, setLayerSectionCollapsed] = useState(false);
  const [modelLayoutTab, setModelLayoutTab] = useState<'model' | 'layout1'>('model');

  const isPanning = useRef(false);
  const panStart = useRef<Point>({ x: 0, y: 0 });
  const viewStart = useRef<ViewState>({ panX: 0, panY: 0, zoom: 1 });
  const isDrawing = useRef(false);
  const drawStart = useRef<Point>({ x: 0, y: 0 });
  // Window/Crossing selection box
  const isSelecting = useRef(false);
  const selBoxStart = useRef<Point>({ x: 0, y: 0 }); // screen coords
  const selBoxEnd = useRef<Point>({ x: 0, y: 0 });   // screen coords
  const selBoxWorldStart = useRef<Point>({ x: 0, y: 0 }); // world coords
  // 3-step dimension: step 0=first point, 1=second point, 2=offset position
  const dimStep = useRef(0);
  const dimFirstPoint = useRef<Point>({ x: 0, y: 0 });
  const dimSecondPoint = useRef<Point>({ x: 0, y: 0 });

  // ─── Generate entities for active tab ──────────────────────────────────────
  const regenerate = useCallback((p: ElevatorParams, tab: DrawingTab) => {
    _eid = 0;
    let newEnts: CadEntity[];
    switch (tab) {
      case 'kuyu-kesiti': newEnts = generateCrossSection(p); break;
      case 'boyuna-kesit': newEnts = generateLongitudinalSection(p); break;
      case 'makine-dairesi': newEnts = generateMachineRoom(p); break;
      case 'kabin-plani': newEnts = generateCabinPlan(p); break;
      case 'hesap-raporu': newEnts = generateHesapRaporu(p); break;
      case 'hesap-ozeti': newEnts = generateHesapOzeti(p); break;
      case 'tkaa': newEnts = generateTKAA(p); break;
      case 'tkbb': newEnts = generateTKBB(p); break;
      case 'tum-proje': newEnts = generateTumProje(p); break;
      case 'kapi-detay': newEnts = generateKapiDetay(p); break;
      case 'aski-diyagram': newEnts = generateAskiDiyagram(p); break;
      default: newEnts = generateCrossSection(p);
    }
    setEntities(newEnts);
    setUndoStack([]);
    setRedoStack([]);
    setSelectedEntity(null);
  }, []);

  useEffect(() => { regenerate(params, activeTab); setTimeout(handleZoomExtents, 150); }, [params, activeTab, regenerate]);

  // ─── Calculated values ─────────────────────────────────────────────────────
  const { kabinGen, kabinDer } = useMemo(() => hesaplaKabinBoyutlari(params), [params]);
  const beyan = useMemo(() => beyanYukBul(kabinGen, kabinDer), [kabinGen, kabinDer]);

  // ─── Canvas rendering ─────────────────────────────────────────────────────
  const render = useCallback(() => {
    const canvas = canvasRef.current;
    if (!canvas) return;
    const ctx = canvas.getContext('2d');
    if (!ctx) return;
    const dpr = window.devicePixelRatio || 1;
    const rect = canvas.getBoundingClientRect();
    canvas.width = rect.width * dpr;
    canvas.height = rect.height * dpr;
    ctx.scale(dpr, dpr);
    renderAll(ctx, entities, view, rect.width, rect.height, showGrid, layers, hoveredDimId);
    // Render rubber band preview with dynamic dimensions
    if (previewEntity && isDrawing.current) {
      ctx.globalAlpha = 0.5;
      renderEntity(ctx, { ...previewEntity, color: '#00ff88', lineWidth: 1.5 }, view, rect.height, null);
      ctx.globalAlpha = 1.0;

      // Dynamic dimension display (AutoCAD-style)
      const startSc = worldToScreen(drawStart.current.x, drawStart.current.y, view, rect.height);
      const endSc = worldToScreen(mouseWorld.x, mouseWorld.y, view, rect.height);
      const dxW = mouseWorld.x - drawStart.current.x;
      const dyW = mouseWorld.y - drawStart.current.y;
      const distW = Math.sqrt(dxW * dxW + dyW * dyW);
      const angleRad = Math.atan2(dyW, dxW);
      const angleDeg = ((angleRad * 180 / Math.PI) + 360) % 360;

      // Polar tracking detection
      const polar = applyPolarTracking(drawStart.current, mouseWorld);
      const isPolarSnapped = polar.snapped && !showOrtho && (activeTool === 'line' || activeTool === 'dimension');

      // Tracking lines
      ctx.lineWidth = 0.5; ctx.setLineDash([4, 4]);
      if (isPolarSnapped) {
        // Polar tracking line — extends through the snapped angle
        ctx.strokeStyle = '#00ff88';
        const polarEnd = worldToScreen(polar.point.x, polar.point.y, view, rect.height);
        const extLen = 2000; // extend line far
        const pa = (polar.angle * Math.PI) / 180;
        const farX = startSc.x + extLen * Math.cos(-pa);
        const farY = startSc.y + extLen * Math.sin(-pa); // negative because screen Y is flipped
        ctx.beginPath(); ctx.moveTo(startSc.x, startSc.y); ctx.lineTo(farX, farY); ctx.stroke();
        // Angle label on tracking line
        ctx.setLineDash([]);
        ctx.fillStyle = '#00ff88'; ctx.font = '10px monospace'; ctx.textAlign = 'center';
        const labelX = (startSc.x + polarEnd.x) / 2;
        const labelY = (startSc.y + polarEnd.y) / 2 - 8;
        ctx.fillText(`${polar.angle}°`, labelX, labelY);
      } else {
        // Standard horizontal/vertical tracking
        ctx.strokeStyle = '#00ff8844';
        ctx.beginPath(); ctx.moveTo(startSc.x, startSc.y); ctx.lineTo(endSc.x, startSc.y); ctx.stroke();
        ctx.beginPath(); ctx.moveTo(endSc.x, startSc.y); ctx.lineTo(endSc.x, endSc.y); ctx.stroke();
      }
      ctx.setLineDash([]);

      // Dimension text near cursor
      ctx.font = 'bold 12px monospace'; ctx.textAlign = 'left'; ctx.textBaseline = 'bottom';
      const dimX = endSc.x + 15, dimY = endSc.y - 8;
      const displayDist = isPolarSnapped ? Math.sqrt((polar.point.x - drawStart.current.x) ** 2 + (polar.point.y - drawStart.current.y) ** 2) : distW;
      const displayAngle = isPolarSnapped ? polar.angle : angleDeg;

      if (activeTool === 'line' || activeTool === 'dimension') {
        // Show length and angle (highlighted if polar snapped)
        ctx.fillStyle = isPolarSnapped ? '#00ffff' : '#00ff88';
        ctx.fillText(`${displayDist.toFixed(1)}`, dimX, dimY);
        ctx.fillStyle = isPolarSnapped ? '#00ffff' : '#888';
        ctx.fillText(`∠${displayAngle.toFixed(1)}°${isPolarSnapped ? ' ◆' : ''}`, dimX, dimY + 14);
      } else if (activeTool === 'rect') {
        // Show width × height
        const w = Math.abs(dxW), h = Math.abs(dyW);
        ctx.fillStyle = '#00ff88';
        ctx.fillText(`${w.toFixed(1)} × ${h.toFixed(1)}`, dimX, dimY);
        ctx.fillStyle = '#888';
        ctx.fillText(`A=${(w * h / 1_000_000).toFixed(3)} m²`, dimX, dimY + 14);

        // Show W and H along edges
        const tlSc = worldToScreen(Math.min(drawStart.current.x, mouseWorld.x), Math.max(drawStart.current.y, mouseWorld.y), view, rect.height);
        const brSc = worldToScreen(Math.max(drawStart.current.x, mouseWorld.x), Math.min(drawStart.current.y, mouseWorld.y), view, rect.height);
        ctx.fillStyle = '#00ccff'; ctx.font = '11px monospace'; ctx.textAlign = 'center';
        // Width along top
        ctx.fillText(`${w.toFixed(0)}`, (tlSc.x + brSc.x) / 2, tlSc.y - 4);
        // Height along right
        ctx.save(); ctx.translate(brSc.x + 12, (tlSc.y + brSc.y) / 2);
        ctx.rotate(-Math.PI / 2); ctx.fillText(`${h.toFixed(0)}`, 0, 0); ctx.restore();
      } else if (activeTool === 'circle') {
        // Show radius
        ctx.fillStyle = '#00ff88';
        ctx.fillText(`R=${distW.toFixed(1)}`, dimX, dimY);
        ctx.fillStyle = '#888';
        ctx.fillText(`Ø=${(distW * 2).toFixed(1)}`, dimX, dimY + 14);
      }

      // Start point marker (small cross)
      ctx.strokeStyle = '#00ff88'; ctx.lineWidth = 1;
      ctx.beginPath();
      ctx.moveTo(startSc.x - 8, startSc.y); ctx.lineTo(startSc.x + 8, startSc.y);
      ctx.moveTo(startSc.x, startSc.y - 8); ctx.lineTo(startSc.x, startSc.y + 8);
      ctx.stroke();
    }
    renderCrosshair(ctx, mouseScreen.x, mouseScreen.y, rect.width, rect.height);
    // Render selection box (Window=blue solid, Crossing=green dashed)
    if (isSelecting.current) {
      const sx1 = selBoxStart.current.x, sy1 = selBoxStart.current.y;
      const sx2 = selBoxEnd.current.x, sy2 = selBoxEnd.current.y;
      const isWindow = sx2 > sx1;
      ctx.save();
      ctx.strokeStyle = isWindow ? '#3b82f6' : '#22c55e';
      ctx.lineWidth = 1.5;
      ctx.setLineDash(isWindow ? [] : [6, 3]);
      ctx.fillStyle = isWindow ? 'rgba(59,130,246,0.08)' : 'rgba(34,197,94,0.08)';
      const x = Math.min(sx1, sx2), y = Math.min(sy1, sy2);
      const w2 = Math.abs(sx2 - sx1), h2 = Math.abs(sy2 - sy1);
      ctx.fillRect(x, y, w2, h2);
      ctx.strokeRect(x, y, w2, h2);
      ctx.setLineDash([]);
      // Label
      ctx.font = '10px Arial';
      ctx.fillStyle = isWindow ? '#3b82f6' : '#22c55e';
      ctx.textAlign = 'left';
      ctx.fillText(isWindow ? 'Window' : 'Crossing', x + 4, y - 4);
      ctx.restore();
    }
    // Render snap point indicator
    if (snapPoint) {
      const sp = worldToScreen(snapPoint.x, snapPoint.y, view, rect.height);
      ctx.lineWidth = 2;
      ctx.beginPath();
      switch (snapPoint.type) {
        case 'endpoint':
          ctx.strokeStyle = '#ff0';
          ctx.rect(sp.x - 5, sp.y - 5, 10, 10);
          break;
        case 'midpoint':
          ctx.strokeStyle = '#ff0';
          ctx.moveTo(sp.x, sp.y - 6); ctx.lineTo(sp.x + 6, sp.y + 3); ctx.lineTo(sp.x - 6, sp.y + 3); ctx.closePath();
          break;
        case 'center':
          ctx.strokeStyle = '#ff0';
          ctx.arc(sp.x, sp.y, 6, 0, Math.PI * 2);
          break;
        case 'intersection':
          ctx.strokeStyle = '#00ff00';
          ctx.moveTo(sp.x - 6, sp.y - 6); ctx.lineTo(sp.x + 6, sp.y + 6);
          ctx.moveTo(sp.x + 6, sp.y - 6); ctx.lineTo(sp.x - 6, sp.y + 6);
          break;
        case 'perpendicular':
          ctx.strokeStyle = '#00ccff';
          ctx.moveTo(sp.x - 6, sp.y); ctx.lineTo(sp.x, sp.y); ctx.lineTo(sp.x, sp.y - 6);
          break;
        case 'nearest':
          ctx.strokeStyle = '#ff8800';
          ctx.moveTo(sp.x - 5, sp.y - 5); ctx.lineTo(sp.x + 5, sp.y - 5);
          ctx.lineTo(sp.x + 5, sp.y + 5); ctx.lineTo(sp.x - 5, sp.y + 5); ctx.closePath();
          ctx.moveTo(sp.x - 3, sp.y - 3); ctx.lineTo(sp.x + 3, sp.y + 3);
          break;
        case 'extension':
          ctx.strokeStyle = '#ff00ff';
          ctx.setLineDash([3, 3]);
          ctx.moveTo(sp.x - 8, sp.y); ctx.lineTo(sp.x + 8, sp.y);
          ctx.moveTo(sp.x, sp.y - 8); ctx.lineTo(sp.x, sp.y + 8);
          break;
        case 'quadrant':
          ctx.strokeStyle = '#ff0';
          ctx.moveTo(sp.x, sp.y - 6); ctx.lineTo(sp.x + 6, sp.y);
          ctx.lineTo(sp.x, sp.y + 6); ctx.lineTo(sp.x - 6, sp.y); ctx.closePath();
          break;
      }
      ctx.stroke();
      ctx.setLineDash([]);
    }
  }, [entities, view, showGrid, mouseScreen, mouseWorld, layers, hoveredDimId, previewEntity, snapPoint]);

  useEffect(() => { requestAnimationFrame(render); }, [render]);

  useEffect(() => {
    const canvas = canvasRef.current;
    if (!canvas) return;
    const ro = new ResizeObserver(() => requestAnimationFrame(render));
    ro.observe(canvas);
    return () => ro.disconnect();
  }, [render]);

  // ─── Mouse handlers ───────────────────────────────────────────────────────
  const handleMouseDown = useCallback((e: React.MouseEvent<HTMLCanvasElement>) => {
    const canvas = canvasRef.current;
    if (!canvas) return;
    const rect = canvas.getBoundingClientRect();
    const sx = e.clientX - rect.left, sy = e.clientY - rect.top;

    // Close context menu on any click
    setContextMenu(null);

    if (e.button === 1 || (e.button === 0 && activeTool === 'pan')) {
      isPanning.current = true;
      panStart.current = { x: sx, y: sy };
      viewStart.current = { ...view };
      e.preventDefault();
      return;
    }

    // Feature 7: Entity selection on click OR start window/crossing selection drag
    if (e.button === 0 && activeTool === 'select') {
      const w = screenToWorld(sx, sy, view, rect.height);
      const tolerance = 30 / view.zoom;
      // Check if clicking on an entity first
      let found: CadEntity | null = null;
      for (let i = entities.length - 1; i >= 0; i--) {
        if (hitTestEntity(entities[i], w.x, w.y, tolerance)) {
          found = entities[i];
          break;
        }
      }
      if (found) {
        // Direct click on entity — select it
        if (!e.shiftKey) {
          setEntities(prev => prev.map(ent => ent.id === found!.id ? { ...ent, selected: true } : { ...ent, selected: false }));
        } else {
          // Shift+click — toggle selection (add/remove)
          setEntities(prev => prev.map(ent => ent.id === found!.id ? { ...ent, selected: !ent.selected } : ent));
        }
        setSelectedEntity(found);
        const info = `${found.layer} | ${found.type}${found.xdata ? ` | ${found.xdata.blockName}` : ''}${found.xdata?.paramName ? ` [${found.xdata.paramName}]` : ''}`;
        setStatusInfo(info);
      } else {
        // No entity hit — start selection box drag
        isSelecting.current = true;
        selBoxStart.current = { x: sx, y: sy };
        selBoxEnd.current = { x: sx, y: sy };
        selBoxWorldStart.current = w;
        if (!e.shiftKey) {
          setEntities(prev => prev.map(ent => ({ ...ent, selected: false })));
          setSelectedEntity(null);
          setStatusInfo('');
        }
      }
      return;
    }

    // Feature 6: DD mode — click dimension to edit
    if (e.button === 0 && activeTool === 'dd') {
      const w = screenToWorld(sx, sy, view, rect.height);
      const tolerance = 30 / view.zoom;
      for (let i = entities.length - 1; i >= 0; i--) {
        const ent = entities[i];
        if (ent.type === 'dimension' && ent.xdata?.paramName && hitTestEntity(ent, w.x, w.y, tolerance)) {
          setDimEditPopup({ x: sx, y: sy, value: ent.dimText || '0', paramName: ent.xdata.paramName });
          return;
        }
      }
      return;
    }

    // Move/Copy tool
    if (e.button === 0 && (activeTool === 'move' || activeTool === 'copy') && selectedEntity) {
      const w = screenToWorld(sx, sy, view, rect.height);
      if (!isDrawing.current) {
        isDrawing.current = true;
        drawStart.current = w;
      } else {
        isDrawing.current = false;
        const dx = w.x - drawStart.current.x;
        const dy = w.y - drawStart.current.y;
        setUndoStack(prev => [...prev, entities]);
        setRedoStack([]);
        if (activeTool === 'move') {
          setEntities(prev => prev.map(ent => {
            if (!ent.selected) return ent;
            return moveEntity(ent, dx, dy);
          }));
        } else {
          // Copy
          const copies = entities.filter(ent => ent.selected).map(ent => ({
            ...moveEntity(ent, dx, dy),
            id: eid(),
            selected: false,
          }));
          setEntities(prev => [...prev.map(e2 => ({ ...e2, selected: false })), ...copies]);
        }
        setActiveTool('select');
      }
      return;
    }

    // Rotate tool
    if (e.button === 0 && activeTool === 'rotate' && selectedEntity) {
      const w = screenToWorld(sx, sy, view, rect.height);
      if (!isDrawing.current) {
        isDrawing.current = true;
        drawStart.current = w;
      } else {
        isDrawing.current = false;
        // Simple 90° rotation for now
        setUndoStack(prev => [...prev, entities]);
        setRedoStack([]);
        setEntities(prev => prev.map(ent => {
          if (!ent.selected) return ent;
          return rotateEntity90(ent, drawStart.current);
        }));
        setActiveTool('select');
      }
      return;
    }

    // Mirror tool
    if (e.button === 0 && activeTool === 'mirror' && selectedEntity) {
      const w = screenToWorld(sx, sy, view, rect.height);
      if (!isDrawing.current) {
        isDrawing.current = true;
        drawStart.current = w;
      } else {
        isDrawing.current = false;
        setUndoStack(prev => [...prev, entities]);
        setRedoStack([]);
        const mirrorX = (drawStart.current.x + w.x) / 2;
        setEntities(prev => prev.map(ent => {
          if (!ent.selected) return ent;
          return mirrorEntityX(ent, mirrorX);
        }));
        setActiveTool('select');
      }
      return;
    }

    // ─── 3-Step Dimension Tool ─────────────────────────────────────────────
    if (e.button === 0 && activeTool === 'dimension') {
      let w = screenToWorld(sx, sy, view, rect.height);
      if (showSnap) {
        const snap = findSnapPoint(entities, w.x, w.y, 50 / view.zoom);
        if (snap) w = { x: snap.x, y: snap.y };
      }
      if (dimStep.current === 0) {
        // Step 1: First point
        dimFirstPoint.current = w;
        dimStep.current = 1;
        isDrawing.current = true;
        drawStart.current = w;
        setStatusInfo('Ölçü: İkinci noktayı seçin...');
      } else if (dimStep.current === 1) {
        // Step 2: Second point
        let finalEnd = w;
        if (showOrtho) finalEnd = applyOrtho(dimFirstPoint.current, finalEnd);
        else { const polar = applyPolarTracking(dimFirstPoint.current, finalEnd); finalEnd = polar.point; }
        dimSecondPoint.current = finalEnd;
        dimStep.current = 2;
        setStatusInfo('Ölçü: Ölçü çizgisinin konumunu belirleyin...');
      } else if (dimStep.current === 2) {
        // Step 3: Offset position — determine dimOffset from the line between first and second points
        const p1 = dimFirstPoint.current, p2 = dimSecondPoint.current;
        const isHorizontal = Math.abs(p2.x - p1.x) > Math.abs(p2.y - p1.y);
        const dimOffset = isHorizontal ? (w.y - (p1.y + p2.y) / 2) : (w.x - (p1.x + p2.x) / 2);
        const dist = Math.round(Math.sqrt((p2.x - p1.x) ** 2 + (p2.y - p1.y) ** 2));
        // Create dimension with offset
        const dimX1 = isHorizontal ? Math.min(p1.x, p2.x) : p1.x + dimOffset;
        const dimY1 = isHorizontal ? p1.y + dimOffset : Math.min(p1.y, p2.y);
        const dimX2 = isHorizontal ? Math.max(p1.x, p2.x) : p1.x + dimOffset;
        const dimY2 = isHorizontal ? p1.y + dimOffset : Math.max(p1.y, p2.y);
        const newDim: CadEntity = {
          id: eid(), type: 'dimension', layer: 'USER', color: C.dim, lineWidth: 0.8,
          x1: dimX1, y1: dimY1, x2: dimX2, y2: dimY2,
          dimText: `${dist}`, dimDir: isHorizontal ? 'h' : 'v', dimOffset: 0,
          userDrawn: true,
        };
        setUndoStack(prev => [...prev, entities]);
        setRedoStack([]);
        setEntities(prev => [...prev, newDim]);
        dimStep.current = 0;
        isDrawing.current = false;
        setPreviewEntity(null);
        setStatusInfo(`Ölçü: ${dist} mm`);
      }
      return;
    }

    if (e.button === 0 && ['line', 'rect', 'circle', 'text'].includes(activeTool)) {
      let w = screenToWorld(sx, sy, view, rect.height);
      // Apply snap if active
      if (showSnap) {
        const snap = findSnapPoint(entities, w.x, w.y, 50 / view.zoom);
        if (snap) w = { x: snap.x, y: snap.y };
      }
      if (!isDrawing.current) {
        isDrawing.current = true;
        drawStart.current = w;
      } else {
        isDrawing.current = false;
        let finalEnd = w;
        if (showOrtho) {
          finalEnd = applyOrtho(drawStart.current, finalEnd);
        } else if (activeTool === 'line') {
          const polar = applyPolarTracking(drawStart.current, finalEnd);
          finalEnd = polar.point;
        }
        const newEnt = createToolEntity(activeTool, drawStart.current, finalEnd);
        if (newEnt) {
          setUndoStack(prev => [...prev, entities]);
          setRedoStack([]);
          setEntities(prev => [...prev, newEnt]);
        }
      }
    }
  }, [view, activeTool, entities]);

  // Feature 6: Double-click dimension edit
  const handleDoubleClick = useCallback((e: React.MouseEvent<HTMLCanvasElement>) => {
    const canvas = canvasRef.current;
    if (!canvas) return;
    const rect = canvas.getBoundingClientRect();
    const sx = e.clientX - rect.left, sy = e.clientY - rect.top;
    const w = screenToWorld(sx, sy, view, rect.height);
    const tolerance = 30 / view.zoom;
    for (let i = entities.length - 1; i >= 0; i--) {
      const ent = entities[i];
      if (ent.type === 'dimension' && ent.xdata?.paramName && hitTestEntity(ent, w.x, w.y, tolerance)) {
        setDimEditPopup({ x: sx, y: sy, value: ent.dimText || '0', paramName: ent.xdata.paramName });
        return;
      }
    }
  }, [view, entities]);

  // Feature 12: Right-click context menu
  const handleContextMenu = useCallback((e: React.MouseEvent<HTMLCanvasElement>) => {
    e.preventDefault();
    const canvas = canvasRef.current;
    if (!canvas) return;
    const rect = canvas.getBoundingClientRect();
    const sx = e.clientX - rect.left, sy = e.clientY - rect.top;
    const w = screenToWorld(sx, sy, view, rect.height);
    const tolerance = 30 / view.zoom;
    for (let i = entities.length - 1; i >= 0; i--) {
      const ent = entities[i];
      if (ent.xdata && hitTestEntity(ent, w.x, w.y, tolerance)) {
        setContextMenu({ x: sx, y: sy, entity: ent });
        return;
      }
    }
    setContextMenu(null);
  }, [view, entities]);

  const handleMouseMove = useCallback((e: React.MouseEvent<HTMLCanvasElement>) => {
    const canvas = canvasRef.current;
    if (!canvas) return;
    const rect = canvas.getBoundingClientRect();
    const sx = e.clientX - rect.left, sy = e.clientY - rect.top;
    setMouseScreen({ x: sx, y: sy });
    setMouseWorld(screenToWorld(sx, sy, view, rect.height));
    if (isPanning.current) {
      const dx = sx - panStart.current.x;
      const dy = -(sy - panStart.current.y);
      setView({ ...viewStart.current, panX: viewStart.current.panX + dx, panY: viewStart.current.panY + dy });
    }
    // Selection box drag tracking
    if (isSelecting.current) {
      selBoxEnd.current = { x: sx, y: sy };
    }
    // DD hover detection
    if (activeTool === 'dd') {
      const mouseWorld2 = screenToWorld(sx, sy, view, rect.height);
      let foundDim: string | null = null;
      const tolerance = 30 / view.zoom;
      for (let i = entities.length - 1; i >= 0; i--) {
        const ent = entities[i];
        if (ent.type === 'dimension' && ent.xdata?.paramName && hitTestEntity(ent, mouseWorld2.x, mouseWorld2.y, tolerance)) {
          foundDim = ent.id;
          break;
        }
      }
      setHoveredDimId(foundDim);
    } else if (hoveredDimId !== null) {
      setHoveredDimId(null);
    }
    // Snap detection
    if (showSnap && activeTool !== 'select' && activeTool !== 'pan') {
      const mw = screenToWorld(sx, sy, view, rect.height);
      const snap = findSnapPoint(entities, mw.x, mw.y, 50 / view.zoom);
      setSnapPoint(snap);
    } else {
      setSnapPoint(null);
    }
    // Rubber band preview with polar tracking
    if (isDrawing.current && ['line', 'rect', 'circle'].includes(activeTool)) {
      let mw = screenToWorld(sx, sy, view, rect.height);
      if (showSnap) {
        const snap = findSnapPoint(entities, mw.x, mw.y, 50 / view.zoom);
        if (snap) mw = { x: snap.x, y: snap.y };
      }
      let finalEnd: Point;
      if (showOrtho) {
        finalEnd = applyOrtho(drawStart.current, mw);
      } else if (activeTool === 'line') {
        const polar = applyPolarTracking(drawStart.current, mw);
        finalEnd = polar.point;
      } else {
        finalEnd = mw;
      }
      setPreviewEntity(createToolEntity(activeTool, drawStart.current, finalEnd));
    } else if (isDrawing.current && activeTool === 'dimension') {
      // 3-step dimension preview
      let mw = screenToWorld(sx, sy, view, rect.height);
      if (showSnap) {
        const snap = findSnapPoint(entities, mw.x, mw.y, 50 / view.zoom);
        if (snap) mw = { x: snap.x, y: snap.y };
      }
      if (dimStep.current === 1) {
        // Step 1→2: show line from first point to cursor
        let finalEnd = mw;
        if (showOrtho) finalEnd = applyOrtho(dimFirstPoint.current, finalEnd);
        else { const polar = applyPolarTracking(dimFirstPoint.current, finalEnd); finalEnd = polar.point; }
        const dist = Math.round(Math.sqrt((finalEnd.x - dimFirstPoint.current.x) ** 2 + (finalEnd.y - dimFirstPoint.current.y) ** 2));
        const isH = Math.abs(finalEnd.x - dimFirstPoint.current.x) > Math.abs(finalEnd.y - dimFirstPoint.current.y);
        setPreviewEntity({
          id: 'preview', type: 'dimension', layer: 'USER', color: THEME.accent, lineWidth: 0.8,
          x1: dimFirstPoint.current.x, y1: dimFirstPoint.current.y, x2: finalEnd.x, y2: finalEnd.y,
          dimText: `${dist}`, dimDir: isH ? 'h' : 'v', dimOffset: 0,
        });
      } else if (dimStep.current === 2) {
        // Step 2→3: show dimension at offset position
        const p1 = dimFirstPoint.current, p2 = dimSecondPoint.current;
        const isH = Math.abs(p2.x - p1.x) > Math.abs(p2.y - p1.y);
        const dimOffset = isH ? (mw.y - (p1.y + p2.y) / 2) : (mw.x - (p1.x + p2.x) / 2);
        const dist = Math.round(Math.sqrt((p2.x - p1.x) ** 2 + (p2.y - p1.y) ** 2));
        const dimX1 = isH ? Math.min(p1.x, p2.x) : p1.x + dimOffset;
        const dimY1 = isH ? p1.y + dimOffset : Math.min(p1.y, p2.y);
        const dimX2 = isH ? Math.max(p1.x, p2.x) : p1.x + dimOffset;
        const dimY2 = isH ? p1.y + dimOffset : Math.max(p1.y, p2.y);
        setPreviewEntity({
          id: 'preview', type: 'dimension', layer: 'USER', color: THEME.accent, lineWidth: 0.8,
          x1: dimX1, y1: dimY1, x2: dimX2, y2: dimY2,
          dimText: `${dist}`, dimDir: isH ? 'h' : 'v', dimOffset: 0,
        });
      }
    } else {
      setPreviewEntity(null);
    }
  }, [view, activeTool, entities, hoveredDimId, showSnap, showOrtho]);

  const handleMouseUp = useCallback((e?: React.MouseEvent<HTMLCanvasElement>) => {
    isPanning.current = false;
    // Complete selection box
    if (isSelecting.current) {
      isSelecting.current = false;
      const canvas = canvasRef.current;
      if (!canvas) return;
      const rect = canvas.getBoundingClientRect();
      const sx1 = selBoxStart.current.x, sy1 = selBoxStart.current.y;
      const sx2 = selBoxEnd.current.x, sy2 = selBoxEnd.current.y;
      // Only process if dragged more than 5px
      if (Math.abs(sx2 - sx1) > 5 || Math.abs(sy2 - sy1) > 5) {
        const w1 = screenToWorld(sx1, sy1, view, rect.height);
        const w2 = screenToWorld(sx2, sy2, view, rect.height);
        const minX = Math.min(w1.x, w2.x), maxX = Math.max(w1.x, w2.x);
        const minY = Math.min(w1.y, w2.y), maxY = Math.max(w1.y, w2.y);
        // Window (left→right) = only fully inside; Crossing (right→left) = touching
        const isWindow = sx2 > sx1; // left to right = window selection
        setEntities(prev => prev.map(ent => {
          const bb = getEntityBounds(ent);
          if (!bb) return ent;
          if (isWindow) {
            // Window: entity must be fully inside the box
            const inside = bb.minX >= minX && bb.maxX <= maxX && bb.minY >= minY && bb.maxY <= maxY;
            return { ...ent, selected: inside || (e?.shiftKey ? ent.selected : false) };
          } else {
            // Crossing: entity just needs to overlap the box
            const overlaps = bb.maxX >= minX && bb.minX <= maxX && bb.maxY >= minY && bb.minY <= maxY;
            return { ...ent, selected: overlaps || (e?.shiftKey ? ent.selected : false) };
          }
        }));
        const count = entities.filter(ent => {
          const bb = getEntityBounds(ent);
          if (!bb) return false;
          if (isWindow) return bb.minX >= minX && bb.maxX <= maxX && bb.minY >= minY && bb.maxY <= maxY;
          return bb.maxX >= minX && bb.minX <= maxX && bb.maxY >= minY && bb.minY <= maxY;
        }).length;
        setStatusInfo(`${count} nesne seçildi (${isWindow ? 'Window' : 'Crossing'})`);
      }
    }
  }, [view, entities]);

  const handleWheel = useCallback((e: React.WheelEvent<HTMLCanvasElement>) => {
    e.preventDefault();
    const canvas = canvasRef.current;
    if (!canvas) return;
    const rect = canvas.getBoundingClientRect();
    const sx = e.clientX - rect.left, sy = e.clientY - rect.top;
    const worldBefore = screenToWorld(sx, sy, view, rect.height);
    const factor = e.deltaY < 0 ? 1.15 : 1 / 1.15;
    const newZoom = Math.max(0.001, Math.min(50, view.zoom * factor));
    const newPanX = sx - worldBefore.x * newZoom;
    const newPanY = (rect.height - sy) - worldBefore.y * newZoom;
    setView({ panX: newPanX, panY: newPanY, zoom: newZoom });
  }, [view]);

  function createToolEntity(tool: ToolName, start: Point, end: Point): CadEntity | null {
    switch (tool) {
      case 'line': return { id: eid(), type: 'line', layer: 'USER', color: '#f1f5f9', lineWidth: 1, x1: start.x, y1: start.y, x2: end.x, y2: end.y, userDrawn: true };
      case 'rect': { const x = Math.min(start.x, end.x), y = Math.min(start.y, end.y); return { id: eid(), type: 'rect', layer: 'USER', color: '#f1f5f9', lineWidth: 1, x, y, w: Math.abs(end.x - start.x), h: Math.abs(end.y - start.y), userDrawn: true }; }
      case 'circle': { const r = Math.sqrt((end.x - start.x) ** 2 + (end.y - start.y) ** 2); return { id: eid(), type: 'circle', layer: 'USER', color: '#f1f5f9', lineWidth: 1, cx: start.x, cy: start.y, r, userDrawn: true }; }
      case 'dimension': return { id: eid(), type: 'dimension', layer: 'USER', color: C.dim, lineWidth: 0.8, x1: start.x, y1: start.y, x2: end.x, y2: end.y, dimText: `${Math.round(Math.sqrt((end.x - start.x) ** 2 + (end.y - start.y) ** 2))}`, dimDir: Math.abs(end.x - start.x) > Math.abs(end.y - start.y) ? 'h' : 'v', dimOffset: 0, userDrawn: true };
      case 'text': return { id: eid(), type: 'text', layer: 'USER', color: '#f1f5f9', lineWidth: 1, x: start.x, y: start.y, text: 'Metin', fontSize: 50, anchor: 'left', userDrawn: true };
      default: return null;
    }
  }

  // ─── Actions ───────────────────────────────────────────────────────────────
  const handleUndo = () => { if (undoStack.length === 0) return; setRedoStack(prev => [...prev, entities]); setEntities(undoStack[undoStack.length - 1]); setUndoStack(prev => prev.slice(0, -1)); };
  const handleRedo = () => { if (redoStack.length === 0) return; setUndoStack(prev => [...prev, entities]); setEntities(redoStack[redoStack.length - 1]); setRedoStack(prev => prev.slice(0, -1)); };
  const handleDelete = () => {
    const hasSelected = entities.some(e => e.selected);
    if (!hasSelected && entities.length === 0) return;
    setUndoStack(prev => [...prev, entities]);
    setRedoStack([]);
    if (hasSelected) {
      setEntities(prev => prev.filter(e => !e.selected));
      setSelectedEntity(null);
      setStatusInfo('');
    } else {
      setEntities(prev => prev.slice(0, -1));
    }
  };

  const handleZoomExtents = () => {
    if (entities.length === 0) return;
    let minX = Infinity, minY = Infinity, maxX = -Infinity, maxY = -Infinity;
    for (const e of entities) {
      if (e.x !== undefined && e.w !== undefined) { minX = Math.min(minX, e.x); minY = Math.min(minY, e.y!); maxX = Math.max(maxX, e.x + e.w); maxY = Math.max(maxY, e.y! + e.h!); }
      if (e.x1 !== undefined) { minX = Math.min(minX, e.x1, e.x2!); minY = Math.min(minY, e.y1!, e.y2!); maxX = Math.max(maxX, e.x1, e.x2!); maxY = Math.max(maxY, e.y1!, e.y2!); }
      if (e.cx !== undefined) { minX = Math.min(minX, e.cx - e.r!); minY = Math.min(minY, e.cy! - e.r!); maxX = Math.max(maxX, e.cx + e.r!); maxY = Math.max(maxY, e.cy! + e.r!); }
    }
    if (!isFinite(minX)) return;
    const canvas = canvasRef.current;
    if (!canvas) return;
    const rect = canvas.getBoundingClientRect();
    const padding = 80;
    const ww = maxX - minX, wh = maxY - minY;
    const zoom = Math.min((rect.width - 2 * padding) / ww, (rect.height - 2 * padding) / wh);
    const panX = padding - minX * zoom + ((rect.width - 2 * padding) - ww * zoom) / 2;
    const panY = padding - minY * zoom + ((rect.height - 2 * padding) - wh * zoom) / 2;
    setView({ panX, panY, zoom });
  };

  const handleExportDXF = () => { downloadFile(exportDXF(entities), 'asncad-drawing.dxf', 'application/dxf'); };
  const handleExportSVG = () => { downloadFile(exportSVG(entities, params.kuyuGen + 600, params.kuyuDer + 600), 'asncad-drawing.svg', 'image/svg+xml'); };

  const handleApplyParams = (newParams: ElevatorParams) => {
    setParams(newParams);
    setShowDialog(false);
    setTimeout(handleZoomExtents, 100);
  };

  // Feature 6: Apply dimension edit
  const handleDimEdit = (val: number) => {
    if (!dimEditPopup) return;
    setParams(prev => ({ ...prev, [dimEditPopup.paramName]: val }));
    setDimEditPopup(null);
  };

  // Feature 12: Apply context menu selection
  const handleContextSelect = (paramName: string, value: string) => {
    setParams(prev => ({ ...prev, [paramName]: value }));
  };

  // Feature 11: Command input handler
  const handleCommand = (cmd: string) => {
    const c = cmd.trim().toLowerCase();
    setCmdInput('');
    switch (c) {
      case 'param': setShowDialog(true); break;
      case 'kk': setActiveTab('kuyu-kesiti'); break;
      case 'kd': setActiveTab('kuyu-kesiti'); break; // KD uses same view with different label
      case 'tkaa': setActiveTab('tkaa'); break;
      case 'tkbb': setActiveTab('tkbb'); break;
      case 'md': setActiveTab('makine-dairesi'); break;
      case 'hesap': setActiveTab('hesap-raporu'); break;
      case 'dd': setActiveTool('dd'); break;
      case 'dall': {
        // Delete all user-drawn entities
        setUndoStack(prev => [...prev, entities]);
        setRedoStack([]);
        setEntities(prev => prev.filter(e => !e.userDrawn));
        break;
      }
      case 'ze': case 'zoom': handleZoomExtents(); break;
      case 'save': {
        const projectData = JSON.stringify({ params: params, version: '1.0' });
        localStorage.setItem('asncad-project', projectData);
        break;
      }
      case 'load': {
        const saved = localStorage.getItem('asncad-project');
        if (saved) {
          try {
            const data = JSON.parse(saved);
            if (data.params) setParams({ ...defaultParams(), ...data.params });
          } catch { /* ignore */ }
        }
        break;
      }
      case 'export-json': {
        const projectData = JSON.stringify({ params: params, version: '1.0' }, null, 2);
        downloadFile(projectData, 'asncad-project.json', 'application/json');
        break;
      }
      case 'konut': case 'preset-konut': {
        setParams(prev => ({ ...prev,
          binaKullanimTipi: 0, binaKisiSayisi: 80, hiz: 1.0, kabinP: 600,
          kuyuGen: 1700, kuyuDer: 1800, kuyuDibi: 1200, kuyuKafa: 3600,
          kapiGen: 800, kapiH: 2100, kapiTipi: 'KK-OT', motorGucu: 5.5,
          halatCapi: 8, halatSayisi: 4, katlar: [
            { katNo: -1, rumuz: 'B1', yukseklik: 2800, mimariKot: -2.80 },
            { katNo: 0, rumuz: 'Z', yukseklik: 3000, mimariKot: 0.00 },
            { katNo: 1, rumuz: '1', yukseklik: 2800, mimariKot: 3.00 },
            { katNo: 2, rumuz: '2', yukseklik: 2800, mimariKot: 5.80 },
            { katNo: 3, rumuz: '3', yukseklik: 2800, mimariKot: 8.60 },
            { katNo: 4, rumuz: '4', yukseklik: 2800, mimariKot: 11.40 },
          ],
        }));
        break;
      }
      case 'ofis': case 'preset-ofis': {
        setParams(prev => ({ ...prev,
          binaKullanimTipi: 1, binaKisiSayisi: 200, hiz: 1.6, kabinP: 800,
          kuyuGen: 2100, kuyuDer: 2500, kuyuDibi: 1500, kuyuKafa: 4200,
          kapiGen: 900, kapiH: 2100, kapiTipi: 'KK-OT', motorGucu: 11.0,
          halatCapi: 10, halatSayisi: 6, katlar: [
            { katNo: -1, rumuz: 'B1', yukseklik: 3200, mimariKot: -3.20 },
            { katNo: 0, rumuz: 'Z', yukseklik: 4000, mimariKot: 0.00 },
            { katNo: 1, rumuz: '1', yukseklik: 3500, mimariKot: 4.00 },
            { katNo: 2, rumuz: '2', yukseklik: 3500, mimariKot: 7.50 },
            { katNo: 3, rumuz: '3', yukseklik: 3500, mimariKot: 11.00 },
            { katNo: 4, rumuz: '4', yukseklik: 3500, mimariKot: 14.50 },
            { katNo: 5, rumuz: '5', yukseklik: 3500, mimariKot: 18.00 },
          ],
        }));
        break;
      }
      case 'hastane': case 'preset-hastane': {
        setParams(prev => ({ ...prev,
          binaKullanimTipi: 2, binaKisiSayisi: 300, hiz: 1.0, kabinP: 1200,
          kuyuGen: 2700, kuyuDer: 3000, kuyuDibi: 1500, kuyuKafa: 3800,
          kapiGen: 1300, kapiH: 2100, kapiTipi: 'KK-OT', motorGucu: 15.0,
          halatCapi: 12, halatSayisi: 6, asansorSayisi: 2,
          katlar: [
            { katNo: -1, rumuz: 'B1', yukseklik: 3500, mimariKot: -3.50 },
            { katNo: 0, rumuz: 'Z', yukseklik: 4000, mimariKot: 0.00 },
            { katNo: 1, rumuz: '1', yukseklik: 3500, mimariKot: 4.00 },
            { katNo: 2, rumuz: '2', yukseklik: 3500, mimariKot: 7.50 },
            { katNo: 3, rumuz: '3', yukseklik: 3500, mimariKot: 11.00 },
          ],
        }));
        break;
      }
      case 'otel': case 'preset-otel': {
        setParams(prev => ({ ...prev,
          binaKullanimTipi: 3, binaKisiSayisi: 250, hiz: 2.0, kabinP: 900,
          kuyuGen: 2200, kuyuDer: 2600, kuyuDibi: 1800, kuyuKafa: 4500,
          kapiGen: 900, kapiH: 2100, kapiTipi: 'KK-OT', motorGucu: 15.0,
          halatCapi: 10, halatSayisi: 6, panoramik: true,
          katlar: [
            { katNo: -1, rumuz: 'B1', yukseklik: 3200, mimariKot: -3.20 },
            { katNo: 0, rumuz: 'Lobi', yukseklik: 4500, mimariKot: 0.00 },
            { katNo: 1, rumuz: '1', yukseklik: 3200, mimariKot: 4.50 },
            { katNo: 2, rumuz: '2', yukseklik: 3200, mimariKot: 7.70 },
            { katNo: 3, rumuz: '3', yukseklik: 3200, mimariKot: 10.90 },
            { katNo: 4, rumuz: '4', yukseklik: 3200, mimariKot: 14.10 },
            { katNo: 5, rumuz: '5', yukseklik: 3200, mimariKot: 17.30 },
            { katNo: 6, rumuz: '6', yukseklik: 3200, mimariKot: 20.50 },
          ],
        }));
        break;
      }
      default: break;
    }
  };

  // ─── Keyboard shortcuts ────────────────────────────────────────────────────
  useEffect(() => {
    const handler = (e: KeyboardEvent) => {
      // Skip shortcuts when typing in input fields
      const tag = (e.target as HTMLElement)?.tagName;
      if (tag === 'INPUT' || tag === 'TEXTAREA' || tag === 'SELECT') return;

      // Ctrl shortcuts
      if (e.ctrlKey) {
        switch (e.key.toLowerCase()) {
          case 'z': e.preventDefault(); handleUndo(); return;
          case 'y': e.preventDefault(); handleRedo(); return;
          case 's': e.preventDefault(); handleCommand('save'); return;
          case 'o': e.preventDefault(); handleCommand('load'); return;
          case 'a': e.preventDefault(); setEntities(prev => prev.map(ent => ({ ...ent, selected: true }))); return; // Select all
          case 'c': e.preventDefault(); break; // Reserved for future copy
          case 'v': e.preventDefault(); break; // Reserved for future paste
        }
        return;
      }

      // Single key shortcuts (ZwCAD style)
      switch (e.key) {
        case 'Delete': handleDelete(); break;
        case 'Escape': setActiveTool('select'); isDrawing.current = false; dimStep.current = 0; setDimEditPopup(null); setContextMenu(null); setPreviewEntity(null); break;
        // Drawing tools
        case 'l': case 'L': setActiveTool('line'); break;
        case 'r': case 'R': setActiveTool('rect'); break;
        case 'c': case 'C': setActiveTool('circle'); break;
        case 'd': case 'D': setActiveTool('dimension'); break;
        case 't': case 'T': setActiveTool('text'); break;
        // Manipulation tools
        case 'm': case 'M': setActiveTool('move'); break;
        // View controls
        case 'g': case 'G': setShowGrid(g => !g); break;
        case 'F3': e.preventDefault(); setShowSnap(s => !s); break;
        case 'F8': e.preventDefault(); setShowOrtho(o => !o); break;
        case 'F7': e.preventDefault(); setShowGrid(g => !g); break;
        // Zoom
        case 'z': case 'Z': handleZoomExtents(); break;
        // Parameter dialog
        case 'p': case 'P': setShowDialog(true); break;
      }
    };
    window.addEventListener('keydown', handler);
    return () => window.removeEventListener('keydown', handler);
  }, [entities, undoStack, redoStack]);

  useEffect(() => {
    const t = setTimeout(handleZoomExtents, 200);
    return () => clearTimeout(t);
  }, []);

  // ─── New AutoCAD Web UI Layout ─────────────────────────────────────────────
  return (
    <div style={{ display: 'flex', flexDirection: 'column', height: '100vh', width: '100vw', background: THEME.bg, color: THEME.text, fontFamily: 'Arial, sans-serif', overflow: 'hidden' }}>
      {/* Quick Access Toolbar */}
      <QuickAccessToolbar
        onNew={() => handleCommand('new')}
        onSave={() => handleCommand('save')}
        onOpen={() => handleCommand('load')}
        onUndo={handleUndo}
        onRedo={handleRedo}
        onExportDXF={handleExportDXF}
        onExportSVG={handleExportSVG}
        onExportJSON={() => handleCommand('export-json')}
        canUndo={undoStack.length > 0}
        canRedo={redoStack.length > 0}
      />
      {/* Ribbon Toolbar */}
      <RibbonToolbar
        activeRibbonTab={activeRibbonTab}
        onTabChange={setActiveRibbonTab}
        activeTool={activeTool}
        onToolSelect={(tool) => setActiveTool(tool as any)}
        onPreset={(preset) => handleCommand(preset)}
        onOpenParams={() => setShowDialog(true)}
        showSnap={showSnap}
        showGrid={showGrid}
        showOrtho={showOrtho}
        onToggleSnap={() => setShowSnap(s => !s)}
        onToggleGrid={() => setShowGrid(g => !g)}
        onToggleOrtho={() => setShowOrtho(o => !o)}
        onZoomExtents={() => handleCommand('ze')}
        onDelete={() => { setEntities(prev => prev.filter(e => !e.selected)); }}
        onSelectAll={() => { setEntities(prev => prev.map(e => ({ ...e, selected: true }))); setStatusInfo(`${entities.length} nesne seçildi`); }}
        onDeselectAll={() => { setEntities(prev => prev.map(e => ({ ...e, selected: false }))); setSelectedEntity(null); setStatusInfo(''); }}
      />
      {/* Drawing Tab Bar */}
      <DrawingTabBar activeTab={activeTab} onTabChange={(tab) => setActiveTab(tab as any)} />
      {/* Middle area: Left Panel + Canvas */}
      <div style={{ display: 'flex', flex: 1, overflow: 'hidden' }}>
        <LeftPanel collapsed={leftPanelCollapsed} onToggle={() => setLeftPanelCollapsed(c => !c)}>
          <ObjectPropertiesPanel
            entity={entities.find(e => e.selected) || null}
            collapsed={objPropsCollapsed}
            onToggle={() => setObjPropsCollapsed(c => !c)}
          />
          <LayerPanelSection
            layers={layers}
            onToggleVisibility={(name) => setLayers(prev => prev.map(l => l.name === name ? { ...l, visible: !l.visible } : l))}
            onToggleLock={(name) => setLayers(prev => prev.map(l => l.name === name ? { ...l, locked: !l.locked } : l))}
            collapsed={layerSectionCollapsed}
            onToggle={() => setLayerSectionCollapsed(c => !c)}
          />
        </LeftPanel>
        {/* Canvas area */}
        <div style={{ flex: 1, position: 'relative', background: THEME.canvasBg }}>
          {activeTab === '3d-gorunum' ? (
            <Elevator3DViewer params={params} />
          ) : (
            <>
              <canvas
                ref={canvasRef}
                style={{ width: '100%', height: '100%', display: 'block', cursor: activeTool === 'select' ? 'crosshair' : activeTool === 'pan' || isPanning.current ? 'grab' : activeTool === 'dd' ? (hoveredDimId ? 'pointer' : 'help') : 'none' }}
                onMouseDown={handleMouseDown}
                onMouseMove={handleMouseMove}
                onMouseUp={handleMouseUp}
                onMouseLeave={handleMouseUp}
                onWheel={handleWheel}
                onDoubleClick={handleDoubleClick}
                onContextMenu={handleContextMenu}
              />
              {/* Dimension Edit Popup */}
              {dimEditPopup && (
                <DimEditPopup x={dimEditPopup.x} y={dimEditPopup.y} currentValue={dimEditPopup.value}
                  onApply={handleDimEdit} onClose={() => setDimEditPopup(null)} />
              )}
              {/* Context Menu */}
              {contextMenu && (
                <ContextMenu x={contextMenu.x} y={contextMenu.y} entity={contextMenu.entity}
                  onSelect={handleContextSelect} onClose={() => setContextMenu(null)} />
              )}
            </>
          )}
        </div>
      </div>
      {/* Command Line */}
      <CommandLineBar value={cmdInput} onChange={setCmdInput} onExecute={handleCommand} />
      {/* Status Bar */}
      <CadStatusBar
        mouseWorld={mouseWorld}
        activeTool={activeTool}
        entityCount={entities.length}
        showSnap={showSnap}
        showGrid={showGrid}
        showOrtho={showOrtho}
        onToggleSnap={() => setShowSnap(s => !s)}
        onToggleGrid={() => setShowGrid(g => !g)}
        onToggleOrtho={() => setShowOrtho(o => !o)}
        modelLayoutTab={modelLayoutTab}
        onModelLayoutChange={setModelLayoutTab}
        beyanYuk={beyan.yuk}
        kabinGen={kabinGen}
        kabinDer={kabinDer}
        kuyuGen={params.kuyuGen}
        kuyuDer={params.kuyuDer}
        statusInfo={statusInfo}
      />
      {/* Parameter Dialog */}
      {showDialog && (
        <ParameterDialog params={params} onApply={handleApplyParams} onClose={() => setShowDialog(false)} />
      )}
    </div>
  );
}
