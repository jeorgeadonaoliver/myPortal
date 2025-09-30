using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Infrastructure.PortalDb;

public partial class MyPortalDbContext : DbContext, IMyPortalDbContext
{

    public MyPortalDbContext()
    {
    }

    public MyPortalDbContext(DbContextOptions<MyPortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }

    public virtual DbSet<CustomerLoginActivity> CustomerLoginActivities { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerAccount>(entity =>
        {
            entity
                .HasKey(e => e.Id).HasName("PK_CustomerAccount");
            entity.ToTable("CustomerAccount");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Id).HasColumnType("uniqueidentifier");
            entity.Property(e => e.TenantId).HasColumnType("uniqueidentifier");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.Uid).HasMaxLength(50);
            entity.Property(e => e.SecretKey).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())");
        });

        modelBuilder.Entity<CustomerLoginActivity>(entity =>
        {
            entity.HasKey(e => e.ActivityId);

            entity.ToTable("CustomerLoginActivity");

            entity.Property(e => e.ActivityId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TenantId).HasColumnType("uniqueidentifier");
            entity.Property(e => e.DeviceInfo).HasMaxLength(100);
            entity.Property(e => e.IpAddress).HasMaxLength(45);
            entity.Property(e => e.LoginMethod).HasMaxLength(50);
            entity.Property(e => e.LoginTimestamp)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysdatetime())");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.TenantId).HasName("PK__Tenant__2E9B47811DF4BDE9");

            entity.ToTable("Tenant");

            entity.HasIndex(e => e.TenantName, "IX_Tenant_TenantName");

            entity.HasIndex(e => e.Email, "UQ__Tenant__A9D1053465C9B6F8").IsUnique();

            entity.Property(e => e.TenantId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenantName).HasMaxLength(255);
            entity.Property(e => e.TenantStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Active");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
