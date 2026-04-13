import { useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { authApi } from '../api/services'
import { useAuthStore } from '../store/authStore'

export default function RegisterPage() {
  const [form, setForm] = useState({ email: '', password: '', fullName: '', companyName: '' })
  const [error, setError] = useState('')
  const [loading, setLoading] = useState(false)
  const login = useAuthStore((s) => s.login)
  const navigate = useNavigate()

  const set = (key: string, val: string) => setForm(prev => ({ ...prev, [key]: val }))

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setLoading(true); setError('')
    try {
      const res = await authApi.register(form)
      login(res)
      navigate('/')
    } catch { setError('Kayıt başarısız. Email zaten kullanılıyor olabilir.') }
    finally { setLoading(false) }
  }

  return (
    <div style={{ minHeight: '100vh', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
      <div className="card" style={{ width: 400 }}>
        <h1 style={{ textAlign: 'center', marginBottom: 8 }}>🏗️ Kayıt Ol</h1>
        <p style={{ textAlign: 'center', color: 'var(--text-light)', marginBottom: 24 }}>ASNCAD Web hesabı oluşturun</p>
        {error && <div style={{ background: '#fee2e2', color: '#dc2626', padding: 10, borderRadius: 6, marginBottom: 16, fontSize: 13 }}>{error}</div>}
        <form onSubmit={handleSubmit}>
          <div style={{ marginBottom: 12 }}>
            <label>Ad Soyad</label>
            <input value={form.fullName} onChange={e => set('fullName', e.target.value)} required />
          </div>
          <div style={{ marginBottom: 12 }}>
            <label>Firma Adı</label>
            <input value={form.companyName} onChange={e => set('companyName', e.target.value)} required />
          </div>
          <div style={{ marginBottom: 12 }}>
            <label>Email</label>
            <input type="email" value={form.email} onChange={e => set('email', e.target.value)} required />
          </div>
          <div style={{ marginBottom: 16 }}>
            <label>Şifre</label>
            <input type="password" value={form.password} onChange={e => set('password', e.target.value)} required minLength={6} />
          </div>
          <button type="submit" className="btn-primary" style={{ width: '100%' }} disabled={loading}>
            {loading ? 'Kaydediliyor...' : 'Kayıt Ol'}
          </button>
        </form>
        <p style={{ textAlign: 'center', marginTop: 16, fontSize: 13 }}>
          Zaten hesabınız var mı? <Link to="/login">Giriş Yap</Link>
        </p>
      </div>
    </div>
  )
}
