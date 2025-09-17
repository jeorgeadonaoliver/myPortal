using myPortal.Authentication.Application.Abstraction.Authentication;
using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Authentication.Command.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IJwtService _jwtService;

    public LoginCommandHandler(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public async Task<string> HandleAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _jwtService.GenerateTokenAsync(request.token, cancellationToken);
    }
}
