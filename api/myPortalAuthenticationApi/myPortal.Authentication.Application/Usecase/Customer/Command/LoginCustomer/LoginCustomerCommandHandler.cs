using myPortal.Authentication.Application.Abstraction.Authentication;
using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Customer.Command.LoginCustomer;

internal sealed class LoginCustomerCommandHandler : IRequestHandler<LoginCustomerCommand, string>
{
    private readonly IJwtService _jwtService;

    public LoginCustomerCommandHandler(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public async Task<string> HandleAsync(LoginCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _jwtService.GenerateTokenAsync(request.Email, request.Password, cancellationToken);
    }
}
