namespace myPortal.Authentication.Application.Abstraction.Request;

public interface IRequestDispatcher
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
}
