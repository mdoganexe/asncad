import { useState } from 'react'
import { useQuery, useMutation } from '@tanstack/react-query'
import { templateApi } from '../api/services'
import type { BuildingTemplateResult } from '../types'

const residentialUnits = ['1+1', '2+1', '3+1', '4+1', '5+1']
const paramLabels: Record<string, string> = { bedCount: 'Yatak Sayısı', studentCount: 'Öğrenci Sayısı', employeeCount: 'Çalışan Sayısı', carCount: 'Araç Sayısı', personCount: 'Kişi Sayısı' }

function getParamFields(type: string): string[] {
  if (type === 'Konut') return residentialUnits
  if (type === 'Otel' || type === 'Hastane') return ['bedCount']
  if (type === 'Okul') return ['studentCount']
  if (type === 'İş Merkezi') return ['employeeCount']
  if (type === 'Otopark') return ['carCount']
  if (type === 'Resmi') return ['personCount']
  return []
}

interface Props { onApply?: (result: BuildingTemplateResult) => void }

export default function BuildingTemplateSelector({ onApply }: Props) {
  const [buildingType, setBuildingType] = useState('')
  const [params, setParams] = useState<Record<string, number>>({})
  const [result, setResult] = useState<BuildingTemplateResult | null>(null)

  const { data: types } = useQuery({ queryKey: ['buildingTypes'], queryFn: templateApi.getTypes })

  const applyMut = useMutation({
    mutationFn: () => templateApi.apply({ buildingType, parameters: params }),
    onSuccess: (data) => { setResult(data); onApply?.(data) },
  })

  const handleTypeChange = (t: string) => {
    setBuildingType(t); setParams({}); setResult(null)
  }

  const fields = getParamFields(buildingType)

  return (
    <div className="card" style={{ marginBottom: 24 }}>
      <h2 style={{ marginBottom: 16 }}>Bina Tipi Şablonu</h2>
      <div className="grid grid-3" style={{ marginBottom: 16 }}>
        <div>
          <label>Bina Tipi</label>
          <select value={buildingType} onChange={e => handleTypeChange(e.target.value)}>
            <option value="">-- Seçiniz --</option>
            {types?.map(t => <option key={t} value={t}>{t}</option>)}
          </select>
        </div>
        {fields.map(f => (
          <div key={f}>
            <label>{paramLabels[f] || f}</label>
            <input type="number" value={params[f] || ''} onChange={e => setParams(p => ({ ...p, [f]: +e.target.value }))} />
          </div>
        ))}
      </div>
      {buildingType && (
        <button className="btn-primary" style={{ fontSize: 13 }} onClick={() => applyMut.mutate()} disabled={applyMut.isPending}>
          Şablonu Uygula
        </button>
      )}

      {result && (
        <div style={{ marginTop: 16, padding: 16, background: '#f1f5f9', borderRadius: 8 }}>
          <h3 style={{ marginBottom: 12 }}>Öneriler</h3>
          <div className="grid grid-3">
            <div><label>Kişi Sayısı</label><span style={{ fontWeight: 600 }}>{result.occupantCount}</span></div>
            <div><label>Min Kabin Genişliği</label><span style={{ fontWeight: 600 }}>{result.recommendedMinCabinWidth} mm</span></div>
            <div><label>Min Kabin Derinliği</label><span style={{ fontWeight: 600 }}>{result.recommendedMinCabinDepth} mm</span></div>
            <div><label>Min Yük Kapasitesi</label><span style={{ fontWeight: 600 }}>{result.recommendedMinLoadCapacity} kg</span></div>
            <div><label>Asansör Sayısı</label><span style={{ fontWeight: 600 }}>{result.recommendedElevatorCount}</span></div>
          </div>
          {result.requiresAdditionalCapacityReview && (
            <div className="tag tag-danger" style={{ marginTop: 12, padding: '8px 12px' }}>
              ⚠️ 200+ kişi — ek kapasite incelemesi gerekli
            </div>
          )}
        </div>
      )}
    </div>
  )
}
