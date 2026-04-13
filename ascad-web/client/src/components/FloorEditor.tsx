import { useState, useEffect } from 'react'
import { useMutation } from '@tanstack/react-query'
import { floorApi } from '../api/services'
import type { FloorInfo, FloorCalculationResponse } from '../types'

interface Props {
  liftId: string
  initialFloors: FloorInfo[]
  onUpdate?: (result: FloorCalculationResponse) => void
}

export default function FloorEditor({ liftId, initialFloors, onUpdate }: Props) {
  const [floors, setFloors] = useState<FloorInfo[]>(initialFloors.length > 0 ? initialFloors : [
    { katNo: 0, katRumuz: 'Zemin', katYuksekligi: 3000, mimariKot: '0.00' }
  ])
  const [calcResult, setCalcResult] = useState<Omit<FloorCalculationResponse, 'floors'> | null>(null)

  useEffect(() => {
    if (initialFloors.length > 0) setFloors(initialFloors)
  }, [initialFloors])

  const saveMut = useMutation({
    mutationFn: () => floorApi.update(liftId, floors),
    onSuccess: (data) => {
      setFloors(data.floors)
      setCalcResult({ travelDistance: data.travelDistance, pitDepth: data.pitDepth, overheadClearance: data.overheadClearance })
      onUpdate?.(data)
    },
  })

  const updateFloor = (idx: number, key: keyof FloorInfo, val: string | number) => {
    setFloors(prev => prev.map((f, i) => i === idx ? { ...f, [key]: val } : f))
  }

  const addFloor = () => {
    const maxNo = floors.length > 0 ? Math.max(...floors.map(f => f.katNo)) : -1
    setFloors(prev => [...prev, { katNo: maxNo + 1, katRumuz: `Kat ${maxNo + 1}`, katYuksekligi: 3000, mimariKot: '' }])
  }

  const addBasement = () => {
    const minNo = floors.length > 0 ? Math.min(...floors.map(f => f.katNo)) : 1
    setFloors(prev => [{ katNo: minNo - 1, katRumuz: `B${Math.abs(minNo - 1)}`, katYuksekligi: 3000, mimariKot: '' }, ...prev])
  }

  const removeFloor = (idx: number) => {
    if (floors.length <= 1) return
    setFloors(prev => prev.filter((_, i) => i !== idx))
  }

  return (
    <div className="card" style={{ marginBottom: 24 }}>
      <div className="flex-between" style={{ marginBottom: 16 }}>
        <h2>Kat Bilgileri</h2>
        <div className="flex">
          <button className="btn-secondary" style={{ fontSize: 12, padding: '6px 12px' }} onClick={addBasement}>+ Bodrum</button>
          <button className="btn-secondary" style={{ fontSize: 12, padding: '6px 12px' }} onClick={addFloor}>+ Kat</button>
          <button className="btn-primary" style={{ fontSize: 12, padding: '6px 12px' }} onClick={() => saveMut.mutate()} disabled={saveMut.isPending}>
            {saveMut.isPending ? 'Kaydediliyor...' : 'Kaydet & Hesapla'}
          </button>
        </div>
      </div>

      <table>
        <thead>
          <tr><th>Kat No</th><th>Rumuz</th><th>Yükseklik (mm)</th><th>Mimari Kot</th><th style={{ width: 60 }}></th></tr>
        </thead>
        <tbody>
          {floors.map((f, i) => (
            <tr key={i}>
              <td><input type="number" value={f.katNo} onChange={e => updateFloor(i, 'katNo', +e.target.value)} style={{ width: 70 }} /></td>
              <td><input value={f.katRumuz} onChange={e => updateFloor(i, 'katRumuz', e.target.value)} /></td>
              <td><input type="number" value={f.katYuksekligi} onChange={e => updateFloor(i, 'katYuksekligi', +e.target.value)} style={{ width: 100 }} /></td>
              <td style={{ fontFamily: 'monospace' }}>{f.mimariKot || '-'}</td>
              <td><button className="btn-danger" style={{ padding: '2px 8px', fontSize: 11 }} onClick={() => removeFloor(i)}>✕</button></td>
            </tr>
          ))}
        </tbody>
      </table>

      {calcResult && (
        <div className="grid grid-3" style={{ marginTop: 16, padding: 12, background: '#f1f5f9', borderRadius: 8 }}>
          <div><label>Seyahat Mesafesi</label><span style={{ fontWeight: 600 }}>{calcResult.travelDistance} mm</span></div>
          <div><label>Kuyu Dibi</label><span style={{ fontWeight: 600 }}>{calcResult.pitDepth} mm</span></div>
          <div><label>Kuyu Kafası</label><span style={{ fontWeight: 600 }}>{calcResult.overheadClearance} mm</span></div>
        </div>
      )}
    </div>
  )
}
