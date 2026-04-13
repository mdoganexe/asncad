import { v4 } from 'uuid';
import type {
  CadEntity,
  LiftParams,
  PolylineEntity,
  LineEntity,
  DimensionEntity,
  HatchEntity,
  TextEntity,
  CircleEntity,
  Point2D,
} from '../core/types';
import type { BlockLibrary } from '../blocks/BlockLibrary';
import type { GenerationResult } from './AutoDrawingGenerator';

/**
 * Complete cross-section generator ported from original ASNCAD vtGroup blocks.
 * Generates all 14 components:
 * 1. Kuyu duvarları (shaft walls) with hatch
 * 2. Kabin (cabin)
 * 3. Kabin Rayları (cabin rails) - T-profile
 * 4. Kapı (door)
 * 5. Ağırlık (counterweight) - positioned by YonKodu
 * 6. Ağırlık Rayları (counterweight rails)
 * 7. Ağırlık Üst Kasnak (counterweight top sheave) - MDDUZ/MDCAP
 * 8. Kabin Alt Kasnak (cabin bottom sheave) - MDDUZ
 * 9. Çapraz (diagonal) - MDCAP
 * 10. Tamponlar (buffers) - cabin and counterweight
 * 11. Sınır çizgileri (limit lines)
 * 12. Ölçülendirme (dimensions)
 * 13. Hatch patterns for concrete walls
 * 14. Labels/text annotations
 */
export class CrossSectionGenerator {
  constructor(private blockLibrary: BlockLibrary) {}

