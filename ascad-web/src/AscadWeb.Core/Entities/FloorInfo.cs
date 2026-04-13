namespace AscadWeb.Core.Entities;

/// <summary>
/// Kat bilgileri - Orijinal clsKatBilgi + structKatBilgileri
/// </summary>
public class FloorInfo : BaseEntity
{
    public Guid LiftId { get; set; }
    public int KatNo { get; set; }
    public string KatRumuz { get; set; } = string.Empty;
    public int KatYuksekligi { get; set; }
    public string MimariKot { get; set; } = string.Empty;

    // Navigation
    public Lift Lift { get; set; } = null!;
}
