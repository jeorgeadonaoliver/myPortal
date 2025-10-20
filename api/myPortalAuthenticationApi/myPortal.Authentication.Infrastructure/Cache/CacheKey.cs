using myPortal.Authentication.Application.Abstraction.Data;

namespace myPortal.Authentication.Infrastructure.Cache
{
    public static class CacheKey 
    {
        public const string UserByIdTemplate = "User:ById:{0}";
    }
}
