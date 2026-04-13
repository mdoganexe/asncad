namespace AscadWeb.Core.DTOs;

public record CreateProjectRequest(
    string ProjectName,
    string? Description
);

public record ProjectResponse(
    Guid Id,
    string ProjectName,
    string? Description,
    string Status,
    int LiftCount,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
