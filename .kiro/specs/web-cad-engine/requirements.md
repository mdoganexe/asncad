# Requirements Document

## Introduction

This document defines the requirements for the Interactive Web CAD Drawing Engine — a ZwCAD-like interactive 2D/3D drawing system for the ASCAD Web SaaS platform. The existing platform generates static SVG drawings server-side and renders them non-interactively via `dangerouslySetInnerHTML`. This feature replaces that approach with a fully interactive client-side CAD canvas supporting pan, zoom, object selection, manual drawing tools, parametric block insertion, layer management, undo/redo, and DXF/DWG export. It also adds 3D visualization of the elevator shaft and components. The engine integrates bi-directionally with the existing Lift parameter model so that parameter changes update drawings live and drawing edits can feed back into parameters.

## Glossary

- **CAD_Canvas**: The client-side 2D interactive drawing surface built on HTML5 Canvas/WebGL that supports infinite pan, zoom, grid, snap, and rendering of all CAD entities.
- **CAD_Entity**: A discrete geometric or annotation object on the CAD_Canvas, such as a line, polyline, rectangle, circle, arc, dimension, text, hatch, or block reference.
- **CAD_Engine**: The core TypeScript module that manages the entity model, rendering pipeline, spatial index, selection, transformation, and command execution for the 2D canvas.
- **Entity_Model**: The in-memory data structure representing all CAD_Entity objects in a drawing, organized by layers, supporting serialization to/from a JSON-based drawing format.
- **Block_Definition**: A reusable, named collection of CAD_Entity objects with parametric attributes (e.g., cabin width, door width) that can be inserted as a Block_Reference at a specific position, scale, and rotation.
- **Block_Reference**: An instance of a Block_Definition placed on the CAD_Canvas at a specific insertion point, with attribute values resolved from Lift parameters.
- **Block_Library**: The collection of pre-built parametric Block_Definitions for elevator components (cabin, rails, doors, counterweight, traction machine, buffers, safety gear, governor, control panel).
- **Layer**: A named grouping mechanism for CAD_Entity objects with properties: visibility (on/off), color, line type, line weight, and lock state.
- **Snap_Mode**: A constraint that forces the cursor to lock onto specific geometric points (endpoint, midpoint, center, intersection, perpendicular, nearest, grid).
- **Drawing_Tool**: A user-activated mode for creating new CAD_Entity objects interactively (Line, Polyline, Rectangle, Circle, Arc, Dimension, Text).
- **Command_Stack**: The undo/redo history that records all state-changing operations on the Entity_Model as reversible commands.
- **Dimension_Entity**: A specialized CAD_Entity that displays a measured distance or angle between geometric points, with leader lines, extension lines, and a text label showing the measurement value.
- **Hatch_Entity**: A specialized CAD_Entity that fills a closed boundary with a repeating pattern (e.g., cross-section hatching for concrete, steel, or insulation).
- **Three_D_Viewer**: The 3D visualization component built on Three.js that renders the elevator shaft, cabin, rails, counterweight, and other components as 3D geometry with orbit, pan, and zoom controls.
- **Drawing_Serializer**: The module responsible for converting the Entity_Model to/from the JSON-based drawing storage format for persistence to the server.
- **DXF_Exporter**: The client-side module that converts the Entity_Model into a valid DXF (Drawing Exchange Format) file compatible with AutoCAD and ZwCAD.
- **Spatial_Index**: A data structure (e.g., R-tree or grid-based) that enables efficient hit-testing, selection, and visibility culling of CAD_Entity objects on the CAD_Canvas.
- **Viewport**: The visible rectangular region of the infinite CAD_Canvas, defined by a center point and zoom level, controlling which entities are rendered.
- **Ortho_Mode**: A drawing constraint that restricts cursor movement to horizontal or vertical directions relative to the last input point.
- **Selection_Set**: The collection of currently selected CAD_Entity objects, supporting click selection, box selection (window), and crossing selection.
- **Title_Block**: A standardized border and information panel placed on each drawing sheet containing company name, project name, drawing title, scale, date, and engineer information.
- **Lift**: The existing elevator configuration entity containing shaft dimensions, cabin parameters, drive type, floor information, and component catalog references.

