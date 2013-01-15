using Bifrost.Validation;
using Chirp.Concepts.Validation;
using FluentValidation;

namespace Chirp.Domain.Messaging
{
    public class MessageInputValidator : Validator<Message>
    {
        public MessageInputValidator()
        {
            RuleFor(c => c.Id).Cascade(CascadeMode.StopOnFirstFailure)
                .MustBeAValidMessageId();
            RuleFor(c => c.Content).Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .Length(1, Message.MaxLength);
        }
    }
}