namespace AscadWeb.Core.DTOs;

public record UpdateCompanyInfoRequest(
    string? Ad,
    string? Adres,
    string? Telefon,
    string? Fax,
    string? Email,
    string? Yetkili,
    string? Marka,
    string? VergiDairesi,
    string? VergiNo,
    string? OnayliKurulusAd,
    string? OnayliKurulusNo,
    DateTime? SanayiTarih,
    string? SanayiNo,
    DateTime? HYBTarih,
    string? HYBNo,
    string? MakinaMuhAd,
    string? MakinaMuhOdaSicil,
    string? MakinaMuhBelge,
    string? MakinaMuhSMM,
    string? ElektrikMuhAd,
    string? ElektrikMuhOdaSicil,
    string? ElektrikMuhBelge,
    string? ElektrikMuhSMM
);
