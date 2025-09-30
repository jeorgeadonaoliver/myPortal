using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Application.Usecase.Tenant.Query.GetTenant;

namespace myPortal.Authentication.Api.Endpoint
{
    public static class TenantEndpoint
    {
        public static IEndpointRouteBuilder MapTenantEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/tenant", async (IRequestDispatcher dispatcher, CancellationToken cancellationToken) =>
            {
                var result = await dispatcher.Send(new GetTenantQuery(), cancellationToken);
                return Results.Ok(result);
            })
            .WithName("Tenant")
            .WithOpenApi();

            return app;
        }
    }
}
