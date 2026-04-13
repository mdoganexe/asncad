import { useState, useCallback, useEffect } from 'react';
import type { LiftParams, FloorParam } from '../core/types';

// ============================================================================
// BeyanYuk lookup table from original ascad.cs beyanqbul()
// ============================================================================
const BEYAN_TABLE: { min: number; max: number; yuk: number; kisi: number }[] = [
  { min: 0.49, max: 0.58, yuk: 180, kisi: 3 },
  { min: 0.60, max: 0.70, yuk: 225, kisi: 3 },
  { min: 0.79, max: 0.90, yuk: 300, kisi: 4 },
  { min: 0.90, max: 0.98, yuk: 320, kisi: 5 },
  { min: 0.98, max: 1.10, yuk: 375, kisi: 5 },
  { min: 1.10, max: 1.17, yuk: 400, kisi: 5 },
  { min: 1.17, max: 1.30, yuk: 450, kisi: 6 },
  { min: 1.31, max: 1.45, yuk: 525, kisi: 7 },
  { min: 1.45, max: 1.60, yuk: 600, kisi: 8 },
  { min: 1.60, max: 1.66, yuk: 630, kisi: 8 },
  { min: 1.59, max: 1.75, yuk: 675, kisi: 9 },
  { min: 1.73, max: 1.90, yuk: 750, kisi: 10 },
  { min: 1.90, max: 2.00, yuk: 800, kisi: 10 },
  { min: 1.87, max: 2.05, yuk: 825, kisi: 11 },
  { min: 2.01, max: 2.20, yuk: 900, kisi: 12 },
  { min: 2.15, max: 2.35, yuk: 975, kisi: 13 },
  { min: 2.35, max: 2.40, yuk: 1000, kisi: 13 },
  { min: 2.29, max: 2.50, yuk: 1050, kisi: 14 },
  { min: 2.43, max: 2.65, yuk: 1125, kisi: 15 },
  { min: 2.57, max: 2.80, yuk: 1200, kisi: 16 },
  { min: 2.80, max: 2.90, yuk: 1250, kisi: 16 },
  { min: 2.71, max: 2.95, yuk: 1275, kisi: 17 },
  { min: 2.85, max: 3.10, yuk: 1350, kisi: 18 },
  { min: 2.99, max: 3.25, yuk: 1425, kisi: 19 },
  { min: 3.13, max: 3.40, yuk: 1500, kisi: 20 },
  { min: 3.24, max: 3.45, yuk: 1575, kisi: 21 },
  { min: 3.36, max: 3.56, yuk: 1600, kisi: 22 },
  { min: 3.36, max: 3.68, yuk: 1650, kisi: 22 },
  { min: 3.47, max: 3.80, yuk: 1725, kisi: 23 },
  { min: 3.59, max: 3.92, yuk: 1800, kisi: 24 },
  { min: 3.70, max: 4.04, yuk: 1875, kisi: 25 },
  { min: 3.82, max: 4.16, yuk: 1950, kisi: 26 },
  { min: 3.87, max: 4.20, yuk: 2000, kisi: 26 },
  { min: 3.93, max: 4.32, yuk: 2025, kisi: 27 },
];

function beyanqbul(kabinGen: number, kabinDer: number): { yuk: number; kisi: number } {
  const alan = (kabinGen * kabinDer) / 1_000_000;
  for (const row of BEYAN_TABLE) {
    if (alan >= row.min && alan <= row.max) {
      return { yuk: row.yuk, kisi: row.kisi };
    }
  }
  return { yuk: 630, kisi: 8 };
}

// Parse rail string like "70x65x9" into {x, y, z}
function parseRailStr(s: string): { x: number; y: number; z: number } {
  const parts = s.split('x').map(Number);
  return { x: parts[0] || 70, y: parts[1] || 65, z: parts[2] || 9 };
}

// ============================================================================
// Cabin dimension formulas from original ascad.cs
// KabinDer = KuyuDer - KabinYEksen - 100
// KabinGen = KuyuGen - (AgrDuv + AgrGen + AgrU + 70 + 200) - ((KRX + KabinRayUcu) * 2)
// For ARKA: KabinGen = KuyuGen - ((KRX + KabinRayUcu) * 2) - 200
//           KabinDer = KuyuDer - KabinYEksen - (AgrDuv + AgrGen + AgrU + 70) - 100
// ============================================================================

