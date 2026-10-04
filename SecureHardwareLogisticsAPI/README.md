# Project Requirements Document (PRD): Secure Hardware Logistics API

## 1. Project Overview
**Objective:** Build an enterprise-grade backend REST API to manage the chain-of-custody for secure military field hardware (e.g., encrypted laptops, radios). The system will replace manual tracking by provisioning assets, assigning them to personnel, and generating immutable audit logs for every state change.

**Use Case Context:** Demonstrates defensive engineering, relational database management (EF Core), strict DTO boundaries, and proper Dependency Injection lifetimes for federal/enterprise environments.

## 2. Technology Stack
* **Framework:** .NET Core Web API (C#)
* **Architecture:** Controller-Based MVC (No Minimal APIs)
* **Database:** PostgreSQL (Hosted on Neon serverless DB)
* **ORM:** Entity Framework (EF) Core
* **Design Patterns:** Dependency Injection, Repository/Service Pattern, DTOs

## 3. Database Schema & Entities

### **HardwareAsset** (Table: `HardwareAssets`)
* `Id` (int, Primary Key)
* `SerialNumber` (string, Server-generated UUID/Secure Hash - never client-provided)
* `DeviceModel` (string, e.g., "ThinkPad T14")
* `AssignedMilitaryId` (string, nullable)
* `Status` (string, e.g., "In Inventory", "Deployed", "Decommissioned")
* `CreatedAt` (DateTime, UTC)

### **AuditLog** (Table: `AuditLogs`)
* `Id` (int, Primary Key)
* `HardwareAssetId` (int, Foreign Key)
* `Action` (string, e.g., "Provisioned", "Assigned to [ID]")
* `Timestamp` (DateTime, UTC)
* *Relationship:* One `HardwareAsset` has many `AuditLogs`.

## 4. API Endpoints & Contracts

| Method | Endpoint | Description | Input (DTO) | Output / Status Code |
| :--- | :--- | :--- | :--- | :--- |
| **POST** | `/api/assets` | Provision a new secure asset into inventory. | `ProvisionAssetDto` (DeviceModel) | `201 Created` returns `AssetSummaryDto` |
| **GET** | `/api/assets` | List all tracked hardware. | None | `200 OK` returns `List<AssetSummaryDto>` |
| **GET** | `/api/assets/{id}` | Retrieve specific asset + full audit history. | None | `200 OK` returns `AssetDetailDto` |
| **PUT** | `/api/assets/{id}/assign` | Assign asset to user & log chain-of-custody. | `AssignAssetDto` (MilitaryId) | `204 No Content` or `404 Not Found` |

## 5. Core Technical Requirements (Acceptance Criteria)

* **Strict DTO Boundaries:** Database entities (`HardwareAsset`, `AuditLog`) must never be returned directly in the controller or accepted as parameters. Map all requests/responses to DTOs to prevent over-posting vulnerabilities.
* **Server-Side Data Generation:** The `SerialNumber` and `CreatedAt` fields must be generated in the Service layer, not accepted from the client.
* **Transactional Integrity:** The `PUT /assign` endpoint must update the `HardwareAsset` table AND insert a new `AuditLog` record using a single `await _context.SaveChangesAsync()` call.
* **Eager Loading (Solving N+1):** The `GET /api/assets/{id}` endpoint must use `.Include(a => a.AuditLogs)` to fetch the chain-of-custody history in a single SQL query.
* **Performance Optimization:** The `GET /api/assets` endpoint must utilize `.AsNoTracking()` to reduce memory overhead for read-only operations.
* **Service Layer Abstraction:** Controllers must not inject `AppDbContext` directly. Controllers inject an `IAssetService` (Scoped lifetime), which contains the EF Core business logic.

## 6. Project Structure
Maintain a clean separation of concerns using the following folder structure:
```text
SecureHardwareLogisticsAPI/
├── Controllers/
│   └── AssetsController.cs
├── Data/
│   └── AppDbContext.cs
├── DTOs/
│   ├── Requests/
│   │   ├── ProvisionAssetDto.cs
│   │   └── AssignAssetDto.cs
│   └── Responses/
│       ├── AssetSummaryDto.cs
│       └── AssetDetailDto.cs
├── Models/
│   ├── HardwareAsset.cs
│   └── AuditLog.cs
├── Services/
│   ├── IAssetService.cs
│   └── AssetService.cs
├── appsettings.json
└── Program.cs