import type { LiftParams, ComponentCategory } from '../core/types';

// Three.js types - imported dynamically to avoid SSR issues
type THREE = typeof import('three');

/**
 * Three.js-based 3D visualization of the elevator shaft.
 * Builds geometry from LiftParams and supports component toggling,
 * render modes, and section planes.
 */
export class Renderer3D {
  private container: HTMLElement;
  private scene: any;
  private camera: any;
  private renderer: any;
  private controls: any;
  private sectionPlane: any = null;
  private animationId: number | null = null;
  private componentGroups: Map<ComponentCategory, any> = new Map();
  private THREE: any = null;
  private OrbitControls: any = null;
  private initialized = false;

  constructor(container: HTMLElement) {
    this.container = container;
  }

  /** Initialize the Three.js scene. */
  async initialize(): Promise<void> {
    // Dynamic import to avoid bundling issues
    const THREE = await import('three');
    const { OrbitControls } = await import('three/examples/jsm/controls/OrbitControls.js');
    this.THREE = THREE;
    this.OrbitControls = OrbitControls;

    // Scene
    this.scene = new THREE.Scene();
    this.scene.background = new THREE.Color(0x1a1a2e);

    // Camera
    const aspect = this.container.clientWidth / this.container.clientHeight;
    this.camera = new THREE.PerspectiveCamera(60, aspect, 0.1, 100000);
    this.camera.position.set(3000, 5000, 5000);
    this.camera.lookAt(0, 2000, 0);

    // Renderer
    this.renderer = new THREE.WebGLRenderer({ antialias: true });
    this.renderer.setSize(this.container.clientWidth, this.container.clientHeight);
    this.renderer.setPixelRatio(window.devicePixelRatio);
    this.renderer.localClippingEnabled = true;
    this.container.appendChild(this.renderer.domElement);

    // Controls
    this.controls = new OrbitControls(this.camera, this.renderer.domElement);
    this.controls.enableDamping = true;
    this.controls.dampingFactor = 0.1;
    this.controls.target.set(0, 2000, 0);

    // Lights
    const ambient = new THREE.AmbientLight(0x404040, 0.6);
    this.scene.add(ambient);
    const directional = new THREE.DirectionalLight(0xffffff, 0.8);
    directional.position.set(5000, 10000, 5000);
    this.scene.add(directional);
    const hemi = new THREE.HemisphereLight(0xffffff, 0x444444, 0.4);
    this.scene.add(hemi);

    // Grid helper
    const grid = new THREE.GridHelper(10000, 50, 0x444444, 0x333333);
    this.scene.add(grid);

    this.initialized = true;
    this.animate();
  }

