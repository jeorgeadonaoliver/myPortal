using myPortal.Authentication.Application.Abstraction.Authentication;

namespace myPortal.Authentication.Api.Middleware;

public class TenantResolutionMiddleware
{
    private readonly RequestDelegate _next;

    public TenantResolutionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITenantContext tenantContext) 
    {

        if (context.Request.Headers.TryGetValue("x-tenant-id", out var tenantId) && !string.IsNullOrEmpty(tenantId))
        {
            tenantContext.SetTenantId(tenantid: tenantId);
        }


        await _next(context);
    }

}
