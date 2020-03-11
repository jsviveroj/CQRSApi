using Domain.Commands;
using FluentValidation;

namespace CQRS_Example.Validators
{
    public class CreateCustomerValidator : AbstractValidator<AddCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(m => m.Name).NotEmpty().WithMessage($"Name couldn't be empty.");
            RuleFor(m => m.Phone).NotEmpty().WithMessage($"Phone couldn't be empty.");
        }
    }
}
