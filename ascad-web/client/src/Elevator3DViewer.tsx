import React, { useRef, useEffect, useState, useCallback, useMemo } from 'react';
import * as THREE from 'three';
import { OrbitControls } from 'three/addons/controls/OrbitControls.js';

// ─── Types ───────────────────────────────────────────────────────────────────
interface KatBilgi { katNo: number; rumuz: string; yukseklik: number; mimariKot: number; }
interface FirmaBilgi { firmaAdi: string; adres: string; tel: string; muhendis: string; }

interface ElevatorParams {
  asansorTipi: 'EA' | 'HA'; tahrikKodu: 'DA' | 'MDDUZ' | 'MDCAP' | 'YA' | 'SD';
  yonKodu: 'SOL' | 'SAG' | 'ARKA'; kuyuGen: number; kuyuDer: number;
  kuyuDibi: number; kuyuKafa: number; duvarKal: number;
  kapiGen: number; kapiH: number; kapiTipi: string;
  kabinYEksen: number; kabinRayUcu: number; kizakKalin: number; krx: number;
  agrGen: number; agrDuv: number; agrU: number; agrUz: number;
  tahrikKas: number; sapKas: number; katlar: KatBilgi[]; firma: FirmaBilgi;
  kabinRayTipi: string; agrRayTipi: string; tamponTipi: string;
  regYeri: number; kabinP: number; hiz: number; dengeOrani: number;
  halatCapi: number; halatSayisi: number; frenTipi: string; motorGucu: number;
  calisYuksek: number; mDaireH: number; asansorSayisi: number; araBolme: number;
  panoramik: boolean; olcek: number; konsolMesafe: number; kapiAgirlik: number;
  motorVerim: number; binaKisiSayisi: number; binaKullanimTipi: number;
  Xc: number; Yc: number; Xs: number; Ys: number; Xp: number; Yp: number;
  esikKalin: number; kasaGen: number; kasaDer: number; mentese: 'SOL' | 'SAG';
  kapiFlip: boolean; kabinDuvar: number; kabinYanDuv: number; aydinMesafe: number;
  iskeleVar: boolean; dengeZinciri: boolean; hamdGen: number;
}

interface Elevator3DViewerProps { params: ElevatorParams; }

type PartGroup = 'kuyu' | 'kabin' | 'ray' | 'kapi' | 'agirlik' | 'kasnak' | 'tampon' | 'halat' | 'makine' | 'regulator';
type ViewPreset = 'on' | 'yan' | 'ust' | 'izometrik' | 'kabin-ici';

interface PartInfo { name: string; group: PartGroup; mesh: THREE.Object3D; }
interface BomItem { no: number; name: string; count: number; material: string; weight: number; }

const GROUP_LABELS: Record<PartGroup, string> = {
  kuyu: 'Kuyu', kabin: 'Kabin', ray: 'Raylar', kapi: 'Kapılar',
  agirlik: 'Ağırlık', kasnak: 'Kasnak', tampon: 'Tamponlar',
  halat: 'Halatlar', makine: 'Makine Dairesi', regulator: 'Regülatör',
};

// ─── Helpers ─────────────────────────────────────────────────────────────────
const mm = (v: number) => v / 1000;

function seyirMesafesi(katlar: KatBilgi[]): number {
  if (katlar.length < 2) return 0;
  let t = 0; for (let i = 0; i < katlar.length - 1; i++) t += katlar[i].yukseklik;
  return t;
}

function kabinBoyutlari(p: ElevatorParams) {
  let kabinGen: number, kabinDer: number;
  if (p.yonKodu === 'SOL' || p.yonKodu === 'SAG') {
    kabinDer = p.kuyuDer - p.kabinYEksen - 100;
    kabinGen = p.kuyuGen - (p.agrDuv + p.agrGen + p.agrU + 70 + 200) - ((p.krx + p.kabinRayUcu) * 2);
  } else {
    kabinGen = p.kuyuGen - ((p.krx + p.kabinRayUcu) * 2) - 200;
    kabinDer = p.kuyuDer - p.kabinYEksen - (p.agrDuv + p.agrGen + p.agrU + 70 + 200) - 100;
  }
  return { kabinGen: Math.max(kabinGen, 600), kabinDer: Math.max(kabinDer, 600) };
}

function tagMesh(obj: THREE.Object3D, name: string, group: PartGroup) {
  obj.name = name;
  obj.userData.partGroup = group;
}

// ─── Procedural Textures ─────────────────────────────────────────────────────
function createConcreteTexture(): THREE.CanvasTexture {
  const size = 512;
  const canvas = document.createElement('canvas');
  canvas.width = size; canvas.height = size;
  const ctx = canvas.getContext('2d')!;
  // Base color
  ctx.fillStyle = '#8a8a8a';
  ctx.fillRect(0, 0, size, size);
  // Noise for concrete grain
  for (let i = 0; i < 15000; i++) {
    const x = Math.random() * size;
    const y = Math.random() * size;
    const v = 120 + Math.random() * 40;
    ctx.fillStyle = `rgb(${v},${v},${v})`;
    ctx.fillRect(x, y, 1 + Math.random() * 2, 1 + Math.random() * 2);
  }
  // Formwork lines (horizontal)
  for (let y = 0; y < size; y += 60 + Math.random() * 20) {
    ctx.strokeStyle = `rgba(100,100,100,${0.1 + Math.random() * 0.15})`;
    ctx.lineWidth = 1;
    ctx.beginPath(); ctx.moveTo(0, y); ctx.lineTo(size, y); ctx.stroke();
  }
  const tex = new THREE.CanvasTexture(canvas);
  tex.wrapS = tex.wrapT = THREE.RepeatWrapping;
  tex.repeat.set(2, 2);
  return tex;
}

function createBrushedSteelTexture(): THREE.CanvasTexture {
  const size = 256;
  const canvas = document.createElement('canvas');
  canvas.width = size; canvas.height = size;
  const ctx = canvas.getContext('2d')!;
  // Base
  ctx.fillStyle = '#c8c8c8';
  ctx.fillRect(0, 0, size, size);
  // Brushed lines (horizontal)
  for (let y = 0; y < size; y++) {
    const v = 180 + Math.random() * 50;
    ctx.strokeStyle = `rgb(${v},${v},${v})`;
    ctx.lineWidth = 0.5;
    ctx.beginPath(); ctx.moveTo(0, y); ctx.lineTo(size, y); ctx.stroke();
  }
  const tex = new THREE.CanvasTexture(canvas);
  tex.wrapS = tex.wrapT = THREE.RepeatWrapping;
  tex.repeat.set(1, 1);
  return tex;
}

function createFloorTexture(): THREE.CanvasTexture {
  const size = 256;
  const canvas = document.createElement('canvas');
  canvas.width = size; canvas.height = size;
  const ctx = canvas.getContext('2d')!;
  // PVC floor tile pattern
  ctx.fillStyle = '#7a6b55';
  ctx.fillRect(0, 0, size, size);
  // Tile grid
  const tileSize = 64;
  for (let x = 0; x < size; x += tileSize) {
    for (let y = 0; y < size; y += tileSize) {
      const v = 100 + Math.random() * 30;
      ctx.fillStyle = `rgb(${v + 20},${v + 10},${v})`;
      ctx.fillRect(x + 1, y + 1, tileSize - 2, tileSize - 2);
    }
  }
  const tex = new THREE.CanvasTexture(canvas);
  tex.wrapS = tex.wrapT = THREE.RepeatWrapping;
  tex.repeat.set(2, 2);
  return tex;
}

function createEnvMap(): THREE.CubeTexture {
  // Procedural environment cubemap for reflections
  const size = 128;
  const faces: HTMLCanvasElement[] = [];
  const colors = [
    [0.15, 0.18, 0.25], // px (right) — dark blue
    [0.12, 0.14, 0.20], // nx (left)
    [0.35, 0.40, 0.50], // py (top) — lighter sky
    [0.05, 0.05, 0.08], // ny (bottom) — dark ground
    [0.18, 0.20, 0.28], // pz (front)
    [0.10, 0.12, 0.18], // nz (back)
  ];
  for (const [r, g, b] of colors) {
    const canvas = document.createElement('canvas');
    canvas.width = size; canvas.height = size;
    const ctx = canvas.getContext('2d')!;
    // Gradient
    const grad = ctx.createLinearGradient(0, 0, 0, size);
    grad.addColorStop(0, `rgb(${Math.round(r * 255 * 1.3)},${Math.round(g * 255 * 1.3)},${Math.round(b * 255 * 1.3)})`);
    grad.addColorStop(1, `rgb(${Math.round(r * 255 * 0.7)},${Math.round(g * 255 * 0.7)},${Math.round(b * 255 * 0.7)})`);
    ctx.fillStyle = grad;
    ctx.fillRect(0, 0, size, size);
    // Some noise for realism
    for (let i = 0; i < 500; i++) {
      const x = Math.random() * size, y = Math.random() * size;
      const v = Math.random() * 0.1;
      ctx.fillStyle = `rgba(255,255,255,${v})`;
      ctx.fillRect(x, y, 2, 2);
    }
    faces.push(canvas);
  }
  const cubeTexture = new THREE.CubeTexture(faces);
  cubeTexture.needsUpdate = true;
  return cubeTexture;
}

// ─── Materials ───────────────────────────────────────────────────────────────
function createMaterials() {
  const concreteTex = createConcreteTexture();
  const steelTex = createBrushedSteelTexture();
  const floorTex = createFloorTexture();
  const envMap = createEnvMap();

  return {
    concrete: new THREE.MeshStandardMaterial({
      map: concreteTex, roughness: 0.92, metalness: 0.0,
      transparent: true, opacity: 0.35, side: THREE.DoubleSide,
    }),
    steel: new THREE.MeshPhysicalMaterial({
      map: steelTex, color: 0xd8d8d8, metalness: 0.95, roughness: 0.12,
      clearcoat: 0.7, clearcoatRoughness: 0.08,
      envMap, envMapIntensity: 1.5,
    }),
    glass: new THREE.MeshPhysicalMaterial({
      color: 0xaaddff, metalness: 0.0, roughness: 0.02,
      transmission: 0.92, thickness: 0.8, transparent: true,
      ior: 1.52, clearcoat: 0.3, clearcoatRoughness: 0.05,
      envMap, envMapIntensity: 0.8,
    }),
    darkSteel: new THREE.MeshStandardMaterial({
      color: 0x3a3a3a, metalness: 0.88, roughness: 0.42,
      envMap, envMapIntensity: 0.6,
    }),
    rubber: new THREE.MeshStandardMaterial({
      color: 0x1a1a1a, roughness: 0.95, metalness: 0.0,
    }),
    yellow: new THREE.MeshStandardMaterial({
      color: 0xf0c800, roughness: 0.55, metalness: 0.05,
    }),
    cabinInterior: new THREE.MeshStandardMaterial({
      color: 0xf2ece0, roughness: 0.35, metalness: 0.05,
      envMap, envMapIntensity: 0.2,
    }),
    mirror: new THREE.MeshPhysicalMaterial({
      color: 0xf0f0f0, metalness: 1.0, roughness: 0.01,
      clearcoat: 1.0, clearcoatRoughness: 0.005,
      envMap, envMapIntensity: 2.0,
    }),
    light: new THREE.MeshStandardMaterial({
      color: 0xffffff, emissive: 0xfff8e8, emissiveIntensity: 1.2,
      roughness: 0.1, metalness: 0.0,
    }),
    cabinFloor: new THREE.MeshStandardMaterial({
      map: floorTex, roughness: 0.75, metalness: 0.0,
    }),
  };
}

// ─── T-Rail Profile Shape ────────────────────────────────────────────────────
function createTRailShape(): THREE.Shape {
  const shape = new THREE.Shape();
  // T89/B profile: base 89mm, web 16mm, total height 89mm, head 60mm
  // All dimensions in meters
  const baseW = 0.089;    // base width
  const baseH = 0.012;    // base thickness
  const webW = 0.016;     // web width
  const webH = 0.050;     // web height (between base and head)
  const headW = 0.060;    // head width
  const headH = 0.027;    // head height
  const fillet = 0.003;   // fillet radius approximation

  // Start from bottom-left of base
  shape.moveTo(-baseW / 2, 0);
  shape.lineTo(baseW / 2, 0);
  shape.lineTo(baseW / 2, baseH);
  // Right side: base to web transition with fillet
  shape.lineTo(webW / 2 + fillet, baseH);
  shape.quadraticCurveTo(webW / 2, baseH, webW / 2, baseH + fillet);
  // Web right side
  shape.lineTo(webW / 2, baseH + webH - fillet);
  // Web to head transition right
  shape.quadraticCurveTo(webW / 2, baseH + webH, webW / 2 + fillet, baseH + webH);
  shape.lineTo(headW / 2, baseH + webH);
  // Head right side
  shape.lineTo(headW / 2, baseH + webH + headH - fillet);
  shape.quadraticCurveTo(headW / 2, baseH + webH + headH, headW / 2 - fillet, baseH + webH + headH);
  // Head top
  shape.lineTo(-headW / 2 + fillet, baseH + webH + headH);
  shape.quadraticCurveTo(-headW / 2, baseH + webH + headH, -headW / 2, baseH + webH + headH - fillet);
  // Head left side
  shape.lineTo(-headW / 2, baseH + webH);
  shape.lineTo(-webW / 2 - fillet, baseH + webH);
  // Web to head transition left
  shape.quadraticCurveTo(-webW / 2, baseH + webH, -webW / 2, baseH + webH - fillet);
  // Web left side
  shape.lineTo(-webW / 2, baseH + fillet);
  // Base to web transition left
  shape.quadraticCurveTo(-webW / 2, baseH, -webW / 2 - fillet, baseH);
  shape.lineTo(-baseW / 2, baseH);
  shape.closePath();
  return shape;
}

function createCChannelShape(w: number, h: number, t: number, fillet: number): THREE.Shape {
  // C-channel profile: width w, height h, thickness t
  const shape = new THREE.Shape();
  shape.moveTo(0, 0);
  shape.lineTo(w, 0);
  shape.lineTo(w, t);
  shape.lineTo(t + fillet, t);
  shape.quadraticCurveTo(t, t, t, t + fillet);
  shape.lineTo(t, h - t - fillet);
  shape.quadraticCurveTo(t, h - t, t + fillet, h - t);
  shape.lineTo(w, h - t);
  shape.lineTo(w, h);
  shape.lineTo(0, h);
  shape.closePath();
  return shape;
}

function createBoltGeometry(): THREE.BufferGeometry {
  // Hex bolt head + shaft
  const group = new THREE.CylinderGeometry(0.006, 0.006, 0.015, 6);
  return group;
}

function createDoorSillProfile(): THREE.Shape {
  // Door sill cross-section (T-shaped with groove)
  const shape = new THREE.Shape();
  const w = 0.08, h = 0.025, grooveW = 0.012, grooveD = 0.015;
  shape.moveTo(-w/2, 0);
  shape.lineTo(w/2, 0);
  shape.lineTo(w/2, h - grooveD);
  shape.lineTo(grooveW/2, h - grooveD);
  shape.lineTo(grooveW/2, h);
  shape.lineTo(-grooveW/2, h);
  shape.lineTo(-grooveW/2, h - grooveD);
  shape.lineTo(-w/2, h - grooveD);
  shape.closePath();
  return shape;
}

// ─── STL Export ──────────────────────────────────────────────────────────────
function exportSTL(scene: THREE.Scene): string {
  let stl = 'solid asncad\n';
  scene.traverse(obj => {
    if (!(obj instanceof THREE.Mesh)) return;
    const geo = obj.geometry;
    if (!geo || !geo.attributes.position) return;
    const pos = geo.attributes.position;
    const idx = geo.index;
    const matrixWorld = obj.matrixWorld;
    const triCount = idx ? idx.count / 3 : pos.count / 3;
    const vA = new THREE.Vector3(), vB = new THREE.Vector3(), vC = new THREE.Vector3();
    const cb = new THREE.Vector3(), ab = new THREE.Vector3();
    for (let i = 0; i < triCount; i++) {
      const a = idx ? idx.getX(i * 3) : i * 3;
      const b = idx ? idx.getX(i * 3 + 1) : i * 3 + 1;
      const c = idx ? idx.getX(i * 3 + 2) : i * 3 + 2;
      vA.fromBufferAttribute(pos, a).applyMatrix4(matrixWorld);
      vB.fromBufferAttribute(pos, b).applyMatrix4(matrixWorld);
      vC.fromBufferAttribute(pos, c).applyMatrix4(matrixWorld);
      cb.subVectors(vC, vB); ab.subVectors(vA, vB); cb.cross(ab).normalize();
      stl += `  facet normal ${cb.x} ${cb.y} ${cb.z}\n    outer loop\n`;
      stl += `      vertex ${vA.x} ${vA.y} ${vA.z}\n`;
      stl += `      vertex ${vB.x} ${vB.y} ${vB.z}\n`;
      stl += `      vertex ${vC.x} ${vC.y} ${vC.z}\n`;
      stl += `    endloop\n  endfacet\n`;
    }
  });
  stl += 'endsolid asncad\n';
  return stl;
}

// ─── BOM Generator ───────────────────────────────────────────────────────────
function generateBOM(p: ElevatorParams): BomItem[] {
  const seyir = seyirMesafesi(p.katlar);
  const kuyuH = p.kuyuDibi + seyir + p.kuyuKafa;
  const railLenM = kuyuH / 1000;
  const railWeightPerM_cabin = p.kabinRayTipi === 'T89/B' ? 16.2 : p.kabinRayTipi === 'T127/B' ? 23.8 : 12.5;
  const railWeightPerM_cw = p.agrRayTipi === 'T89/B' ? 16.2 : p.agrRayTipi === 'T75/B' ? 9.9 : 8.5;
  const items: BomItem[] = [
    { no: 1, name: `Kabin Rayı ${p.kabinRayTipi || 'T89/B'}`, count: 2, material: 'Çelik S235', weight: Math.round(2 * railLenM * railWeightPerM_cabin) },
    { no: 2, name: `Ağırlık Rayı ${p.agrRayTipi || 'T75/B'}`, count: 2, material: 'Çelik S235', weight: Math.round(2 * railLenM * railWeightPerM_cw) },
    { no: 3, name: 'Kat Kapısı', count: p.katlar.length, material: 'Paslanmaz', weight: Math.round(p.katlar.length * (p.kapiAgirlik || 65)) },
    { no: 4, name: 'Kabin Kapısı', count: 1, material: 'Paslanmaz', weight: Math.round(p.kapiAgirlik || 65) },
    { no: 5, name: 'Kabin Grubu', count: 1, material: 'Çelik/Paslanmaz', weight: Math.round(p.kabinP || 450) },
    { no: 6, name: 'Karşı Ağırlık', count: 1, material: 'Beton/Çelik', weight: Math.round((p.kabinP || 450) + (p.kabinP || 450) * (p.dengeOrani || 50) / 100) },
    { no: 7, name: 'Çelik Halat', count: p.halatSayisi || 4, material: `Ø${p.halatCapi || 10} Çelik`, weight: Math.round((p.halatSayisi || 4) * railLenM * 2 * 0.4) },
    { no: 8, name: 'Tampon', count: p.asansorTipi === 'EA' ? 4 : 2, material: p.tamponTipi === 'YAG' ? 'Yağlı' : 'Kauçuk', weight: p.tamponTipi === 'YAG' ? 45 : 8 },
    { no: 9, name: 'Tahrik Makinesi', count: 1, material: 'Çelik/Bakır', weight: Math.round((p.motorGucu || 7.5) * 30) },
    { no: 10, name: 'Hız Regülatörü', count: 1, material: 'Çelik', weight: 18 },
  ];
  return items;
}

// ─── Part Properties Database ────────────────────────────────────────────────
interface PartProperties {
  name: string;
  group: string;
  malzeme: string;
  standart: string;
  boyut: string;
  agirlik: string;
  yuzeyIslemi: string;
  imalatNotu: string;
  tedarikci: string;
  birimFiyat: string;
  teslimatSuresi: string;
}

