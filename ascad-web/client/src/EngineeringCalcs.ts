// ═══════════════════════════════════════════════════════════════════════════════
// ASNCAD Engineering Calculations — Faz 2-4
// Pure calculation functions, no React/UI dependencies
// ═══════════════════════════════════════════════════════════════════════════════

// ─── Shared Types ────────────────────────────────────────────────────────────
export interface KatBilgi { katNo: number; rumuz: string; yukseklik: number; mimariKot: number; }
export interface FirmaBilgi { firmaAdi: string; adres: string; tel: string; muhendis: string; }

export interface ElevatorParams {
  asansorTipi: 'EA' | 'HA'; tahrikKodu: string; yonKodu: 'SOL' | 'SAG' | 'ARKA';
  kuyuGen: number; kuyuDer: number; kuyuDibi: number; kuyuKafa: number; duvarKal: number;
  kapiGen: number; kapiH: number; kapiTipi: string;
  kabinYEksen: number; kabinRayUcu: number; kizakKalin: number; krx: number;
  agrGen: number; agrDuv: number; agrU: number; agrUz: number;
  tahrikKas: number; sapKas: number; katlar: KatBilgi[]; firma: FirmaBilgi;
  kabinRayTipi: string; agrRayTipi: string; tamponTipi: string; regYeri: number;
  kabinP: number; hiz: number; dengeOrani: number; halatCapi: number; halatSayisi: number;
  frenTipi: string; motorGucu: number; calisYuksek: number; mDaireH: number;
  asansorSayisi: number; araBolme: number; panoramik: boolean; olcek: number;
  konsolMesafe: number; kapiAgirlik: number; motorVerim: number;
  binaKisiSayisi: number; binaKullanimTipi: number;
  Xc: number; Yc: number; Xs: number; Ys: number; Xp: number; Yp: number;
  esikKalin: number; kasaGen: number; kasaDer: number; mentese: 'SOL' | 'SAG'; kapiFlip: boolean;
  kabinDuvar: number; kabinYanDuv: number; aydinMesafe: number;
  iskeleVar: boolean; dengeZinciri: boolean;
  hamdGen: number; hamdDer: number; hidrolikGen: number;
  kkOlcek: number; kdOlcek: number; mdOlcek: number; tkOlcek: number;
}

// ─── Data Tables ─────────────────────────────────────────────────────────────
export const RAIL_PROFILE_DETAILS: Record<string, { weight: number; ix: number; iy: number; wx: number; wy: number; A: number; c: number }> = {
  'T50/A': { weight: 3.7, ix: 7.1, iy: 7.1, wx: 3.2, wy: 2.8, A: 4.71, c: 12.5 },
  'T70/A': { weight: 5.5, ix: 22.9, iy: 7.7, wx: 6.5, wy: 3.5, A: 7.01, c: 16.0 },
  'T70/B': { weight: 5.5, ix: 22.9, iy: 7.7, wx: 6.5, wy: 3.5, A: 7.01, c: 16.0 },
  'T82/B': { weight: 9.5, ix: 52.0, iy: 11.0, wx: 11.0, wy: 5.0, A: 12.1, c: 19.0 },
  'T89/B': { weight: 12.3, ix: 79.7, iy: 14.5, wx: 14.5, wy: 6.0, A: 15.7, c: 22.0 },
  'T127/B': { weight: 22.3, ix: 280.0, iy: 30.0, wx: 32.0, wy: 10.0, A: 28.4, c: 31.5 },
};

export const OMEGA_TABLE: [number, number, number][] = [
  [20, 1.04, 1.02], [30, 1.09, 1.05], [40, 1.16, 1.09], [50, 1.26, 1.14],
  [60, 1.39, 1.21], [70, 1.56, 1.30], [80, 1.77, 1.42], [90, 2.02, 1.57],
  [100, 2.31, 1.75], [110, 2.64, 1.97], [120, 3.01, 2.22], [130, 3.42, 2.51],
  [140, 3.87, 2.84], [150, 4.36, 3.20], [160, 4.89, 3.60], [170, 5.46, 4.03],
  [180, 6.07, 4.50], [190, 6.72, 5.00], [200, 7.41, 5.54],
];

const ROPE_DB: Record<number, { fmin: number; weight: number }> = {
  6: { fmin: 22100, weight: 0.16 },
  8: { fmin: 39300, weight: 0.28 },
  10: { fmin: 61400, weight: 0.44 },
  12: { fmin: 88400, weight: 0.63 },
  14: { fmin: 120000, weight: 0.86 },
  16: { fmin: 157000, weight: 1.12 },
};

const BEYAN_TABLE: [number, number, number, number][] = [
  [0.49, 0.58, 180, 3], [0.60, 0.70, 225, 3], [0.79, 0.90, 300, 4],
  [0.90, 0.98, 320, 5], [0.98, 1.10, 375, 5], [1.10, 1.17, 400, 5],
  [1.17, 1.30, 450, 6], [1.31, 1.45, 525, 7], [1.45, 1.60, 600, 8],
  [1.60, 1.66, 630, 8], [1.59, 1.75, 675, 9], [1.73, 1.90, 750, 10],
  [1.90, 2.00, 800, 10], [1.87, 2.05, 825, 11], [2.01, 2.20, 900, 12],
  [2.15, 2.35, 975, 13], [2.35, 2.40, 1000, 13], [2.29, 2.50, 1050, 14],
  [2.43, 2.65, 1125, 15], [2.57, 2.80, 1200, 16], [2.80, 2.90, 1250, 16],
  [2.71, 2.95, 1275, 17], [2.85, 3.10, 1350, 18], [2.99, 3.25, 1425, 19],
  [3.13, 3.40, 1500, 20], [3.24, 3.45, 1575, 21], [3.36, 3.56, 1600, 22],
  [3.36, 3.68, 1650, 22], [3.47, 3.80, 1725, 23], [3.59, 3.92, 1800, 24],
  [3.70, 4.04, 1875, 25], [3.82, 4.16, 1950, 26], [3.87, 4.20, 2000, 26],
  [3.93, 4.32, 2025, 27],
];

