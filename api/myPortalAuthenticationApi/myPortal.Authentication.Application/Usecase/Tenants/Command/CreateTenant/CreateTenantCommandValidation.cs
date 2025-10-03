using FluentValidation;
using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Application.Abstraction.Data;

namespace myPortal.Authentication.Application.Usecase.Tenants.Command.CreateTenant;

internal class CreateTenantCommandValidation : AbstractValidator<CreateTenantCommand>
{
    protected readonly IMyPortalDbContext _context;

    public CreateTenantCommandValidation(IMyPortalDbContext context)
    {
        _context = context;

        RuleFor(x => x.TenantName)
            .NotEmpty().WithMessage("Tenant Name is required");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .MustAsync(IsEmailUnique).WithMessage("Email Address must be unique!");
        
    }

    private async Task<bool> IsEmailUnique(string? email, CancellationToken cancellationToken) 
    {
        var row = await _context.Tenants.Where(c => c.Email == email).FirstOrDefaultAsync();

        if(row is not null)
            return false;

        return true;
    }
      
}
