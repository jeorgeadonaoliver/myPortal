namespace myPortal.Authentication.Application.Abstraction.Data;

public interface IUserCacheService
{
    public Task<string?> GetCachUserId(string id, CancellationToken cancellationToken = default);

    public Task SetCachUserId(string id, CancellationToken cancellationToken = default);

    public Task RemoveCachUserId(string id, CancellationToken cancellationToken = default);
}
