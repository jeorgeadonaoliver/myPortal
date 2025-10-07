using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Usecase.Customer.Query.GetCustomerTenantByUid;

public static class GetCustomerTenantByUidQueryMappingExtension
{
    public static GetCustomerTenantByUidQueryDto ToDto(this CustomerAccount customer) 
    {
        return new GetCustomerTenantByUidQueryDto { 
            TenantId = customer.TenantId

        };
    }
}
