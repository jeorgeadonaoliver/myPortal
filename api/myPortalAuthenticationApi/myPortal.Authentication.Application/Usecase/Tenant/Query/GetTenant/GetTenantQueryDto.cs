namespace myPortal.Authentication.Application.Usecase.Tenant.Query.GetTenant;

public class GetTenantQueryDto
{
    public Guid TenantId { get; set; }

    public string TenantName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime LeaseStartDate { get; set; }

    public DateTime LeaseEndDate { get; set; }

    public string TenantStatus { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
