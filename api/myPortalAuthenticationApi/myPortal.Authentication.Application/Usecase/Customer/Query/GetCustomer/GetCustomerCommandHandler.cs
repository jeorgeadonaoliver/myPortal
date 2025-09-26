using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Customer.Query.GetCustomer;

internal class GetCustomerCommandHandler : IRequestHandler<GetCustomerQuery, IEnumerable<GetCustomerQueryDto>>
{
    private readonly IMyPortalDbContext _context;

    public GetCustomerCommandHandler(IMyPortalDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GetCustomerQueryDto>> HandleAsync(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customers = await _context.CustomerAccounts
            .GroupJoin(_context.CustomerLoginActivities,
            activity => activity.Id,
            cust => cust.CustomerId,
            (activity, cust) => new { activity, cust })
            .Select(x =>
                 new GetCustomerQueryDto
                {
                    Id = x.activity.Id,
                    LastName = x.activity.LastName,
                    FirstName = x.activity.FirstName,
                    MiddleName = x.activity.MiddleName,
                    Email = x.activity.Email,
                    RoleId = x.activity.RoleId,
                    Uid = x.activity.Uid,
                    LastLogin = x.cust.Max(y => (DateTime)y.LoginTimestamp),
                    TenantId = x.activity.TenantId,
                })
            .ToListAsync(cancellationToken);

        return customers;
    }
}
