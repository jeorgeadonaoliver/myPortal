using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Application.Usecase.Authentication.Command.Login;
using myPortal.Authentication.Application.Usecase.Authentication.Command.VerifyOtp;

namespace myPortal.Authentication.Api.Endpoint
{
    public static class AuthEndpoint
    {
        public static IEndpointRouteBuilder MapAuthEndpoint(this IEndpointRouteBuilder app) 
        {
            app.MapPost("/auth/otp", (HttpContext httpContext, VerifyOtpCommand command, IRequestDispatcher dispatcher, CancellationToken cancellationToken) =>
            {
                var uid = httpContext.User.FindFirst("user_id")?.Value;
                if (uid == null) return Results.Unauthorized();
                var response = dispatcher.Send(command with { uid = uid }, cancellationToken);

                return Results.Ok(new { Success = response });
            })
            .RequireAuthorization()
            .WithOpenApi();

            app.MapPost("/auth/login", async (LoginCommand cmd, IRequestDispatcher dispatcher, CancellationToken cancellationToken) =>
            {

                var isAuthorize = await dispatcher.Send(cmd, cancellationToken);

                return Results.Ok(new { success = isAuthorize });

            })
            .WithOpenApi();
            

            return app;
        }
    }
}
