using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Usecase.Tenants.Command.CreateTenant;

internal static class CreateTenantCommandMappingExtension
{
    public static Tenant ToEntities(this CreateTenantCommand command) 
    {
        return new Tenant {
            Email = command.Email,
            LeaseEndDate = command.LeaseEndDate,
            LeaseStartDate = command.LeaseStartDate,
            TenantName = command.TenantName,
            PhoneNumber = command.PhoneNumber
        };
    }
}
