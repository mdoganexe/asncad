namespace AscadWeb.Core.DTOs;

public record UpdateSettingsRequest(
    int? DefaultKuyuGenisligi,
    int? DefaultKuyuDerinligi,
    int? DefaultKapiGenisligi,
    int? DefaultKatYuksekligi,
    string? DefaultTahrikKodu,
    string? DefaultKabinRayStr,
    string? DefaultAgrRayStr,
    string? Language,
    double? DefaultScaleFactor,
    int? DimensionTextSize,
    double? LineWeight
);