function calculateCabinDimensions(p: LiftParams): { kabinGen: number; kabinDer: number } {
  const krx = p.krx || parseRailStr(p.kabinRayStr).x;
  const kabinRayUcu = p.kabinRayUcu || 15;
  
  if (p.yonKodu === 'ARKA') {
    const kabinGen = p.kuyuGenisligi - ((krx + kabinRayUcu) * 2) - 200;
    const kabinDer = p.kuyuDerinligi - p.kabinYEksen - (p.agrDuv + p.agrGen + p.agrU + 70) - 100;
    return { kabinGen: Math.max(kabinGen, 600), kabinDer: Math.max(kabinDer, 600) };
  }
  // SOL or SAG
  const kabinDer = p.kuyuDerinligi - p.kabinYEksen - 100;
  const kabinGen = p.kuyuGenisligi - (p.agrDuv + p.agrGen + p.agrU + 70 + 200) - ((krx + kabinRayUcu) * 2);
  return { kabinGen: Math.max(kabinGen, 600), kabinDer: Math.max(kabinDer, 600) };
}

// ============================================================================
// Rail options from original raymaster table
// ============================================================================
const RAIL_OPTIONS = [
  '50x50x5', '70x65x9', '89x62x16', '89x75x16',
  '100x75x16', '100x88x16', '127x88x16', '127x89x16',
];

const KAPI_TIP_OPTIONS = ['KK', 'YK'];
const OTO_KAPI_OPTIONS = ['OT', 'TK', 'MK', 'YK'];
const MENTESE_OPTIONS = ['SOL', 'SAG', 'ORTA'];
const REG_YER_OPTIONS = ['SOL', 'SAG', 'ARKA'];
const TAMPON_KABIN_OPTIONS = [
  'YTampon1#YTamponBK#YTamponKK',
  'YTampon2#YTamponBK#YTamponKK',
  'HTampon#HTamponBK#HTamponKK',
];
const TAMPON_AGR_OPTIONS = [
  'YTampon1#YTamponBK#YTamponKK',
  'YTampon2#YTamponBK#YTamponKK',
  'HTampon#HTamponBK#HTamponKK',
];

// ============================================================================
// Styles
// ============================================================================
const overlay: React.CSSProperties = {
  position: 'fixed', inset: 0, background: 'rgba(0,0,0,0.6)',
  display: 'flex', alignItems: 'center', justifyContent: 'center', zIndex: 9999,
};
const dialog: React.CSSProperties = {
  background: '#1e293b', border: '1px solid #475569', borderRadius: 8,
  width: 900, maxHeight: '90vh', display: 'flex', flexDirection: 'column',
  color: '#e2e8f0', fontFamily: 'system-ui, sans-serif', boxShadow: '0 25px 50px rgba(0,0,0,0.5)',
};
const header: React.CSSProperties = {
  display: 'flex', justifyContent: 'space-between', alignItems: 'center',
  padding: '12px 16px', borderBottom: '1px solid #334155', background: '#0f172a',
  borderRadius: '8px 8px 0 0',
};
const tabBar: React.CSSProperties = {
  display: 'flex', borderBottom: '1px solid #334155', background: '#0f172a',
};
const body: React.CSSProperties = {
  flex: 1, overflow: 'auto', padding: 16,
};
const footer: React.CSSProperties = {
  display: 'flex', justifyContent: 'flex-end', gap: 8, padding: '12px 16px',
  borderTop: '1px solid #334155', background: '#0f172a', borderRadius: '0 0 8px 8px',
};
const inputStyle: React.CSSProperties = {
  background: '#0f172a', color: '#e2e8f0', border: '1px solid #475569',
  borderRadius: 4, padding: '4px 8px', fontSize: 13, width: '100%', outline: 'none',
};
const selectStyle: React.CSSProperties = {
  ...inputStyle, cursor: 'pointer',
};
const labelStyle: React.CSSProperties = {
  fontSize: 12, color: '#94a3b8', marginBottom: 2, display: 'block',
};
const radioGroupStyle: React.CSSProperties = {
  display: 'flex', gap: 8, flexWrap: 'wrap',
};
const radioLabelStyle: React.CSSProperties = {
  display: 'flex', alignItems: 'center', gap: 4, fontSize: 13, cursor: 'pointer',
  padding: '4px 10px', borderRadius: 4, border: '1px solid #475569', background: '#0f172a',
};
const radioLabelActiveStyle: React.CSSProperties = {
  ...radioLabelStyle, borderColor: '#2563eb', background: '#1e3a5f', color: '#60a5fa',
};
const sectionTitle: React.CSSProperties = {
  fontSize: 14, fontWeight: 700, color: '#60a5fa', marginTop: 16, marginBottom: 8,
  borderBottom: '1px solid #334155', paddingBottom: 4,
};
const gridRow: React.CSSProperties = {
  display: 'grid', gridTemplateColumns: '1fr 1fr', gap: 12, marginBottom: 8,
};
const gridRow3: React.CSSProperties = {
  display: 'grid', gridTemplateColumns: '1fr 1fr 1fr', gap: 12, marginBottom: 8,
};
const checkboxStyle: React.CSSProperties = {
  display: 'flex', alignItems: 'center', gap: 6, fontSize: 13, cursor: 'pointer',
};
const btnPrimary: React.CSSProperties = {
  padding: '8px 24px', fontSize: 13, fontWeight: 600, cursor: 'pointer',
  background: '#2563eb', color: '#fff', border: 'none', borderRadius: 4,
};
const btnSecondary: React.CSSProperties = {
  padding: '8px 24px', fontSize: 13, fontWeight: 600, cursor: 'pointer',
  background: '#334155', color: '#94a3b8', border: 'none', borderRadius: 4,
};