function getPartProperties(partName: string, p: ElevatorParams, parts: PartInfo[]): PartProperties {
  const seyir = seyirMesafesi(p.katlar);
  const kuyuH = p.kuyuDibi + seyir + p.kuyuKafa;
  const rayLen = (kuyuH / 1000).toFixed(1);
  const { kabinGen, kabinDer } = kabinBoyutlari(p);

  const db: Record<string, Partial<PartProperties>> = {
    'Kabin Rayı - Sol': { malzeme: `Çelik S235 — ${p.kabinRayTipi}`, standart: 'TS EN 81-20, ISO 7465', boyut: `${p.kabinRayTipi} × ${rayLen} m`, agirlik: `${(parseFloat(rayLen) * 12.3).toFixed(1)} kg`, yuzeyIslemi: 'Haddelenmiş, yağlanmış', imalatNotu: `${rayLen}m boy, 5m'lik parçalar halinde, ek yerleri işaretli. Montaj sırasında lazer hizalama yapılacak.`, tedarikci: 'Savera / Montanari', birimFiyat: `${(parseFloat(rayLen) * 580).toFixed(0)} ₺`, teslimatSuresi: '2-3 hafta' },
    'Kabin Rayı - Sağ': { malzeme: `Çelik S235 — ${p.kabinRayTipi}`, standart: 'TS EN 81-20, ISO 7465', boyut: `${p.kabinRayTipi} × ${rayLen} m`, agirlik: `${(parseFloat(rayLen) * 12.3).toFixed(1)} kg`, yuzeyIslemi: 'Haddelenmiş, yağlanmış', imalatNotu: `${rayLen}m boy, 5m'lik parçalar halinde. Sağ ray, sol ray ile simetrik montaj.`, tedarikci: 'Savera / Montanari', birimFiyat: `${(parseFloat(rayLen) * 580).toFixed(0)} ₺`, teslimatSuresi: '2-3 hafta' },
    'Ağırlık Rayı - 1': { malzeme: `Çelik S235 — ${p.agrRayTipi}`, standart: 'TS EN 81-20, ISO 7465', boyut: `${p.agrRayTipi} × ${rayLen} m`, agirlik: `${(parseFloat(rayLen) * 3.7).toFixed(1)} kg`, yuzeyIslemi: 'Haddelenmiş', imalatNotu: 'Ağırlık rayı, kabin rayından daha hafif profil.', tedarikci: 'Savera / Montanari', birimFiyat: `${(parseFloat(rayLen) * 180).toFixed(0)} ₺`, teslimatSuresi: '2-3 hafta' },
    'Kabin Grubu': { malzeme: 'Paslanmaz Çelik AISI 304 / Çelik S235', standart: 'TS EN 81-20 Madde 8', boyut: `${kabinGen} × ${kabinDer} × ${p.kapiH + 200} mm`, agirlik: `${p.kabinP} kg`, yuzeyIslemi: 'Satine fırçalama + koruyucu film', imalatNotu: `Kabin iç: RAL 9001 fırınlanmış boya. Tavan: LED panel aydınlatma. Zemin: PVC kaplama. Ayna: 3mm temperli. Küpeşte: Ø32 paslanmaz boru.`, tedarikci: 'Yerli üretim', birimFiyat: `${Math.round(kabinGen * kabinDer / 1e6 * 28000)} ₺`, teslimatSuresi: '3-4 hafta' },
    'Karşı Ağırlık': { malzeme: 'Beton blok + Çelik çerçeve S235', standart: 'TS EN 81-20 Madde 8.17', boyut: `${p.agrGen} × ${p.agrUz} × 800 mm`, agirlik: `${Math.round(p.kabinP + p.kabinP * p.dengeOrani)} kg`, yuzeyIslemi: 'Galvaniz çerçeve, beton blok boyasız', imalatNotu: `Toplam ağırlık: KP + Q×${p.dengeOrani} = ${Math.round(p.kabinP + p.kabinP * p.dengeOrani)} kg. 8 adet beton plaka. Çerçeve: 60×40×3 kutu profil.`, tedarikci: 'Yerli üretim', birimFiyat: `${Math.round((p.kabinP + p.kabinP * p.dengeOrani) * 8)} ₺`, teslimatSuresi: '1-2 hafta' },
    'Makine Dairesi': { malzeme: 'Çelik S235 / Dökme demir', standart: 'TS EN 81-20 Madde 12', boyut: `Motor: ${p.motorGucu} kW, Kasnak: Ø${p.tahrikKas} mm`, agirlik: `${Math.round(p.motorGucu * 30)} kg`, yuzeyIslemi: 'Epoksi boya RAL 7035', imalatNotu: `Tahrik: ${p.tahrikKodu}. Fren: ${p.frenTipi}. Kasnak Ø${p.tahrikKas}mm. Saptırma Ø${p.sapKas}mm. Kiriş: IPE 200. Regülatör yeri: ${p.regYeri}.`, tedarikci: 'Sicor / Ziehl-Abegg / Montanari', birimFiyat: `${Math.round(p.motorGucu * 12000)} ₺`, teslimatSuresi: '4-6 hafta' },
  };

  // Generic door entries
  for (let i = 0; i < p.katlar.length; i++) {
    const floorName = p.katlar[i].rumuz;
    ['Sol Panel', 'Sağ Panel', 'Eşik'].forEach(sub => {
      const key = `Kat Kapısı ${i + 1} - ${sub}`;
      db[key] = {
        malzeme: sub === 'Eşik' ? 'Alüminyum 6063-T5' : 'Paslanmaz Çelik AISI 304',
        standart: 'TS EN 81-20 Madde 7',
        boyut: sub === 'Eşik' ? `${p.kapiGen + 120} × 80 × 25 mm` : `${Math.round(p.kapiGen / 2)} × ${p.kapiH} × 40 mm`,
        agirlik: sub === 'Eşik' ? '8 kg' : `${Math.round(p.kapiAgirlik / 2)} kg`,
        yuzeyIslemi: sub === 'Eşik' ? 'Eloksal' : 'Satine fırçalama',
        imalatNotu: `${floorName}. kat ${p.kapiTipi} kapı. ${sub === 'Eşik' ? 'T-profil eşik rayı, oluklu.' : 'Panel kalınlığı 40mm, çift cidarlı.'}`,
        tedarikci: 'Fermator / Wittur',
        birimFiyat: sub === 'Eşik' ? '1200 ₺' : `${Math.round(p.kapiAgirlik * 50)} ₺`,
        teslimatSuresi: '3-4 hafta',
      };
    });
  }

  const found = db[partName];
  return {
    name: partName,
    group: GROUP_LABELS[parts.find(pp => pp.name === partName)?.group || 'kuyu'] || 'Genel',
    malzeme: found?.malzeme || 'Çelik S235',
    standart: found?.standart || 'TS EN 81-20',
    boyut: found?.boyut || '-',
    agirlik: found?.agirlik || '-',
    yuzeyIslemi: found?.yuzeyIslemi || 'Boyalı',
    imalatNotu: found?.imalatNotu || 'Standart imalat',
    tedarikci: found?.tedarikci || 'Yerli',
    birimFiyat: found?.birimFiyat || '-',
    teslimatSuresi: found?.teslimatSuresi || '2-4 hafta',
  };
}

// ─── Scene Builder ───────────────────────────────────────────────────────────
function buildScene(p: ElevatorParams, scene: THREE.Scene, mats: ReturnType<typeof createMaterials>, parts: PartInfo[]) {
  while (scene.children.length > 0) {
    const child = scene.children[0];
    scene.remove(child);
    if (child instanceof THREE.Mesh) { child.geometry.dispose(); }
  }
  parts.length = 0;

  const seyir = seyirMesafesi(p.katlar);
  const kuyuH = p.kuyuDibi + seyir + p.kuyuKafa;
  const W = mm(p.kuyuGen), D = mm(p.kuyuDer), H = mm(kuyuH);
  const wallT = mm(p.duvarKal);
  const { kabinGen, kabinDer } = kabinBoyutlari(p);
  const cW = mm(kabinGen), cD = mm(kabinDer), cH = mm(p.kapiH + 200);
  const doorW = mm(p.kapiGen), doorH = mm(p.kapiH);

  // ─── Lighting (Studio-quality 3-point setup) ────────────────────────
  scene.add(new THREE.AmbientLight(0xffffff, 0.25));
  const hemi = new THREE.HemisphereLight(0x8ec8e8, 0x3a3a3a, 0.5);
  scene.add(hemi);
  // Key light — ana ışık (güneş benzeri)
  const dir1 = new THREE.DirectionalLight(0xfff5e0, 1.0);
  dir1.position.set(6, 12, 8); dir1.castShadow = true;
  dir1.shadow.mapSize.set(4096, 4096);
  dir1.shadow.camera.near = 0.1; dir1.shadow.camera.far = 60;
  dir1.shadow.camera.left = -12; dir1.shadow.camera.right = 12;
  dir1.shadow.camera.top = 12; dir1.shadow.camera.bottom = -12;
  dir1.shadow.bias = -0.0002;
  dir1.shadow.normalBias = 0.02;
  scene.add(dir1);
  // Fill light — dolgu ışık (yumuşak, soğuk)
  const dir2 = new THREE.DirectionalLight(0xc8d8ff, 0.4);
  dir2.position.set(-4, 8, -6); scene.add(dir2);
  // Rim light — kenar ışık (arkadan, kontur belirginleştirme)
  const dir3 = new THREE.DirectionalLight(0xffffff, 0.3);
  dir3.position.set(0, 5, -10); scene.add(dir3);

  const cx = W / 2, cz = D / 2;

  // ─── Shaft Walls ──────────────────────────────────────────────────────
  const backWall = addWall(mats.concrete, W + wallT * 2, H, wallT, 0, H / 2, -(cz + wallT / 2));
  tagMesh(backWall, 'Kuyu Duvarı - Arka', 'kuyu'); scene.add(backWall); parts.push({ name: backWall.name, group: 'kuyu', mesh: backWall });

  const leftWall = addWall(mats.concrete, wallT, H, D, -(cx + wallT / 2), H / 2, 0);
  tagMesh(leftWall, 'Kuyu Duvarı - Sol', 'kuyu'); scene.add(leftWall); parts.push({ name: leftWall.name, group: 'kuyu', mesh: leftWall });

  const rightWall = addWall(mats.concrete, wallT, H, D, cx + wallT / 2, H / 2, 0);
  tagMesh(rightWall, 'Kuyu Duvarı - Sağ', 'kuyu'); scene.add(rightWall); parts.push({ name: rightWall.name, group: 'kuyu', mesh: rightWall });

  const frontParts = buildFrontWall(mats.concrete, p, W, H, D, wallT, cx, cz, doorW, doorH);
  frontParts.forEach((m, i) => { tagMesh(m, `Kuyu Duvarı - Ön ${i + 1}`, 'kuyu'); scene.add(m); parts.push({ name: m.name, group: 'kuyu', mesh: m }); });

  const pitFloor = new THREE.Mesh(new THREE.BoxGeometry(W + wallT * 2, 0.1, D + wallT * 2), mats.concrete);
  pitFloor.position.set(0, -0.05, 0); pitFloor.receiveShadow = true;
  tagMesh(pitFloor, 'Kuyu Tabanı', 'kuyu'); scene.add(pitFloor); parts.push({ name: pitFloor.name, group: 'kuyu', mesh: pitFloor });

  // Kuyu üst kapağı (tavan döşemesi)
  const topSlab = new THREE.Mesh(new THREE.BoxGeometry(W + wallT * 2, 0.15, D + wallT * 2), mats.concrete);
  topSlab.position.set(0, H + 0.075, 0); topSlab.receiveShadow = true;
  tagMesh(topSlab, 'Kuyu Tavanı', 'kuyu'); scene.add(topSlab); parts.push({ name: topSlab.name, group: 'kuyu', mesh: topSlab });

  // ─── Guide Rails ──────────────────────────────────────────────────────
  const railShape = createTRailShape();
  const railPositions: [number, number, number][] = [
    [-cW / 2 - 0.05, 0, -cD / 2 + 0.1], [cW / 2 + 0.05, 0, -cD / 2 + 0.1],
  ];
  if (p.yonKodu === 'SOL') { railPositions.push([-cx + 0.1, 0, -cz + 0.15], [-cx + 0.1, 0, cz - 0.15]); }
  else if (p.yonKodu === 'SAG') { railPositions.push([cx - 0.1, 0, -cz + 0.15], [cx - 0.1, 0, cz - 0.15]); }
  else { railPositions.push([-cx + 0.2, 0, -cz + 0.1], [cx - 0.2, 0, -cz + 0.1]); }

  const extSettings = { steps: 1, depth: H, bevelEnabled: false };
  const railExtGeo = new THREE.ExtrudeGeometry(railShape, extSettings);
  railExtGeo.rotateX(-Math.PI / 2);
  const railNames = ['Kabin Rayı - Sol', 'Kabin Rayı - Sağ', 'Ağırlık Rayı - 1', 'Ağırlık Rayı - 2'];
  for (let ri = 0; ri < railPositions.length; ri++) {
    const [rx, ry, rz] = railPositions[ri];
    const rail = new THREE.Mesh(railExtGeo, mats.steel);
    rail.position.set(rx, ry, rz); rail.castShadow = true;
    tagMesh(rail, railNames[ri] || `Ray ${ri + 1}`, 'ray');
    scene.add(rail); parts.push({ name: rail.name, group: 'ray', mesh: rail });
    const edges = new THREE.EdgesGeometry(railExtGeo);
    const line = new THREE.LineSegments(edges, new THREE.LineBasicMaterial({ color: 0x333333, transparent: true, opacity: 0.3 }));
    line.position.copy(rail.position); scene.add(line);
  }

  // ─── Rail Brackets (Konsol) — every ~2.5m along height ─────────────────
  const bracketSpacing = 2.5;
  const bracketCount = Math.max(2, Math.floor(H / bracketSpacing));
  const bracketMat = mats.darkSteel;
  for (let ri = 0; ri < railPositions.length; ri++) {
    const [rx, , rz] = railPositions[ri];
    // Calculate direction from rail to nearest wall
    // Walls are at: left=-cx, right=+cx, back=-cz, front=+cz
    const distLeft = Math.abs(rx - (-cx));
    const distRight = Math.abs(rx - cx);
    const distBack = Math.abs(rz - (-cz));
    const distFront = Math.abs(rz - cz);
    const minDist = Math.min(distLeft, distRight, distBack, distFront);
    let bDir: THREE.Vector3;
    if (minDist === distLeft) bDir = new THREE.Vector3(-1, 0, 0);
    else if (minDist === distRight) bDir = new THREE.Vector3(1, 0, 0);
    else if (minDist === distBack) bDir = new THREE.Vector3(0, 0, -1);
    else bDir = new THREE.Vector3(0, 0, 1);

    // Arm length = distance to wall minus small gap
    const armLen = Math.max(0.06, minDist - 0.02);

    for (let bi = 0; bi < bracketCount; bi++) {
      const by = (bi + 0.5) * (H / bracketCount);
      // Horizontal arm
      const armW = bDir.x !== 0 ? armLen : 0.035;
      const armD = bDir.z !== 0 ? armLen : 0.035;
      const arm = new THREE.Mesh(new THREE.BoxGeometry(armW, 0.008, armD), bracketMat);
      arm.position.set(rx + bDir.x * armLen / 2, by, rz + bDir.z * armLen / 2);
      arm.castShadow = true;
      tagMesh(arm, `Ray Konsol ${ri + 1}-${bi + 1}`, 'ray');
      scene.add(arm);
      parts.push({ name: arm.name, group: 'ray', mesh: arm });
      // Clip on rail
      const clip = new THREE.Mesh(new THREE.BoxGeometry(0.025, 0.05, 0.025), bracketMat);
      clip.position.set(rx, by, rz);
      scene.add(clip);
      // Yellow bolts
      [0.012, -0.012].forEach(bOff => {
        const bolt = new THREE.Mesh(new THREE.CylinderGeometry(0.004, 0.004, 0.015, 6), mats.yellow);
        bolt.position.set(rx + bDir.x * armLen * 0.6, by + bOff, rz + bDir.z * armLen * 0.6);
        scene.add(bolt);
      });
    }
  }

  // ─── Multi-elevator support ────────────────────────────────────────────
  const elevatorCount = p.asansorSayisi || 1;
  const araBolmeM = mm(p.araBolme || 100);

  for (let elev = 0; elev < elevatorCount; elev++) {
    const offsetX = elev * (W + araBolmeM);
    const suffix = elevatorCount > 1 ? ` (Asansör ${elev + 1})` : '';

    // ─── Cabin ─────────────────────────────────────────────────────────
    const cabinY = mm(p.kuyuDibi);
    const cabinGroup = buildCabin(mats, p, cW, cD, cH, cabinY, doorW, doorH);
    cabinGroup.position.x += offsetX;
    tagMesh(cabinGroup, `Kabin Grubu${suffix}`, 'kabin');
    scene.add(cabinGroup); parts.push({ name: cabinGroup.name, group: 'kabin', mesh: cabinGroup });

    // ─── Counterweight ─────────────────────────────────────────────────
    if (p.asansorTipi === 'EA') {
      const cwGroup = buildCounterweight(mats, p, cabinY, H, cx, cz);
      cwGroup.position.x += offsetX;
      tagMesh(cwGroup, `Karşı Ağırlık${suffix}`, 'agirlik');
      scene.add(cwGroup); parts.push({ name: cwGroup.name, group: 'agirlik', mesh: cwGroup });
    }

    // ─── Doors ─────────────────────────────────────────────────────────
    const doorMeshes = buildDoors(mats, p, doorW, doorH, cx, cz, wallT);
    doorMeshes.forEach((dm, i) => {
      dm.position.x += offsetX;
      const floorIdx = Math.floor(i / 3);
      const sub = i % 3;
      const subName = sub === 0 ? 'Sol Panel' : sub === 1 ? 'Sağ Panel' : 'Eşik';
      const nm = `Kat Kapısı ${floorIdx + 1} - ${subName}${suffix}`;
      tagMesh(dm, nm, 'kapi'); scene.add(dm); parts.push({ name: nm, group: 'kapi', mesh: dm });
    });

    // ─── Buffers ───────────────────────────────────────────────────────
    const bufferMeshes = buildBuffers(mats, cW);
    bufferMeshes.forEach((bm, i) => {
      bm.position.x += offsetX;
      const nm = (i < 2 ? `Kabin Tamponu ${i + 1}` : `Tampon Kapak ${i - 1}`) + suffix;
      tagMesh(bm, nm, 'tampon'); scene.add(bm); parts.push({ name: nm, group: 'tampon', mesh: bm });
    });

    // ─── Ropes ─────────────────────────────────────────────────────────
    if (p.asansorTipi === 'EA') {
      const cabinY2 = mm(p.kuyuDibi);
      const ropeMeshes = buildRopes(mats, p, cabinY2, H, cW);
      ropeMeshes.forEach((rm, i) => {
        rm.position.x += offsetX;
        const nm = `Halat ${i + 1}${suffix}`;
        tagMesh(rm, nm, 'halat'); scene.add(rm); parts.push({ name: nm, group: 'halat', mesh: rm });
      });
    }

    // ─── Pit Ladder (kuyu dibi merdiveni) ────────────────────────────
    if (elev === 0) {
      const ladderH = mm(p.kuyuDibi) + mm(p.katlar[0]?.yukseklik || 3000) * 0.5;
      const ladderW2 = 0.35;
      const ladderMat = mats.darkSteel;
      const ladderX = -cx + wallT + 0.08;
      const ladderZ = cz - 0.15;
      // Side rails
      [-ladderW2/2, ladderW2/2].forEach((lx, li) => {
        const rail = new THREE.Mesh(new THREE.BoxGeometry(0.03, ladderH, 0.015), ladderMat);
        rail.position.set(ladderX + lx, ladderH/2, ladderZ);
        rail.castShadow = true;
        tagMesh(rail, `Merdiven Yan ${li+1}${suffix}`, 'kuyu');
        scene.add(rail); parts.push({ name: rail.name, group: 'kuyu', mesh: rail });
      });
      // Rungs
      const rungCount = Math.floor(ladderH / 0.28);
      for (let r = 0; r < rungCount; r++) {
        const rung = new THREE.Mesh(new THREE.CylinderGeometry(0.01, 0.01, ladderW2, 6), ladderMat);
        rung.rotation.z = Math.PI / 2;
        rung.position.set(ladderX, (r + 1) * 0.28, ladderZ);
        scene.add(rung);
      }
    }

    // ─── Governor Rope (regülatör halatı — dikey sarı halat) ─────────
    if (elev === 0 && p.asansorTipi === 'EA') {
      const govRopeMat = new THREE.MeshStandardMaterial({ color: 0xccaa00, roughness: 0.6, metalness: 0.3 });
      const govRopeH = H + 0.5;
      const govRope = new THREE.Mesh(new THREE.CylinderGeometry(0.004, 0.004, govRopeH, 6), govRopeMat);
      govRope.position.set(-cx + 0.15 + offsetX, govRopeH / 2, cz - 0.2);
      govRope.castShadow = true;
      tagMesh(govRope, `Regülatör Halatı${suffix}`, 'regulator');
      scene.add(govRope); parts.push({ name: govRope.name, group: 'regulator', mesh: govRope });
    }

    // ─── Door Frame (kapı kasası — çelik profil) ─────────────────────
    {
      const frameMat = mats.darkSteel;
      const frameW = 0.05, frameD = 0.06;
      let doorFloorY = mm(p.kuyuDibi);
      for (let di = 0; di < p.katlar.length; di++) {
        const frontZ2 = cz + wallT / 2;
        // Left jamb
        const lJamb = new THREE.Mesh(new THREE.BoxGeometry(frameW, doorH + 0.05, frameD), frameMat);
        lJamb.position.set(-doorW/2 - frameW/2 + offsetX, doorFloorY + doorH/2, frontZ2);
        scene.add(lJamb);
        // Right jamb
        const rJamb = new THREE.Mesh(new THREE.BoxGeometry(frameW, doorH + 0.05, frameD), frameMat);
        rJamb.position.set(doorW/2 + frameW/2 + offsetX, doorFloorY + doorH/2, frontZ2);
        scene.add(rJamb);
        // Top header
        const hdr = new THREE.Mesh(new THREE.BoxGeometry(doorW + frameW * 2, frameW, frameD), frameMat);
        hdr.position.set(offsetX, doorFloorY + doorH + frameW/2, frontZ2);
        scene.add(hdr);
        if (di < p.katlar.length - 1) doorFloorY += mm(p.katlar[di].yukseklik);
      }
    }

    // ─── Machine Room (only for first elevator) ──────────────────────
    if (elev === 0 && p.asansorTipi === 'EA' && (p.tahrikKodu === 'DA' || p.tahrikKodu === 'YA')) {
      const mrGroup = buildMachineRoom(mats, p, H, W, D, cx, cz, wallT);
      tagMesh(mrGroup, 'Makine Dairesi', 'makine');
      scene.add(mrGroup); parts.push({ name: mrGroup.name, group: 'makine', mesh: mrGroup });
    }

    // ─── Additional shaft walls for second elevator ──────────────────
    if (elev > 0) {
      // Right wall of second shaft
      const rw2 = addWall(mats.concrete, wallT, H, D, offsetX + cx + wallT / 2, H / 2, 0);
      tagMesh(rw2, `Kuyu Duvarı - Sağ (Asansör ${elev + 1})`, 'kuyu');
      scene.add(rw2); parts.push({ name: rw2.name, group: 'kuyu', mesh: rw2 });
      // Back wall of second shaft
      const bw2 = addWall(mats.concrete, W + wallT * 2, H, wallT, offsetX, H / 2, -(cz + wallT / 2));
      tagMesh(bw2, `Kuyu Duvarı - Arka (Asansör ${elev + 1})`, 'kuyu');
      scene.add(bw2); parts.push({ name: bw2.name, group: 'kuyu', mesh: bw2 });
      // Front wall of second shaft
      const fw2 = buildFrontWall(mats.concrete, p, W, H, D, wallT, cx, cz, doorW, doorH);
      fw2.forEach((m, i) => {
        m.position.x += offsetX;
        tagMesh(m, `Kuyu Duvarı - Ön ${i + 1} (Asansör ${elev + 1})`, 'kuyu');
        scene.add(m); parts.push({ name: m.name, group: 'kuyu', mesh: m });
      });
      // Additional rails for second shaft
      const railExtGeo2 = new THREE.ExtrudeGeometry(railShape, extSettings);
      railExtGeo2.rotateX(-Math.PI / 2);
      const rail2Positions: [number, number, number][] = [
        [offsetX - cW / 2 - 0.05, 0, -cD / 2 + 0.1],
        [offsetX + cW / 2 + 0.05, 0, -cD / 2 + 0.1],
      ];
      rail2Positions.forEach(([rx, ry, rz], ri) => {
        const rail = new THREE.Mesh(railExtGeo2, mats.steel);
        rail.position.set(rx, ry, rz); rail.castShadow = true;
        tagMesh(rail, `Kabin Rayı ${ri + 1} (Asansör ${elev + 1})`, 'ray');
        scene.add(rail); parts.push({ name: rail.name, group: 'ray', mesh: rail });
      });
    }

    // Ara bölme duvarı (between elevators)
    if (elev === 0 && elevatorCount > 1) {
      const abX = cx + wallT / 2;
      const abWall = addWall(mats.concrete, araBolmeM, H, D, abX + araBolmeM / 2, H / 2, 0);
      tagMesh(abWall, 'Ara Bölme Duvarı', 'kuyu');
      scene.add(abWall); parts.push({ name: abWall.name, group: 'kuyu', mesh: abWall });
    }
  }

  // ─── Ground Plane (zemin yansıması) ────────────────────────────────────
  const groundGeo = new THREE.PlaneGeometry(20, 20);
  const groundMat = new THREE.MeshStandardMaterial({ color: 0xd0d0d8, roughness: 0.85, metalness: 0.1 });
  const ground = new THREE.Mesh(groundGeo, groundMat);
  ground.rotation.x = -Math.PI / 2; ground.position.y = -0.01; ground.receiveShadow = true;
  scene.add(ground);

  // ─── 3D Grid ──────────────────────────────────────────────────────────
  const gridHelper = new THREE.GridHelper(20, 40, 0x999999, 0xcccccc);
  gridHelper.position.y = -0.005;
  gridHelper.userData._isGrid = true;
  scene.add(gridHelper);
  // Axis helper (small, at origin)
  const axesHelper = new THREE.AxesHelper(0.5);
  axesHelper.position.set(-cx - wallT - 0.3, 0, cz + wallT + 0.3);
  axesHelper.userData._isGrid = true;
  scene.add(axesHelper);

  // ─── Floor slabs (kat çizgileri + beton döşemeler) ──────────────────────
  const floorLineMat = new THREE.LineBasicMaterial({ color: 0xffd700 });
  let floorY = mm(p.kuyuDibi);
  for (let i = 0; i < p.katlar.length; i++) {
    // Yellow outline at floor level
    const pts = [
      new THREE.Vector3(-cx - wallT, floorY, cz + wallT), new THREE.Vector3(cx + wallT, floorY, cz + wallT),
      new THREE.Vector3(cx + wallT, floorY, -cz - wallT), new THREE.Vector3(-cx - wallT, floorY, -cz - wallT),
      new THREE.Vector3(-cx - wallT, floorY, cz + wallT),
    ];
    const geo = new THREE.BufferGeometry().setFromPoints(pts);
    scene.add(new THREE.Line(geo, floorLineMat));

    // Kat numarası etiketi (sprite)
    const canvas2 = document.createElement('canvas');
    canvas2.width = 128; canvas2.height = 64;
    const ctx2 = canvas2.getContext('2d');
    if (ctx2) {
      ctx2.fillStyle = '#000000'; ctx2.fillRect(0, 0, 128, 64);
      ctx2.fillStyle = '#ffd700'; ctx2.font = 'bold 36px Arial';
      ctx2.textAlign = 'center'; ctx2.textBaseline = 'middle';
      ctx2.fillText(p.katlar[i].rumuz, 64, 32);
      const tex = new THREE.CanvasTexture(canvas2);
      const spriteMat = new THREE.SpriteMaterial({ map: tex, transparent: true });
      const sprite = new THREE.Sprite(spriteMat);
      sprite.position.set(cx + wallT + 0.3, floorY + 0.15, cz + wallT + 0.1);
      sprite.scale.set(0.3, 0.15, 1);
      scene.add(sprite);
    }

    if (i < p.katlar.length - 1) floorY += mm(p.katlar[i].yukseklik);
  }
}

