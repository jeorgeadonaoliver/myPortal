using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Tenants.Query.GetTenantById
{
    public record GetTenantByIdQuery(Guid id) : IRequest<GetTenantByIdDto>;    
}