// ============================================================================
// Component
// ============================================================================
interface ParameterDialogProps {
  open: boolean;
  params: LiftParams;
  onApply: (params: LiftParams) => void;
  onClose: () => void;
}

type TabKey = 'kuyu' | 'katlar' | 'bilesen' | 'firma' | 'hamd';

export default function ParameterDialog({ open, params, onApply, onClose }: ParameterDialogProps) {
  const [tab, setTab] = useState<TabKey>('kuyu');
  const [p, setP] = useState<LiftParams>({ ...params });
  const [floors, setFloors] = useState<FloorParam[]>([...params.floors]);

  useEffect(() => {
    if (open) {
      setP({ ...params });
      setFloors([...params.floors]);
    }
  }, [open, params]);

  const update = useCallback((key: keyof LiftParams, val: any) => {
    setP(prev => ({ ...prev, [key]: val }));
  }, []);

  const updateNum = useCallback((key: keyof LiftParams, val: string) => {
    const n = parseFloat(val);
    if (!isNaN(n)) setP(prev => ({ ...prev, [key]: n }));
  }, []);

  const handleApply = () => {
    // Calculate cabin dimensions using original formulas
    const { kabinGen, kabinDer } = calculateCabinDimensions(p);
    const { yuk, kisi } = beyanqbul(kabinGen, kabinDer);
    
    // Parse rail strings
    const kr = parseRailStr(p.kabinRayStr);
    const ar = parseRailStr(p.agrRayStr);
    
    const finalParams: LiftParams = {
      ...p,
      kabinGenisligi: kabinGen,
      kabinDerinligi: kabinDer,
      beyanYuk: yuk,
      beyanKisi: kisi,
      krx: kr.x, kry: kr.y, krz: kr.z,
      arx: ar.x, ary: ar.y, arz: ar.z,
      kabinRayFark: (p.tahrikKodu === 'MDDUZ') ? 250 : 100,
      floors,
    };
    onApply(finalParams);
  };

  if (!open) return null;

  const tabBtn = (key: TabKey, label: string) => (
    <button
      key={key}
      onClick={() => setTab(key)}
      style={{
        padding: '8px 16px', fontSize: 12, fontWeight: 600, cursor: 'pointer',
        background: tab === key ? '#2563eb' : 'transparent',
        color: tab === key ? '#fff' : '#94a3b8',
        border: 'none', borderBottom: tab === key ? '2px solid #2563eb' : '2px solid transparent',
      }}
    >{label}</button>
  );

  return (
    <div style={overlay} onClick={e => { if (e.target === e.currentTarget) onClose(); }}>
      <div style={dialog} onClick={e => e.stopPropagation()}>
        {/* Header */}
        <div style={header}>
          <span style={{ fontSize: 16, fontWeight: 700 }}>⚙️ ASNCAD Parametreler</span>
          <button onClick={onClose} style={{ background: 'none', border: 'none', color: '#94a3b8', fontSize: 20, cursor: 'pointer' }}>✕</button>
        </div>

        {/* Tabs */}
        <div style={tabBar}>
          {tabBtn('kuyu', '🏗️ Kuyu & Kabin')}
          {tabBtn('katlar', '🏢 Kat Bilgileri')}
          {tabBtn('bilesen', '🔧 Bileşenler')}
          {tabBtn('firma', '🏢 Firma Bilgileri')}
          {p.asansorTipi === 'HA' && tabBtn('hamd', '🔵 HAMD Bilgileri')}
        </div>

        {/* Body */}
        <div style={body}>
          {tab === 'kuyu' && <TabKuyu p={p} update={update} updateNum={updateNum} />}
          {tab === 'katlar' && <TabKatlar p={p} floors={floors} setFloors={setFloors} updateNum={updateNum} />}
          {tab === 'bilesen' && <TabBilesen p={p} update={update} updateNum={updateNum} />}
          {tab === 'firma' && <TabFirma p={p} update={update} />}
          {tab === 'hamd' && <TabHAMD p={p} update={update} updateNum={updateNum} />}
        </div>

        {/* Calculated preview */}
        <div style={{ padding: '8px 16px', background: '#0f172a', borderTop: '1px solid #334155', fontSize: 12, color: '#64748b', display: 'flex', gap: 16 }}>
          {(() => {
            const { kabinGen, kabinDer } = calculateCabinDimensions(p);
            const { yuk, kisi } = beyanqbul(kabinGen, kabinDer);
            return (
              <>
                <span>KabinGen: <b style={{ color: '#60a5fa' }}>{kabinGen}</b> mm</span>
                <span>KabinDer: <b style={{ color: '#60a5fa' }}>{kabinDer}</b> mm</span>
                <span>Alan: <b style={{ color: '#60a5fa' }}>{((kabinGen * kabinDer) / 1_000_000).toFixed(2)}</b> m²</span>
                <span>BeyanYük: <b style={{ color: '#f59e0b' }}>{yuk}</b> kg</span>
                <span>BeyanKişi: <b style={{ color: '#f59e0b' }}>{kisi}</b></span>
              </>
            );
          })()}
        </div>

        {/* Footer */}
        <div style={footer}>
          <button style={btnSecondary} onClick={onClose}>İptal</button>
          <button style={btnPrimary} onClick={handleApply}>✓ Uygula</button>
        </div>
      </div>
    </div>
  );
}

