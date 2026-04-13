using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using AscadWeb.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AscadWeb.Api.Controllers;

[ApiController]
[Route("api")]
[Authorize]
public class DrawingsController : ControllerBase
{
    private readonly IDrawingGeneratorService _drawingService;
    private readonly ILiftRepository _liftRepo;
    private readonly AscadDbContext _db;

    public DrawingsController(IDrawingGeneratorService drawingService, ILiftRepository liftRepo, AscadDbContext db)
    {
        _drawingService = drawingService;
        _liftRepo = liftRepo;
        _db = db;
    }

    [HttpGet("lifts/{id}/drawings/{type}")]
    public async Task<IActionResult> GetDrawing(Guid id, string type)
    {
        var lift = await _liftRepo.GetLiftWithDetailsAsync(id);
        if (lift == null) return NotFound();

        var svg = type.ToLowerInvariant() switch
        {
            "cross-section" => _drawingService.GenerateShaftCrossSection(lift),
            "longitudinal" => _drawingService.GenerateLongitudinalSection(lift),
            "machine-room" => _drawingService.GenerateMachineRoomLayout(lift),
            "cabin-plan" => _drawingService.GenerateCabinPlan(lift),
            _ => null
        };

        if (svg == null)
            return BadRequest(new { error = new { code = "VALIDATION_ERROR", message = $"Invalid drawing type: {type}. Valid types: cross-section, longitudinal, machine-room, cabin-plan" } });

        return Content(svg, "image/svg+xml");
    }

    [HttpGet("lifts/{id}/drawings/{type}/dxf")]
    public async Task<IActionResult> GetDxf(Guid id, string type)
    {
        var lift = await _liftRepo.GetLiftWithDetailsAsync(id);
        if (lift == null) return NotFound();

        var svg = type.ToLowerInvariant() switch
        {
            "cross-section" => _drawingService.GenerateShaftCrossSection(lift),
            "longitudinal" => _drawingService.GenerateLongitudinalSection(lift),
            "machine-room" => _drawingService.GenerateMachineRoomLayout(lift),
            "cabin-plan" => _drawingService.GenerateCabinPlan(lift),
            _ => null
        };

        if (svg == null)
            return BadRequest(new { error = new { code = "VALIDATION_ERROR", message = $"Invalid drawing type: {type}" } });

        var dxfBytes = _drawingService.ExportToDxf(svg, type);
        return File(dxfBytes, "application/dxf", $"{type}-{id}.dxf");
    }

    [HttpGet("lifts/{id}/drawings/group")]
    public async Task<IActionResult> GetGroupDrawing(Guid id, [FromQuery] int partitionWallThickness = 200)
    {
        var lift = await _liftRepo.GetLiftWithDetailsAsync(id);
        if (lift == null) return NotFound();

        if (string.IsNullOrEmpty(lift.GroupId))
            return BadRequest(new { error = new { code = "VALIDATION_ERROR", message = "Lift is not part of a group" } });

        var allLifts = await _liftRepo.GetLiftsByProjectAsync(lift.ProjectId);
        var groupLifts = allLifts.Where(l => l.GroupId == lift.GroupId).OrderBy(l => l.GroupPosition).ToList();

        var svg = _drawingService.GenerateGroupCrossSection(groupLifts, partitionWallThickness);
        return Content(svg, "image/svg+xml");
    }

    // =========================================================================
    // CAD Drawing JSON Persistence Endpoints
    // =========================================================================

    [HttpGet("drawings/{liftId}/{type}")]
    public async Task<IActionResult> GetCadDrawing(Guid liftId, string type)
    {
        var drawing = await _db.Drawings
            .FirstOrDefaultAsync(d => d.LiftId == liftId && d.DrawingType == type);

        if (drawing == null) return NotFound();

        return Content(drawing.JsonContent, "application/json");
    }

    [HttpPost("drawings/{liftId}/{type}")]
    public async Task<IActionResult> SaveCadDrawing(Guid liftId, string type, [FromBody] object json)
    {
        var lift = await _liftRepo.GetLiftWithDetailsAsync(liftId);
        if (lift == null) return NotFound(new { error = "Lift not found" });

        var existing = await _db.Drawings
            .FirstOrDefaultAsync(d => d.LiftId == liftId && d.DrawingType == type);

        var jsonContent = System.Text.Json.JsonSerializer.Serialize(json);

        if (existing != null)
        {
            existing.JsonContent = jsonContent;
            existing.Version++;
            existing.UpdatedAt = DateTime.UtcNow;
        }
        else
        {
            _db.Drawings.Add(new Drawing
            {
                LiftId = liftId,
                DrawingType = type,
                JsonContent = jsonContent,
                Version = 1
            });
        }

        await _db.SaveChangesAsync();
        return Ok(new { success = true });
    }
}
