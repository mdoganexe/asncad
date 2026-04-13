using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Interfaces;

public interface IDynamicCalculationService
{
    Task<List<CalculationResult>> ExecuteCalculationsAsync(Lift lift, Guid tenantId);
}
