using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Helper;
using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Application.Abstraction.Service;

namespace myPortal.Authentication.Application.Usecase.Tenants.Command.CreateTenant;

public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, Guid>
{
    protected readonly IUnitOfWork _context;
    private readonly ITenantService _tenantService;

    private readonly IValidationHelper _validationHelperl;

    public CreateTenantCommandHandler(IUnitOfWork context, ITenantService tenantService, IValidationHelper validationHelper)
    {
        _context = context;
        _validationHelperl = validationHelper;
        _tenantService = tenantService;
    }

    public async Task<Guid> HandleAsync(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var newTenantId = await _context.ExecuteInTransactionAsync(
            async(db, ct) => {
                try {

                    await ProcessCommandValidation(request, ct);

                    var tenant = request.ToEntities();
                    await _tenantService.CreateAsync(tenant, ct);

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
