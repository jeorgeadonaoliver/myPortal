using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Infrastructure.PortalDb;

public partial class MyPortalDbContext : DbContext
{
    public MyPortalDbContext()
    {
    }

    public MyPortalDbContext(DbContextOptions<MyPortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerAccount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CustomerAccount");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
