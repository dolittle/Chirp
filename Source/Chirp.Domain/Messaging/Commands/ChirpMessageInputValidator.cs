using Bifrost.Validation;
using Chirp.Concepts.Validation;
using FluentValidation;

namespace Chirp.Domain.Messaging.Commands
{
    public class ChirpMessageInputValidator : CommandInputValidator<ChirpMessage>
    {
        public ChirpMessageInputValidator()
        {
            RuleFor(c => c.Publisher).Cascade(CascadeMode.StopOnFirstFailure)
                .MustBeAValidPublisherId();
            RuleFor(c => c.Message).Cascade(CascadeMode.StopOnFirstFailure)
                .MustBeAValidMessage();
        }
    }
}