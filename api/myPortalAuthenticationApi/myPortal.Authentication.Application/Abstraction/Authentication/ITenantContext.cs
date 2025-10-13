namespace myPortal.Authentication.Application.Abstraction.Authentication;

public interface ITenantContext
{
    string? CurrentTenantId { get; }

    string? OriginalTenantId { get; }
    
    bool IsImpersonating { get; }

    void SetTenantId(string tenantid);

    void SetOriginalTenantId(string tenantid);

    void ClearImpersonation();
}
