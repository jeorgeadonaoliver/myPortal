namespace myPortal.Authentication.Application.Abstraction.Authentication;

public interface IJwtService
{
    Task<string> GenerateTokenAsync(string token, CancellationToken cancellationToken);
}
