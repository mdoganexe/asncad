using AscadWeb.Core.Enums;

namespace AscadWeb.Core.Entities;

/// <summary>
/// Asansör ana modeli - Orijinal clsMainLift + myData birleşimi
/// </summary>
public class Lift : BaseEntity
{
    public Guid ProjectId { get; set; }
    public int LiftNumber { get; set; } = 1;

    // Asansör Tipi
    public AsansorTipi AsansorTipiKodu { get; set; } = AsansorTipi.EA;
    public TahrikKodu TahrikKodu { get; set; } = TahrikKodu.DA;
    public YonKodu YonKodu { get; set; } = YonKodu.SOL;

    // Kuyu Bilgileri
    public int KuyuGenisligi { get; set; } = 2000;
    public int KuyuDerinligi { get; set; } = 2500;
    public int KuyuDibi { get; set; }
    public int KuyuKafa { get; set; }

    // Kabin Bilgileri
    public int KabinGenisligi { get; set; }
    public int KabinDerinligi { get; set; }
    public int KabinYuksekligi { get; set; }

    // Kapı Bilgileri
    public int KapiGenisligi { get; set; } = 900;
    public string KapiTipi { get; set; } = "KK-OT";
    public string Mentese { get; set; } = string.Empty;

    // Yük ve Kapasite
    public int BeyanYuk { get; set; }
    public int BeyanKisi { get; set; }

    // Kat Bilgileri
    public int DurakSayisi { get; set; }
    public int IlkDurakNo { get; set; }
    public string SeyirMesafesi { get; set; } = string.Empty;
    public string KatYuksekligi { get; set; } = "3000";

    // Ray Bilgileri
    public string KabinRayStr { get; set; } = string.Empty;
    public string AgrRayStr { get; set; } = string.Empty;

    // Tampon Bilgileri
    public string KabinTamponu { get; set; } = string.Empty;
    public string AgrTamponu { get; set; } = string.Empty;

    // Tahrik Bilgileri
    public string TahrikKasnagi { get; set; } = string.Empty;
    public string SapmaKasnagi { get; set; } = string.Empty;
    public string MdTabTavan { get; set; } = "2100";

    // Regülatör
    public string RegulatorYeri { get; set; } = string.Empty;

    // Panoramik
    public bool Panoramik { get; set; }

    // HAMD (Hidrolik)
    public int? HAMDGenisligi { get; set; }
    public int? HAMDDerinligi { get; set; }

    // Group support for multi-elevator shafts
    public string? GroupId { get; set; }
    public int? GroupPosition { get; set; }

    // Speed and balance for calculations
    public double RatedSpeed { get; set; } = 1.0;
    public double BalanceRatio { get; set; } = 0.5;

    // Component catalog references
    public Guid? CabinRailCatalogId { get; set; }
    public Guid? CounterweightRailCatalogId { get; set; }
    public Guid? CabinBufferCatalogId { get; set; }
    public Guid? CounterweightBufferCatalogId { get; set; }
    public Guid? MotorCatalogId { get; set; }
    public Guid? SafetyDeviceCatalogId { get; set; }
    public Guid? RopeCatalogId { get; set; }

    // Navigation
    public Project Project { get; set; } = null!;
    public ICollection<FloorInfo> Floors { get; set; } = new List<FloorInfo>();
    public ICollection<CalculationResult> CalculationResults { get; set; } = new List<CalculationResult>();
}
