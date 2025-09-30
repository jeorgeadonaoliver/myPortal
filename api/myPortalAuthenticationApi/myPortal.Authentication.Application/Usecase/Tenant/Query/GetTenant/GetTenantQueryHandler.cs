using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Tenant.Query.GetTenant;

public class GetTenantQueryHandler : IRequestHandler<GetTenantQuery, IEnumerable<GetTenantQueryDto>>
{
    private readonly IMyPortalDbContext _myPortalDbContext;

    public GetTenantQueryHandler(IMyPortalDbContext myPortalDbContext)
    {
        _myPortalDbContext = myPortalDbContext;
    }

    public async Task<IEnumerable<GetTenantQueryDto>> HandleAsync(GetTenantQuery request, CancellationToken cancellationToken)
    {
        var tenant = await _myPortalDbContext.Tenants
            .Select(t => new GetTenantQueryDto
            {
                TenantId = t.TenantId,
                CreatedDate = t.CreatedDate,
                TenantName = t.TenantName,
                Email = t.Email,
                LeaseEndDate = t.LeaseEndDate,
                LeaseStartDate = t.LeaseStartDate,
                ModifiedDate = t.ModifiedDate,
                PhoneNumber = t.PhoneNumber,
                TenantStatus = t.TenantStatus,
            }).ToListAsync(cancellationToken);

        return tenant;
    }
}
