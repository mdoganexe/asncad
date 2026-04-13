using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;
using AscadWeb.Core.Exceptions;
using AscadWeb.Core.Interfaces;
using AscadWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AscadWeb.Infrastructure.Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly AscadDbContext _db;

    private static readonly List<SubscriptionPlan> DefaultPlans = new()
    {
        new SubscriptionPlan
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            Name = "Basic",
            MaxProjects = 5,
            MaxUsersPerTenant = 2,
            MaxPdfExportsPerMonth = 10,
            MonthlyPrice = 0m,
            IsActive = true
        },
        new SubscriptionPlan
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
            Name = "Professional",
            MaxProjects = 25,
            MaxUsersPerTenant = 10,
            MaxPdfExportsPerMonth = 100,
            MonthlyPrice = 49m,
            IsActive = true
        },
        new SubscriptionPlan
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
            Name = "Enterprise",
            MaxProjects = 999,
            MaxUsersPerTenant = 50,
            MaxPdfExportsPerMonth = 9999,
            MonthlyPrice = 149m,
            IsActive = true
        }
    };

    public SubscriptionService(AscadDbContext db)
    {
        _db = db;
    }

    public async Task<SubscriptionPlan> GetPlanAsync(Guid tenantId)
    {
        await EnsurePlansSeededAsync();

        var subscription = await _db.TenantSubscriptions
            .Include(ts => ts.Plan)
            .FirstOrDefaultAsync(ts => ts.TenantId == tenantId);

        if (subscription != null)
            return subscription.Plan;

        // Return Basic plan as default
        return await _db.SubscriptionPlans.FirstAsync(p => p.Name == "Basic");
    }

    public async Task<UsageStats> GetUsageAsync(Guid tenantId)
    {
        var plan = await GetPlanAsync(tenantId);

        int projectCount = await _db.Projects.CountAsync(p => p.TenantId == tenantId);
        int userCount = await _db.Users.CountAsync(u => u.TenantId == tenantId);

        var subscription = await _db.TenantSubscriptions
            .FirstOrDefaultAsync(ts => ts.TenantId == tenantId);

        int pdfExportCount = 0;
        if (subscription != null)
        {
            ResetExportCountIfNewMonth(subscription);
            pdfExportCount = subscription.MonthlyPdfExportCount;
        }

        return new UsageStats(
            plan.Name,
            projectCount,
            plan.MaxProjects,
            userCount,
            plan.MaxUsersPerTenant,
            pdfExportCount,
            plan.MaxPdfExportsPerMonth
        );
    }

    public async Task EnforceProjectLimitAsync(Guid tenantId)
    {
        var plan = await GetPlanAsync(tenantId);
        int count = await _db.Projects.CountAsync(p => p.TenantId == tenantId);

        if (count >= plan.MaxProjects)
            throw new PlanLimitExceededException(
                $"Project limit reached. Current: {count}, Limit: {plan.MaxProjects} ({plan.Name} plan).");
    }

    public async Task EnforceUserLimitAsync(Guid tenantId)
    {
        var plan = await GetPlanAsync(tenantId);
        int count = await _db.Users.CountAsync(u => u.TenantId == tenantId);

        if (count >= plan.MaxUsersPerTenant)
            throw new PlanLimitExceededException(
                $"User limit reached. Current: {count}, Limit: {plan.MaxUsersPerTenant} ({plan.Name} plan).");
    }

    public async Task EnforceExportLimitAsync(Guid tenantId)
    {
        var plan = await GetPlanAsync(tenantId);
        var subscription = await GetOrCreateSubscriptionAsync(tenantId);

        ResetExportCountIfNewMonth(subscription);

        if (subscription.MonthlyPdfExportCount >= plan.MaxPdfExportsPerMonth)
            throw new PlanLimitExceededException(
                $"Monthly PDF export limit reached. Current: {subscription.MonthlyPdfExportCount}, Limit: {plan.MaxPdfExportsPerMonth} ({plan.Name} plan).");
    }

    public async Task IncrementExportCountAsync(Guid tenantId)
    {
        var subscription = await GetOrCreateSubscriptionAsync(tenantId);

        ResetExportCountIfNewMonth(subscription);
        subscription.MonthlyPdfExportCount++;
        subscription.UpdatedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();
    }

    private async Task<TenantSubscription> GetOrCreateSubscriptionAsync(Guid tenantId)
    {
        var subscription = await _db.TenantSubscriptions
            .Include(ts => ts.Plan)
            .FirstOrDefaultAsync(ts => ts.TenantId == tenantId);

        if (subscription != null)
            return subscription;

        await EnsurePlansSeededAsync();
        var basicPlan = await _db.SubscriptionPlans.FirstAsync(p => p.Name == "Basic");

        subscription = new TenantSubscription
        {
            TenantId = tenantId,
            PlanId = basicPlan.Id,
            StartDate = DateTime.UtcNow,
            MonthlyPdfExportCount = 0,
            ExportCountResetDate = DateTime.UtcNow
        };

        _db.TenantSubscriptions.Add(subscription);
        await _db.SaveChangesAsync();

        subscription.Plan = basicPlan;
        return subscription;
    }

    private static void ResetExportCountIfNewMonth(TenantSubscription subscription)
    {
        var now = DateTime.UtcNow;
        if (now.Year != subscription.ExportCountResetDate.Year ||
            now.Month != subscription.ExportCountResetDate.Month)
        {
            subscription.MonthlyPdfExportCount = 0;
            subscription.ExportCountResetDate = now;
        }
    }

    private async Task EnsurePlansSeededAsync()
    {
        if (await _db.SubscriptionPlans.AnyAsync())
            return;

        foreach (var plan in DefaultPlans)
        {
            _db.SubscriptionPlans.Add(new SubscriptionPlan
            {
                Id = plan.Id,
                Name = plan.Name,
                MaxProjects = plan.MaxProjects,
                MaxUsersPerTenant = plan.MaxUsersPerTenant,
                MaxPdfExportsPerMonth = plan.MaxPdfExportsPerMonth,
                MonthlyPrice = plan.MonthlyPrice,
                IsActive = plan.IsActive
            });
        }

        await _db.SaveChangesAsync();
    }
}
