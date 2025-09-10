using FluentValidation;
using myPortal.Authentication.Application.Abstraction.Helper;

namespace myPortal.Authentication.Application.Helper
{
    public class ValidationHelper : IValidationHelper
    {
        public async Task ValidateAsync<TCommand>(TCommand command, IValidator<TCommand> validator, CancellationToken cancellationToken)
            where TCommand : class
        {
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                Console.WriteLine("Validation failed: " + string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
