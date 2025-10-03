using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Usecase.Customer.Query.GetCustomer
{
    internal static class GetCustomerQueryDtoMappingExtension
    {
        public static GetCustomerQueryDto ToDto(this CustomerAccount customerAccount) 
        {
            return new GetCustomerQueryDto { 
            
                Email = customerAccount.Email,
                FirstName = customerAccount.FirstName,
                LastName = customerAccount.LastName,
                Id = customerAccount.Id,
                MiddleName = customerAccount.MiddleName,
                TenantId = customerAccount.TenantId,
                RoleId = customerAccount.RoleId,
                Uid = customerAccount.Uid
            };
        }
    }
}
