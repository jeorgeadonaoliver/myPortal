using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPortal.Authentication.Application.Abstraction.Authentication;

public interface IMfaService
{
    public string GenerateSecretKey();

    public bool VerifyTotp(string secretKey, string userCode);
}
