using myPortal.Authentication.Application.Abstraction.Data;

namespace myPortal.Authentication.Infrastructure.Cache
{
    internal class CacheManger<T> : ICacheManager<T>
    {
        private readonly ICacheKeyService _cacheKeyService;
        private readonly ICacheService _cacheService;

        public CacheManger(ICacheKeyService cacheKeyService, ICacheService cacheService)
        {
            _cacheKeyService = cacheKeyService;
            _cacheService = cacheService;
        }

        public async Task CheckCacheByKey(Guid id, bool isToCahcheIfNull, T value)
        {
            if (isToCahcheIfNull) 
            {
                var cacheKey = _cacheKeyService.GetTenantKey(id);
                var isEmpty = await _cacheService.GetAsync<T>(cacheKey);

                if (isEmpty is null) 
                {
                    await _cacheService.SetAsync<T>(cacheKey, value , TimeSpan.FromMinutes(5));
                }
            }
        }
    }
}
