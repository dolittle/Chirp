using Bifrost.Validation;
using Chirp.Concepts.Validation;
using FluentValidation;

namespace Chirp.Domain.Messaging.Commands
{
    public class DeleteChirpInputValidator : CommandInputValidator<DeleteChirp>
    {
        public DeleteChirpInputValidator()
        {
            RuleFor(c => c.PublishedBy).Cascade(CascadeMode.StopOnFirstFailure)
                .MustBeAValidPublisherId();
            RuleFor(c => c.ChirpToDelete).Cascade(CascadeMode.StopOnFirstFailure)
                .MustBeAValidMessageId("ChirpToDelete");
        }
    }
}