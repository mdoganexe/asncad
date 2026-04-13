# Implementation Plan: ASCAD Web SaaS Platform

## Overview

This plan converts the ASCAD Web application into a full-featured multi-tenant SaaS platform. Tasks are ordered by dependency: foundational entities and infrastructure first, then core services, then API controllers, then frontend components, with testing woven into each feature area. The existing Clean Architecture (Api → Core → Infrastructure) is extended — not replaced.

## Tasks

- [x] 1. Core entities, DTOs, and database schema
  - [x] 1.1 Create new Core entities: CalculationDefinition, ProductCatalogItem, RailSpec, SubscriptionPlan, TenantSubscription, TenantSettings
    - Add `CalculationDefinition.cs`, `ProductCatalogItem.cs`, `RailSpec.cs`, `SubscriptionPlan.cs`, `TenantSubscription.cs`, `TenantSettings.cs` to `AscadWeb.Core/Entities/`
    - Add `FormulaExpression.cs` AST records to `AscadWeb.Core/Models/`
    - Add `BuildingTemplateResult.cs` to `AscadWeb.Core/Models/`
    - _Requirements: 2.1, 3.1, 8.5, 10.1, 13.1, 15.1, 17.1_

  - [x] 1.2 Extend existing Lift entity with group support and component references
    - Add `GroupId`, `GroupPosition`, `RatedSpeed`, `BalanceRatio`, and catalog FK properties (`CabinRailCatalogId`, `CounterweightRailCatalogId`, `CabinBufferCatalogId`, `CounterweightBufferCatalogId`, `MotorCatalogId`, `SafetyDeviceCatalogId`, `RopeCatalogId`) to `Lift.cs`
    - _Requirements: 5.1, 5.4, 12.1_

  - [x] 1.3 Create all new DTOs
    - Add `UpdateCompanyInfoRequest`, `CreateCatalogItemRequest`, `UpdateCatalogItemRequest`, `CatalogItemResponse`, `BuildingTemplateRequest`, `UsageStats`, `UpdateSettingsRequest`, `UpdateFloorsRequest`, `FloorCalculationResponse` to `AscadWeb.Core/DTOs/`
    - _Requirements: 1.5, 3.2, 8.2, 10.2, 13.5, 14.1, 15.1_

  - [x] 1.4 Create all new service interfaces
    - Add `IDynamicCalculationService`, `IFormulaParser`, `IProductCatalogService`, `IBuildingTemplateService`, `IDrawingGeneratorService`, `IPdfReportGeneratorService`, `IFloorCalculationService`, `ISubscriptionService`, `ISettingsService`, `ICompanyInfoService`, `ILiftGroupService`, `ITenantContext` to `AscadWeb.Core/Interfaces/`
    - _Requirements: 1, 2, 3, 8, 9, 10, 11, 12, 13, 14, 15, 17_

  - [x] 1.5 Update AscadDbContext with new DbSets and entity configurations
    - Add DbSets for `CalculationDefinition`, `ProductCatalogItem`, `SubscriptionPlan`, `TenantSubscription`, `TenantSettings`
    - Configure Tenant navigation properties for new entities
    - Configure Lift catalog FK relationships and group index
    - Add EF migration
    - _Requirements: 2.1, 3.1, 10.1, 12.1, 13.1, 15.1_

- [x] 2. Tenant infrastructure and middleware
  - [x] 2.1 Implement ITenantContext and TenantMiddleware
    - Create `TenantContext` class that reads TenantId from JWT claims
    - Create `TenantMiddleware` that populates ITenantContext per request
    - Register in DI and middleware pipeline in `Program.cs`
    - _Requirements: 1.5, 13.2_

  - [x] 2.2 Implement SubscriptionMiddleware
    - Create middleware that checks plan limits on write operations (project creation, user addition, PDF export)
    - Return `PLAN_LIMIT_EXCEEDED` (403) when limits are exceeded
    - Register in middleware pipeline after authentication
    - _Requirements: 13.2, 13.3, 13.4_

