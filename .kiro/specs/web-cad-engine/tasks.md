# Implementation Plan: Interactive Web CAD Drawing Engine

## Overview

This plan implements a ZwCAD-like interactive 2D/3D CAD engine for the ASCAD Web platform, replacing the existing server-side SVG generation with a fully interactive client-side drawing system. The implementation follows a bottom-up dependency order: core types → viewport → entity model → rendering → commands → tools → blocks → auto-generation → export → persistence → 3D → React UI → integration. All code is TypeScript in `ascad-web/client/src/cad/`.

## Tasks

- [x] 1. Set up CAD engine project structure and core types
  - [x] 1.1 Create directory structure and install dependencies
    - Create `ascad-web/client/src/cad/` directory tree: `core/`, `rendering/`, `tools/`, `blocks/`, `generation/`, `export/`, `export/dxf/`, `persistence/`, `react/`, `__tests__/`, `__tests__/properties/`
    - Install npm dependencies: `rbush` (spatial index), `three` (3D), `@types/three`, `uuid`, `@types/uuid`
    - Install dev dependencies: `vitest`, `fast-check`, `@vitest/coverage-v8`
    - Add vitest config to `vite.config.ts`
    - _Requirements: 1.1, 11.1_

  - [x] 1.2 Define all core type interfaces in `core/types.ts`
    - Define `Point2D`, `BoundingBox`, `Transform2D` geometry types
    - Define `EntityType`, `LineType`, `CadEntity` base interface
    - Define `LineEntity`, `PolylineEntity`, `CircleEntity`, `ArcEntity` geometry entities
    - Define `DimensionType`, `DimensionEntity`, `TextEntity`, `HatchPattern`, `HatchEntity` annotation entities
    - Define `BlockDefinition`, `BlockAttributeDef`, `BlockReferenceEntity` block types
    - Define `Layer` interface and `DEFAULT_LAYERS` constant array
    - Define `DrawingState`, `ViewportStateJson`, `DrawingMetadata`, `DrawingJson` persistence types
    - Define `LiftParams`, `FloorParam`, `RailSpec` parameter types
    - Define `TitleBlockData` interface
    - Define `CadEvent`, `CadEventHandler`, `CadMouseEvent`, `SnapMode`, `SnapResult`, `ToolName`, `ToolState` event/tool types
    - Define `COLOR_TO_ACI` and `LINETYPE_TO_DXF` mapping constants
    - _Requirements: 1.1, 3.7, 4.1, 4.6, 6.1, 6.2, 8.1, 10.2, 12.1, 13.1, 14.2, 18.6_


- [x] 2. Implement ViewportState and coordinate transforms
  - [x] 2.1 Implement `rendering/ViewportState.ts`
    - Implement `ViewportState` class with `centerX`, `centerY`, `zoom`, `canvasWidth`, `canvasHeight` properties
    - Implement `worldToScreen(wx, wy)` and `screenToWorld(sx, sy)` with Y-axis flip (world Y up, screen Y down)
    - Implement `pan(screenDx, screenDy)` shifting center by `(-dx/zoom, dy/zoom)`
    - Implement `zoomAt(screenX, screenY, factor)` preserving world point under cursor, clamping zoom to [0.01, 100]
    - Implement `zoomExtents(bounds, margin)` fitting all entities with 10% margin
    - Implement `getVisibleBounds()` and `getTransformMatrix()` returning a `DOMMatrix`
    - _Requirements: 1.2, 1.3, 1.8_

  - [ ]* 2.2 Write property test: Viewport Zoom Preserves Cursor World Position
    - **Property 4: Viewport Zoom Preserves Cursor World Position**
    - **Validates: Requirements 1.2**

  - [ ]* 2.3 Write property test: Viewport Pan Translates by Correct World Delta
    - **Property 5: Viewport Pan Translates by Correct World Delta**
    - **Validates: Requirements 1.3**

  - [ ]* 2.4 Write property test: Viewport Zoom Extents Contains All Entities
    - **Property 6: Viewport Zoom Extents Contains All Entities**
    - **Validates: Requirements 1.8**

- [x] 3. Implement EntityModel and SpatialIndex
  - [x] 3.1 Implement `core/SpatialIndex.ts`
    - Wrap `rbush` library with typed interface for `CadEntity` bounding boxes
    - Implement `insert(entity)`, `remove(entity)`, `update(entity)`, `queryRect(bounds)`, `queryPoint(point, tolerance)`, `clear()`
    - Compute bounding boxes per entity type (line, polyline, circle, arc, dimension, text, hatch, block_reference)
    - _Requirements: 1.6_

  - [x] 3.2 Implement `core/EntityModel.ts`
    - Implement entity CRUD: `addEntity`, `removeEntity`, `getEntity`, `updateEntity`, `getAllEntities`, `getEntitiesByLayer`
    - Implement spatial queries: `queryRect`, `queryPoint`, `hitTest` delegating to `SpatialIndex`
    - Implement layer management: `addLayer`, `removeLayer`, `getLayer`, `getAllLayers`, `setActiveLayer`, `getActiveLayer`
    - Initialize with `DEFAULT_LAYERS` from types, set active layer to "0"
    - Implement block definition registry: `addBlockDef`, `getBlockDef`, `getAllBlockDefs`
    - Implement `getVisibleEntities()` filtering by layer visibility
    - Implement `getEntityCount()` and `clear()`
    - Prevent deletion of default layer "0"
    - _Requirements: 1.6, 6.1, 6.2, 6.3, 6.4, 6.5, 6.6_

  - [ ]* 3.3 Write property test: Spatial Index Query Matches Brute-Force
    - **Property 7: Spatial Index Query Matches Brute-Force**
    - **Validates: Requirements 1.6**

  - [ ]* 3.4 Write property test: Layer Visibility Filters Entities
    - **Property 22: Layer Visibility Filters Entities**
    - **Validates: Requirements 6.3**

  - [ ]* 3.5 Write property test: Default Layer "0" Cannot Be Deleted
    - **Property 23: Default Layer "0" Cannot Be Deleted**
    - **Validates: Requirements 6.6**

