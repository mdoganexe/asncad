using AscadWeb.Core.DTOs;
using AscadWeb.Core.Interfaces;
using AscadWeb.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AscadWeb.Api.Controllers;

[ApiController]
[Route("api/building-templates")]
[Authorize]
public class BuildingTemplatesController : ControllerBase
{
    private readonly IBuildingTemplateService _service;

    public BuildingTemplatesController(IBuildingTemplateService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<string>> GetAvailableBuildingTypes()
    {
        return Ok(_service.GetAvailableBuildingTypes());
    }

    [HttpPost("apply")]
    public ActionResult<BuildingTemplateResult> ApplyTemplate(BuildingTemplateRequest request)
    {
        try
        {
            var result = _service.ApplyTemplate(request);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new
            {
                error = new
                {
                    code = "TEMPLATE_INVALID",
                    message = ex.Message
                }
            });
        }
    }
}
