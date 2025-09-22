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
            .Select(x =>
                new GetCustomerQueryDto
                {
                    Id = x.Id, 
                    LastName = x.LastName,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    Email = x.Email,
                    RoleId = x.RoleId,
                    Uid = x.Uid,
                    CreatedAt = x.CreatedAt
                })
            .ToListAsync(cancellationToken);

        return customers;
    }
}
