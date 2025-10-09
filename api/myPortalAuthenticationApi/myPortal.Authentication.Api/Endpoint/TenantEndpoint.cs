using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Application.Usecase.Tenants.Command.CreateTenant;
using myPortal.Authentication.Application.Usecase.Tenants.Query.GetTenant;
using myPortal.Authentication.Application.Usecase.Tenants.Query.GetTenantById;

namespace myPortal.Authentication.Api.Endpoint;

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

        app.MapPost("/createtenant", async (CreateTenantCommand cmd ,IRequestDispatcher dispatcher, CancellationToken cancellationToken) =>
        {
            var result = await dispatcher.Send(cmd, cancellationToken);
            return Results.Ok(result);
        })
        .WithName("CreateTenant")
        .WithOpenApi();

        app.MapGet("/gettenantbyid", async (Guid id, IRequestDispatcher dispatcher, CancellationToken cancellationToken) =>
        {
            var result = await dispatcher.Send(new GetTenantByIdQuery(id), cancellationToken);
            return Results.Ok(result);
        })
        .WithName("GetTenantbyId")
        .WithOpenApi();

        return app;
    }
}
