using Domain.Models;
using Domain.Validators;
using FluentValidation;

namespace Domain.Validation.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator(string paramName) 
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName));
        }
    }
}
