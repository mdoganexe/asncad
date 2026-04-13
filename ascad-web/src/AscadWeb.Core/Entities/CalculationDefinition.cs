namespace AscadWeb.Core.Entities;

public class CalculationDefinition : BaseEntity
{
    public Guid TenantId { get; set; }
    public int Sira { get; set; }
    public string Parametre { get; set; } = string.Empty;
    public string Standart { get; set; } = string.Empty;
    public string Aciklama { get; set; } = string.Empty;
    public string Formul { get; set; } = string.Empty;
    public string Birim { get; set; } = string.Empty;
    public string VeriTipi { get; set; } = "d";
    public string? TipKodu { get; set; }
    public string? TahrikKodu { get; set; }
    public string? YonKodu { get; set; }
    public bool IsActive { get; set; } = true;

    public Tenant Tenant { get; set; } = null!;
}
