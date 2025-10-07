namespace myPortal.Authentication.Application.Abstraction.Data
{
    public interface  ICacheKeyService
    {
        string GetTenantKey(Guid tenantId);

        string GetAllTenantsKey();
    }
}
