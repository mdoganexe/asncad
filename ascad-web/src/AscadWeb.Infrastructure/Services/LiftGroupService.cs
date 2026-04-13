using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using AscadWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AscadWeb.Infrastructure.Services;

public class LiftGroupService : ILiftGroupService
{
    private readonly AscadDbContext _db;

    public LiftGroupService(AscadDbContext db)
    {
        _db = db;
    }

    public async Task<int> CalculateGroupShaftWidth(Guid projectId, string groupId, int partitionWallThickness)
    {
        var lifts = await GetGroupLiftsAsync(projectId, groupId);
        if (lifts.Count == 0) return 0;

        var totalWidth = lifts.Sum(l => l.KuyuGenisligi);
        totalWidth += (lifts.Count - 1) * partitionWallThickness;
        return totalWidth;
    }

    public async Task<List<Lift>> GetGroupLiftsAsync(Guid projectId, string groupId)
    {
        return await _db.Lifts
            .Where(l => l.ProjectId == projectId && l.GroupId == groupId)
            .OrderBy(l => l.GroupPosition)
            .ToListAsync();
    }
}