// ─── Sub-builders (return meshes instead of adding to scene) ─────────────────
function addWall(mat: THREE.Material, w: number, h: number, d: number, x: number, y: number, z: number): THREE.Mesh {
  const mesh = new THREE.Mesh(new THREE.BoxGeometry(w, h, d), mat);
  mesh.position.set(x, y, z); mesh.castShadow = true; mesh.receiveShadow = true;
  return mesh;
}

function buildFrontWall(mat: THREE.Material, p: ElevatorParams,
  W: number, H: number, _D: number, wallT: number, _cx: number, cz: number, doorW: number, doorH: number): THREE.Mesh[] {
  const meshes: THREE.Mesh[] = [];
  const frontZ = cz + wallT / 2;
  let floorY = mm(p.kuyuDibi);
  for (let i = 0; i < p.katlar.length; i++) {
    const leftW = (W - doorW) / 2;
    // Side panels next to door
    if (leftW > 0.01) {
      meshes.push(addWall(mat, leftW, doorH, wallT, -doorW / 2 - leftW / 2, floorY + doorH / 2, frontZ));
      meshes.push(addWall(mat, leftW, doorH, wallT, doorW / 2 + leftW / 2, floorY + doorH / 2, frontZ));
    }
    // Wall above door opening up to next floor (or to top)
    const nextFloorY = (i < p.katlar.length - 1) ? floorY + mm(p.katlar[i].yukseklik) : H;
    const aboveH = nextFloorY - (floorY + doorH);
    if (aboveH > 0.005) {
      meshes.push(addWall(mat, W, aboveH, wallT, 0, floorY + doorH + aboveH / 2, frontZ));
    }
    if (i < p.katlar.length - 1) floorY += mm(p.katlar[i].yukseklik);
  }
  // Pit wall (below first floor)
  const pitH = mm(p.kuyuDibi);
  if (pitH > 0.01) meshes.push(addWall(mat, W, pitH, wallT, 0, pitH / 2, frontZ));
  return meshes;
}

function buildCabin(mats: ReturnType<typeof createMaterials>, p: ElevatorParams,
  cW: number, cD: number, cH: number, cabinY: number, doorW: number, doorH: number): THREE.Group {
  const t = 0.015; // wall thickness
  const group = new THREE.Group();
  group.position.set(0, cabinY, 0);

  // ── Cabin Sling (Frame) — detailed like reference ──
  const slingW = 0.06, slingD = 0.08;
  const slingH = cH + 0.5; // extends above and below cabin
  const slingMat = mats.darkSteel;

  // 4 Vertical corner beams (dikmeler)
  const cornerPositions: [number, number][] = [
    [-cW/2 - slingW/2, -cD/2 + slingD/2], [-cW/2 - slingW/2, cD/2 - slingD/2],
    [cW/2 + slingW/2, -cD/2 + slingD/2], [cW/2 + slingW/2, cD/2 - slingD/2],
  ];
  cornerPositions.forEach(([sx, sz], i) => {
    const beam = new THREE.Mesh(new THREE.BoxGeometry(slingW, slingH, slingD), slingMat);
    beam.position.set(sx, cH/2 - 0.1, sz); beam.castShadow = true;
    beam.name = `Kabin Çerçeve Dikme ${i+1}`;
    group.add(beam);
  });

  // Top frame — rectangular frame with crossbeams (üst çerçeve)
  const topY = cH + 0.18;
  // Front & back top beams
  [cD/2 - slingD/2, -cD/2 + slingD/2].forEach((tz, i) => {
    const tb = new THREE.Mesh(new THREE.BoxGeometry(cW + slingW * 2 + 0.02, slingW, slingD * 0.6), slingMat);
    tb.position.set(0, topY, tz); tb.name = `Üst Kiriş ${i === 0 ? 'Ön' : 'Arka'}`;
    group.add(tb);
  });
  // Left & right top beams
  [-cW/2 - slingW/2, cW/2 + slingW/2].forEach((tx, i) => {
    const tb = new THREE.Mesh(new THREE.BoxGeometry(slingW, slingW, cD - slingD), slingMat);
    tb.position.set(tx, topY, 0); tb.name = `Üst Kiriş ${i === 0 ? 'Sol' : 'Sağ'}`;
    group.add(tb);
  });
  // Top cross braces (X pattern)
  const braceLen = Math.sqrt(cW * cW + cD * cD) * 0.8;
  const braceAngle = Math.atan2(cD, cW);
  [1, -1].forEach((dir, i) => {
    const brace = new THREE.Mesh(new THREE.BoxGeometry(braceLen, 0.02, 0.02), slingMat);
    brace.position.set(0, topY + 0.04, 0);
    brace.rotation.y = dir * braceAngle;
    brace.name = `Üst Çapraz ${i+1}`;
    group.add(brace);
  });

  // Rope attachment plate (halat bağlantı plakası — üst ortada)
  const ropePlate = new THREE.Mesh(new THREE.BoxGeometry(0.2, 0.025, 0.15), slingMat);
  ropePlate.position.set(0, topY + 0.06, 0); ropePlate.name = 'Halat Bağlantı Plakası';
  group.add(ropePlate);
  // Rope clamp bolts
  for (let bi = 0; bi < 4; bi++) {
    const bolt = new THREE.Mesh(new THREE.CylinderGeometry(0.006, 0.006, 0.04, 6), slingMat);
    bolt.position.set(-0.06 + bi * 0.04, topY + 0.08, 0);
    group.add(bolt);
  }

  // Bottom crossbeam
  const botBeam = new THREE.Mesh(new THREE.BoxGeometry(cW + slingW*2 + 0.02, slingW, slingD), slingMat);
  botBeam.position.set(0, -0.18, 0); botBeam.name = 'Kabin Alt Kiriş';
  group.add(botBeam);
  // Bottom side beams
  [-cW/2 - slingW/2, cW/2 + slingW/2].forEach((tx, i) => {
    const bb = new THREE.Mesh(new THREE.BoxGeometry(slingW, slingW, cD * 0.6), slingMat);
    bb.position.set(tx, -0.18, 0); bb.name = `Alt Kiriş ${i === 0 ? 'Sol' : 'Sağ'}`;
    group.add(bb);
  });

  // ── Guide Shoes (4 pieces — on rail side) ──
  const shoeW = 0.08, shoeH = 0.12, shoeD = 0.06;
  const shoeMat = new THREE.MeshStandardMaterial({ color: 0x44aaaa, roughness: 0.5, metalness: 0.4 }); // cyan like reference
  [[-cW/2 - slingW - shoeW/2, cH + 0.05], [-cW/2 - slingW - shoeW/2, -0.08],
   [cW/2 + slingW + shoeW/2, cH + 0.05], [cW/2 + slingW + shoeW/2, -0.08]].forEach(([sx, sy], i) => {
    const shoe = new THREE.Mesh(new THREE.BoxGeometry(shoeW, shoeH, shoeD), shoeMat);
    shoe.position.set(sx, sy, -cD/2 + 0.1); shoe.name = `Kılavuz Ayakkabı ${i+1}`;
    shoe.castShadow = true;
    group.add(shoe);
  });

  // ── Safety Gear (under cabin — yellow) ──
  const sgW = 0.15, sgH = 0.08, sgD = 0.1;
  const sgMat = mats.yellow;
  [-cW/3, cW/3].forEach((sx, i) => {
    const sg = new THREE.Mesh(new THREE.BoxGeometry(sgW, sgH, sgD), sgMat);
    sg.castShadow = true;
    sg.position.set(sx, -0.25, -cD/2 + 0.1); sg.name = `Güvenlik Tertibatı ${i+1}`;
    group.add(sg);
  });

  // ── Floor ──
  const floor = new THREE.Mesh(new THREE.BoxGeometry(cW, t, cD), mats.cabinFloor);
  floor.position.set(0, 0, 0); floor.receiveShadow = true; floor.name = 'Kabin Tabanı';
  group.add(floor);

  // ── Ceiling ──
  const ceiling = new THREE.Mesh(new THREE.BoxGeometry(cW, t, cD), mats.steel);
  ceiling.position.set(0, cH, 0); ceiling.name = 'Kabin Tavanı';
  group.add(ceiling);

  // ── Roof Platform ──
  const roofPlat = new THREE.Mesh(new THREE.BoxGeometry(cW * 0.8, 0.005, cD * 0.6), mats.darkSteel);
  roofPlat.position.set(0, cH + 0.02, 0); roofPlat.name = 'Kabin Üstü Platform';
  group.add(roofPlat);

  // ── Ceiling Lights (2 LED panels) ──
  [-cD/4, cD/4].forEach((lz, i) => {
    const lightGeo = new THREE.BoxGeometry(cW * 0.4, 0.008, 0.15);
    const lightMesh = new THREE.Mesh(lightGeo, mats.light);
    lightMesh.position.set(0, cH - 0.015, lz); lightMesh.name = `LED Panel ${i+1}`;
    group.add(lightMesh);
  });
  const cabinLight = new THREE.PointLight(0xfff5e0, 0.6, cH * 2);
  cabinLight.position.set(0, cH - 0.1, 0);
  group.add(cabinLight);

  // ── Ventilation Grille ──
  const ventGeo = new THREE.BoxGeometry(0.3, 0.005, 0.15);
  const ventMat = new THREE.MeshStandardMaterial({ color: 0x555555, roughness: 0.5, metalness: 0.6 });
  const vent = new THREE.Mesh(ventGeo, ventMat);
  vent.position.set(cW/4, cH - 0.01, -cD/3); vent.name = 'Havalandırma';
  group.add(vent);

  // ── Walls ──
  const backMat = p.panoramik ? mats.glass : mats.mirror;
  const backWall = new THREE.Mesh(new THREE.BoxGeometry(cW, cH, t), backMat);
  backWall.position.set(0, cH / 2, -cD / 2); backWall.name = 'Kabin Arka Duvar';
  group.add(backWall);

  const leftWall = new THREE.Mesh(new THREE.BoxGeometry(t, cH, cD), mats.cabinInterior);
  leftWall.position.set(-cW / 2, cH / 2, 0); leftWall.name = 'Kabin Sol Duvar';
  group.add(leftWall);

  const rightWall = new THREE.Mesh(new THREE.BoxGeometry(t, cH, cD), mats.cabinInterior);
  rightWall.position.set(cW / 2, cH / 2, 0); rightWall.name = 'Kabin Sağ Duvar';
  group.add(rightWall);

  // ── Front wall with door opening ──
  const frontPanelW = (cW - doorW) / 2;
  if (frontPanelW > 0.01) {
    const lp = new THREE.Mesh(new THREE.BoxGeometry(frontPanelW, cH, t), mats.steel);
    lp.position.set(-cW / 2 + frontPanelW / 2, cH / 2, cD / 2); lp.name = 'Kabin Ön Sol';
    group.add(lp);
    const rp = new THREE.Mesh(new THREE.BoxGeometry(frontPanelW, cH, t), mats.steel);
    rp.position.set(cW / 2 - frontPanelW / 2, cH / 2, cD / 2); rp.name = 'Kabin Ön Sağ';
    group.add(rp);
  }
  const aboveDoor = cH - doorH;
  if (aboveDoor > 0.01) {
    const ap = new THREE.Mesh(new THREE.BoxGeometry(doorW, aboveDoor, t), mats.steel);
    ap.position.set(0, doorH + aboveDoor / 2, cD / 2); ap.name = 'Kabin Kapı Üstü';
    group.add(ap);
  }

  // ── Door Operator (on top of door opening) ──
  const doorOp = new THREE.Mesh(new THREE.BoxGeometry(doorW * 0.8, 0.08, 0.12), mats.darkSteel);
  doorOp.position.set(0, doorH + 0.06, cD / 2 - 0.06); doorOp.name = 'Kapı Operatörü';
  group.add(doorOp);

  // ── Handrails (3 sides, round profile) ──
  const railR = 0.012;
  const hrH = cH * 0.42;
  // Back handrail
  const hrBack = new THREE.Mesh(new THREE.CylinderGeometry(railR, railR, cW - 0.1, 8), mats.steel);
  hrBack.rotation.z = Math.PI / 2; hrBack.position.set(0, hrH, -cD / 2 + 0.04); hrBack.name = 'Küpeşte Arka';
  group.add(hrBack);
  // Left handrail
  const hrLeft = new THREE.Mesh(new THREE.CylinderGeometry(railR, railR, cD - 0.15, 8), mats.steel);
  hrLeft.rotation.x = Math.PI / 2; hrLeft.position.set(-cW / 2 + 0.04, hrH, -0.05); hrLeft.name = 'Küpeşte Sol';
  group.add(hrLeft);
  // Right handrail
  const hrRight = new THREE.Mesh(new THREE.CylinderGeometry(railR, railR, cD - 0.15, 8), mats.steel);
  hrRight.rotation.x = Math.PI / 2; hrRight.position.set(cW / 2 - 0.04, hrH, -0.05); hrRight.name = 'Küpeşte Sağ';
  group.add(hrRight);
  // Handrail brackets (6 pieces)
  const bracketGeo = new THREE.CylinderGeometry(0.008, 0.008, 0.04, 6);
  [[-cW/2 + 0.04, -cD/2 + 0.04], [-cW/2 + 0.04, cD/4], [cW/2 - 0.04, -cD/2 + 0.04],
   [cW/2 - 0.04, cD/4], [-cW/4, -cD/2 + 0.04], [cW/4, -cD/2 + 0.04]].forEach(([bx, bz]) => {
    const bracket = new THREE.Mesh(bracketGeo, mats.steel);
    bracket.position.set(bx, hrH, bz);
    group.add(bracket);
  });

  // ── Button Panel ──
  const bpGeo = new THREE.BoxGeometry(0.02, 0.35, 0.18);
  const bp = new THREE.Mesh(bpGeo, mats.darkSteel);
  bp.position.set(cW / 2 - 0.015, cH * 0.48, cD / 2 - 0.22); bp.name = 'Kumanda Paneli';
  group.add(bp);
  // Buttons (small cylinders)
  const btnCount = Math.min(p.katlar.length, 8);
  for (let i = 0; i < btnCount; i++) {
    const btn = new THREE.Mesh(new THREE.CylinderGeometry(0.006, 0.006, 0.005, 8), mats.yellow);
    btn.rotation.z = Math.PI / 2;
    btn.position.set(cW / 2 - 0.005, cH * 0.35 + i * 0.035, cD / 2 - 0.22);
    group.add(btn);
  }

  // ── Edge highlights (bold, like eDrawings) ──
  const childSnapshot = [...group.children];
  childSnapshot.forEach(child => {
    if (child instanceof THREE.Mesh && child.geometry) {
      const edges = new THREE.EdgesGeometry(child.geometry, 15);
      const line = new THREE.LineSegments(edges, new THREE.LineBasicMaterial({ color: 0x111111, transparent: true, opacity: 0.5 }));
      line.position.copy(child.position); line.rotation.copy(child.rotation);
      group.add(line);
    }
  });

  return group;
}

