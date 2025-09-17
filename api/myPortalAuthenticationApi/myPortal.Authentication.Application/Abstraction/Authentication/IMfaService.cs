namespace myPortal.Authentication.Application.Abstraction.Authentication;

public interface IMfaService
{
    public bool VerifyTotp(string secretKey, string userCode);
}
