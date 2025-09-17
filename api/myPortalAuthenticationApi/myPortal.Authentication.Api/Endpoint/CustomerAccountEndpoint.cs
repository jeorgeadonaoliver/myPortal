using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Application.Usecase.Customer.Command.LoginCustomer;
using myPortal.Authentication.Application.Usecase.Customer.Command.RegisterCustomer;

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
        .WithOpenApi();

        app.MapPost("/auth/login", async (LoginCustomerCommand command, IRequestDispatcher dispatcher, CancellationToken cancellationToken) =>
        {
            var result = await dispatcher.Send(command, cancellationToken);
            return Results.Ok(result);
        })
        .WithName("Login")
        .WithOpenApi();

        app.MapGet("/auth/otp", (HttpContext httpContext, CancellationToken cancellationToken) =>
        {

                var uid = httpContext.User.FindFirst("user_id")?.Value; // Firebase stores UID here
            return Results.Ok(new { Message = "hello world!", FirebaseUid = uid });
        })
        .RequireAuthorization()
        .WithOpenApi();

        return app;
    }
}
