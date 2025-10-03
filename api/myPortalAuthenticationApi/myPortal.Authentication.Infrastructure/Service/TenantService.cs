using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Service;
using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Infrastructure.Service
{
    internal class TenantService : ITenantService
    {
        protected readonly IMyPortalDbContext _context;

        public TenantService(IMyPortalDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Tenant tenant, CancellationToken cancellationToken)
        {
            await _context.Tenants.AddAsync(tenant, cancellationToken);
        }
    }
}
