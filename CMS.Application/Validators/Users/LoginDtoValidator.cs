using CMS.Application.Dtos.Users;
using FluentValidation;

namespace CMS.Application.Validators.Users;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(c => c.UserName)
            .NotEmpty();

        RuleFor(c => c.Password)
            .NotEmpty();
    }
}