- [x] 4. Checkpoint — Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.

- [x] 5. Implement Renderer2D and grid rendering
  - [x] 5.1 Implement `rendering/GridRenderer.ts`
    - Implement adaptive grid spacing based on zoom level using `getGridSpacing(zoom)` algorithm from design
    - Render major grid lines (thicker, labeled) and minor grid lines (thinner)
    - Default spacing: 100mm major, 10mm minor
    - _Requirements: 1.4, 2.1_

  - [x] 5.2 Implement `rendering/EntityRenderers.ts`
    - Implement per-type Canvas2D render functions: `renderLine`, `renderPolyline`, `renderCircle`, `renderArc`, `renderDimension`, `renderText`, `renderHatch`, `renderBlockRef`
    - Dimension rendering: extension lines + dimension line + arrows + text label with configurable style
    - Hatch rendering: fill boundary polygon with `ctx.createPattern()` for ANSI31, ANSI32, INSUL, SOLID patterns
    - Block reference rendering: resolve block definition, apply insertion transform, render child entities
    - Apply layer color, line type (dash patterns), and line weight
    - _Requirements: 1.1, 1.5, 4.1, 4.2, 4.3, 4.4, 4.7, 10.1, 10.2, 10.3_

  - [x] 5.3 Implement `rendering/CursorRenderer.ts`
    - Render crosshair cursor at current world position
    - Render snap indicator icons (endpoint marker, midpoint marker, center marker, etc.)
    - Render coordinate readout text at cursor position
    - _Requirements: 1.7, 2.5_

  - [x] 5.4 Implement `rendering/Renderer2D.ts`
    - Implement full render pipeline: `clearCanvas → applyTransform → renderGrid → queryVisibleEntities → renderEntities → renderSelectionHighlights → renderGrips → renderToolPreview → renderSnapIndicator → renderCursor`
    - Use `requestAnimationFrame` for render scheduling via `requestRender()`
    - Filter entities by layer visibility before rendering
    - Target 30fps with up to 10,000 entities using spatial index culling
    - _Requirements: 1.1, 1.5, 1.6, 3.6_


- [x] 6. Implement CommandStack (undo/redo)
  - [x] 6.1 Implement `core/CommandStack.ts`
    - Implement `Command` interface with `execute()` and `undo()` methods and `description` string
    - Implement `CommandStack` class with `undoStack` and `redoStack` arrays, `maxLevels` default 100
    - Implement `execute(command)`: push to undo stack, clear redo stack, enforce max levels
    - Implement `undo()`: pop from undo stack, call `command.undo()`, push to redo stack
    - Implement `redo()`: pop from redo stack, call `command.execute()`, push to undo stack
    - Implement `canUndo()`, `canRedo()`, `clear()`
    - Implement `beginGroup(description)` / `endGroup()` for grouping sub-operations into a single undoable unit
    - _Requirements: 7.1, 7.2, 7.3, 7.4, 7.5, 7.6_

  - [ ]* 6.2 Write property test: Undo/Redo Round-Trip
    - **Property 24: Undo/Redo Round-Trip**
    - **Validates: Requirements 7.2, 7.3**

  - [ ]* 6.3 Write property test: New Command After Undo Clears Redo Stack
    - **Property 25: New Command After Undo Clears Redo Stack**
    - **Validates: Requirements 7.5**

  - [ ]* 6.4 Write property test: Grouped Commands Undo Atomically
    - **Property 26: Grouped Commands Undo Atomically**
    - **Validates: Requirements 7.6**

- [x] 7. Implement SnapManager
  - [x] 7.1 Implement `tools/SnapManager.ts`
    - Implement snap detection for all modes: Endpoint, Midpoint, Center, Intersection, Perpendicular, Nearest, Grid
    - Implement priority ordering: Endpoint > Intersection > Center > Midpoint > Perpendicular > Nearest > Grid
    - Implement configurable aperture radius (default 10 pixels) with screen-to-world conversion
    - Implement `findSnap(screenPoint, worldPoint, lastPoint)` returning `SnapResult | null`
    - Implement `setMode(mode, enabled)`, `setApertureRadius(pixels)`, `setOrthoEnabled(enabled)`
    - Implement `applyOrtho(point, lastPoint)` constraining to horizontal or vertical based on larger delta
    - _Requirements: 2.2, 2.3, 2.4, 2.5, 2.6_

  - [ ]* 7.2 Write property test: Grid Snap Produces Nearest Grid Intersection
    - **Property 8: Grid Snap Produces Nearest Grid Intersection**
    - **Validates: Requirements 2.2**

  - [ ]* 7.3 Write property test: Snap Priority Ordering
    - **Property 10: Snap Priority Ordering**
    - **Validates: Requirements 2.4**

  - [ ]* 7.4 Write property test: Ortho Mode Constrains to Axis-Aligned
    - **Property 11: Ortho Mode Constrains to Axis-Aligned**
    - **Validates: Requirements 2.6**

