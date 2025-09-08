using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Customer.Command.RegisterCustomer;

public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Guid>
{
    protected readonly IMyPortalDbContext _context;

    public RegisterCustomerCommandHandler(IMyPortalDbContext context)
    {
        _context = context;
    }

    public Task<Guid> HandleAsync(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
