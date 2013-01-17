using Bifrost.Validation;
using FluentValidation;

namespace Chirp.Concepts.Validation
{
    public class ChirperIdInputValidator : Validator<ChirperId>
    {
        public ChirperIdInputValidator()
        {
            RuleFor(p => p.Value)
                .NotEmpty().WithName("ChirperId");
        }
    }
}