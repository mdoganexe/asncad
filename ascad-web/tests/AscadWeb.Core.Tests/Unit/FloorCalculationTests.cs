using AscadWeb.Core.Entities;
using AscadWeb.Core.Services;

namespace AscadWeb.Core.Tests.Unit;

public class FloorCalculationTests
{
    private readonly FloorCalculationService _svc = new();

    // --- Architectural Levels ---

    [Fact]
    public void CalculateArchitecturalLevels_GroundFloorIsZero()
    {
        var floors = new List<FloorInfo>
        {
            new() { KatNo = 0, KatYuksekligi = 0 },
            new() { KatNo = 1, KatYuksekligi = 3000 },
            new() { KatNo = 2, KatYuksekligi = 3000 }
        };

        var result = _svc.CalculateArchitecturalLevels(floors);
        var ground = result.First(f => f.KatNo == 0);
        Assert.Equal("0.00", ground.MimariKot);
    }

    [Fact]
    public void CalculateArchitecturalLevels_FloorsAboveGround_AccumulateUpward()
    {
        var floors = new List<FloorInfo>
        {
            new() { KatNo = 0, KatYuksekligi = 0 },
            new() { KatNo = 1, KatYuksekligi = 3000 },
            new() { KatNo = 2, KatYuksekligi = 3500 }
        };

        var result = _svc.CalculateArchitecturalLevels(floors);
        var floor1 = result.First(f => f.KatNo == 1);
        var floor2 = result.First(f => f.KatNo == 2);

        Assert.Equal("3.00", floor1.MimariKot);
        Assert.Equal("6.50", floor2.MimariKot);
    }

    [Fact]
    public void CalculateArchitecturalLevels_NegativeFloors_AccumulateDownward()
    {
        var floors = new List<FloorInfo>
        {
            new() { KatNo = -1, KatYuksekligi = 2800 },
            new() { KatNo = 0, KatYuksekligi = 0 },
            new() { KatNo = 1, KatYuksekligi = 3000 }
        };

        var result = _svc.CalculateArchitecturalLevels(floors);
        var ground = result.First(f => f.KatNo == 0);
        var basement = result.First(f => f.KatNo == -1);

        // Ground should be 0.00
        Assert.Equal("0.00", ground.MimariKot);
        // Basement should have a mimari kot value set (non-empty)
        Assert.False(string.IsNullOrEmpty(basement.MimariKot));
        // Basement level should differ from ground
        Assert.NotEqual("0.00", basement.MimariKot);
    }

    [Fact]
    public void CalculateArchitecturalLevels_EmptyList_ReturnsEmpty()
    {
        var result = _svc.CalculateArchitecturalLevels(new List<FloorInfo>());
        Assert.Empty(result);
    }

    // --- Travel Distance ---

    [Fact]
    public void CalculateTravelDistance_ReturnsCorrectValue()
    {
        var floors = new List<FloorInfo>
        {
            new() { KatNo = 0, MimariKot = "0.00" },
            new() { KatNo = 1, MimariKot = "3.00" },
            new() { KatNo = 2, MimariKot = "6.00" }
        };

        var distance = _svc.CalculateTravelDistance(floors);
        Assert.Equal(6000, distance); // 6.00m = 6000mm
    }

    [Fact]
    public void CalculateTravelDistance_WithBasement()
    {
        var floors = new List<FloorInfo>
        {
            new() { KatNo = -1, MimariKot = "-3.00" },
            new() { KatNo = 0, MimariKot = "0.00" },
            new() { KatNo = 1, MimariKot = "3.00" }
        };

        var distance = _svc.CalculateTravelDistance(floors);
        Assert.Equal(6000, distance); // from -3.00 to +3.00 = 6000mm
    }

    [Fact]
    public void CalculateTravelDistance_SingleFloor_ReturnsZero()
    {
        var floors = new List<FloorInfo> { new() { KatNo = 0, MimariKot = "0.00" } };
        Assert.Equal(0, _svc.CalculateTravelDistance(floors));
    }

    // --- Pit Depth ---

    [Fact]
    public void CalculatePitDepth_LightLoad_Min1200()
    {
        var floors = new List<FloorInfo> { new() { KatNo = 0, MimariKot = "0.00" } };
        var pit = _svc.CalculatePitDepth(floors, 450); // 450kg ≤ 600
        Assert.True(pit >= 1200);
    }

    [Fact]
    public void CalculatePitDepth_HeavyLoad_Min1500()
    {
        var floors = new List<FloorInfo> { new() { KatNo = 0, MimariKot = "0.00" } };
        var pit = _svc.CalculatePitDepth(floors, 1000); // 1000kg > 600
        Assert.True(pit >= 1500);
    }

    // --- Overhead Clearance ---

    [Fact]
    public void CalculateOverheadClearance_Minimum3600()
    {
        var floors = new List<FloorInfo> { new() { KatNo = 0, MimariKot = "0.00" } };
        var overhead = _svc.CalculateOverheadClearance(floors, 0);
        Assert.True(overhead >= 3600);
    }
}
