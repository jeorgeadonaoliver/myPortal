using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Usecase.Tenants.Query.GetTenantById;

public static class GetTenantByIdQueryMappingExtension
{
    public static GetTenantByIdDto ToDto(this Tenant tenant)
    {
        return new GetTenantByIdDto
        {
            TenantId = tenant.TenantId,
            TenantName = tenant.TenantName,
            Email = tenant.Email,
            PhoneNumber = tenant.PhoneNumber,
            LeaseStartDate = tenant.LeaseStartDate,
            LeaseEndDate = tenant.LeaseEndDate,
            TenantStatus = tenant.TenantStatus.ToString(),
            CreatedDate = tenant.CreatedDate,
            ModifiedDate = tenant.ModifiedDate
        };
    }
}
