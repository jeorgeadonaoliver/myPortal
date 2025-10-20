using Microsoft.AspNetCore.Http;
using myPortal.Authentication.Application.Abstraction.Authentication;
using System.Security.Claims;

namespace myPortal.Authentication.Infrastructure.Authentication
{
    public class HttpContextCurrentUser : ICurrentUser
    {
        private readonly ClaimsPrincipal _user;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextCurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        string? ICurrentUser.UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue("user_id");
    }
}
