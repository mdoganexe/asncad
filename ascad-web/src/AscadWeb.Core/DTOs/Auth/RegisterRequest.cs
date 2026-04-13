namespace AscadWeb.Core.DTOs.Auth;

public record RegisterRequest(
    string Email,
    string Password,
    string FullName,
    string CompanyName
);
