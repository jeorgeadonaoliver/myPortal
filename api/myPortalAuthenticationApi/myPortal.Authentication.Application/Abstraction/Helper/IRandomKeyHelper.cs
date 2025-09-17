namespace myPortal.Authentication.Application.Abstraction.Helper;

public interface IRandomKeyHelper
{
    public string GenerateSecret();
}
