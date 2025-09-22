using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Customer.Query.GetCustomer;

public record GetCustomerQuery : IRequest<IEnumerable<GetCustomerQueryDto>>;
