using myPortal.Authentication.Application.Abstraction.Data;

namespace myPortal.Authentication.Infrastructure.Cache
{
    internal class CacheKeySerivce : ICacheKeyService
    {
        public string GetAllTenantsKey() => $"Tenants:All";

        public string GetTenantKey(Guid tenantId) => $"Tenants:{tenantId}:Info";

    }
}