---

## Requirements

### Requirement 1: CAD Canvas Core — Viewport and Rendering

**User Story:** As an elevator engineer, I want an interactive 2D drawing canvas with infinite pan and zoom, so that I can navigate large-scale elevator drawings at any detail level.

#### Acceptance Criteria

1. THE CAD_Canvas SHALL render all visible CAD_Entity objects within the current Viewport using HTML5 Canvas 2D or WebGL.
2. WHEN the user performs a scroll gesture (mouse wheel or trackpad pinch), THE CAD_Canvas SHALL zoom in or out centered on the cursor position, with a minimum zoom of 0.01x and a maximum zoom of 100x.
3. WHEN the user performs a middle-mouse-button drag or two-finger pan gesture, THE CAD_Canvas SHALL pan the Viewport by the corresponding screen delta.
4. THE CAD_Canvas SHALL display a configurable grid with major and minor grid lines, where grid spacing adjusts automatically based on the current zoom level.
5. THE CAD_Canvas SHALL render at a minimum of 30 frames per second when displaying up to 10,000 CAD_Entity objects within the Viewport.
6. WHEN the Viewport changes, THE CAD_Canvas SHALL use the Spatial_Index to determine which entities are visible and render only those entities.
7. THE CAD_Canvas SHALL display a coordinate readout showing the current cursor position in drawing units (millimeters).
8. WHEN the user double-clicks or presses a "Zoom Extents" button, THE CAD_Canvas SHALL adjust the Viewport to fit all entities in the drawing with a 10% margin.

---

### Requirement 2: Grid and Snap System

**User Story:** As an elevator engineer, I want grid display and snap-to-point functionality, so that I can place and align drawing elements precisely.

#### Acceptance Criteria

1. THE CAD_Canvas SHALL support configurable grid spacing with a default of 100mm for major grid lines and 10mm for minor grid lines.
2. WHEN grid snap is enabled, THE CAD_Canvas SHALL constrain all input points to the nearest grid intersection.
3. THE CAD_Canvas SHALL support the following Snap_Mode types: Endpoint, Midpoint, Center, Intersection, Perpendicular, Nearest, and Grid.
4. WHEN multiple Snap_Mode types are active simultaneously, THE CAD_Canvas SHALL prioritize snaps in the following order: Endpoint, Intersection, Center, Midpoint, Perpendicular, Nearest, Grid.
5. WHEN a snap point is detected within a configurable aperture radius (default 10 pixels), THE CAD_Canvas SHALL display a visual snap indicator (marker icon) at the snap point and use that point as the input coordinate.
6. WHEN Ortho_Mode is enabled, THE CAD_Canvas SHALL constrain the cursor to move only horizontally or vertically relative to the last input point during drawing tool operations.

---

### Requirement 3: Drawing Tools — Basic Geometry

**User Story:** As an elevator engineer, I want to draw lines, polylines, rectangles, circles, and arcs manually, so that I can add custom geometry to auto-generated drawings or create drawings from scratch.

#### Acceptance Criteria

1. WHEN the Line Drawing_Tool is active, THE CAD_Engine SHALL create a line CAD_Entity from the first click point to the second click point, respecting active Snap_Mode and Ortho_Mode constraints.
2. WHEN the Polyline Drawing_Tool is active, THE CAD_Engine SHALL create a polyline CAD_Entity by accumulating click points until the user presses Enter or right-clicks to finish, with each segment respecting active snap and ortho constraints.
3. WHEN the Rectangle Drawing_Tool is active, THE CAD_Engine SHALL create a closed polyline CAD_Entity defined by two opposite corner points.
4. WHEN the Circle Drawing_Tool is active, THE CAD_Engine SHALL support center-radius input (click center, then click or type radius) and create a circle CAD_Entity.
5. WHEN the Arc Drawing_Tool is active, THE CAD_Engine SHALL support three-point arc input (start, point on arc, end) and create an arc CAD_Entity.
6. WHILE any Drawing_Tool is active, THE CAD_Canvas SHALL display a real-time preview of the entity being created as the cursor moves.
7. THE CAD_Engine SHALL assign each newly created CAD_Entity to the currently active Layer.

