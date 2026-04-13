using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Interfaces;

public interface ISettingsService
{
    Task<TenantSettings> GetSettingsAsync(Guid tenantId);
    Task<TenantSettings> UpdateSettingsAsync(Guid tenantId, UpdateSettingsRequest request);
}
