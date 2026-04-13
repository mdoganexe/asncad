namespace AscadWeb.Core.DTOs;

public record CalculationResultDto(
    int Sira,
    string Parametre,
    string Standart,
    string Aciklama,
    string Formul,
    string FormulDeger,
    string FormulSonuc,
    string Birim
);

public record CalculationSummaryDto(
    Guid LiftId,
    int TotalChecks,
    int PassedChecks,
    int FailedChecks,
    List<CalculationResultDto> Results
);
