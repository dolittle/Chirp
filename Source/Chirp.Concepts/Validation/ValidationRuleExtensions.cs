using FluentValidation;

namespace Chirp.Concepts.Validation
{
    public static class ValidationRuleExtensions
    {
        public static IRuleBuilderOptions<T, PublisherId> MustBeAValidPublisherId<T>(this IRuleBuilder<T, PublisherId> ruleBuilder, string propertyName = "")
        {
            return ruleBuilder
                .NotNull()
                .SetValidator(new PublisherIdInputValidator());
        }

        public static IRuleBuilderOptions<T, MessageId> MustBeAValidMessageId<T>(this IRuleBuilder<T, MessageId> ruleBuilder, string propertyName = "")
        {
            return ruleBuilder
                .NotNull()
                .SetValidator(new MessageIdInputValidator());
        } 
    }
}