using myPortal.Authentication.Application.Abstraction.Authentication;
using OtpNet;

namespace myPortal.Authentication.Infrastructure.Authentication;

internal class MfaService : IMfaService
{
    public bool VerifyTotp(string secretKey, string userCode)
    {
        if (string.IsNullOrWhiteSpace(secretKey) || string.IsNullOrWhiteSpace(userCode))
            return false;

        userCode = userCode.Trim().Replace(" ", "");

        var bytes = Base32Encoding.ToBytes(secretKey);
        var totp = new Totp(bytes, step: 30, mode: OtpHashMode.Sha1, totpSize: 6);
        return totp.VerifyTotp(userCode, out _, new VerificationWindow(2, 2));
    }
}
