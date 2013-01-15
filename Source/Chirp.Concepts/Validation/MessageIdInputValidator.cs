using Bifrost.Validation;
using FluentValidation;

namespace Chirp.Concepts.Validation
{
    public class MessageIdInputValidator : Validator<MessageId>
    {
        public MessageIdInputValidator()
        {
            RuleFor(p => p.Value)
                .NotEmpty().WithName("MessageId");
        }
    }
}