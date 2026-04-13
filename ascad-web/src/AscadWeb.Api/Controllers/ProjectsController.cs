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
public class ProjectsController : ControllerBase
{
    private readonly IProjectRepository _projectRepo;

    public ProjectsController(IProjectRepository projectRepo)
    {
        _projectRepo = projectRepo;
    }

    private Guid GetTenantId() => Guid.Parse(User.FindFirstValue("TenantId")!);
    private Guid GetUserId() => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpGet]
    public async Task<ActionResult<List<ProjectResponse>>> GetAll()
    {
        var projects = await _projectRepo.GetProjectsByTenantAsync(GetTenantId());
        return Ok(projects.Select(p => new ProjectResponse(
            p.Id, p.ProjectName, p.Description, p.Status,
            p.Lifts.Count, p.CreatedAt, p.UpdatedAt
        )).ToList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectResponse>> Get(Guid id)
    {
        var project = await _projectRepo.GetProjectWithLiftsAsync(id);
        if (project == null || project.TenantId != GetTenantId())
            return NotFound();

        return Ok(new ProjectResponse(
            project.Id, project.ProjectName, project.Description, project.Status,
            project.Lifts.Count, project.CreatedAt, project.UpdatedAt
        ));
    }

    [HttpPost]
    public async Task<ActionResult<ProjectResponse>> Create(CreateProjectRequest request)
    {
        var project = new Project
        {
            TenantId = GetTenantId(),
            UserId = GetUserId(),
            ProjectName = request.ProjectName,
            Description = request.Description
        };

        await _projectRepo.AddAsync(project);

        return CreatedAtAction(nameof(Get), new { id = project.Id },
            new ProjectResponse(project.Id, project.ProjectName, project.Description,
                project.Status, 0, project.CreatedAt, project.UpdatedAt));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var project = await _projectRepo.GetByIdAsync(id);
        if (project == null || project.TenantId != GetTenantId())
            return NotFound();

        await _projectRepo.DeleteAsync(project);
        return NoContent();
    }
}
