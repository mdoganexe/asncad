using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Interfaces;

public interface IDrawingGeneratorService
{
    string GenerateShaftCrossSection(Lift lift);
    string GenerateLongitudinalSection(Lift lift);
    string GenerateMachineRoomLayout(Lift lift);
    string GenerateCabinPlan(Lift lift);
    string GenerateGroupCrossSection(List<Lift> lifts, int partitionWallThickness);
    byte[] ExportToDxf(string svgContent, string drawingType);
}
