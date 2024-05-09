using FluentValidation;

namespace Domain.Validators
{
    public static class ValidateException
    {
        public static T ValidateWithErrors<T>(this IValidator<T> validator, T value)
        {
            var validationResult = validator.Validate(value);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            return value;
        }
    }
}
