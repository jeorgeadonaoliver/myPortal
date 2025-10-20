using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using myPortal.Authentication.Application.Abstraction.Data;

namespace myPortal.Authentication.Infrastructure.Cache;

internal class CacheService : ICacheService
{
    private readonly IMemoryCache _cache;
    private readonly ICacheKeyProvider _cacheKeyProvider;

    public CacheService(IMemoryCache cache, ICacheKeyProvider cacheKeyProvider)
    {
        _cache = cache;
        _cacheKeyProvider = cacheKeyProvider;
    }

    public Task<T?> GetAsync<T>(string id, CancellationToken cancellationToken = default)
    {
        string cacheKey = _cacheKeyProvider.GetCacheKey(id);
        if (_cache.TryGetValue(cacheKey, out var value) && value is T typedValue)
        {
            return Task.FromResult(typedValue);
        }

        return Task.FromResult(default(T)!);
    }

    public Task SetAsync<T>(string id, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
    {
        var options = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(10)
        };

        string cacheKey = _cacheKeyProvider.GetCacheKey(id);
        _cache.Set(cacheKey, value, options);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(string id, CancellationToken cancellationToken = default)
    {
        string cacheKey = _cacheKeyProvider.GetCacheKey(id);
        _cache.Remove(cacheKey);
        return Task.CompletedTask;
    }
}
