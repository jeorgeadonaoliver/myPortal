using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Infrastructure.Request;

public class RequestHandlerWrapper<TRequest, TResponse> : IRequestHandlerWrapper where TRequest : IRequest<TResponse>
{
    private readonly IRequestHandler<TRequest, TResponse> _handler;

    public RequestHandlerWrapper(IRequestHandler<TRequest, TResponse> handler)
    {
        _handler = handler ?? throw new ArgumentNullException(nameof(handler));
    }

    public async Task<object> Handle(object request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var result = await _handler.HandleAsync((TRequest)request, cancellationToken);
        return result ?? throw new InvalidOperationException("Handler returned a null response.");
    }
}