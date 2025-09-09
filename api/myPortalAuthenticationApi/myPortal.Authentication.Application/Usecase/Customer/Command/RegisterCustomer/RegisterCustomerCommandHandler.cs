using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Usecase.Customer.Command.RegisterCustomer;

public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Guid>
{
    protected readonly IUnitOfWork _context;

    public RegisterCustomerCommandHandler(IUnitOfWork context)
    {
        _context = context;
    }

    public async Task<Guid> HandleAsync(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {

        var newCustomerId = await _context.ExecuteInTransactionAsync<Guid>(
            async (db, ct) =>
            {
                var customer = new CustomerAccount() {

                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Id = Guid.NewGuid(),
                    MiddleName = request.MiddletName,
                    Uid = request.Uid
                };

                db.CustomerAccounts.Add(customer);

                await db.SaveChangesAsync(ct);

                return customer.Id; 
            },
            cancellationToken);

        return newCustomerId;
    }
}
