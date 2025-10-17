namespace myPortal.Authentication.Application.Abstraction.Authentication;

public interface ITenantContext
{
    string? CurrentTenantId { get; }

    string? OriginalTenantId { get; }
    
    bool IsImpersonating { get; }

    void SetTenantId(string tenantId);

    void ImpersonateTenant(string tenantId);

    void ClearImpersonation();
}
