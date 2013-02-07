using Bifrost.Validation;
using Chirp.Concepts.Validation;
using FluentValidation;

namespace Chirp.Domain.Chirping.Commands
{
    public class ChirpMessageInputValidator : CommandInputValidator<ChirpMessage>
    {
        public ChirpMessageInputValidator()
        {
            RuleFor(c => c.Chirper).Cascade(CascadeMode.StopOnFirstFailure)
                .MustBeAValidChirperId();
            RuleFor(c => c.Chirp).Cascade(CascadeMode.StopOnFirstFailure)
                .MustBeAValidChirp();
        }
    }
}