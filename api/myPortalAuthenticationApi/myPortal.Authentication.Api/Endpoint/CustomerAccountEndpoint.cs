using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Application.Usecase.Authentication.Command.VerifyOtp;
using myPortal.Authentication.Application.Usecase.Customer.Command.RegisterCustomer;
using myPortal.Authentication.Application.Usecase.Customer.Query.GetCustomer;
using myPortal.Authentication.Application.Usecase.Customer.Query.GetCustomerTenantByUid;

namespace myPortal.Authentication.Api.Endpoint;

public static class CustomerAccountEndpoint
{
    public static IEndpointRouteBuilder MapCustomerAccountEndpoint(this IEndpointRouteBuilder app) 
    {
        app.MapPost("/auth/register", async (RegisterCustomerCommand command, IRequestDispatcher dispatcher, CancellationToken cancellationToken)=>    
        { 
                var result = await dispatcher.Send(command, cancellationToken);
                return Results.Ok(result);
        })
        .WithName("Register")
        .RequireAuthorization()
        .WithOpenApi();

        app.MapPost("/auth/otp", (HttpContext httpContext, VerifyOtpCommand command, IRequestDispatcher dispatcher, CancellationToken cancellationToken) =>
        {
            var uid = httpContext.User.FindFirst("user_id")?.Value; 
            if (uid == null) return Results.Unauthorized();
            var response = dispatcher.Send(command with { uid = uid }, cancellationToken);

            return Results.Ok(new { Success = response });
        })
        .RequireAuthorization()
        .WithOpenApi();

        app.MapGet("/auth/getusers", (Guid tenantId,IRequestDispatcher dispatcher, CancellationToken cancellationToken) =>
        {
            var response = dispatcher.Send(new GetCustomerQuery(tenantId), cancellationToken);
            return Results.Ok(response.Result);
        })
        .WithOpenApi();

        app.MapGet("/auth/getuserbyuid", (string uid, IRequestDispatcher dispatcher, CancellationToken cancellationToken) =>
        {
            var response = dispatcher.Send(new GetCustomerTenantByUidQuery(uid), cancellationToken);
            return Results.Ok(response.Result);
        })
        .WithOpenApi();

        return app;
    }
}