const RAIL_COST: Record<string, number> = { 'T50/A': 180, 'T70/A': 280, 'T70/B': 280, 'T82/B': 450, 'T89/B': 580, 'T127/B': 950 };

// ─── Helper Functions ────────────────────────────────────────────────────────
export function hesaplaKabinBoyutlari(p: ElevatorParams): { kabinGen: number; kabinDer: number } {
  let kabinGen: number, kabinDer: number;
  if (p.yonKodu === 'SOL' || p.yonKodu === 'SAG') {
    kabinDer = p.kuyuDer - p.kabinYEksen - 100;
    kabinGen = p.kuyuGen - (p.agrDuv + p.agrGen + p.agrU + 70 + 200) - ((p.krx + p.kabinRayUcu) * 2);
  } else {
    kabinGen = p.kuyuGen - ((p.krx + p.kabinRayUcu) * 2) - 200;
    kabinDer = p.kuyuDer - p.kabinYEksen - (p.agrDuv + p.agrGen + p.agrU + 70) - 100;
  }
  return { kabinGen: Math.max(kabinGen, 400), kabinDer: Math.max(kabinDer, 400) };
}

export function beyanYukBul(kabinGenMM: number, kabinDerMM: number): { yuk: number; kisi: number } {
  const alan = (kabinGenMM * kabinDerMM) / 1_000_000;
  for (const [min, max, yuk, kisi] of BEYAN_TABLE) {
    if (alan >= min && alan <= max) return { yuk, kisi };
  }
  if (alan < 0.49) return { yuk: 100, kisi: 1 };
  return { yuk: 2500, kisi: 33 };
}

export function hesaplaSeyirMesafesi(katlar: KatBilgi[]): number {
  if (katlar.length < 2) return 0;
  let total = 0;
  for (let i = 0; i < katlar.length - 1; i++) total += katlar[i].yukseklik;
  return total;
}

export function hesaplaKuyuMesafesi(p: ElevatorParams): number {
  return p.kuyuDibi + hesaplaSeyirMesafesi(p.katlar) + p.kuyuKafa;
}

function interpolateOmega(narinlik: number, Rm: number): number {
  let omega370 = 1.0, omega520 = 1.0;
  if (narinlik <= OMEGA_TABLE[0][0]) { omega370 = OMEGA_TABLE[0][1]; omega520 = OMEGA_TABLE[0][2]; }
  else if (narinlik >= OMEGA_TABLE[OMEGA_TABLE.length - 1][0]) { omega370 = OMEGA_TABLE[OMEGA_TABLE.length - 1][1]; omega520 = OMEGA_TABLE[OMEGA_TABLE.length - 1][2]; }
  else {
    for (let i = 0; i < OMEGA_TABLE.length - 1; i++) {
      if (narinlik >= OMEGA_TABLE[i][0] && narinlik <= OMEGA_TABLE[i + 1][0]) {
        const t = (narinlik - OMEGA_TABLE[i][0]) / (OMEGA_TABLE[i + 1][0] - OMEGA_TABLE[i][0]);
        omega370 = OMEGA_TABLE[i][1] + t * (OMEGA_TABLE[i + 1][1] - OMEGA_TABLE[i][1]);
        omega520 = OMEGA_TABLE[i][2] + t * (OMEGA_TABLE[i + 1][2] - OMEGA_TABLE[i][2]);
        break;
      }
    }
  }
  return omega370 + ((omega520 - omega370) / 150) * (Rm - 370);
}

// ═══════════════════════════════════════════════════════════════════════════════
// EN81-1 FULL CALCULATION (existing, copied from AscadCadApp)
// ═══════════════════════════════════════════════════════════════════════════════
export interface EN81CalcResult {
  trafikH: number; trafikSe: number; trafikTr: number; trafikR: number; trafikL: number;
  Ga: number; Smotor: number; hesaplananMotorGucu: number; motorUygun: boolean;
  P1: number; P2: number; F1: number; F2: number; Fk: number; Fc: number;
  Q1: number; Q2: number; Fs: number;
  narinlik: number; omega: number; Wr: number;
  gerilmeK: number; gerilmeM: number; gerilmeA: number; gerilmeF: number; gerilmeZul: number;
  tetaX: number; tetaY: number; tetaZul: number;
  gerilmeM1: number; gerilmeA2: number; gerilmeZul1: number;
  agrGerilmeA1: number; agrGerilmeF1: number; agrTetaX1: number; agrTetaY1: number;
  yukGerilmeM: number; yukGerilmeF: number; yukTetaX: number; yukGerilmeA: number;
  kontrolSonuclari: { no: number; aciklama: string; uygun: boolean }[];
  halatKutlesi: number; Gh: number; karsiAgirlik: number; beyanYuk: number; kisiSayisi: number;
}