  generate(params: LiftParams): GenerationResult {
    const entities: CadEntity[] = [];
    const parameterMap = new Map<string, string>();

    const W = params.kuyuGenisligi;
    const D = params.kuyuDerinligi;
    const wallT = params.duvarKal || 200;
    const yon = params.yonKodu;

    // Parse rail dimensions
    const kr = parseRail(params.kabinRayStr);
    const ar = parseRail(params.agrRayStr);
    const KRX = params.krx || kr.x;
    const kabinRayUcu = params.kabinRayUcu || 15;
    const kabinYEksen = params.kabinYEksen || 100;
    const agrGen = params.agrGen || 200;
    const agrDuv = params.agrDuv || 50;
    const agrU = params.agrU || 50;
    const agrUz = params.agrUz || 80;
    const kizakKalin = params.kizakKalin || 16;

    // ========================================================================
    // Calculate cabin dimensions using original formulas
    // ========================================================================
    let kabinGen: number, kabinDer: number;
    if (yon === 'ARKA') {
      kabinGen = W - ((KRX + kabinRayUcu) * 2) - 200;
      kabinDer = D - kabinYEksen - (agrDuv + agrGen + agrU + 70) - 100;
    } else {
      // SOL or SAG
      kabinDer = D - kabinYEksen - 100;
      kabinGen = W - (agrDuv + agrGen + agrU + 70 + 200) - ((KRX + kabinRayUcu) * 2);
    }
    kabinGen = Math.max(kabinGen, params.kabinGenisligi || 600);
    kabinDer = Math.max(kabinDer, params.kabinDerinligi || 600);

    const doorW = params.kapiGenisligi;

    // ========================================================================
    // 1. KUYU DUVARLARI (Shaft Walls) - outer and inner rectangles
    // ========================================================================
    // Outer wall
    const outerWall = makePoly([
      { x: 0, y: 0 }, { x: W, y: 0 }, { x: W, y: D }, { x: 0, y: D },
    ], true, 'Shaft', '#808080', 0.50, 'kuyuGenisligi');
    entities.push(outerWall);
    parameterMap.set(outerWall.id, 'kuyuGenisligi');

    // Inner wall (shaft opening)
    const innerWall = makePoly([
      { x: wallT, y: wallT },
      { x: W - wallT, y: wallT },
      { x: W - wallT, y: D - wallT },
      { x: wallT, y: D - wallT },
    ], true, 'Shaft', '#808080', 0.25, 'duvarKal');
    entities.push(innerWall);

    // 13. HATCH for concrete walls (ANSI31 pattern)
    const hatch = makeHatch(outerWall.id, [
      { x: 0, y: 0 }, { x: W, y: 0 }, { x: W, y: D }, { x: 0, y: D },
    ], 'kuyuGenisligi');
    entities.push(hatch);

    // ========================================================================
    // 2. KABİN (Cabin) - positioned with original formulas
    // ========================================================================
    // Cabin position: front wall at y = kabinYEksen from inner shaft front
    const cabinX = wallT + ((W - 2 * wallT - kabinGen) / 2);
    const cabinY = wallT + kabinYEksen;

    // Adjust cabin X based on counterweight position
    let cabinXFinal = cabinX;
    if (yon === 'SOL') {
      // Counterweight on left, cabin shifted right
      cabinXFinal = wallT + agrDuv + agrGen + agrU + 70 + (KRX + kabinRayUcu);
    } else if (yon === 'SAG') {
      // Counterweight on right, cabin shifted left
      cabinXFinal = wallT + (KRX + kabinRayUcu);
    } else {
      // ARKA - cabin centered horizontally
      cabinXFinal = wallT + (KRX + kabinRayUcu);
    }

    const cabinOutline = makePoly([
      { x: cabinXFinal, y: cabinY },
      { x: cabinXFinal + kabinGen, y: cabinY },
      { x: cabinXFinal + kabinGen, y: cabinY + kabinDer },
      { x: cabinXFinal, y: cabinY + kabinDer },
    ], true, 'Cabin', '#2563EB', 0.35, 'kabinGenisligi');
    entities.push(cabinOutline);
    parameterMap.set(cabinOutline.id, 'kabinGenisligi');

    // ========================================================================
    // 4. KAPI (Door) - opening at front of cabin
    // ========================================================================
    const doorCenterX = cabinXFinal + kabinGen / 2;
    const doorY = cabinY; // front wall of cabin

    // Door opening (dashed line)
    const doorLine = makeLine(
      { x: doorCenterX - doorW / 2, y: doorY },
      { x: doorCenterX + doorW / 2, y: doorY },
      'Doors', '#EA580C', 0.35, 'kapiGenisligi'
    );
    doorLine.lineType = 'dashed';
    entities.push(doorLine);
    parameterMap.set(doorLine.id, 'kapiGenisligi');

    // Door panels based on KapiTip
    const kapiTip = params.kapiTipi || 'KK-OT';
    const isOT = kapiTip.includes('OT'); // Otomatik Teleskopik
    const isTK = kapiTip.includes('TK'); // Teleskopik

    if (isOT || isTK) {
      // Telescopic door panels (2 panels sliding to one side)
      const panelW = doorW / 2;
      // Panel 1 (outer)
      entities.push(makeLine(
        { x: doorCenterX - doorW / 2, y: doorY - 5 },
        { x: doorCenterX - doorW / 2 + panelW, y: doorY - 5 },
        'Doors', '#EA580C', 0.25, 'kapiGenisligi'
      ));
      // Panel 2 (inner)
      entities.push(makeLine(
        { x: doorCenterX - doorW / 2, y: doorY - 10 },
        { x: doorCenterX, y: doorY - 10 },
        'Doors', '#EA580C', 0.25, 'kapiGenisligi'
      ));
    } else {
      // Center-opening door (KK) - two panels
      entities.push(makeLine(
        { x: doorCenterX - doorW / 2, y: doorY - 5 },
        { x: doorCenterX, y: doorY - 5 },
        'Doors', '#EA580C', 0.25, 'kapiGenisligi'
      ));
      entities.push(makeLine(
        { x: doorCenterX, y: doorY - 5 },
        { x: doorCenterX + doorW / 2, y: doorY - 5 },
        'Doors', '#EA580C', 0.25, 'kapiGenisligi'
      ));
    }

    // ========================================================================
    // 3. KABİN RAYLARI (Cabin Rails) - T-profile on both sides
    // ========================================================================
    const railY = cabinY + kabinDer / 2; // Rails at cabin mid-height
    const leftRailX = cabinXFinal - kabinRayUcu;
    const rightRailX = cabinXFinal + kabinGen + kabinRayUcu;

    // Left cabin rail T-profile
    const leftRail = makeTProfile(leftRailX, railY, kr.x, kr.y, kr.z, false, 'kabinRayStr');
    entities.push(...leftRail);
    leftRail.forEach(e => parameterMap.set(e.id, 'kabinRayStr'));

    // Right cabin rail T-profile
    const rightRail = makeTProfile(rightRailX, railY, kr.x, kr.y, kr.z, true, 'kabinRayStr');
    entities.push(...rightRail);
    rightRail.forEach(e => parameterMap.set(e.id, 'kabinRayStr'));

    // ========================================================================
    // 5. AĞIRLIK (Counterweight) - positioned based on YonKodu
    // ========================================================================
    let cwX: number, cwY: number, cwW: number, cwH: number;

    if (yon === 'SOL') {
      cwW = agrGen;
      cwH = agrUz + agrDuv;
      cwX = wallT + agrDuv;
      cwY = cabinY + (kabinDer - cwH) / 2;
    } else if (yon === 'SAG') {
      cwW = agrGen;
      cwH = agrUz + agrDuv;
      cwX = W - wallT - agrDuv - cwW;
      cwY = cabinY + (kabinDer - cwH) / 2;
    } else {
      // ARKA
      cwW = agrGen;
      cwH = agrUz + agrDuv;
      cwX = cabinXFinal + (kabinGen - cwW) / 2;
      cwY = D - wallT - agrDuv - cwH;
    }

    const cwOutline = makePoly([
      { x: cwX, y: cwY }, { x: cwX + cwW, y: cwY },
      { x: cwX + cwW, y: cwY + cwH }, { x: cwX, y: cwY + cwH },
    ], true, 'Counterweight', '#4B5563', 0.25, 'yonKodu');
    entities.push(cwOutline);
    parameterMap.set(cwOutline.id, 'yonKodu');

    // Counterweight fill lines (hatching effect)
    const cwFillStep = 15;
    for (let fy = cwY + cwFillStep; fy < cwY + cwH; fy += cwFillStep) {
      entities.push(makeLine(
        { x: cwX, y: fy }, { x: cwX + cwW, y: fy },
        'Counterweight', '#4B5563', 0.13, 'yonKodu'
      ));
    }

    // ========================================================================
    // 6. AĞIRLIK RAYLARI (Counterweight Rails)
    // ========================================================================
    const cwRailY = cwY + cwH / 2;
    const cwLeftRailX = cwX - 10;
    const cwRightRailX = cwX + cwW + 10;

    const cwLeftRail = makeTProfile(cwLeftRailX, cwRailY, ar.x, ar.y, ar.z, false, 'agrRayStr');
    entities.push(...cwLeftRail);
    cwLeftRail.forEach(e => parameterMap.set(e.id, 'agrRayStr'));

    const cwRightRail = makeTProfile(cwRightRailX, cwRailY, ar.x, ar.y, ar.z, true, 'agrRayStr');
    entities.push(...cwRightRail);
    cwRightRail.forEach(e => parameterMap.set(e.id, 'agrRayStr'));

    // ========================================================================
    // 7. AĞIRLIK ÜST KASNAK (Counterweight Top Sheave) - MDDUZ/MDCAP
    // ========================================================================
    if (params.tahrikKodu === 'MDDUZ' || params.tahrikKodu === 'MDCAP') {
      const sheaveR = (params.sapKas || 200) / 2;
      const sheaveCX = cwX + cwW / 2;
      const sheaveCY = cwY - sheaveR - 20;

      const sheave: CircleEntity = {
        id: v4(), type: 'circle',
        center: { x: sheaveCX, y: sheaveCY }, radius: sheaveR,
        layerName: 'Counterweight', color: '#4B5563', lineType: 'continuous', lineWeight: 0.25,
        visible: true, locked: false, autoGenerated: true, sourceParam: 'sapKas',
      };
      entities.push(sheave);
      parameterMap.set(sheave.id, 'sapKas');

      // Cross mark in sheave center
      entities.push(makeLine(
        { x: sheaveCX - 10, y: sheaveCY }, { x: sheaveCX + 10, y: sheaveCY },
        'Counterweight', '#4B5563', 0.13, 'sapKas'
      ));
      entities.push(makeLine(
        { x: sheaveCX, y: sheaveCY - 10 }, { x: sheaveCX, y: sheaveCY + 10 },
        'Counterweight', '#4B5563', 0.13, 'sapKas'
      ));
    }

    // ========================================================================
    // 8. KABİN ALT KASNAK (Cabin Bottom Sheave) - MDDUZ only
    // ========================================================================
    if (params.tahrikKodu === 'MDDUZ') {
      const cabSheaveR = (params.tahrikKas || 200) / 2;
      const cabSheaveCX = cabinXFinal + kabinGen / 2;
      const cabSheaveCY = cabinY + kabinDer + cabSheaveR + 20;

      const cabSheave: CircleEntity = {
        id: v4(), type: 'circle',
        center: { x: cabSheaveCX, y: cabSheaveCY }, radius: cabSheaveR,
        layerName: 'Cabin', color: '#2563EB', lineType: 'continuous', lineWeight: 0.25,
        visible: true, locked: false, autoGenerated: true, sourceParam: 'tahrikKas',
      };
      entities.push(cabSheave);
      parameterMap.set(cabSheave.id, 'tahrikKas');
    }

    // ========================================================================
    // 9. ÇAPRAZ (Diagonal) - MDCAP only
    // ========================================================================
    if (params.tahrikKodu === 'MDCAP') {
      // Diagonal rope line from cabin to counterweight sheave
      const diagStart = { x: cabinXFinal + kabinGen / 2, y: cabinY + kabinDer };
      const diagEnd = { x: cwX + cwW / 2, y: cwY };
      const diagLine = makeLine(diagStart, diagEnd, 'Cabin', '#2563EB', 0.18, 'tahrikKodu');
      diagLine.lineType = 'center';
      entities.push(diagLine);
      parameterMap.set(diagLine.id, 'tahrikKodu');
    }

    // ========================================================================
    // 10. TAMPONLAR (Buffers) - cabin and counterweight
    // ========================================================================
    // Cabin buffer - below cabin center, at shaft floor
    const cabBufX = cabinXFinal + kabinGen / 2;
    const cabBufY = wallT;
    const cabBuf = makeBuffer(cabBufX, cabBufY, 30, 40, 'Cabin', '#2563EB', 'kabinTamponu');
    entities.push(...cabBuf);
    cabBuf.forEach(e => parameterMap.set(e.id, 'kabinTamponu'));

    // Counterweight buffer
    let cwBufX: number, cwBufY: number;
    if (yon === 'ARKA') {
      cwBufX = cwX + cwW / 2;
      cwBufY = D - wallT;
    } else {
      cwBufX = cwX + cwW / 2;
      cwBufY = wallT;
    }
    const cwBuf = makeBuffer(cwBufX, cwBufY, 25, 35, 'Counterweight', '#4B5563', 'agrTamponu');
    entities.push(...cwBuf);
    cwBuf.forEach(e => parameterMap.set(e.id, 'agrTamponu'));

    // ========================================================================
    // 11. SINIR ÇİZGİLERİ (Limit Lines) - cabin clearance boundaries
    // ========================================================================
    // Cabin base limit rectangle (50mm clearance around cabin)
    const limitClearance = 50;
    const limitRect = makePoly([
      { x: cabinXFinal - limitClearance, y: cabinY - limitClearance },
      { x: cabinXFinal + kabinGen + limitClearance, y: cabinY - limitClearance },
      { x: cabinXFinal + kabinGen + limitClearance, y: cabinY + kabinDer + limitClearance },
      { x: cabinXFinal - limitClearance, y: cabinY + kabinDer + limitClearance },
    ], true, 'Cabin', '#2563EB', 0.13, 'kabinGenisligi');
    limitRect.lineType = 'center';
    entities.push(limitRect);

    // ========================================================================
    // 12. ÖLÇÜLENDIRME (Dimensions) - all key measurements
    // ========================================================================
    const dimOffset = 60;

    // Shaft width (bottom)
    addDim(entities, parameterMap,
      { x: 0, y: 0 }, { x: W, y: 0 },
      { x: W / 2, y: -dimOffset }, W, 'kuyuGenisligi');

    // Shaft depth (right side)
    addDim(entities, parameterMap,
      { x: W, y: 0 }, { x: W, y: D },
      { x: W + dimOffset, y: D / 2 }, D, 'kuyuDerinligi');

    // Cabin width (top of cabin)
    addDim(entities, parameterMap,
      { x: cabinXFinal, y: cabinY + kabinDer },
      { x: cabinXFinal + kabinGen, y: cabinY + kabinDer },
      { x: cabinXFinal + kabinGen / 2, y: cabinY + kabinDer + 30 },
      kabinGen, 'kabinGenisligi');

    // Cabin depth (left of cabin)
    addDim(entities, parameterMap,
      { x: cabinXFinal, y: cabinY },
      { x: cabinXFinal, y: cabinY + kabinDer },
      { x: cabinXFinal - 30, y: cabinY + kabinDer / 2 },
      kabinDer, 'kabinDerinligi');

    // Door width
    addDim(entities, parameterMap,
      { x: doorCenterX - doorW / 2, y: doorY },
      { x: doorCenterX + doorW / 2, y: doorY },
      { x: doorCenterX, y: doorY - 30 },
      doorW, 'kapiGenisligi');

    // Clearance: cabin front to shaft front wall
    addDim(entities, parameterMap,
      { x: cabinXFinal + kabinGen / 2, y: wallT },
      { x: cabinXFinal + kabinGen / 2, y: cabinY },
      { x: cabinXFinal + kabinGen + 60, y: (wallT + cabinY) / 2 },
      cabinY - wallT, 'kabinYEksen');

    // Clearance: cabin to counterweight
    if (yon === 'SOL') {
      addDim(entities, parameterMap,
        { x: cwX + cwW, y: cwRailY },
        { x: cabinXFinal, y: cwRailY },
        { x: (cwX + cwW + cabinXFinal) / 2, y: cwRailY - 30 },
        cabinXFinal - (cwX + cwW), 'agrU');
    } else if (yon === 'SAG') {
      addDim(entities, parameterMap,
        { x: cabinXFinal + kabinGen, y: cwRailY },
        { x: cwX, y: cwRailY },
        { x: (cabinXFinal + kabinGen + cwX) / 2, y: cwRailY - 30 },
        cwX - (cabinXFinal + kabinGen), 'agrU');
    }

    // Counterweight width
    addDim(entities, parameterMap,
      { x: cwX, y: cwY + cwH },
      { x: cwX + cwW, y: cwY + cwH },
      { x: cwX + cwW / 2, y: cwY + cwH + 20 },
      cwW, 'agrGen');

    // ========================================================================
    // 14. LABELS (Text annotations)
    // ========================================================================
    // Cabin label
    entities.push(makeText(
      { x: cabinXFinal + kabinGen / 2, y: cabinY + kabinDer / 2 },
      'KABİN', 'Text', '#FFFFFF', 'kabinGenisligi'
    ));

    // Counterweight label
    entities.push(makeText(
      { x: cwX + cwW / 2, y: cwY + cwH / 2 },
      'AĞIRLIK', 'Text', '#FFFFFF', 'yonKodu'
    ));

    // Shaft label
    entities.push(makeText(
      { x: W / 2, y: D + wallT + 20 },
      `KUYU KESİTİ (${W}x${D})`, 'Text', '#FFFFFF', 'kuyuGenisligi'
    ));

    return { entities, parameterMap };
  }
}