---

### Requirement 4: Drawing Tools — Dimensions and Text

**User Story:** As an elevator engineer, I want to add dimension annotations and text labels to drawings, so that I can document measurements and provide notes on technical drawings.

#### Acceptance Criteria

1. WHEN the Linear Dimension Drawing_Tool is active, THE CAD_Engine SHALL create a horizontal or vertical Dimension_Entity by selecting two points and a dimension line position, displaying the measured distance in millimeters.
2. WHEN the Aligned Dimension Drawing_Tool is active, THE CAD_Engine SHALL create a Dimension_Entity aligned to the angle between two selected points, displaying the true distance.
3. WHEN the Angular Dimension Drawing_Tool is active, THE CAD_Engine SHALL create a Dimension_Entity showing the angle between two lines or three points in degrees.
4. WHEN the Radial Dimension Drawing_Tool is active, THE CAD_Engine SHALL create a Dimension_Entity showing the radius of a selected circle or arc.
5. THE Dimension_Entity SHALL automatically update its displayed measurement value when the referenced geometry points are moved.
6. WHEN the Text Drawing_Tool is active, THE CAD_Engine SHALL create a text CAD_Entity at the clicked position, opening an inline text editor for content input with configurable font size, style, and alignment.
7. THE CAD_Engine SHALL support dimension style configuration including: text height, arrow size, extension line offset, and decimal precision.

---

### Requirement 5: Object Selection and Manipulation

**User Story:** As an elevator engineer, I want to select, move, copy, rotate, scale, and mirror drawing objects, so that I can edit and arrange elements in the drawing.

#### Acceptance Criteria

1. WHEN the user clicks on a CAD_Entity, THE CAD_Engine SHALL add that entity to the Selection_Set, displaying selection grips (handles) at key points.
2. WHEN the user drags a selection box from left to right (window selection), THE CAD_Engine SHALL select only entities fully contained within the box.
3. WHEN the user drags a selection box from right to left (crossing selection), THE CAD_Engine SHALL select all entities that intersect or are contained within the box.
4. WHEN the Move command is executed with a Selection_Set, THE CAD_Engine SHALL translate all selected entities by the vector from a base point to a destination point.
5. WHEN the Copy command is executed with a Selection_Set, THE CAD_Engine SHALL duplicate all selected entities and place the copies at the destination point.
6. WHEN the Rotate command is executed with a Selection_Set, THE CAD_Engine SHALL rotate all selected entities around a base point by a specified angle.
7. WHEN the Scale command is executed with a Selection_Set, THE CAD_Engine SHALL scale all selected entities relative to a base point by a specified scale factor.
8. WHEN the Mirror command is executed with a Selection_Set, THE CAD_Engine SHALL mirror all selected entities across a line defined by two points.
9. WHEN the Offset command is executed on a line or polyline, THE CAD_Engine SHALL create a parallel copy at the specified offset distance.
10. WHEN a CAD_Entity on a locked Layer is clicked, THE CAD_Engine SHALL display the entity as selected visually but SHALL prevent any modification commands on that entity.

---

### Requirement 6: Layer Management

**User Story:** As an elevator engineer, I want to organize drawing elements into named layers with configurable visibility, color, and line properties, so that I can control drawing complexity and produce clean output.

#### Acceptance Criteria

