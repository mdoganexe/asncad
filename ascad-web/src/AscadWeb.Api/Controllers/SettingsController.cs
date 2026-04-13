using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AscadWeb.Api.Controllers;

[ApiController]
[Route("api/settings")]
[Authorize]
public class SettingsController : ControllerBase
{
    private readonly ISettingsService _service;
    private readonly ITenantContext _tenantContext;

    public SettingsController(ISettingsService service, ITenantContext tenantContext)
    {
        _service = service;
        _tenantContext = tenantContext;
    }

    [HttpGet]
    public async Task<ActionResult<TenantSettings>> Get()
    {
        var settings = await _service.GetSettingsAsync(_tenantContext.TenantId);
        return Ok(settings);
    }

    [HttpPut]
    public async Task<ActionResult<TenantSettings>> Update(UpdateSettingsRequest request)
    {
        var settings = await _service.UpdateSettingsAsync(_tenantContext.TenantId, request);
        return Ok(settings);
    }
}
