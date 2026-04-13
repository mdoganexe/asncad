using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using AscadWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AscadWeb.Infrastructure.Repositories;

public class LiftRepository : Repository<Lift>, ILiftRepository
{
    public LiftRepository(AscadDbContext context) : base(context) { }

    public async Task<Lift?> GetLiftWithDetailsAsync(Guid liftId)
        => await _dbSet
            .Include(l => l.Floors)
            .Include(l => l.CalculationResults)
            .FirstOrDefaultAsync(l => l.Id == liftId);

    public async Task<IReadOnlyList<Lift>> GetLiftsByProjectAsync(Guid projectId)
        => await _dbSet
            .Where(l => l.ProjectId == projectId)
            .Include(l => l.Floors)
            .OrderBy(l => l.LiftNumber)
            .ToListAsync();
}
