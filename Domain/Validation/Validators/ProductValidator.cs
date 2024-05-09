using Domain.Models;
using Domain.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validation.Validators
{
    public  class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator(string paramName)
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName))
                .Matches(RegexPatterns.OnlyLetters).WithMessage(ExceptionMessage.OnlyLetters)
                .MaximumLength(50).WithMessage(ExceptionMessage.charactersCount);

            RuleFor(x => x.UnitOfMeasure)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName))
                .MaximumLength(50).WithMessage(ExceptionMessage.charactersCount);

            //RuleFor(x => x.ExpiryDate)
            //   .GreaterThan(DateTime.Now).WithMessage((string.Format(ExceptionMessage.dateFormat, paramName)));


            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName));

            RuleFor(x => x.SupplierId)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName));
        }
    }
}
