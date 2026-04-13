using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using AscadWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AscadWeb.Infrastructure.Repositories;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    public ProjectRepository(AscadDbContext context) : base(context) { }

    public async Task<IReadOnlyList<Project>> GetProjectsByTenantAsync(Guid tenantId)
        => await _dbSet
            .Where(p => p.TenantId == tenantId)
            .Include(p => p.Lifts)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();

    public async Task<Project?> GetProjectWithLiftsAsync(Guid projectId)
        => await _dbSet
            .Include(p => p.Lifts)
                .ThenInclude(l => l.Floors)
            .FirstOrDefaultAsync(p => p.Id == projectId);
}
