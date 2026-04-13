namespace AscadWeb.Core.Entities;

/// <summary>
/// Firma bilgileri - Orijinal FirmaBilgileri formundan taşındı
/// </summary>
public class CompanyInfo : BaseEntity
{
    public Guid TenantId { get; set; }
    public string Ad { get; set; } = string.Empty;
    public string Adres { get; set; } = string.Empty;
    public string Telefon { get; set; } = string.Empty;
    public string Fax { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Yetkili { get; set; } = string.Empty;
    public string Marka { get; set; } = string.Empty;
    public string VergiDairesi { get; set; } = string.Empty;
    public string VergiNo { get; set; } = string.Empty;

    // Onaylı Kuruluş
    public string OnayliKurulusAd { get; set; } = string.Empty;
    public string OnayliKurulusNo { get; set; } = string.Empty;
    public DateTime? SanayiTarih { get; set; }
    public string SanayiNo { get; set; } = string.Empty;
    public DateTime? HYBTarih { get; set; }
    public string HYBNo { get; set; } = string.Empty;

    // Makina Mühendisi
    public string MakinaMuhAd { get; set; } = string.Empty;
    public string MakinaMuhOdaSicil { get; set; } = string.Empty;
    public string MakinaMuhBelge { get; set; } = string.Empty;
    public string MakinaMuhSMM { get; set; } = string.Empty;

    // Elektrik Mühendisi
    public string ElektrikMuhAd { get; set; } = string.Empty;
    public string ElektrikMuhOdaSicil { get; set; } = string.Empty;
    public string ElektrikMuhBelge { get; set; } = string.Empty;
    public string ElektrikMuhSMM { get; set; } = string.Empty;

    // Navigation
    public Tenant Tenant { get; set; } = null!;
}
