using Domain.Models;
using Domain.Validators;
using FluentValidation;


namespace Domain.Validation.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator(string paramName)
        {
            RuleFor(t => t.CategoryName)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName));
        }
    }
}
