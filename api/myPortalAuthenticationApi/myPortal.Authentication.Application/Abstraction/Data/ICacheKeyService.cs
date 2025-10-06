namespace myPortal.Authentication.Application.Abstraction.Data
{
    public interface  ITenantIdCacheService
    {
        string GetTenantKey(Guid tenantId);

        string GetAllTenantsKey();
    }
}