  /** Build 3D geometry from lift parameters. */
  buildFromParams(params: LiftParams): void {
    if (!this.THREE || !this.initialized) return;
    const T = this.THREE;

    // Clear existing component groups
    for (const group of this.componentGroups.values()) {
      this.scene.remove(group);
    }
    this.componentGroups.clear();

    const sw = params.kuyuGenisligi;
    const sd = params.kuyuDerinligi;
    const cw = params.kabinGenisligi;
    const cd = params.kabinDerinligi;
    const ch = params.kabinYuksekligi || 2200;
    const totalHeight = this.getTotalHeight(params);

    // Shaft walls
    const shaftGroup = new T.Group();
    const wallMat = new T.MeshPhongMaterial({ color: 0x808080, transparent: true, opacity: 0.3, side: T.DoubleSide });
    // Back wall
    const backWall = new T.Mesh(new T.BoxGeometry(sw, totalHeight, 20), wallMat);
    backWall.position.set(0, totalHeight / 2, -sd / 2);
    shaftGroup.add(backWall);
    // Left wall
    const leftWall = new T.Mesh(new T.BoxGeometry(20, totalHeight, sd), wallMat);
    leftWall.position.set(-sw / 2, totalHeight / 2, 0);
    shaftGroup.add(leftWall);
    // Right wall
    const rightWall = new T.Mesh(new T.BoxGeometry(20, totalHeight, sd), wallMat);
    rightWall.position.set(sw / 2, totalHeight / 2, 0);
    shaftGroup.add(rightWall);
    this.scene.add(shaftGroup);
    this.componentGroups.set('shaft', shaftGroup);

    // Cabin
    const cabinGroup = new T.Group();
    const cabinMat = new T.MeshPhongMaterial({ color: 0x2563eb, transparent: true, opacity: 0.6 });
    const cabin = new T.Mesh(new T.BoxGeometry(cw, ch, cd), cabinMat);
    const cabinY = params.kuyuDibi + ch / 2;
    cabin.position.set(0, cabinY, 0);
    cabinGroup.add(cabin);
    // Cabin edges
    const cabinEdges = new T.LineSegments(new T.EdgesGeometry(cabin.geometry), new T.LineBasicMaterial({ color: 0x1d4ed8 }));
    cabinEdges.position.copy(cabin.position);
    cabinGroup.add(cabinEdges);
    this.scene.add(cabinGroup);
    this.componentGroups.set('cabin', cabinGroup);

    // Guide rails
    const railGroup = new T.Group();
    const railMat = new T.MeshPhongMaterial({ color: 0xdc2626 });
    const railW = 16, railD = 9;
    const positions = [
      { x: -sw / 2 + 100, z: -sd / 2 + 100 },
      { x: sw / 2 - 100, z: -sd / 2 + 100 },
    ];
    for (const pos of positions) {
      const rail = new T.Mesh(new T.BoxGeometry(railW, totalHeight, railD), railMat);
      rail.position.set(pos.x, totalHeight / 2, pos.z);
      railGroup.add(rail);
    }
    this.scene.add(railGroup);
    this.componentGroups.set('rails', railGroup);

    // Counterweight
    const cwGroup = new T.Group();
    const cwMat = new T.MeshPhongMaterial({ color: 0x4b5563 });
    const cwWidth = 200, cwDepth = 100, cwHeight = 800;
    const cwMesh = new T.Mesh(new T.BoxGeometry(cwWidth, cwHeight, cwDepth), cwMat);
    const cwX = params.yonKodu === 'SAG' ? sw / 2 - 200 : params.yonKodu === 'SOL' ? -sw / 2 + 200 : 0;
    const cwZ = params.yonKodu === 'ARKA' ? -sd / 2 + 150 : sd / 2 - 150;
    cwMesh.position.set(cwX, totalHeight - 1000, cwZ);
    cwGroup.add(cwMesh);
    this.scene.add(cwGroup);
    this.componentGroups.set('counterweight', cwGroup);

    // Traction machine
    const machineGroup = new T.Group();
    const machineMat = new T.MeshPhongMaterial({ color: 0x22c55e });
    const motor = new T.Mesh(new T.CylinderGeometry(150, 150, 300, 32), machineMat);
    motor.position.set(0, totalHeight + 200, 0);
    motor.rotation.z = Math.PI / 2;
    machineGroup.add(motor);
    const sheave = new T.Mesh(new T.TorusGeometry(200, 30, 16, 32), machineMat);
    sheave.position.set(0, totalHeight + 200, 0);
    machineGroup.add(sheave);
    this.scene.add(machineGroup);
    this.componentGroups.set('machine', machineGroup);

    // Doors
    const doorGroup = new T.Group();
    const doorMat = new T.MeshPhongMaterial({ color: 0xea580c, transparent: true, opacity: 0.7 });
    const doorW = params.kapiGenisligi;
    const doorH = 2100;
    for (let i = 0; i < params.durakSayisi; i++) {
      const floorY = this.getFloorY(params, i);
      const door = new T.Mesh(new T.BoxGeometry(doorW, doorH, 10), doorMat);
      door.position.set(0, floorY + doorH / 2, sd / 2);
      doorGroup.add(door);
    }
    this.scene.add(doorGroup);
    this.componentGroups.set('doors', doorGroup);

    // Buffers
    const bufferGroup = new T.Group();
    const bufferMat = new T.MeshPhongMaterial({ color: 0xfbbf24 });
    const bufferR = 50, bufferH = 200;
    const cabinBuffer = new T.Mesh(new T.CylinderGeometry(bufferR, bufferR, bufferH, 16), bufferMat);
    cabinBuffer.position.set(0, bufferH / 2, 0);
    bufferGroup.add(cabinBuffer);
    const cwBuffer = new T.Mesh(new T.CylinderGeometry(bufferR, bufferR, bufferH, 16), bufferMat);
    cwBuffer.position.set(cwX, bufferH / 2, cwZ);
    bufferGroup.add(cwBuffer);
    this.scene.add(bufferGroup);
    this.componentGroups.set('buffers', bufferGroup);

    // Update camera target
    this.controls.target.set(0, totalHeight / 2, 0);
    this.camera.position.set(sw * 2, totalHeight * 0.7, sd * 2);
    this.controls.update();
  }