function buildCounterweight(mats: ReturnType<typeof createMaterials>,
  p: ElevatorParams, cabinY: number, H: number, cx: number, cz: number): THREE.Group {
  const cwW = mm(p.agrGen), cwD = mm(p.agrUz || 300), cwH = 0.8;
  let cwX = 0, cwZ = 0;
  if (p.yonKodu === 'SOL') { cwX = -cx + mm(p.agrDuv) + cwW / 2; cwZ = 0; }
  else if (p.yonKodu === 'SAG') { cwX = cx - mm(p.agrDuv) - cwW / 2; cwZ = 0; }
  else { cwX = 0; cwZ = -cz + mm(p.agrDuv) + cwD / 2; }

  const cwY = H - cabinY - cwH;
  const group = new THREE.Group();
  group.position.set(cwX, cwY, cwZ);

  // Frame (U-channel)
  const frameT = 0.015;
  // Side plates
  // Frame (turquoise/cyan like reference)
  const frameMat = new THREE.MeshStandardMaterial({ color: 0x44aaaa, roughness: 0.4, metalness: 0.5 });
  const lFrame = new THREE.Mesh(new THREE.BoxGeometry(frameT, cwH + 0.15, cwD + 0.02), frameMat);
  lFrame.position.set(-cwW/2 - frameT/2, cwH/2, 0); lFrame.name = 'Ağırlık Çerçeve Sol';
  group.add(lFrame);
  const rFrame = new THREE.Mesh(new THREE.BoxGeometry(frameT, cwH + 0.15, cwD + 0.02), frameMat);
  rFrame.position.set(cwW/2 + frameT/2, cwH/2, 0); rFrame.name = 'Ağırlık Çerçeve Sağ';
  group.add(rFrame);
  // Front & back frame rails
  const fbFrame = new THREE.Mesh(new THREE.BoxGeometry(cwW + frameT*2, cwH + 0.15, frameT), frameMat);
  fbFrame.position.set(0, cwH/2, cwD/2 + frameT/2); fbFrame.name = 'Ağırlık Çerçeve Ön';
  group.add(fbFrame);
  const bbFrame = new THREE.Mesh(new THREE.BoxGeometry(cwW + frameT*2, cwH + 0.15, frameT), frameMat);
  bbFrame.position.set(0, cwH/2, -cwD/2 - frameT/2); bbFrame.name = 'Ağırlık Çerçeve Arka';
  group.add(bbFrame);
  // Top crossbar
  const topBar = new THREE.Mesh(new THREE.BoxGeometry(cwW + frameT*2 + 0.02, 0.04, cwD + 0.04), frameMat);
  topBar.position.set(0, cwH + 0.08, 0); topBar.name = 'Ağırlık Üst Bağlantı';
  group.add(topBar);
  // Bottom crossbar
  const botBar = new THREE.Mesh(new THREE.BoxGeometry(cwW + frameT*2 + 0.02, 0.04, cwD + 0.04), frameMat);
  botBar.position.set(0, -0.06, 0); botBar.name = 'Ağırlık Alt Bağlantı';
  group.add(botBar);

  // Weight plates (stacked — YELLOW like reference)
  const yellowPlateMat = new THREE.MeshStandardMaterial({ color: 0xddcc00, roughness: 0.5, metalness: 0.2 });
  const plateCount = Math.max(8, Math.round(cwH / 0.05));
  const totalPlateH = cwH * 0.9;
  const plateH = totalPlateH / plateCount * 0.92;
  const plateGap = totalPlateH / plateCount * 0.08;
  for (let i = 0; i < plateCount; i++) {
    const plate = new THREE.Mesh(new THREE.BoxGeometry(cwW - 0.01, plateH, cwD - 0.01), yellowPlateMat);
    plate.position.set(0, i * (plateH + plateGap) + plateH/2 + 0.02, 0); plate.castShadow = true;
    plate.name = `Ağırlık Plakası ${i + 1}`;
    group.add(plate);
  }

  // Guide shoes (4 — cyan colored)
  const shoeGeo = new THREE.BoxGeometry(0.06, 0.08, 0.04);
  const shoeMat = new THREE.MeshStandardMaterial({ color: 0xccaa00, roughness: 0.5, metalness: 0.3 });
  [[-cwW/2 - 0.04, cwH + 0.02], [-cwW/2 - 0.04, -0.02],
   [cwW/2 + 0.04, cwH + 0.02], [cwW/2 + 0.04, -0.02]].forEach(([sx, sy], i) => {
    const shoe = new THREE.Mesh(shoeGeo, shoeMat);
    shoe.position.set(sx, sy, 0); shoe.name = `Ağırlık Kılavuz ${i+1}`;
    group.add(shoe);
  });

  // Rope attachment block (green like reference)
  const ropeBlockMat = new THREE.MeshStandardMaterial({ color: 0x33aa55, roughness: 0.4, metalness: 0.3 });
  const ropeBlock = new THREE.Mesh(new THREE.BoxGeometry(cwW * 0.5, 0.08, cwD * 0.4), ropeBlockMat);
  ropeBlock.position.set(0, cwH + 0.14, 0); ropeBlock.name = 'Halat Bağlantı Bloğu';
  group.add(ropeBlock);
  // Rope sheave on top
  const attachGeo = new THREE.CylinderGeometry(0.03, 0.03, cwW * 0.6, 12);
  const attach = new THREE.Mesh(attachGeo, mats.steel);
  attach.rotation.z = Math.PI / 2;
  attach.position.set(0, cwH + 0.2, 0); attach.name = 'Halat Bağlantısı';
  group.add(attach);

  // ── Edge highlights ──
  const cwSnapshot = [...group.children];
  cwSnapshot.forEach(child => {
    if (child instanceof THREE.Mesh && child.geometry) {
      const edges = new THREE.EdgesGeometry(child.geometry, 15);
      const line = new THREE.LineSegments(edges, new THREE.LineBasicMaterial({ color: 0x111111, transparent: true, opacity: 0.45 }));
      line.position.copy(child.position); line.rotation.copy(child.rotation);
      group.add(line);
    }
  });

  return group;
}

function buildDoors(mats: ReturnType<typeof createMaterials>,
  p: ElevatorParams, doorW: number, doorH: number, _cx: number, cz: number, wallT: number): THREE.Mesh[] {
  const meshes: THREE.Mesh[] = [];
  const frontZ = cz + wallT / 2 + 0.005;
  let floorY = mm(p.kuyuDibi);
  const panelW = doorW / 2;
  const panelT = 0.04; // door panel thickness (40mm)
  const gapW = 0.004; // gap between panels

  // Door sill profile (extruded)
  const sillProfile = createDoorSillProfile();
  const sillExtSettings = { steps: 1, depth: doorW + 0.12, bevelEnabled: false };
  const sillGeo = new THREE.ExtrudeGeometry(sillProfile, sillExtSettings);
  sillGeo.rotateY(Math.PI / 2);
  sillGeo.translate(-(doorW + 0.12) / 2, 0, 0);

  for (let i = 0; i < p.katlar.length; i++) {
    // Left door panel (with bevel)
    const lDoorGeo = new THREE.BoxGeometry(panelW - gapW, doorH, panelT, 1, 1, 1);
    const lDoor = new THREE.Mesh(lDoorGeo, mats.steel);
    lDoor.position.set(-panelW / 2 - gapW / 2, floorY + doorH / 2, frontZ);
    lDoor.castShadow = true;
    meshes.push(lDoor);

    // Right door panel
    const rDoorGeo = new THREE.BoxGeometry(panelW - gapW, doorH, panelT, 1, 1, 1);
    const rDoor = new THREE.Mesh(rDoorGeo, mats.steel);
    rDoor.position.set(panelW / 2 + gapW / 2, floorY + doorH / 2, frontZ);
    rDoor.castShadow = true;
    meshes.push(rDoor);

    // Door sill (extruded T-profile)
    const sill = new THREE.Mesh(sillGeo.clone(), mats.darkSteel);
    sill.position.set(0, floorY, frontZ);
    meshes.push(sill);

    // Door header beam
    const header = new THREE.Mesh(new THREE.BoxGeometry(doorW + 0.1, 0.06, 0.08), mats.darkSteel);
    header.position.set(0, floorY + doorH + 0.03, frontZ);
    meshes.push(header);

    // Door shoes (bottom guides, 2 per panel)
    [-panelW / 2, panelW / 2].forEach(sx => {
      const shoe = new THREE.Mesh(new THREE.BoxGeometry(0.04, 0.02, 0.03), mats.darkSteel);
      shoe.position.set(sx, floorY + 0.01, frontZ + panelT / 2 + 0.015);
      meshes.push(shoe);
    });

    // Edge highlights on door panels
    [lDoor, rDoor].forEach(d => {
      const edges = new THREE.EdgesGeometry(d.geometry, 15);
      const line = new THREE.LineSegments(edges, new THREE.LineBasicMaterial({ color: 0x111111, transparent: true, opacity: 0.5 }));
      line.position.copy(d.position);
      meshes.push(line as unknown as THREE.Mesh);
    });

    // Vertical slats on door panels (lamel — like reference image)
    const slatCount = Math.max(3, Math.floor(panelW / 0.06));
    const slatW = 0.004, slatD = panelT + 0.002;
    const slatMat = new THREE.MeshStandardMaterial({ color: 0x888888, metalness: 0.7, roughness: 0.3 });
    for (let si = 1; si < slatCount; si++) {
      const sx = si * ((panelW - gapW) / slatCount) - (panelW - gapW) / 2;
      // Left panel slat
      const lSlat = new THREE.Mesh(new THREE.BoxGeometry(slatW, doorH * 0.92, slatD), slatMat);
      lSlat.position.set(-panelW / 2 - gapW / 2 + sx, floorY + doorH / 2, frontZ);
      meshes.push(lSlat);
      // Right panel slat
      const rSlat = new THREE.Mesh(new THREE.BoxGeometry(slatW, doorH * 0.92, slatD), slatMat);
      rSlat.position.set(panelW / 2 + gapW / 2 + sx, floorY + doorH / 2, frontZ);
      meshes.push(rSlat);
    }

    if (i < p.katlar.length - 1) floorY += mm(p.katlar[i].yukseklik);
  }
  return meshes;
}

function buildBuffers(mats: ReturnType<typeof createMaterials>, cW: number): THREE.Mesh[] {
  const meshes: THREE.Mesh[] = [];
  const bufferH = 0.30, bufferR = 0.065;
  const blueMat = new THREE.MeshStandardMaterial({ color: 0x3355cc, roughness: 0.4, metalness: 0.5 });
  const orangeMat = new THREE.MeshStandardMaterial({ color: 0xcc7722, roughness: 0.5, metalness: 0.3 });

  // ── Main support beam (I-profile, blue — like reference) ──
  const beamW = cW * 0.9, beamH = 0.12, beamFlange = 0.008;
  // Web
  const web = new THREE.Mesh(new THREE.BoxGeometry(beamW, beamH, 0.008), blueMat);
  web.position.set(0, beamH / 2 + 0.01, 0); web.castShadow = true;
  meshes.push(web);
  // Top flange
  const topF = new THREE.Mesh(new THREE.BoxGeometry(beamW, beamFlange, 0.08), blueMat);
  topF.position.set(0, beamH + 0.01, 0); meshes.push(topF);
  // Bottom flange
  const botF = new THREE.Mesh(new THREE.BoxGeometry(beamW, beamFlange, 0.08), blueMat);
  botF.position.set(0, 0.01, 0); meshes.push(botF);

  // ── Cross beam (perpendicular) ──
  const crossW = 0.08;
  [-cW / 4, cW / 4].forEach(cx => {
    const crossWeb = new THREE.Mesh(new THREE.BoxGeometry(0.006, beamH * 0.8, crossW), blueMat);
    crossWeb.position.set(cx, beamH * 0.4 + 0.01, 0); meshes.push(crossWeb);
  });

  // ── Buffer base plates (orange/brown — like reference) ──
  const positions: [number, number, number][] = [[-cW / 4, 0, 0], [cW / 4, 0, 0]];
  for (const [bx, , bz] of positions) {
    // Orange base plate
    const basePlate = new THREE.Mesh(new THREE.BoxGeometry(0.18, 0.02, 0.18), orangeMat);
    basePlate.position.set(bx, beamH + 0.02, bz); basePlate.castShadow = true;
    meshes.push(basePlate);

    // Buffer cylinder body (oil buffer style)
    const outerCyl = new THREE.Mesh(new THREE.CylinderGeometry(bufferR, bufferR, bufferH, 16), mats.darkSteel);
    outerCyl.position.set(bx, beamH + 0.03 + bufferH / 2, bz); outerCyl.castShadow = true;
    meshes.push(outerCyl);

    // Inner piston rod
    const pistonR = bufferR * 0.4;
    const pistonH = bufferH * 0.6;
    const piston = new THREE.Mesh(new THREE.CylinderGeometry(pistonR, pistonR, pistonH, 12), mats.steel);
    piston.position.set(bx, beamH + 0.03 + bufferH + pistonH / 2, bz);
    meshes.push(piston);

    // Top cap
    const cap = new THREE.Mesh(new THREE.CylinderGeometry(bufferR * 0.7, pistonR, 0.02, 12), mats.steel);
    cap.position.set(bx, beamH + 0.03 + bufferH + pistonH + 0.01, bz);
    meshes.push(cap);

    // Mounting bolts (4 per buffer — on base plate)
    for (let b = 0; b < 4; b++) {
      const angle = (b / 4) * Math.PI * 2 + Math.PI / 4;
      const boltR2 = 0.07;
      const bolt = new THREE.Mesh(new THREE.CylinderGeometry(0.006, 0.006, 0.025, 6), mats.yellow);
      bolt.position.set(bx + boltR2 * Math.cos(angle), beamH + 0.035, bz + boltR2 * Math.sin(angle));
      meshes.push(bolt);
    }

    // Edge highlights on buffer
    [outerCyl, basePlate].forEach(m => {
      const edges = new THREE.EdgesGeometry(m.geometry, 15);
      const line = new THREE.LineSegments(edges, new THREE.LineBasicMaterial({ color: 0x111111, transparent: true, opacity: 0.4 }));
      line.position.copy(m.position); line.rotation.copy(m.rotation);
      meshes.push(line as unknown as THREE.Mesh);
    });
  }

  // ── Rail base brackets (L-profile feet — at floor level) ──
  const railFootMat = mats.darkSteel;
  [-cW / 2 - 0.05, cW / 2 + 0.05].forEach((rx, i) => {
    // Vertical plate
    const vPlate = new THREE.Mesh(new THREE.BoxGeometry(0.06, 0.1, 0.04), railFootMat);
    vPlate.position.set(rx, 0.05, -0.1); vPlate.castShadow = true;
    meshes.push(vPlate);
    // Horizontal foot
    const hFoot = new THREE.Mesh(new THREE.BoxGeometry(0.1, 0.012, 0.08), railFootMat);
    hFoot.position.set(rx, 0.006, -0.1);
    meshes.push(hFoot);
    // Anchor bolts (2 per foot)
    [-0.025, 0.025].forEach(bOff => {
      const bolt = new THREE.Mesh(new THREE.CylinderGeometry(0.005, 0.005, 0.03, 6), mats.yellow);
      bolt.position.set(rx + bOff, 0.015, -0.1);
      meshes.push(bolt);
    });
  });

  // ── Compensation chain guide (telafi zinciri kılavuzu) ──
  const chainGuide = new THREE.Mesh(new THREE.BoxGeometry(cW * 0.4, 0.04, 0.04), blueMat);
  chainGuide.position.set(0, 0.02, 0.15);
  meshes.push(chainGuide);

  return meshes;
}

function buildRopes(mats: ReturnType<typeof createMaterials>,
  p: ElevatorParams, cabinY: number, H: number, _cW: number): THREE.Mesh[] {
  const meshes: THREE.Mesh[] = [];
  const ropeR = mm(p.halatCapi) / 2 || 0.005;
  const ropeCount = Math.min(p.halatSayisi || 4, 6);
  const topY = H + 0.5;
  const spacing = 0.04;
  const ropeMat = new THREE.MeshStandardMaterial({ color: 0xccaa00, roughness: 0.6, metalness: 0.4 }); // yellow/gold ropes
  for (let i = 0; i < ropeCount; i++) {
    const x = (i - (ropeCount - 1) / 2) * spacing;
    const ropeH = topY - cabinY - mm(p.kapiH + 200);
    if (ropeH > 0) {
      const rope = new THREE.Mesh(new THREE.CylinderGeometry(ropeR, ropeR, ropeH, 6), ropeMat);
      rope.position.set(x, cabinY + mm(p.kapiH + 200) + ropeH / 2, 0);
      rope.castShadow = true;
      meshes.push(rope);
    }
  }
  return meshes;
}

