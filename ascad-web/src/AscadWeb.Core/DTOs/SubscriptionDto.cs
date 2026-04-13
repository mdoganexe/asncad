namespace AscadWeb.Core.DTOs;

public record UsageStats(
    string PlanName,
    int ProjectCount,
    int ProjectLimit,
    int UserCount,
    int UserLimit,
    int PdfExportCount,
    int PdfExportLimit
);

public record ChangePlanRequest(
    string PlanName
);
