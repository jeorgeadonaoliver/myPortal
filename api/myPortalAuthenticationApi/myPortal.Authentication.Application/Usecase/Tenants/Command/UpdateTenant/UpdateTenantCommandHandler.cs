using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Tenants.Command.UpdateTenant;

public class UpdateTenantCommandHandler : IRequestHandler<UpdateTenantCommand, Guid>
{
    protected readonly IUnitOfWork _unitOfWiork;

    public UpdateTenantCommandHandler(IUnitOfWork unitOfWiork)
    {
        _unitOfWiork = unitOfWiork;
    }

    public async Task<Guid> HandleAsync(UpdateTenantCommand request, CancellationToken cancellationToken)
    {
        var id = await _unitOfWiork.ExecuteInTransactionAsync(
            async (db, ct) => {

                try { 
                    db.Tenants.Update(request.ToEntity());

                    await db.SaveChangesAsync(ct);
                    return request.TenantId;
                }
                catch 
                {
                    return Guid.Empty;
                }
            }, cancellationToken);

        return id;
    }
}
