using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Tenants.Command.StopImpersonateTenant
{
    public record StopImpersonateTenantCommand : IRequest<bool>;
}
