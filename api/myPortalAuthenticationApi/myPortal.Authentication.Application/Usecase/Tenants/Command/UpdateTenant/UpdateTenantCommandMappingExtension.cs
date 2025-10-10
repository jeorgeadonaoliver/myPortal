using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Usecase.Tenants.Command.UpdateTenant;

internal static class UpdateTenantCommandMappingExtension
{
    public static Tenant ToEntity(this UpdateTenantCommand command) 
    {
        return new Tenant 
        {
            TenantId = command.TenantId,
            Email = command.Email,
            LeaseEndDate = command.LeaseEndDate,
            LeaseStartDate = command.LeaseStartDate,
            TenantName = command.TenantName,
            PhoneNumber = command.PhoneNumber
        };
    }
}
