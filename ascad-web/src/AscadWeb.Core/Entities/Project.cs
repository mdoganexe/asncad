namespace AscadWeb.Core.Entities;

/// <summary>
/// Asansör projesi - Her proje bir asansör tasarımını temsil eder
/// </summary>
public class Project : BaseEntity
{
    public Guid TenantId { get; set; }
    public Guid UserId { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = "Draft"; // Draft, InProgress, Completed

    // Navigation
    public Tenant Tenant { get; set; } = null!;
    public User User { get; set; } = null!;
    public ICollection<Lift> Lifts { get; set; } = new List<Lift>();
}
