using FluentValidation;
using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Application.Abstraction.Data;

namespace myPortal.Authentication.Application.Usecase.Customer.Command.RegisterCustomer;

public class RegisterCustomerCommandValidation : AbstractValidator<RegisterCustomerCommand>
{
    protected readonly IMyPortalDbContext _context;

    public RegisterCustomerCommandValidation(IMyPortalDbContext context)
    {
        _context = context;

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(50).WithMessage("Email must not exceed 50 characters.")
            .MustAsync(IsEmailExistInFirebase).WithMessage("Email already Exist in Firebase!")
            .MustAsync(IsEmailExistInDb).WithMessage("Email already Exist in DB!");
    }


    public async Task<bool> IsEmailExistInFirebase(string email, CancellationToken cancellationToken) 
    {
        try 
        {
            var user = await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance.GetUserByEmailAsync(email, cancellationToken);
            if (user is not null)
                return false;

            return true;
        }
        catch (Exception ex)
        {
            //log error
            return true;
        }
    }

    public async Task<bool> IsEmailExistInDb(string email, CancellationToken cancellationToken)
    {
        return  !await _context.CustomerAccounts.AnyAsync(x => x.Email == email, cancellationToken);
    }
}
