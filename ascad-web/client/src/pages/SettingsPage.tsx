import { useState, useEffect } from 'react'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { settingsApi } from '../api/services'
import type { TenantSettings, UpdateSettingsRequest } from '../types'

export default function SettingsPage() {
  const [form, setForm] = useState<UpdateSettingsRequest>({})
  const [saved, setSaved] = useState(false)
  const qc = useQueryClient()

  const { data, isLoading } = useQuery({ queryKey: ['settings'], queryFn: settingsApi.get })

  useEffect(() => {
    if (data) {
      const { id, ...rest } = data
      setForm(rest as UpdateSettingsRequest)
    }
  }, [data])

  const mutation = useMutation({
    mutationFn: (d: UpdateSettingsRequest) => settingsApi.update(d),
    onSuccess: () => { qc.invalidateQueries({ queryKey: ['settings'] }); setSaved(true); setTimeout(() => setSaved(false), 3000) },
  })

  const setVal = (key: string, val: string | number) => setForm(prev => ({ ...prev, [key]: val }))

  if (isLoading) return <p>Yükleniyor...</p>

  return (
    <div>
      <div className="flex-between" style={{ marginBottom: 24 }}>
        <h1>Ayarlar</h1>
        <div className="flex">
          {saved && <span className="tag tag-success">✓ Kaydedildi</span>}
          <button className="btn-primary" onClick={() => mutation.mutate(form)} disabled={mutation.isPending}>
            {mutation.isPending ? 'Kaydediliyor...' : 'Kaydet'}
          </button>
        </div>
      </div>

      <div className="card" style={{ marginBottom: 24 }}>
        <h2 style={{ marginBottom: 16 }}>Varsayılan Asansör Parametreleri</h2>
        <div className="grid grid-3">
          <div><label>Kuyu Genişliği (mm)</label><input type="number" value={form.defaultKuyuGenisligi ?? ''} onChange={e => setVal('defaultKuyuGenisligi', +e.target.value)} /></div>
          <div><label>Kuyu Derinliği (mm)</label><input type="number" value={form.defaultKuyuDerinligi ?? ''} onChange={e => setVal('defaultKuyuDerinligi', +e.target.value)} /></div>
          <div><label>Kapı Genişliği (mm)</label><input type="number" value={form.defaultKapiGenisligi ?? ''} onChange={e => setVal('defaultKapiGenisligi', +e.target.value)} /></div>
          <div><label>Kat Yüksekliği (mm)</label><input type="number" value={form.defaultKatYuksekligi ?? ''} onChange={e => setVal('defaultKatYuksekligi', +e.target.value)} /></div>
          <div>
            <label>Tahrik Kodu</label>
            <select value={(form.defaultTahrikKodu as string) ?? 'DA'} onChange={e => setVal('defaultTahrikKodu', e.target.value)}>
              <option value="DA">Direk Askı</option><option value="MDDUZ">Makine Dairesiz Düz</option>
              <option value="MDCAP">Makine Dairesiz Çapraz</option><option value="YA">Yarı Askı</option>
              <option value="SD">Sonsuz Dişli</option>
            </select>
          </div>
          <div><label>Kabin Ray Profili</label><input value={(form.defaultKabinRayStr as string) ?? ''} onChange={e => setVal('defaultKabinRayStr', e.target.value)} /></div>
          <div><label>Ağırlık Ray Profili</label><input value={(form.defaultAgrRayStr as string) ?? ''} onChange={e => setVal('defaultAgrRayStr', e.target.value)} /></div>
        </div>
      </div>

      <div className="card" style={{ marginBottom: 24 }}>
        <h2 style={{ marginBottom: 16 }}>Dil</h2>
        <div style={{ maxWidth: 300 }}>
          <label>Arayüz Dili</label>
          <select value={(form.language as string) ?? 'tr'} onChange={e => setVal('language', e.target.value)}>
            <option value="tr">Türkçe</option><option value="en">English</option>
          </select>
        </div>
      </div>

      <div className="card">
        <h2 style={{ marginBottom: 16 }}>Çizim Tercihleri</h2>
        <div className="grid grid-3">
          <div><label>Ölçek Faktörü</label><input type="number" step="0.1" value={form.defaultScaleFactor ?? ''} onChange={e => setVal('defaultScaleFactor', +e.target.value)} /></div>
          <div><label>Yazı Boyutu (px)</label><input type="number" value={form.dimensionTextSize ?? ''} onChange={e => setVal('dimensionTextSize', +e.target.value)} /></div>
          <div><label>Çizgi Kalınlığı</label><input type="number" step="0.1" value={form.lineWeight ?? ''} onChange={e => setVal('lineWeight', +e.target.value)} /></div>
        </div>
      </div>
    </div>
  )
}
