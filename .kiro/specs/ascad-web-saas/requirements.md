# Requirements Document

## Introduction

This document defines the requirements for completing the ASCAD Web SaaS platform — a migration of the ASCAD desktop elevator (asansör) design and calculation application from .NET Framework 4.0 WinForms to a web-based multi-tenant SaaS platform. The existing web implementation provides authentication, project CRUD, lift CRUD, basic calculation engine, and a canvas-based shaft preview. This specification covers all remaining features needed for full parity and SaaS readiness.

## Glossary

- **Calculation_Engine**: The server-side service that evaluates elevator design formulas, performs EN81-1 compliance checks, and produces calculation results for a given Lift configuration.
- **Company_Info_Service**: The backend service responsible for storing and retrieving company profile data (firma bilgileri) per Tenant.
- **Building_Template_Service**: The service that provides pre-configured default elevator parameters based on building type (residential, hotel, hospital, school, business center, parking, government).
- **PDF_Report_Generator**: The service that produces PDF documents containing calculation summaries, technical specifications, and EN81-1 compliance reports.
- **Product_Catalog**: The data store and API for elevator component master data including rails, buffers, motors, doors, safety devices, and ropes.
- **Drawing_Generator**: The service that produces 2D technical drawings (shaft cross-section, longitudinal section, machine room layout, cabin plan) as SVG output with DXF export capability.
- **Floor_Editor**: The frontend component and backend logic for managing floor information per lift, including auto-calculation of architectural levels (mimari kot) and travel distances.
- **Subscription_Service**: The service managing tenant subscription plans, usage limits, and billing integration.
- **Settings_Service**: The service managing per-tenant configuration preferences including default parameters, units, language, and drawing preferences.
- **Tenant**: An organization (company) that subscribes to the platform; all data is isolated per Tenant.
- **Lift**: A single elevator configuration within a Project, containing shaft dimensions, cabin parameters, drive type, and floor information.
- **Project**: A container for one or more Lift configurations belonging to a Tenant.
- **NCalc_Expression**: A mathematical expression string evaluated dynamically at runtime, supporting parameter substitution and conditional logic (ported from the original NCalc library).
- **EARS**: Easy Approach to Requirements Syntax — the pattern used for all acceptance criteria.
- **EN81-1**: European standard for safety rules for the construction and installation of electric lifts.
- **Beyan_Yuk**: Declared load capacity of the elevator in kilograms, derived from cabin area per EN81-1 Table 1.1.
- **Mimari_Kot**: Architectural level — the absolute height of each floor relative to ground level (0.00).
- **Seyir_Mesafesi**: Travel distance — the vertical distance between the first and last stop.

---

## Requirements

### Requirement 1: Company Information Management

**User Story:** As a tenant administrator, I want to manage my company profile including engineer certifications and approved organization details, so that this information appears on generated reports and documents.

#### Acceptance Criteria

1. THE Company_Info_Service SHALL store and retrieve the following fields per Tenant: company name, address, phone, fax, email, brand, tax office, tax number, authorized person name.
2. THE Company_Info_Service SHALL store and retrieve mechanical engineer information per Tenant: full name, chamber registration number (oda sicil), certificate number (belge), and SMM number.
3. THE Company_Info_Service SHALL store and retrieve electrical engineer information per Tenant: full name, chamber registration number (oda sicil), certificate number (belge), and SMM number.
4. THE Company_Info_Service SHALL store and retrieve approved organization information per Tenant: organization name, organization number, industry registration date and number (sanayi tarih/no), and HYB date and number.
5. WHEN a tenant administrator submits a company information update request with valid data, THE Company_Info_Service SHALL persist all provided fields and return the updated record.
6. WHEN a tenant administrator requests company information and no record exists, THE Company_Info_Service SHALL return a default empty record for that Tenant.
7. IF a company information update request contains a field exceeding 255 characters, THEN THE Company_Info_Service SHALL reject the request with a validation error specifying the offending field.

---

### Requirement 2: Dynamic Calculation Engine

**User Story:** As an elevator engineer, I want the calculation engine to evaluate formulas dynamically from database-driven definitions, so that calculations can be extended and modified without code changes.

