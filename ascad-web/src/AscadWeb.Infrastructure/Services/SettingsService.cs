using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using AscadWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AscadWeb.Infrastructure.Services;

public class SettingsService : ISettingsService
{
    private readonly AscadDbContext _db;

    public SettingsService(AscadDbContext db)
    {
        _db = db;
    }

    public async Task<TenantSettings> GetSettingsAsync(Guid tenantId)
    {
        var settings = await _db.TenantSettings.FirstOrDefaultAsync(s => s.TenantId == tenantId);
        if (settings != null)
            return settings;

        // Create defaults: Turkish language, standard dimensions
        settings = new TenantSettings
        {
            TenantId = tenantId,
            Language = "tr",
            DefaultKuyuGenisligi = 2000,
            DefaultKuyuDerinligi = 2500,
            DefaultKapiGenisligi = 900,
            DefaultKatYuksekligi = 3000,
            DefaultTahrikKodu = "DA",
            DefaultKabinRayStr = "70x65x9",
            DefaultAgrRayStr = "50x50x5",
            DefaultScaleFactor = 1.0,
            DimensionTextSize = 12,
            LineWeight = 1.0
        };

        _db.TenantSettings.Add(settings);
        await _db.SaveChangesAsync();
        return settings;
    }

    public async Task<TenantSettings> UpdateSettingsAsync(Guid tenantId, UpdateSettingsRequest request)
    {
        var settings = await GetSettingsAsync(tenantId);

        // Update only non-null fields
        if (request.DefaultKuyuGenisligi.HasValue) settings.DefaultKuyuGenisligi = request.DefaultKuyuGenisligi.Value;
        if (request.DefaultKuyuDerinligi.HasValue) settings.DefaultKuyuDerinligi = request.DefaultKuyuDerinligi.Value;
        if (request.DefaultKapiGenisligi.HasValue) settings.DefaultKapiGenisligi = request.DefaultKapiGenisligi.Value;
        if (request.DefaultKatYuksekligi.HasValue) settings.DefaultKatYuksekligi = request.DefaultKatYuksekligi.Value;
        if (request.DefaultTahrikKodu is not null) settings.DefaultTahrikKodu = request.DefaultTahrikKodu;
        if (request.DefaultKabinRayStr is not null) settings.DefaultKabinRayStr = request.DefaultKabinRayStr;
        if (request.DefaultAgrRayStr is not null) settings.DefaultAgrRayStr = request.DefaultAgrRayStr;
        if (request.Language is not null) settings.Language = request.Language;
        if (request.DefaultScaleFactor.HasValue) settings.DefaultScaleFactor = request.DefaultScaleFactor.Value;
        if (request.DimensionTextSize.HasValue) settings.DimensionTextSize = request.DimensionTextSize.Value;
        if (request.LineWeight.HasValue) settings.LineWeight = request.LineWeight.Value;

        settings.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();
        return settings;
    }
}
