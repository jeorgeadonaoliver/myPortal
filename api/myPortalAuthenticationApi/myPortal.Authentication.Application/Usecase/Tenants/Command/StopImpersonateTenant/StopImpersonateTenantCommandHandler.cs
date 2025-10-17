using myPortal.Authentication.Application.Abstraction.Authentication;
using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Tenants.Command.StopImpersonateTenant
{
    internal class StopImpersonateTenantCommandHandler : IRequestHandler<StopImpersonateTenantCommand, bool>
    {
        private readonly ITenantContext _tenantContext;

        public StopImpersonateTenantCommandHandler(ITenantContext tenantContext)
        {
            _tenantContext = tenantContext;
        }

        public Task<bool> HandleAsync(StopImpersonateTenantCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                _tenantContext.ClearImpersonation();
                return Task.FromResult(true);
            } 
            catch 
            {
                return Task.FromResult(false);
            } 
        }
    }
}
