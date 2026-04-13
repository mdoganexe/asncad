using AscadWeb.Core.DTOs;
using AscadWeb.Core.Interfaces;
using AscadWeb.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AscadWeb.Api.Controllers;

[ApiController]
[Route("api/subscription")]
[Authorize]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionService _service;
    private readonly ITenantContext _tenantContext;
    private readonly AscadDbContext _db;

    public SubscriptionsController(ISubscriptionService service, ITenantContext tenantContext, AscadDbContext db)
    {
        _service = service;
        _tenantContext = tenantContext;
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<UsageStats>> GetUsage()
    {
        var usage = await _service.GetUsageAsync(_tenantContext.TenantId);
        return Ok(usage);
    }

    [HttpPut("plan")]
    public async Task<IActionResult> ChangePlan(ChangePlanRequest request)
    {
        var plan = await _db.SubscriptionPlans
            .FirstOrDefaultAsync(p => p.Name == request.PlanName && p.IsActive);

        if (plan == null)
            return BadRequest(new
            {
                error = new
                {
                    code = "VALIDATION_ERROR",
                    message = $"Plan '{request.PlanName}' not found."
                }
            });

        var subscription = await _db.TenantSubscriptions
            .FirstOrDefaultAsync(ts => ts.TenantId == _tenantContext.TenantId);

        if (subscription == null)
        {
            subscription = new Core.Entities.TenantSubscription
            {
                TenantId = _tenantContext.TenantId,
                PlanId = plan.Id,
                StartDate = DateTime.UtcNow,
                ExportCountResetDate = DateTime.UtcNow
            };
            _db.TenantSubscriptions.Add(subscription);
        }
        else
        {
            subscription.PlanId = plan.Id;
            subscription.UpdatedAt = DateTime.UtcNow;
        }

        await _db.SaveChangesAsync();

        var usage = await _service.GetUsageAsync(_tenantContext.TenantId);
        return Ok(usage);
    }
}
