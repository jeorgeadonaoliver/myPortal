using myPortal.Authentication.Application.Abstraction.Authentication;

namespace myPortal.Authentication.Infrastructure.Authentication;

public class TenantContext : ITenantContext
{
    public string? CurrentTenantId { get; private set; }

    public string? OriginalTenantId { get; private set; }

    public bool IsImpersonating { get; private set; }

    public void ClearImpersonation()
    {
        if (IsImpersonating == true)
        {
            CurrentTenantId = OriginalTenantId;
            CurrentTenantId = null;
            IsImpersonating = false;
        }
    }

    public void ImpersonateTenant(string tenantId)
    {
        if (IsImpersonating == false)
        {
            OriginalTenantId = CurrentTenantId;
            CurrentTenantId = tenantId;
            IsImpersonating = true;
        }
    }

    public void SetTenantId(string tenantId)
    {
        if(IsImpersonating == true)
            CurrentTenantId = tenantId;
    }
}
