using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Abstraction.Data;

public interface IMyPortalDbContext
{
    DbSet<CustomerAccount> CustomerAccounts { get; }

    DbSet<CustomerLoginActivity> CustomerLoginActivities { get; }

    DbSet<Tenant> Tenants { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
