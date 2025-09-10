using FirebaseAdmin.Auth;
using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Usecase.Customer.Command.RegisterCustomer;

public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Guid>
{
    protected readonly IUnitOfWork _context;

    public RegisterCustomerCommandHandler(IUnitOfWork context)
    {
        _context = context;
    }

    public async Task<Guid> HandleAsync(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        var validator = new RegisterCustomerCommandValidation(_context.Context);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
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
                       Uid = uid
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
                   throw;
               }
           },
           cancellationToken);

            return newCustomerId;
        }

        Console.WriteLine(validationResult.ToString());

        return Guid.Empty;

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
}