- [x] 8. Implement SelectionManager
  - [x] 8.1 Implement `core/SelectionManager.ts`
    - Implement `selectEntity`, `deselectEntity`, `toggleEntity`, `selectAll`, `clearSelection`
    - Implement `selectByWindow(bounds)` — select only entities fully contained within the box (left-to-right)
    - Implement `selectByCrossing(bounds)` — select entities intersecting or contained within the box (right-to-left)
    - Implement `getSelectedIds()`, `getSelectedEntities()`, `isSelected(id)`, `getSelectionCount()`
    - Implement `getGripPoints()` returning key points (endpoints, centers, midpoints) for selected entities
    - Prevent selection of entities on locked layers from being modified (visual selection allowed)
    - _Requirements: 5.1, 5.2, 5.3, 5.10_

  - [ ]* 8.2 Write property test: Window Selection Returns Only Fully Contained Entities
    - **Property 17: Window Selection Returns Only Fully Contained Entities**
    - **Validates: Requirements 5.2**

  - [ ]* 8.3 Write property test: Crossing Selection Returns Intersecting and Contained Entities
    - **Property 18: Crossing Selection Returns Intersecting and Contained Entities**
    - **Validates: Requirements 5.3**

- [x] 9. Checkpoint — Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.

- [ ] 10. Implement ToolManager and BaseTool
  - [x] 10.1 Implement `tools/BaseTool.ts`
    - Implement abstract `BaseTool` class with state machine: `idle → first_point → preview → complete → idle`
    - Define abstract methods: `onMouseDown`, `onMouseMove`, `onMouseUp`, `onKeyDown`, `onNumericInput`, `getPreviewEntities`
    - Implement `activate()`, `deactivate()`, `cancel()` lifecycle methods
    - Hold reference to `CadEngine` for accessing entity model, command stack, snap manager
    - _Requirements: 3.1, 3.2, 3.3, 3.4, 3.5, 3.6_

  - [x] 10.2 Implement `tools/ToolManager.ts`
    - Implement tool registry with `Map<ToolName, BaseTool>`
    - Implement `activateTool(name)` — deactivate current tool first, then activate new tool
    - Implement `deactivateTool()` — cancel and deactivate current tool
    - Implement input routing: `handleMouseDown`, `handleMouseMove`, `handleMouseUp`, `handleKeyDown`, `handleNumericInput`
    - Apply snap before routing mouse events to active tool
    - _Requirements: 3.1, 3.6, 16.1_


- [ ] 11. Implement individual drawing tools
  - [x] 11.1 Implement `tools/SelectTool.ts`
    - Click selection: hit-test at cursor, add to selection set
    - Box selection: left-to-right drag → window selection, right-to-left drag → crossing selection
    - Shift+click for toggle selection
    - Display selection grips at key points
    - _Requirements: 5.1, 5.2, 5.3_

  - [x] 11.2 Implement `tools/LineTool.ts`
    - First click: capture start point (respecting snap and ortho)
    - Second click: capture end point, create `LineEntity` via `CreateEntityCommand`
    - Preview: rubber-band line from start to cursor
    - Numeric input: use as distance along current direction
    - _Requirements: 3.1, 3.6, 3.7_

  - [x] 11.3 Implement `tools/PolylineTool.ts`
    - Accumulate click points as vertices
    - Enter or right-click to finish, creating `PolylineEntity`
    - Preview: rubber-band segments from last vertex to cursor
    - Each segment respects snap and ortho constraints
    - _Requirements: 3.2, 3.6, 3.7_

  - [x] 11.4 Implement `tools/RectangleTool.ts`
    - First click: first corner
    - Second click: opposite corner, create closed `PolylineEntity` with 4 vertices
    - Preview: rubber-band rectangle
    - _Requirements: 3.3, 3.6, 3.7_

  - [ ]* 11.5 Write property test: Rectangle Tool Produces Valid Closed Polyline
    - **Property 12: Rectangle Tool Produces Valid Closed Polyline**
    - **Validates: Requirements 3.3**

  - [x] 11.6 Implement `tools/CircleTool.ts`
    - First click: center point
    - Second click or numeric input: radius, create `CircleEntity`
    - Preview: rubber-band circle from center to cursor
    - _Requirements: 3.4, 3.6, 3.7_

  - [x] 11.7 Implement `tools/ArcTool.ts`
    - Three-point arc: click start, click point on arc, click end
    - Compute center and radius from three points
    - Create `ArcEntity`
    - Preview: arc through current three points
    - _Requirements: 3.5, 3.6, 3.7_

  - [ ]* 11.8 Write property test: Three-Point Arc Passes Through All Three Points
    - **Property 13: Three-Point Arc Passes Through All Three Points**
    - **Validates: Requirements 3.5**

  - [x] 11.9 Implement `tools/DimensionTool.ts`
    - Support linear (horizontal/vertical), aligned, angular, and radial dimension types
    - Linear/Aligned: click two definition points, then click dimension line position
    - Angular: click three points (vertex + two rays)
    - Radial: click circle/arc entity
    - Compute `measurementValue` automatically from definition points
    - Create `DimensionEntity` with configurable style (text height, arrow size, extension offset, precision)
    - _Requirements: 4.1, 4.2, 4.3, 4.4, 4.5, 4.7_

  - [ ]* 11.10 Write property test: Dimension Measurement Correctness
    - **Property 15: Dimension Measurement Correctness**
    - **Validates: Requirements 4.1, 4.2, 4.3, 4.4**

  - [x] 11.11 Implement `tools/TextTool.ts`
    - Click position to place text
    - Open inline text editor for content input
    - Support configurable font size, style (normal/bold/italic), and alignment (left/center/right)
    - Create `TextEntity` on confirm
    - _Requirements: 4.6_

  - [ ]* 11.12 Write property test: New Entity Inherits Active Layer
    - **Property 14: New Entity Inherits Active Layer**
    - **Validates: Requirements 3.7, 6.5**

