using Domain.Models;
using Domain.Validators;
using FluentValidation;


namespace Domain.Validation.Validators
{
    public class ItemOrderValidator : AbstractValidator<ItemOrder>
    {
        public ItemOrderValidator(string paramName) 
        {

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage((string.Format(ExceptionMessage.GreaterThanZero, paramName)));

            RuleFor(x => x.ProductId)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName));

        }
    }
}
