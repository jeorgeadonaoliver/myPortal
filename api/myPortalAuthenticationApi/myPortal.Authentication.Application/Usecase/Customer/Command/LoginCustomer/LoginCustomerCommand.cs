using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Customer.Command.LoginCustomer;

public record LoginCustomerCommand(string Email, string Password ) : IRequest<string>;
