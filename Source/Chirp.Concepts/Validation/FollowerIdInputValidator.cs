using Bifrost.Validation;
using FluentValidation;

namespace Chirp.Concepts.Validation
{
    public class FollowerIdInputValidator : Validator<FollowerId>
    {
        public FollowerIdInputValidator()
        {
            RuleFor(p => p.Value)
                .NotEmpty().WithName("FollowerId");
        }
    }
}