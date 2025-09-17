using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Authentication.Command.Login;

public record LoginCommand(string token) : IRequest<string>;
