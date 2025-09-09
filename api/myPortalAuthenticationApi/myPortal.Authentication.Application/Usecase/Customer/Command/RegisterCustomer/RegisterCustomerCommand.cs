using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Customer.Command.RegisterCustomer;

public class RegisterCustomerCommand : IRequest<Guid>
{
    public string Email { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string MiddletName { get; set; }

    public string LastName { get; set; }

    public string ContactNumber { get; set; }

    public string Uid { get; set; }
}
