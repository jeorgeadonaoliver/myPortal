using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Helper;
using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Usecase.Tenants.Command.CreateTenant;

public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, Guid>
{
    protected readonly IUnitOfWork _context;
    private readonly IValidationHelper _validationHelperl;

    public CreateTenantCommandHandler(IUnitOfWork context, IValidationHelper validationHelper)
    {
        _context = context;
        _validationHelperl = validationHelper;
    }

    public async Task<Guid> HandleAsync(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var newTenantId = await _context.ExecuteInTransactionAsync(
            async(db, ct) => {
                try {

                    await ProcessCommandValidation(request, ct);

                    var tenant = new Tenant()
                    {
                        TenantId = Guid.NewGuid(),
                        TenantName = request.TenantName,
                        TenantStatus = "Active",
                        CreatedDate = DateTime.UtcNow,
                        Email = request.Email,
                        LeaseEndDate = request.LeaseEndDate,
                        LeaseStartDate = request.LeaseStartDate,
                        PhoneNumber = request.PhoneNumber
                    };

                    var id = db.Tenants.Add(tenant);
                    await db.SaveChangesAsync(ct);

                    return tenant.TenantId;

                } 
                catch 
                {
                    return Guid.Empty;
                }
            }, cancellationToken);

        return newTenantId;
    }

    private async Task ProcessCommandValidation(CreateTenantCommand cmd, CancellationToken cancellationToken) 
    {
        var validator = new CreateTenantCommandValidation(_context.Context);
        await _validationHelperl.ValidateAsync(cmd, validator, cancellationToken);
    }
}
