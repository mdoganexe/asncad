import { useState } from 'react'
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { catalogApi } from '../api/services'
import type { CatalogItem, CreateCatalogItemRequest } from '../types'

const categories = ['ray', 'tampon', 'motor', 'kapı', 'fren', 'halat']

export default function CatalogPage() {
  const [tab, setTab] = useState('ray')
  const [search, setSearch] = useState('')
  const [modal, setModal] = useState<{ mode: 'create' | 'edit'; item?: CatalogItem } | null>(null)
  const [form, setForm] = useState<CreateCatalogItemRequest>({ category: 'ray', modelName: '', specsJson: '{}' })
  const [deleteConfirm, setDeleteConfirm] = useState<string | null>(null)
  const qc = useQueryClient()

  const { data: items, isLoading } = useQuery({
    queryKey: ['catalog', tab],
    queryFn: () => catalogApi.getAll(tab),
  })

  const createMut = useMutation({
    mutationFn: () => catalogApi.create(form),
    onSuccess: () => { qc.invalidateQueries({ queryKey: ['catalog', tab] }); setModal(null) },
  })

  const updateMut = useMutation({
    mutationFn: () => catalogApi.update(modal!.item!.id, { modelName: form.modelName, description: form.description, specsJson: form.specsJson }),
    onSuccess: () => { qc.invalidateQueries({ queryKey: ['catalog', tab] }); setModal(null) },
  })

  const deleteMut = useMutation({
    mutationFn: (id: string) => catalogApi.delete(id),
    onSuccess: () => { qc.invalidateQueries({ queryKey: ['catalog', tab] }); setDeleteConfirm(null) },
    onError: () => alert('Bu öğe kullanımda olduğu için silinemez.'),
  })

  const openCreate = () => {
    setForm({ category: tab, modelName: '', specsJson: '{}' })
    setModal({ mode: 'create' })
  }

  const openEdit = (item: CatalogItem) => {
    setForm({ category: item.category, modelName: item.modelName, description: item.description, specsJson: item.specsJson })
    setModal({ mode: 'edit', item })
  }

  const filtered = items?.filter(i => !search || i.modelName.toLowerCase().includes(search.toLowerCase())) ?? []

  return (
    <div>
      <div className="flex-between" style={{ marginBottom: 24 }}>
        <h1>Ürün Kataloğu</h1>
        <button className="btn-primary" onClick={openCreate}>+ Yeni Öğe</button>
      </div>

      <div className="flex" style={{ marginBottom: 16 }}>
        {categories.map(c => (
          <button key={c} onClick={() => { setTab(c); setSearch('') }}
            style={{ padding: '8px 16px', borderRadius: 6, fontWeight: 600, fontSize: 13,
              background: tab === c ? 'var(--primary)' : 'var(--border)', color: tab === c ? 'white' : 'var(--text)' }}>
            {c.charAt(0).toUpperCase() + c.slice(1)}
          </button>
        ))}
      </div>

      <div style={{ marginBottom: 16, maxWidth: 300 }}>
        <input placeholder="Ara..." value={search} onChange={e => setSearch(e.target.value)} />
      </div>

      {isLoading ? <p>Yükleniyor...</p> : (
        <div className="card">
          <table>
            <thead>
              <tr><th>Model</th><th>Açıklama</th><th>Teknik Özellikler</th><th style={{ width: 120 }}>İşlem</th></tr>
            </thead>
            <tbody>
              {filtered.map(item => (
                <tr key={item.id}>
                  <td style={{ fontWeight: 600 }}>{item.modelName}</td>
                  <td>{item.description || '-'}</td>
                  <td style={{ fontSize: 12, fontFamily: 'monospace', maxWidth: 300, overflow: 'hidden', textOverflow: 'ellipsis' }}>{item.specsJson}</td>
                  <td>
                    <div className="flex">
                      <button className="btn-secondary" style={{ padding: '4px 10px', fontSize: 12 }} onClick={() => openEdit(item)}>Düzenle</button>
                      <button className="btn-danger" style={{ padding: '4px 10px', fontSize: 12 }} onClick={() => setDeleteConfirm(item.id)}>Sil</button>
                    </div>
                  </td>
                </tr>
              ))}
              {filtered.length === 0 && <tr><td colSpan={4} style={{ textAlign: 'center', color: 'var(--text-light)' }}>Öğe bulunamadı.</td></tr>}
            </tbody>
          </table>
        </div>
      )}

      {deleteConfirm && (
        <Overlay onClose={() => setDeleteConfirm(null)}>
          <h3 style={{ marginBottom: 16 }}>Silmek istediğinize emin misiniz?</h3>
          <div className="flex">
            <button className="btn-danger" onClick={() => deleteMut.mutate(deleteConfirm)}>Sil</button>
            <button className="btn-secondary" onClick={() => setDeleteConfirm(null)}>İptal</button>
          </div>
        </Overlay>
      )}

      {modal && (
        <Overlay onClose={() => setModal(null)}>
          <h3 style={{ marginBottom: 16 }}>{modal.mode === 'create' ? 'Yeni Öğe Ekle' : 'Öğeyi Düzenle'}</h3>
          <div className="grid" style={{ gap: 12, marginBottom: 16 }}>
            <div><label>Model Adı</label><input value={form.modelName} onChange={e => setForm(p => ({ ...p, modelName: e.target.value }))} /></div>
            <div><label>Açıklama</label><input value={form.description || ''} onChange={e => setForm(p => ({ ...p, description: e.target.value }))} /></div>
            <div><label>Teknik Özellikler (JSON)</label>
              <textarea value={form.specsJson} onChange={e => setForm(p => ({ ...p, specsJson: e.target.value }))}
                style={{ width: '100%', minHeight: 80, padding: 10, border: '1px solid var(--border)', borderRadius: 6, fontFamily: 'monospace', fontSize: 13 }} />
            </div>
          </div>
          <div className="flex">
            <button className="btn-primary" onClick={() => modal.mode === 'create' ? createMut.mutate() : updateMut.mutate()}>
              {modal.mode === 'create' ? 'Ekle' : 'Güncelle'}
            </button>
            <button className="btn-secondary" onClick={() => setModal(null)}>İptal</button>
          </div>
        </Overlay>
      )}
    </div>
  )
}

function Overlay({ children, onClose }: { children: React.ReactNode; onClose: () => void }) {
  return (
    <div onClick={onClose} style={{
      position: 'fixed', inset: 0, background: 'rgba(0,0,0,0.4)', display: 'flex',
      alignItems: 'center', justifyContent: 'center', zIndex: 1000
    }}>
      <div onClick={e => e.stopPropagation()} className="card" style={{ minWidth: 400, maxWidth: 500 }}>
        {children}
      </div>
    </div>
  )
}
