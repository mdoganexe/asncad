using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AscadWeb.Api.Controllers;

[ApiController]
[Route("api/lifts")]
[Authorize]
public class FloorsController : ControllerBase
{
    private readonly ILiftRepository _liftRepo;
    private readonly IFloorCalculationService _floorCalcService;

    public FloorsController(ILiftRepository liftRepo, IFloorCalculationService floorCalcService)
    {
        _liftRepo = liftRepo;
        _floorCalcService = floorCalcService;
    }

    [HttpPut("{id}/floors")]
    public async Task<ActionResult<FloorCalculationResponse>> UpdateFloors(Guid id, UpdateFloorsRequest request)
    {
        var lift = await _liftRepo.GetLiftWithDetailsAsync(id);
        if (lift == null)
            return NotFound();

        // Replace existing floors
        lift.Floors.Clear();
        foreach (var f in request.Floors)
        {
            lift.Floors.Add(new FloorInfo
            {
                LiftId = lift.Id,
                KatNo = f.KatNo,
                KatRumuz = f.KatRumuz,
                KatYuksekligi = f.KatYuksekligi,
                MimariKot = f.MimariKot
            });
        }

        // Run auto-calculations
        var floorList = lift.Floors.ToList();
        var calculatedFloors = _floorCalcService.CalculateArchitecturalLevels(floorList);
        int travelDistance = _floorCalcService.CalculateTravelDistance(calculatedFloors);
        int pitDepth = _floorCalcService.CalculatePitDepth(calculatedFloors, lift.BeyanYuk);
        int overheadClearance = _floorCalcService.CalculateOverheadClearance(calculatedFloors, lift.KuyuKafa);

        // Update lift floors with calculated values
        lift.Floors = calculatedFloors;
        lift.UpdatedAt = DateTime.UtcNow;
        await _liftRepo.UpdateAsync(lift);

        var floorDtos = calculatedFloors
            .Select(f => new FloorInfoDto(f.KatNo, f.KatRumuz, f.KatYuksekligi, f.MimariKot))
            .ToList();

        return Ok(new FloorCalculationResponse(floorDtos, travelDistance, pitDepth, overheadClearance));
    }
}
