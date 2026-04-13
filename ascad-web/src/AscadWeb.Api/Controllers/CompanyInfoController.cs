using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AscadWeb.Api.Controllers;

[ApiController]
[Route("api/company-info")]
[Authorize]
public class CompanyInfoController : ControllerBase
{
    private readonly ICompanyInfoService _service;
    private readonly ITenantContext _tenantContext;

    public CompanyInfoController(ICompanyInfoService service, ITenantContext tenantContext)
    {
        _service = service;
        _tenantContext = tenantContext;
    }

    [HttpGet]
    public async Task<ActionResult<CompanyInfo>> Get()
    {
        var info = await _service.GetOrCreateAsync(_tenantContext.TenantId);
        return Ok(info);
    }

    [HttpPut]
    public async Task<ActionResult<CompanyInfo>> Update(UpdateCompanyInfoRequest request)
    {
        try
        {
            var info = await _service.UpdateAsync(_tenantContext.TenantId, request);
            return Ok(info);
        }
        catch (ArgumentException ex)
        {
            // Extract field name from the exception message (format: "Field '{fieldName}' exceeds...")
            var field = ExtractFieldName(ex.Message);
            return BadRequest(new
            {
                error = new
                {
                    code = "VALIDATION_ERROR",
                    message = ex.Message,
                    field
                }
            });
        }
    }

    private static string? ExtractFieldName(string message)
    {
        var start = message.IndexOf('\'');
        if (start < 0) return null;
        var end = message.IndexOf('\'', start + 1);
        if (end < 0) return null;
        return message.Substring(start + 1, end - start - 1);
    }
}
