using FirebaseAdmin.Auth;
using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Helper;
using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Usecase.Customer.Command.RegisterCustomer;

public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Guid>
{
    protected readonly IUnitOfWork _context;
    private readonly IValidationHelper _validationHelper;
    private readonly IRandomKeyHelper _randomKeyHelper;

    public RegisterCustomerCommandHandler(IUnitOfWork context, IValidationHelper validationHelper, IRandomKeyHelper randomKeyHelper)
    {
        _context = context;
        _validationHelper = validationHelper;
        _randomKeyHelper = randomKeyHelper;
    }

    public async Task<Guid> HandleAsync(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        await ProcessCommandValidation(request, cancellationToken);
        var newCustomerId = await _context.ExecuteInTransactionAsync<Guid>(
           async (db, ct) =>
           {
               string uid = string.Empty;

               try
               {
                   uid = await RegisterCustomerAccountInFirebase(request, ct);

                   if (string.IsNullOrEmpty(uid))
                   {
                       throw new Exception("Failed to create user in Firebase.");
                   }

                   var customer = new CustomerAccount()
                   {
                       Email = request.Email,
                       FirstName = request.FirstName,
                       LastName = request.LastName,
                       Id = Guid.NewGuid(),
                       MiddleName = request.MiddletName,
                       RoleId = 1,
                       Uid = uid,
                       SecretKey = _randomKeyHelper.GenerateSecret(),
                       CreatedAt = DateTime.UtcNow,
                   };

                   db.CustomerAccounts.Add(customer);

                   await db.SaveChangesAsync(ct);

                   return customer.Id;
               }
               catch (Exception ex)
               {
                   //log error
                   if (!string.IsNullOrEmpty(uid))
                   {
                       await FirebaseAuth.DefaultInstance.DeleteUserAsync(uid, ct);
                   }

                   return Guid.Empty;
               }
           },
           cancellationToken);

        return newCustomerId;
    }

    private async Task<string> RegisterCustomerAccountInFirebase(RegisterCustomerCommand command, CancellationToken cancellationToken)
    {
        var auth = FirebaseAuth.DefaultInstance;
        var userArgs = new UserRecordArgs
        {
            Email = command.Email,
            Password = command.Password,
            DisplayName = $"{command.FirstName} {command.LastName}",
        };

        UserRecord userRecord = await auth.CreateUserAsync(userArgs);
        return userRecord.Uid;
    }

    private async Task ProcessCommandValidation(RegisterCustomerCommand cmd, CancellationToken cancellationToken) 
    {
        var validator = new RegisterCustomerCommandValidation(_context.Context);

        await _validationHelper.ValidateAsync(cmd, validator, cancellationToken);
    }
}
