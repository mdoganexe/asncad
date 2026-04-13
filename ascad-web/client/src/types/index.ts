// Enums
export type AsansorTipi = 'EA' | 'HA'
export type TahrikKodu = 'DA' | 'MDDUZ' | 'MDCAP' | 'YA' | 'SD' | 'RAMD'
export type YonKodu = 'SOL' | 'SAG' | 'ARKA'
export type DrawingType = 'cross-section' | 'longitudinal' | 'machine-room' | 'cabin-plan'

// Auth
export interface LoginRequest { email: string; password: string }
export interface RegisterRequest { email: string; password: string; fullName: string; companyName: string }
export interface AuthResponse { token: string; email: string; fullName: string; role: string; tenantId: string }

// Project
export interface Project {
  id: string; projectName: string; description?: string
  status: string; liftCount: number; createdAt: string; updatedAt?: string
}
export interface CreateProjectRequest { projectName: string; description?: string }

// Floor
export interface FloorInfo { katNo: number; katRumuz: string; katYuksekligi: number; mimariKot: string }
export interface FloorCalculationResponse {
  floors: FloorInfo[]; travelDistance: number; pitDepth: number; overheadClearance: number
}

// Lift
export interface Lift {
  id: string; projectId: string; liftNumber: number
  asansorTipi: string; tahrikKodu: string; yonKodu: string
  kuyuGenisligi: number; kuyuDerinligi: number; kuyuDibi: number; kuyuKafa: number
  kabinGenisligi: number; kabinDerinligi: number
  kapiGenisligi: number; kapiTipi: string
  beyanYuk: number; beyanKisi: number; durakSayisi: number
  kabinRayStr: string; agrRayStr: string; panoramik: boolean
  floors: FloorInfo[]; createdAt: string
  groupId?: string; groupPosition?: number
}
export interface CreateLiftRequest {
  projectId: string; asansorTipi: AsansorTipi; tahrikKodu: TahrikKodu; yonKodu: YonKodu
  kuyuGenisligi: number; kuyuDerinligi: number; kuyuDibi: number
  kapiGenisligi: number; kapiTipi: string; durakSayisi: number; ilkDurakNo: number
  katYuksekligi: string; kabinRayStr: string; agrRayStr: string; panoramik: boolean
  floors?: FloorInfo[]
  groupId?: string; groupPosition?: number
}

// Calculation
export interface CalculationResult {
  sira: number; parametre: string; standart: string; aciklama: string
  formul: string; formulDeger: string; formulSonuc: string; birim: string
}
export interface CalculationSummary {
  liftId: string; totalChecks: number; passedChecks: number; failedChecks: number
  results: CalculationResult[]
}

// Company Info
export interface CompanyInfo {
  id: string; tenantId: string; ad: string; adres: string; telefon: string; fax: string; email: string
  yetkili: string; marka: string; vergiDairesi: string; vergiNo: string
  onayliKurulusAd: string; onayliKurulusNo: string; sanayiTarih?: string; sanayiNo: string
  hybTarih?: string; hybNo: string
  makinaMuhAd: string; makinaMuhOdaSicil: string; makinaMuhBelge: string; makinaMuhSMM: string
  elektrikMuhAd: string; elektrikMuhOdaSicil: string; elektrikMuhBelge: string; elektrikMuhSMM: string
}
export interface UpdateCompanyInfoRequest { [key: string]: string | undefined }

// Catalog
export interface CatalogItem {
  id: string; category: string; modelName: string; description?: string; specsJson: string
}
export interface CreateCatalogItemRequest {
  category: string; modelName: string; description?: string; specsJson: string
}
export interface UpdateCatalogItemRequest {
  modelName?: string; description?: string; specsJson?: string
}

// Building Template
export interface BuildingTemplateRequest { buildingType: string; parameters: Record<string, number> }
export interface BuildingTemplateResult {
  buildingType: string; occupantCount: number; recommendedMinCabinWidth: number
  recommendedMinCabinDepth: number; recommendedMinLoadCapacity: number
  recommendedElevatorCount: number; requiresAdditionalCapacityReview: boolean
}

// Subscription
export interface SubscriptionPlan {
  id: string; name: string; maxProjects: number; maxUsersPerTenant: number
  maxPdfExportsPerMonth: number; monthlyPrice: number
}
export interface UsageStats {
  planName: string; projectCount: number; projectLimit: number
  userCount: number; userLimit: number; pdfExportCount: number; pdfExportLimit: number
}

// Settings
export interface TenantSettings {
  id: string; defaultKuyuGenisligi: number; defaultKuyuDerinligi: number; defaultKapiGenisligi: number
  defaultKatYuksekligi: number; defaultTahrikKodu: string; defaultKabinRayStr: string; defaultAgrRayStr: string
  language: string; defaultScaleFactor: number; dimensionTextSize: number; lineWeight: number
}
export interface UpdateSettingsRequest { [key: string]: string | number | undefined }
