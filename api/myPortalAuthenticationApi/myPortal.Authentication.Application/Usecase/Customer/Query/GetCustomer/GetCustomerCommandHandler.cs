using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Application.Abstraction.Service;

namespace myPortal.Authentication.Application.Usecase.Customer.Query.GetCustomer;

internal class GetCustomerCommandHandler : IRequestHandler<GetCustomerQuery, IEnumerable<GetCustomerQueryDto>>
{
    private readonly ICustomerService _customerService;

    public GetCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<IEnumerable<GetCustomerQueryDto>> HandleAsync(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var data = await _customerService.GetAllCustomerByTenantId(request.tenantId, cancellationToken);
        var customerList = data.Select(x => x.ToDto());

        return customerList;
    }
}
