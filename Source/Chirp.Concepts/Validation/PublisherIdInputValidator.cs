using Bifrost.Validation;
using FluentValidation;

namespace Chirp.Concepts.Validation
{
    public class PublisherIdInputValidator : Validator<PublisherId>
    {
        public PublisherIdInputValidator()
        {
            RuleFor(p => p.Value)
                .NotEmpty().WithName("PublisherId");
        }
    }
}