export function hesaplaEN81Full(p: ElevatorParams): EN81CalcResult {
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const beyan = beyanYukBul(kabinGen, kabinDer);
  const beyanYuk = beyan.yuk;
  const kisiSayisi = beyan.kisi;
  const seyirMesafesi = hesaplaSeyirMesafesi(p.katlar);
  const gn = 9.81;
  const KRA = 2; const Rm = 370; const St = 3; const St1 = 3.75;
  const E = 21000 * gn;
  const verim = p.motorVerim / 100;
  const q = 0.5;
  let darbe = 5;
  if (p.frenTipi === 'Kampana') darbe = 3;
  else if (p.frenTipi === 'Elektromanyetik') darbe = 2;

  const halatKutlesiPerM = (Math.PI * (p.halatCapi / 2000) ** 2) * 7850;
  const halatKutlesi = halatKutlesiPerM * seyirMesafesi / 1000 * p.halatSayisi;
  const Gh = halatKutlesi;
  const Ga = p.kabinP + p.kapiAgirlik + beyanYuk * q;
  const karsiAgirlik = Ga;
  const Smotor = (p.kabinP + p.kapiAgirlik + beyanYuk) - Ga - Gh;
  const hesaplananMotorGucu = (1 / verim) * (Math.abs(Smotor) * gn * p.hiz / 1000);
  const motorUygun = p.motorGucu >= hesaplananMotorGucu;

  const trafikH = seyirMesafesi / 1000;
  const trafikSe = trafikH / p.hiz;
  const trafikTr = trafikSe + 10;
  const trafikR = 3600 / trafikTr;
  const trafikL = trafikR * kisiSayisi;

  const P1 = 4 * gn * (p.kabinP + p.kapiAgirlik + beyanYuk + Gh);
  const P2 = 4 * gn * (p.kabinP + p.kapiAgirlik + Gh + q * beyanYuk);
  const F1 = (darbe * gn * (p.kabinP + p.kapiAgirlik + beyanYuk + Gh)) / KRA;
  const F2 = (darbe * gn * Ga) / KRA;

  const kabinGenM = kabinGen / 1000; const kabinDerM = kabinDer / 1000;
  const Xc = p.Xc !== 0 ? p.Xc / 1000 : kabinGenM / 2;
  const Yc = p.Yc !== 0 ? p.Yc / 1000 : kabinDerM / 2;
  const Xs = p.Xs !== 0 ? p.Xs / 1000 : kabinGenM / 2;
  const Ys = p.Ys !== 0 ? p.Ys / 1000 : 0;

  const dx = Math.abs(Xc - Xs); const dy = Math.abs(Yc - Ys);
  const Fk = F1; const Fc = F1 * 0.3;
  const lk = p.konsolMesafe / 1000;
  const Fx = Fk * dy + Fc * dx; const Fy = Fk * dx + Fc * dy;

  const rayProfil = RAIL_PROFILE_DETAILS[p.kabinRayTipi] || RAIL_PROFILE_DETAILS['T89/B'];
  const { ix: Ix, iy: Iy, wx: Wx, wy: Wy, A } = rayProfil;
  const k3 = 1;
  const eylemsizlikCapi = Math.sqrt(Ix / A);
  const narinlik = (lk * 100) / eylemsizlikCapi;
  const omega = interpolateOmega(narinlik, Rm);
  const Wr = omega;

  const M = p.kabinP + p.kapiAgirlik + beyanYuk;
  const gerilmeK = ((Fk + k3 * M * gn) * Wr) / (A * 100);
  const gerilmeM = (Fx * lk * 1000) / (4 * Wx * 1000) + (Fy * lk * 1000) / (4 * Wy * 1000);
  const gerilmeA = gerilmeK + gerilmeM;
  const gerilmeF = (Fc * lk * 1000) / (4 * Wy * 1000);
  const gerilmeZul = Rm / St;
  const tetaX = (0.7 * Fx * (lk * 1000) ** 3) / (48 * E * Iy * 10000);
  const tetaY = (0.7 * Fy * (lk * 1000) ** 3) / (48 * E * Ix * 10000);
  const tetaZul = 5;

  const F1n = (gn * (p.kabinP + p.kapiAgirlik + beyanYuk + Gh)) / KRA;
  const Fxn = F1n * dy; const Fyn = F1n * dx;
  const gerilmeM1 = (Fxn * lk * 1000) / (4 * Wx * 1000) + (Fyn * lk * 1000) / (4 * Wy * 1000);
  const gerilmeK1 = ((F1n + k3 * M * gn) * Wr) / (A * 100);
  const gerilmeA2 = gerilmeK1 + gerilmeM1;
  const gerilmeZul1 = Rm / St1;
  const tetaXn = (0.7 * Fxn * (lk * 1000) ** 3) / (48 * E * Iy * 10000);
  const tetaYn = (0.7 * Fyn * (lk * 1000) ** 3) / (48 * E * Ix * 10000);

  const agrProfil = RAIL_PROFILE_DETAILS[p.agrRayTipi] || RAIL_PROFILE_DETAILS['T50/A'];
  const agrF = (darbe * gn * Ga) / KRA;
  const agrFx = agrF * 0.3; const agrFy = agrF * 0.2;
  const agrGerilmeM = (agrFx * lk * 1000) / (4 * agrProfil.wx * 1000) + (agrFy * lk * 1000) / (4 * agrProfil.wy * 1000);
  const agrGerilmeK = (agrF * Wr) / (agrProfil.A * 100);
  const agrGerilmeA1 = agrGerilmeK + agrGerilmeM;
  const agrGerilmeF1 = (agrFy * lk * 1000) / (4 * agrProfil.wy * 1000);
  const agrTetaX1 = (0.7 * agrFx * (lk * 1000) ** 3) / (48 * E * agrProfil.iy * 10000);
  const agrTetaY1 = (0.7 * agrFy * (lk * 1000) ** 3) / (48 * E * agrProfil.ix * 10000);

  const yukF = (gn * (p.kabinP + p.kapiAgirlik + beyanYuk)) / KRA;
  const yukFx = yukF * dy; const yukFy = yukF * dx;
  const yukGerilmeM = (yukFx * lk * 1000) / (4 * Wx * 1000) + (yukFy * lk * 1000) / (4 * Wy * 1000);
  const yukGerilmeK = (yukF * Wr) / (A * 100);
  const yukGerilmeF = (yukFy * lk * 1000) / (4 * Wy * 1000);
  const yukTetaX = (0.7 * yukFx * (lk * 1000) ** 3) / (48 * E * Iy * 10000);
  const yukGerilmeA = yukGerilmeK + yukGerilmeM;

  const Q1 = P1 / KRA; const Q2 = P2 / KRA; const Fs = F1;

  const kontrolSonuclari: { no: number; aciklama: string; uygun: boolean }[] = [
    { no: 1, aciklama: 'Güvenlikli kullanma - Birleşik gerilme', uygun: gerilmeA <= gerilmeZul },
    { no: 2, aciklama: 'Güvenlikli kullanma - Basınç gerilmesi', uygun: gerilmeK <= gerilmeZul },
    { no: 3, aciklama: 'Güvenlikli kullanma - Ray boynu eğilmesi', uygun: gerilmeF <= gerilmeZul },
    { no: 4, aciklama: 'Güvenlikli kullanma - X ekseni eğilme miktarı', uygun: tetaX <= tetaZul },
    { no: 5, aciklama: 'Güvenlikli kullanma - Y ekseni eğilme miktarı', uygun: tetaY <= tetaZul },
    { no: 6, aciklama: 'Normal kullanma hareket - Birleşik gerilme', uygun: gerilmeA2 <= gerilmeZul1 },
    { no: 7, aciklama: 'Normal kullanma hareket - Basınç gerilmesi', uygun: gerilmeK1 <= gerilmeZul1 },
    { no: 8, aciklama: 'Normal kullanma hareket - Ray boynu eğilmesi', uygun: gerilmeM1 <= gerilmeZul1 },
    { no: 9, aciklama: 'Normal kullanma hareket - X ekseni eğilme', uygun: tetaXn <= tetaZul },
    { no: 10, aciklama: 'Normal kullanma hareket - Y ekseni eğilme', uygun: tetaYn <= tetaZul },
    { no: 11, aciklama: 'Karşı ağırlık ray - Birleşik gerilme', uygun: agrGerilmeA1 <= gerilmeZul },
    { no: 12, aciklama: 'Karşı ağırlık ray - Ray boynu eğilmesi', uygun: agrGerilmeF1 <= gerilmeZul },
    { no: 13, aciklama: 'Karşı ağırlık ray - X ekseni eğilme', uygun: agrTetaX1 <= tetaZul },
    { no: 14, aciklama: 'Karşı ağırlık ray - Y ekseni eğilme', uygun: agrTetaY1 <= tetaZul },
    { no: 15, aciklama: 'Normal kullanma yükleme - Birleşik gerilme', uygun: yukGerilmeA <= gerilmeZul1 },
    { no: 16, aciklama: 'Normal kullanma yükleme - Ray boynu eğilmesi', uygun: yukGerilmeF <= gerilmeZul1 },
    { no: 17, aciklama: 'Normal kullanma yükleme - X ekseni eğilme', uygun: yukTetaX <= tetaZul },
    { no: 18, aciklama: 'Normal kullanma yükleme - Basınç gerilmesi', uygun: yukGerilmeK <= gerilmeZul1 },
  ];

  return {
    trafikH, trafikSe, trafikTr, trafikR, trafikL,
    Ga, Smotor, hesaplananMotorGucu, motorUygun,
    P1, P2, F1, F2, Fk, Fc, Q1, Q2, Fs,
    narinlik, omega, Wr, gerilmeK, gerilmeM, gerilmeA, gerilmeF, gerilmeZul,
    tetaX, tetaY, tetaZul, gerilmeM1, gerilmeA2, gerilmeZul1,
    agrGerilmeA1, agrGerilmeF1, agrTetaX1, agrTetaY1,
    yukGerilmeM, yukGerilmeF, yukTetaX, yukGerilmeA,
    kontrolSonuclari, halatKutlesi, Gh, karsiAgirlik, beyanYuk, kisiSayisi,
  };
}

