using Bifrost.Validation;
using FluentValidation;

namespace Chirp.Domain.Users.Commands
{
    public class LoginInputValidator : CommandInputValidator<Login>
    {
        public LoginInputValidator()
        {
            RuleFor(l => l.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(l => l.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