1. THE CAD_Engine SHALL maintain a list of Layer objects, each with properties: name, visibility (on/off), color, line type (continuous, dashed, center, hidden), line weight, and lock state.
2. THE CAD_Engine SHALL provide a default set of layers for elevator drawings: "Shaft" (gray), "Cabin" (blue), "Rails" (red), "Doors" (orange), "Counterweight" (dark gray), "Dimensions" (cyan), "Text" (white), "Hatch" (green), and "TitleBlock" (magenta).
3. WHEN a Layer's visibility is set to off, THE CAD_Canvas SHALL hide all CAD_Entity objects on that Layer.
4. WHEN a Layer's lock state is set to locked, THE CAD_Engine SHALL prevent creation, modification, or deletion of CAD_Entity objects on that Layer.
5. WHEN the user creates a new CAD_Entity, THE CAD_Engine SHALL assign the entity to the currently active Layer, inheriting the Layer's color and line properties unless explicitly overridden.
6. THE CAD_Engine SHALL support creating, renaming, and deleting custom layers, with the restriction that the default "0" layer cannot be deleted.

---

### Requirement 7: Undo/Redo System

**User Story:** As an elevator engineer, I want to undo and redo drawing operations, so that I can correct mistakes and experiment with design changes without risk.

#### Acceptance Criteria

1. THE Command_Stack SHALL record every state-changing operation (entity creation, modification, deletion, layer change, property change) as a reversible command.
2. WHEN the user triggers Undo (Ctrl+Z), THE Command_Stack SHALL reverse the most recent command and restore the Entity_Model to its previous state.
3. WHEN the user triggers Redo (Ctrl+Y or Ctrl+Shift+Z), THE Command_Stack SHALL re-apply the most recently undone command.
4. THE Command_Stack SHALL support a minimum of 100 undo levels.
5. WHEN a new command is executed after one or more Undo operations, THE Command_Stack SHALL discard the redo history beyond the current position.
6. THE Command_Stack SHALL group related sub-operations (e.g., moving multiple selected entities) into a single undoable command.

---

### Requirement 8: Parametric Block Library

**User Story:** As an elevator engineer, I want a library of pre-built parametric elevator component blocks that I can insert into drawings, so that I can quickly compose standard elevator layouts without drawing each component from scratch.

#### Acceptance Criteria

1. THE Block_Library SHALL provide parametric Block_Definition objects for the following elevator components: Cabin (kabin), Guide Rails (kılavuz ray), Telescopic Door (teleskopik kapı), Center-Opening Door (ortadan açılır kapı), Counterweight (karşı ağırlık), Traction Machine (tahrik makinesi), Buffers (tampon), Safety Gear (emniyet tertibatı), Governor (regülatör), and Control Panel (kumanda panosu).
2. WHEN a Block_Definition is inserted, THE CAD_Engine SHALL create a Block_Reference at the specified insertion point, resolving parametric dimensions from the current Lift parameters (e.g., cabin width from KabinGenisligi, door width from KapiGenisligi).
3. WHEN a Lift parameter that affects a Block_Definition changes, THE CAD_Engine SHALL update all Block_Reference instances of that definition to reflect the new parametric dimensions.
4. THE Block_Definition for Cabin SHALL generate geometry including: cabin walls, door opening, handrail positions, and button panel position, scaled to KabinGenisligi × KabinDerinligi.
5. THE Block_Definition for Guide Rails SHALL generate geometry for the rail profile cross-section, scaled to the selected rail model dimensions from the Product_Catalog.
6. WHEN a Block_Reference is inserted, THE CAD_Engine SHALL support setting block attributes (text labels) equivalent to the original ZwCAD InsertBlock2 with ApplyAttributes functionality.
7. THE Block_Library SHALL support user-defined custom Block_Definitions created by grouping selected CAD_Entity objects.

---

### Requirement 9: Automatic Drawing Generation

**User Story:** As an elevator engineer, I want the system to automatically generate complete technical drawings from Lift parameters, so that I get instant visual feedback on my elevator design without manual drawing.

