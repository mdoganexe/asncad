import { useState } from 'react'
import { useQuery } from '@tanstack/react-query'
import { drawingApi } from '../api/services'
import type { DrawingType } from '../types'

interface Props { liftId: string }

const tabs: { type: DrawingType; label: string }[] = [
  { type: 'cross-section', label: 'Kuyu Kesiti' },
  { type: 'longitudinal', label: 'Boy Kesiti' },
  { type: 'machine-room', label: 'Makine Dairesi' },
  { type: 'cabin-plan', label: 'Kabin Planı' },
]

export default function DrawingViewer({ liftId }: Props) {
  const [activeTab, setActiveTab] = useState<DrawingType>('cross-section')

  const { data: svg, isLoading, error } = useQuery({
    queryKey: ['drawing', liftId, activeTab],
    queryFn: () => drawingApi.getSvg(liftId, activeTab),
  })

  const handleDxfExport = async () => {
    try {
      const blob = await drawingApi.getDxf(liftId, activeTab)
      const url = URL.createObjectURL(blob as Blob)
      const a = document.createElement('a')
      a.href = url; a.download = `${activeTab}-${liftId}.dxf`
      a.click(); URL.revokeObjectURL(url)
    } catch { alert('DXF dışa aktarım hatası.') }
  }

  return (
    <div className="card" style={{ marginBottom: 24 }}>
      <div className="flex-between" style={{ marginBottom: 16 }}>
        <h2>Teknik Çizimler</h2>
        <button className="btn-secondary" style={{ fontSize: 12, padding: '6px 12px' }} onClick={handleDxfExport}>
          📐 DXF İndir
        </button>
      </div>

      <div className="flex" style={{ marginBottom: 16 }}>
        {tabs.map(t => (
          <button key={t.type} onClick={() => setActiveTab(t.type)}
            style={{ padding: '6px 14px', borderRadius: 6, fontSize: 13, fontWeight: 600,
              background: activeTab === t.type ? 'var(--primary)' : 'var(--border)',
              color: activeTab === t.type ? 'white' : 'var(--text)' }}>
            {t.label}
          </button>
        ))}
      </div>

      <div style={{ minHeight: 300, background: '#f8fafc', borderRadius: 8, border: '1px solid var(--border)',
        display: 'flex', alignItems: 'center', justifyContent: 'center', overflow: 'auto' }}>
        {isLoading && <p>Çizim yükleniyor...</p>}
        {error && <p style={{ color: 'var(--danger)' }}>Çizim yüklenemedi.</p>}
        {svg && <div dangerouslySetInnerHTML={{ __html: svg }} style={{ padding: 16 }} />}
      </div>
    </div>
  )
}
