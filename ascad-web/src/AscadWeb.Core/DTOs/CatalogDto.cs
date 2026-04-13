namespace AscadWeb.Core.DTOs;

public record CreateCatalogItemRequest(
    string Category,
    string ModelName,
    string? Description,
    string SpecsJson
);

public record UpdateCatalogItemRequest(
    string? ModelName,
    string? Description,
    string? SpecsJson
);

public record CatalogItemResponse(
    Guid Id,
    string Category,
    string ModelName,
    string? Description,
    string SpecsJson
);