// ============================================================================
// Tab 1: Kuyu & Kabin
// ============================================================================
function TabKuyu({ p, update, updateNum }: { p: LiftParams; update: (k: keyof LiftParams, v: any) => void; updateNum: (k: keyof LiftParams, v: string) => void }) {
  return (
    <div>
      {/* Asansör Tipi */}
      <div style={sectionTitle}>Asansör Tipi</div>
      <div style={radioGroupStyle}>
        {(['EA', 'HA'] as const).map(t => (
          <label key={t} style={p.asansorTipi === t ? radioLabelActiveStyle : radioLabelStyle}>
            <input type="radio" name="asansorTipi" checked={p.asansorTipi === t} onChange={() => update('asansorTipi', t)} style={{ display: 'none' }} />
            {t === 'EA' ? '⚡ Elektrikli (EA)' : '💧 Hidrolik (HA)'}
          </label>
        ))}
      </div>

      {/* Tahrik Tipi */}
      {p.asansorTipi === 'EA' && (
        <>
          <div style={sectionTitle}>Tahrik Tipi</div>
          <div style={radioGroupStyle}>
            {([
              { key: 'DA', label: 'Dişli (DA)', icon: '⚙️' },
              { key: 'MDDUZ', label: 'MRL Düz (MDDUZ)', icon: '🔄' },
              { key: 'MDCAP', label: 'MRL Çapraz (MDCAP)', icon: '↗️' },
              { key: 'YA', label: 'Yüksek Hız (YA)', icon: '🚀' },
              { key: 'SD', label: 'Sonsuz Dişli (SD)', icon: '♾️' },
            ] as const).map(t => (
              <label key={t.key} style={p.tahrikKodu === t.key ? radioLabelActiveStyle : radioLabelStyle}>
                <input type="radio" name="tahrikKodu" checked={p.tahrikKodu === t.key} onChange={() => update('tahrikKodu', t.key)} style={{ display: 'none' }} />
                {t.icon} {t.label}
              </label>
            ))}
          </div>
        </>
      )}

      {/* Tahrik Yönü */}
      <div style={sectionTitle}>Tahrik Yönü (Ağırlık Konumu)</div>
      <div style={radioGroupStyle}>
        {([
          { key: 'SOL', label: '← SOL' },
          { key: 'SAG', label: 'SAĞ →' },
          { key: 'ARKA', label: '↑ ARKA' },
        ] as const).map(t => (
          <label key={t.key} style={p.yonKodu === t.key ? radioLabelActiveStyle : radioLabelStyle}>
            <input type="radio" name="yonKodu" checked={p.yonKodu === t.key} onChange={() => update('yonKodu', t.key)} style={{ display: 'none' }} />
            {t.label}
          </label>
        ))}
      </div>

      {/* Kuyu Boyutları */}
      <div style={sectionTitle}>Kuyu Boyutları</div>
      <div style={gridRow}>
        <Field label="Kuyu Genişliği (mm)" value={p.kuyuGenisligi} onChange={v => updateNum('kuyuGenisligi', v)} />
        <Field label="Kuyu Derinliği (mm)" value={p.kuyuDerinligi} onChange={v => updateNum('kuyuDerinligi', v)} />
      </div>
      <div style={gridRow}>
        <Field label="Kuyu Dibi (mm)" value={p.kuyuDibi} onChange={v => updateNum('kuyuDibi', v)} />
        <Field label="Kuyu Kafası (mm)" value={p.kuyuKafa} onChange={v => updateNum('kuyuKafa', v)} />
      </div>
      <div style={gridRow}>
        <Field label="Duvar Kalınlığı (mm)" value={p.duvarKal} onChange={v => updateNum('duvarKal', v)} />
        <Field label="Kabin Yüksekliği (mm)" value={p.kabinYuksekligi} onChange={v => updateNum('kabinYuksekligi', v)} />
      </div>

      {/* Kabin Eksen */}
      <div style={sectionTitle}>Kabin Eksen Ayarları</div>
      <div style={gridRow3}>
        <Field label="Kabin Y Eksen (mm)" value={p.kabinYEksen} onChange={v => updateNum('kabinYEksen', v)} />
        <Field label="Kabin Ray Ucu (mm)" value={p.kabinRayUcu} onChange={v => updateNum('kabinRayUcu', v)} />
        <Field label="Kızak Kalınlığı (mm)" value={p.kizakKalin} onChange={v => updateNum('kizakKalin', v)} />
      </div>

      {/* Panoramik */}
      <div style={{ marginTop: 12 }}>
        <label style={checkboxStyle}>
          <input type="checkbox" checked={p.panoramik} onChange={e => update('panoramik', e.target.checked)} />
          🪟 Panoramik Asansör
        </label>
      </div>
    </div>
  );
}

