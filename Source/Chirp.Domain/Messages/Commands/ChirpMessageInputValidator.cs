using Bifrost.Validation;
using FluentValidation;

namespace Chirp.Domain.Messages.Commands
{
    public class ChirpMessageInputValidator : CommandInputValidator<ChirpMessage>
    {
        public ChirpMessageInputValidator()
        {
            RuleFor(c => c.Message).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty();
            RuleFor(c => c.Message.Content).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().When(c => c.Message != null)
                .Length(1, Message.MaxLength).When(c => c.Message != null);
        }
    }
}