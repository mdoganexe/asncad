import { useRef, useEffect, useImperativeHandle, forwardRef, useCallback } from 'react';
import { CadEngine } from '../core/CadEngine';
import { Renderer2D } from '../rendering/Renderer2D';
import type { ViewportState } from '../rendering/ViewportState';
import type { CadMouseEvent } from '../core/types';

export interface CadCanvasHandle {
  engine: CadEngine | null;
  renderer: Renderer2D | null;
}

interface CadCanvasProps {
  onEngineReady?: (engine: CadEngine) => void;
}

/**
 * React wrapper for the 2D CAD canvas.
 * Initializes CadEngine on mount, disposes on unmount.
 * Handles resize and wires mouse/keyboard events.
 */
const CadCanvas = forwardRef<CadCanvasHandle, CadCanvasProps>(({ onEngineReady }, ref) => {
  const canvasRef = useRef<HTMLCanvasElement>(null);
  const engineRef = useRef<CadEngine | null>(null);
  const rendererRef = useRef<Renderer2D | null>(null);
  const isPanning = useRef(false);
  const lastMouse = useRef({ x: 0, y: 0 });

  useImperativeHandle(ref, () => ({
    get engine() { return engineRef.current; },
    get renderer() { return rendererRef.current; },
  }));

  const toWorldEvent = useCallback((e: MouseEvent): CadMouseEvent => {
    const engine = engineRef.current;
    if (!engine) return { screenX: 0, screenY: 0, worldX: 0, worldY: 0, button: 0, shiftKey: false, ctrlKey: false };
    const canvas = canvasRef.current!;
    const rect = canvas.getBoundingClientRect();
    const sx = e.clientX - rect.left;
    const sy = e.clientY - rect.top;
    const wp = engine.viewportState.screenToWorld(sx, sy);
    return { screenX: sx, screenY: sy, worldX: wp.x, worldY: wp.y, button: e.button, shiftKey: e.shiftKey, ctrlKey: e.ctrlKey };
  }, []);

  useEffect(() => {
    const canvas = canvasRef.current;
    if (!canvas) return;

    const ctx = canvas.getContext('2d');
    if (!ctx) return;

    // Size canvas to container
    const parent = canvas.parentElement!;
    canvas.width = parent.clientWidth;
    canvas.height = parent.clientHeight;

    // Create engine
    const engine = new CadEngine();
    engine.viewportState.canvasWidth = canvas.width;
    engine.viewportState.canvasHeight = canvas.height;
    engine.initialize();
    engineRef.current = engine;

    // Create renderer
    const renderer = new Renderer2D(ctx, engine.viewportState, engine.entityModel);
    rendererRef.current = renderer;

    // Wire requestRender into tool context
    const requestRender = () => renderer.requestRender();

    // Listen for engine events to trigger re-renders
    const events = ['entityAdded', 'entityRemoved', 'entityModified', 'selectionChanged', 'layerChanged', 'toolChanged', 'viewportChanged', 'commandExecuted', 'undoRedoChanged'] as const;
    for (const evt of events) {
      engine.on(evt, requestRender);
    }

    // Mouse handlers
    const onMouseDown = (e: MouseEvent) => {
      if (e.button === 1) { // Middle mouse = pan
        isPanning.current = true;
        lastMouse.current = { x: e.clientX, y: e.clientY };
        e.preventDefault();
        return;
      }
      engine.handleMouseDown(toWorldEvent(e));
      renderer.requestRender();
    };

    const onMouseMove = (e: MouseEvent) => {
      if (isPanning.current) {
        const dx = e.clientX - lastMouse.current.x;
        const dy = e.clientY - lastMouse.current.y;
        engine.viewportState.pan(dx, dy);
        lastMouse.current = { x: e.clientX, y: e.clientY };
        renderer.requestRender();
        return;
      }
      const we = toWorldEvent(e);
      engine.handleMouseMove(we);
      renderer.setCursorWorldPos({ x: we.worldX, y: we.worldY });

      // Update preview entities from active tool
      const tool = engine.toolManager.getActiveTool();
      if (tool) {
        renderer.setPreviewEntities(tool.getPreviewEntities());
      }
      // Update selection highlights
      renderer.setSelectedIds(new Set(engine.selectionManager.getSelectedIds()));
      renderer.setGripPoints(engine.selectionManager.getGripPoints());
      renderer.requestRender();
    };

    const onMouseUp = (e: MouseEvent) => {
      if (e.button === 1) {
        isPanning.current = false;
        return;
      }
      engine.handleMouseUp(toWorldEvent(e));
      renderer.requestRender();
    };

    const onWheel = (e: WheelEvent) => {
      e.preventDefault();
      const rect = canvas.getBoundingClientRect();
      const sx = e.clientX - rect.left;
      const sy = e.clientY - rect.top;
      const factor = e.deltaY < 0 ? 1.15 : 1 / 1.15;
      engine.viewportState.zoomAt(sx, sy, factor);
      renderer.requestRender();
    };

    const onKeyDown = (e: KeyboardEvent) => {
      engine.handleKeyDown(e);
      renderer.requestRender();
    };

    const onContextMenu = (e: Event) => e.preventDefault();

    canvas.addEventListener('mousedown', onMouseDown);
    canvas.addEventListener('mousemove', onMouseMove);
    canvas.addEventListener('mouseup', onMouseUp);
    canvas.addEventListener('wheel', onWheel, { passive: false });
    canvas.addEventListener('contextmenu', onContextMenu);
    window.addEventListener('keydown', onKeyDown);

    // Resize observer
    const resizeObserver = new ResizeObserver(() => {
      canvas.width = parent.clientWidth;
      canvas.height = parent.clientHeight;
      engine.viewportState.canvasWidth = canvas.width;
      engine.viewportState.canvasHeight = canvas.height;
      renderer.requestRender();
    });
    resizeObserver.observe(parent);

    // Initial render
    renderer.requestRender();

    if (onEngineReady) onEngineReady(engine);

    return () => {
      canvas.removeEventListener('mousedown', onMouseDown);
      canvas.removeEventListener('mousemove', onMouseMove);
      canvas.removeEventListener('mouseup', onMouseUp);
      canvas.removeEventListener('wheel', onWheel);
      canvas.removeEventListener('contextmenu', onContextMenu);
      window.removeEventListener('keydown', onKeyDown);
      resizeObserver.disconnect();
      engine.dispose();
      engineRef.current = null;
      rendererRef.current = null;
    };
  }, [toWorldEvent, onEngineReady]);

  return (
    <div style={{ width: '100%', height: '100%', position: 'relative', overflow: 'hidden' }}>
      <canvas
        ref={canvasRef}
        style={{ display: 'block', width: '100%', height: '100%', cursor: 'crosshair' }}
        tabIndex={0}
      />
    </div>
  );
});

CadCanvas.displayName = 'CadCanvas';
export default CadCanvas;
