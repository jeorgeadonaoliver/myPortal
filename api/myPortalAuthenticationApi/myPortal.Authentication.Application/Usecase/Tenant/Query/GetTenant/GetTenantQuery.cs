using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Tenant.Query.GetTenant;

public record GetTenantQuery :  IRequest<IEnumerable<GetTenantQueryDto>>;