// ═══════════════════════════════════════════════════════════════════════════════
// 1. HYDRAULIC ELEVATOR CALCULATIONS (Faz 2)
// ═══════════════════════════════════════════════════════════════════════════════
export interface HydraulicCalcResult {
  pistonCapi: number;
  pistonBasinc: number;
  pistonStrok: number;
  silindirTipi: string;
  pompaDegeri: number;
  tankHacmi: number;
  hidrolikGucu: number;
  kontrolSonuclari: { no: number; aciklama: string; uygun: boolean }[];
}

export function hesaplaHidrolik(p: ElevatorParams): HydraulicCalcResult {
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const beyan = beyanYukBul(kabinGen, kabinDer);
  const beyanYuk = beyan.yuk;
  const gn = 9.81;
  const seyirMesafesi = hesaplaSeyirMesafesi(p.katlar);

  // Total force on piston
  const F = (p.kabinP + beyanYuk + p.kapiAgirlik) * gn; // N
  const P_max = 50; // bar (working pressure, range 40-60)
  const P_max_Pa = P_max * 1e5; // Pa

  // Piston diameter: D = sqrt(4*F / (π*P_max))
  const pistonCapi = Math.sqrt((4 * F) / (Math.PI * P_max_Pa)) * 1000; // mm

  // Piston stroke = travel distance
  const pistonStrok = seyirMesafesi; // mm

  // Cylinder type based on stroke
  let silindirTipi = 'Direkt';
  if (pistonStrok > 4000) silindirTipi = 'Teleskopik';
  else if (pistonStrok > 2500) silindirTipi = 'İndirekt 2:1';

  // Pump flow rate: Q = (π*D²/4) * v * 60 / 1000 (l/min)
  const D_m = pistonCapi / 1000;
  const pompaDegeri = (Math.PI * D_m * D_m / 4) * p.hiz * 60 * 1000; // l/min

  // Tank volume: V = Q * seyirMesafesi / (v * 1000) * 1.5
  const tankHacmi = pompaDegeri * (seyirMesafesi / 1000) / (p.hiz * 1000) * 1.5; // litre

  // Hydraulic power: P = Q * P_max / 600
  const hidrolikGucu = pompaDegeri * P_max / 600; // kW

  const pistonBasinc = P_max;

  const kontrolSonuclari: { no: number; aciklama: string; uygun: boolean }[] = [
    { no: 1, aciklama: 'Piston çapı yeterli', uygun: pistonCapi >= 40 },
    { no: 2, aciklama: 'Çalışma basıncı ≤ 60 bar', uygun: P_max <= 60 },
    { no: 3, aciklama: 'Pompa debisi uygun', uygun: pompaDegeri > 0 && pompaDegeri < 200 },
    { no: 4, aciklama: 'Tank hacmi yeterli', uygun: tankHacmi >= pompaDegeri * 0.5 },
    { no: 5, aciklama: 'Hidrolik güç ≤ 30 kW', uygun: hidrolikGucu <= 30 },
    { no: 6, aciklama: 'Strok ≤ 18m (EN81-2)', uygun: pistonStrok <= 18000 },
    { no: 7, aciklama: 'Hız ≤ 1.0 m/s (EN81-2)', uygun: p.hiz <= 1.0 },
  ];

  return { pistonCapi, pistonBasinc, pistonStrok, silindirTipi, pompaDegeri, tankHacmi, hidrolikGucu, kontrolSonuclari };
}

