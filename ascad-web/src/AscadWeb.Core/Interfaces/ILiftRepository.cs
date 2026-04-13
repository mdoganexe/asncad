using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Interfaces;

public interface ILiftRepository : IRepository<Lift>
{
    Task<Lift?> GetLiftWithDetailsAsync(Guid liftId);
    Task<IReadOnlyList<Lift>> GetLiftsByProjectAsync(Guid projectId);
}
