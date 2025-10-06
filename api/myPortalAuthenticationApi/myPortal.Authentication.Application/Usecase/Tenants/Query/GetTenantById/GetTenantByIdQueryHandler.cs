using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Tenants.Query.GetTenantById;

internal class GetTenantByIdQueryHandler : IRequestHandler<GetTenantByIdQuery, GetTenantByIdDto>
{
    public Task<GetTenantByIdDto> HandleAsync(GetTenantByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
