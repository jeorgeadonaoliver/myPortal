using FirebaseAdmin.Auth;
using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Application.Abstraction.Authentication;
using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Authentication.Command.Login;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
{
    private readonly IJwtService _jwtService;
    private readonly ITenantContext _tenantContext;

    protected readonly IMyPortalDbContext _context;

    public LoginCommandHandler(IJwtService jwtService, IMyPortalDbContext context, ITenantContext tenantContext)
    {
        _jwtService = jwtService;
        _context = context;
        _tenantContext = tenantContext;
    }

    public async Task<bool> HandleAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        var data = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.token);

        var result = await _context.CustomerAccounts.Where(x => x.Uid == data.Uid)
            .Select(y => y.TenantId).FirstOrDefaultAsync(cancellationToken);

        if (result != Guid.Empty)
        {
            var user = await FirebaseAuth.DefaultInstance.GetUserAsync(data.Uid);
            if (!user.CustomClaims.ContainsKey("tenantId"))
            {
                await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(data.Uid, new Dictionary<string, object>
                {
                    { "tenantId", data.TenantId }
                });
            }

            return true;

        }

        return false;

    }
}
