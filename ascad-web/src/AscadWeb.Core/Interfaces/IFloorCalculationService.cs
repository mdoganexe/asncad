using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Interfaces;

public interface IFloorCalculationService
{
    List<FloorInfo> CalculateArchitecturalLevels(List<FloorInfo> floors);
    int CalculateTravelDistance(List<FloorInfo> floors);
    int CalculatePitDepth(List<FloorInfo> floors, int beyanYuk);
    int CalculateOverheadClearance(List<FloorInfo> floors, int machineRoomHeight);
}
