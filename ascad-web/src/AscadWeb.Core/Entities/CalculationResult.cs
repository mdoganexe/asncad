namespace AscadWeb.Core.Entities;

/// <summary>
/// Hesaplama sonuçları - Orijinal hesaplamalar formundan
/// </summary>
public class CalculationResult : BaseEntity
{
    public Guid LiftId { get; set; }
    public int Sira { get; set; }
    public string Parametre { get; set; } = string.Empty;
    public string Standart { get; set; } = string.Empty;
    public string Aciklama { get; set; } = string.Empty;
    public string Formul { get; set; } = string.Empty;
    public string FormulDeger { get; set; } = string.Empty;
    public string FormulSonuc { get; set; } = string.Empty;
    public string Birim { get; set; } = string.Empty;
    public string VeriTipi { get; set; } = "d"; // d=decimal, s=string

    // Navigation
    public Lift Lift { get; set; } = null!;
}
