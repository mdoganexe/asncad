import api from './client'
import type {
  AuthResponse, LoginRequest, RegisterRequest,
  Project, CreateProjectRequest,
  Lift, CreateLiftRequest, CalculationSummary,
  CompanyInfo, UpdateCompanyInfoRequest,
  CatalogItem, CreateCatalogItemRequest, UpdateCatalogItemRequest,
  BuildingTemplateResult, BuildingTemplateRequest,
  UsageStats, SubscriptionPlan,
  TenantSettings, UpdateSettingsRequest,
  FloorInfo, FloorCalculationResponse, DrawingType
} from '../types'

// Auth
export const authApi = {
  login: (data: LoginRequest) => api.post<AuthResponse>('/auth/login', data).then(r => r.data),
  register: (data: RegisterRequest) => api.post<AuthResponse>('/auth/register', data).then(r => r.data),
}

// Projects
export const projectApi = {
  getAll: () => api.get<Project[]>('/projects').then(r => r.data),
  getById: (id: string) => api.get<Project>(`/projects/${id}`).then(r => r.data),
  create: (data: CreateProjectRequest) => api.post<Project>('/projects', data).then(r => r.data),
  delete: (id: string) => api.delete(`/projects/${id}`),
}

// Lifts
export const liftApi = {
  getByProject: (projectId: string) => api.get<Lift[]>(`/lifts/project/${projectId}`).then(r => r.data),
  getById: (id: string) => api.get<Lift>(`/lifts/${id}`).then(r => r.data),
  create: (data: CreateLiftRequest) => api.post<Lift>('/lifts', data).then(r => r.data),
  calculate: (id: string) => api.post<CalculationSummary>(`/lifts/${id}/calculate`).then(r => r.data),
  delete: (id: string) => api.delete(`/lifts/${id}`),
}

// Company Info
export const companyInfoApi = {
  get: () => api.get<CompanyInfo>('/company-info').then(r => r.data),
  update: (data: UpdateCompanyInfoRequest) => api.put<CompanyInfo>('/company-info', data).then(r => r.data),
}

// Product Catalog
export const catalogApi = {
  getAll: (category?: string, modelName?: string) =>
    api.get<CatalogItem[]>('/catalog', { params: { category, modelName } }).then(r => r.data),
  getById: (id: string) => api.get<CatalogItem>(`/catalog/${id}`).then(r => r.data),
  create: (data: CreateCatalogItemRequest) => api.post<CatalogItem>('/catalog', data).then(r => r.data),
  update: (id: string, data: UpdateCatalogItemRequest) => api.put<CatalogItem>(`/catalog/${id}`, data).then(r => r.data),
  delete: (id: string) => api.delete(`/catalog/${id}`),
  getRails: () => api.get<CatalogItem[]>('/catalog/rails').then(r => r.data),
}

// Building Templates
export const templateApi = {
  getTypes: () => api.get<string[]>('/building-templates').then(r => r.data),
  apply: (data: BuildingTemplateRequest) =>
    api.post<BuildingTemplateResult>('/building-templates/apply', data).then(r => r.data),
}

// Drawings
export const drawingApi = {
  getSvg: (liftId: string, type: DrawingType) =>
    api.get<string>(`/lifts/${liftId}/drawings/${type}`).then(r => r.data),
  getDxf: (liftId: string, type: DrawingType) =>
    api.get(`/lifts/${liftId}/drawings/${type}/dxf`, { responseType: 'blob' }).then(r => r.data),
  // CAD JSON persistence
  saveCadDrawing: (liftId: string, type: string, json: any) =>
    api.post(`/drawings/${liftId}/${type}`, json).then(r => r.data),
  loadCadDrawing: (liftId: string, type: string) =>
    api.get(`/drawings/${liftId}/${type}`).then(r => r.data).catch(err => {
      if (err?.response?.status === 404) return null;
      throw err;
    }),
}

// Reports
export const reportApi = {
  generate: (liftId: string) =>
    api.post(`/lifts/${liftId}/report`, null, { responseType: 'blob' }).then(r => r.data),
}

// Floors
export const floorApi = {
  update: (liftId: string, floors: FloorInfo[]) =>
    api.put<FloorCalculationResponse>(`/lifts/${liftId}/floors`, { floors }).then(r => r.data),
}

// Subscription
export const subscriptionApi = {
  get: () => api.get<{ plan: SubscriptionPlan; usage: UsageStats }>('/subscription').then(r => r.data),
  changePlan: (planId: string) => api.put('/subscription/plan', { planId }).then(r => r.data),
}

// Settings
export const settingsApi = {
  get: () => api.get<TenantSettings>('/settings').then(r => r.data),
  update: (data: UpdateSettingsRequest) => api.put<TenantSettings>('/settings', data).then(r => r.data),
}