// ============================================================================
// Tab 2: Kat Bilgileri
// ============================================================================
function TabKatlar({ p, floors, setFloors, updateNum }: {
  p: LiftParams;
  floors: FloorParam[];
  setFloors: (f: FloorParam[]) => void;
  updateNum: (k: keyof LiftParams, v: string) => void;
}) {
  const addFloor = () => {
    const lastNo = floors.length > 0 ? Math.max(...floors.map(f => f.katNo)) + 1 : 0;
    setFloors([...floors, { katNo: lastNo, katRumuz: String(lastNo), katYuksekligi: p.katYuksekligi || 3000, mimariKot: '' }]);
  };

  const removeFloor = (idx: number) => {
    setFloors(floors.filter((_, i) => i !== idx));
  };

  const updateFloor = (idx: number, key: keyof FloorParam, val: any) => {
    const next = [...floors];
    (next[idx] as any)[key] = val;
    // Recalculate mimari kot
    recalcMimariKot(next, p);
    setFloors(next);
  };

  return (
    <div>
      <div style={sectionTitle}>Durak Ayarları</div>
      <div style={gridRow3}>
        <Field label="Durak Sayısı" value={p.durakSayisi} onChange={v => updateNum('durakSayisi', v)} />
        <Field label="İlk Durak No" value={p.ilkDurakNo} onChange={v => updateNum('ilkDurakNo', v)} />
        <Field label="Kat Yüksekliği (mm)" value={p.katYuksekligi} onChange={v => updateNum('katYuksekligi', v)} />
      </div>

      <div style={{ ...sectionTitle, display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
        <span>Kat Bilgileri Tablosu</span>
        <button onClick={addFloor} style={{ ...btnSecondary, padding: '4px 12px', fontSize: 11 }}>+ Kat Ekle</button>
      </div>

      <div style={{ overflowX: 'auto' }}>
        <table style={{ width: '100%', borderCollapse: 'collapse', fontSize: 12 }}>
          <thead>
            <tr style={{ background: '#0f172a' }}>
              <th style={thStyle}>Kat No</th>
              <th style={thStyle}>Rumuz</th>
              <th style={thStyle}>Yükseklik (mm)</th>
              <th style={thStyle}>Mimari Kot</th>
              <th style={thStyle}>Sil</th>
            </tr>
          </thead>
          <tbody>
            {floors.map((f, i) => (
              <tr key={i} style={{ borderBottom: '1px solid #334155' }}>
                <td style={tdStyle}>
                  <input style={{ ...inputStyle, width: 60 }} value={f.katNo} onChange={e => updateFloor(i, 'katNo', parseInt(e.target.value) || 0)} />
                </td>
                <td style={tdStyle}>
                  <input style={{ ...inputStyle, width: 80 }} value={f.katRumuz} onChange={e => updateFloor(i, 'katRumuz', e.target.value)} />
                </td>
                <td style={tdStyle}>
                  <input style={{ ...inputStyle, width: 100 }} value={f.katYuksekligi} onChange={e => updateFloor(i, 'katYuksekligi', parseInt(e.target.value) || 0)} />
                </td>
                <td style={tdStyle}>
                  <span style={{ color: '#64748b' }}>{f.mimariKot || '—'}</span>
                </td>
                <td style={tdStyle}>
                  <button onClick={() => removeFloor(i)} style={{ background: 'none', border: 'none', color: '#ef4444', cursor: 'pointer', fontSize: 14 }}>✕</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

const thStyle: React.CSSProperties = { padding: '6px 8px', textAlign: 'left', color: '#94a3b8', fontWeight: 600, borderBottom: '1px solid #475569' };
const tdStyle: React.CSSProperties = { padding: '4px 8px' };

// Recalculate mimari kot based on floor heights (from original grhes2/gridkatHhesapla)
function recalcMimariKot(floors: FloorParam[], p: LiftParams) {
  const sorted = [...floors].sort((a, b) => a.katNo - b.katNo);
  let cumHeight = 0;
  const zeroIdx = sorted.findIndex(f => f.katNo === 0);
  
  if (zeroIdx >= 0) {
    sorted[zeroIdx].mimariKot = '0.00';
    // Go up from zero
    cumHeight = 0;
    for (let i = zeroIdx + 1; i < sorted.length; i++) {
      cumHeight += sorted[i - 1].katYuksekligi;
      sorted[i].mimariKot = (cumHeight / 1000).toFixed(2);
    }
    // Go down from zero
    cumHeight = 0;
    for (let i = zeroIdx - 1; i >= 0; i--) {
      cumHeight -= sorted[i + 1].katYuksekligi;
      sorted[i].mimariKot = (cumHeight / 1000).toFixed(2);
    }
  } else {
    // No zero floor, start from first
    for (let i = 0; i < sorted.length; i++) {
      if (i === 0) {
        sorted[i].mimariKot = '0.00';
      } else {
        cumHeight += sorted[i - 1].katYuksekligi;
        sorted[i].mimariKot = (cumHeight / 1000).toFixed(2);
      }
    }
  }
  
  // Write back
  for (const sf of sorted) {
    const orig = floors.find(f => f.katNo === sf.katNo);
    if (orig) orig.mimariKot = sf.mimariKot;
  }
}

// ============================================================================
// Tab 3: Bileşenler (Components)
// ============================================================================
function TabBilesen({ p, update, updateNum }: { p: LiftParams; update: (k: keyof LiftParams, v: any) => void; updateNum: (k: keyof LiftParams, v: string) => void }) {
  return (
    <div>
      {/* Raylar */}
      <div style={sectionTitle}>Kabin Rayları</div>
      <div style={gridRow}>
        <div>
          <label style={labelStyle}>Kabin Ray Str</label>
          <select style={selectStyle} value={p.kabinRayStr} onChange={e => update('kabinRayStr', e.target.value)}>
            {RAIL_OPTIONS.map(r => <option key={r} value={r}>{r}</option>)}
          </select>
        </div>
        <div>
          <label style={labelStyle}>Ağırlık Ray Str</label>
          <select style={selectStyle} value={p.agrRayStr} onChange={e => update('agrRayStr', e.target.value)}>
            {RAIL_OPTIONS.map(r => <option key={r} value={r}>{r}</option>)}
          </select>
        </div>
      </div>

      {/* Kapı */}
      <div style={sectionTitle}>Kapı</div>
      <div style={gridRow3}>
        <Field label="Kapı Genişliği (mm)" value={p.kapiGenisligi} onChange={v => updateNum('kapiGenisligi', v)} />
        <div>
          <label style={labelStyle}>Kapı Tipi</label>
          <div style={{ display: 'flex', gap: 4 }}>
            <select style={{ ...selectStyle, flex: 1 }} value={p.kapiTipi.split('-')[0] || 'KK'} onChange={e => update('kapiTipi', e.target.value + '-' + (p.kapiTipi.split('-')[1] || 'OT'))}>
              {KAPI_TIP_OPTIONS.map(t => <option key={t} value={t}>{t}</option>)}
            </select>
            <select style={{ ...selectStyle, flex: 1 }} value={p.kapiTipi.split('-')[1] || 'OT'} onChange={e => update('kapiTipi', (p.kapiTipi.split('-')[0] || 'KK') + '-' + e.target.value)}>
              {OTO_KAPI_OPTIONS.map(t => <option key={t} value={t}>{t}</option>)}
            </select>
          </div>
        </div>
        <div>
          <label style={labelStyle}>Menteşe Tipi</label>
          <select style={selectStyle} value={p.mentese} onChange={e => update('mentese', e.target.value)}>
            {MENTESE_OPTIONS.map(m => <option key={m} value={m}>{m}</option>)}
          </select>
        </div>
      </div>
      <div style={gridRow}>
        <Field label="Kapı Yüksekliği (mm)" value={p.kapiH} onChange={v => updateNum('kapiH', v)} />
        <Field label="Eşik Kalınlığı (mm)" value={p.esikKalin} onChange={v => updateNum('esikKalin', v)} />
      </div>

      {/* Ağırlık */}
      <div style={sectionTitle}>Ağırlık (Karşı Ağırlık)</div>
      <div style={gridRow3}>
        <Field label="Ağırlık Genişliği (mm)" value={p.agrGen} onChange={v => updateNum('agrGen', v)} />
        <Field label="Ağırlık Duvar (mm)" value={p.agrDuv} onChange={v => updateNum('agrDuv', v)} />
        <Field label="Ağırlık U (mm)" value={p.agrU} onChange={v => updateNum('agrU', v)} />
      </div>
      <div style={gridRow}>
        <Field label="Ağırlık Uzunluk (mm)" value={p.agrUz} onChange={v => updateNum('agrUz', v)} />
        <Field label="Ağırlık Giriş (mm)" value={p.agrGir} onChange={v => updateNum('agrGir', v)} />
      </div>

      {/* Kasnak */}
      <div style={sectionTitle}>Kasnak</div>
      <div style={gridRow}>
        <Field label="Tahrik Kasnağı Çapı (mm)" value={p.tahrikKas} onChange={v => updateNum('tahrikKas', v)} />
        <Field label="Sapma Kasnağı Çapı (mm)" value={p.sapKas} onChange={v => updateNum('sapKas', v)} />
      </div>

      {/* Regülatör */}
      <div style={sectionTitle}>Regülatör & Tamponlar</div>
      <div style={gridRow3}>
        <div>
          <label style={labelStyle}>Regülatör Yeri</label>
          <select style={selectStyle} value={p.regYer} onChange={e => update('regYer', e.target.value)}>
            {REG_YER_OPTIONS.map(r => <option key={r} value={r}>{r}</option>)}
          </select>
        </div>
        <div>
          <label style={labelStyle}>Kabin Tamponu</label>
          <select style={selectStyle} value={p.kabinTamponu} onChange={e => update('kabinTamponu', e.target.value)}>
            {TAMPON_KABIN_OPTIONS.map(t => <option key={t} value={t}>{t.split('#')[0]}</option>)}
          </select>
        </div>
        <div>
          <label style={labelStyle}>Ağırlık Tamponu</label>
          <select style={selectStyle} value={p.agrTamponu} onChange={e => update('agrTamponu', e.target.value)}>
            {TAMPON_AGR_OPTIONS.map(t => <option key={t} value={t}>{t.split('#')[0]}</option>)}
          </select>
        </div>
      </div>

      {/* Checkboxes */}
      <div style={sectionTitle}>Ek Seçenekler</div>
      <div style={{ display: 'flex', gap: 24 }}>
        <label style={checkboxStyle}>
          <input type="checkbox" checked={p.dengeZinciri} onChange={e => update('dengeZinciri', e.target.checked)} />
          ⛓️ Denge Zinciri
        </label>
        <label style={checkboxStyle}>
          <input type="checkbox" checked={p.iskeleVar} onChange={e => update('iskeleVar', e.target.checked)} />
          🏗️ İskele Var
        </label>
      </div>
    </div>
  );
}

// ============================================================================
// Tab 4: Firma Bilgileri
// ============================================================================
function TabFirma({ p, update }: { p: LiftParams; update: (k: keyof LiftParams, v: any) => void }) {
  return (
    <div>
      <div style={sectionTitle}>Firma Bilgileri</div>
      <div style={gridRow}>
        <FieldStr label="Firma Adı" value={p.firmaAd} onChange={v => update('firmaAd', v)} />
        <FieldStr label="Marka" value={p.firmaMarka} onChange={v => update('firmaMarka', v)} />
      </div>
      <div style={{ marginBottom: 8 }}>
        <FieldStr label="Adres" value={p.firmaAdres} onChange={v => update('firmaAdres', v)} />
      </div>
      <div style={gridRow3}>
        <FieldStr label="Telefon" value={p.firmaTel} onChange={v => update('firmaTel', v)} />
        <FieldStr label="Fax" value={p.firmaFax} onChange={v => update('firmaFax', v)} />
        <FieldStr label="E-posta" value={p.firmaMail} onChange={v => update('firmaMail', v)} />
      </div>
      <div style={{ marginBottom: 8 }}>
        <FieldStr label="Yetkili" value={p.firmaYetkili} onChange={v => update('firmaYetkili', v)} />
      </div>

      <div style={sectionTitle}>Makina Mühendisi</div>
      <div style={gridRow}>
        <FieldStr label="Adı Soyadı" value={p.mmAd} onChange={v => update('mmAd', v)} />
        <FieldStr label="Oda Sicil No" value={p.mmOda} onChange={v => update('mmOda', v)} />
      </div>
      <div style={gridRow}>
        <FieldStr label="Belge Sicil No" value={p.mmBel} onChange={v => update('mmBel', v)} />
        <FieldStr label="SMM Belge No" value={p.mmSmm} onChange={v => update('mmSmm', v)} />
      </div>

      <div style={sectionTitle}>Elektrik Mühendisi</div>
      <div style={gridRow}>
        <FieldStr label="Adı Soyadı" value={p.emAd} onChange={v => update('emAd', v)} />
        <FieldStr label="Oda Sicil No" value={p.emOda} onChange={v => update('emOda', v)} />
      </div>
      <div style={gridRow}>
        <FieldStr label="Belge Sicil No" value={p.emBel} onChange={v => update('emBel', v)} />
        <FieldStr label="SMM Belge No" value={p.emSmm} onChange={v => update('emSmm', v)} />
      </div>
    </div>
  );
}

// ============================================================================
// Tab 5: HAMD Bilgileri (Hidrolik)
// ============================================================================
function TabHAMD({ p, update, updateNum }: { p: LiftParams; update: (k: keyof LiftParams, v: any) => void; updateNum: (k: keyof LiftParams, v: string) => void }) {
  return (
    <div>
      <div style={sectionTitle}>Hidrolik Ünite Boyutları</div>
      <div style={gridRow}>
        <Field label="HAMD Genişlik (mm)" value={p.hamdGen} onChange={v => updateNum('hamdGen', v)} />
        <Field label="HAMD Derinlik (mm)" value={p.hamdDer} onChange={v => updateNum('hamdDer', v)} />
      </div>

      <div style={sectionTitle}>Makine Yönü</div>
      <div style={radioGroupStyle}>
        {(['SOL', 'SAG'] as const).map(t => (
          <label key={t} style={p.makYon === t ? radioLabelActiveStyle : radioLabelStyle}>
            <input type="radio" name="makYon" checked={p.makYon === t} onChange={() => update('makYon', t)} style={{ display: 'none' }} />
            {t === 'SOL' ? '← SOL' : 'SAĞ →'}
          </label>
        ))}
      </div>

      <div style={sectionTitle}>Seyir Bilgileri</div>
      <div style={gridRow}>
        <Field label="Seyir Mesafesi (mm)" value={p.seyirMesafesi} onChange={v => updateNum('seyirMesafesi', v)} />
        <Field label="MD Taban-Tavan (mm)" value={p.mdTabTavan} onChange={v => updateNum('mdTabTavan', v)} />
      </div>
    </div>
  );
}

// ============================================================================
// Shared field components
// ============================================================================
function Field({ label, value, onChange }: { label: string; value: number; onChange: (v: string) => void }) {
  return (
    <div>
      <label style={labelStyle}>{label}</label>
      <input style={inputStyle} type="number" value={value} onChange={e => onChange(e.target.value)} />
    </div>
  );
}

function FieldStr({ label, value, onChange }: { label: string; value: string; onChange: (v: string) => void }) {
  return (
    <div>
      <label style={labelStyle}>{label}</label>
      <input style={inputStyle} type="text" value={value || ''} onChange={e => onChange(e.target.value)} />
    </div>
  );
}
