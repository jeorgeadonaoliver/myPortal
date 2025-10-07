namespace myPortal.Authentication.Application.Abstraction.Data
{
    public interface ICacheManager<T>
    {
        Task CheckCacheByKey(Guid id, bool isToCahcheIfNull, T value);
    }
}
