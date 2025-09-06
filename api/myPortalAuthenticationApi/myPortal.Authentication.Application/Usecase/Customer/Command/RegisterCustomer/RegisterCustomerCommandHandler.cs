using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Customer.Command.RegisterCustomer;

public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Guid>
{
    public Task<Guid> HandleAsync(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
