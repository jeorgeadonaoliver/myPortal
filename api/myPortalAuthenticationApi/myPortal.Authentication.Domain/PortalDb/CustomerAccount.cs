namespace myPortal.Authentication.Domain.PortalDb;

public partial class CustomerAccount
{
    public Guid Id { get; set; }

    public Guid TenantId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public string Uid { get; set; }

    public string SecretKey { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
