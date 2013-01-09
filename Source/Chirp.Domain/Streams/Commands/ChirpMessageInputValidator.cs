using Bifrost.Validation;
using Bifrost.Views;
using Chirp.Concepts.Validation;
using FluentValidation;

namespace Chirp.Domain.Streams.Commands
{
    public class ChirpMessageInputValidator : CommandInputValidator<ChirpMessage>
    {
        public ChirpMessageInputValidator()
        {
            RuleFor(c => c.PublisherId).Cascade(CascadeMode.StopOnFirstFailure)
                .MustBeAValidPublisherId();
            RuleFor(c => c.Message).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty();
            RuleFor(c => c.Message.Content).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().When(MessageIsNotNull)
                .Length(1, Message.MaxLength).When(MessageIsNotNull);
        }

        bool MessageIsNotNull(ChirpMessage command )
        {
            return command.Message != null;
        }
    }
}