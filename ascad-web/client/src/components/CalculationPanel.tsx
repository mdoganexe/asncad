import type { CalculationSummary } from '../types'

interface Props { data: CalculationSummary | null }

export default function CalculationPanel({ data }: Props) {
  if (!data) return null

  return (
    <div className="card" style={{ marginBottom: 24 }}>
      <div className="flex-between" style={{ marginBottom: 16 }}>
        <h2>Hesaplama Sonuçları</h2>
        <div className="flex">
          <span className="tag tag-success">✓ {data.passedChecks} Uygun</span>
          {data.failedChecks > 0 && <span className="tag tag-danger">✗ {data.failedChecks} Uygun Değil</span>}
          <span className="tag tag-info">Toplam: {data.totalChecks}</span>
        </div>
      </div>
      <table>
        <thead>
          <tr>
            <th>Sıra</th><th>Parametre</th><th>Standart</th><th>Açıklama</th>
            <th>Formül Değer</th><th>Sonuç</th><th>Birim</th><th>Durum</th>
          </tr>
        </thead>
        <tbody>
          {data.results.map(r => (
            <tr key={r.sira} className={r.formulSonuc === 'UD' ? 'fail' : ''}>
              <td>{r.sira}</td>
              <td style={{ fontWeight: 600 }}>{r.parametre}</td>
              <td style={{ fontSize: 12 }}>{r.standart}</td>
              <td>{r.aciklama}</td>
              <td style={{ fontSize: 12, fontFamily: 'monospace' }}>{r.formulDeger}</td>
              <td style={{ fontWeight: 600, color: r.formulSonuc === 'UD' ? 'var(--danger)' : undefined }}>
                {r.formulSonuc}
              </td>
              <td>{r.birim}</td>
              <td>
                {r.standart === 'SORG' ? (
                  <span className={`tag ${r.formulSonuc === 'UY' ? 'tag-success' : 'tag-danger'}`}>
                    {r.formulSonuc === 'UY' ? '✓ Uygun' : '✗ Uygun Değil'}
                  </span>
                ) : <span className="tag tag-info">Değer</span>}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}
