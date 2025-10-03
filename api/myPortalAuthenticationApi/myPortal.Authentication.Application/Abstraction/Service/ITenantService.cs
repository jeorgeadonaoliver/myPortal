using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Abstraction.Service;

public interface ITenantService
{
    Task CreateAsync(Tenant tenant, CancellationToken cancellationToken);
}
