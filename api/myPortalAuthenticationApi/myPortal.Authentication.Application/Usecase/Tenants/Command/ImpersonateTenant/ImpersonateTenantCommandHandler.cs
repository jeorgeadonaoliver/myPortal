using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Tenants.Command.ImpersonateTenant
{
    internal class ImpersonateTenantCommandHandler //: IRequestHandler<ImpersonateTenantCommand, bool>
    {
        //private readonly ITenantContext _tenantContext;
        //public ImpersonateTenantCommandHandler(ITenantContext tenantContext)
        //{
        //    _tenantContext = tenantContext;
        //}

        //public Task<bool> HandleAsync(ImpersonateTenantCommand request, CancellationToken cancellationToken)
        //{
        //    try 
        //    {
        //        _tenantContext.ImpersonateTenant(request.tenantId.ToString());
        //        string originalTenantId = _tenantContext.OriginalTenantId?? "";
        //        string currentTenantId = _tenantContext.CurrentTenantId ?? "";

        //        return Task.FromResult(true);

        //    }
        //    catch 
        //    {
        //        return Task.FromResult(false);
        //    }
            
        //}
    }
}
