namespace AscadWeb.Core.DTOs;

public record BuildingTemplateRequest(
    string BuildingType,
    Dictionary<string, int> Parameters
);
