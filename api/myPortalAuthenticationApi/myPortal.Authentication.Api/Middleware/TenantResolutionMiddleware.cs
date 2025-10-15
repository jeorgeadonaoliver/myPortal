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
        if (context.User.Identity.IsAuthenticated)
        {
            var tenantIdClaim = context.User.FindFirst(TenantIdClaimType);

            if (tenantIdClaim != null && !string.IsNullOrEmpty(tenantIdClaim.Value))
            {
                tenantContext.SetTenantId(tenantid: tenantIdClaim.Value);
            }
        }
        //if (context.Request.Headers.TryGetValue(TenantIdClaimType, out var tenantId) && !string.IsNullOrEmpty(tenantId))
        //{
        //    tenantContext.SetTenantId(tenantid: tenantId);
        //}


        await _next(context);
    }

}