- [ ] 12. Implement manipulation tools (Move, Copy, Rotate, Scale, Mirror, Offset)
  - [x] 12.1 Implement `tools/MoveTool.ts`
    - Select base point, then destination point
    - Translate all selected entities by the vector (dest - base)
    - Execute as grouped command for undo
    - Reject modification of entities on locked layers
    - _Requirements: 5.4, 5.10_

  - [x] 12.2 Implement `tools/CopyTool.ts`
    - Select base point, then destination point
    - Duplicate all selected entities and place copies at destination
    - Execute as grouped command
    - _Requirements: 5.5_

  - [x] 12.3 Implement `tools/RotateTool.ts`
    - Select base point, then specify angle (click or numeric input)
    - Rotate all selected entities around base point by angle
    - Execute as grouped command
    - _Requirements: 5.6_

  - [x] 12.4 Implement `tools/ScaleTool.ts`
    - Select base point, then specify scale factor (click or numeric input)
    - Scale all selected entities relative to base point
    - Execute as grouped command
    - _Requirements: 5.7_

  - [x] 12.5 Implement `tools/MirrorTool.ts`
    - Select two points defining the mirror line
    - Mirror all selected entities across that line
    - Execute as grouped command
    - _Requirements: 5.8_

  - [x] 12.6 Implement `tools/OffsetTool.ts`
    - Specify offset distance, then click a line or polyline
    - Create a parallel copy at the specified offset distance
    - _Requirements: 5.9_

  - [ ]* 12.7 Write property test: Geometric Transforms Preserve Entity Structure
    - **Property 19: Geometric Transforms Preserve Entity Structure**
    - **Validates: Requirements 5.4, 5.6, 5.7**

  - [ ]* 12.8 Write property test: Mirror Is Self-Inverse
    - **Property 20: Mirror Is Self-Inverse**
    - **Validates: Requirements 5.8**

  - [ ]* 12.9 Write property test: Locked Layer Prevents Modification
    - **Property 21: Locked Layer Prevents Modification**
    - **Validates: Requirements 5.10, 6.4**

  - [ ]* 12.10 Write property test: Dimension Updates When Geometry Moves
    - **Property 16: Dimension Updates When Geometry Moves**
    - **Validates: Requirements 4.5**

- [x] 13. Checkpoint — Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.


- [ ] 14. Implement LayerManager integration into CadEngine
  - [x] 14.1 Wire layer operations into CadEngine
    - Implement `setActiveLayer(layerName)`, `setLayerVisibility(layerName, visible)`, `setLayerLock(layerName, locked)` on `CadEngine`
    - Implement layer CRUD: create, rename, delete custom layers (prevent deleting "0")
    - Ensure new entities inherit active layer's color and line properties
    - Emit `layerChanged` events for React UI updates
    - _Requirements: 6.1, 6.2, 6.3, 6.4, 6.5, 6.6_

