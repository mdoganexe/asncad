using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Interfaces;

public interface IProjectRepository : IRepository<Project>
{
    Task<IReadOnlyList<Project>> GetProjectsByTenantAsync(Guid tenantId);
    Task<Project?> GetProjectWithLiftsAsync(Guid projectId);
}
