using myPortal.Authentication.Application.Abstraction.Authentication;

namespace myPortal.Authentication.Api.Middleware;

public class TenantResolutionMiddleware
{
    private readonly RequestDelegate _next;
    private const string TenantIdClaimType = "tenantId";

    public TenantResolutionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITenantContext tenantContext) 
    {
        var user = context.User;
        if (user.Identity?.IsAuthenticated == true)
        {
            var tenantIdId = user.FindFirst(TenantIdClaimType)?.Value;

            if (!string.IsNullOrEmpty(tenantIdId))
            {
                tenantContext.SetTenantId(tenantId: tenantIdId);
            }
        }

        await _next(context);
    }

}