- [ ] 15. Implement BlockLibrary and parametric block definitions
  - [x] 15.1 Implement `blocks/BlockDefinition.ts` and `blocks/BlockLibrary.ts`
    - Implement `ParametricBlockDef` interface with `generate(params)` method
    - Implement `BlockLibrary` class with `register`, `get`, `getAll`, `resolve(name, liftParams)`, `registerBuiltins()`
    - Support user-defined custom block definitions from grouped entities
    - _Requirements: 8.1, 8.6, 8.7_

  - [x] 15.2 Implement `blocks/CabinBlock.ts`
    - Generate cabin walls (polyline), door opening (line), handrail positions (lines), button panel (rect)
    - Bind to `kabinGenisligi`, `kabinDerinligi`, `kapiGenisligi` from LiftParams
    - _Requirements: 8.2, 8.4_

  - [x] 15.3 Implement `blocks/GuideRailBlock.ts`
    - Generate T-profile cross-section polyline
    - Bind to `cabinRailSpec.width`, `cabinRailSpec.height` from LiftParams
    - _Requirements: 8.5_

  - [x] 15.4 Implement remaining block definitions
    - `blocks/DoorBlock.ts` — Telescopic (2-3 sliding panels) and center-opening (2 panels) variants, bound to `kapiGenisligi`
    - `blocks/CounterweightBlock.ts` — Rectangular frame with filler weights, bound to `beyanYuk`, `yonKodu`
    - `blocks/TractionMachineBlock.ts` — Motor circle, sheave circle, base rect
    - `blocks/BufferBlock.ts` — Cylinder cross-section (circle + rect)
    - `blocks/SafetyGearBlock.ts` — Wedge profile polyline
    - `blocks/GovernorBlock.ts` — Sheave circle + rope lines
    - `blocks/ControlPanelBlock.ts` — Rectangular cabinet (rect + text)
    - _Requirements: 8.1, 8.2, 8.3_

  - [ ]* 15.5 Write property test: Block Parameter Resolution Matches Lift Values
    - **Property 27: Block Parameter Resolution Matches Lift Values**
    - **Validates: Requirements 8.2, 8.4, 8.5**

- [ ] 16. Implement AutoDrawingGenerator (6 drawing types)
  - [x] 16.1 Implement `generation/AutoDrawingGenerator.ts` orchestrator
    - Implement `generateCrossSection`, `generateLongitudinalSection`, `generateMachineRoom`, `generateCabinPlan`, `generatePitDetail`, `generateOverheadDetail`
    - Track auto-generated entity IDs and parameter mappings (`entityId → paramName`)
    - Place entities on correct default layers (shaft walls → "Shaft", cabin → "Cabin", dimensions → "Dimensions")
    - Set `autoGenerated = true` and `sourceParam` on all generated entities
    - _Requirements: 9.1, 9.2, 9.3, 9.4, 9.6, 9.7, 9.8_

  - [x] 16.2 Implement `generation/CrossSectionGenerator.ts`
    - Generate shaft walls, cabin outline, rail positions (cabin and counterweight), door opening, counterweight position based on `yonKodu`
    - Generate dimension annotations for all key measurements (shaft width, shaft depth, cabin width, cabin depth, door width, clearances)
    - _Requirements: 9.1_

  - [x] 16.3 Implement `generation/LongitudinalGenerator.ts`
    - Generate shaft pit, floor levels with architectural level labels, cabin at reference floor, counterweight, travel distance annotation, overhead clearance, machine room outline
    - _Requirements: 9.2_

  - [x] 16.4 Implement `generation/MachineRoomGenerator.ts`
    - Generate room walls, traction machine, deflection sheave, control panel, governor, access door with dimension annotations
    - _Requirements: 9.3_

  - [x] 16.5 Implement `generation/CabinPlanGenerator.ts`
    - Generate cabin walls, door opening, handrails, button panel, interior dimensions
    - _Requirements: 9.4_

  - [x] 16.6 Implement `generation/PitDetailGenerator.ts` and `generation/OverheadDetailGenerator.ts`
    - Pit: pit floor, buffer positions, safety gear clearance, minimum pit depth dimensions per EN81-1
    - Overhead: top floor landing, overhead clearance, machine beam positions, minimum overhead dimensions per EN81-1
    - _Requirements: 9.7, 9.8_

  - [ ]* 16.7 Write property test: Auto-Generation Produces Correct Layer Assignments
    - **Property 28: Auto-Generation Produces Correct Layer Assignments**
    - **Validates: Requirements 9.6, 15.4**

  - [ ]* 16.8 Write property test: Auto-Generation Dimensions Match Lift Parameters
    - **Property 29: Auto-Generation Dimensions Match Lift Parameters**
    - **Validates: Requirements 9.1, 9.2, 9.3, 9.4, 9.7, 9.8**

- [x] 17. Checkpoint — Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.


