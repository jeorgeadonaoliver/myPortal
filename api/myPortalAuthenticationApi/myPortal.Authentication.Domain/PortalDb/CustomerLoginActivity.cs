namespace myPortal.Authentication.Domain.PortalDb;

public partial class CustomerLoginActivity
{
    public Guid ActivityId { get; set; }

    public Guid CustomerId { get; set; }

    public Guid TenantId { get; set; }

    public DateTime LoginTimestamp { get; set; }

    public string? LoginMethod { get; set; }

    public string? IpAddress { get; set; }

    public string? DeviceInfo { get; set; }

}
