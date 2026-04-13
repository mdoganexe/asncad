using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Interfaces;

public interface IProductCatalogService
{
    Task<ProductCatalogItem?> GetByIdAsync(Guid id, Guid tenantId);
    Task<List<ProductCatalogItem>> GetByCategoryAsync(string category, Guid tenantId);
    Task<List<ProductCatalogItem>> SearchAsync(string? category, string? modelName, Guid tenantId);
    Task<ProductCatalogItem> CreateAsync(CreateCatalogItemRequest request, Guid tenantId);
    Task<ProductCatalogItem> UpdateAsync(Guid id, UpdateCatalogItemRequest request, Guid tenantId);
    Task DeleteAsync(Guid id, Guid tenantId);
    Task SeedDefaultsAsync(Guid tenantId);
}
