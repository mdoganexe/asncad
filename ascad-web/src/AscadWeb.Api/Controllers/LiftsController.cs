using System.Security.Claims;
using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AscadWeb.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LiftsController : ControllerBase
{
    private readonly ILiftRepository _liftRepo;
    private readonly IProjectRepository _projectRepo;
    private readonly ICalculationService _calcService;

    public LiftsController(ILiftRepository liftRepo, IProjectRepository projectRepo,
        ICalculationService calcService)
    {
        _liftRepo = liftRepo;
        _projectRepo = projectRepo;
        _calcService = calcService;
    }

    private Guid GetTenantId() => Guid.Parse(User.FindFirstValue("TenantId")!);

    [HttpGet("project/{projectId}")]
    public async Task<ActionResult<List<LiftResponse>>> GetByProject(Guid projectId)
    {
        var lifts = await _liftRepo.GetLiftsByProjectAsync(projectId);
        return Ok(lifts.Select(MapToResponse).ToList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LiftResponse>> Get(Guid id)
    {
        var lift = await _liftRepo.GetLiftWithDetailsAsync(id);
        if (lift == null) return NotFound();
        return Ok(MapToResponse(lift));
    }

    [HttpPost]
    public async Task<ActionResult<LiftResponse>> Create(CreateLiftRequest request)
    {
        var project = await _projectRepo.GetByIdAsync(request.ProjectId);
        if (project == null || project.TenantId != GetTenantId())
            return NotFound("Proje bulunamadı.");

        var lift = new Lift
        {
            ProjectId = request.ProjectId,
            LiftNumber = (await _liftRepo.GetLiftsByProjectAsync(request.ProjectId)).Count + 1,
            AsansorTipiKodu = request.AsansorTipi,
            TahrikKodu = request.TahrikKodu,
            YonKodu = request.YonKodu,
            KuyuGenisligi = request.KuyuGenisligi,
            KuyuDerinligi = request.KuyuDerinligi,
            KuyuDibi = request.KuyuDibi,
            KapiGenisligi = request.KapiGenisligi,
            KapiTipi = request.KapiTipi,
            DurakSayisi = request.DurakSayisi,
            IlkDurakNo = request.IlkDurakNo,
            KatYuksekligi = request.KatYuksekligi,
            KabinRayStr = request.KabinRayStr,
            AgrRayStr = request.AgrRayStr,
            Panoramik = request.Panoramik,
            GroupId = request.GroupId,
            GroupPosition = request.GroupPosition
        };

        // Kabin boyutlarını hesapla
        var (kabinGen, kabinDer) = _calcService.CalculateKabinBoyutlari(lift);
        lift.KabinGenisligi = kabinGen;
        lift.KabinDerinligi = kabinDer;

        // Beyan yük hesapla
        var (beyanYuk, beyanKisi) = _calcService.CalculateBeyanYuk(kabinGen, kabinDer);
        lift.BeyanYuk = beyanYuk;
        lift.BeyanKisi = beyanKisi;

        // Kat bilgilerini ekle
        if (request.Floors != null)
        {
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
        }

        await _liftRepo.AddAsync(lift);
        return CreatedAtAction(nameof(Get), new { id = lift.Id }, MapToResponse(lift));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var lift = await _liftRepo.GetByIdAsync(id);
        if (lift == null) return NotFound();
        await _liftRepo.DeleteAsync(lift);
        return NoContent();
    }

    private static LiftResponse MapToResponse(Lift l) => new(
        l.Id, l.ProjectId, l.LiftNumber,
        l.AsansorTipiKodu.ToString(), l.TahrikKodu.ToString(), l.YonKodu.ToString(),
        l.KuyuGenisligi, l.KuyuDerinligi, l.KuyuDibi, l.KuyuKafa,
        l.KabinGenisligi, l.KabinDerinligi, l.KapiGenisligi, l.KapiTipi,
        l.BeyanYuk, l.BeyanKisi, l.DurakSayisi,
        l.KabinRayStr, l.AgrRayStr, l.Panoramik,
        l.Floors.Select(f => new FloorInfoDto(f.KatNo, f.KatRumuz, f.KatYuksekligi, f.MimariKot)).ToList(),
        l.CreatedAt,
        l.GroupId,
        l.GroupPosition
    );
}
