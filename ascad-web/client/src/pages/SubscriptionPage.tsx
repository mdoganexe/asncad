import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query'
import { subscriptionApi } from '../api/services'

const plans = [
  { id: 'basic', name: 'Basic', price: 0, projects: 3, users: 1, exports: 10, color: '#64748b' },
  { id: 'professional', name: 'Professional', price: 49, projects: 25, users: 5, exports: 100, color: 'var(--primary)' },
  { id: 'enterprise', name: 'Enterprise', price: 149, projects: -1, users: 20, exports: -1, color: 'var(--success)' },
]

export default function SubscriptionPage() {
  const qc = useQueryClient()
  const { data, isLoading } = useQuery({ queryKey: ['subscription'], queryFn: subscriptionApi.get })
  const changeMut = useMutation({
    mutationFn: (planId: string) => subscriptionApi.changePlan(planId),
    onSuccess: () => qc.invalidateQueries({ queryKey: ['subscription'] }),
  })

  if (isLoading || !data) return <p>Yükleniyor...</p>
  const { usage } = data

  return (
    <div>
      <h1 style={{ marginBottom: 24 }}>Abonelik</h1>

      <div className="card" style={{ marginBottom: 24 }}>
        <h2 style={{ marginBottom: 16 }}>Mevcut Plan: {usage.planName}</h2>
        <div className="grid grid-3">
          <UsageBar label="Projeler" current={usage.projectCount} limit={usage.projectLimit} />
          <UsageBar label="Kullanıcılar" current={usage.userCount} limit={usage.userLimit} />
          <UsageBar label="PDF Dışa Aktarım" current={usage.pdfExportCount} limit={usage.pdfExportLimit} />
        </div>
      </div>

      <h2 style={{ marginBottom: 16 }}>Planlar</h2>
      <div className="grid grid-3">
        {plans.map(p => (
          <div key={p.id} className="card" style={{ borderTop: `3px solid ${p.color}` }}>
            <h3 style={{ marginBottom: 8 }}>{p.name}</h3>
            <div style={{ fontSize: 28, fontWeight: 700, marginBottom: 12 }}>
              {p.price === 0 ? 'Ücretsiz' : `₺${p.price}/ay`}
            </div>
            <div style={{ fontSize: 13, color: 'var(--text-light)', marginBottom: 16 }}>
              <div>{p.projects === -1 ? 'Sınırsız' : p.projects} proje</div>
              <div>{p.users} kullanıcı</div>
              <div>{p.exports === -1 ? 'Sınırsız' : p.exports} PDF/ay</div>
            </div>
            <button
              className={usage.planName === p.name ? 'btn-secondary' : 'btn-primary'}
              style={{ width: '100%' }}
              disabled={usage.planName === p.name || changeMut.isPending}
              onClick={() => changeMut.mutate(p.id)}
            >
              {usage.planName === p.name ? 'Mevcut Plan' : 'Yükselt'}
            </button>
          </div>
        ))}
      </div>
    </div>
  )
}

function UsageBar({ label, current, limit }: { label: string; current: number; limit: number }) {
  const pct = limit <= 0 ? 0 : Math.min((current / limit) * 100, 100)
  const isNear = pct >= 80
  return (
    <div>
      <div className="flex-between" style={{ marginBottom: 4 }}>
        <label>{label}</label>
        <span style={{ fontSize: 13, fontWeight: 600 }}>{current} / {limit <= 0 ? '∞' : limit}</span>
      </div>
      <div style={{ height: 8, background: 'var(--border)', borderRadius: 4, overflow: 'hidden' }}>
        <div style={{
          width: `${pct}%`, height: '100%', borderRadius: 4,
          background: isNear ? 'var(--danger)' : 'var(--primary)', transition: 'width 0.3s'
        }} />
      </div>
    </div>
  )
}
