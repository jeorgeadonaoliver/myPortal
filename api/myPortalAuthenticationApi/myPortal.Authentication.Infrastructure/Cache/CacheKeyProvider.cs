using myPortal.Authentication.Application.Abstraction.Data;

namespace myPortal.Authentication.Infrastructure.Cache;

internal class CacheKeyProvider : ICacheKeyProvider
{
    public string GetCacheKey(string userId)
    {
        return string.Format(CacheKey.UserByIdTemplate, userId);
    }
}
