using AscadWeb.Core.Entities;
using AscadWeb.Core.Enums;
using AscadWeb.Core.Interfaces;

namespace AscadWeb.Core.Services;

/// <summary>
/// Asansör hesaplama motoru - Orijinal hesaplamalar.cs ve ascad.cs'den taşındı
/// EN81-1 standardına göre hesaplamalar
/// </summary>
public class CalculationService : ICalculationService
{
    /// <summary>
    /// Beyan yük ve kişi sayısını kabin alanına göre hesaplar
    /// Orijinal: beyanqbul metodu (ascad.cs) - EN81-1 Tablo 1.1
    /// </summary>
    public (int BeyanYuk, int BeyanKisi) CalculateBeyanYuk(int kabinGenisligi, int kabinDerinligi)
    {
        double alan = Math.Round((double)(kabinGenisligi * kabinDerinligi) / 1_000_000.0, 2);

        return alan switch
        {
            >= 0.49 and <= 0.58 => (180, 3),
            > 0.58 and <= 0.70 => (225, 3),
            > 0.70 and <= 0.90 => (300, 4),
            > 0.90 and <= 0.98 => (320, 5),
            > 0.98 and <= 1.10 => (375, 5),
            > 1.10 and <= 1.17 => (400, 5),
            > 1.17 and <= 1.30 => (450, 6),
            > 1.30 and <= 1.45 => (525, 7),
            > 1.45 and <= 1.60 => (600, 8),
            > 1.60 and <= 1.66 => (630, 8),
            > 1.66 and <= 1.75 => (675, 9),
            > 1.75 and <= 1.90 => (750, 10),
            > 1.90 and <= 2.00 => (800, 10),
            > 2.00 and <= 2.05 => (825, 11),
            > 2.05 and <= 2.20 => (900, 12),
            > 2.20 and <= 2.35 => (975, 13),
            > 2.35 and <= 2.40 => (1000, 13),
            > 2.40 and <= 2.50 => (1050, 14),
            > 2.50 and <= 2.65 => (1125, 15),
            > 2.65 and <= 2.80 => (1200, 16),
            > 2.80 and <= 2.90 => (1250, 16),
            > 2.90 and <= 2.95 => (1275, 17),
            > 2.95 and <= 3.10 => (1350, 18),
            > 3.10 and <= 3.25 => (1425, 19),
            > 3.25 and <= 3.40 => (1500, 20),
            > 3.40 and <= 3.56 => (1600, 22),
            > 3.56 and <= 3.68 => (1650, 22),
            > 3.68 and <= 3.80 => (1725, 23),
            > 3.80 and <= 3.92 => (1800, 24),
            > 3.92 and <= 4.04 => (1875, 25),
            > 4.04 and <= 4.16 => (1950, 26),
            > 4.16 and <= 4.20 => (2000, 26),
            > 4.20 and <= 4.32 => (2025, 27),
            _ => (0, 0)
        };
    }

    /// <summary>
    /// Kabin boyutlarını kuyu ve asansör tipine göre hesaplar
    /// Orijinal: ascad.cs AsCad() metodu
    /// </summary>
    public (int KabinGen, int KabinDer) CalculateKabinBoyutlari(Lift lift)
    {
        int kabinRayFark = lift.TahrikKodu switch
        {
            TahrikKodu.DA => 100,
            TahrikKodu.MDDUZ => 250,
            TahrikKodu.MDCAP => 0,
            _ => 100
        };

        int kabinDer = lift.KuyuDerinligi - 350 - kabinRayFark;
        int kabinGen = lift.KuyuGenisligi - 600;

        return (Math.Max(kabinGen, 600), Math.Max(kabinDer, 600));
    }