#### Acceptance Criteria

1. THE Calculation_Engine SHALL support three calculation types: GENEL (direct parameter lookup), GENELFRM (formula evaluation with parameter substitution), and SORG (conditional compliance check returning UY or UD).
2. WHEN a GENELFRM calculation is executed, THE Calculation_Engine SHALL parse the formula string, substitute all referenced parameters with their current values, evaluate the mathematical expression, and store both the substituted formula and the numeric result.
3. WHEN a SORG calculation is executed, THE Calculation_Engine SHALL evaluate the conditional expression and return "UY" (uygun/compliant) when the condition is true and "UD" (uygun değil/non-compliant) when the condition is false.
4. THE Calculation_Engine SHALL support master data lookups where the standart field contains a hyphen-separated reference (e.g., "ray-KabinRAYID"), resolving the value from the corresponding master table.
5. THE Calculation_Engine SHALL maintain a parameter dictionary during calculation execution, adding each computed result as a parameter available to subsequent formulas.
6. WHEN a formula references an undefined parameter, THE Calculation_Engine SHALL record an error result for that calculation row and continue processing remaining calculations.
7. THE Calculation_Engine SHALL support the following mathematical operations in formula expressions: addition, subtraction, multiplication, division, modulo, power, comparison operators, and conditional (if/then) expressions.
8. WHEN a calculation definition is added or modified in the database, THE Calculation_Engine SHALL use the updated definition on the next calculation execution without requiring a service restart.

---

### Requirement 3: Rail Master Data Lookups

**User Story:** As an elevator engineer, I want to select rail profiles from a catalog of standard rail types, so that the calculation engine can look up rail properties (dimensions, weight, moment of inertia) for structural calculations.

#### Acceptance Criteria

1. THE Product_Catalog SHALL store rail master data with the following fields: model (e.g., "70x65x9"), weight per meter (kg/m), moment of inertia Ix (cm⁴), moment of inertia Iy (cm⁴), section modulus Wx (cm³), section modulus Wy (cm³), and cross-sectional area (cm²).
2. WHEN a rail model identifier is provided, THE Product_Catalog SHALL return the complete set of rail properties for that model.
3. THE Product_Catalog SHALL provide a list of all available rail models for use in selection dropdowns.
4. WHEN a calculation references a rail property, THE Calculation_Engine SHALL resolve the value from the Product_Catalog using the Lift's configured rail model identifier.

---

### Requirement 4: Motor and Machine Selection Calculations

**User Story:** As an elevator engineer, I want the system to calculate motor power requirements and machine selection parameters, so that I can specify the correct drive unit for the elevator.

#### Acceptance Criteria

1. WHEN motor calculations are triggered for a Lift, THE Calculation_Engine SHALL compute the required motor power based on declared load (Beyan_Yuk), speed, balance ratio, and drive type efficiency.
2. THE Calculation_Engine SHALL compute the traction sheave diameter requirement based on rope diameter and the minimum D/d ratio specified by EN81-1.
3. THE Calculation_Engine SHALL compute the deflection sheave diameter requirement when the drive type requires a deflection sheave (sapma kasnağı).
4. WHEN the drive type is machine-room-less (MDDUZ or MDCAP), THE Calculation_Engine SHALL apply the corresponding machine-room-less calculation parameters.

---

### Requirement 5: Rope and Cable Calculations

**User Story:** As an elevator engineer, I want the system to calculate rope specifications including quantity, diameter, and safety factors, so that the suspension system meets EN81-1 requirements.

#### Acceptance Criteria

1. WHEN rope calculations are triggered, THE Calculation_Engine SHALL compute the minimum number of ropes based on declared load, cabin weight, rope diameter, and the safety factor specified by EN81-1.
2. THE Calculation_Engine SHALL compute the rope safety factor and verify it meets the EN81-1 minimum requirement of 12 for traction drives.
3. THE Calculation_Engine SHALL compute the rope pressure ratio on the traction sheave and verify it does not exceed the allowable limit.
4. WHEN the drive type is direct suspension (DA), THE Calculation_Engine SHALL use a roping factor of 1; WHEN the drive type is indirect suspension (YA), THE Calculation_Engine SHALL use a roping factor of 2.

