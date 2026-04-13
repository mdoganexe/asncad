using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Interfaces;

public interface ISubscriptionService
{
    Task<SubscriptionPlan> GetPlanAsync(Guid tenantId);
    Task<UsageStats> GetUsageAsync(Guid tenantId);
    Task EnforceProjectLimitAsync(Guid tenantId);
    Task EnforceUserLimitAsync(Guid tenantId);
    Task EnforceExportLimitAsync(Guid tenantId);
    Task IncrementExportCountAsync(Guid tenantId);
}
