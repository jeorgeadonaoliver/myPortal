using FirebaseAdmin.Auth;
using myPortal.Authentication.Application.Abstraction.User;

namespace myPortal.Authentication.Infrastructure.Firbase;

internal sealed class CustomerService : ICustomerService
{
    public async Task<string> RegisterCustomerAsync(string email, string password)
    {
        var userArgs = new UserRecordArgs()
        {
            Email = email,
            Password = password,
            Disabled = false,
        };

        await FirebaseAuth.DefaultInstance.CreateUserAsync(userArgs);

        return userArgs.Uid;
    }
}
