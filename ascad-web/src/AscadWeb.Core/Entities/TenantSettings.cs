namespace AscadWeb.Core.Entities;

public class TenantSettings : BaseEntity
{
    public Guid TenantId { get; set; }

    public int DefaultKuyuGenisligi { get; set; } = 2000;
    public int DefaultKuyuDerinligi { get; set; } = 2500;
    public int DefaultKapiGenisligi { get; set; } = 900;
    public int DefaultKatYuksekligi { get; set; } = 3000;
    public string DefaultTahrikKodu { get; set; } = "DA";
    public string DefaultKabinRayStr { get; set; } = "70x65x9";
    public string DefaultAgrRayStr { get; set; } = "50x50x5";

    public string Language { get; set; } = "tr";

    public double DefaultScaleFactor { get; set; } = 1.0;
    public int DimensionTextSize { get; set; } = 12;
    public double LineWeight { get; set; } = 1.0;

    public Tenant Tenant { get; set; } = null!;
}
