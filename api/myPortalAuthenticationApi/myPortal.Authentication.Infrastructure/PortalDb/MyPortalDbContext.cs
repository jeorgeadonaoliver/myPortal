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
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.Uid).HasMaxLength(50);
            entity.Property(e => e.SecretKey).HasMaxLength(100);
        });

        modelBuilder.Entity<CustomerLoginActivity>(entity =>
        {
            entity.HasKey(e => e.ActivityId);

            entity.ToTable("CustomerLoginActivity");

            entity.Property(e => e.ActivityId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DeviceInfo).HasMaxLength(100);
            entity.Property(e => e.IpAddress).HasMaxLength(45);
            entity.Property(e => e.LoginMethod).HasMaxLength(50);
            entity.Property(e => e.LoginTimestamp)
                .HasPrecision(3)
                .HasDefaultValueSql("(sysdatetime())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
