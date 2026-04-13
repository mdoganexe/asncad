using AscadWeb.Core.Entities;
using AscadWeb.Core.Enums;
using AscadWeb.Core.Services;

namespace AscadWeb.Core.Tests.Unit;

public class DrawingGeneratorTests
{
    private readonly DrawingGeneratorService _svc = new();

    private static Lift CreateTestLift() => new()
    {
        KuyuGenisligi = 2000, KuyuDerinligi = 2500,
        KabinGenisligi = 1400, KabinDerinligi = 2050,
        KapiGenisligi = 900, YonKodu = YonKodu.SOL,
        Floors = new List<FloorInfo>
        {
            new() { KatNo = 0, KatYuksekligi = 0, MimariKot = "0.00" },
            new() { KatNo = 1, KatYuksekligi = 3000, MimariKot = "3.00" },
            new() { KatNo = 2, KatYuksekligi = 3000, MimariKot = "6.00" }
        }
    };

    // --- Cross Section ---

    [Fact]
    public void GenerateShaftCrossSection_ContainsSvgElement()
    {
        var svg = _svc.GenerateShaftCrossSection(CreateTestLift());
        Assert.Contains("<svg", svg);
        Assert.Contains("</svg>", svg);
    }

    [Fact]
    public void GenerateShaftCrossSection_ContainsShaftDimensions()
    {
        var lift = CreateTestLift();
        var svg = _svc.GenerateShaftCrossSection(lift);
        Assert.Contains("2000 mm", svg);
        Assert.Contains("2500 mm", svg);
    }

    [Fact]
    public void GenerateShaftCrossSection_ContainsCounterweightLabel()
    {
        var svg = _svc.GenerateShaftCrossSection(CreateTestLift());
        Assert.Contains("CW", svg);
    }

    // --- Longitudinal Section ---

    [Fact]
    public void GenerateLongitudinalSection_ContainsFloorLabels()
    {
        var svg = _svc.GenerateLongitudinalSection(CreateTestLift());
        Assert.Contains("Kat 0", svg);
        Assert.Contains("Kat 1", svg);
    }

    [Fact]
    public void GenerateLongitudinalSection_ContainsPitDepthLabel()
    {
        var lift = CreateTestLift();
        lift.KuyuDibi = 1500;
        var svg = _svc.GenerateLongitudinalSection(lift);
        Assert.Contains("Kuyu Dibi", svg);
    }

    // --- Machine Room ---

    [Fact]
    public void GenerateMachineRoomLayout_ContainsMotorLabel()
    {
        var svg = _svc.GenerateMachineRoomLayout(CreateTestLift());
        Assert.Contains("Motor", svg);
    }

    // --- Cabin Plan ---

    [Fact]
    public void GenerateCabinPlan_ContainsDoorLabel()
    {
        var svg = _svc.GenerateCabinPlan(CreateTestLift());
        Assert.Contains("Kapı", svg);
    }

    // --- Group Cross Section ---

    [Fact]
    public void GenerateGroupCrossSection_MultipleLifts_ContainsTotalWidth()
    {
        var lifts = new List<Lift>
        {
            new() { KuyuGenisligi = 2000, KuyuDerinligi = 2500, GroupPosition = 1 },
            new() { KuyuGenisligi = 2000, KuyuDerinligi = 2500, GroupPosition = 2 }
        };

        var svg = _svc.GenerateGroupCrossSection(lifts, 200);
        // Total = 2000 + 2000 + 200 = 4200
        Assert.Contains("4200 mm", svg);
    }

    [Fact]
    public void GenerateGroupCrossSection_EmptyList_ReturnsEmptySvg()
    {
        var svg = _svc.GenerateGroupCrossSection(new List<Lift>(), 200);
        Assert.Contains("<svg", svg);
    }

    // --- DXF Export ---

    [Fact]
    public void ExportToDxf_ReturnsNonEmptyBytes()
    {
        var svg = _svc.GenerateShaftCrossSection(CreateTestLift());
        var dxf = _svc.ExportToDxf(svg, "cross-section");
        Assert.NotEmpty(dxf);
    }

    [Fact]
    public void ExportToDxf_ContainsDxfStructure()
    {
        var svg = _svc.GenerateShaftCrossSection(CreateTestLift());
        var dxf = _svc.ExportToDxf(svg, "cross-section");
        var content = System.Text.Encoding.UTF8.GetString(dxf);
        Assert.Contains("SECTION", content);
        Assert.Contains("ENTITIES", content);
        Assert.Contains("EOF", content);
    }
}
