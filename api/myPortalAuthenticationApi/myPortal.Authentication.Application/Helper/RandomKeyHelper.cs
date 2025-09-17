using myPortal.Authentication.Application.Abstraction.Helper;
using OtpNet;

namespace myPortal.Authentication.Application.Helper;

internal class RandomKeyHelper : IRandomKeyHelper
{
    public string GenerateSecret()
    {
        var secretKey = KeyGeneration.GenerateRandomKey(20);
        return Base32Encoding.ToString(secretKey);
    }
}
