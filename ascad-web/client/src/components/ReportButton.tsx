import { useState } from 'react'
import { reportApi } from '../api/services'

interface Props { liftId: string }

export default function ReportButton({ liftId }: Props) {
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  const handleGenerate = async () => {
    setLoading(true)
    setError(null)
    try {
      const blob = await reportApi.generate(liftId)
      const url = URL.createObjectURL(blob as Blob)
      const a = document.createElement('a')
      a.href = url; a.download = `rapor-${liftId}.pdf`
      a.click(); URL.revokeObjectURL(url)
    } catch (err: unknown) {
      const msg = (err as { response?: { status?: number } })?.response?.status === 403
        ? 'PDF dışa aktarım limitinize ulaştınız. Planınızı yükseltin.'
        : 'Rapor oluşturulurken hata oluştu.'
      setError(msg)
    } finally { setLoading(false) }
  }

  return (
    <div>
      <button className="btn-primary" onClick={handleGenerate} disabled={loading}>
        {loading ? 'Rapor Oluşturuluyor...' : '📄 PDF Rapor Oluştur'}
      </button>
      {error && <p style={{ color: 'var(--danger)', fontSize: 13, marginTop: 8 }}>{error}</p>}
    </div>
  )
}