- [x] 3. Checkpoint — Ensure all entities compile and migrations run
  - Ensure all tests pass, ask the user if questions arise.

- [x] 4. Company information service and API
  - [x] 4.1 Implement CompanyInfoService
    - Implement `ICompanyInfoService.GetOrCreateAsync` — return existing or create empty default record
    - Implement `ICompanyInfoService.UpdateAsync` — validate 255-char field limits, persist changes
    - _Requirements: 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7_

  - [x] 4.2 Create CompanyInfoController with GET and PUT endpoints
    - `GET /api/company-info` — returns tenant company info
    - `PUT /api/company-info` — updates company info with validation
    - Wire to DI in `Program.cs`
    - _Requirements: 1.5, 1.6, 1.7_

  - [ ]* 4.3 Write property tests for CompanyInfo (Properties 1, 2)
    - **Property 1: CompanyInfo storage round-trip**
    - **Property 2: CompanyInfo field length validation**
    - **Validates: Requirements 1.1, 1.2, 1.3, 1.4, 1.5, 1.7**

- [x] 5. Formula parser service
  - [x] 5.1 Implement FormulaParserService (recursive-descent parser)
    - Parse formula strings into `FormulaExpression` AST: `NumberLiteral`, `ParameterRef`, `BinaryOp`, `ComparisonOp`, `ConditionalExpr`
    - Implement `PrettyPrint` to convert AST back to formula string
    - Return descriptive parse errors with position for invalid input
    - _Requirements: 17.1, 17.2, 17.3, 17.4_

  - [ ]* 5.2 Write property tests for FormulaParser (Properties 24, 25)
    - **Property 24: Formula parse-print-parse round-trip**
    - **Property 25: Formula parser error on invalid input**
    - **Validates: Requirements 17.1, 17.2, 17.3, 17.4**

- [x] 6. Dynamic calculation engine
  - [x] 6.1 Implement DynamicCalculationService
    - Read `CalculationDefinition` rows from database ordered by `Sira`
    - Filter by `TipKodu`, `TahrikKodu`, `YonKodu` matching the Lift configuration (or TEMEL for all)
    - Implement GENEL type: direct parameter lookup
    - Implement GENELFRM type: NCalc formula evaluation with parameter substitution, store substituted formula and numeric result
    - Implement SORG type: conditional evaluation returning "UY" or "UD"
    - Implement master data lookups (hyphen-separated standart field, e.g., "ray-KabinRAYID")
    - Maintain parameter dictionary — each computed result becomes available to subsequent formulas
    - Record error results for undefined parameters or evaluation failures, continue processing
    - _Requirements: 2.1, 2.2, 2.3, 2.4, 2.5, 2.6, 2.7, 2.8_

  - [x] 6.2 Create CalculationsController
    - `POST /api/lifts/{id}/calculate` — runs dynamic calculations for a lift, replaces old hardcoded endpoint
    - Return `CalculationSummaryDto` with all results
    - _Requirements: 2.2, 2.3, 4.1, 5.1, 6.1, 7.1_

  - [ ]* 6.3 Write property tests for calculation engine (Properties 3, 4, 5, 6)
    - **Property 3: GENELFRM formula evaluation correctness**
    - **Property 4: SORG compliance check correctness**
    - **Property 5: Calculation parameter accumulation**
    - **Property 6: Roping factor by drive type**
    - **Validates: Requirements 2.2, 2.3, 2.5, 2.7, 4.1, 5.1, 5.2, 5.3, 5.4, 6.1, 6.2, 6.3, 7.1, 7.2, 7.3, 7.4**

