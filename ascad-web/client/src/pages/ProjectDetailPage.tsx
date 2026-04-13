import { useState } from 'react'
import { useParams, Link } from 'react-router-dom'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { projectApi, liftApi } from '../api/services'
import type { CreateLiftRequest, AsansorTipi, TahrikKodu, YonKodu } from '../types'
import BuildingTemplateSelector from '../components/BuildingTemplateSelector'
import LiftGroupPanel from '../components/LiftGroupPanel'

const defaultLift: Omit<CreateLiftRequest, 'projectId'> = {
  asansorTipi: 'EA', tahrikKodu: 'DA', yonKodu: 'SOL',
  kuyuGenisligi: 2000, kuyuDerinligi: 2500, kuyuDibi: 1500,
  kapiGenisligi: 900, kapiTipi: 'KK-OT', durakSayisi: 5, ilkDurakNo: 0,
  katYuksekligi: '3000', kabinRayStr: '70x65x9', agrRayStr: '50x50x5',
  panoramik: false, floors: []
}

export default function ProjectDetailPage() {
  const { id } = useParams<{ id: string }>()
  const [showNew, setShowNew] = useState(false)
  const [form, setForm] = useState(defaultLift)
  const qc = useQueryClient()

  const { data: project } = useQuery({ queryKey: ['project', id], queryFn: () => projectApi.getById(id!) })
  const { data: lifts, isLoading } = useQuery({ queryKey: ['lifts', id], queryFn: () => liftApi.getByProject(id!) })

  const createMut = useMutation({
    mutationFn: liftApi.create,
    onSuccess: () => { qc.invalidateQueries({ queryKey: ['lifts', id] }); setShowNew(false); setForm(defaultLift) }
  })

  const set = (key: string, val: string | number | boolean) =>
    setForm(prev => ({ ...prev, [key]: val }))

  const handleAssignGroup = (_liftId: string, _groupId: string, _position: number) => {
    // TODO: call API to update lift group assignment, then invalidate
    qc.invalidateQueries({ queryKey: ['lifts', id] })
  }

  return (
    <div>
      <div className="flex" style={{ marginBottom: 8 }}>
        <Link to="/" style={{ fontSize: 13 }}>← Projeler</Link>
      </div>
      <div className="flex-between" style={{ marginBottom: 24 }}>
        <div>
          <h1>{project?.projectName}</h1>
          {project?.description && <p style={{ color: 'var(--text-light)', fontSize: 14 }}>{project.description}</p>}
        </div>
        <button className="btn-primary" onClick={() => setShowNew(!showNew)}>+ Asansör Ekle</button>
      </div>

      {/* Building Template Selector */}
      <BuildingTemplateSelector />

      {showNew && (
        <div className="card" style={{ marginBottom: 24 }}>
          <h3 style={{ marginBottom: 16 }}>Yeni Asansör Tanımla</h3>
          <div className="grid grid-3" style={{ marginBottom: 16 }}>
            <div>
              <label>Asansör Tipi</label>
              <select value={form.asansorTipi} onChange={e => set('asansorTipi', e.target.value as AsansorTipi)}>
                <option value="EA">Elektrikli Asansör</option>
                <option value="HA">Hidrolik Asansör</option>
              </select>
            </div>
            <div>
              <label>Tahrik Kodu</label>
              <select value={form.tahrikKodu} onChange={e => set('tahrikKodu', e.target.value as TahrikKodu)}>
                <option value="DA">Direk Askı</option>
                <option value="MDDUZ">Makine Dairesiz Düz</option>
                <option value="MDCAP">Makine Dairesiz Çapraz</option>
                <option value="YA">Yarı Askı</option>
                <option value="SD">Sonsuz Dişli</option>
              </select>
            </div>
            <div>
              <label>Tahrik Yönü</label>
              <select value={form.yonKodu} onChange={e => set('yonKodu', e.target.value as YonKodu)}>
                <option value="SOL">Sol</option>
                <option value="SAG">Sağ</option>
                <option value="ARKA">Arka</option>
              </select>
            </div>
            <div><label>Kuyu Genişliği (mm)</label><input type="number" value={form.kuyuGenisligi} onChange={e => set('kuyuGenisligi', +e.target.value)} /></div>
            <div><label>Kuyu Derinliği (mm)</label><input type="number" value={form.kuyuDerinligi} onChange={e => set('kuyuDerinligi', +e.target.value)} /></div>
            <div><label>Kuyu Dibi (mm)</label><input type="number" value={form.kuyuDibi} onChange={e => set('kuyuDibi', +e.target.value)} /></div>
            <div><label>Kapı Genişliği (mm)</label><input type="number" value={form.kapiGenisligi} onChange={e => set('kapiGenisligi', +e.target.value)} /></div>
            <div><label>Durak Sayısı</label><input type="number" value={form.durakSayisi} onChange={e => set('durakSayisi', +e.target.value)} /></div>
            <div><label>Kat Yüksekliği (mm)</label><input value={form.katYuksekligi} onChange={e => set('katYuksekligi', e.target.value)} /></div>
          </div>
          <div className="flex">
            <button className="btn-primary" onClick={() => createMut.mutate({ ...form, projectId: id! })}>Asansör Ekle</button>
            <button className="btn-secondary" onClick={() => setShowNew(false)}>İptal</button>
          </div>
        </div>
      )}

      {/* Lift Group Panel */}
      {lifts && lifts.length > 0 && <LiftGroupPanel lifts={lifts} onAssignGroup={handleAssignGroup} />}

      {isLoading ? <p>Yükleniyor...</p> : (
        <div className="grid grid-2">
          {lifts?.map(l => (
            <Link key={l.id} to={`/lifts/${l.id}`} style={{ textDecoration: 'none', color: 'inherit' }}>
              <div className="card" style={{ cursor: 'pointer', transition: 'box-shadow 0.2s' }}>
                <div className="flex-between" style={{ marginBottom: 12 }}>
                  <h3>Asansör #{l.liftNumber}</h3>
                  <div className="flex">
                    {l.groupId && <span className="tag tag-success">Grup {l.groupId}</span>}
                    <span className="tag tag-info">{l.asansorTipi}</span>
                  </div>
                </div>
                <div className="grid grid-2" style={{ fontSize: 13, color: 'var(--text-light)' }}>
                  <div>Kuyu: {l.kuyuGenisligi} x {l.kuyuDerinligi} mm</div>
                  <div>Kabin: {l.kabinGenisligi} x {l.kabinDerinligi} mm</div>
                  <div>Beyan Yük: {l.beyanYuk} kg</div>
                  <div>Kişi: {l.beyanKisi}</div>
                  <div>Tahrik: {l.tahrikKodu}</div>
                  <div>Yön: {l.yonKodu}</div>
                </div>
              </div>
            </Link>
          ))}
          {lifts?.length === 0 && <p style={{ color: 'var(--text-light)' }}>Henüz asansör eklenmemiş.</p>}
        </div>
      )}
    </div>
  )
}
