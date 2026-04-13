using AscadWeb.Core.Entities;

namespace AscadWeb.Core.Interfaces;

public interface IPdfReportGeneratorService
{
    Task<byte[]> GenerateCalculationReportAsync(Lift lift, CompanyInfo? companyInfo, Project project);
}
