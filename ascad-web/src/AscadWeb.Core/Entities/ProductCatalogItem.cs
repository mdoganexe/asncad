namespace AscadWeb.Core.Entities;

public class ProductCatalogItem : BaseEntity
{
    public Guid TenantId { get; set; }
    public string Category { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string SpecsJson { get; set; } = "{}";

    public Tenant Tenant { get; set; } = null!;
}
