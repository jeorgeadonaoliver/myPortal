using Microsoft.EntityFrameworkCore;
using myPortal.Authentication.Application.Abstraction.Authentication;
using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Domain.PortalDb;

namespace myPortal.Authentication.Application.Usecase.Authentication.Command.VerifyOtp;

public class VerifyOtpCommandHandler : IRequestHandler<VerifyOtpCommand, bool>
{
    protected readonly IUnitOfWork _context;
    private readonly IMfaService _mfaservice;

    public VerifyOtpCommandHandler(IUnitOfWork context, IMfaService mfaservice)
    {
        _context = context;
        _mfaservice = mfaservice;
    }

    public async Task<bool> HandleAsync(VerifyOtpCommand request, CancellationToken cancellationToken)
    {
        try {
           bool isValid = await _context.ExecuteInTransactionAsync<bool>(
               async (db, ct) => {

                   var data = await db.CustomerAccounts
                       .Where(c => c.Uid == request.uid)
                       .Select(c => new { c.SecretKey, c.Id, c.TenantId })
                       .FirstOrDefaultAsync(ct);

                   var result = _mfaservice.VerifyTotp(data.SecretKey ?? "", request.otp);

                   if (result)
                   {
                       var userActivity = new CustomerLoginActivity
                       {
                           ActivityId = Guid.NewGuid(),
                           CustomerId = data.Id,
                           LoginTimestamp = DateTime.Now,
                           LoginMethod = "MFA_VERIFIED",
                       };

                       db.CustomerLoginActivities.Add(userActivity);
                       await db.SaveChangesAsync(ct);
                   }

                   return result;

               }, cancellationToken);

            return isValid;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during OTP verification: {ex.Message}");
            return false;
            
        }
    }
}
