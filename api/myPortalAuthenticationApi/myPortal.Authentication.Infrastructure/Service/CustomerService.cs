using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Service;
using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Infrastructure.Service;

public class CustomerService : ICustomerService
{
    protected readonly IMyPortalDbContext _context;

    public CustomerService(IMyPortalDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CustomerAccount>> GetAllCustomerByTenantId(Guid tenantId, CancellationToken cancellationToken)
    {
        return await _context.CustomerAccounts
            .Where(x => x.TenantId == tenantId).ToListAsync(cancellationToken);

    }

    public async Task<CustomerAccount> GetCustomerTenantIdByUidAsync(string uid, CancellationToken cancellationToken)
    {
        return await _context.CustomerAccounts
            .Where(x => x.Uid == uid).FirstOrDefaultAsync(cancellationToken) 
            ?? throw new InvalidOperationException("GetCustomerTenantIdByUidAsync is null!");

    }
}
