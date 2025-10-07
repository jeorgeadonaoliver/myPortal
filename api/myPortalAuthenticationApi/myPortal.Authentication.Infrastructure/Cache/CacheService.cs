using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using myPortal.Authentication.Application.Abstraction.Data;
using System.Text.Json;

namespace myPortal.Authentication.Infrastructure.Cache
{
    internal class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            _cache.TryGetValue(key, out T? value);
            return Task.FromResult(value);
        }

        public Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(10)
            };
            _cache.Set(key, value, options);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            _cache.Remove(key);
            return Task.CompletedTask;
        }
    }
}
