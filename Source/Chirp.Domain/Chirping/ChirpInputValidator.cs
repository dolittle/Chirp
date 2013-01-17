using Bifrost.Validation;
using Chirp.Concepts.Validation;
using FluentValidation;

namespace Chirp.Domain.Chirping
{
    public class ChirpInputValidator : Validator<Chirp>
    {
        public ChirpInputValidator()
        {
            RuleFor(c => c.Id).Cascade(CascadeMode.StopOnFirstFailure)
                .MustBeAValidChirpId();
            RuleFor(c => c.Content).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Length(1, Chirp.MaxLength);
        }
    }
}