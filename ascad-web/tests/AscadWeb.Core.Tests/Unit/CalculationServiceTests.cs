using AscadWeb.Core.Entities;
using AscadWeb.Core.Enums;
using AscadWeb.Core.Services;

namespace AscadWeb.Core.Tests.Unit;

public class CalculationServiceTests
{
    private readonly CalculationService _svc = new();

    // --- BeyanYuk (EN81-1 Table 1.1) ---

    [Theory]
    [InlineData(900, 1000, 300, 4)]    // 0.9 m² → 300kg, 4 kişi
    [InlineData(1100, 1400, 600, 8)]   // 1.54 m² → 600kg, 8 kişi
    [InlineData(1500, 1800, 1200, 16)] // 2.7 m² → 1200kg
    [InlineData(400, 400, 0, 0)]       // 0.16 m² → too small
    public void CalculateBeyanYuk_ReturnsCorrectValues(int gen, int der, int expectedYuk, int expectedKisi)
    {
        var (yuk, kisi) = _svc.CalculateBeyanYuk(gen, der);
        Assert.Equal(expectedYuk, yuk);
        Assert.Equal(expectedKisi, kisi);
    }

    [Fact]
    public void CalculateBeyanYuk_BoundaryAt058_Returns180()
    {
        // 760 x 763 ≈ 0.58 m²
        var (yuk, _) = _svc.CalculateBeyanYuk(760, 763);
        Assert.Equal(180, yuk);
    }

    // --- Kabin Boyutları ---

    [Theory]
    [InlineData(TahrikKodu.DA, 2000, 2500, 1400, 2050)]
    [InlineData(TahrikKodu.MDDUZ, 2000, 2500, 1400, 1900)]
    [InlineData(TahrikKodu.MDCAP, 2000, 2500, 1400, 2150)]
    public void CalculateKabinBoyutlari_ByDriveType(TahrikKodu tahrik, int kuyuGen, int kuyuDer,
        int expectedGen, int expectedDer)
    {
        var lift = new Lift { KuyuGenisligi = kuyuGen, KuyuDerinligi = kuyuDer, TahrikKodu = tahrik };
        var (gen, der) = _svc.CalculateKabinBoyutlari(lift);
        Assert.Equal(expectedGen, gen);
        Assert.Equal(expectedDer, der);
    }

    [Fact]
    public void CalculateKabinBoyutlari_MinimumEnforced()
    {
        var lift = new Lift { KuyuGenisligi = 500, KuyuDerinligi = 500, TahrikKodu = TahrikKodu.DA };
        var (gen, der) = _svc.CalculateKabinBoyutlari(lift);
        Assert.True(gen >= 600);
        Assert.True(der >= 600);
    }

    // --- RunCalculationsAsync ---

    [Fact]
    public async Task RunCalculationsAsync_ReturnsResults()
    {
        var lift = new Lift
        {
            KuyuGenisligi = 2000, KuyuDerinligi = 2500, KuyuDibi = 1500, KuyuKafa = 3600,
            TahrikKodu = TahrikKodu.DA,
            Floors = new List<FloorInfo>
            {
                new() { KatNo = 0, KatYuksekligi = 0, MimariKot = "0" },
                new() { KatNo = 1, KatYuksekligi = 3000, MimariKot = "3" },
                new() { KatNo = 2, KatYuksekligi = 3000, MimariKot = "6" }
            }
        };

        var results = await _svc.RunCalculationsAsync(lift);

        Assert.NotEmpty(results);
        Assert.True(results.Count >= 6); // At least kabin, beyan, seyir, kuyu, + checks
        Assert.All(results, r => Assert.NotEmpty(r.Parametre));
    }

    [Fact]
    public async Task RunCalculationsAsync_EN81Checks_ReturnUYorUD()
    {
        var lift = new Lift
        {
            KuyuGenisligi = 2000, KuyuDerinligi = 2500, KuyuDibi = 1500, KuyuKafa = 4000,
            TahrikKodu = TahrikKodu.DA,
            Floors = new List<FloorInfo>()
        };

        var results = await _svc.RunCalculationsAsync(lift);
        var checks = results.Where(r => r.Standart == "SORG").ToList();

        Assert.NotEmpty(checks);
        Assert.All(checks, r => Assert.True(r.FormulSonuc == "UY" || r.FormulSonuc == "UD"));
    }

    [Fact]
    public async Task RunCalculationsAsync_SetsBeyanYukOnLift()
    {
        var lift = new Lift { KuyuGenisligi = 2000, KuyuDerinligi = 2500, TahrikKodu = TahrikKodu.DA };
        await _svc.RunCalculationsAsync(lift);
        Assert.True(lift.BeyanYuk > 0);
        Assert.True(lift.BeyanKisi > 0);
    }
}