---

### Requirement 6: Safety Device Calculations

**User Story:** As an elevator engineer, I want the system to calculate safety device (fren/emniyet) requirements, so that the selected safety gear meets EN81-1 standards for the given load and speed.

#### Acceptance Criteria

1. WHEN safety device calculations are triggered, THE Calculation_Engine SHALL compute the required braking force based on declared load, cabin weight, and balance ratio.
2. THE Calculation_Engine SHALL verify that the selected safety device type is appropriate for the configured elevator speed per EN81-1 requirements.
3. THE Calculation_Engine SHALL compute the governor tripping speed and verify it falls within the EN81-1 specified range relative to rated speed.

---

### Requirement 7: Buffer Calculations

**User Story:** As an elevator engineer, I want the system to calculate buffer requirements for both cabin and counterweight, so that the selected buffers meet EN81-1 impact absorption standards.

#### Acceptance Criteria

1. WHEN buffer calculations are triggered, THE Calculation_Engine SHALL compute the minimum buffer stroke based on rated speed and EN81-1 formula.
2. THE Calculation_Engine SHALL verify that the selected cabin buffer type provides sufficient stroke for the rated speed.
3. THE Calculation_Engine SHALL verify that the selected counterweight buffer type provides sufficient stroke for the rated speed.
4. WHEN the rated speed exceeds 1.0 m/s, THE Calculation_Engine SHALL require energy-accumulating buffers with buffered return (type B) or energy-dissipating buffers (type C).

---

### Requirement 8: Building Type Templates

**User Story:** As an elevator engineer, I want to select a building type and have the system pre-fill elevator parameters with appropriate defaults, so that I can quickly configure elevators for common building scenarios.

#### Acceptance Criteria

1. THE Building_Template_Service SHALL provide templates for the following building types: Residential (Konut), Hotel (Otel), Hospital (Hastane), School (Okul), Business Center (İş Merkezi), Parking (Otopark), and Government (Resmi).
2. WHEN a Residential template is selected, THE Building_Template_Service SHALL accept apartment unit counts by type (1+1, 2+1, 3+1, 4+1, 5+1) and compute the total occupant count using the multipliers: 1+1→2, 2+1→3, 3+1→4, 4+1→5, 5+1→6 persons per unit.
3. WHEN a Hotel template is selected, THE Building_Template_Service SHALL accept the total bed count and use it as the occupant count for elevator capacity sizing.
4. WHEN a Hospital template is selected, THE Building_Template_Service SHALL accept the total bed count and compute the occupant count using a multiplier of 3 persons per bed.
5. WHEN a building template is applied, THE Building_Template_Service SHALL return recommended elevator parameters including minimum cabin dimensions, minimum load capacity, and recommended number of elevators based on the computed occupant count.
6. WHEN the computed occupant count for a Residential building reaches or exceeds 200, THE Building_Template_Service SHALL flag the result as requiring additional elevator capacity review.

---

### Requirement 9: PDF Report Generation

**User Story:** As an elevator engineer, I want to generate PDF reports containing calculation results, technical specifications, and compliance status, so that I can submit documentation to approval authorities.

#### Acceptance Criteria

1. WHEN a calculation summary report is requested, THE PDF_Report_Generator SHALL produce a PDF document containing: company letterhead information, project details, lift configuration parameters, and all calculation results in tabular format.
2. THE PDF_Report_Generator SHALL highlight non-compliant calculation results (FormulSonuc = "UD") with red background in the output table.
3. THE PDF_Report_Generator SHALL include a floor information table showing floor number, floor designation (kat rumuz), floor height, and architectural level (mimari kot) for each floor.
4. THE PDF_Report_Generator SHALL include the company's mechanical engineer and electrical engineer information with their certification details in the report footer.
5. WHEN a report is generated, THE PDF_Report_Generator SHALL include the generation date, project name, and a unique report identifier.
6. THE PDF_Report_Generator SHALL produce the report as a downloadable PDF file with a maximum generation time of 30 seconds for a lift with up to 50 floors.

