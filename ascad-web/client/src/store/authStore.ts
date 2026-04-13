import { create } from 'zustand'
import type { AuthResponse } from '../types'

interface AuthState {
  user: AuthResponse | null
  isAuthenticated: boolean
  login: (data: AuthResponse) => void
  logout: () => void
}

export const useAuthStore = create<AuthState>((set) => {
  const stored = localStorage.getItem('ascad_user')
  const user = stored ? JSON.parse(stored) as AuthResponse : null

  return {
    user,
    isAuthenticated: !!user,
    login: (data) => {
      localStorage.setItem('ascad_token', data.token)
      localStorage.setItem('ascad_user', JSON.stringify(data))
      set({ user: data, isAuthenticated: true })
    },
    logout: () => {
      localStorage.removeItem('ascad_token')
      localStorage.removeItem('ascad_user')
      set({ user: null, isAuthenticated: false })
    },
  }
})
