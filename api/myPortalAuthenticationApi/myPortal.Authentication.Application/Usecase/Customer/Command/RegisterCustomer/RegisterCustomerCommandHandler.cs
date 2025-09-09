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
        var customer = new CustomerAccount {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Id = Guid.NewGuid(),
            MiddleName = request.MiddletName

        };

        await _context.BeginTransactionAsync(cancellationToken);

        try 
        {

            await _context.Context.CustomerAccounts.AddAsync(customer, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            await _context.CommitTransactionAsync(cancellationToken);

            return customer.Id;
        }
        catch
        {
            await _context.RollbackTransactionAsync(cancellationToken);
            throw;
        }
    }
}