---

### Requirement 10: Product and Component Catalog Management

**User Story:** As a tenant administrator, I want to manage a catalog of elevator components (rails, buffers, motors, doors, safety devices, ropes), so that engineers can select from approved components during design.

#### Acceptance Criteria

1. THE Product_Catalog SHALL support CRUD operations for the following component categories: rails (ray), buffers (tampon), motors/machines (motor), doors (kapı), safety devices (fren/emniyet), and ropes/cables (halat).
2. WHEN a component is created, THE Product_Catalog SHALL require a category, model name, and at least one technical specification field.
3. THE Product_Catalog SHALL support filtering components by category and searching by model name.
4. WHEN a component referenced by an existing Lift configuration is deleted, THE Product_Catalog SHALL reject the deletion with an error indicating the component is in use.
5. THE Product_Catalog SHALL provide default seed data for common rail profiles (e.g., 70x65x9, 89x62x16, 50x50x5) and standard buffer types upon tenant creation.

---

### Requirement 11: 2D CAD Drawing Generation

**User Story:** As an elevator engineer, I want the system to generate 2D technical drawings of the shaft cross-section, longitudinal section, machine room layout, and cabin plan, so that I can review the design visually and export drawings for construction documents.

#### Acceptance Criteria

1. WHEN a shaft cross-section drawing is requested, THE Drawing_Generator SHALL produce an SVG image showing: shaft walls with dimensions, cabin outline with dimensions, rail positions (cabin and counterweight), door opening position, and counterweight position based on drive direction (yonKodu).
2. WHEN a shaft longitudinal section drawing is requested, THE Drawing_Generator SHALL produce an SVG image showing: shaft pit depth, each floor level with architectural level labels, travel distance, overhead clearance, and machine room height where applicable.
3. WHEN a machine room layout drawing is requested, THE Drawing_Generator SHALL produce an SVG image showing: room dimensions, traction machine position, deflection sheave position, control panel position, and access door position.
4. WHEN a cabin plan drawing is requested, THE Drawing_Generator SHALL produce an SVG image showing: cabin interior dimensions, door opening, handrail positions, and button panel position.
5. WHEN a DXF export is requested for any drawing type, THE Drawing_Generator SHALL produce a valid DXF file containing all geometry, dimensions, and text annotations from the corresponding SVG drawing.
6. THE Drawing_Generator SHALL scale all drawings proportionally and include dimension annotations in millimeters.

---

### Requirement 12: Multi-Elevator Support

**User Story:** As an elevator engineer, I want to configure multiple elevators within a single project sharing a common shaft wall, so that I can design elevator groups for buildings with adjacent shafts.

#### Acceptance Criteria

1. THE Lift entity SHALL support a group identifier that associates multiple Lifts within the same Project as a shared-shaft group.
2. WHEN multiple Lifts are assigned to the same group, THE system SHALL compute the total shaft width as the sum of individual shaft widths plus partition wall thicknesses (ara bölme).
3. WHEN a shared-shaft group drawing is requested, THE Drawing_Generator SHALL produce a combined cross-section showing all elevators in the group with shared walls indicated.
4. WHEN a Lift in a group is modified, THE system SHALL recalculate the combined shaft dimensions for the group.

---

### Requirement 13: Subscription and Billing

**User Story:** As a platform operator, I want to manage subscription plans with usage limits, so that tenants are billed according to their usage tier.

#### Acceptance Criteria

1. THE Subscription_Service SHALL support three plan tiers: Basic, Professional, and Enterprise, each with configurable limits for maximum projects, maximum users per tenant, and maximum PDF exports per month.
2. WHEN a Tenant attempts to create a Project exceeding the plan's project limit, THE Subscription_Service SHALL reject the request with an error indicating the plan limit has been reached.
3. WHEN a Tenant attempts to add a user exceeding the plan's user limit, THE Subscription_Service SHALL reject the request with an error indicating the plan limit has been reached.
4. THE Subscription_Service SHALL track monthly PDF export usage per Tenant and enforce the plan's export limit.
5. THE Subscription_Service SHALL expose an API endpoint returning the Tenant's current plan, usage statistics, and remaining quotas.
6. THE Subscription_Service SHALL provide a placeholder integration point for a payment provider (Stripe) to process subscription payments.

