using CMS.Application.Dtos.Customers;
using FluentValidation;

namespace CMS.Application.Validators.Customers;

public class CustomerDtoValidator : AbstractValidator<CustomerDto>
{
    public CustomerDtoValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(c => c.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(c => c.Email)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(c => c.Phone)
            .MaximumLength(15);

        RuleFor(c => c.Address)
            .MaximumLength(250);
    }
}