- [ ] 18. Implement DxfExporter
  - [x] 18.1 Implement `export/dxf/DxfWriter.ts`
    - Low-level DXF string builder for group codes (code/value pairs)
    - Write HEADER section (ACADVER = AC1027 for AutoCAD 2013, INSBASE, EXTMIN, EXTMAX)
    - Write line type table entries (CONTINUOUS, DASHED, CENTER, HIDDEN)
    - Write EOF marker
    - _Requirements: 12.1_

  - [x] 18.2 Implement `export/dxf/DxfLayerMapper.ts`
    - Map each `Layer` to a DXF LAYER table entry with name (group 2), ACI color (group 62) using `COLOR_TO_ACI`, line type name (group 6) using `LINETYPE_TO_DXF`, line weight (group 370)
    - _Requirements: 12.2, 18.6_

  - [x] 18.3 Implement `export/dxf/DxfEntityMapper.ts`
    - Map `LineEntity` → DXF LINE (10/20 start, 11/21 end)
    - Map `CircleEntity` → DXF CIRCLE (10/20 center, 40 radius)
    - Map `ArcEntity` → DXF ARC (10/20 center, 40 radius, 50 start°, 51 end°)
    - Map `PolylineEntity` → DXF LWPOLYLINE (90 vertex count, 70 closed flag, 10/20 per vertex)
    - Map `TextEntity` → DXF TEXT (10/20 insertion, 40 height, 1 content, 50 rotation°)
    - Map `DimensionEntity` → DXF DIMENSION (10/20 def point, 13/23 def point 2, 14/24 dim line, 1 text override, 70 dim type)
    - Map `HatchEntity` → DXF HATCH (2 pattern name, 41 scale, 52 angle, boundary path data)
    - Map `BlockReferenceEntity` → DXF INSERT (2 block name, 10/20 insertion, 41/42 scale, 50 rotation°)
    - _Requirements: 12.1, 12.3, 12.4, 18.1, 18.2, 18.3, 18.4, 18.5_

  - [x] 18.4 Implement `export/DxfExporter.ts`
    - Orchestrate full DXF file generation: HEADER → TABLES (LTYPE + LAYER) → BLOCKS → ENTITIES → EOF
    - Export block definitions as BLOCK/ENDBLK pairs
    - Export all entities using `DxfEntityMapper`
    - _Requirements: 12.1_

  - [ ]* 18.5 Write property test: DXF Line Entity Mapping
    - **Property 33: DXF Line Entity Mapping**
    - **Validates: Requirements 18.1**

  - [ ]* 18.6 Write property test: DXF Circle Entity Mapping
    - **Property 34: DXF Circle Entity Mapping**
    - **Validates: Requirements 18.2**

  - [ ]* 18.7 Write property test: DXF Polyline Entity Mapping
    - **Property 35: DXF Polyline Entity Mapping**
    - **Validates: Requirements 18.3**

  - [ ]* 18.8 Write property test: DXF Text Entity Mapping
    - **Property 36: DXF Text Entity Mapping**
    - **Validates: Requirements 18.4**

  - [ ]* 18.9 Write property test: DXF Dimension Entity Mapping
    - **Property 37: DXF Dimension Entity Mapping**
    - **Validates: Requirements 18.5**

  - [ ]* 18.10 Write property test: DXF Layer Table Mapping
    - **Property 38: DXF Layer Table Mapping**
    - **Validates: Requirements 18.6**

- [ ] 19. Implement DrawingSerializer and persistence API
  - [x] 19.1 Implement `persistence/DrawingSerializer.ts`
    - Implement `serialize(model, viewport)` → `DrawingJson` converting all entities, layers, block definitions, viewport state, and metadata to JSON
    - Implement `deserialize(json, model, viewport)` reconstructing the full entity model from JSON
    - Implement per-type serialization/deserialization for each entity type, layer, and block definition
    - Handle version field for future migration support
    - _Requirements: 13.1, 13.2, 13.3_

  - [ ]* 19.2 Write property test: Drawing Serialization Round-Trip (Entities)
    - **Property 1: Drawing Serialization Round-Trip (Entities)**
    - **Validates: Requirements 13.1, 13.2, 13.3, 17.1**

  - [ ]* 19.3 Write property test: Drawing Serialization Round-Trip (Layers)
    - **Property 2: Drawing Serialization Round-Trip (Layers)**
    - **Validates: Requirements 17.2**

  - [ ]* 19.4 Write property test: Drawing Serialization Round-Trip (Block Definitions)
    - **Property 3: Drawing Serialization Round-Trip (Block Definitions)**
    - **Validates: Requirements 17.3**

  - [x] 19.5 Implement `persistence/DrawingApiClient.ts`
    - Implement `saveDrawing(liftId, type, json)` → `POST /api/drawings/{liftId}/{type}`
    - Implement `loadDrawing(liftId, type)` → `GET /api/drawings/{liftId}/{type}`
    - Handle 404 (no saved drawing → return null for auto-generation trigger)
    - Handle network errors with retry (3 attempts, exponential backoff)
    - _Requirements: 13.4, 13.5, 13.6_

  - [x] 19.6 Implement backend Drawing entity and API endpoints
    - Create `Drawing` entity in `AscadWeb.Core/Entities/Drawing.cs` with `LiftId`, `DrawingType`, `JsonContent`, `Version` fields
    - Add `DbSet<Drawing>` to `AscadDbContext` with Lift FK relationship
    - Add EF Core migration for the Drawing table
    - Add `POST /api/drawings/{liftId}/{type}` and `GET /api/drawings/{liftId}/{type}` endpoints to `DrawingsController.cs`
    - _Requirements: 13.4, 13.5_

- [x] 20. Checkpoint — Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.


- [ ] 21. Implement PDF and SVG exporters
  - [x] 21.1 Implement `export/PdfExporter.ts`
    - Render current viewport to PDF at user-selected scale (1:50, 1:100, 1:200)
    - Include title block with company info, project name, drawing title, date
    - Use canvas-to-PDF approach (e.g., jsPDF or similar)
    - _Requirements: 12.5_

  - [x] 21.2 Implement `export/SvgExporter.ts`
    - Produce SVG document containing all visible entities
    - Preserve layer colors and line styles
    - _Requirements: 12.6_

