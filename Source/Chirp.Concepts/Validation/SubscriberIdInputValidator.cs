using Bifrost.Validation;
using FluentValidation;

namespace Chirp.Concepts.Validation
{
    public class SubscriberIdInputValidator : Validator<SubscriberId>
    {
        public SubscriberIdInputValidator()
        {
            RuleFor(p => p.Value)
                .NotEmpty().WithName("SubscriberId");
        }
    }
}