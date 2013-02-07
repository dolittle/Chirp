using Bifrost.Validation;
using Chirp.Concepts.Validation;
using FluentValidation;

namespace Chirp.Domain.Chirping.Commands
{
    public class DeleteChirpInputValidator : CommandInputValidator<DeleteChirp>
    {
        public DeleteChirpInputValidator()
        {
            RuleFor(c => c.ChirpedBy).Cascade(CascadeMode.StopOnFirstFailure)
                .MustBeAValidChirperId();
            RuleFor(c => c.ChirpToDelete).Cascade(CascadeMode.StopOnFirstFailure)
                .MustBeAValidChirpId("ChirpToDelete");
        }
    }
}