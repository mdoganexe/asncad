using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;
using AscadWeb.Core.Interfaces;
using AscadWeb.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AscadWeb.Infrastructure.Services;

public class CompanyInfoService : ICompanyInfoService
{
    private readonly AscadDbContext _db;

    public CompanyInfoService(AscadDbContext db)
    {
        _db = db;
    }

    public async Task<CompanyInfo> GetOrCreateAsync(Guid tenantId)
    {
        var info = await _db.CompanyInfos.FirstOrDefaultAsync(c => c.TenantId == tenantId);
        if (info is not null)
            return info;

        info = new CompanyInfo { TenantId = tenantId };
        _db.CompanyInfos.Add(info);
        await _db.SaveChangesAsync();
        return info;
    }

    public async Task<CompanyInfo> UpdateAsync(Guid tenantId, UpdateCompanyInfoRequest request)
    {
        var info = await GetOrCreateAsync(tenantId);

        // Validate string field lengths
        ValidateFieldLength(nameof(request.Ad), request.Ad);
        ValidateFieldLength(nameof(request.Adres), request.Adres);
        ValidateFieldLength(nameof(request.Telefon), request.Telefon);
        ValidateFieldLength(nameof(request.Fax), request.Fax);
        ValidateFieldLength(nameof(request.Email), request.Email);
        ValidateFieldLength(nameof(request.Yetkili), request.Yetkili);
        ValidateFieldLength(nameof(request.Marka), request.Marka);
        ValidateFieldLength(nameof(request.VergiDairesi), request.VergiDairesi);
        ValidateFieldLength(nameof(request.VergiNo), request.VergiNo);
        ValidateFieldLength(nameof(request.OnayliKurulusAd), request.OnayliKurulusAd);
        ValidateFieldLength(nameof(request.OnayliKurulusNo), request.OnayliKurulusNo);
        ValidateFieldLength(nameof(request.SanayiNo), request.SanayiNo);
        ValidateFieldLength(nameof(request.HYBNo), request.HYBNo);
        ValidateFieldLength(nameof(request.MakinaMuhAd), request.MakinaMuhAd);
        ValidateFieldLength(nameof(request.MakinaMuhOdaSicil), request.MakinaMuhOdaSicil);
        ValidateFieldLength(nameof(request.MakinaMuhBelge), request.MakinaMuhBelge);
        ValidateFieldLength(nameof(request.MakinaMuhSMM), request.MakinaMuhSMM);
        ValidateFieldLength(nameof(request.ElektrikMuhAd), request.ElektrikMuhAd);
        ValidateFieldLength(nameof(request.ElektrikMuhOdaSicil), request.ElektrikMuhOdaSicil);
        ValidateFieldLength(nameof(request.ElektrikMuhBelge), request.ElektrikMuhBelge);
        ValidateFieldLength(nameof(request.ElektrikMuhSMM), request.ElektrikMuhSMM);

        // Update only non-null fields
        if (request.Ad is not null) info.Ad = request.Ad;
        if (request.Adres is not null) info.Adres = request.Adres;
        if (request.Telefon is not null) info.Telefon = request.Telefon;
        if (request.Fax is not null) info.Fax = request.Fax;
        if (request.Email is not null) info.Email = request.Email;
        if (request.Yetkili is not null) info.Yetkili = request.Yetkili;
        if (request.Marka is not null) info.Marka = request.Marka;
        if (request.VergiDairesi is not null) info.VergiDairesi = request.VergiDairesi;
        if (request.VergiNo is not null) info.VergiNo = request.VergiNo;
        if (request.OnayliKurulusAd is not null) info.OnayliKurulusAd = request.OnayliKurulusAd;
        if (request.OnayliKurulusNo is not null) info.OnayliKurulusNo = request.OnayliKurulusNo;
        if (request.SanayiTarih is not null) info.SanayiTarih = request.SanayiTarih;
        if (request.SanayiNo is not null) info.SanayiNo = request.SanayiNo;
        if (request.HYBTarih is not null) info.HYBTarih = request.HYBTarih;
        if (request.HYBNo is not null) info.HYBNo = request.HYBNo;
        if (request.MakinaMuhAd is not null) info.MakinaMuhAd = request.MakinaMuhAd;
        if (request.MakinaMuhOdaSicil is not null) info.MakinaMuhOdaSicil = request.MakinaMuhOdaSicil;
        if (request.MakinaMuhBelge is not null) info.MakinaMuhBelge = request.MakinaMuhBelge;
        if (request.MakinaMuhSMM is not null) info.MakinaMuhSMM = request.MakinaMuhSMM;
        if (request.ElektrikMuhAd is not null) info.ElektrikMuhAd = request.ElektrikMuhAd;
        if (request.ElektrikMuhOdaSicil is not null) info.ElektrikMuhOdaSicil = request.ElektrikMuhOdaSicil;
        if (request.ElektrikMuhBelge is not null) info.ElektrikMuhBelge = request.ElektrikMuhBelge;
        if (request.ElektrikMuhSMM is not null) info.ElektrikMuhSMM = request.ElektrikMuhSMM;

        info.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();
        return info;
    }

    private static void ValidateFieldLength(string fieldName, string? value)
    {
        if (value is not null && value.Length > 255)
            throw new ArgumentException($"Field '{fieldName}' exceeds maximum length of 255 characters.");
    }
}
