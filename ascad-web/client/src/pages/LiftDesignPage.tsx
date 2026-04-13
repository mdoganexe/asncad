import { useState } from 'react'
import { useParams, Link } from 'react-router-dom'
import { useQuery, useMutation } from '@tanstack/react-query'
import { liftApi } from '../api/services'
import type { CalculationSummary } from '../types'
import ShaftPreview from '../components/ShaftPreview'
import FloorEditor from '../components/FloorEditor'
import ComponentSelector from '../components/ComponentSelector'
import DrawingViewer from '../components/DrawingViewer'
import CalculationPanel from '../components/CalculationPanel'
import ReportButton from '../components/ReportButton'

export default function LiftDesignPage() {
  const { id } = useParams<{ id: string }>()
  const [calcResult, setCalcResult] = useState<CalculationSummary | null>(null)

  const { data: lift, isLoading } = useQuery({
    queryKey: ['lift', id],
    queryFn: () => liftApi.getById(id!)
  })

  const calcMut = useMutation({
    mutationFn: () => liftApi.calculate(id!),
    onSuccess: (data) => setCalcResult(data)
  })

  if (isLoading || !lift) return <p>Yükleniyor...</p>

  return (
    <div>
      <div className="flex" style={{ marginBottom: 8 }}>
        <Link to={`/projects/${lift.projectId}`} style={{ fontSize: 13 }}>← Projeye Dön</Link>
      </div>
      <div className="flex-between" style={{ marginBottom: 24 }}>
        <h1>Asansör #{lift.liftNumber} - Detay</h1>
        <div className="flex">
          <ReportButton liftId={id!} />
          <Link to={`/lifts/${id}/cad`} style={{ padding: '10px 20px', fontSize: 14, fontWeight: 600, background: 'var(--primary)', color: 'white', borderRadius: 6, textDecoration: 'none' }}>
            📐 CAD Çizim
          </Link>
          <button className="btn-primary" onClick={() => calcMut.mutate()} disabled={calcMut.isPending}>
            {calcMut.isPending ? 'Hesaplanıyor...' : '🔢 Hesaplamaları Çalıştır'}
          </button>
        </div>
      </div>

      <div style={{ display: 'grid', gridTemplateColumns: '1fr 300px', gap: 24 }}>
        <div>
          {/* Teknik Bilgiler */}
          <div className="card" style={{ marginBottom: 24 }}>
            <h2 style={{ marginBottom: 16 }}>Teknik Bilgiler</h2>
            <div className="grid grid-3">
              <InfoItem label="Asansör Tipi" value={lift.asansorTipi === 'EA' ? 'Elektrikli' : 'Hidrolik'} />
              <InfoItem label="Tahrik Kodu" value={lift.tahrikKodu} />
              <InfoItem label="Tahrik Yönü" value={lift.yonKodu} />
              <InfoItem label="Kuyu Genişliği" value={`${lift.kuyuGenisligi} mm`} />
              <InfoItem label="Kuyu Derinliği" value={`${lift.kuyuDerinligi} mm`} />
              <InfoItem label="Kuyu Dibi" value={`${lift.kuyuDibi} mm`} />
              <InfoItem label="Kabin Genişliği" value={`${lift.kabinGenisligi} mm`} />
              <InfoItem label="Kabin Derinliği" value={`${lift.kabinDerinligi} mm`} />
              <InfoItem label="Kapı Genişliği" value={`${lift.kapiGenisligi} mm`} />
              <InfoItem label="Beyan Yükü" value={`${lift.beyanYuk} kg`} />
              <InfoItem label="Beyan Kişi" value={`${lift.beyanKisi} kişi`} />
              <InfoItem label="Durak Sayısı" value={`${lift.durakSayisi}`} />
            </div>
          </div>

          {/* Floor Editor */}
          <FloorEditor liftId={id!} initialFloors={lift.floors || []} />

          {/* Component Selector */}
          <ComponentSelector onSelect={(field, catalogId) => { /* TODO: update lift with catalog selection */ }} />

          {/* Calculation Panel */}
          <CalculationPanel data={calcResult} />

          {/* Drawing Viewer */}
          <DrawingViewer liftId={id!} />
        </div>

        {/* Kuyu Kesit Önizleme */}
        <div>
          <div className="card" style={{ position: 'sticky', top: 24 }}>
            <h3 style={{ marginBottom: 12 }}>Kuyu Kesiti (Önizleme)</h3>
            <ShaftPreview
              kuyuGen={lift.kuyuGenisligi}
              kuyuDer={lift.kuyuDerinligi}
              kabinGen={lift.kabinGenisligi}
              kabinDer={lift.kabinDerinligi}
              kapiGen={lift.kapiGenisligi}
              yonKodu={lift.yonKodu}
            />
          </div>
        </div>
      </div>
    </div>
  )
}

function InfoItem({ label, value }: { label: string; value: string }) {
  return (
    <div>
      <div style={{ fontSize: 12, color: 'var(--text-light)' }}>{label}</div>
      <div style={{ fontSize: 15, fontWeight: 600 }}>{value}</div>
    </div>
  )
}
