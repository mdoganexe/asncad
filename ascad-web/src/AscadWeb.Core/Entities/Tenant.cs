namespace AscadWeb.Core.Entities;

public class Tenant : BaseEntity
{
    public string CompanyName { get; set; } = string.Empty;
    public string SubscriptionPlan { get; set; } = "Basic";
    public bool IsActive { get; set; } = true;

    // Navigation
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public CompanyInfo? CompanyInfo { get; set; }
}