#### Acceptance Criteria

1. WHEN a shaft cross-section drawing is generated, THE CAD_Engine SHALL produce CAD_Entity objects representing: shaft walls, cabin outline, rail positions (cabin and counterweight), door opening, counterweight position based on YonKodu, and dimension annotations for all key measurements.
2. WHEN a shaft longitudinal section drawing is generated, THE CAD_Engine SHALL produce CAD_Entity objects representing: shaft pit, floor levels with architectural level labels, cabin at a reference floor, counterweight, travel distance annotation, overhead clearance, and machine room outline.
3. WHEN a machine room layout drawing is generated, THE CAD_Engine SHALL produce CAD_Entity objects representing: room walls, traction machine, deflection sheave, control panel, governor, and access door, with dimension annotations.
4. WHEN a cabin plan drawing is generated, THE CAD_Engine SHALL produce CAD_Entity objects representing: cabin walls, door opening, handrails, button panel, and interior dimensions.
5. WHEN a Lift parameter changes and auto-generated drawings exist, THE CAD_Engine SHALL offer the user a choice to regenerate the drawing (replacing manual edits) or keep the current drawing with manual edits preserved.
6. THE CAD_Engine SHALL place auto-generated entities on appropriate default layers (shaft walls on "Shaft", cabin on "Cabin", dimensions on "Dimensions").
7. WHEN a pit detail drawing is generated, THE CAD_Engine SHALL produce CAD_Entity objects representing: pit floor, buffer positions, safety gear clearance, and minimum pit depth dimensions per EN81-1.
8. WHEN an overhead detail drawing is generated, THE CAD_Engine SHALL produce CAD_Entity objects representing: top floor landing, overhead clearance, machine beam positions, and minimum overhead dimensions per EN81-1.

---

### Requirement 10: Hatch Patterns

**User Story:** As an elevator engineer, I want to apply hatch patterns to closed regions in cross-section drawings, so that I can visually distinguish materials (concrete walls, steel sections, insulation) per standard drafting conventions.

#### Acceptance Criteria

1. THE CAD_Engine SHALL support applying Hatch_Entity fills to closed boundaries defined by lines, polylines, circles, or arcs.
2. THE CAD_Engine SHALL provide built-in hatch patterns for: concrete (ANSI31), steel (ANSI32), insulation (INSUL), and solid fill.
3. WHEN a hatch pattern is applied, THE CAD_Engine SHALL compute the boundary from the selected closed geometry and fill the interior with the specified pattern at the specified scale and angle.
4. WHEN the boundary geometry of a Hatch_Entity is modified, THE Hatch_Entity SHALL update its fill to match the new boundary.

---

### Requirement 11: 3D Visualization

**User Story:** As an elevator engineer, I want a 3D view of the elevator shaft with all components, so that I can visually verify spatial relationships and present the design to clients.

#### Acceptance Criteria

1. THE Three_D_Viewer SHALL render a 3D model of the elevator shaft including: shaft walls, cabin, guide rails, counterweight, door assemblies, traction machine, and buffers, using Three.js.
2. THE Three_D_Viewer SHALL support orbit (rotate around target), pan, and zoom camera controls.
3. THE Three_D_Viewer SHALL support render mode switching between: wireframe, solid with edges, and transparent modes.
4. THE Three_D_Viewer SHALL support component visibility toggles allowing the user to show or hide individual component categories (cabin, rails, counterweight, machine, doors).
5. WHEN a Lift parameter changes, THE Three_D_Viewer SHALL update the 3D model to reflect the new dimensions and positions.
6. THE Three_D_Viewer SHALL support a section plane that cuts through the 3D model at a user-specified height, revealing the interior cross-section.
7. THE Three_D_Viewer SHALL generate 3D geometry from the same Lift parameters used by the 2D auto-generation, maintaining dimensional consistency between 2D and 3D views.

---

