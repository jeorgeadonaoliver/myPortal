using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Abstraction.Service;

public interface ICustomerService
{
    Task<IEnumerable<CustomerAccount>> GetAllCustomerByTenantId(Guid tenantId, CancellationToken cancellationToken);
}
