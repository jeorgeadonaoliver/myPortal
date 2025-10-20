using FirebaseAdmin.Auth;
using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Application.Abstraction.Authentication;
using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Authentication.Command.Login;

internal class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
{
    private readonly IJwtService _jwtService;
    private readonly IUserCacheService _cacheService;
    protected readonly IMyPortalDbContext _context;

    public LoginCommandHandler(IJwtService jwtService, IMyPortalDbContext context, IUserCacheService cacheService)
    {
        _jwtService = jwtService;
        _context = context;
        _cacheService = cacheService;
    }

    public async Task<bool> HandleAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        var data = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(request.token);

        var result = await _context.CustomerAccounts.Where(x => x.Uid == data.Uid)
            .Select(y => y.TenantId).FirstOrDefaultAsync(cancellationToken);

        if (result != Guid.Empty)
        {
            //await _cacheService.SetAsync<string>(key: CacheKey.TenantId , value: result.ToString(), 
            //    TimeSpan.FromMinutes(30), 
            //    cancellationToken);

            await _cacheService.SetCachUserId(data.Uid, cancellationToken);

            return true;

        }

        return false;

    }
}