- [ ] 22. Implement 3D Viewer (Three.js)
  - [x] 22.1 Implement `rendering/Renderer3D.ts`
    - Initialize Three.js scene, PerspectiveCamera, WebGLRenderer, OrbitControls
    - Implement `buildFromParams(liftParams)` creating 3D geometry: shaft walls (BoxGeometry), cabin (BoxGeometry), guide rails (ExtrudedProfile), counterweight (BoxGeometry), traction machine (CylinderGeometry + TorusGeometry), door panels (BoxGeometry), buffers (CylinderGeometry)
    - Implement `updateParams(params)` updating geometry dimensions
    - Implement `setComponentVisible(component, visible)` for toggling component categories
    - Implement `setRenderMode(mode)` for wireframe, solid with edges, and transparent modes
    - Implement `setSectionPlane(height)` using `THREE.ClippingPlane` to cut through geometry
    - Implement `resetCamera()` and `dispose()` lifecycle methods
    - _Requirements: 11.1, 11.2, 11.3, 11.4, 11.5, 11.6_

  - [ ]* 22.2 Write property test: 2D/3D Dimensional Consistency
    - **Property 39: 2D/3D Dimensional Consistency**
    - **Validates: Requirements 11.7**

- [ ] 23. Implement CadEngine orchestrator
  - [x] 23.1 Implement `core/CadEngine.ts`
    - Instantiate and wire all subsystems: EntityModel, CommandStack, ToolManager, SelectionManager, SnapManager, BlockLibrary, Renderer2D, ViewportState, DrawingSerializer
    - Implement canvas event listeners: mousedown, mousemove, mouseup, wheel, keydown, contextmenu
    - Implement `screenToWorld` conversion in event handlers, pass to ToolManager
    - Implement zoom (wheel → `zoomAt`), pan (middle-mouse drag), zoom extents (double-click)
    - Implement public API: `activateTool`, `cancelCurrentTool`, `undo`, `redo`, `deleteSelected`, `moveSelected`, `copySelected`, `rotateSelected`, `scaleSelected`, `mirrorSelected`
    - Implement layer API: `setActiveLayer`, `setLayerVisibility`, `setLayerLock`
    - Implement block API: `insertBlock`
    - Implement auto-generation API: `generateDrawing(type)`
    - Implement persistence API: `serialize()`, `deserialize(json)`
    - Implement export API: `exportDxf()`, `exportSvg()`, `exportPdf(scale)`
    - Implement parameter sync: `updateLiftParams(params)` updating all auto-generated entities
    - Implement event system: `on(event, handler)`, `off(event, handler)`
    - Implement `initialize()` and `dispose()` lifecycle
    - _Requirements: 1.1, 1.2, 1.3, 1.7, 1.8, 7.2, 7.3, 15.1_

- [ ] 24. Implement hatch pattern support
  - [x] 24.1 Implement hatch boundary computation and pattern rendering
    - Implement boundary detection from selected closed geometry (lines, polylines, circles, arcs)
    - Implement built-in hatch patterns: ANSI31 (concrete), ANSI32 (steel), INSUL (insulation), SOLID
    - Implement pattern rendering with configurable scale and angle using `ctx.createPattern()`
    - Implement boundary update when source geometry is modified
    - _Requirements: 10.1, 10.2, 10.3, 10.4_

- [ ] 25. Implement title block
  - [x] 25.1 Implement title block entity rendering
    - Render border and information panel at fixed position relative to drawing sheet boundaries
    - Display all required fields: company name, address, phone, project name, drawing title, drawing number, scale, date, revision, mechanical engineer name/SMM, electrical engineer name/SMM
    - Source data from `CompanyInfo` service and current Project data
    - Support multiple drawing sheets per Lift, each with its own title block
    - Update content when company info or project data changes
    - _Requirements: 14.1, 14.2, 14.3, 14.4, 14.5_

  - [ ]* 25.2 Write property test: Title Block Contains All Required Fields
    - **Property 40: Title Block Contains All Required Fields**
    - **Validates: Requirements 14.2, 14.3**

- [x] 26. Checkpoint — Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.