// ============================================================================
// Helper functions
// ============================================================================

function parseRail(s: string): { x: number; y: number; z: number } {
  const parts = (s || '70x65x9').split('x').map(Number);
  return { x: parts[0] || 70, y: parts[1] || 65, z: parts[2] || 9 };
}

function makePoly(
  vertices: Point2D[], closed: boolean,
  layerName: string, color: string, lineWeight: number,
  sourceParam: string
): PolylineEntity {
  return {
    id: v4(), type: 'polyline', vertices, closed,
    layerName, color, lineType: 'continuous', lineWeight,
    visible: true, locked: false, autoGenerated: true, sourceParam,
  };
}

function makeLine(
  start: Point2D, end: Point2D,
  layerName: string, color: string, lineWeight: number,
  sourceParam: string
): LineEntity {
  return {
    id: v4(), type: 'line', start, end,
    layerName, color, lineType: 'continuous', lineWeight,
    visible: true, locked: false, autoGenerated: true, sourceParam,
  };
}

function makeHatch(
  boundaryId: string, boundaryPoints: Point2D[], sourceParam: string
): HatchEntity {
  return {
    id: v4(), type: 'hatch',
    pattern: 'ANSI31', patternScale: 1, patternAngle: 0.785, // 45 degrees
    boundaryEntityIds: [boundaryId], boundaryPoints,
    layerName: 'Hatch', color: '#16A34A', lineType: 'continuous', lineWeight: 0.13,
    visible: true, locked: false, autoGenerated: true, sourceParam,
  };
}