---

### Requirement 14: Enhanced Floor Management

**User Story:** As an elevator engineer, I want the floor editor to auto-calculate architectural levels, support negative floors (basements), and compute travel distances automatically, so that I can efficiently configure floor information without manual calculations.

#### Acceptance Criteria

1. WHEN floor information is entered with floor heights, THE Floor_Editor SHALL auto-calculate the architectural level (mimari kot) for each floor relative to ground level (floor 0 = 0.00).
2. WHEN negative floor numbers are present (basements), THE Floor_Editor SHALL calculate their architectural levels as negative values by accumulating floor heights downward from ground level.
3. WHEN floor information changes, THE Floor_Editor SHALL auto-calculate the travel distance (seyir mesafesi) as the difference between the last stop's architectural level and the first stop's architectural level.
4. WHEN floor information changes, THE Floor_Editor SHALL auto-calculate the shaft pit depth requirement based on the first floor's position and EN81-1 minimum pit depth rules.
5. WHEN floor information changes, THE Floor_Editor SHALL auto-calculate the overhead clearance (kuyu kafa) based on the last floor's position and the machine room floor height.
6. THE Floor_Editor SHALL support floor designations (kat rumuz) as free-text labels (e.g., "Z" for ground, "B1" for basement 1, "1" for first floor).
7. WHEN a floor is added or removed, THE Floor_Editor SHALL recalculate all architectural levels and update the travel distance, pit depth, and overhead values.

---

### Requirement 15: Tenant Settings and Configuration

**User Story:** As a tenant administrator, I want to configure default parameters, language preferences, and drawing preferences for my organization, so that all users in my tenant share consistent defaults.

#### Acceptance Criteria

1. THE Settings_Service SHALL store and retrieve per-tenant default parameters including: default shaft width, default shaft depth, default door width, default floor height, default drive type, and default rail profiles.
2. WHEN a new Lift is created and no explicit values are provided for configurable fields, THE system SHALL apply the Tenant's default parameter values.
3. THE Settings_Service SHALL support a language preference setting with Turkish as the primary language.
4. THE Settings_Service SHALL store drawing preferences per Tenant including: default scale factor, dimension text size, and line weight preferences.
5. WHEN a tenant administrator updates settings, THE Settings_Service SHALL persist the changes and apply the updated defaults to subsequent new Lift creations.

---

### Requirement 16: Calculation Result Serialization Round-Trip

**User Story:** As a developer, I want to ensure that calculation results can be serialized to JSON and deserialized back without data loss, so that API responses and database storage preserve all calculation data accurately.

#### Acceptance Criteria

1. FOR ALL valid CalculationResult objects, serializing to JSON then deserializing back SHALL produce an object with identical field values (round-trip property).
2. FOR ALL valid CalculationSummary objects containing a list of CalculationResult items, serializing to JSON then deserializing back SHALL preserve the item count and all field values of each item.
3. FOR ALL valid Lift objects with associated FloorInfo collections, serializing to JSON then deserializing back SHALL preserve the floor count and all floor field values.

---

### Requirement 17: Formula Parser and Pretty Printer

**User Story:** As a developer, I want a formula parser that converts formula strings into an evaluable expression tree and a pretty printer that converts expression trees back to formula strings, so that formulas can be validated, displayed, and round-tripped reliably.

#### Acceptance Criteria

1. WHEN a valid formula string is provided, THE Formula_Parser SHALL parse it into a structured expression representation supporting: numeric literals, parameter references, binary operators (+, -, *, /), comparison operators (>, <, >=, <=, ==, !=), and conditional expressions (if/then/else).
2. WHEN an invalid formula string is provided, THE Formula_Parser SHALL return a descriptive parse error indicating the position and nature of the syntax error.
3. THE Pretty_Printer SHALL format expression representations back into valid formula strings.
4. FOR ALL valid formula strings, parsing then pretty-printing then parsing again SHALL produce an equivalent expression representation (round-trip property).
