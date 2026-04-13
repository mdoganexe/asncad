using AscadWeb.Core.DTOs;
using AscadWeb.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AscadWeb.Api.Controllers;

[ApiController]
[Route("api")]
[Authorize]
public class CalculationsController : ControllerBase
{
    private readonly IDynamicCalculationService _dynamicCalcService;
    private readonly ILiftRepository _liftRepo;
    private readonly ITenantContext _tenantContext;

    public CalculationsController(
        IDynamicCalculationService dynamicCalcService,
        ILiftRepository liftRepo,
        ITenantContext tenantContext)
    {
        _dynamicCalcService = dynamicCalcService;
        _liftRepo = liftRepo;
        _tenantContext = tenantContext;
    }

    [HttpPost("lifts/{id}/calculate")]
    public async Task<ActionResult<CalculationSummaryDto>> Calculate(Guid id)
    {
        var lift = await _liftRepo.GetLiftWithDetailsAsync(id);
        if (lift == null) return NotFound();

        var results = await _dynamicCalcService.ExecuteCalculationsAsync(lift, _tenantContext.TenantId);

        // Clear old calculation results and add new ones
        lift.CalculationResults.Clear();
        foreach (var r in results) lift.CalculationResults.Add(r);
        await _liftRepo.UpdateAsync(lift);

        var dtos = results.Select(r => new CalculationResultDto(
            r.Sira, r.Parametre, r.Standart, r.Aciklama,
            r.Formul, r.FormulDeger, r.FormulSonuc, r.Birim
        )).ToList();

        return Ok(new CalculationSummaryDto(
            lift.Id,
            dtos.Count,
            dtos.Count(d => d.FormulSonuc != "UD"),
            dtos.Count(d => d.FormulSonuc == "UD"),
            dtos
        ));
    }
}
