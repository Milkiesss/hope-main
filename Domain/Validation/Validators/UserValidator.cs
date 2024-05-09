using Domain.Models;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator(string paramName) 
        {
            RuleFor(user => user.Email)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName))
                .Matches(RegexPatterns.Email).WithMessage(ExceptionMessage.EmailException);

            RuleFor(user => user.PasswordHash)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName));

            RuleFor(user => user.FullName)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName))
                .MaximumLength(50).WithMessage(ExceptionMessage.charactersCount);


            RuleFor(user => user.Address)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName))
                .MaximumLength(50).WithMessage(ExceptionMessage.charactersCount);
        }
    }
}
