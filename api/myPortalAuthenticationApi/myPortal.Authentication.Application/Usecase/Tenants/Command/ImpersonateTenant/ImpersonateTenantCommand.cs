using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Tenants.Command.ImpersonateTenant;

public record ImpersonateTenantCommand(Guid tenantId): IRequest<bool>;

