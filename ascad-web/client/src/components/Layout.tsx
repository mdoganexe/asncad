import { Outlet, Link, useNavigate } from 'react-router-dom'
import { useAuthStore } from '../store/authStore'

const navLinks = [
  { to: '/', label: 'Projeler' },
  { to: '/catalog', label: 'Katalog' },
  { to: '/settings/company', label: 'Firma' },
  { to: '/settings', label: 'Ayarlar' },
  { to: '/subscription', label: 'Abonelik' },
]

export default function Layout() {
  const { user, logout } = useAuthStore()
  const navigate = useNavigate()

  const handleLogout = () => { logout(); navigate('/login') }

  return (
    <div>
      <header style={{
        background: '#1e293b', color: 'white', padding: '0 24px',
        height: 56, display: 'flex', alignItems: 'center', justifyContent: 'space-between'
      }}>
        <div className="flex">
          <Link to="/" style={{ color: 'white', fontSize: 20, fontWeight: 700 }}>
            🏗️ ASNCAD Web
          </Link>
          <span style={{ color: '#94a3b8', fontSize: 13 }}>Asansör Tasarım ve Hesaplama</span>
          <nav className="flex" style={{ marginLeft: 24 }}>
            {navLinks.map(l => (
              <Link key={l.to} to={l.to} style={{ color: '#cbd5e1', fontSize: 13, padding: '4px 8px' }}>
                {l.label}
              </Link>
            ))}
          </nav>
        </div>
        <div className="flex">
          <span style={{ color: '#94a3b8', fontSize: 13 }}>{user?.fullName}</span>
          <button onClick={handleLogout} style={{
            background: 'transparent', color: '#94a3b8', fontSize: 13, padding: '6px 12px'
          }}>Çıkış</button>
        </div>
      </header>
      <main style={{ maxWidth: 1200, margin: '24px auto', padding: '0 24px' }}>
        <Outlet />
      </main>
    </div>
  )
}
