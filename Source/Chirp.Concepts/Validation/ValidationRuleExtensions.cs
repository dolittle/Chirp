using System;
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
    }
}