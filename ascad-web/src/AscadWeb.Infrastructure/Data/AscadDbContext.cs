using AscadWeb.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AscadWeb.Infrastructure.Data;

public class AscadDbContext : DbContext
{
    public AscadDbContext(DbContextOptions<AscadDbContext> options) : base(options) { }

    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<User> Users => Set<User>();
    public DbSet<CompanyInfo> CompanyInfos => Set<CompanyInfo>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Lift> Lifts => Set<Lift>();
    public DbSet<FloorInfo> FloorInfos => Set<FloorInfo>();
    public DbSet<CalculationResult> CalculationResults => Set<CalculationResult>();
    public DbSet<CalculationDefinition> CalculationDefinitions => Set<CalculationDefinition>();
    public DbSet<ProductCatalogItem> ProductCatalogItems => Set<ProductCatalogItem>();
    public DbSet<SubscriptionPlan> SubscriptionPlans => Set<SubscriptionPlan>();
    public DbSet<TenantSubscription> TenantSubscriptions => Set<TenantSubscription>();
    public DbSet<TenantSettings> TenantSettings => Set<TenantSettings>();
    public DbSet<Drawing> Drawings => Set<Drawing>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tenant>(e =>
        {
            e.HasKey(t => t.Id);
            e.HasMany(t => t.Users).WithOne(u => u.Tenant).HasForeignKey(u => u.TenantId);
            e.HasMany(t => t.Projects).WithOne(p => p.Tenant).HasForeignKey(p => p.TenantId);
            e.HasOne(t => t.CompanyInfo).WithOne(c => c.Tenant).HasForeignKey<CompanyInfo>(c => c.TenantId);
        });

        modelBuilder.Entity<User>(e =>
        {
            e.HasKey(u => u.Id);
            e.HasIndex(u => u.Email).IsUnique();
        });

        modelBuilder.Entity<Project>(e =>
        {
            e.HasKey(p => p.Id);
            e.HasMany(p => p.Lifts).WithOne(l => l.Project).HasForeignKey(l => l.ProjectId);
        });

        modelBuilder.Entity<Lift>(e =>
        {
            e.HasKey(l => l.Id);
            e.HasMany(l => l.Floors).WithOne(f => f.Lift).HasForeignKey(f => f.LiftId).OnDelete(DeleteBehavior.Cascade);
            e.HasMany(l => l.CalculationResults).WithOne(c => c.Lift).HasForeignKey(c => c.LiftId).OnDelete(DeleteBehavior.Cascade);
            e.Property(l => l.AsansorTipiKodu).HasConversion<string>();
            e.Property(l => l.TahrikKodu).HasConversion<string>();
            e.Property(l => l.YonKodu).HasConversion<string>();

            // Group index for multi-elevator shaft queries
            e.HasIndex(l => new { l.ProjectId, l.GroupId });

            // Optional catalog FK relationships
            e.HasOne<ProductCatalogItem>().WithMany().HasForeignKey(l => l.CabinRailCatalogId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            e.HasOne<ProductCatalogItem>().WithMany().HasForeignKey(l => l.CounterweightRailCatalogId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            e.HasOne<ProductCatalogItem>().WithMany().HasForeignKey(l => l.CabinBufferCatalogId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            e.HasOne<ProductCatalogItem>().WithMany().HasForeignKey(l => l.CounterweightBufferCatalogId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            e.HasOne<ProductCatalogItem>().WithMany().HasForeignKey(l => l.MotorCatalogId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            e.HasOne<ProductCatalogItem>().WithMany().HasForeignKey(l => l.SafetyDeviceCatalogId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
            e.HasOne<ProductCatalogItem>().WithMany().HasForeignKey(l => l.RopeCatalogId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<CalculationDefinition>(e =>
        {
            e.HasKey(cd => cd.Id);
            e.HasOne(cd => cd.Tenant).WithMany().HasForeignKey(cd => cd.TenantId);
            e.HasIndex(cd => new { cd.TenantId, cd.Sira });
        });

        modelBuilder.Entity<ProductCatalogItem>(e =>
        {
            e.HasKey(p => p.Id);
            e.HasOne(p => p.Tenant).WithMany().HasForeignKey(p => p.TenantId);
            e.HasIndex(p => new { p.TenantId, p.Category });
        });

        modelBuilder.Entity<SubscriptionPlan>(e =>
        {
            e.HasKey(sp => sp.Id);
        });

        modelBuilder.Entity<TenantSubscription>(e =>
        {
            e.HasKey(ts => ts.Id);
            e.HasOne(ts => ts.Tenant).WithOne().HasForeignKey<TenantSubscription>(ts => ts.TenantId);
            e.HasOne(ts => ts.Plan).WithMany().HasForeignKey(ts => ts.PlanId);
        });

        modelBuilder.Entity<TenantSettings>(e =>
        {
            e.HasKey(s => s.Id);
            e.HasOne(s => s.Tenant).WithOne().HasForeignKey<TenantSettings>(s => s.TenantId);
        });

        modelBuilder.Entity<Drawing>(e =>
        {
            e.HasKey(d => d.Id);
            e.HasOne(d => d.Lift).WithMany().HasForeignKey(d => d.LiftId).OnDelete(DeleteBehavior.Cascade);
            e.HasIndex(d => new { d.LiftId, d.DrawingType }).IsUnique();
        });
    }
}
