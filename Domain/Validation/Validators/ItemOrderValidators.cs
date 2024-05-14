using Domain.Models;
using Domain.Validators;
using FluentValidation;


namespace Domain.Validation.Validators
{
    public class ItemOrderValidators : AbstractValidator<ItemOrder>
    {
        public ItemOrderValidators(string paramName) 
        {
            RuleFor(x => x.Quantity)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName))
                .GreaterThan(0).WithMessage((string.Format(ExceptionMessage.GreaterThanZero, paramName)));
            RuleFor(x => x.Price)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName))
                .GreaterThan(0).WithMessage((string.Format(ExceptionMessage.GreaterThanZero, paramName)));
        }
    }
}
