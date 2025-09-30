namespace myPortal.Authentication.Domain.PortalDb
{
    public class Tenant
    {
        public Guid TenantId { get; set; }

        public string TenantName { get; set; } = null!;

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateOnly? LeaseStartDate { get; set; }

        public DateOnly? LeaseEndDate { get; set; }

        public string TenantStatus { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