- [x] 7. Product catalog service and API
  - [x] 7.1 Implement ProductCatalogService
    - CRUD operations for catalog items scoped by TenantId
    - Validate required fields (category, modelName, non-empty specsJson) on create
    - Reject deletion when item is referenced by a Lift (check catalog FK fields)
    - Implement `SeedDefaultsAsync` — seed common rail profiles (70x65x9, 89x62x16, 50x50x5) and standard buffer types
    - Implement search/filter by category and model name
    - _Requirements: 3.1, 3.2, 3.3, 10.1, 10.2, 10.3, 10.4, 10.5_

  - [x] 7.2 Create ProductCatalogController
    - `GET /api/catalog` — list/search with category and modelName query params
    - `GET /api/catalog/{id}` — get single item
    - `POST /api/catalog` — create item
    - `PUT /api/catalog/{id}` — update item
    - `DELETE /api/catalog/{id}` — delete item (reject if in use)
    - `GET /api/catalog/rails` — list rail models specifically
    - Wire to DI in `Program.cs`
    - _Requirements: 3.1, 3.2, 3.3, 10.1, 10.2, 10.3, 10.4_

  - [ ] 7.3 Write property tests for ProductCatalog (Properties 9, 10, 11)
    - **Property 9: Product catalog item round-trip**
    - **Property 10: Product catalog category filtering**
    - **Property 11: Product catalog creation validation**
    - **Validates: Requirements 3.1, 3.2, 10.1, 10.2, 10.3**

- [x] 8. Checkpoint — Ensure calculation engine, catalog, and company info work end-to-end
  - Ensure all tests pass, ask the user if questions arise.

- [x] 9. Building template service and API
  - [x] 9.1 Implement BuildingTemplateService
    - Return available building types: Konut, Otel, Hastane, Okul, İş Merkezi, Otopark, Resmi
    - Implement `ApplyTemplate` with occupant count formulas per type (Residential: unit multipliers, Hotel: bed count, Hospital: bed count × 3)
    - Compute recommended cabin dimensions, load capacity, and elevator count from occupant count
    - Set `RequiresAdditionalCapacityReview = true` when residential occupant count ≥ 200
    - _Requirements: 8.1, 8.2, 8.3, 8.4, 8.5, 8.6_

  - [x] 9.2 Create BuildingTemplatesController
    - `GET /api/building-templates` — list available building types
    - `POST /api/building-templates/apply` — apply template and return recommendations
    - _Requirements: 8.1, 8.5_

  - [ ] 9.3 Write property tests for BuildingTemplate (Properties 7, 8)
    - **Property 7: Building template occupant count calculation**
    - **Property 8: Residential capacity review flag**
    - **Validates: Requirements 8.2, 8.3, 8.4, 8.6**

- [x] 10. Floor calculation service and API
  - [x] 10.1 Implement FloorCalculationService
    - `CalculateArchitecturalLevels` — compute mimari kot for each floor relative to ground (floor 0 = 0.00), negative floors accumulate downward
    - `CalculateTravelDistance` — difference between last and first stop architectural levels
    - `CalculatePitDepth` — based on first floor position and EN81-1 minimum pit depth rules
    - `CalculateOverheadClearance` — based on last floor position and machine room height
    - _Requirements: 14.1, 14.2, 14.3, 14.4, 14.5, 14.7_

  - [x] 10.2 Create FloorsController
    - `PUT /api/lifts/{id}/floors` — update floors, auto-calculate levels, return `FloorCalculationResponse`
    - _Requirements: 14.1, 14.6, 14.7_

  - [ ]* 10.3 Write property tests for FloorCalculation (Properties 17, 18)
    - **Property 17: Floor architectural level calculation**
    - **Property 18: Floor travel distance calculation**
    - **Validates: Requirements 14.1, 14.2, 14.3, 14.7**

