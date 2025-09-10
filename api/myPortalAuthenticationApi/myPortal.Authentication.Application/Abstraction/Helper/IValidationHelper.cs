using FluentValidation;

namespace myPortal.Authentication.Application.Abstraction.Helper;

public interface IValidationHelper
{
    Task ValidateAsync<TCommand>(TCommand command, IValidator<TCommand> validator, CancellationToken cancellationToken)
        where TCommand : class;
}
