using FluentValidation;

namespace Chirp.Domain.Messaging
{
    public static class ValidationRuleExtensions
    {
        public static IRuleBuilderOptions<T, Message> MustBeAValidMessage<T>(this IRuleBuilder<T, Message> ruleBuilder, string propertyName = "")
        {
            return ruleBuilder
                .NotNull()
                .SetValidator(new MessageInputValidator());
        }  
    }
}