- [x] 11. Subscription service and API
  - [x] 11.1 Implement SubscriptionService
    - `GetPlanAsync` — return tenant's active subscription plan
    - `GetUsageAsync` — compute current project count, user count, monthly PDF export count, remaining quotas
    - `EnforceProjectLimitAsync`, `EnforceUserLimitAsync`, `EnforceExportLimitAsync` — throw with PLAN_LIMIT_EXCEEDED when at limit
    - `IncrementExportCountAsync` — increment monthly PDF export counter, reset on month boundary
    - Seed three plan tiers (Basic, Professional, Enterprise) with configurable limits
    - Include placeholder Stripe fields on TenantSubscription
    - _Requirements: 13.1, 13.2, 13.3, 13.4, 13.5, 13.6_

  - [x] 11.2 Create SubscriptionsController
    - `GET /api/subscription` — return plan info and usage stats
    - `PUT /api/subscription/plan` — change plan
    - _Requirements: 13.5_

  - [ ]* 11.3 Write property tests for Subscription (Properties 15, 16)
    - **Property 15: Subscription plan limit enforcement**
    - **Property 16: Subscription usage stats accuracy**
    - **Validates: Requirements 13.2, 13.3, 13.4, 13.5**

- [x] 12. Settings service and API
  - [x] 12.1 Implement SettingsService
    - `GetSettingsAsync` — return tenant settings or create defaults (Turkish language, standard dimensions)
    - `UpdateSettingsAsync` — persist updated settings
    - Wire default settings into Lift creation flow (apply tenant defaults when explicit values not provided)
    - _Requirements: 15.1, 15.2, 15.3, 15.4, 15.5_

  - [x] 12.2 Create SettingsController
    - `GET /api/settings` — return tenant settings
    - `PUT /api/settings` — update tenant settings
    - _Requirements: 15.1, 15.4_

  - [ ]* 12.3 Write property tests for Settings (Properties 19, 20)
    - **Property 19: Tenant settings round-trip**
    - **Property 20: Tenant defaults applied to new lifts**
    - **Validates: Requirements 15.1, 15.2, 15.4, 15.5**

- [x] 13. Checkpoint — Ensure all backend services and APIs work
  - Ensure all tests pass, ask the user if questions arise.

- [x] 14. Drawing generator service and API
  - [x] 14.1 Implement DrawingGeneratorService
    - `GenerateShaftCrossSection` — SVG with shaft walls, cabin outline, rail positions, door opening, counterweight position based on yonKodu, dimension annotations in mm
    - `GenerateLongitudinalSection` — SVG with pit depth, floor levels with mimari kot labels, travel distance, overhead clearance, machine room height
    - `GenerateMachineRoomLayout` — SVG with room dimensions, traction machine, deflection sheave, control panel, access door positions
    - `GenerateCabinPlan` — SVG with cabin interior dimensions, door opening, handrail, button panel positions
    - `GenerateGroupCrossSection` — combined SVG for multi-elevator groups with shared walls
    - `ExportToDxf` — convert SVG geometry to DXF format
    - _Requirements: 11.1, 11.2, 11.3, 11.4, 11.5, 11.6, 12.3_

  - [x] 14.2 Create DrawingsController
    - `GET /api/lifts/{id}/drawings/{type}` — return SVG for specified drawing type
    - `GET /api/lifts/{id}/drawings/{type}/dxf` — return DXF file download
    - `GET /api/lifts/{id}/drawings/group` — return group cross-section SVG
    - _Requirements: 11.1, 11.5, 12.3_

  - [ ]* 14.3 Write property tests for Drawing (Properties 12, 13, 14)
    - **Property 12: SVG cross-section contains shaft dimensions**
    - **Property 13: SVG longitudinal section contains floor levels**
    - **Property 14: Group shaft width calculation**
    - **Validates: Requirements 11.1, 11.2, 12.2**

- [x] 15. PDF report generator service and API
  - [x] 15.1 Implement PdfReportGeneratorService using QuestPDF
    - Add QuestPDF NuGet package to `AscadWeb.Core.csproj`
    - Generate PDF with: company letterhead, project details, lift configuration, calculation results table
    - Highlight non-compliant results (UD) with red background
    - Include floor information table (floor number, designation, height, mimari kot)
    - Include engineer certifications in footer
    - Include generation date, project name, unique report identifier
    - Target max 30 seconds for 50-floor lift
    - _Requirements: 9.1, 9.2, 9.3, 9.4, 9.5, 9.6_

  - [x] 15.2 Create ReportsController
    - `POST /api/lifts/{id}/report` — generate and return PDF file, increment export count via SubscriptionService
    - _Requirements: 9.1, 13.4_

