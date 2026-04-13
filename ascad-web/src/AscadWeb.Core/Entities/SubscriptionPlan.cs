namespace AscadWeb.Core.Entities;

public class SubscriptionPlan : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int MaxProjects { get; set; }
    public int MaxUsersPerTenant { get; set; }
    public int MaxPdfExportsPerMonth { get; set; }
    public decimal MonthlyPrice { get; set; }
    public bool IsActive { get; set; } = true;
}
