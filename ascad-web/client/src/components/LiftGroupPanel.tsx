import { useState } from 'react'
import type { Lift } from '../types'

interface Props {
  lifts: Lift[]
  onAssignGroup: (liftId: string, groupId: string, position: number) => void
}

export default function LiftGroupPanel({ lifts, onAssignGroup }: Props) {
  const [groupId, setGroupId] = useState('A')

  const grouped = lifts.filter(l => l.groupId)
  const ungrouped = lifts.filter(l => !l.groupId)

  const groups = Array.from(new Set(grouped.map(l => l.groupId!)))
  const partitionThickness = 200 // mm

  const calcGroupWidth = (gid: string) => {
    const gLifts = grouped.filter(l => l.groupId === gid)
    if (gLifts.length === 0) return 0
    const sum = gLifts.reduce((s, l) => s + l.kuyuGenisligi, 0)
    return sum + (gLifts.length - 1) * partitionThickness
  }

  return (
    <div className="card" style={{ marginBottom: 24 }}>
      <h2 style={{ marginBottom: 16 }}>Asansör Grupları</h2>

      {groups.length > 0 && (
        <div style={{ marginBottom: 16 }}>
          {groups.map(gid => (
            <div key={gid} style={{ marginBottom: 12, padding: 12, background: '#f1f5f9', borderRadius: 8 }}>
              <div className="flex-between" style={{ marginBottom: 8 }}>
                <span style={{ fontWeight: 600 }}>Grup {gid}</span>
                <span className="tag tag-info">Toplam Kuyu: {calcGroupWidth(gid)} mm</span>
              </div>
              <div className="flex">
                {grouped.filter(l => l.groupId === gid).sort((a, b) => (a.groupPosition ?? 0) - (b.groupPosition ?? 0)).map(l => (
                  <span key={l.id} className="tag tag-success" style={{ padding: '4px 10px' }}>
                    #{l.liftNumber} (Pos: {l.groupPosition}) — {l.kuyuGenisligi}mm
                  </span>
                ))}
              </div>
            </div>
          ))}
        </div>
      )}

      {ungrouped.length > 0 && (
        <div>
          <h3 style={{ marginBottom: 8, fontSize: 14 }}>Gruplanmamış Asansörler</h3>
          <div className="flex" style={{ marginBottom: 12 }}>
            <label style={{ marginBottom: 0 }}>Grup ID:</label>
            <input value={groupId} onChange={e => setGroupId(e.target.value)} style={{ width: 60 }} />
          </div>
          <div className="grid grid-3">
            {ungrouped.map((l, i) => (
              <div key={l.id} style={{ padding: 8, border: '1px solid var(--border)', borderRadius: 6 }}>
                <div style={{ fontWeight: 600, marginBottom: 4 }}>Asansör #{l.liftNumber}</div>
                <div style={{ fontSize: 12, color: 'var(--text-light)', marginBottom: 8 }}>{l.kuyuGenisligi}mm kuyu</div>
                <button className="btn-secondary" style={{ fontSize: 11, padding: '4px 8px' }}
                  onClick={() => onAssignGroup(l.id, groupId, i + 1)}>
                  Gruba Ekle
                </button>
              </div>
            ))}
          </div>
        </div>
      )}

      {lifts.length === 0 && <p style={{ color: 'var(--text-light)' }}>Henüz asansör yok.</p>}
    </div>
  )
}
