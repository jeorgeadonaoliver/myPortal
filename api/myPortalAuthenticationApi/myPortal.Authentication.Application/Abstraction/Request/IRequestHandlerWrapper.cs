namespace myPortal.Authentication.Application.Abstraction.Request;

public interface IRequestHandlerWrapper
{
    Task<object> Handle(object request, CancellationToken cancellationToken);
}

