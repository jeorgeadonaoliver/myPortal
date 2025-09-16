using myPortal.Authentication.Application.Abstraction.Authentication;
using OtpNet;

namespace myPortal.Authentication.Infrastructure.Authentication;

internal class MfaService : IMfaService
{
    public string GenerateSecretKey()
    {
        var secretKey = KeyGeneration.GenerateRandomKey(20);
        return Base32Encoding.ToString(secretKey);
    }

    public bool VerifyTotp(string secretKey, string userCode)
    {
        var bytes = Base32Encoding.ToBytes(secretKey);
        var totp = new Totp(bytes);
        return totp.VerifyTotp(userCode, out _, new VerificationWindow(2, 2));
    }
}