function makeText(
  position: Point2D, content: string,
  layerName: string, color: string, sourceParam: string
): TextEntity {
  return {
    id: v4(), type: 'text', position, content,
    fontSize: 3, fontFamily: 'Arial', fontWeight: 'normal', fontStyle: 'normal',
    alignment: 'center', rotation: 0,
    layerName, color, lineType: 'continuous', lineWeight: 0.18,
    visible: true, locked: false, autoGenerated: true, sourceParam,
  };
}

/** Create a T-profile rail cross-section at given position */
function makeTProfile(
  cx: number, cy: number,
  railW: number, railH: number, webT: number,
  mirror: boolean, sourceParam: string
): LineEntity[] {
  const hw = railW / 2;
  const hh = railH / 2;
  const hwt = webT / 2;
  const lines: LineEntity[] = [];

  // T-profile: flange (horizontal) + web (vertical)
  // Flange
  lines.push(makeLine(
    { x: cx - hw, y: cy + hh }, { x: cx + hw, y: cy + hh },
    'Rails', '#DC2626', 0.25, sourceParam
  ));
  // Web
  lines.push(makeLine(
    { x: cx - hwt, y: cy - hh }, { x: cx - hwt, y: cy + hh },
    'Rails', '#DC2626', 0.25, sourceParam
  ));
  lines.push(makeLine(
    { x: cx + hwt, y: cy - hh }, { x: cx + hwt, y: cy + hh },
    'Rails', '#DC2626', 0.25, sourceParam
  ));
  // Bottom of web
  lines.push(makeLine(
    { x: cx - hwt, y: cy - hh }, { x: cx + hwt, y: cy - hh },
    'Rails', '#DC2626', 0.25, sourceParam
  ));
  // Flange bottom
  lines.push(makeLine(
    { x: cx - hw, y: cy + hh - webT }, { x: cx + hw, y: cy + hh - webT },
    'Rails', '#DC2626', 0.18, sourceParam
  ));
  // Flange sides
  lines.push(makeLine(
    { x: cx - hw, y: cy + hh - webT }, { x: cx - hw, y: cy + hh },
    'Rails', '#DC2626', 0.25, sourceParam
  ));
  lines.push(makeLine(
    { x: cx + hw, y: cy + hh - webT }, { x: cx + hw, y: cy + hh },
    'Rails', '#DC2626', 0.25, sourceParam
  ));

  return lines;
}

