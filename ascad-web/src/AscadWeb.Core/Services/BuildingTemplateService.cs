using AscadWeb.Core.DTOs;
using AscadWeb.Core.Interfaces;
using AscadWeb.Core.Models;

namespace AscadWeb.Core.Services;

public class BuildingTemplateService : IBuildingTemplateService
{
    private static readonly List<string> BuildingTypes = new()
    {
        "Konut", "Otel", "Hastane", "Okul", "İş Merkezi", "Otopark", "Resmi"
    };

    public List<string> GetAvailableBuildingTypes() => BuildingTypes;

    public BuildingTemplateResult ApplyTemplate(BuildingTemplateRequest request)
    {
        int occupant = CalculateOccupantCount(request.BuildingType, request.Parameters);

        int minLoadCapacity = GetMinLoadCapacity(occupant);
        int recommendedElevatorCount = Math.Max(1, occupant / 100);
        var (minWidth, minDepth) = GetMinCabinDimensions(minLoadCapacity);

        return new BuildingTemplateResult
        {
            BuildingType = request.BuildingType,
            OccupantCount = occupant,
            RecommendedMinLoadCapacity = minLoadCapacity,
            RecommendedElevatorCount = recommendedElevatorCount,
            RecommendedMinCabinWidth = minWidth,
            RecommendedMinCabinDepth = minDepth,
            RequiresAdditionalCapacityReview = request.BuildingType == "Konut" && occupant >= 200
        };
    }

    private static int CalculateOccupantCount(string buildingType, Dictionary<string, int> parameters)
    {
        return buildingType switch
        {
            "Konut" => CalculateResidentialOccupants(parameters),
            "Otel" => parameters.GetValueOrDefault("bedCount", 0),
            "Hastane" => parameters.GetValueOrDefault("bedCount", 0) * 3,
            _ => parameters.Values.Sum() // Okul, İş Merkezi, Otopark, Resmi
        };
    }

    private static int CalculateResidentialOccupants(Dictionary<string, int> parameters)
    {
        int total = 0;
        total += parameters.GetValueOrDefault("1+1", 0) * 2;
        total += parameters.GetValueOrDefault("2+1", 0) * 3;
        total += parameters.GetValueOrDefault("3+1", 0) * 4;
        total += parameters.GetValueOrDefault("4+1", 0) * 5;
        total += parameters.GetValueOrDefault("5+1", 0) * 6;
        return total;
    }

    private static int GetMinLoadCapacity(int occupantCount)
    {
        return occupantCount switch
        {
            <= 50 => 320,
            <= 100 => 450,
            <= 200 => 630,
            <= 400 => 1000,
            _ => 1600
        };
    }

    private static (int Width, int Depth) GetMinCabinDimensions(int loadCapacity)
    {
        return loadCapacity switch
        {
            <= 320 => (900, 1000),
            <= 450 => (1000, 1250),
            <= 630 => (1100, 1400),
            <= 1000 => (1350, 1600),
            _ => (1500, 1800)
        };
    }
}
