
using Microsoft.Extensions.Caching.Memory;
using myPortal.Authentication.Application.Abstraction.Data;

namespace myPortal.Authentication.Infrastructure.Cache
{
    public class UserCacheService : IUserCacheService
    {
        private readonly ICacheService _cacheService;
        private readonly IMemoryCache _cache;

        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(30);

        public UserCacheService(IMemoryCache cache, ICacheService cacheService)
        {
            _cache = cache;
            _cacheService = cacheService;
        }

        public Task<string?> GetCachUserId(string id, CancellationToken cancellationToken = default)
        {
            return _cacheService.GetAsync<string?>(id: id, cancellationToken);
        }

        public Task RemoveCachUserId(string id, CancellationToken cancellationToken = default)
        {
            _cacheService.RemoveAsync(id: id, cancellationToken);
            return Task.CompletedTask;
        }

        public Task SetCachUserId(string id, CancellationToken cancellationToken = default)
        {
            _cacheService.SetAsync(id: id, value: id, _cacheDuration, cancellationToken);
            return Task.CompletedTask;
        }
    }
}
