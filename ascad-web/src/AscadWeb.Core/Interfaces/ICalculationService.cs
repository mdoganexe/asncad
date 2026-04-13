using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Interfaces;

/// <summary>
/// Asansör hesaplama servisi - Orijinal hesaplamalar.cs iş mantığı
/// </summary>
public interface ICalculationService
{
    /// <summary>
    /// Beyan yük ve kişi sayısını kabin alanına göre hesaplar
    /// Orijinal: beyanqbul metodu
    /// </summary>
    (int BeyanYuk, int BeyanKisi) CalculateBeyanYuk(int kabinGenisligi, int kabinDerinligi);

    /// <summary>
    /// Tüm hesaplamaları çalıştırır
    /// Orijinal: simpleButton5_Click
    /// </summary>
    Task<List<CalculationResult>> RunCalculationsAsync(Lift lift);

    /// <summary>
    /// Kabin boyutlarını hesaplar
    /// </summary>
    (int KabinGen, int KabinDer) CalculateKabinBoyutlari(Lift lift);
}