- [x] 16. Multi-elevator group service
  - [x] 16.1 Implement LiftGroupService
    - `CalculateGroupShaftWidth` — sum individual shaft widths + (n-1) × partition wall thickness
    - `GetGroupLiftsAsync` — return all lifts in a group
    - Recalculate group dimensions when any lift in group is modified
    - _Requirements: 12.1, 12.2, 12.4_

  - [x] 16.2 Update LiftsController for group support
    - Add `GroupId` and `GroupPosition` to lift create/update requests
    - Return group info in lift responses
    - _Requirements: 12.1_

- [ ] 17. Serialization round-trip tests
  - [ ]* 17.1 Write property tests for serialization (Properties 21, 22, 23)
    - **Property 21: CalculationResult JSON serialization round-trip**
    - **Property 22: CalculationSummary JSON serialization round-trip**
    - **Property 23: Lift with FloorInfo JSON serialization round-trip**
    - **Validates: Requirements 16.1, 16.2, 16.3**

- [x] 18. Checkpoint — Ensure all backend features complete and tests pass
  - Ensure all tests pass, ask the user if questions arise.

- [x] 19. Frontend — TypeScript types and API client extensions
  - [x] 19.1 Extend TypeScript types in `client/src/types/index.ts`
    - Add types for: `CompanyInfo`, `UpdateCompanyInfoRequest`, `CatalogItem`, `CreateCatalogItemRequest`, `UpdateCatalogItemRequest`, `BuildingTemplateRequest`, `BuildingTemplateResult`, `UsageStats`, `SubscriptionPlan`, `TenantSettings`, `UpdateSettingsRequest`, `FloorCalculationResponse`, `DrawingType`
    - Add `groupId` and `groupPosition` to `Lift` type
    - _Requirements: 1, 3, 8, 10, 11, 12, 13, 14, 15_

  - [x] 19.2 Extend API service client in `client/src/api/services.ts`
    - Add `companyInfoApi`: `get()`, `update()`
    - Add `catalogApi`: `getAll()`, `getById()`, `create()`, `update()`, `delete()`, `getRails()`
    - Add `templateApi`: `getTypes()`, `apply()`
    - Add `drawingApi`: `getSvg()`, `getDxf()`
    - Add `reportApi`: `generate()`
    - Add `floorApi`: `update()`
    - Add `subscriptionApi`: `get()`, `changePlan()`
    - Add `settingsApi`: `get()`, `update()`
    - _Requirements: 1, 3, 8, 9, 10, 11, 13, 14, 15_

- [x] 20. Frontend — Company info and settings pages
  - [x] 20.1 Create CompanyInfoPage component
    - Form with all company fields (name, address, phone, fax, email, brand, tax info)
    - Engineer certification sections (mechanical and electrical)
    - Approved organization section
    - Save with validation feedback
    - Route: `/settings/company`
    - _Requirements: 1.1, 1.2, 1.3, 1.4, 1.5_

  - [x] 20.2 Create SettingsPage component
    - Default lift parameter inputs (shaft width, depth, door width, floor height, drive type, rail profiles)
    - Language preference selector
    - Drawing preferences (scale factor, text size, line weight)
    - Route: `/settings`
    - _Requirements: 15.1, 15.3, 15.4_

  - [x] 20.3 Create SubscriptionPage component
    - Display current plan name and limits
    - Show usage stats (projects, users, PDF exports) with progress bars
    - Plan upgrade/downgrade options
    - Route: `/subscription`
    - _Requirements: 13.1, 13.5_

