namespace AscadWeb.Core.Models;

public class BuildingTemplateResult
{
    public string BuildingType { get; set; } = string.Empty;
    public int OccupantCount { get; set; }
    public int RecommendedMinCabinWidth { get; set; }
    public int RecommendedMinCabinDepth { get; set; }
    public int RecommendedMinLoadCapacity { get; set; }
    public int RecommendedElevatorCount { get; set; }
    public bool RequiresAdditionalCapacityReview { get; set; }
}
