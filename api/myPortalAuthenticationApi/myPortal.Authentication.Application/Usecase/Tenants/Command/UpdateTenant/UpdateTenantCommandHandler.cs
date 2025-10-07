using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Tenants.Command.UpdateTenant
{
    internal class UpdateTenantCommandHandler : IRequestHandler<UpdateTenantCommand, Guid>
    {

        protected readonly IUnitOfWork unitOfWiork;

        public Task<Guid> HandleAsync(UpdateTenantCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
