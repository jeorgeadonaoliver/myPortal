using myPortal.Authentication.Application.Abstraction.Authentication;
using myPortal.Authentication.Domain.Firebase;
using System.Net.Http.Json;

namespace myPortal.Authentication.Infrastructure.Authentication;

internal sealed class JwtService : IJwtService
{
    private readonly HttpClient _httpClient;

    public JwtService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GenerateTokenAsync(string email, string password, CancellationToken cancellationToken)
    {
        var request = new { 
            email,
            password,
            returnSecureToken = true
        };

        var response = await _httpClient.PostAsJsonAsync("", request, cancellationToken);

        var authToken = await response.Content.ReadFromJsonAsync<AuthToken>(cancellationToken) ?? new AuthToken();

        return authToken.IdToken;

    }
}