function buildMachineRoom(mats: ReturnType<typeof createMaterials>,
  p: ElevatorParams, H: number, W: number, _D: number, cx: number, cz: number, wallT: number): THREE.Group {
  const group = new THREE.Group();
  group.position.set(0, H, 0);
  const D = mm(p.kuyuDer);
  const yellowMat = new THREE.MeshStandardMaterial({ color: 0xddcc00, roughness: 0.4, metalness: 0.3 });
  const redMat = new THREE.MeshStandardMaterial({ color: 0xcc3333, roughness: 0.5, metalness: 0.3 });
  const blueMat = new THREE.MeshStandardMaterial({ color: 0x3355cc, roughness: 0.4, metalness: 0.5 });
  const cyanMat = new THREE.MeshStandardMaterial({ color: 0x00aaaa, roughness: 0.3, metalness: 0.4 });

  // ── Floor slab (döşeme) ──
  const slab = new THREE.Mesh(new THREE.BoxGeometry(W + wallT * 2, 0.15, D + wallT * 2), mats.concrete);
  slab.position.set(0, 0, 0); slab.receiveShadow = true; slab.name = 'Makine Dairesi Döşemesi';
  group.add(slab);

  // ── Support columns under slab (4 köşe kolon) ──
  const colH = 0.6;
  [[-cx + 0.15, -cz + 0.15], [-cx + 0.15, cz - 0.15],
   [cx - 0.15, -cz + 0.15], [cx - 0.15, cz - 0.15]].forEach(([colX, colZ], i) => {
    const col = new THREE.Mesh(new THREE.BoxGeometry(0.08, colH, 0.08), mats.darkSteel);
    col.position.set(colX, -colH / 2, colZ); col.castShadow = true;
    col.name = `Döşeme Kolonu ${i + 1}`;
    group.add(col);
  });

  // ── Motor base frame (sarı çelik platform — like reference) ──
  const frameW = W * 0.6, frameD = D * 0.5, frameH = 0.06;
  const motorFrame = new THREE.Mesh(new THREE.BoxGeometry(frameW, frameH, frameD), yellowMat);
  motorFrame.position.set(0, 0.08 + frameH / 2, -cz + D * 0.35);
  motorFrame.castShadow = true; motorFrame.name = 'Motor Taban Çerçevesi';
  group.add(motorFrame);
  // Frame edge beams (4 sides)
  const edgeH = 0.04;
  [[-frameW/2, 0], [frameW/2, 0]].forEach(([ex], i) => {
    const edge = new THREE.Mesh(new THREE.BoxGeometry(0.04, edgeH, frameD), yellowMat);
    edge.position.set(ex, 0.08 + frameH + edgeH/2, -cz + D * 0.35);
    group.add(edge);
  });
  [[0, -frameD/2], [0, frameD/2]].forEach(([, ez], i) => {
    const edge = new THREE.Mesh(new THREE.BoxGeometry(frameW, edgeH, 0.04), yellowMat);
    edge.position.set(0, 0.08 + frameH + edgeH/2, -cz + D * 0.35 + ez);
    group.add(edge);
  });

  // ── Vibration dampers (kırmızı titreşim takozları — 4 köşe) ──
  [[-frameW/2 + 0.06, -frameD/2 + 0.06], [-frameW/2 + 0.06, frameD/2 - 0.06],
   [frameW/2 - 0.06, -frameD/2 + 0.06], [frameW/2 - 0.06, frameD/2 - 0.06]].forEach(([dx, dz], i) => {
    const damper = new THREE.Mesh(new THREE.BoxGeometry(0.06, 0.03, 0.06), redMat);
    damper.position.set(dx, 0.08 + frameH + 0.015, -cz + D * 0.35 + dz);
    damper.name = `Titreşim Takozu ${i + 1}`;
    group.add(damper);
  });

  // ── Traction Machine (büyük turkuaz silindir — like reference) ──
  const machineR = 0.22, machineL = frameD * 0.7;
  const machine = new THREE.Mesh(new THREE.CylinderGeometry(machineR, machineR, machineL, 32), cyanMat);
  machine.rotation.x = Math.PI / 2;
  machine.position.set(0, 0.08 + frameH + 0.03 + machineR, -cz + D * 0.35);
  machine.castShadow = true; machine.name = 'Tahrik Makinesi';
  group.add(machine);
  // Machine end caps
  [-machineL/2, machineL/2].forEach((mz, i) => {
    const cap = new THREE.Mesh(new THREE.CylinderGeometry(machineR * 0.95, machineR * 0.95, 0.02, 32), mats.darkSteel);
    cap.rotation.x = Math.PI / 2;
    cap.position.set(0, 0.08 + frameH + 0.03 + machineR, -cz + D * 0.35 + mz);
    group.add(cap);
  });

  // ── Motor (sarı kutu, makine yanında) ──
  const motor = new THREE.Mesh(new THREE.BoxGeometry(0.25, 0.22, 0.25), yellowMat);
  motor.position.set(frameW / 2 - 0.15, 0.08 + frameH + 0.03 + 0.11, -cz + D * 0.35);
  motor.castShadow = true; motor.name = 'Motor';
  group.add(motor);

  // ── Sheaves (kasnaklar — üstte, büyük) ──
  const sheaveR = mm(p.tahrikKas || 400) / 2;
  const sheaveY = 0.08 + frameH + 0.03 + machineR * 2 + 0.15;
  // Main traction sheave
  const sheave1 = new THREE.Mesh(new THREE.TorusGeometry(sheaveR, sheaveR * 0.15, 16, 32), cyanMat);
  sheave1.rotation.y = Math.PI / 2;
  sheave1.position.set(-0.1, sheaveY, -cz + D * 0.35);
  sheave1.castShadow = true; sheave1.name = 'Tahrik Kasnağı';
  group.add(sheave1);
  // Deflection sheave
  const sheave2 = new THREE.Mesh(new THREE.TorusGeometry(sheaveR * 0.8, sheaveR * 0.12, 16, 32), cyanMat);
  sheave2.rotation.y = Math.PI / 2;
  sheave2.position.set(0.15, sheaveY, -cz + D * 0.35);
  sheave2.castShadow = true; sheave2.name = 'Saptırma Kasnağı';
  group.add(sheave2);
  // Sheave support frame (mavi çelik)
  const sheaveFrame = new THREE.Mesh(new THREE.BoxGeometry(0.5, 0.04, 0.15), blueMat);
  sheaveFrame.position.set(0, sheaveY - sheaveR - 0.02, -cz + D * 0.35);
  sheaveFrame.name = 'Kasnak Taşıyıcı';
  group.add(sheaveFrame);
  // Vertical sheave supports
  [-0.2, 0.2].forEach((sx, i) => {
    const sup = new THREE.Mesh(new THREE.BoxGeometry(0.04, sheaveR * 2 + 0.1, 0.04), blueMat);
    sup.position.set(sx, sheaveY - sheaveR / 2, -cz + D * 0.35);
    group.add(sup);
  });

  // ── Halat deliği (döşemede) ──
  const holeMarker = new THREE.Mesh(new THREE.RingGeometry(0.03, 0.08, 16), new THREE.MeshBasicMaterial({ color: 0x333333, side: THREE.DoubleSide }));
  holeMarker.rotation.x = -Math.PI / 2;
  holeMarker.position.set(0, 0.076, 0);
  group.add(holeMarker);

  // ── Governor (regülatör — sol duvarda) ──
  const govBox = new THREE.Mesh(new THREE.BoxGeometry(0.15, 0.2, 0.12), mats.darkSteel);
  govBox.position.set(-cx + 0.15, 0.35, cz - 0.2); govBox.name = 'Hız Regülatörü';
  govBox.userData.partGroup = 'regulator';
  group.add(govBox);
  // Governor mounting brackets (red)
  [-0.08, 0.08].forEach(dy => {
    const bracket = new THREE.Mesh(new THREE.BoxGeometry(0.04, 0.04, 0.06), redMat);
    bracket.position.set(-cx + 0.08, 0.35 + dy, cz - 0.2);
    group.add(bracket);
  });
  // Governor rope wheel
  const govWheel = new THREE.Mesh(new THREE.TorusGeometry(0.06, 0.008, 8, 16), mats.steel);
  govWheel.position.set(-cx + 0.15, 0.35, cz - 0.2); govWheel.name = 'Regülatör Kasnağı';
  group.add(govWheel);

  // ── Control Panel (kontrol panosu) ──
  const panel = new THREE.Mesh(new THREE.BoxGeometry(0.6, 1.0, 0.12), mats.darkSteel);
  panel.position.set(cx - 0.35, 0.6, -cz + 0.1); panel.name = 'Kontrol Panosu';
  group.add(panel);
  const handle = new THREE.Mesh(new THREE.CylinderGeometry(0.005, 0.005, 0.12, 6), mats.steel);
  handle.position.set(cx - 0.35 + 0.25, 0.6, -cz + 0.17); handle.name = 'Pano Kolu';
  group.add(handle);

  // ── Steel I-Beams (taşıyıcı kirişler — mavi) ──
  const beamW2 = W * 0.85, beamH2 = 0.12;
  for (let i = 0; i < 2; i++) {
    const bz = -cz / 2 + i * cz;
    const web2 = new THREE.Mesh(new THREE.BoxGeometry(beamW2, beamH2, 0.008), blueMat);
    web2.position.set(0, 0.08, bz); web2.name = `Çelik Kiriş ${i + 1}`;
    group.add(web2);
    const topF2 = new THREE.Mesh(new THREE.BoxGeometry(beamW2, 0.01, 0.1), blueMat);
    topF2.position.set(0, 0.08 + beamH2/2, bz); group.add(topF2);
    const botF2 = new THREE.Mesh(new THREE.BoxGeometry(beamW2, 0.01, 0.1), blueMat);
    botF2.position.set(0, 0.08 - beamH2/2, bz); group.add(botF2);
  }

  // ── Lighting ──
  const mrLight = new THREE.PointLight(0xfff5e0, 0.5, 6);
  mrLight.position.set(0, 1.5, 0);
  group.add(mrLight);

  // ── Edge highlights ──
  const mrSnapshot = [...group.children];
  mrSnapshot.forEach(child => {
    if (child instanceof THREE.Mesh && child.geometry) {
      const edges = new THREE.EdgesGeometry(child.geometry, 15);
      const line = new THREE.LineSegments(edges, new THREE.LineBasicMaterial({ color: 0x111111, transparent: true, opacity: 0.45 }));
      line.position.copy(child.position); line.rotation.copy(child.rotation);
      group.add(line);
    }
  });

  return group;
}

// ─── View Presets ────────────────────────────────────────────────────────────
function applyViewPreset(camera: THREE.PerspectiveCamera, controls: OrbitControls, preset: ViewPreset, p: ElevatorParams) {
  const seyir = seyirMesafesi(p.katlar);
  const kuyuH = mm(p.kuyuDibi + seyir + p.kuyuKafa);
  const midY = kuyuH / 2;
  const dist = Math.max(mm(p.kuyuGen), kuyuH) * 1.5;
  controls.target.set(0, midY, 0);
  switch (preset) {
    case 'on': camera.position.set(0, midY, dist); break;
    case 'yan': camera.position.set(dist, midY, 0); break;
    case 'ust': camera.position.set(0, kuyuH + dist * 0.5, 0.01); break;
    case 'izometrik': camera.position.set(dist * 0.7, midY + dist * 0.4, dist * 0.7); break;
    case 'kabin-ici': {
      const cabinY = mm(p.kuyuDibi);
      const { kabinDer } = kabinBoyutlari(p);
      camera.position.set(0, cabinY + mm(p.kapiH) * 0.6, mm(kabinDer) * 0.3);
      controls.target.set(0, cabinY + mm(p.kapiH) * 0.5, mm(kabinDer) * 0.5);
      break;
    }
  }
  controls.update();
}

// ─── Exploded View Offsets ───────────────────────────────────────────────────
const EXPLODE_OFFSETS: Record<PartGroup, THREE.Vector3> = {
  kuyu: new THREE.Vector3(0, 0, 0),
  ray: new THREE.Vector3(0, 0, 0),
  kabin: new THREE.Vector3(0, -2, 0),
  agirlik: new THREE.Vector3(1.5, 0, 0),
  kapi: new THREE.Vector3(0, 0, 1),
  makine: new THREE.Vector3(0, 2, 0),
  kasnak: new THREE.Vector3(0, 2, 0),
  tampon: new THREE.Vector3(0, -0.5, 0),
  halat: new THREE.Vector3(0, 0, 0),
  regulator: new THREE.Vector3(-1, 0, 0),
};

