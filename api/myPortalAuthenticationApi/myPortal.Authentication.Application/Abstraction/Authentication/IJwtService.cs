namespace myPortal.Authentication.Application.Abstraction.Authentication;

public interface IJwtService
{
    Task<string> GenerateTokenAsync(string email, string password, CancellationToken cancellationToken);
}
