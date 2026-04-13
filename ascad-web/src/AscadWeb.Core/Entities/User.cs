namespace AscadWeb.Core.Entities;

public class User : BaseEntity
{
    public Guid TenantId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Role { get; set; } = "Engineer"; // Admin, Engineer, Viewer

    // Navigation
    public Tenant Tenant { get; set; } = null!;
    public ICollection<Project> Projects { get; set; } = new List<Project>();
}