- [ ] 27. Implement React UI components
  - [x] 27.1 Implement `react/CadCanvas.tsx`
    - React wrapper for the 2D canvas element
    - Initialize `CadEngine` on mount, dispose on unmount
    - Handle canvas resize via `ResizeObserver`
    - Expose engine instance via ref or context for sibling components
    - Render coordinate readout in status bar area
    - _Requirements: 1.1, 1.7_

  - [x] 27.2 Implement `react/CadToolbar.tsx`
    - Drawing tool buttons: Select, Line, Polyline, Rectangle, Circle, Arc, Dimension, Text
    - Manipulation tool buttons: Move, Copy, Rotate, Scale, Mirror, Offset
    - Action buttons: Undo, Redo, Delete, Zoom Extents
    - Export buttons: DXF, PDF, SVG
    - Toggle buttons: Grid, Snap, Ortho
    - Highlight active tool
    - _Requirements: 3.1, 3.2, 3.3, 3.4, 3.5, 4.1, 4.6, 5.4, 5.5, 5.6, 5.7, 5.8, 5.9, 12.1, 12.5, 12.6_

  - [x] 27.3 Implement `react/LayerPanel.tsx`
    - Display list of layers with visibility toggle (eye icon), lock toggle (lock icon), color swatch
    - Highlight active layer, click to set active
    - Add/rename/delete layer controls (prevent deleting "0")
    - _Requirements: 6.1, 6.2, 6.3, 6.4, 6.5, 6.6_

  - [x] 27.4 Implement `react/PropertyPanel.tsx`
    - Display properties of selected entity (type, layer, color, line type, line weight, geometry-specific fields)
    - Allow editing property values, propagate changes via commands
    - Show "No selection" when nothing is selected
    - _Requirements: 5.1_

  - [x] 27.5 Implement `react/CommandInput.tsx`
    - Text input field for typing command names (LINE, CIRCLE, MOVE, COPY, ZOOM, etc.)
    - Parse and activate corresponding tool or command on Enter
    - Support numeric input during active tool operations
    - _Requirements: 16.1, 16.3_

  - [x] 27.6 Implement `react/StatusBar.tsx`
    - Display current cursor coordinates in mm
    - Display active command name and prompts (e.g., "Specify first point:", "Specify radius:")
    - Display snap mode indicators and ortho mode status
    - _Requirements: 1.7, 16.4_

  - [x] 27.7 Implement `react/ThreeDViewer.tsx`
    - React wrapper for `Renderer3D`
    - Initialize Three.js on mount, dispose on unmount
    - Render mode selector (wireframe, solid, transparent)
    - Component visibility toggles
    - Section plane height slider
    - _Requirements: 11.1, 11.2, 11.3, 11.4, 11.5, 11.6_

  - [x] 27.8 Implement `react/CadDrawingPage.tsx`
    - Full page layout composing: CadCanvas (main area), CadToolbar (top), LayerPanel (right sidebar), PropertyPanel (right sidebar below layers), CommandInput (bottom), StatusBar (bottom bar), ThreeDViewer (toggleable panel)
    - Drawing type selector tabs (cross-section, longitudinal, machine-room, cabin-plan, pit-detail, overhead-detail)
    - Load saved drawing on mount or auto-generate if none exists
    - Save drawing on explicit save action
    - Offer regenerate vs. keep choice when parameters change (Requirement 9.5)
    - _Requirements: 9.5, 13.4, 13.5, 13.6_

- [ ] 28. Integrate CAD engine into LiftDesignPage
  - [x] 28.1 Replace DrawingViewer with CadDrawingPage
    - Update `LiftDesignPage.tsx` to render `CadDrawingPage` instead of the existing `DrawingViewer` component
    - Pass Lift data as `LiftParams` to the CAD engine
    - Add route for CAD drawing page if needed (or embed in existing layout)
    - Update `App.tsx` routing if a separate route is added
    - Update `drawingApi` in `services.ts` to include new JSON persistence endpoints alongside existing SVG endpoints
    - _Requirements: 13.5, 13.6_

- [ ] 29. Implement bi-directional parameter sync
  - [x] 29.1 Implement forward sync (parameter → drawing)
    - When Lift parameters change in the parameter panel, call `cadEngine.updateLiftParams(params)`
    - Update all auto-generated entities and block references whose `sourceParam` matches changed parameters
    - Update 3D viewer via `renderer3D.updateParams(params)`
    - _Requirements: 15.1_

  - [x] 29.2 Implement reverse sync (drawing → parameter)
    - When user double-clicks an auto-generated dimension and edits the value, propagate new measurement back to corresponding Lift parameter
    - Call server API to update the Lift parameter
    - Validate against EN81-1 constraints, display warning if violated
    - _Requirements: 15.2, 15.3_

  - [ ]* 29.3 Write property test: Parameter Forward Sync Updates Entities
    - **Property 30: Parameter Forward Sync Updates Entities**
    - **Validates: Requirements 15.1**

  - [ ]* 29.4 Write property test: Dimension Edit Reverse Sync
    - **Property 31: Dimension Edit Reverse Sync**
    - **Validates: Requirements 15.2**

  - [ ]* 29.5 Write property test: EN81-1 Constraint Violation Warning
    - **Property 32: EN81-1 Constraint Violation Warning**
    - **Validates: Requirements 15.3**

- [ ] 30. Implement keyboard shortcuts
  - [x] 30.1 Implement keyboard shortcut handler
    - Escape: cancel current operation
    - Delete: delete selected entities
    - Ctrl+Z: undo, Ctrl+Y / Ctrl+Shift+Z: redo
    - Ctrl+A: select all, Ctrl+C: copy to clipboard, Ctrl+V: paste from clipboard
    - F8: toggle Ortho_Mode, F3: toggle snap
    - Numeric input during active tool: use as distance/radius
    - Wire shortcuts into CadEngine's keydown handler
    - _Requirements: 16.2, 16.3_

- [x] 31. Final checkpoint — Ensure all tests pass
  - Ensure all tests pass, ask the user if questions arise.

## Notes

- Tasks marked with `*` are optional and can be skipped for faster MVP
- Each task references specific requirements for traceability
- Checkpoints ensure incremental validation at key integration points
- Property tests validate the 40 correctness properties defined in the design document
- The CAD engine is a standalone TypeScript module (`@/cad/`) that does not use React state for entity management — React wraps it for UI panels only
- The backend changes are minimal: one new `Drawing` entity and two new API endpoints for JSON persistence
- Dependencies: `rbush` (spatial index), `three` + `@types/three` (3D), `uuid` (entity IDs), `vitest` + `fast-check` (testing)
