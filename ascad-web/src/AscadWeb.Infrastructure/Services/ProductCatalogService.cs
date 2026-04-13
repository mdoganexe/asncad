using System.Text.Json;
using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using AscadWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AscadWeb.Infrastructure.Services;

public class ProductCatalogService : IProductCatalogService
{
    private readonly AscadDbContext _db;

    public ProductCatalogService(AscadDbContext db)
    {
        _db = db;
    }

    public async Task<ProductCatalogItem?> GetByIdAsync(Guid id, Guid tenantId)
    {
        return await _db.ProductCatalogItems
            .FirstOrDefaultAsync(p => p.Id == id && p.TenantId == tenantId);
    }

    public async Task<List<ProductCatalogItem>> GetByCategoryAsync(string category, Guid tenantId)
    {
        return await _db.ProductCatalogItems
            .Where(p => p.TenantId == tenantId && p.Category == category)
            .ToListAsync();
    }

    public async Task<List<ProductCatalogItem>> SearchAsync(string? category, string? modelName, Guid tenantId)
    {
        var query = _db.ProductCatalogItems.Where(p => p.TenantId == tenantId);

        if (!string.IsNullOrWhiteSpace(category))
            query = query.Where(p => p.Category == category);

        if (!string.IsNullOrWhiteSpace(modelName))
            query = query.Where(p => p.ModelName.ToLower().Contains(modelName.ToLower()));

        return await query.ToListAsync();
    }

    public async Task<ProductCatalogItem> CreateAsync(CreateCatalogItemRequest request, Guid tenantId)
    {
        if (string.IsNullOrWhiteSpace(request.Category))
            throw new ArgumentException("Category is required.");

        if (string.IsNullOrWhiteSpace(request.ModelName))
            throw new ArgumentException("ModelName is required.");

        if (string.IsNullOrWhiteSpace(request.SpecsJson))
            throw new ArgumentException("SpecsJson is required.");

        var item = new ProductCatalogItem
        {
            TenantId = tenantId,
            Category = request.Category,
            ModelName = request.ModelName,
            Description = request.Description,
            SpecsJson = request.SpecsJson
        };

        _db.ProductCatalogItems.Add(item);
        await _db.SaveChangesAsync();
        return item;
    }

    public async Task<ProductCatalogItem> UpdateAsync(Guid id, UpdateCatalogItemRequest request, Guid tenantId)
    {
        var item = await _db.ProductCatalogItems
            .FirstOrDefaultAsync(p => p.Id == id && p.TenantId == tenantId);

        if (item is null)
            throw new KeyNotFoundException($"Catalog item with id '{id}' not found.");

        if (request.ModelName is not null) item.ModelName = request.ModelName;
        if (request.Description is not null) item.Description = request.Description;
        if (request.SpecsJson is not null) item.SpecsJson = request.SpecsJson;

        item.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();
        return item;
    }

    public async Task DeleteAsync(Guid id, Guid tenantId)
    {
        var item = await _db.ProductCatalogItems
            .FirstOrDefaultAsync(p => p.Id == id && p.TenantId == tenantId);

        if (item is null)
            throw new KeyNotFoundException($"Catalog item with id '{id}' not found.");

        // Check if any Lift references this catalog item across all 7 FK fields
        var isReferenced = await _db.Lifts.AnyAsync(l =>
            l.CabinRailCatalogId == id ||
            l.CounterweightRailCatalogId == id ||
            l.CabinBufferCatalogId == id ||
            l.CounterweightBufferCatalogId == id ||
            l.MotorCatalogId == id ||
            l.SafetyDeviceCatalogId == id ||
            l.RopeCatalogId == id);

        if (isReferenced)
            throw new InvalidOperationException("Component is in use by an existing lift configuration.");

        _db.ProductCatalogItems.Remove(item);
        await _db.SaveChangesAsync();
    }

    public async Task SeedDefaultsAsync(Guid tenantId)
    {
        // Check if tenant already has catalog items to avoid duplicate seeding
        var existingCount = await _db.ProductCatalogItems
            .CountAsync(p => p.TenantId == tenantId);

        if (existingCount > 0)
            return;

        var items = new List<ProductCatalogItem>
        {
            // Rail profiles
            new()
            {
                TenantId = tenantId,
                Category = "ray",
                ModelName = "70x65x9",
                Description = "Standard T-profile guide rail",
                SpecsJson = JsonSerializer.Serialize(new RailSpec
                {
                    WeightPerMeter = 5.5,
                    Ix = 22.9,
                    Iy = 7.7,
                    Wx = 6.5,
                    Wy = 2.4,
                    CrossSectionalArea = 7.0
                })
            },
            new()
            {
                TenantId = tenantId,
                Category = "ray",
                ModelName = "89x62x16",
                Description = "Heavy-duty T-profile guide rail",
                SpecsJson = JsonSerializer.Serialize(new RailSpec
                {
                    WeightPerMeter = 12.3,
                    Ix = 79.7,
                    Iy = 14.5,
                    Wx = 17.9,
                    Wy = 4.7,
                    CrossSectionalArea = 15.7
                })
            },
            new()
            {
                TenantId = tenantId,
                Category = "ray",
                ModelName = "50x50x5",
                Description = "Light T-profile guide rail",
                SpecsJson = JsonSerializer.Serialize(new RailSpec
                {
                    WeightPerMeter = 3.7,
                    Ix = 7.1,
                    Iy = 7.1,
                    Wx = 2.8,
                    Wy = 2.8,
                    CrossSectionalArea = 4.7
                })
            },
            // Buffer types
            new()
            {
                TenantId = tenantId,
                Category = "tampon",
                ModelName = "YTampon1",
                Description = "Spring buffer (yay tampon)",
                SpecsJson = JsonSerializer.Serialize(new { Type = "spring", MaxSpeed = 1.0 })
            },
            new()
            {
                TenantId = tenantId,
                Category = "tampon",
                ModelName = "HTampon",
                Description = "Hydraulic buffer (hidrolik tampon)",
                SpecsJson = JsonSerializer.Serialize(new { Type = "hydraulic", MaxSpeed = 10.0 })
            }
        };

        _db.ProductCatalogItems.AddRange(items);
        await _db.SaveChangesAsync();
    }
}
