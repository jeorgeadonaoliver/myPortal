using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Application.Usecase.Customer.Command.RegisterCustomer;

namespace myPortal.Authentication.Api.Endpoint
{
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
            .WithOpenApi(); ;

            return app;
        }
    }
}
