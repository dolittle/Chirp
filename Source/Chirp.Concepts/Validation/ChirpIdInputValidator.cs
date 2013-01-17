using Bifrost.Validation;
using FluentValidation;

namespace Chirp.Concepts.Validation
{
    public class ChirpIdInputValidator : Validator<ChirpId>
    {
        public ChirpIdInputValidator()
        {
            RuleFor(p => p.Value)
                .NotEmpty().WithName("ChirpId");
        }
    }
}