using AscadWeb.Core.DTOs;
using AscadWeb.Core.Services;

namespace AscadWeb.Core.Tests.Unit;

public class BuildingTemplateTests
{
    private readonly BuildingTemplateService _svc = new();

    [Fact]
    public void GetAvailableBuildingTypes_Returns7Types()
    {
        var types = _svc.GetAvailableBuildingTypes();
        Assert.Equal(7, types.Count);
        Assert.Contains("Konut", types);
        Assert.Contains("Otel", types);
        Assert.Contains("Hastane", types);
        Assert.Contains("Okul", types);
        Assert.Contains("İş Merkezi", types);
        Assert.Contains("Otopark", types);
        Assert.Contains("Resmi", types);
    }

    // --- Konut occupant calculation ---

    [Fact]
    public void ApplyTemplate_Konut_CalculatesOccupantsCorrectly()
    {
        var request = new BuildingTemplateRequest("Konut", new Dictionary<string, int>
        {
            ["1+1"] = 10, ["2+1"] = 20, ["3+1"] = 5, ["4+1"] = 0, ["5+1"] = 0
        });

        var result = _svc.ApplyTemplate(request);

        // 10*2 + 20*3 + 5*4 + 0 + 0 = 20 + 60 + 20 = 100
        Assert.Equal(100, result.OccupantCount);
        Assert.Equal("Konut", result.BuildingType);
    }

    [Fact]
    public void ApplyTemplate_Konut_AllTypes()
    {
        var request = new BuildingTemplateRequest("Konut", new Dictionary<string, int>
        {
            ["1+1"] = 5, ["2+1"] = 10, ["3+1"] = 8, ["4+1"] = 3, ["5+1"] = 2
        });

        var result = _svc.ApplyTemplate(request);
        // 5*2 + 10*3 + 8*4 + 3*5 + 2*6 = 10 + 30 + 32 + 15 + 12 = 99
        Assert.Equal(99, result.OccupantCount);
    }

    // --- Otel ---

    [Fact]
    public void ApplyTemplate_Otel_UseBedCountDirectly()
    {
        var result = _svc.ApplyTemplate(new BuildingTemplateRequest("Otel",
            new Dictionary<string, int> { ["bedCount"] = 150 }));

        Assert.Equal(150, result.OccupantCount);
    }

    // --- Hastane ---

    [Fact]
    public void ApplyTemplate_Hastane_MultipliesBedCountBy3()
    {
        var result = _svc.ApplyTemplate(new BuildingTemplateRequest("Hastane",
            new Dictionary<string, int> { ["bedCount"] = 100 }));

        Assert.Equal(300, result.OccupantCount);
    }

    // --- Capacity review flag ---

    [Fact]
    public void ApplyTemplate_Konut_Under200_NoReview()
    {
        var result = _svc.ApplyTemplate(new BuildingTemplateRequest("Konut",
            new Dictionary<string, int> { ["1+1"] = 50 })); // 50*2 = 100

        Assert.False(result.RequiresAdditionalCapacityReview);
    }

    [Fact]
    public void ApplyTemplate_Konut_Exactly200_RequiresReview()
    {
        var result = _svc.ApplyTemplate(new BuildingTemplateRequest("Konut",
            new Dictionary<string, int> { ["1+1"] = 100 })); // 100*2 = 200

        Assert.True(result.RequiresAdditionalCapacityReview);
    }

    [Fact]
    public void ApplyTemplate_Konut_Over200_RequiresReview()
    {
        var result = _svc.ApplyTemplate(new BuildingTemplateRequest("Konut",
            new Dictionary<string, int> { ["2+1"] = 100 })); // 100*3 = 300

        Assert.True(result.RequiresAdditionalCapacityReview);
    }

    [Fact]
    public void ApplyTemplate_Otel_Over200_NoReviewFlag()
    {
        // Review flag only applies to Konut
        var result = _svc.ApplyTemplate(new BuildingTemplateRequest("Otel",
            new Dictionary<string, int> { ["bedCount"] = 500 }));

        Assert.False(result.RequiresAdditionalCapacityReview);
    }

    // --- Recommendations ---

    [Fact]
    public void ApplyTemplate_ReturnsPositiveRecommendations()
    {
        var result = _svc.ApplyTemplate(new BuildingTemplateRequest("Konut",
            new Dictionary<string, int> { ["2+1"] = 30 })); // 90 occupants

        Assert.True(result.RecommendedMinLoadCapacity > 0);
        Assert.True(result.RecommendedMinCabinWidth > 0);
        Assert.True(result.RecommendedMinCabinDepth > 0);
        Assert.True(result.RecommendedElevatorCount >= 1);
    }
}