// ─── Feature Tree Panel ─────────────────────────────────────────────────────
function FeatureTreePanel({ parts, hiddenGroups, selectedPart, isolatedPart, onToggleGroup, onSelectPart, onIsolate }: {
  parts: PartInfo[];
  hiddenGroups: Set<PartGroup>;
  selectedPart: string | null;
  isolatedPart: string | null;
  onToggleGroup: (g: PartGroup) => void;
  onSelectPart: (name: string | null) => void;
  onIsolate: (name: string | null) => void;
}) {
  const grouped = useMemo(() => {
    const map = new Map<PartGroup, PartInfo[]>();
    for (const p of parts) {
      if (!map.has(p.group)) map.set(p.group, []);
      map.get(p.group)!.push(p);
    }
    return map;
  }, [parts]);

  const panelStyle: React.CSSProperties = {
    position: 'absolute', top: 0, left: 0, width: 210, height: '100%',
    background: 'rgba(15,23,42,0.92)', borderRight: '1px solid #334155',
    color: '#e2e8f0', fontSize: 11, overflowY: 'auto', zIndex: 20,
    backdropFilter: 'blur(8px)', padding: '8px 0',
  };

  const isoBtnStyle: React.CSSProperties = {
    background: 'none', border: 'none', cursor: 'pointer', padding: '0 3px',
    fontSize: 10, lineHeight: 1, flexShrink: 0,
  };

  return (
    <div style={panelStyle}>
      <div style={{ padding: '4px 10px', fontWeight: 700, fontSize: 12, borderBottom: '1px solid #334155', marginBottom: 4, display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
        <span>PARÇA AĞACI</span>
        {isolatedPart && (
          <button onClick={() => onIsolate(null)} style={{ ...isoBtnStyle, color: '#f59e0b', fontSize: 11 }} title="Tümünü Göster">
            ↩ Tümü
          </button>
        )}
      </div>
      {Array.from(grouped.entries()).map(([group, items]) => (
        <div key={group} style={{ marginBottom: 2 }}>
          <div style={{ display: 'flex', alignItems: 'center', padding: '3px 8px', cursor: 'pointer', background: 'rgba(30,41,59,0.5)' }}
            onClick={() => onToggleGroup(group)}>
            <span style={{ width: 18, textAlign: 'center', fontSize: 13, opacity: hiddenGroups.has(group) ? 0.3 : 1 }}>
              {hiddenGroups.has(group) ? '◻' : '◼'}
            </span>
            <span style={{ fontWeight: 600, flex: 1 }}>{GROUP_LABELS[group]}</span>
            <span style={{ color: '#64748b', fontSize: 10 }}>{items.length}</span>
          </div>
          {!hiddenGroups.has(group) && items.map(item => (
            <div key={item.name}
              style={{
                display: 'flex', alignItems: 'center',
                padding: '2px 4px 2px 22px', cursor: 'pointer', fontSize: 10,
                background: selectedPart === item.name ? 'rgba(234,179,8,0.2)' : isolatedPart === item.name ? 'rgba(59,130,246,0.15)' : 'transparent',
                color: selectedPart === item.name ? '#fbbf24' : isolatedPart === item.name ? '#60a5fa' : '#94a3b8',
                opacity: isolatedPart && isolatedPart !== item.name ? 0.4 : 1,
              }}>
              <span style={{ flex: 1, overflow: 'hidden', textOverflow: 'ellipsis', whiteSpace: 'nowrap' }}
                onClick={() => onSelectPart(selectedPart === item.name ? null : item.name)}>
                {item.name}
              </span>
              <button
                onClick={(e) => { e.stopPropagation(); onIsolate(isolatedPart === item.name ? null : item.name); }}
                style={{ ...isoBtnStyle, color: isolatedPart === item.name ? '#60a5fa' : '#475569' }}
                title={isolatedPart === item.name ? 'Tümünü Göster' : 'İzole Et'}>
                {isolatedPart === item.name ? '👁' : '◎'}
              </button>
            </div>
          ))}
        </div>
      ))}
    </div>
  );
}

// ─── BOM Panel ───────────────────────────────────────────────────────────────
function BomPanel({ items }: { items: BomItem[] }) {
  const total = items.reduce((s, i) => s + i.weight, 0);
  const panelStyle: React.CSSProperties = {
    position: 'absolute', top: 0, right: 0, width: 280, height: '100%',
    background: 'rgba(15,23,42,0.92)', borderLeft: '1px solid #334155',
    color: '#e2e8f0', fontSize: 11, overflowY: 'auto', zIndex: 20,
    backdropFilter: 'blur(8px)', padding: '8px 0',
  };
  const thStyle: React.CSSProperties = { padding: '3px 6px', textAlign: 'left', borderBottom: '1px solid #334155', fontWeight: 600, fontSize: 10 };
  const tdStyle: React.CSSProperties = { padding: '2px 6px', borderBottom: '1px solid rgba(51,65,85,0.4)', fontSize: 10 };

  return (
    <div style={panelStyle}>
      <div style={{ padding: '4px 10px', fontWeight: 700, fontSize: 12, borderBottom: '1px solid #334155', marginBottom: 4 }}>
        MALZEME LİSTESİ (BOM)
      </div>
      <table style={{ width: '100%', borderCollapse: 'collapse' }}>
        <thead>
          <tr>
            <th style={thStyle}>No</th>
            <th style={thStyle}>Parça Adı</th>
            <th style={thStyle}>Adet</th>
            <th style={thStyle}>Malzeme</th>
            <th style={{ ...thStyle, textAlign: 'right' }}>Ağırlık</th>
          </tr>
        </thead>
        <tbody>
          {items.map(item => (
            <tr key={item.no}>
              <td style={tdStyle}>{item.no}</td>
              <td style={tdStyle}>{item.name}</td>
              <td style={tdStyle}>{item.count}</td>
              <td style={tdStyle}>{item.material}</td>
              <td style={{ ...tdStyle, textAlign: 'right' }}>{item.weight} kg</td>
            </tr>
          ))}
          <tr style={{ fontWeight: 700, background: 'rgba(30,41,59,0.6)' }}>
            <td style={tdStyle} colSpan={4}>TOPLAM</td>
            <td style={{ ...tdStyle, textAlign: 'right' }}>{total} kg</td>
          </tr>
        </tbody>
      </table>
    </div>
  );
}

// ─── Part Detail Panel ───────────────────────────────────────────────────────
function PartDetailPanel({ partName, params, parts, onClose, onPrint }: {
  partName: string; params: ElevatorParams; parts: PartInfo[];
  onClose: () => void; onPrint: () => void;
}) {
  const props = getPartProperties(partName, params, parts);
  const panelStyle: React.CSSProperties = {
    position: 'absolute', top: '50%', left: '50%', transform: 'translate(-50%, -50%)',
    width: 420, maxHeight: '80vh', overflow: 'auto',
    background: 'rgba(10,15,30,0.96)', border: '1px solid #3b82f6',
    borderRadius: 8, color: '#e2e8f0', fontSize: 12, zIndex: 30,
    backdropFilter: 'blur(12px)', boxShadow: '0 20px 60px rgba(0,0,0,0.6)',
  };
  const headerStyle: React.CSSProperties = {
    padding: '12px 16px', borderBottom: '1px solid #334155',
    display: 'flex', justifyContent: 'space-between', alignItems: 'center',
  };
  const rowStyle: React.CSSProperties = { display: 'flex', padding: '6px 16px', borderBottom: '1px solid rgba(51,65,85,0.3)' };
  const labelSt: React.CSSProperties = { width: 120, color: '#94a3b8', fontSize: 11, flexShrink: 0 };
  const valSt: React.CSSProperties = { flex: 1, color: '#e2e8f0', fontSize: 11 };
  const btnSt: React.CSSProperties = {
    padding: '6px 14px', borderRadius: 4, border: 'none', cursor: 'pointer',
    fontSize: 11, fontWeight: 600,
  };

  const rows: [string, string][] = [
    ['Parça Adı', props.name],
    ['Grup', props.group],
    ['Malzeme', props.malzeme],
    ['Standart', props.standart],
    ['Boyut', props.boyut],
    ['Ağırlık', props.agirlik],
    ['Yüzey İşlemi', props.yuzeyIslemi],
    ['Tedarikçi', props.tedarikci],
    ['Birim Fiyat', props.birimFiyat],
    ['Teslimat Süresi', props.teslimatSuresi],
  ];

  return (
    <div style={panelStyle}>
      <div style={headerStyle}>
        <span style={{ fontWeight: 700, fontSize: 14, color: '#3b82f6' }}>📋 Parça Detayı</span>
        <button onClick={onClose} style={{ ...btnSt, background: '#334155', color: '#94a3b8' }}>✕</button>
      </div>
      {rows.map(([label, value]) => (
        <div key={label} style={rowStyle}>
          <span style={labelSt}>{label}</span>
          <span style={valSt}>{value}</span>
        </div>
      ))}
      <div style={{ padding: '8px 16px', borderTop: '1px solid #334155' }}>
        <div style={{ color: '#94a3b8', fontSize: 10, marginBottom: 4 }}>İmalat Notu:</div>
        <div style={{ color: '#fbbf24', fontSize: 11, lineHeight: 1.5, padding: '6px 8px', background: 'rgba(251,191,36,0.08)', borderRadius: 4 }}>
          {props.imalatNotu}
        </div>
      </div>
      <div style={{ padding: '10px 16px', display: 'flex', gap: 8, justifyContent: 'flex-end' }}>
        <button onClick={onPrint} style={{ ...btnSt, background: '#1e40af', color: '#fff' }}>🖨 İmalat Çıktısı</button>
        <button onClick={onClose} style={{ ...btnSt, background: '#334155', color: '#94a3b8' }}>Kapat</button>
      </div>
    </div>
  );
}

// ─── Main Component ──────────────────────────────────────────────────────────
export default function Elevator3DViewer({ params }: Elevator3DViewerProps) {
  const containerRef = useRef<HTMLDivElement>(null);
  const sceneRef = useRef<THREE.Scene | null>(null);
  const cameraRef = useRef<THREE.PerspectiveCamera | null>(null);
  const rendererRef = useRef<THREE.WebGLRenderer | null>(null);
  const controlsRef = useRef<OrbitControls | null>(null);
  const animIdRef = useRef<number>(0);
  const partsRef = useRef<PartInfo[]>([]);
  const explodeProgressRef = useRef(0);
  const explodedRef = useRef(false);
  const cabinAnimRef = useRef<{ from: number; to: number; t: number } | null>(null);

  const [wireframe, setWireframe] = useState(false);
  const [sectionCut, setSectionCut] = useState(false);
  const [currentFloor, setCurrentFloor] = useState(0);
  const [highQuality, setHighQuality] = useState(true);
  const [viewInfo, setViewInfo] = useState('İzometrik');
  const [exploded, setExploded] = useState(false);
  const [transparencyMode, setTransparencyMode] = useState(false);
  const [selectedPart, setSelectedPart] = useState<string | null>(null);
  const [isolatedPart, setIsolatedPart] = useState<string | null>(null);
  const [hiddenGroups, setHiddenGroups] = useState<Set<PartGroup>>(new Set());
  const [showFeatureTree, setShowFeatureTree] = useState(true);
  const [showBom, setShowBom] = useState(false);
  const [showPartDetail, setShowPartDetail] = useState(false);
  const [measureMode, setMeasureMode] = useState(false);
  const [measureText, setMeasureText] = useState('');
  const [showGrid3D, setShowGrid3D] = useState(true);
  const [cursorPos, setCursorPos] = useState<{ x: number; y: number }>({ x: 0, y: 0 });
  const [cursorVisible, setCursorVisible] = useState(false);
  const [snapActive, setSnapActive] = useState(false);
  const [snapLabel, setSnapLabel] = useState('');
  const [cabinAnimating, setCabinAnimating] = useState(false);
  const [partsVersion, setPartsVersion] = useState(0);

  const measureModeRef = useRef(false);
  const measureStartRef = useRef<THREE.Vector3 | null>(null);
  useEffect(() => { measureModeRef.current = measureMode; }, [measureMode]);

  const bomItems = useMemo(() => generateBOM(params), [params]);

  // Keep ref in sync with state for animation loop access
  useEffect(() => { explodedRef.current = exploded; }, [exploded]);

  // Store original positions for explode animation
  const origPositionsRef = useRef<Map<string, THREE.Vector3>>(new Map());
  const raycasterRef = useRef(new THREE.Raycaster());
  const mouseRef = useRef(new THREE.Vector2());

  // Initialize Three.js
  useEffect(() => {
    const container = containerRef.current;
    if (!container) return;

    const scene = new THREE.Scene();
    scene.background = new THREE.Color(0xe8e8ee);
    sceneRef.current = scene;

    const w = container.clientWidth, h = container.clientHeight;
    const camera = new THREE.PerspectiveCamera(50, w / h, 0.001, 500);
    cameraRef.current = camera;

    const renderer = new THREE.WebGLRenderer({ antialias: highQuality, alpha: false, preserveDrawingBuffer: true });
    renderer.setSize(w, h);
    renderer.setPixelRatio(highQuality ? Math.min(window.devicePixelRatio, 2) : 1);
    renderer.shadowMap.enabled = highQuality;
    renderer.shadowMap.type = THREE.PCFSoftShadowMap;
    renderer.toneMapping = THREE.ACESFilmicToneMapping;
    renderer.toneMappingExposure = 1.4;
    renderer.outputColorSpace = THREE.SRGBColorSpace;
    container.appendChild(renderer.domElement);
    rendererRef.current = renderer;

    const controls = new OrbitControls(camera, renderer.domElement);
    controls.enableDamping = true;
    controls.dampingFactor = 0.08;
    controls.minDistance = 0.01;
    controls.maxDistance = 500;
    controls.maxPolarAngle = Math.PI; // full freedom — can look from below too
    controls.enablePan = true;
    controls.panSpeed = 2.0;
    controls.rotateSpeed = 1.0;
    controls.enableRotate = true;
    controls.screenSpacePanning = true;
    controls.enableZoom = false; // We handle zoom ourselves for SketchUp-style zoom-to-cursor
    // Left=orbit, Middle=orbit, Right=pan (standard Three.js defaults work)
    controls.mouseButtons.LEFT = THREE.MOUSE.ROTATE;
    controls.mouseButtons.MIDDLE = THREE.MOUSE.DOLLY;
    controls.mouseButtons.RIGHT = THREE.MOUSE.PAN;
    controlsRef.current = controls;

    // ── Tekla-style zoom: middle-click sets pivot, scroll zooms toward pivot ──
    // Double-click also sets pivot (orbit center)
    let zoomPivot: THREE.Vector3 | null = null;

    const handleWheel = (event: WheelEvent) => {
      event.preventDefault();
      const zoomIn = event.deltaY < 0;
      const factor = zoomIn ? 0.85 : 1.18;

      // Zoom toward/away from pivot (or target if no pivot set)
      const pivot = zoomPivot || controls.target.clone();
      const dir = new THREE.Vector3().subVectors(pivot, camera.position);
      const dist = dir.length();

      if (zoomIn && dist < 0.001) return;

      const moveAmount = dist * (1 - factor);
      dir.normalize();

      // Move both camera AND target together (no rotation change)
      const moveVec = dir.clone().multiplyScalar(moveAmount);
      camera.position.add(moveVec);
      controls.target.add(moveVec);

      controls.update();
    };
    renderer.domElement.addEventListener('wheel', handleWheel, { passive: false });

    // Middle-click: set zoom/orbit pivot to clicked point
    renderer.domElement.addEventListener('mousedown', (event) => {
      if (event.button === 1) { // middle click
        const rect = renderer.domElement.getBoundingClientRect();
        const ndc = new THREE.Vector2(
          ((event.clientX - rect.left) / rect.width) * 2 - 1,
          -((event.clientY - rect.top) / rect.height) * 2 + 1
        );
        const rc = new THREE.Raycaster();
        rc.setFromCamera(ndc, camera);
        const targets = scene.children.filter(c =>
          !c.userData._isCursor && !c.userData._isMeasure && !c.userData._isMeasurePreview && !c.userData._isGrid
        );
        const hits = rc.intersectObjects(targets, true);
        if (hits.length > 0) {
          zoomPivot = hits[0].point.clone();
          controls.target.copy(zoomPivot);
          controls.update();
        }
      }
    });

    // Track mouse drag to distinguish click vs drag on left button
    let mouseDownPos = { x: 0, y: 0 };
    let isDragging = false;
    renderer.domElement.addEventListener('pointerdown', (e) => {
      mouseDownPos = { x: e.clientX, y: e.clientY };
      isDragging = false;
    });
    renderer.domElement.addEventListener('pointermove', (e) => {
      if (Math.abs(e.clientX - mouseDownPos.x) > 3 || Math.abs(e.clientY - mouseDownPos.y) > 3) {
        isDragging = true;
      }
    });

    // Raycasting: single click = select, double click = detail panel
    // Filter out kuyu (concrete) parts from selection
    const UNSELECTABLE_GROUPS = new Set(['kuyu']);

    const doRaycast = (event: MouseEvent): string | null => {
      const rect = renderer.domElement.getBoundingClientRect();
      mouseRef.current.x = ((event.clientX - rect.left) / rect.width) * 2 - 1;
      mouseRef.current.y = -((event.clientY - rect.top) / rect.height) * 2 + 1;
      raycasterRef.current.setFromCamera(mouseRef.current, camera);
      const intersects = raycasterRef.current.intersectObjects(scene.children, true);
      for (const hit of intersects) {
        let obj: THREE.Object3D = hit.object;
        while (obj && !obj.name && obj.parent) obj = obj.parent;
        if (obj.name && !obj.userData._isOutline) {
          // Skip kuyu/concrete parts
          const partGroup = obj.userData.partGroup as string;
          if (partGroup && UNSELECTABLE_GROUPS.has(partGroup)) continue;
          return obj.name;
        }
      }
      return null;
    };

    const doRaycastPoint = (event: MouseEvent): { point: THREE.Vector3; snapType: string } | null => {
      const rect = renderer.domElement.getBoundingClientRect();
      const mouseScreenX = event.clientX - rect.left;
      const mouseScreenY = event.clientY - rect.top;
      mouseRef.current.x = (mouseScreenX / rect.width) * 2 - 1;
      mouseRef.current.y = -(mouseScreenY / rect.height) * 2 + 1;
      raycasterRef.current.setFromCamera(mouseRef.current, camera);
      // Only raycast against model geometry — exclude catch planes, ground, grid, helpers
      const rayTargets = scene.children.filter(c =>
        !c.userData._isCursor && !c.userData._isMeasure && !c.userData._isMeasurePreview &&
        !c.userData._isOutline && !c.userData._isGrid && c.name !== '_catchPlane' &&
        !(c instanceof THREE.GridHelper)
      );
      const intersects = raycasterRef.current.intersectObjects(rayTargets, true);
      // Filter out ground plane hit (the large dark plane at y=-0.01)
      const modelHit = intersects.find(h => {
        const obj = h.object;
        return obj.name !== '' || (obj.parent && obj.parent.name !== '');
      });
      if (!modelHit) return null;

      const point = modelHit.point.clone();
      const faceNormal = modelHit.face?.normal?.clone() || new THREE.Vector3(0, 1, 0);

      // Screen-pixel-based snap
      const SNAP_PX = 18;
      let bestPixDist = SNAP_PX;
      let bestSnap: THREE.Vector3 | null = null;
      let bestSnapType = 'face';
      const tempV = new THREE.Vector3();
      const tempA = new THREE.Vector3();
      const tempB = new THREE.Vector3();
      const halfW = rect.width / 2;
      const halfH = rect.height / 2;

      const toScreen = (v: THREE.Vector3): [number, number] => {
        tempV.copy(v).project(camera);
        return [(tempV.x * halfW) + halfW, (-tempV.y * halfH) + halfH];
      };

      // Closest point on line segment AB to point P (for edge snap)
      const closestOnSegment = (a: THREE.Vector3, b: THREE.Vector3, p: THREE.Vector3): THREE.Vector3 => {
        const ab = tempV.subVectors(b, a);
        const len2 = ab.lengthSq();
        if (len2 < 1e-10) return a.clone();
        let t = new THREE.Vector3().subVectors(p, a).dot(ab) / len2;
        t = Math.max(0, Math.min(1, t));
        return a.clone().addScaledVector(ab, t);
      };

      scene.traverse(obj => {
        if (obj.userData._isCursor || obj.userData._isMeasure || obj.userData._isMeasurePreview || obj.userData._isGrid) return;
        if (obj.name === '_catchPlane') return;
        const geo = (obj instanceof THREE.Mesh || obj instanceof THREE.Line) ? obj.geometry : null;
        if (!geo || !geo.attributes.position) return;
        const pos = geo.attributes.position;
        const wm = obj.matrixWorld;

        // 1) Vertex snap (highest priority)
        for (let vi = 0; vi < pos.count; vi++) {
          tempA.fromBufferAttribute(pos, vi).applyMatrix4(wm);
          const [sx, sy] = toScreen(tempA);
          const pixDist = Math.hypot(sx - mouseScreenX, sy - mouseScreenY);
          if (pixDist < bestPixDist) {
            bestPixDist = pixDist;
            bestSnap = tempA.clone();
            bestSnapType = 'vertex';
          }
        }

        // 2) Edge midpoint + nearest-on-edge snap (lines)
        if (obj instanceof THREE.Line) {
          for (let vi = 0; vi < pos.count - 1; vi++) {
            tempA.fromBufferAttribute(pos, vi).applyMatrix4(wm);
            tempB.fromBufferAttribute(pos, vi + 1).applyMatrix4(wm);
            // Midpoint
            const mid = tempA.clone().add(tempB).multiplyScalar(0.5);
            const [mx, my] = toScreen(mid);
            const midPx = Math.hypot(mx - mouseScreenX, my - mouseScreenY);
            if (midPx < bestPixDist) {
              bestPixDist = midPx;
              bestSnap = mid;
              bestSnapType = 'midpoint';
            }
            // Nearest point on edge
            const nearest = closestOnSegment(tempA, tempB, point);
            const [nx, ny] = toScreen(nearest);
            const nearPx = Math.hypot(nx - mouseScreenX, ny - mouseScreenY);
            if (nearPx < bestPixDist * 0.8) { // edge snap slightly tighter
              bestPixDist = nearPx;
              bestSnap = nearest;
              bestSnapType = 'edge';
            }
          }
        }
      });

      const result = bestSnap || point;
      return { point: result, snapType: bestSnap ? bestSnapType : 'face' };
    };

    // 3D Cursor — SolidWorks style colored XYZ axes (large, prominent)
    const cursor3D = new THREE.Group();
    cursor3D.userData._isCursor = true;
    const cursorSize = 0.25; // 250mm — much more visible
    const cursorNeg = 0.08;
    // X axis (Red) — thick line
    const cxGeo = new THREE.BufferGeometry().setFromPoints([new THREE.Vector3(0, 0, 0), new THREE.Vector3(cursorSize, 0, 0)]);
    cursor3D.add(new THREE.Line(cxGeo, new THREE.LineBasicMaterial({ color: 0xff3333, linewidth: 2 })));
    const cxNeg = new THREE.BufferGeometry().setFromPoints([new THREE.Vector3(-cursorNeg, 0, 0), new THREE.Vector3(0, 0, 0)]);
    cursor3D.add(new THREE.Line(cxNeg, new THREE.LineBasicMaterial({ color: 0xff3333, transparent: true, opacity: 0.3 })));
    // X arrow cone
    const cxCone = new THREE.Mesh(new THREE.ConeGeometry(0.008, 0.03, 8), new THREE.MeshBasicMaterial({ color: 0xff3333 }));
    cxCone.rotation.z = -Math.PI / 2; cxCone.position.set(cursorSize + 0.015, 0, 0);
    cursor3D.add(cxCone);
    // Y axis (Green)
    const cyGeo = new THREE.BufferGeometry().setFromPoints([new THREE.Vector3(0, 0, 0), new THREE.Vector3(0, cursorSize, 0)]);
    cursor3D.add(new THREE.Line(cyGeo, new THREE.LineBasicMaterial({ color: 0x33ff33, linewidth: 2 })));
    const cyNeg = new THREE.BufferGeometry().setFromPoints([new THREE.Vector3(0, -cursorNeg, 0), new THREE.Vector3(0, 0, 0)]);
    cursor3D.add(new THREE.Line(cyNeg, new THREE.LineBasicMaterial({ color: 0x33ff33, transparent: true, opacity: 0.3 })));
    // Y arrow cone
    const cyCone = new THREE.Mesh(new THREE.ConeGeometry(0.008, 0.03, 8), new THREE.MeshBasicMaterial({ color: 0x33ff33 }));
    cyCone.position.set(0, cursorSize + 0.015, 0);
    cursor3D.add(cyCone);
    // Z axis (Blue)
    const czGeo = new THREE.BufferGeometry().setFromPoints([new THREE.Vector3(0, 0, 0), new THREE.Vector3(0, 0, cursorSize)]);
    cursor3D.add(new THREE.Line(czGeo, new THREE.LineBasicMaterial({ color: 0x3399ff, linewidth: 2 })));
    const czNeg = new THREE.BufferGeometry().setFromPoints([new THREE.Vector3(0, 0, -cursorNeg), new THREE.Vector3(0, 0, 0)]);
    cursor3D.add(new THREE.Line(czNeg, new THREE.LineBasicMaterial({ color: 0x3399ff, transparent: true, opacity: 0.3 })));
    // Z arrow cone
    const czCone = new THREE.Mesh(new THREE.ConeGeometry(0.008, 0.03, 8), new THREE.MeshBasicMaterial({ color: 0x3399ff }));
    czCone.rotation.x = Math.PI / 2; czCone.position.set(0, 0, cursorSize + 0.015);
    cursor3D.add(czCone);
    // Center sphere (white, glowing)
    const cursorDot = new THREE.Mesh(new THREE.SphereGeometry(0.01, 16, 16), new THREE.MeshBasicMaterial({ color: 0xffffff }));
    cursor3D.add(cursorDot);
    // Snap ring (appears when snapped to vertex — yellow torus)
    const snapRing = new THREE.Mesh(new THREE.TorusGeometry(0.02, 0.003, 8, 24), new THREE.MeshBasicMaterial({ color: 0xffff00 }));
    snapRing.rotation.x = Math.PI / 2;
    snapRing.visible = false;
    snapRing.name = '_snapRing';
    cursor3D.add(snapRing);
    // Snap square (appears when snapped to midpoint — green square)
    const snapSquareGeo = new THREE.BufferGeometry().setFromPoints([
      new THREE.Vector3(-0.015, -0.015, 0), new THREE.Vector3(0.015, -0.015, 0),
      new THREE.Vector3(0.015, 0.015, 0), new THREE.Vector3(-0.015, 0.015, 0),
      new THREE.Vector3(-0.015, -0.015, 0),
    ]);
    const snapSquare = new THREE.Line(snapSquareGeo, new THREE.LineBasicMaterial({ color: 0x00ff00 }));
    snapSquare.visible = false;
    snapSquare.name = '_snapSquare';
    cursor3D.add(snapSquare);
    cursor3D.visible = false;
    scene.add(cursor3D);

    // Invisible catch planes so cursor always has something to hit from any angle
    const catchPlane = new THREE.Mesh(
      new THREE.PlaneGeometry(60, 60),
      new THREE.MeshBasicMaterial({ visible: false, side: THREE.DoubleSide })
    );
    catchPlane.rotation.x = -Math.PI / 2;
    catchPlane.position.y = -0.02;
    catchPlane.userData._isCursor = true;
    catchPlane.name = '_catchPlane';
    scene.add(catchPlane);
    // Vertical catch plane (for side views)
    const catchPlaneV = new THREE.Mesh(
      new THREE.PlaneGeometry(60, 60),
      new THREE.MeshBasicMaterial({ visible: false, side: THREE.DoubleSide })
    );
    catchPlaneV.position.z = -2;
    catchPlaneV.userData._isCursor = true;
    catchPlaneV.name = '_catchPlane';
    scene.add(catchPlaneV);

    // Helper: create 3D text sprite for measurement label
    const createMeasureLabel = (text: string, position: THREE.Vector3): THREE.Sprite => {
      const canvas = document.createElement('canvas');
      canvas.width = 256; canvas.height = 48;
      const ctx = canvas.getContext('2d')!;
      ctx.fillStyle = 'rgba(0,0,0,0.8)';
      ctx.beginPath();
      ctx.roundRect(2, 2, 252, 44, 6);
      ctx.fill();
      ctx.strokeStyle = '#00ff00';
      ctx.lineWidth = 1.5;
      ctx.beginPath();
      ctx.roundRect(2, 2, 252, 44, 6);
      ctx.stroke();
      ctx.fillStyle = '#00ff00';
      ctx.font = 'bold 22px Arial';
      ctx.textAlign = 'center';
      ctx.textBaseline = 'middle';
      ctx.fillText(text, 128, 24);
      const tex = new THREE.CanvasTexture(canvas);
      const mat = new THREE.SpriteMaterial({ map: tex, transparent: true, depthTest: false, sizeAttenuation: true });
      const sprite = new THREE.Sprite(mat);
      sprite.position.copy(position);
      // Scale based on camera distance for consistent screen size
      const dist = camera.position.distanceTo(position);
      const s = Math.max(0.02, dist * 0.06);
      sprite.scale.set(s * 2, s * 0.4, 1);
      sprite.userData._isMeasure = true;
      return sprite;
    };

    // Mouse move handler for 3D cursor + snap
    const handleMouseMove = (event: MouseEvent) => {
      const containerRect = container.getBoundingClientRect();
      const mouseScreenX = event.clientX - containerRect.left;
      const mouseScreenY = event.clientY - containerRect.top;
      setCursorPos({ x: mouseScreenX, y: mouseScreenY });
      setCursorVisible(true);

      const rect = renderer.domElement.getBoundingClientRect();
      mouseRef.current.x = ((event.clientX - rect.left) / rect.width) * 2 - 1;
      mouseRef.current.y = -((event.clientY - rect.top) / rect.height) * 2 + 1;
      raycasterRef.current.setFromCamera(mouseRef.current, camera);

      // Two-pass raycast: first try model-only, then catch planes for cursor position
      const modelTargets = scene.children.filter(c =>
        !c.userData._isCursor && !c.userData._isMeasure && !c.userData._isMeasurePreview &&
        !c.userData._isOutline && !c.userData._isGrid && c.name !== '_catchPlane'
      );
      let intersects = raycasterRef.current.intersectObjects(modelTargets, true);
      // Filter out ground plane
      intersects = intersects.filter(h => h.object.name !== '' || (h.object.parent && h.object.parent.name !== ''));
      const onModel = intersects.length > 0;

      // If not on model, use catch planes for cursor position only
      if (!onModel) {
        const catchTargets = scene.children.filter(c => c.name === '_catchPlane');
        intersects = raycasterRef.current.intersectObjects(catchTargets, true);
      }

      if (intersects.length > 0) {
        const pt = intersects[0].point.clone();
        let snapped = false;
        let snapType: 'vertex' | 'midpoint' | 'edge' | 'face' | 'none' = 'none';

        // Only snap when on model
        if (onModel) {
          const SNAP_PX = 18;
          let bestPixDist = SNAP_PX;
          const tv = new THREE.Vector3();
          const tA = new THREE.Vector3();
          const tB = new THREE.Vector3();
          const halfW = rect.width / 2;
          const halfH = rect.height / 2;
          const msx = event.clientX - rect.left;
          const msy = event.clientY - rect.top;

          const toScr = (v: THREE.Vector3): [number, number] => {
            tv.copy(v).project(camera);
            return [(tv.x * halfW) + halfW, (-tv.y * halfH) + halfH];
          };

          const closestOnSeg = (a: THREE.Vector3, b: THREE.Vector3, p: THREE.Vector3): THREE.Vector3 => {
            const ab = tv.subVectors(b, a);
            const len2 = ab.lengthSq();
            if (len2 < 1e-10) return a.clone();
            let t = new THREE.Vector3().subVectors(p, a).dot(ab) / len2;
            t = Math.max(0, Math.min(1, t));
            return a.clone().addScaledVector(ab, t);
          };

          scene.traverse(obj => {
            if (obj.userData._isCursor || obj.userData._isMeasure || obj.userData._isMeasurePreview || obj.userData._isGrid) return;
            if (obj.name === '_catchPlane') return;
            const geo = (obj instanceof THREE.Mesh || obj instanceof THREE.Line) ? obj.geometry : null;
            if (!geo || !geo.attributes.position) return;
            const pos = geo.attributes.position;
            const wm = obj.matrixWorld;

            // Vertex snap
            for (let vi = 0; vi < pos.count; vi++) {
              tA.fromBufferAttribute(pos, vi).applyMatrix4(wm);
              const [sx, sy] = toScr(tA);
              const pixDist = Math.hypot(sx - msx, sy - msy);
              if (pixDist < bestPixDist) {
                bestPixDist = pixDist;
                pt.copy(tA);
                snapped = true;
                snapType = 'vertex';
              }
            }
            // Edge midpoint + nearest-on-edge (lines)
            if (obj instanceof THREE.Line) {
              for (let vi = 0; vi < pos.count - 1; vi++) {
                tA.fromBufferAttribute(pos, vi).applyMatrix4(wm);
                tB.fromBufferAttribute(pos, vi + 1).applyMatrix4(wm);
                // Midpoint
                const mid = tA.clone().add(tB).multiplyScalar(0.5);
                const [mx, my] = toScr(mid);
                const midPx = Math.hypot(mx - msx, my - msy);
                if (midPx < bestPixDist) {
                  bestPixDist = midPx;
                  pt.copy(mid);
                  snapped = true;
                  snapType = 'midpoint';
                }
                // Nearest on edge
                const nearest = closestOnSeg(tA, tB, intersects[0].point);
                const [nx, ny] = toScr(nearest);
                const nearPx = Math.hypot(nx - msx, ny - msy);
                if (nearPx < bestPixDist * 0.8) {
                  bestPixDist = nearPx;
                  pt.copy(nearest);
                  snapped = true;
                  snapType = 'edge';
                }
              }
            }
          });
        }

        cursor3D.position.copy(pt);
        cursor3D.visible = true;
        // Show snap indicators
        const ring = cursor3D.getObjectByName('_snapRing');
        const square = cursor3D.getObjectByName('_snapSquare');
        if (ring) ring.visible = snapped && snapType === 'vertex';
        if (square) square.visible = snapped && (snapType === 'midpoint' || snapType === 'edge');
        // Update HTML snap feedback
        setSnapActive(snapped);
        const snapLabels: Record<string, string> = { vertex: '◇ Köşe', midpoint: '△ Orta', edge: '— Kenar', face: '□ Yüzey', none: '' };
        setSnapLabel(snapped ? (snapLabels[snapType] || '') : '');

        // Draw preview line + live distance (only in measure mode, only on model)
        if (measureModeRef.current && onModel) {
          const oldPreview = scene.children.filter(c => c.userData._isMeasurePreview);
          oldPreview.forEach(o => scene.remove(o));
          if (measureStartRef.current) {
            const previewGeo = new THREE.BufferGeometry().setFromPoints([measureStartRef.current, pt]);
            const previewLine = new THREE.Line(previewGeo, new THREE.LineBasicMaterial({ color: 0x00ff00, transparent: true, opacity: 0.6 }));
            previewLine.userData._isMeasurePreview = true;
            scene.add(previewLine);
            const liveDist = measureStartRef.current.distanceTo(pt) * 1000;
            const mid = measureStartRef.current.clone().add(pt).multiplyScalar(0.5);
            mid.y += 0.02;
            const liveLabel = createMeasureLabel(`${liveDist.toFixed(0)} mm`, mid);
            liveLabel.userData._isMeasurePreview = true;
            scene.add(liveLabel);
          }
        } else if (measureModeRef.current && !onModel) {
          // Clear preview when off model
          const oldPreview = scene.children.filter(c => c.userData._isMeasurePreview);
          oldPreview.forEach(o => scene.remove(o));
        }
      } else {
        cursor3D.visible = false;
      }
    };
    renderer.domElement.addEventListener('mousemove', handleMouseMove);

    const handleClick = (event: MouseEvent) => {
      // Ignore if user was dragging (orbit/pan)
      if (isDragging) return;
      // Measurement mode — only works on model geometry
      if (measureModeRef.current) {
        const result = doRaycastPoint(event);
        if (result) {
          const pt = result.point;
          if (!measureStartRef.current) {
            // Clear previous measurements when starting new one
            const oldMeasures = scene.children.filter(c => c.userData._isMeasure);
            oldMeasures.forEach(o => scene.remove(o));
            measureStartRef.current = pt;
            setMeasureText(`Başlangıç: ${result.snapType} — İkinci noktayı tıklayın... (Esc=İptal)`);
            // Start point marker
            const startMarker = new THREE.Mesh(new THREE.SphereGeometry(0.004, 8, 8), new THREE.MeshBasicMaterial({ color: 0x00ff00 }));
            startMarker.position.copy(pt);
            startMarker.userData._isMeasure = true;
            scene.add(startMarker);
          } else {
            const dist = measureStartRef.current.distanceTo(pt) * 1000;
            const dx = Math.abs(pt.x - measureStartRef.current.x) * 1000;
            const dy = Math.abs(pt.y - measureStartRef.current.y) * 1000;
            const dz = Math.abs(pt.z - measureStartRef.current.z) * 1000;
            setMeasureText(`Mesafe: ${dist.toFixed(1)} mm (ΔX:${dx.toFixed(0)} ΔY:${dy.toFixed(0)} ΔZ:${dz.toFixed(0)})`);
            // Draw measurement line
            const lineGeo = new THREE.BufferGeometry().setFromPoints([measureStartRef.current, pt]);
            const lineMat = new THREE.LineBasicMaterial({ color: 0x00ff00, linewidth: 2 });
            const line = new THREE.Line(lineGeo, lineMat);
            line.userData._isMeasure = true;
            scene.add(line);
            // End point marker
            const endMarker = new THREE.Mesh(new THREE.SphereGeometry(0.004, 8, 8), new THREE.MeshBasicMaterial({ color: 0x00ff00 }));
            endMarker.position.copy(pt);
            endMarker.userData._isMeasure = true;
            scene.add(endMarker);
            // 3D measurement label at midpoint
            const mid = measureStartRef.current.clone().add(pt).multiplyScalar(0.5);
            mid.y += 0.02;
            const label = createMeasureLabel(`${dist.toFixed(1)} mm`, mid);
            scene.add(label);
            // Clean preview
            const oldPreview = scene.children.filter(c => c.userData._isMeasurePreview);
            oldPreview.forEach(o => scene.remove(o));
            measureStartRef.current = null;
          }
        } else {
          // Clicked on empty space — show warning
          setMeasureText('⚠ Model üzerine tıklayın! (Esc=İptal)');
        }
        return;
      }

      const name = doRaycast(event);
      if (name) {
        setSelectedPart(prev => prev === name ? null : name);
      } else {
        setSelectedPart(null);
      }
      setShowPartDetail(false);
    };

    const handleDblClick = (event: MouseEvent) => {
      if (isDragging) return;
      if (measureModeRef.current) return;
      // Set zoom pivot on double-click (Tekla style)
      const rect = renderer.domElement.getBoundingClientRect();
      const ndc = new THREE.Vector2(
        ((event.clientX - rect.left) / rect.width) * 2 - 1,
        -((event.clientY - rect.top) / rect.height) * 2 + 1
      );
      const rc = new THREE.Raycaster();
      rc.setFromCamera(ndc, camera);
      const targets = scene.children.filter(c =>
        !c.userData._isCursor && !c.userData._isMeasure && !c.userData._isMeasurePreview && !c.userData._isGrid
      );
      const hits = rc.intersectObjects(targets, true);
      if (hits.length > 0) {
        zoomPivot = hits[0].point.clone();
        controls.target.copy(zoomPivot);
        controls.update();
      }
      const name = doRaycast(event);
      if (name) {
        setSelectedPart(name);
        setShowPartDetail(true);
      }
    };

    renderer.domElement.addEventListener('click', handleClick);
    renderer.domElement.addEventListener('dblclick', handleDblClick);

    // ── Keyboard handler (AutoCAD style) ──
    // Esc = cancel active command (measure), deselect
    // F = fit/zoom extents
    const handleKeyDown = (event: KeyboardEvent) => {
      if (event.key === 'Escape') {
        if (measureModeRef.current && measureStartRef.current) {
          // Cancel current measurement point, keep mode active
          measureStartRef.current = null;
          setMeasureText('İlk noktayı tıklayın...');
          const old = scene.children.filter(c => c.userData._isMeasurePreview);
          old.forEach(o => scene.remove(o));
        } else if (measureModeRef.current) {
          // Second Esc exits measure mode entirely
          setMeasureMode(false);
          setMeasureText('');
          measureStartRef.current = null;
          const old = scene.children.filter(c => c.userData._isMeasure || c.userData._isMeasurePreview);
          old.forEach(o => scene.remove(o));
        } else {
          // Deselect
          setSelectedPart(null);
          setShowPartDetail(false);
        }
      }
      // F key = fit to view (zoom extents)
      if (event.key === 'f' || event.key === 'F') {
        if (document.activeElement?.tagName === 'INPUT' || document.activeElement?.tagName === 'SELECT') return;
        const box = new THREE.Box3();
        scene.traverse(obj => {
          if (obj instanceof THREE.Mesh && obj.visible && !obj.userData._isCursor && !obj.userData._isGrid) {
            box.expandByObject(obj);
          }
        });
        if (!box.isEmpty()) {
          const center = box.getCenter(new THREE.Vector3());
          const size = box.getSize(new THREE.Vector3());
          const maxDim = Math.max(size.x, size.y, size.z);
          controls.target.copy(center);
          camera.position.set(center.x + maxDim * 0.8, center.y + maxDim * 0.5, center.z + maxDim * 0.8);
          controls.update();
          setViewInfo('Sığdır');
        }
      }
    };
    window.addEventListener('keydown', handleKeyDown);

    const mats = createMaterials();
    buildScene(params, scene, mats, partsRef.current);
    applyViewPreset(camera, controls, 'izometrik', params);

    // Store original positions
    origPositionsRef.current.clear();
    for (const p of partsRef.current) {
      origPositionsRef.current.set(p.name, p.mesh.position.clone());
    }
    setPartsVersion(v => v + 1);

    // Render loop with explode + cabin animation
    const animate = () => {
      animIdRef.current = requestAnimationFrame(animate);
      controls.update();

      // Explode animation lerp
      const targetProgress = explodedRef.current ? 1 : 0;
      const ep = explodeProgressRef.current;
      if (Math.abs(ep - targetProgress) > 0.001) {
        explodeProgressRef.current += (targetProgress - ep) * 0.08;
        for (const part of partsRef.current) {
          const orig = origPositionsRef.current.get(part.name);
          if (!orig) continue;
          const offset = EXPLODE_OFFSETS[part.group] || new THREE.Vector3();
          part.mesh.position.lerpVectors(orig, orig.clone().add(offset), explodeProgressRef.current);
        }
      }

      // Cabin floor animation
      const ca = cabinAnimRef.current;
      if (ca && ca.t < 1) {
        ca.t = Math.min(ca.t + 0.03, 1);
        const cabinPart = partsRef.current.find(p => p.name === 'Kabin Grubu');
        if (cabinPart) {
          const y = ca.from + (ca.to - ca.from) * ca.t;
          cabinPart.mesh.position.y = y;
          if (ca.t >= 1) cabinAnimRef.current = null;
        }
      }

      renderer.render(scene, camera);
    };
    animate();

    const onResize = () => {
      const w = container.clientWidth, h = container.clientHeight;
      camera.aspect = w / h;
      camera.updateProjectionMatrix();
      renderer.setSize(w, h);
    };
    window.addEventListener('resize', onResize);
    const ro = new ResizeObserver(onResize);
    ro.observe(container);

    return () => {
      cancelAnimationFrame(animIdRef.current);
      window.removeEventListener('resize', onResize);
      window.removeEventListener('keydown', handleKeyDown);
      renderer.domElement.removeEventListener('click', handleClick);
      renderer.domElement.removeEventListener('dblclick', handleDblClick);
      renderer.domElement.removeEventListener('mousemove', handleMouseMove);
      renderer.domElement.removeEventListener('wheel', handleWheel);
      ro.disconnect();
      controls.dispose();
      renderer.dispose();
      if (container.contains(renderer.domElement)) container.removeChild(renderer.domElement);
    };
  }, []); // eslint-disable-line react-hooks/exhaustive-deps

  // Rebuild on params change
  useEffect(() => {
    const scene = sceneRef.current;
    if (!scene) return;
    const mats = createMaterials();
    buildScene(params, scene, mats, partsRef.current);
    origPositionsRef.current.clear();
    for (const p of partsRef.current) {
      origPositionsRef.current.set(p.name, p.mesh.position.clone());
    }
    explodeProgressRef.current = 0;
    setPartsVersion(v => v + 1);
  }, [params]);

  // Wireframe toggle
  useEffect(() => {
    const scene = sceneRef.current;
    if (!scene) return;
    scene.traverse(obj => {
      if (obj instanceof THREE.Mesh && obj.material) {
        const mat = obj.material as THREE.MeshStandardMaterial;
        if (mat.wireframe !== undefined) mat.wireframe = wireframe;
      }
    });
  }, [wireframe]);

  // Section cut toggle
  useEffect(() => {
    const renderer = rendererRef.current;
    if (!renderer) return;
    if (sectionCut) {
      const clipPlane = new THREE.Plane(new THREE.Vector3(0, 0, -1), mm(params.kuyuDer) * 0.3);
      renderer.clippingPlanes = [clipPlane];
      renderer.localClippingEnabled = true;
    } else {
      renderer.clippingPlanes = [];
      renderer.localClippingEnabled = false;
    }
  }, [sectionCut, params]);

  // Quality toggle
  useEffect(() => {
    const renderer = rendererRef.current;
    if (!renderer) return;
    renderer.shadowMap.enabled = highQuality;
    renderer.setPixelRatio(highQuality ? Math.min(window.devicePixelRatio, 2) : 1);
  }, [highQuality]);

  // Visibility toggle (respects both hiddenGroups and isolatedPart)
  useEffect(() => {
    for (const part of partsRef.current) {
      if (isolatedPart) {
        // Isolate mode: only show the isolated part
        part.mesh.visible = part.name === isolatedPart;
      } else {
        part.mesh.visible = !hiddenGroups.has(part.group);
      }
    }
  }, [hiddenGroups, isolatedPart, partsVersion]);

  // Transparency mode + selection highlight (eDrawings style)
  useEffect(() => {
    const scene = sceneRef.current;
    if (!scene) return;

    // Helper: check if object or any parent matches selected part name
    const isSelected = (obj: THREE.Object3D): boolean => {
      let current: THREE.Object3D | null = obj;
      while (current) {
        if (current.name === selectedPart) return true;
        current = current.parent;
      }
      return false;
    };

    scene.traverse(obj => {
      if (!(obj instanceof THREE.Mesh) || !obj.material) return;
      const mat = obj.material as THREE.MeshStandardMaterial;
      if (!mat.color) return;

      const selected = selectedPart && isSelected(obj);

      if (selected) {
        // Selected part: yellow transparent (see-through)
        mat.emissive = new THREE.Color(0xffaa00);
        mat.emissiveIntensity = 0.5;
        mat.transparent = true;
        mat.opacity = 0.35;
        mat.depthWrite = false;
      } else if (selectedPart) {
        // Other parts when something is selected: stay normal (solid)
        mat.emissive = new THREE.Color(0x000000);
        mat.emissiveIntensity = 0;
        mat.transparent = mat.userData._origTransparent ?? false;
        mat.opacity = mat.userData._origOpacity ?? 1;
        mat.depthWrite = true;
      } else {
        // Nothing selected: restore original
        mat.emissive = new THREE.Color(0x000000);
        mat.emissiveIntensity = 0;
        mat.transparent = mat.userData._origTransparent ?? false;
        mat.opacity = mat.userData._origOpacity ?? 1;
        mat.depthWrite = true;
      }
    });

    // Add/remove outline effect for selected part
    // Remove old outlines
    const oldOutlines = scene.children.filter(c => c.userData._isOutline);
    oldOutlines.forEach(o => scene.remove(o));

    if (selectedPart) {
      const part = partsRef.current.find(p => p.name === selectedPart);
      if (part) {
        part.mesh.traverse(child => {
          if (child instanceof THREE.Mesh && child.geometry) {
            const edges = new THREE.EdgesGeometry(child.geometry, 15);
            const outline = new THREE.LineSegments(edges, new THREE.LineBasicMaterial({
              color: 0xffcc00, linewidth: 2, transparent: true, opacity: 0.9,
            }));
            outline.position.copy(child.position);
            outline.rotation.copy(child.rotation);
            outline.scale.copy(child.scale);
            if (child.parent && child.parent !== scene) {
              // Apply parent world transform
              child.parent.updateWorldMatrix(true, false);
              outline.applyMatrix4(child.parent.matrixWorld);
            }
            outline.userData._isOutline = true;
            scene.add(outline);
          }
        });
      }
    }
  }, [selectedPart, transparencyMode, partsVersion]);

  // Store original material transparency on build
  useEffect(() => {
    const scene = sceneRef.current;
    if (!scene) return;
    scene.traverse(obj => {
      if (obj instanceof THREE.Mesh && obj.material) {
        const mat = obj.material as THREE.MeshStandardMaterial;
        if (mat.userData._origOpacity === undefined) {
          mat.userData._origTransparent = mat.transparent;
          mat.userData._origOpacity = mat.opacity;
        }
      }
    });
  }, [partsVersion]);

  const handleViewPreset = useCallback((preset: ViewPreset, label: string) => {
    const camera = cameraRef.current;
    const controls = controlsRef.current;
    if (!camera || !controls) return;
    applyViewPreset(camera, controls, preset, params);
    setViewInfo(label);
  }, [params]);

  const handleFloorChange = useCallback((floor: number) => {
    setCurrentFloor(floor);
    const camera = cameraRef.current;
    const controls = controlsRef.current;
    if (!camera || !controls) return;

    let floorY = mm(params.kuyuDibi);
    for (let i = 0; i < floor && i < params.katlar.length - 1; i++) {
      floorY += mm(params.katlar[i].yukseklik);
    }
    controls.target.set(0, floorY + mm(params.kapiH) / 2, 0);
    controls.update();

    // Animate cabin to this floor
    const cabinPart = partsRef.current.find(p => p.name === 'Kabin Grubu');
    if (cabinPart) {
      cabinAnimRef.current = { from: cabinPart.mesh.position.y, to: floorY, t: 0 };
      setCabinAnimating(true);
      setTimeout(() => setCabinAnimating(false), 1200);
    }
  }, [params]);

  const handleToggleGroup = useCallback((group: PartGroup) => {
    setHiddenGroups(prev => {
      const next = new Set(prev);
      if (next.has(group)) next.delete(group); else next.add(group);
      return next;
    });
  }, []);

  const handleScreenshot = useCallback(() => {
    const renderer = rendererRef.current;
    const scene = sceneRef.current;
    const camera = cameraRef.current;
    if (!renderer || !scene || !camera) return;
    renderer.render(scene, camera);
    const dataUrl = renderer.domElement.toDataURL('image/png');
    const a = document.createElement('a');
    a.href = dataUrl; a.download = 'asansor-3d.png'; a.click();
  }, []);

  const handleExportSTL = useCallback(() => {
    const scene = sceneRef.current;
    if (!scene) return;
    const stl = exportSTL(scene);
    const blob = new Blob([stl], { type: 'application/octet-stream' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url; a.download = 'asansor.stl'; a.click();
    URL.revokeObjectURL(url);
  }, []);

  const handlePrintPart = useCallback(() => {
    if (!selectedPart) return;
    const props = getPartProperties(selectedPart, params, partsRef.current);
    const printWindow = window.open('', '_blank', 'width=800,height=600');
    if (!printWindow) return;
    printWindow.document.write(`
      <html><head><title>İmalat Çıktısı — ${props.name}</title>
      <style>
        body { font-family: Arial, sans-serif; padding: 30px; color: #333; }
        h1 { font-size: 18px; border-bottom: 2px solid #333; padding-bottom: 8px; }
        h2 { font-size: 14px; color: #666; margin-top: 20px; }
        table { width: 100%; border-collapse: collapse; margin: 10px 0; }
        td, th { border: 1px solid #ccc; padding: 6px 10px; font-size: 12px; text-align: left; }
        th { background: #f0f0f0; font-weight: bold; }
        .note { background: #fff8e0; border: 1px solid #f0c800; padding: 10px; margin: 15px 0; border-radius: 4px; font-size: 12px; }
        .footer { margin-top: 30px; font-size: 10px; color: #999; border-top: 1px solid #ccc; padding-top: 10px; }
        @media print { body { padding: 15px; } }
      </style></head><body>
      <h1>ASNCAD — İMALAT PARÇA KARTI</h1>
      <table>
        <tr><th>Parça Adı</th><td>${props.name}</td><th>Grup</th><td>${props.group}</td></tr>
        <tr><th>Malzeme</th><td colspan="3">${props.malzeme}</td></tr>
        <tr><th>Standart</th><td>${props.standart}</td><th>Boyut</th><td>${props.boyut}</td></tr>
        <tr><th>Ağırlık</th><td>${props.agirlik}</td><th>Yüzey İşlemi</th><td>${props.yuzeyIslemi}</td></tr>
        <tr><th>Tedarikçi</th><td>${props.tedarikci}</td><th>Birim Fiyat</th><td>${props.birimFiyat}</td></tr>
        <tr><th>Teslimat Süresi</th><td colspan="3">${props.teslimatSuresi}</td></tr>
      </table>
      <h2>İmalat Notu</h2>
      <div class="note">${props.imalatNotu}</div>
      <h2>Proje Bilgileri</h2>
      <table>
        <tr><th>Firma</th><td>${params.firma.firmaAdi}</td><th>Mühendis</th><td>${params.firma.muhendis}</td></tr>
        <tr><th>Asansör Tipi</th><td>${params.asansorTipi} — ${params.tahrikKodu}</td><th>Hız</th><td>${params.hiz} m/s</td></tr>
        <tr><th>Kuyu</th><td>${params.kuyuGen}×${params.kuyuDer} mm</td><th>Durak</th><td>${params.katlar.length} kat</td></tr>
      </table>
      <div class="footer">
        Tarih: ${new Date().toLocaleDateString('tr-TR')} | ASNCAD Asansör Çizim Sistemi | ${params.firma.firmaAdi}
      </div>
      </body></html>
    `);
    printWindow.document.close();
    setTimeout(() => printWindow.print(), 500);
  }, [selectedPart, params]);

  // ─── Styles ──────────────────────────────────────────────────────────────
  const btnStyle: React.CSSProperties = {
    background: 'rgba(15,23,42,0.85)', border: '1px solid #334155', color: '#e2e8f0',
    padding: '4px 10px', borderRadius: 4, cursor: 'pointer', fontSize: 11, fontWeight: 500,
    backdropFilter: 'blur(4px)', transition: 'background 0.15s', whiteSpace: 'nowrap',
  };
  const activeBtnStyle: React.CSSProperties = { ...btnStyle, background: '#1e40af', borderColor: '#3b82f6' };
  const sepStyle: React.CSSProperties = { width: 1, height: 20, background: '#334155', margin: '0 4px' };

  return (
    <div ref={containerRef} onMouseLeave={() => setCursorVisible(false)} onContextMenu={e => e.preventDefault()} style={{ flex: 1, position: 'relative', width: '100%', height: '100%', background: '#e8e8ee', cursor: 'none', outline: 'none' }} tabIndex={0}>

      {/* Feature Tree (Left Panel) */}

      {/* AutoCAD-style Crosshair Cursor — colored axis lines through mouse position */}
      {cursorVisible && (
        <>
          {/* X axis line — Red, full width through cursor */}
          <div style={{
            position: 'absolute', left: 0, top: cursorPos.y, width: '100%', height: 0,
            borderTop: snapActive ? '1.5px solid rgba(0,255,100,0.9)' : '1px solid rgba(255,60,60,0.7)',
            pointerEvents: 'none', zIndex: 45,
          }} />
          {/* Y axis line — Green, full height through cursor */}
          <div style={{
            position: 'absolute', left: cursorPos.x, top: 0, width: 0, height: '100%',
            borderLeft: snapActive ? '1.5px solid rgba(0,255,100,0.9)' : '1px solid rgba(60,255,60,0.7)',
            pointerEvents: 'none', zIndex: 45,
          }} />
          {/* Pickbox — small square at cursor center */}
          <div style={{
            position: 'absolute',
            left: cursorPos.x - 5, top: cursorPos.y - 5,
            width: 10, height: 10,
            border: snapActive ? '2px solid #00ff66' : '1px solid #ffffff',
            background: snapActive ? 'rgba(0,255,100,0.15)' : 'transparent',
            pointerEvents: 'none', zIndex: 46,
          }} />
          {/* Snap type label — shows near cursor when snapped */}
          {snapActive && snapLabel && (
            <div style={{
              position: 'absolute',
              left: cursorPos.x + 14, top: cursorPos.y - 20,
              color: '#00ff66', fontSize: 10, fontWeight: 600, fontFamily: 'Arial',
              background: 'rgba(0,0,0,0.7)', padding: '1px 5px', borderRadius: 3,
              pointerEvents: 'none', zIndex: 47, whiteSpace: 'nowrap',
            }}>
              {snapLabel}
            </div>
          )}
        </>
      )}
      {/* Fixed XYZ Orientation Cube — bottom-right corner */}
      <svg style={{
        position: 'absolute', right: 12, bottom: 52, width: 60, height: 60,
        pointerEvents: 'none', zIndex: 18, opacity: 0.9,
      }} viewBox="0 0 60 60">
        <rect x="0" y="0" width="60" height="60" rx="4" fill="rgba(15,23,42,0.8)" stroke="#334155" strokeWidth="1" />
        {/* X axis — Red (right) */}
        <line x1="16" y1="38" x2="50" y2="38" stroke="#ff4444" strokeWidth="2.5" strokeLinecap="round" />
        <text x="52" y="42" fill="#ff4444" fontSize="10" fontWeight="bold" fontFamily="Arial">X</text>
        {/* Y axis — Green (up) */}
        <line x1="16" y1="38" x2="16" y2="6" stroke="#44ff44" strokeWidth="2.5" strokeLinecap="round" />
        <text x="10" y="6" fill="#44ff44" fontSize="10" fontWeight="bold" fontFamily="Arial">Y</text>
        {/* Z axis — Blue (toward viewer, isometric) */}
        <line x1="16" y1="38" x2="4" y2="50" stroke="#4488ff" strokeWidth="2" strokeLinecap="round" />
        <text x="0" y="58" fill="#4488ff" fontSize="9" fontWeight="bold" fontFamily="Arial">Z</text>
        {/* Origin dot */}
        <circle cx="16" cy="38" r="2" fill="#ffffff" />
      </svg>
      {showFeatureTree && (
        <FeatureTreePanel
          key={partsVersion}
          parts={partsRef.current}
          hiddenGroups={hiddenGroups}
          selectedPart={selectedPart}
          isolatedPart={isolatedPart}
          onToggleGroup={handleToggleGroup}
          onSelectPart={setSelectedPart}
          onIsolate={setIsolatedPart}
        />
      )}

      {/* BOM Panel (Right) */}
      {showBom && <BomPanel items={bomItems} />}

      {/* Part Detail Panel */}
      {showPartDetail && selectedPart && (
        <PartDetailPanel
          partName={selectedPart}
          params={params}
          parts={partsRef.current}
          onClose={() => setShowPartDetail(false)}
          onPrint={handlePrintPart}
        />
      )}

      {/* Bottom Toolbar */}
      <div style={{
        position: 'absolute', bottom: 0, left: 0, right: 0, height: 40,
        background: 'rgba(15,23,42,0.92)', borderTop: '1px solid #334155',
        display: 'flex', alignItems: 'center', padding: '0 8px', gap: 3, zIndex: 20,
        backdropFilter: 'blur(8px)', overflowX: 'auto',
      }}>
        {/* View presets */}
        <button style={btnStyle} onClick={() => handleViewPreset('on', 'Ön')}>Ön</button>
        <button style={btnStyle} onClick={() => handleViewPreset('yan', 'Yan')}>Yan</button>
        <button style={btnStyle} onClick={() => handleViewPreset('ust', 'Üst')}>Üst</button>
        <button style={btnStyle} onClick={() => handleViewPreset('izometrik', 'İzometrik')}>İzometrik</button>
        <button style={btnStyle} onClick={() => handleViewPreset('kabin-ici', 'Kabin İçi')}>Kabin İçi</button>
        <button style={btnStyle} onClick={() => {
          const scene = sceneRef.current;
          const camera = cameraRef.current;
          const controls = controlsRef.current;
          if (!scene || !camera || !controls) return;
          const box = new THREE.Box3();
          scene.traverse(obj => {
            if (obj instanceof THREE.Mesh && obj.visible && !obj.userData._isCursor && !obj.userData._isGrid) {
              box.expandByObject(obj);
            }
          });
          if (!box.isEmpty()) {
            const center = box.getCenter(new THREE.Vector3());
            const size = box.getSize(new THREE.Vector3());
            const maxDim = Math.max(size.x, size.y, size.z);
            controls.target.copy(center);
            camera.position.set(center.x + maxDim * 0.8, center.y + maxDim * 0.5, center.z + maxDim * 0.8);
            controls.update();
            setViewInfo('Sığdır');
          }
        }}>Sığdır (F)</button>

        <div style={sepStyle} />

        {/* Toggles */}
        <button style={wireframe ? activeBtnStyle : btnStyle} onClick={() => setWireframe(w => !w)}>Wireframe</button>
        <button style={sectionCut ? activeBtnStyle : btnStyle} onClick={() => setSectionCut(s => !s)}>Kesit</button>
        <button style={highQuality ? activeBtnStyle : btnStyle} onClick={() => setHighQuality(q => !q)}>HQ</button>

        <div style={sepStyle} />

        {/* Explode & Transparency & Isolate & Measure & Grid */}
        <button style={exploded ? activeBtnStyle : btnStyle} onClick={() => setExploded(e => !e)}>Patlat</button>
        <button style={transparencyMode ? activeBtnStyle : btnStyle} onClick={() => setTransparencyMode(t => !t)}>Şeffaf</button>
        <button style={isolatedPart ? activeBtnStyle : btnStyle} onClick={() => {
          if (isolatedPart) {
            setIsolatedPart(null);
          } else if (selectedPart) {
            setIsolatedPart(selectedPart);
          }
        }} title={isolatedPart ? 'Tümünü Göster' : 'Seçili Parçayı İzole Et'}>
          {isolatedPart ? '👁 Tümü' : '◎ İzole'}
        </button>
        <button style={measureMode ? activeBtnStyle : btnStyle} onClick={() => {
          const newMode = !measureMode;
          setMeasureMode(newMode);
          setMeasureText(newMode ? 'İlk noktayı tıklayın... (Esc=İptal)' : '');
          measureStartRef.current = null;
          // Clear old measurements and previews when exiting
          if (!newMode && sceneRef.current) {
            const old = sceneRef.current.children.filter(c => c.userData._isMeasure || c.userData._isMeasurePreview);
            old.forEach(o => sceneRef.current!.remove(o));
          }
        }}>📏 Ölçü</button>
        <button style={showGrid3D ? activeBtnStyle : btnStyle} onClick={() => {
          setShowGrid3D(g => !g);
          if (sceneRef.current) {
            sceneRef.current.traverse(obj => {
              if (obj.userData._isGrid) obj.visible = !showGrid3D;
            });
          }
        }}>Grid</button>

        <div style={sepStyle} />

        {/* Floor selector */}
        <span style={{ color: '#94a3b8', fontSize: 10 }}>Kat:</span>
        <select
          style={{ background: '#1e293b', border: '1px solid #334155', color: '#e2e8f0', borderRadius: 3, fontSize: 11, padding: '2px 6px' }}
          value={currentFloor}
          onChange={e => handleFloorChange(parseInt(e.target.value))}
        >
          {params.katlar.map((k, i) => (
            <option key={i} value={i}>{k.rumuz || `Kat ${k.katNo}`}</option>
          ))}
        </select>
        {cabinAnimating && <span style={{ color: '#fbbf24', fontSize: 10 }}>⟳</span>}

        <div style={sepStyle} />

        {/* Export */}
        <button style={btnStyle} onClick={handleExportSTL}>STL</button>
        <button style={btnStyle} onClick={handleScreenshot}>📷</button>
        <button style={btnStyle} onClick={() => {
          const bom = generateBOM(params);
          const total = bom.reduce((s, i) => s + i.weight, 0);
          const pw = window.open('', '_blank', 'width=900,height=700');
          if (!pw) return;
          pw.document.write(`<html><head><title>İmalat Malzeme Listesi</title>
          <style>body{font-family:Arial;padding:30px}h1{font-size:18px;border-bottom:2px solid #333;padding-bottom:8px}
          table{width:100%;border-collapse:collapse;margin:15px 0}td,th{border:1px solid #ccc;padding:6px 10px;font-size:12px;text-align:left}
          th{background:#f0f0f0}.total{font-weight:bold;background:#e8e8e8}
          .footer{margin-top:20px;font-size:10px;color:#999;border-top:1px solid #ccc;padding-top:10px}</style></head><body>
          <h1>ASNCAD — İMALAT MALZEME LİSTESİ (BOM)</h1>
          <p><strong>Firma:</strong> ${params.firma.firmaAdi} | <strong>Mühendis:</strong> ${params.firma.muhendis} | <strong>Tarih:</strong> ${new Date().toLocaleDateString('tr-TR')}</p>
          <p><strong>Asansör:</strong> ${params.asansorTipi} — ${params.tahrikKodu} | <strong>Hız:</strong> ${params.hiz} m/s | <strong>Durak:</strong> ${params.katlar.length} | <strong>Kuyu:</strong> ${params.kuyuGen}×${params.kuyuDer} mm</p>
          <table><tr><th>No</th><th>Parça Adı</th><th>Adet</th><th>Malzeme</th><th>Ağırlık (kg)</th></tr>
          ${bom.map(b => `<tr><td>${b.no}</td><td>${b.name}</td><td>${b.count}</td><td>${b.material}</td><td>${b.weight}</td></tr>`).join('')}
          <tr class="total"><td colspan="4">TOPLAM</td><td>${total} kg</td></tr></table>
          <div class="footer">ASNCAD Asansör Çizim Sistemi — ${params.firma.firmaAdi}</div></body></html>`);
          pw.document.close();
          setTimeout(() => pw.print(), 500);
        }}>🖨 İmalat</button>

        <div style={sepStyle} />

        {/* Panel toggles */}
        <button style={showFeatureTree ? activeBtnStyle : btnStyle} onClick={() => setShowFeatureTree(v => !v)}>Ağaç</button>
        <button style={showBom ? activeBtnStyle : btnStyle} onClick={() => setShowBom(v => !v)}>BOM</button>
      </div>

      {/* Info bar */}
      <div style={{
        position: 'absolute', bottom: 44, right: 8, background: 'rgba(15,23,42,0.85)',
        border: '1px solid #334155', color: '#94a3b8', padding: '3px 8px', borderRadius: 4,
        fontSize: 10, zIndex: 15, backdropFilter: 'blur(4px)',
      }}>
        {viewInfo} | {wireframe ? 'Wireframe' : 'Solid'} | {highQuality ? 'HQ' : 'LQ'}
        {exploded ? ' | Patlatılmış' : ''}{transparencyMode ? ' | Şeffaf' : ''}
        {isolatedPart ? ` | 🔍 ${isolatedPart}` : ''}
        {measureMode ? ' | 📏 Ölçü Modu' : ''}
        {measureText ? ` | ${measureText}` : ''}
        {selectedPart ? ` | ${selectedPart}` : ''}
      </div>

      {/* Navigation hint bar */}
      <div style={{
        position: 'absolute', bottom: 44, left: showFeatureTree ? 208 : 8, background: 'rgba(15,23,42,0.75)',
        border: '1px solid #334155', color: '#64748b', padding: '3px 8px', borderRadius: 4,
        fontSize: 9, zIndex: 15, backdropFilter: 'blur(4px)', whiteSpace: 'nowrap',
      }}>
        🖱 Sol Sürükle: Orbit | Sağ Sürükle: Pan | Scroll: Zoom | Çift Tık/Orta Tık: Pivot Belirle | Esc: İptal | F: Sığdır
      </div>
    </div>
  );
}