/** Create a buffer symbol (rectangle with spring lines) */
function makeBuffer(
  cx: number, cy: number, w: number, h: number,
  layerName: string, color: string, sourceParam: string
): LineEntity[] {
  const lines: LineEntity[] = [];
  const hw = w / 2;

  // Buffer rectangle
  lines.push(makeLine({ x: cx - hw, y: cy }, { x: cx + hw, y: cy }, layerName, color, 0.25, sourceParam));
  lines.push(makeLine({ x: cx + hw, y: cy }, { x: cx + hw, y: cy + h }, layerName, color, 0.25, sourceParam));
  lines.push(makeLine({ x: cx + hw, y: cy + h }, { x: cx - hw, y: cy + h }, layerName, color, 0.25, sourceParam));
  lines.push(makeLine({ x: cx - hw, y: cy + h }, { x: cx - hw, y: cy }, layerName, color, 0.25, sourceParam));

  // Spring zigzag inside
  const steps = 4;
  const stepH = h / (steps * 2);
  for (let i = 0; i < steps; i++) {
    const y1 = cy + stepH * (i * 2);
    const y2 = cy + stepH * (i * 2 + 1);
    const y3 = cy + stepH * (i * 2 + 2);
    lines.push(makeLine(
      { x: cx - hw * 0.6, y: y1 + stepH },
      { x: cx + hw * 0.6, y: y2 },
      layerName, color, 0.13, sourceParam
    ));
  }

  return lines;
}

function addDim(
  entities: CadEntity[], parameterMap: Map<string, string>,
  p1: Point2D, p2: Point2D, dimPt: Point2D,
  value: number, sourceParam: string
) {
  const dim: DimensionEntity = {
    id: v4(), type: 'dimension', dimensionType: 'linear',
    defPoint1: p1, defPoint2: p2, dimLinePoint: dimPt,
    measurementValue: Math.round(value),
    textHeight: 2.5, arrowSize: 2.5, extensionLineOffset: 1.5, decimalPrecision: 0,
    layerName: 'Dimensions', color: '#06B6D4', lineType: 'continuous', lineWeight: 0.18,
    visible: true, locked: false, autoGenerated: true, sourceParam,
  };
  entities.push(dim);
  parameterMap.set(dim.id, sourceParam);
}
