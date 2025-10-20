namespace myPortal.Authentication.Application.Abstraction.Data
{
    public interface ICacheKeyProvider
    {
        string GetCacheKey(string userId);
    }
}
