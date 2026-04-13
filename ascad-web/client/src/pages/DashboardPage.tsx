import { useState } from 'react'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { Link } from 'react-router-dom'
import { projectApi } from '../api/services'

export default function DashboardPage() {
  const [showNew, setShowNew] = useState(false)
  const [name, setName] = useState('')
  const [desc, setDesc] = useState('')
  const qc = useQueryClient()

  const { data: projects, isLoading } = useQuery({
    queryKey: ['projects'],
    queryFn: projectApi.getAll
  })

  const createMut = useMutation({
    mutationFn: projectApi.create,
    onSuccess: () => { qc.invalidateQueries({ queryKey: ['projects'] }); setShowNew(false); setName(''); setDesc('') }
  })

  const deleteMut = useMutation({
    mutationFn: projectApi.delete,
    onSuccess: () => qc.invalidateQueries({ queryKey: ['projects'] })
  })

  return (
    <div>
      <div className="flex-between" style={{ marginBottom: 24 }}>
        <h1>Projelerim</h1>
        <button className="btn-primary" onClick={() => setShowNew(!showNew)}>+ Yeni Proje</button>
      </div>

      {showNew && (
        <div className="card" style={{ marginBottom: 24 }}>
          <h3 style={{ marginBottom: 12 }}>Yeni Proje Oluştur</h3>
          <div className="grid grid-2" style={{ marginBottom: 12 }}>
            <div><label>Proje Adı</label><input value={name} onChange={e => setName(e.target.value)} placeholder="Örn: Konut Projesi A" /></div>
            <div><label>Açıklama</label><input value={desc} onChange={e => setDesc(e.target.value)} placeholder="Opsiyonel" /></div>
          </div>
          <div className="flex">
            <button className="btn-primary" onClick={() => createMut.mutate({ projectName: name, description: desc || undefined })} disabled={!name}>Oluştur</button>
            <button className="btn-secondary" onClick={() => setShowNew(false)}>İptal</button>
          </div>
        </div>
      )}

      {isLoading ? <p>Yükleniyor...</p> : (
        <div className="grid grid-3">
          {projects?.map(p => (
            <div key={p.id} className="card">
              <div className="flex-between" style={{ marginBottom: 8 }}>
                <Link to={`/projects/${p.id}`}><h3>{p.projectName}</h3></Link>
                <span className={`tag ${p.status === 'Completed' ? 'tag-success' : 'tag-info'}`}>{p.status}</span>
              </div>
              {p.description && <p style={{ fontSize: 13, color: 'var(--text-light)', marginBottom: 8 }}>{p.description}</p>}
              <div className="flex-between" style={{ fontSize: 13, color: 'var(--text-light)' }}>
                <span>{p.liftCount} asansör</span>
                <span>{new Date(p.createdAt).toLocaleDateString('tr-TR')}</span>
              </div>
              <button className="btn-danger" style={{ marginTop: 12, fontSize: 12, padding: '4px 12px' }}
                onClick={() => { if (confirm('Silmek istediğinize emin misiniz?')) deleteMut.mutate(p.id) }}>Sil</button>
            </div>
          ))}
          {projects?.length === 0 && <p style={{ color: 'var(--text-light)' }}>Henüz proje yok. Yeni bir proje oluşturun.</p>}
        </div>
      )}
    </div>
  )
}