  /** Update geometry dimensions. */
  updateParams(params: LiftParams): void {
    this.buildFromParams(params);
  }

  /** Toggle component visibility. */
  setComponentVisible(component: ComponentCategory, visible: boolean): void {
    const group = this.componentGroups.get(component);
    if (group) group.visible = visible;
  }

  /** Set render mode: wireframe, solid, or transparent. */
  setRenderMode(mode: 'wireframe' | 'solid' | 'transparent'): void {
    for (const group of this.componentGroups.values()) {
      group.traverse((child: any) => {
        if (child.isMesh && child.material) {
          switch (mode) {
            case 'wireframe':
              child.material.wireframe = true;
              child.material.transparent = false;
              child.material.opacity = 1;
              break;
            case 'solid':
              child.material.wireframe = false;
              child.material.transparent = false;
              child.material.opacity = 1;
              break;
            case 'transparent':
              child.material.wireframe = false;
              child.material.transparent = true;
              child.material.opacity = 0.4;
              break;
          }
        }
      });
    }
  }

  /** Set a horizontal section plane at the given height. null to remove. */
  setSectionPlane(height: number | null): void {
    if (!this.THREE) return;
    if (height === null) {
      this.renderer.clippingPlanes = [];
      this.sectionPlane = null;
    } else {
      const plane = new this.THREE.Plane(new this.THREE.Vector3(0, -1, 0), height);
      this.renderer.clippingPlanes = [plane];
      this.sectionPlane = plane;
    }
  }

  /** Reset camera to default position. */
  resetCamera(): void {
    if (!this.camera || !this.controls) return;
    this.camera.position.set(3000, 5000, 5000);
    this.controls.target.set(0, 2000, 0);
    this.controls.update();
  }

  /** Clean up resources. */
  dispose(): void {
    if (this.animationId !== null) {
      cancelAnimationFrame(this.animationId);
      this.animationId = null;
    }
    if (this.renderer) {
      this.renderer.dispose();
      if (this.renderer.domElement.parentElement) {
        this.renderer.domElement.parentElement.removeChild(this.renderer.domElement);
      }
    }
    if (this.controls) {
      this.controls.dispose();
    }
    this.initialized = false;
  }

  /** Handle container resize. */
  resize(): void {
    if (!this.camera || !this.renderer) return;
    const w = this.container.clientWidth;
    const h = this.container.clientHeight;
    this.camera.aspect = w / h;
    this.camera.updateProjectionMatrix();
    this.renderer.setSize(w, h);
  }

  private animate = (): void => {
    if (!this.initialized) return;
    this.animationId = requestAnimationFrame(this.animate);
    this.controls?.update();
    this.renderer?.render(this.scene, this.camera);
  };

  private getTotalHeight(params: LiftParams): number {
    let total = params.kuyuDibi + (params.kuyuKafa || 3500);
    if (params.floors && params.floors.length > 0) {
      total = params.kuyuDibi;
      for (const f of params.floors) {
        total += f.katYuksekligi;
      }
      total += params.kuyuKafa || 3500;
    }
    return total;
  }

  private getFloorY(params: LiftParams, index: number): number {
    let y = params.kuyuDibi;
    if (params.floors) {
      for (let i = 0; i < index && i < params.floors.length; i++) {
        y += params.floors[i].katYuksekligi;
      }
    } else {
      y += index * 3000;
    }
    return y;
  }
}