### Requirement 12: File Export — DXF and PDF

**User Story:** As an elevator engineer, I want to export drawings as DXF files compatible with AutoCAD/ZwCAD and as PDF documents, so that I can share drawings with contractors and approval authorities.

#### Acceptance Criteria

1. WHEN a DXF export is requested, THE DXF_Exporter SHALL produce a valid DXF file (AutoCAD 2013 format) containing all CAD_Entity objects from the Entity_Model, preserving: geometry coordinates, layer assignments, colors, line types, line weights, dimension values, text content, and block references.
2. THE DXF_Exporter SHALL map each Layer in the Entity_Model to a corresponding DXF layer with matching name, color index, and line type.
3. THE DXF_Exporter SHALL export Dimension_Entity objects as native DXF DIMENSION entities with correct measurement values and style properties.
4. THE DXF_Exporter SHALL export Block_Reference objects as DXF INSERT entities with resolved attribute values.
5. WHEN a PDF export is requested, THE CAD_Engine SHALL render the current Viewport to a PDF document at a user-selected scale (1:50, 1:100, 1:200) with a Title_Block containing company information, project name, drawing title, and date.
6. WHEN an SVG export is requested, THE CAD_Engine SHALL produce an SVG document containing all visible CAD_Entity objects with preserved layer colors and line styles.

---

### Requirement 13: Drawing Persistence and Server Sync

**User Story:** As an elevator engineer, I want to save and load interactive drawings to/from the server per project, so that my drawing work is preserved across sessions and accessible from any device.

#### Acceptance Criteria

1. THE Drawing_Serializer SHALL convert the Entity_Model (all entities, layers, blocks, viewport state) to a JSON representation for server storage.
2. THE Drawing_Serializer SHALL reconstruct the Entity_Model from a JSON representation, restoring all entities, layers, blocks, and viewport state.
3. FOR ALL valid Entity_Model states, serializing to JSON then deserializing back SHALL produce an Entity_Model with identical entity count, layer count, and all entity property values (round-trip property).
4. WHEN the user triggers a save operation, THE system SHALL send the serialized drawing JSON to the server API and associate it with the current Lift and drawing type.
5. WHEN the user opens a Lift's drawing page, THE system SHALL load the most recently saved drawing JSON from the server and reconstruct the Entity_Model on the CAD_Canvas.
6. IF the server returns no saved drawing for a Lift and drawing type, THEN THE system SHALL auto-generate a new drawing from the current Lift parameters.

---

### Requirement 14: Title Block and Drawing Sheets

**User Story:** As an elevator engineer, I want each drawing to include a standardized title block with company and project information, so that printed drawings meet professional documentation standards.

#### Acceptance Criteria

1. THE CAD_Engine SHALL support a Title_Block entity that renders a border and information panel at a fixed position relative to the drawing sheet boundaries.
2. THE Title_Block SHALL display: company name, company address, company phone, project name, drawing title, drawing number, scale, date, and revision number, sourced from the Company_Info_Service and current Project data.
3. THE Title_Block SHALL display mechanical engineer name and SMM number, and electrical engineer name and SMM number, sourced from the Company_Info_Service.
4. THE CAD_Engine SHALL support multiple drawing sheets per Lift, with each sheet having its own Title_Block and drawing content (cross-section, longitudinal section, machine room, cabin plan, pit detail, overhead detail).
5. WHEN company information or project data changes, THE Title_Block SHALL update its displayed content to reflect the current values.

---

### Requirement 15: Bi-Directional Parameter Sync

**User Story:** As an elevator engineer, I want changes to Lift parameters to update the drawing live, and want the ability to read measurements from the drawing back into parameters, so that the drawing and parameter model stay in sync.

#### Acceptance Criteria

