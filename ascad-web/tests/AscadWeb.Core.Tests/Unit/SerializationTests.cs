using System.Text.Json;
using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Tests.Unit;

public class SerializationTests
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    // --- CalculationResult round-trip (Property 21) ---

    [Fact]
    public void CalculationResult_SerializationRoundTrip()
    {
        var original = new CalculationResult
        {
            Id = Guid.NewGuid(),
            LiftId = Guid.NewGuid(),
            Sira = 5,
            Parametre = "KabinGen",
            Standart = "GENELFRM",
            Aciklama = "Kabin Genişliği",
            Formul = "KuyuGen-600",
            FormulDeger = "2000-600",
            FormulSonuc = "1400",
            Birim = "mm",
            VeriTipi = "d"
        };

        var json = JsonSerializer.Serialize(original, Options);
        var deserialized = JsonSerializer.Deserialize<CalculationResult>(json, Options)!;

        Assert.Equal(original.Sira, deserialized.Sira);
        Assert.Equal(original.Parametre, deserialized.Parametre);
        Assert.Equal(original.Standart, deserialized.Standart);
        Assert.Equal(original.Aciklama, deserialized.Aciklama);
        Assert.Equal(original.Formul, deserialized.Formul);
        Assert.Equal(original.FormulDeger, deserialized.FormulDeger);
        Assert.Equal(original.FormulSonuc, deserialized.FormulSonuc);
        Assert.Equal(original.Birim, deserialized.Birim);
        Assert.Equal(original.VeriTipi, deserialized.VeriTipi);
    }

    // --- CalculationSummary round-trip (Property 22) ---

    [Fact]
    public void CalculationSummaryDto_SerializationRoundTrip()
    {
        var original = new CalculationSummaryDto(
            Guid.NewGuid(), 3, 2, 1,
            new List<CalculationResultDto>
            {
                new(1, "KabinGen", "GENELFRM", "Kabin Genişliği", "KuyuGen-600", "2000-600", "1400", "mm"),
                new(2, "BeyanYuk", "GENEL", "Beyan Yükü", "", "", "600", "kg"),
                new(3, "KuyuDibiKontrol", "SORG", "Kuyu Dibi Kontrolü", "KuyuDibi>=1200", "1500>=1200", "UY", "")
            }
        );

        var json = JsonSerializer.Serialize(original, Options);
        var deserialized = JsonSerializer.Deserialize<CalculationSummaryDto>(json, Options)!;

        Assert.Equal(original.LiftId, deserialized.LiftId);
        Assert.Equal(original.TotalChecks, deserialized.TotalChecks);
        Assert.Equal(original.PassedChecks, deserialized.PassedChecks);
        Assert.Equal(original.FailedChecks, deserialized.FailedChecks);
        Assert.Equal(original.Results.Count, deserialized.Results.Count);

        for (int i = 0; i < original.Results.Count; i++)
        {
            Assert.Equal(original.Results[i].Sira, deserialized.Results[i].Sira);
            Assert.Equal(original.Results[i].Parametre, deserialized.Results[i].Parametre);
            Assert.Equal(original.Results[i].FormulSonuc, deserialized.Results[i].FormulSonuc);
        }
    }

    // --- FloorInfo round-trip (Property 23) ---

    [Fact]
    public void FloorInfoDto_ListSerializationRoundTrip()
    {
        var original = new List<FloorInfoDto>
        {
            new(-1, "B1", 2800, "-2.80"),
            new(0, "Z", 0, "0.00"),
            new(1, "1", 3000, "3.00"),
            new(2, "2", 3000, "6.00")
        };

        var json = JsonSerializer.Serialize(original, Options);
        var deserialized = JsonSerializer.Deserialize<List<FloorInfoDto>>(json, Options)!;

        Assert.Equal(original.Count, deserialized.Count);
        for (int i = 0; i < original.Count; i++)
        {
            Assert.Equal(original[i].KatNo, deserialized[i].KatNo);
            Assert.Equal(original[i].KatRumuz, deserialized[i].KatRumuz);
            Assert.Equal(original[i].KatYuksekligi, deserialized[i].KatYuksekligi);
            Assert.Equal(original[i].MimariKot, deserialized[i].MimariKot);
        }
    }

    // --- LiftResponse round-trip ---

    [Fact]
    public void LiftResponse_SerializationRoundTrip()
    {
        var original = new LiftResponse(
            Guid.NewGuid(), Guid.NewGuid(), 1, "EA", "DA", "SOL",
            2000, 2500, 1500, 3600, 1400, 2050, 900, "KK-OT",
            600, 8, 5, "70x65x9", "50x50x5", false,
            new List<FloorInfoDto> { new(0, "Z", 0, "0.00"), new(1, "1", 3000, "3.00") },
            DateTime.UtcNow, null, null
        );

        var json = JsonSerializer.Serialize(original, Options);
        var deserialized = JsonSerializer.Deserialize<LiftResponse>(json, Options)!;

        Assert.Equal(original.Id, deserialized.Id);
        Assert.Equal(original.LiftNumber, deserialized.LiftNumber);
        Assert.Equal(original.BeyanYuk, deserialized.BeyanYuk);
        Assert.Equal(original.Floors.Count, deserialized.Floors.Count);
    }
}
