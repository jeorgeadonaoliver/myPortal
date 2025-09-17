using myPortal.Authentication.Application.Abstraction.Request;

namespace myPortal.Authentication.Application.Usecase.Authentication.Command.VerifyOtp;

public record VerifyOtpCommand(string otp, string uid) : IRequest<bool>;
