import { useRef, useEffect } from 'react'

interface Props {
  kuyuGen: number; kuyuDer: number
  kabinGen: number; kabinDer: number
  kapiGen: number; yonKodu: string
}

export default function ShaftPreview({ kuyuGen, kuyuDer, kabinGen, kabinDer, kapiGen, yonKodu }: Props) {
  const canvasRef = useRef<HTMLCanvasElement>(null)

  useEffect(() => {
    const canvas = canvasRef.current
    if (!canvas) return
    const ctx = canvas.getContext('2d')
    if (!ctx) return

    const W = canvas.width
    const H = canvas.height
    const padding = 30
    const maxDim = Math.max(kuyuGen, kuyuDer)
    const scale = (Math.min(W, H) - padding * 2) / maxDim

    ctx.clearRect(0, 0, W, H)
    ctx.save()
    ctx.translate(padding, padding)

    // Kuyu duvarları
    const kw = kuyuGen * scale
    const kd = kuyuDer * scale
    ctx.strokeStyle = '#334155'
    ctx.lineWidth = 3
    ctx.strokeRect(0, 0, kw, kd)

    // Kuyu boyut yazıları
    ctx.fillStyle = '#64748b'
    ctx.font = '11px sans-serif'
    ctx.textAlign = 'center'
    ctx.fillText(`${kuyuGen}`, kw / 2, -8)
    ctx.save()
    ctx.translate(-12, kd / 2)
    ctx.rotate(-Math.PI / 2)
    ctx.fillText(`${kuyuDer}`, 0, 0)
    ctx.restore()

    // Kabin
    const cabinW = kabinGen * scale
    const cabinD = kabinDer * scale
    const cabinX = (kw - cabinW) / 2
    const cabinY = kd - cabinD - 20 * scale
    ctx.fillStyle = '#dbeafe'
    ctx.fillRect(cabinX, cabinY, cabinW, cabinD)
    ctx.strokeStyle = '#2563eb'
    ctx.lineWidth = 2
    ctx.strokeRect(cabinX, cabinY, cabinW, cabinD)

    // Kabin boyut yazıları
    ctx.fillStyle = '#2563eb'
    ctx.font = 'bold 11px sans-serif'
    ctx.fillText(`${kabinGen}x${kabinDer}`, cabinX + cabinW / 2, cabinY + cabinD / 2 + 4)

    // Kapı
    const doorW = kapiGen * scale
    const doorX = cabinX + (cabinW - doorW) / 2
    ctx.fillStyle = '#fbbf24'
    ctx.fillRect(doorX, cabinY + cabinD - 2, doorW, 6)
    ctx.fillStyle = '#92400e'
    ctx.font = '10px sans-serif'
    ctx.fillText(`Kapı ${kapiGen}`, doorX + doorW / 2, cabinY + cabinD + 16)

    // Ağırlık yönü göstergesi
    ctx.fillStyle = '#dc2626'
    ctx.font = 'bold 10px sans-serif'
    const agrLabel = 'AGR'
    if (yonKodu === 'SOL') {
      ctx.fillText(agrLabel, 8, kd / 2)
    } else if (yonKodu === 'SAG') {
      ctx.fillText(agrLabel, kw - 24, kd / 2)
    } else {
      ctx.fillText(agrLabel, kw / 2, 16)
    }

    // Raylar (basit gösterim)
    ctx.strokeStyle = '#94a3b8'
    ctx.lineWidth = 1
    ctx.setLineDash([4, 4])
    // Sol ray
    ctx.beginPath()
    ctx.moveTo(cabinX - 8, cabinY - 10)
    ctx.lineTo(cabinX - 8, cabinY + cabinD + 10)
    ctx.stroke()
    // Sağ ray
    ctx.beginPath()
    ctx.moveTo(cabinX + cabinW + 8, cabinY - 10)
    ctx.lineTo(cabinX + cabinW + 8, cabinY + cabinD + 10)
    ctx.stroke()
    ctx.setLineDash([])

    ctx.restore()
  }, [kuyuGen, kuyuDer, kabinGen, kabinDer, kapiGen, yonKodu])

  return (
    <canvas
      ref={canvasRef}
      width={260}
      height={280}
      style={{ width: '100%', background: '#f8fafc', borderRadius: 8, border: '1px solid var(--border)' }}
    />
  )
}
