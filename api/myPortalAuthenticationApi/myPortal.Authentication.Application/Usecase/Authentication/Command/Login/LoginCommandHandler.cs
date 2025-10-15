using FirebaseAdmin.Auth;
using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Application.Abstraction.Authentication;
using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Authentication.Command.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
{
    private readonly IJwtService _jwtService;

    protected readonly IMyPortalDbContext _context;

    public LoginCommandHandler(IJwtService jwtService, IMyPortalDbContext context)
    {
        _jwtService = jwtService;
        _context = context;
    }

    public async Task<bool> HandleAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        var data = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.token);

        var result = await _context.CustomerAccounts.AnyAsync(x => x.Uid == data.Uid);

        if (result)
        {
            var customClaims = new Dictionary<string, object>
                        {
                            { "tenantId", data.TenantId }
                        };

            await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(data.Uid, customClaims);

            return true;

        }

        return false;

    }
}
