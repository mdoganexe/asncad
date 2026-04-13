using AscadWeb.Core.DTOs;
using AscadWeb.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AscadWeb.Api.Controllers;

[ApiController]
[Route("api/catalog")]
[Authorize]
public class ProductCatalogController : ControllerBase
{
    private readonly IProductCatalogService _service;
    private readonly ITenantContext _tenantContext;

    public ProductCatalogController(IProductCatalogService service, ITenantContext tenantContext)
    {
        _service = service;
        _tenantContext = tenantContext;
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] string? category, [FromQuery] string? modelName)
    {
        var items = await _service.SearchAsync(category, modelName, _tenantContext.TenantId);
        var response = items.Select(i => new CatalogItemResponse(
            i.Id, i.Category, i.ModelName, i.Description, i.SpecsJson));
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var item = await _service.GetByIdAsync(id, _tenantContext.TenantId);
        if (item is null)
            return NotFound(new { error = new { code = "NOT_FOUND", message = "Catalog item not found." } });

        return Ok(new CatalogItemResponse(
            item.Id, item.Category, item.ModelName, item.Description, item.SpecsJson));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCatalogItemRequest request)
    {
        try
        {
            var item = await _service.CreateAsync(request, _tenantContext.TenantId);
            var response = new CatalogItemResponse(
                item.Id, item.Category, item.ModelName, item.Description, item.SpecsJson);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = new { code = "VALIDATION_ERROR", message = ex.Message } });
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateCatalogItemRequest request)
    {
        try
        {
            var item = await _service.UpdateAsync(id, request, _tenantContext.TenantId);
            return Ok(new CatalogItemResponse(
                item.Id, item.Category, item.ModelName, item.Description, item.SpecsJson));
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new { error = new { code = "NOT_FOUND", message = "Catalog item not found." } });
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _service.DeleteAsync(id, _tenantContext.TenantId);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new { error = new { code = "NOT_FOUND", message = "Catalog item not found." } });
        }
        catch (InvalidOperationException)
        {
            return Conflict(new { error = new { code = "COMPONENT_IN_USE", message = "Component is in use by an existing lift configuration." } });
        }
    }

    [HttpGet("rails")]
    public async Task<IActionResult> GetRails()
    {
        var items = await _service.GetByCategoryAsync("ray", _tenantContext.TenantId);
        var response = items.Select(i => new CatalogItemResponse(
            i.Id, i.Category, i.ModelName, i.Description, i.SpecsJson));
        return Ok(response);
    }
}
