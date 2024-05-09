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
    public class SupplierValidator : AbstractValidator<Supplier>
    {
        public SupplierValidator(string paramName) 
        {
            RuleFor(supplier => supplier.CompanyName)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName))
                .MaximumLength(50).WithMessage(ExceptionMessage.charactersCount);

            RuleFor(supplier => supplier.ContactInfo)
                .NotNull().WithMessage(string.Format(ExceptionMessage.NullException, paramName))
                .NotEmpty().WithMessage(string.Format(ExceptionMessage.EmptyException, paramName))
                .MaximumLength(100).WithMessage(ExceptionMessage.charactersCount);
        }
    }
}
