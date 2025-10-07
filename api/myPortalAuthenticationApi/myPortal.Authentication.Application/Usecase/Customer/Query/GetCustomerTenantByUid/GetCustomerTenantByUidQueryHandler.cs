using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Application.Abstraction.Service;

namespace myPortal.Authentication.Application.Usecase.Customer.Query.GetCustomerTenantByUid;

internal class GetCustomerTenantByUidQueryHandler : IRequestHandler<GetCustomerTenantByUidQuery, GetCustomerTenantByUidQueryDto>
{
    private readonly ICustomerService _custotmerService;

    public GetCustomerTenantByUidQueryHandler(ICustomerService customerService)
    {
        _custotmerService = customerService;
    }

    public async Task<GetCustomerTenantByUidQueryDto> HandleAsync(GetCustomerTenantByUidQuery request, CancellationToken cancellationToken)
    {
        var data = await _custotmerService.GetCustomerTenantIdByUidAsync(request.uid, cancellationToken);
        var toDto = data.ToDto();

        return toDto;
    }
}
