namespace myPortal.Authentication.Application.Abstraction.Data;

public interface ICacheService
{
    Task<T> GetAsync<T>(string id, CancellationToken cancellationToken = default);

    Task SetAsync<T>(string id, T value, TimeSpan? expiry = null, CancellationToken cancellationToken = default);

    Task RemoveAsync(string id, CancellationToken cancellationToken = default);
}