// ═══════════════════════════════════════════════════════════════════════════════
// 2. ROPE/SHEAVE CALCULATIONS (Faz 2)
// ═══════════════════════════════════════════════════════════════════════════════
export interface RopeCalcResult {
  halatKopmaKuvveti: number;
  halatGuvenlikKatsayisi: number;
  Dd_orani: number;
  Dd_uygun: boolean;
  halatOmru: number;
  toplam_statik_yuk: number;
}

export function hesaplaHalat(p: ElevatorParams): RopeCalcResult {
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const beyan = beyanYukBul(kabinGen, kabinDer);
  const beyanYuk = beyan.yuk;
  const gn = 9.81;
  const seyirMesafesi = hesaplaSeyirMesafesi(p.katlar);

  // Rope data lookup
  const ropeData = ROPE_DB[p.halatCapi] || ROPE_DB[10];
  const halatKopmaKuvveti = ropeData.fmin; // N per rope

  // Total static load
  const halatKutlesiPerM = ropeData.weight; // kg/m
  const halatTotalKg = halatKutlesiPerM * (seyirMesafesi / 1000) * p.halatSayisi;
  const toplam_statik_yuk = (p.kabinP + beyanYuk + p.kapiAgirlik + halatTotalKg) * gn; // N

  // Safety factor: n = (Fmin * halatSayisi) / toplam_yuk
  const halatGuvenlikKatsayisi = (halatKopmaKuvveti * p.halatSayisi) / toplam_statik_yuk;

  // D/d ratio
  const Dd_orani = p.tahrikKas / p.halatCapi;
  const Dd_uygun = Dd_orani >= 40; // EN81-1 minimum

  // Estimated rope life (simplified: based on D/d ratio and bending cycles)
  const halatOmru = Math.round(500000 * (Dd_orani / 40) * (1 - p.hiz / 5));

  return { halatKopmaKuvveti, halatGuvenlikKatsayisi, Dd_orani, Dd_uygun, halatOmru, toplam_statik_yuk };
}

// ═══════════════════════════════════════════════════════════════════════════════
// 3. BUFFER CALCULATIONS (Faz 2)
// ═══════════════════════════════════════════════════════════════════════════════
export interface BufferCalcResult {
  tamponTipi: string;
  tamponStrok: number;
  tamponYuksekligi: number;
  tamponKuvveti: number;
  uygun: boolean;
  aciklama: string;
}

export function hesaplaTampon(p: ElevatorParams): BufferCalcResult {
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const beyan = beyanYukBul(kabinGen, kabinDer);
  const beyanYuk = beyan.yuk;
  const gn = 9.81;
  const v = p.hiz;

  let tamponTipi: string;
  let tamponStrok: number;

  if (v <= 1.0) {
    // Spring buffer allowed (EN81-1 5.7.3.3)
    tamponTipi = 'Yay Tampon';
    tamponStrok = (v * v) / (2 * gn * 1.0) * 1000; // mm
  } else {
    // Hydraulic buffer required
    tamponTipi = 'Hidrolik Tampon';
    tamponStrok = (v * v) / (2 * gn) * 1000 * 1.15; // mm with 15% safety
  }

  const tamponYuksekligi = tamponStrok + 150; // mm safety margin
  const tamponKuvveti = (p.kabinP + beyanYuk + p.kapiAgirlik) * gn * 2.5; // N (2.5g deceleration)

  // Check if pit depth is sufficient
  const minPitForBuffer = tamponYuksekligi + 200; // buffer + clearance
  const uygun = p.kuyuDibi >= minPitForBuffer;
  const aciklama = uygun
    ? `${tamponTipi}: Strok ${tamponStrok.toFixed(0)} mm, Yükseklik ${tamponYuksekligi.toFixed(0)} mm — Kuyu dibi yeterli`
    : `${tamponTipi}: Strok ${tamponStrok.toFixed(0)} mm, Yükseklik ${tamponYuksekligi.toFixed(0)} mm — Kuyu dibi yetersiz (min ${minPitForBuffer.toFixed(0)} mm gerekli)`;

  return { tamponTipi, tamponStrok, tamponYuksekligi, tamponKuvveti, uygun, aciklama };
}