    /// <summary>
    /// Tüm hesaplamaları çalıştırır - Orijinal: simpleButton5_Click
    /// </summary>
    public Task<List<CalculationResult>> RunCalculationsAsync(Lift lift)
    {
        var results = new List<CalculationResult>();
        int sira = 1;

        var (kabinGen, kabinDer) = CalculateKabinBoyutlari(lift);
        lift.KabinGenisligi = kabinGen;
        lift.KabinDerinligi = kabinDer;

        results.Add(MakeResult(lift.Id, sira++, "KabinGen", "GENELFRM",
            "Kabin Genişliği", "KuyuGen-600", kabinGen.ToString(), "mm"));
        results.Add(MakeResult(lift.Id, sira++, "KabinDer", "GENELFRM",
            "Kabin Derinliği", "KuyuDer-350-RayFark", kabinDer.ToString(), "mm"));

        var (beyanYuk, beyanKisi) = CalculateBeyanYuk(kabinGen, kabinDer);
        lift.BeyanYuk = beyanYuk;
        lift.BeyanKisi = beyanKisi;

        double alan = Math.Round((double)(kabinGen * kabinDer) / 1_000_000.0, 2);
        results.Add(MakeResult(lift.Id, sira++, "BeyanYuk", "GENEL",
            "Beyan Yükü", $"Alan={alan} m²", beyanYuk.ToString(), "kg"));
        results.Add(MakeResult(lift.Id, sira++, "BeyanKisi", "GENEL",
            "Beyan Kişi Sayısı", "", beyanKisi.ToString(), "kişi"));

        int seyir = CalculateSeyirMesafesi(lift);
        results.Add(MakeResult(lift.Id, sira++, "SeyirMesafesi", "GENELFRM",
            "Seyir Mesafesi", "SonDurakKot-IlkDurakKot", seyir.ToString(), "mm"));

        int kuyuMesafesi = seyir + lift.KuyuDibi + lift.KuyuKafa;
        results.Add(MakeResult(lift.Id, sira++, "KuyuMesafesi", "GENELFRM",
            "Kuyu Mesafesi", "Seyir+KuyuDibi+KuyuKafa", kuyuMesafesi.ToString(), "mm"));

        // EN81-1 kontrolleri
        int minKuyuDibi = beyanYuk <= 600 ? 1200 : 1500;
        results.Add(MakeCheck(lift.Id, sira++, "KuyuDibiKontrol",
            "Kuyu Dibi Min. Kontrolü (EN81-1 5.7.1.1)",
            $"KuyuDibi >= {minKuyuDibi}", $"{lift.KuyuDibi} >= {minKuyuDibi}",
            lift.KuyuDibi >= minKuyuDibi));

        results.Add(MakeCheck(lift.Id, sira++, "KuyuKafaKontrol",
            "Kuyu Kafası Min. Kontrolü (EN81-1 5.7.1.2)",
            "KuyuKafa >= 3600", $"{lift.KuyuKafa} >= 3600",
            lift.KuyuKafa >= 3600));

        double maxAlan = GetMaxKabinAlani(beyanYuk);
        results.Add(MakeCheck(lift.Id, sira++, "KabinAlaniKontrol",
            "Kabin Alanı Kontrolü (EN81-1 8.2.1)",
            $"KabinAlani <= {maxAlan}", $"{alan} <= {maxAlan}",
            alan <= maxAlan));

        return Task.FromResult(results);
    }

    private int CalculateSeyirMesafesi(Lift lift)
    {
        if (lift.Floors == null || lift.Floors.Count < 2) return 0;
        var sorted = lift.Floors.OrderBy(f => f.KatNo).ToList();
        return sorted.Sum(f => f.KatYuksekligi) - sorted.First().KatYuksekligi;
    }

    private static double GetMaxKabinAlani(int beyanYuk) => beyanYuk switch
    {
        <= 180 => 0.58, <= 225 => 0.70, <= 300 => 0.90, <= 375 => 1.10,
        <= 450 => 1.30, <= 600 => 1.60, <= 750 => 1.90, <= 900 => 2.20,
        <= 1050 => 2.50, <= 1200 => 2.80, <= 1500 => 3.40, <= 1600 => 3.56,
        <= 1800 => 3.92, <= 2000 => 4.20, <= 2500 => 5.00, _ => 5.00
    };

    private static CalculationResult MakeResult(Guid liftId, int sira, string param,
        string standart, string aciklama, string formul, string sonuc, string birim) => new()
    {
        LiftId = liftId, Sira = sira, Parametre = param, Standart = standart,
        Aciklama = aciklama, Formul = formul, FormulDeger = formul,
        FormulSonuc = sonuc, Birim = birim
    };

    private static CalculationResult MakeCheck(Guid liftId, int sira, string param,
        string aciklama, string formul, string formulDeger, bool passed) => new()
    {
        LiftId = liftId, Sira = sira, Parametre = param, Standart = "SORG",
        Aciklama = aciklama, Formul = formul, FormulDeger = formulDeger,
        FormulSonuc = passed ? "UY" : "UD", Birim = ""
    };
}
