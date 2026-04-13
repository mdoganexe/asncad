using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Interfaces;

public interface ILiftGroupService
{
    Task<int> CalculateGroupShaftWidth(Guid projectId, string groupId, int partitionWallThickness);
    Task<List<Lift>> GetGroupLiftsAsync(Guid projectId, string groupId);
}