// ═══════════════════════════════════════════════════════════════════════════════
// 4. ADVANCED TRAFFIC ANALYSIS (Faz 2)
// ═══════════════════════════════════════════════════════════════════════════════
export interface TrafficCalcResult {
  binaKullanimTipi: string;
  kKatsayisi: number;
  beklemeArasi: number;
  handlingCapacity: number;
  handlingCapacityPct: number;
  gerekliAsansorSayisi: number;
  uygun: boolean;
  aciklama: string;
}

export function hesaplaTrafik(p: ElevatorParams): TrafficCalcResult {
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const beyan = beyanYukBul(kabinGen, kabinDer);
  const kisiSayisi = beyan.kisi;
  const seyirMesafesi = hesaplaSeyirMesafesi(p.katlar);
  const katSayisi = p.katlar.length;

  // Building type k-factors
  const tipler = ['Konut', 'Ofis', 'Hastane', 'Otel'];
  const kRanges: [number, number][] = [[0.05, 0.08], [0.11, 0.15], [0.08, 0.12], [0.10, 0.12]];
  const maxIntervals = [60, 30, 45, 40]; // seconds

  const tipIdx = Math.min(p.binaKullanimTipi, 3);
  const binaKullanimTipi = tipler[tipIdx];
  const kKatsayisi = (kRanges[tipIdx][0] + kRanges[tipIdx][1]) / 2;
  const maxInterval = maxIntervals[tipIdx];

  // RTT = 2*H*tv + (S+1)*ts + 2*P*tp
  const H = seyirMesafesi / 1000; // m
  const tv = 1 / p.hiz; // time per meter
  const S = Math.min(katSayisi - 1, Math.ceil(kisiSayisi * 0.8)); // probable stops
  const P = Math.min(kisiSayisi, Math.ceil(beyan.yuk / 75 * 0.8)); // passengers per trip
  const ts = 8; // door open/close + acceleration time per stop (s)
  const tp = 1.5; // passenger transfer time (s)

  const RTT = 2 * H * tv + (S + 1) * ts + 2 * P * tp; // seconds

  // Interval = RTT / N_elevators
  const N = p.asansorSayisi;
  const beklemeArasi = RTT / N;

  // HC% = (P * 300) / (RTT * population) * 100
  const population = p.binaKisiSayisi;
  const handlingCapacity = (P * 300) / RTT; // persons per 5 min
  const handlingCapacityPct = (handlingCapacity * N / population) * 100;

  // Required elevators
  const gerekliAsansorSayisi = Math.ceil(RTT / maxInterval);

  const uygun = beklemeArasi <= maxInterval && handlingCapacityPct >= kKatsayisi * 100;
  const aciklama = uygun
    ? `${binaKullanimTipi}: Bekleme ${beklemeArasi.toFixed(0)}s (max ${maxInterval}s), HC=${handlingCapacityPct.toFixed(1)}% — Uygun`
    : `${binaKullanimTipi}: Bekleme ${beklemeArasi.toFixed(0)}s (max ${maxInterval}s), HC=${handlingCapacityPct.toFixed(1)}% — Yetersiz (${gerekliAsansorSayisi} asansör gerekli)`;

  return { binaKullanimTipi, kKatsayisi, beklemeArasi, handlingCapacity, handlingCapacityPct, gerekliAsansorSayisi, uygun, aciklama };
}

// ═══════════════════════════════════════════════════════════════════════════════
// 5. ENERGY CLASS CALCULATION (Faz 3) — VDI 4707
// ═══════════════════════════════════════════════════════════════════════════════
export interface EnergyCalcResult {
  energySinifi: string;
  yillikEnerji: number;
  standbyGucu: number;
  calismaGucu: number;
  kategori: number;
  aciklama: string;
}

export function hesaplaEnerji(p: ElevatorParams): EnergyCalcResult {
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const beyan = beyanYukBul(kabinGen, kabinDer);
  const beyanYuk = beyan.yuk;
  const seyirMesafesi = hesaplaSeyirMesafesi(p.katlar);

  // Standby power estimation (lighting, controller, ventilation)
  const standbyGucu = 50 + (beyanYuk / 1000) * 30 + (p.katlar.length * 5); // W

  // Running power
  const motorKW = p.motorGucu;
  const calismaGucu = motorKW * 1000 * (p.motorVerim / 100); // W effective

  // Trips per year estimation (VDI 4707 usage categories)
  const tripPerDay = p.binaKullanimTipi === 1 ? 300 : p.binaKullanimTipi === 2 ? 400 : p.binaKullanimTipi === 3 ? 250 : 150;
  const tripDuration = (seyirMesafesi / 1000) / p.hiz; // seconds per trip
  const runHoursPerYear = (tripPerDay * 365 * tripDuration) / 3600;
  const standbyHoursPerYear = 8760 - runHoursPerYear;

  // Annual energy
  const yillikEnerji = (calismaGucu * runHoursPerYear + standbyGucu * standbyHoursPerYear) / 1000; // kWh

  // Energy per trip (Wh)
  const energyPerTrip = (calismaGucu * tripDuration / 3600) * 1000 + standbyGucu * (3600 / tripPerDay) / 3600 * 1000;

  // VDI 4707 classification (simplified thresholds based on energy per trip in Wh/kg/m)
  const specificEnergy = energyPerTrip / (beyanYuk * seyirMesafesi / 1000);
  let kategori: number; let energySinifi: string;
  if (specificEnergy < 0.56) { kategori = 1; energySinifi = 'A'; }
  else if (specificEnergy < 0.84) { kategori = 2; energySinifi = 'B'; }
  else if (specificEnergy < 1.26) { kategori = 3; energySinifi = 'C'; }
  else if (specificEnergy < 1.89) { kategori = 4; energySinifi = 'D'; }
  else if (specificEnergy < 2.80) { kategori = 5; energySinifi = 'E'; }
  else if (specificEnergy < 4.20) { kategori = 6; energySinifi = 'F'; }
  else { kategori = 7; energySinifi = 'G'; }

  const aciklama = `VDI 4707 Sınıf ${energySinifi} (Kategori ${kategori}): Yıllık ${yillikEnerji.toFixed(0)} kWh, Standby ${standbyGucu.toFixed(0)} W`;

  return { energySinifi, yillikEnerji, standbyGucu, calismaGucu, kategori, aciklama };
}

