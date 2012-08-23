using Bifrost.Validation;
using FluentValidation;

namespace Chirp.Domain.Users.Commands
{
    public class ResetPasswordInputValidator : CommandInputValidator<ResetPassword>
    {
        public ResetPasswordInputValidator()
        {
            RuleFor(c => c.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }
}
