namespace myPortal.Authentication.Application.Abstraction.Data;

public interface ITenantCacheService
{
    public Task<string?> GetCacheTenantId(string id, CancellationToken cancellationToken = default);

    public Task SetCacheTenantId(string id, CancellationToken cancellationToken = default);

    public Task RemoveCacheTenantId(string id, CancellationToken cancellationToken = default);
}