// ═══════════════════════════════════════════════════════════════════════════════
// 6. SEISMIC ANALYSIS (Faz 4) — EN81-77
// ═══════════════════════════════════════════════════════════════════════════════
export interface SeismicCalcResult {
  depremBolgesi: number;
  ivmeKatsayisi: number;
  rayEkKuvvet: number;
  tamponEkStrok: number;
  uygun: boolean;
  onlemler: string[];
}

export function hesaplaDeprem(p: ElevatorParams, depremBolgesi: number = 1): SeismicCalcResult {
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const beyan = beyanYukBul(kabinGen, kabinDer);
  const beyanYuk = beyan.yuk;
  const gn = 9.81;

  // Seismic acceleration by zone (Turkey TBDY 2018 simplified)
  const ivmeMap: Record<number, number> = { 1: 0.40, 2: 0.30, 3: 0.20, 4: 0.10, 5: 0.05 };
  const ivmeKatsayisi = ivmeMap[depremBolgesi] || 0.40;

  // Importance factor (elevators in hospitals = 1.5, others = 1.0)
  const importanceFactor = p.binaKullanimTipi === 2 ? 1.5 : 1.0;

  // Total mass
  const totalMass = p.kabinP + beyanYuk + p.kapiAgirlik; // kg

  // Additional horizontal seismic force on rails
  const rayEkKuvvet = totalMass * ivmeKatsayisi * gn * importanceFactor; // N

  // Additional buffer stroke for seismic
  const tamponEkStrok = (ivmeKatsayisi * p.hiz * p.hiz) / (2 * gn) * 1000 * 0.5; // mm

  // Check: existing rail can handle additional seismic force
  const rayProfil = RAIL_PROFILE_DETAILS[p.kabinRayTipi] || RAIL_PROFILE_DETAILS['T89/B'];
  const Rm = 370; // N/mm²
  const seismicStress = rayEkKuvvet / (rayProfil.A * 100); // N/mm²
  const allowableStress = Rm / 3;
  const uygun = seismicStress <= allowableStress * 0.5; // 50% reserve for seismic

  // Recommended measures
  const onlemler: string[] = [];
  if (depremBolgesi <= 2) {
    onlemler.push('Deprem algılama sensörü zorunlu');
    onlemler.push('Otomatik en yakın kata gitme sistemi');
    onlemler.push('Ray bağlantı elemanları güçlendirilmeli');
  }
  if (depremBolgesi <= 3) {
    onlemler.push('Karşı ağırlık raylarına deprem kilidi');
    onlemler.push('Halat tutucu (rope gripper) önerilir');
  }
  if (ivmeKatsayisi >= 0.20) {
    onlemler.push('Tampon stroku artırılmalı');
    onlemler.push('Kabin içi acil aydınlatma');
  }
  if (!uygun) {
    onlemler.push('Ray profili yükseltilmeli veya konsol mesafesi azaltılmalı');
  }

  return { depremBolgesi, ivmeKatsayisi, rayEkKuvvet, tamponEkStrok, uygun, onlemler };
}

// ═══════════════════════════════════════════════════════════════════════════════
// 7. COST ESTIMATION (Faz 4)
// ═══════════════════════════════════════════════════════════════════════════════
export interface CostEstimateResult {
  kabinMaliyeti: number;
  rayMaliyeti: number;
  motorMaliyeti: number;
  kapiMaliyeti: number;
  halatMaliyeti: number;
  elektrikMaliyeti: number;
  montajMaliyeti: number;
  toplamMaliyet: number;
  birimFiyatlar: { kalem: string; birim: string; miktar: number; birimFiyat: number; toplam: number }[];
}