1. WHEN a Lift parameter (shaft width, shaft depth, cabin width, cabin depth, door width, floor heights, drive direction) changes in the parameter panel, THE CAD_Engine SHALL update all affected auto-generated entities and Block_Reference instances on the CAD_Canvas in real time.
2. WHEN the user modifies a dimension value on an auto-generated Dimension_Entity by double-clicking and entering a new value, THE CAD_Engine SHALL propagate the new measurement back to the corresponding Lift parameter and update the server.
3. WHEN a parameter update from the drawing conflicts with EN81-1 constraints, THE CAD_Engine SHALL display a warning indicating the constraint violation and allow the user to accept or revert the change.
4. THE CAD_Engine SHALL maintain a mapping between auto-generated CAD_Entity objects and their source Lift parameters, so that parameter changes target the correct entities.

---

### Requirement 16: Keyboard Shortcuts and Command Input

**User Story:** As an elevator engineer, I want keyboard shortcuts and a command input line for common CAD operations, so that I can work efficiently using familiar CAD workflows.

#### Acceptance Criteria

1. THE CAD_Engine SHALL support a command input field where the user can type command names (e.g., "LINE", "CIRCLE", "MOVE", "COPY", "ZOOM") and press Enter to activate the corresponding Drawing_Tool or command.
2. THE CAD_Engine SHALL support the following keyboard shortcuts: Escape (cancel current operation), Delete (delete selected entities), Ctrl+Z (undo), Ctrl+Y (redo), Ctrl+A (select all), Ctrl+C (copy to clipboard), Ctrl+V (paste from clipboard), F8 (toggle Ortho_Mode), F3 (toggle snap).
3. WHEN a Drawing_Tool is active and the user types a numeric value followed by Enter, THE CAD_Engine SHALL use that value as the distance or radius input for the current tool operation.
4. THE CAD_Engine SHALL display the currently active command name and any prompts (e.g., "Specify first point:", "Specify radius:") in a status bar area.

---

### Requirement 17: Drawing Serializer Round-Trip

**User Story:** As a developer, I want to ensure that the drawing serializer preserves all entity data through JSON serialization and deserialization, so that saved drawings load identically to how they were saved.

#### Acceptance Criteria

1. FOR ALL valid Entity_Model states containing lines, polylines, circles, arcs, dimensions, text, hatches, and block references, serializing to JSON then deserializing back SHALL produce an Entity_Model with identical entity properties (round-trip property).
2. FOR ALL valid Layer configurations (name, color, line type, line weight, visibility, lock state), serializing to JSON then deserializing back SHALL preserve all layer properties (round-trip property).
3. FOR ALL valid Block_Definition objects with parametric attributes, serializing to JSON then deserializing back SHALL preserve the block geometry, attribute definitions, and parametric bindings (round-trip property).

---

### Requirement 18: DXF Entity Mapping Correctness

**User Story:** As a developer, I want to ensure that the DXF exporter correctly maps all CAD entity types to their DXF equivalents, so that exported files open correctly in AutoCAD and ZwCAD.

#### Acceptance Criteria

1. FOR ALL CAD_Entity objects of type line, THE DXF_Exporter SHALL produce a DXF LINE entity with matching start point (10/20) and end point (11/21) group codes.
2. FOR ALL CAD_Entity objects of type circle, THE DXF_Exporter SHALL produce a DXF CIRCLE entity with matching center point (10/20) and radius (40) group codes.
3. FOR ALL CAD_Entity objects of type polyline, THE DXF_Exporter SHALL produce a DXF LWPOLYLINE entity with matching vertex coordinates and closed/open flag.
4. FOR ALL CAD_Entity objects of type text, THE DXF_Exporter SHALL produce a DXF TEXT entity with matching insertion point, text height, and text content.
5. FOR ALL CAD_Entity objects of type dimension, THE DXF_Exporter SHALL produce a DXF DIMENSION entity with matching definition points and measurement value.
6. FOR ALL Layer objects in the Entity_Model, THE DXF_Exporter SHALL produce a DXF LAYER table entry with matching name, color index, and line type name.
