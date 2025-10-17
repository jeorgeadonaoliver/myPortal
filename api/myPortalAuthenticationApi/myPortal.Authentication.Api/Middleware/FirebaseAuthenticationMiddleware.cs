using FirebaseAdmin.Auth;
using System.Security.Claims;

namespace myPortal.Authentication.Api.Middleware;

public class FirebaseAuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public FirebaseAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string? token = context.Request.Headers["Authorization"]
            .FirstOrDefault()?.Replace("Bearer ", "");

        if (!string.IsNullOrEmpty(token))
        {
            try
            {
                var decoded = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);
                var claims = decoded.Claims.Select(c => new Claim(c.Key, c.Value.ToString()!)).ToList();
                var identity = new ClaimsIdentity(claims, "firebase");
                context.User = new ClaimsPrincipal(identity);
            }
            catch
            {
                // invalid token, ignore or handle
            }
        }

        await _next(context);
    }
}