export function hesaplaMaliyet(p: ElevatorParams): CostEstimateResult {
  const { kabinGen, kabinDer } = hesaplaKabinBoyutlari(p);
  const seyirMesafesi = hesaplaSeyirMesafesi(p.katlar);
  const katSayisi = p.katlar.length;
  const kabinAlani = (kabinGen * kabinDer) / 1_000_000; // m²

  const birimFiyatlar: { kalem: string; birim: string; miktar: number; birimFiyat: number; toplam: number }[] = [];

  // Cabin cost (based on area and material)
  const kabinBirimFiyat = p.panoramik ? 45000 : 28000; // TRY/m²
  const kabinMaliyeti = kabinAlani * kabinBirimFiyat;
  birimFiyatlar.push({ kalem: 'Kabin', birim: 'm²', miktar: kabinAlani, birimFiyat: kabinBirimFiyat, toplam: kabinMaliyeti });

  // Rail cost
  const rayBirimFiyat = RAIL_COST[p.kabinRayTipi] || 580;
  const agrRayBirimFiyat = RAIL_COST[p.agrRayTipi] || 180;
  const rayUzunluk = (seyirMesafesi + p.kuyuDibi + p.kuyuKafa) / 1000; // m
  const kabinRayMaliyet = rayUzunluk * 2 * rayBirimFiyat;
  const agrRayMaliyet = rayUzunluk * 2 * agrRayBirimFiyat;
  const rayMaliyeti = kabinRayMaliyet + agrRayMaliyet;
  birimFiyatlar.push({ kalem: 'Kabin Rayı', birim: 'm', miktar: rayUzunluk * 2, birimFiyat: rayBirimFiyat, toplam: kabinRayMaliyet });
  birimFiyatlar.push({ kalem: 'Ağırlık Rayı', birim: 'm', miktar: rayUzunluk * 2, birimFiyat: agrRayBirimFiyat, toplam: agrRayMaliyet });

  // Motor cost (based on kW)
  const motorBirimFiyat = p.asansorTipi === 'HA' ? 18000 : 12000; // TRY/kW
  const motorMaliyeti = p.motorGucu * motorBirimFiyat;
  birimFiyatlar.push({ kalem: 'Motor/Tahrik', birim: 'kW', miktar: p.motorGucu, birimFiyat: motorBirimFiyat, toplam: motorMaliyeti });

  // Door cost (per floor)
  const kapiBirimFiyat = p.kapiTipi.includes('KK') ? 8500 : 6500; // TRY per door
  const kapiMaliyeti = katSayisi * kapiBirimFiyat;
  birimFiyatlar.push({ kalem: 'Kat Kapısı', birim: 'adet', miktar: katSayisi, birimFiyat: kapiBirimFiyat, toplam: kapiMaliyeti });

  // Rope cost
  const ropeData = ROPE_DB[p.halatCapi] || ROPE_DB[10];
  const halatBirimFiyat = Math.round(ropeData.weight * 120); // TRY/m approximate
  const halatUzunluk = rayUzunluk * 2.2 * p.halatSayisi; // total rope length
  const halatMaliyeti = halatUzunluk * halatBirimFiyat;
  birimFiyatlar.push({ kalem: 'Halat', birim: 'm', miktar: halatUzunluk, birimFiyat: halatBirimFiyat, toplam: halatMaliyeti });

  // Electrical cost
  const elektrikBirimFiyat = 3500; // TRY per floor
  const elektrikMaliyeti = katSayisi * elektrikBirimFiyat + 25000; // base + per floor
  birimFiyatlar.push({ kalem: 'Elektrik/Kumanda', birim: 'kat', miktar: katSayisi, birimFiyat: elektrikBirimFiyat, toplam: elektrikMaliyeti });

  // Installation cost (% of material)
  const malzemeToplam = kabinMaliyeti + rayMaliyeti + motorMaliyeti + kapiMaliyeti + halatMaliyeti + elektrikMaliyeti;
  const montajMaliyeti = malzemeToplam * 0.25;
  birimFiyatlar.push({ kalem: 'Montaj İşçiliği', birim: '%', miktar: 25, birimFiyat: malzemeToplam / 100, toplam: montajMaliyeti });

  const toplamMaliyet = malzemeToplam + montajMaliyeti;

  return { kabinMaliyeti, rayMaliyeti, motorMaliyeti, kapiMaliyeti, halatMaliyeti, elektrikMaliyeti, montajMaliyeti, toplamMaliyet, birimFiyatlar };
}

// ═══════════════════════════════════════════════════════════════════════════════
// 8. COMPREHENSIVE REPORT GENERATOR
// ═══════════════════════════════════════════════════════════════════════════════
export interface FullReport {
  en81: EN81CalcResult;
  hidrolik?: HydraulicCalcResult;
  halat: RopeCalcResult;
  tampon: BufferCalcResult;
  trafik: TrafficCalcResult;
  enerji: EnergyCalcResult;
  deprem: SeismicCalcResult;
  maliyet: CostEstimateResult;
  toplamKontrol: number;
  uygunKontrol: number;
  uygunlukOrani: number;
}

export function generateFullReport(p: ElevatorParams): FullReport {
  const en81 = hesaplaEN81Full(p);
  const hidrolik = p.asansorTipi === 'HA' ? hesaplaHidrolik(p) : undefined;
  const halat = hesaplaHalat(p);
  const tampon = hesaplaTampon(p);
  const trafik = hesaplaTrafik(p);
  const enerji = hesaplaEnerji(p);
  const deprem = hesaplaDeprem(p, 1);
  const maliyet = hesaplaMaliyet(p);

  // Aggregate compliance checks
  let toplamKontrol = 0;
  let uygunKontrol = 0;

  // EN81 checks (18)
  toplamKontrol += en81.kontrolSonuclari.length;
  uygunKontrol += en81.kontrolSonuclari.filter(k => k.uygun).length;

  // Hydraulic checks
  if (hidrolik) {
    toplamKontrol += hidrolik.kontrolSonuclari.length;
    uygunKontrol += hidrolik.kontrolSonuclari.filter(k => k.uygun).length;
  }

  // Rope check (safety factor)
  toplamKontrol += 2;
  const minSafety = p.asansorTipi === 'EA' ? 12 : 8;
  if (halat.halatGuvenlikKatsayisi >= minSafety) uygunKontrol++;
  if (halat.Dd_uygun) uygunKontrol++;

  // Buffer check
  toplamKontrol += 1;
  if (tampon.uygun) uygunKontrol++;

  // Traffic check
  toplamKontrol += 1;
  if (trafik.uygun) uygunKontrol++;

  // Seismic check
  toplamKontrol += 1;
  if (deprem.uygun) uygunKontrol++;

  const uygunlukOrani = toplamKontrol > 0 ? (uygunKontrol / toplamKontrol) * 100 : 0;

  return { en81, hidrolik, halat, tampon, trafik, enerji, deprem, maliyet, toplamKontrol, uygunKontrol, uygunlukOrani };
}
