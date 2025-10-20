namespace myPortal.Authentication.Application.Abstraction.Authentication;

public interface ICurrentUser
{
    string? UserId { get; }
}