- [x] 21. Frontend — Product catalog page
  - [x] 21.1 Create CatalogPage component
    - Category tabs (ray, tampon, motor, kapı, fren, halat)
    - List items per category with search
    - Create/edit modal with category-specific spec fields
    - Delete with confirmation (show error if in use)
    - Route: `/catalog`
    - _Requirements: 10.1, 10.2, 10.3, 10.4_

- [x] 22. Frontend — Lift design page enhancements
  - [x] 22.1 Create FloorEditor component (embedded in LiftDesignPage)
    - Editable floor table: floor number, designation (free text), floor height
    - Auto-display computed mimari kot, travel distance, pit depth, overhead clearance
    - Add/remove floor buttons with auto-recalculation
    - Support negative floor numbers (basements)
    - _Requirements: 14.1, 14.2, 14.3, 14.4, 14.5, 14.6, 14.7_

  - [x] 22.2 Create ComponentSelector component (embedded in LiftDesignPage)
    - Catalog-backed dropdowns for: cabin rail, counterweight rail, cabin buffer, counterweight buffer, motor, safety device, rope
    - Fetch options from catalog API filtered by category
    - Update lift with selected catalog item IDs
    - _Requirements: 3.3, 3.4, 10.1_

  - [x] 22.3 Create DrawingViewer component (embedded in LiftDesignPage)
    - Tab switching: Cross Section, Longitudinal, Machine Room, Cabin Plan
    - Render SVG from API response
    - DXF export button per drawing type
    - _Requirements: 11.1, 11.2, 11.3, 11.4, 11.5_

  - [x] 22.4 Create CalculationPanel component (enhanced calculation results)
    - Display dynamic calculation results from new engine
    - Highlight non-compliant (UD) rows in red
    - Show parameter values and substituted formulas
    - _Requirements: 2.2, 2.3_

  - [x] 22.5 Add ReportButton to LiftDesignPage
    - Button to trigger PDF report generation
    - Download generated PDF file
    - Show subscription limit warning if at export limit
    - _Requirements: 9.1, 13.4_

  - [x] 22.6 Integrate FloorEditor, ComponentSelector, DrawingViewer, CalculationPanel, and ReportButton into LiftDesignPage
    - Update LiftDesignPage layout to include all new components
    - Wire data flow between components (lift data, calculation results)
    - _Requirements: 2, 3, 9, 11, 14_

- [x] 23. Frontend — Project detail page enhancements
  - [x] 23.1 Create BuildingTemplateSelector component (embedded in ProjectDetailPage)
    - Building type dropdown with parameter inputs per type
    - Display recommended elevator parameters after template application
    - Show capacity review warning for residential ≥ 200 occupants
    - _Requirements: 8.1, 8.2, 8.3, 8.4, 8.5, 8.6_

  - [x] 23.2 Create LiftGroupPanel component (embedded in ProjectDetailPage)
    - Group assignment UI: assign lifts to groups, set positions
    - Display combined shaft width calculation
    - Show group cross-section drawing
    - _Requirements: 12.1, 12.2, 12.3, 12.4_

  - [x] 23.3 Integrate BuildingTemplateSelector and LiftGroupPanel into ProjectDetailPage
    - Update ProjectDetailPage layout
    - Wire template results to lift creation defaults
    - _Requirements: 8, 12_

- [x] 24. Frontend — Routing and navigation updates
  - [x] 24.1 Update App.tsx with new routes and Layout navigation
    - Add routes: `/settings/company`, `/catalog`, `/settings`, `/subscription`
    - Update Layout sidebar/nav with links to new pages
    - _Requirements: 1, 10, 13, 15_

- [x] 25. Final checkpoint — Full integration verification
  - Ensure all tests pass, ask the user if questions arise.

## Notes

- Tasks marked with `*` are optional and can be skipped for faster MVP
- Each task references specific requirements for traceability
- Checkpoints ensure incremental validation
- Property tests validate universal correctness properties from the design document (25 properties)
- The backend uses C# / ASP.NET Core 8.0; the frontend uses TypeScript / React 18
- QuestPDF and FsCheck NuGet packages need to be added; fast-check npm package for frontend PBT
