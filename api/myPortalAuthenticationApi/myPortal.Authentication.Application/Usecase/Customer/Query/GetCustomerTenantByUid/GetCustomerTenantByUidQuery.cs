using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Customer.Query.GetCustomerTenantByUid;

internal record GetCustomerTenantByUidQuery(string uid) : IRequest<GetCustomerTenantByUidQueryDto>;
