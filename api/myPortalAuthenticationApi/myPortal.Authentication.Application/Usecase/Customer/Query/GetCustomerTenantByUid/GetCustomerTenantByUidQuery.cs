using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Customer.Query.GetCustomerTenantByUid;

public record GetCustomerTenantByUidQuery(string uid) : IRequest<GetCustomerTenantByUidQueryDto>;
