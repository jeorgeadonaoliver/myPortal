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
        var tenantId = context.Request.Headers["x-tenant-ID"].FirstOrDefault();

        if (!string.IsNullOrEmpty(tenantId)) 
        {
            tenantContext.SetTenantId(tenantId);
        }

        await _next(context);
    }

}
