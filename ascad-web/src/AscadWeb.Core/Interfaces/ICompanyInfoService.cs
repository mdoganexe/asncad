using AscadWeb.Core.DTOs;
using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Interfaces;

public interface ICompanyInfoService
{
    Task<CompanyInfo> GetOrCreateAsync(Guid tenantId);
    Task<CompanyInfo> UpdateAsync(Guid tenantId, UpdateCompanyInfoRequest request);
}
