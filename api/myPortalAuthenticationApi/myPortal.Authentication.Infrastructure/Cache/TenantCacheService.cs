using Microsoft.Extensions.Caching.Memory;
using myPortal.Authentication.Application.Abstraction.Data;

namespace myPortal.Authentication.Infrastructure.Cache
{
    public class TenantCacheService : ITenantCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ICacheService _cacheService;

        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(30);

        public TenantCacheService(IMemoryCache memoryCache, ICacheService cacheService)
        {
            _memoryCache = memoryCache;
            _cacheService = cacheService;
        }
        public Task<string?> GetCacheTenantId(string id, CancellationToken cancellationToken = default)
        {
            return _cacheService.GetAsync<string?>(id: id, cancellationToken);
        }

        public Task RemoveCacheTenantId(string id, CancellationToken cancellationToken = default)
        {
            _cacheService.RemoveAsync(id: id, cancellationToken);
            return Task.CompletedTask;
        }

        public Task SetCacheTenantId(string id, CancellationToken cancellationToken = default)
        {
            _cacheService.SetAsync(id: id, value: id, _cacheDuration, cancellationToken);
            return Task.CompletedTask;
        }

    }
}
