using AscadWeb.Core.Enums;

namespace AscadWeb.Core.DTOs;

public record CreateLiftRequest(
    Guid ProjectId,
    AsansorTipi AsansorTipi,
    TahrikKodu TahrikKodu,
    YonKodu YonKodu,
    int KuyuGenisligi,
    int KuyuDerinligi,
    int KuyuDibi,
    int KapiGenisligi,
    string KapiTipi,
    int DurakSayisi,
    int IlkDurakNo,
    string KatYuksekligi,
    string KabinRayStr,
    string AgrRayStr,
    bool Panoramik,
    List<FloorInfoDto>? Floors,
    string? GroupId = null,
    int? GroupPosition = null
);

public record UpdateLiftRequest(
    AsansorTipi? AsansorTipi,
    TahrikKodu? TahrikKodu,
    YonKodu? YonKodu,
    int? KuyuGenisligi,
    int? KuyuDerinligi,
    int? KuyuDibi,
    int? KapiGenisligi,
    string? KapiTipi,
    int? DurakSayisi,
    string? KabinRayStr,
    string? AgrRayStr,
    bool? Panoramik,
    List<FloorInfoDto>? Floors,
    string? GroupId = null,
    int? GroupPosition = null
);

public record LiftResponse(
    Guid Id,
    Guid ProjectId,
    int LiftNumber,
    string AsansorTipi,
    string TahrikKodu,
    string YonKodu,
    int KuyuGenisligi,
    int KuyuDerinligi,
    int KuyuDibi,
    int KuyuKafa,
    int KabinGenisligi,
    int KabinDerinligi,
    int KapiGenisligi,
    string KapiTipi,
    int BeyanYuk,
    int BeyanKisi,
    int DurakSayisi,
    string KabinRayStr,
    string AgrRayStr,
    bool Panoramik,
    List<FloorInfoDto> Floors,
    DateTime CreatedAt,
    string? GroupId = null,
    int? GroupPosition = null
);

public record FloorInfoDto(
    int KatNo,
    string KatRumuz,
    int KatYuksekligi,
    string MimariKot
);
