using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Tenants.Query.GetTenantById;

public class GetTenantByIdQueryHandler : IRequestHandler<GetTenantByIdQuery, GetTenantByIdDto>
{
    private readonly IMyPortalDbContext _context;

    public GetTenantByIdQueryHandler(IMyPortalDbContext context)
    {
        _context = context;
    }

    public async Task<GetTenantByIdDto> HandleAsync(GetTenantByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _context.Tenants.Where(x => x.TenantId == request.id)
            .Select(selector: y => y.ToDto())
            .FirstOrDefaultAsync(cancellationToken);

        return data ?? new GetTenantByIdDto();
    }
}
