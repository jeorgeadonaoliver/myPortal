using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Tenants.Command.UpdateTenant;

public class UpdateTenantCommand : IRequest<Guid>
{
    public Guid TenantId { get; set; }

    public string TenantName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public DateOnly? LeaseStartDate { get; set; }

    public DateOnly? LeaseEndDate { get; set; }

    public string TenantStatus { get; set; } = null!;

    public DateTime? ModifiedDate { get; set; }
}

