using myPortal.Authentication.Application.Abstraction.Authentication;

namespace myPortal.Authentication.Infrastructure.Authentication;

public class TenantContext : ITenantContext
{
    public string? CurrentTenantId { get; private set; }

    public string? OriginalTenantId { get; private set; }

    public bool IsImpersonating { get; private set; }

    public void ClearImpersonation()
    {
        OriginalTenantId = null;
        CurrentTenantId = null;
        IsImpersonating = false;
    }

    public void SetOriginalTenantId(string tenantid)
    {
        if (OriginalTenantId == null)
            OriginalTenantId = CurrentTenantId;

        CurrentTenantId = tenantid;
    }

    public void SetTenantId(string tenantid)
    {
        CurrentTenantId = tenantid;
    }
}
