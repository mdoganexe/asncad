using AscadWeb.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AscadWeb.Api.Controllers;

[ApiController]
[Route("api")]
[Authorize]
public class ReportsController : ControllerBase
{
    private readonly IPdfReportGeneratorService _pdfService;
    private readonly ILiftRepository _liftRepo;
    private readonly IProjectRepository _projectRepo;
    private readonly ICompanyInfoService _companyInfoService;
    private readonly ISubscriptionService _subscriptionService;
    private readonly ITenantContext _tenantContext;

    public ReportsController(
        IPdfReportGeneratorService pdfService,
        ILiftRepository liftRepo,
        IProjectRepository projectRepo,
        ICompanyInfoService companyInfoService,
        ISubscriptionService subscriptionService,
        ITenantContext tenantContext)
    {
        _pdfService = pdfService;
        _liftRepo = liftRepo;
        _projectRepo = projectRepo;
        _companyInfoService = companyInfoService;
        _subscriptionService = subscriptionService;
        _tenantContext = tenantContext;
    }

    [HttpPost("lifts/{id}/report")]
    public async Task<IActionResult> GenerateReport(Guid id)
    {
        var lift = await _liftRepo.GetLiftWithDetailsAsync(id);
        if (lift == null) return NotFound();

        var project = await _projectRepo.GetByIdAsync(lift.ProjectId);
        if (project == null) return NotFound();

        var tenantId = _tenantContext.TenantId;

        // Enforce export limit
        await _subscriptionService.EnforceExportLimitAsync(tenantId);

        var companyInfo = await _companyInfoService.GetOrCreateAsync(tenantId);

        var pdfBytes = await _pdfService.GenerateCalculationReportAsync(lift, companyInfo, project);

        // Increment export count
        await _subscriptionService.IncrementExportCountAsync(tenantId);

        return File(pdfBytes, "application/pdf", $"rapor-{lift.LiftNumber}-{DateTime.UtcNow:yyyyMMdd}.pdf");
    }
}
