namespace myPortal.Authentication.Application.Abstraction.User
{
    public interface ICustomerService
    {
        public Task<string> RegisterCustomerAsync(string email, string password);
    }
}
