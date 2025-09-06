using myPortal.Authentication.Application.Abstraction.Request;
using Microsoft.Extensions.DependencyInjection;

namespace myPortal.Authentication.Infrastructure.Request;

public class RequestDispatcher : IRequestDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public RequestDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        var requestType = request.GetType();
        var wrapperType = typeof(RequestHandlerWrapper<,>).MakeGenericType(requestType, typeof(TResponse));

        var wrapper = (IRequestHandlerWrapper)_serviceProvider.GetRequiredService(wrapperType);

        try
        {
            var response = (TResponse)await wrapper.Handle(request, cancellationToken);

            return response;
        }
        catch
        {
            throw;
        }
    }

}
