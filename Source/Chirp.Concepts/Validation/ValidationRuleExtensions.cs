using FluentValidation;

namespace Chirp.Concepts.Validation
{
    public static class ValidationRuleExtensions
    {
        public static IRuleBuilderOptions<T, ChirperId> MustBeAValidChirperId<T>(this IRuleBuilder<T, ChirperId> ruleBuilder, string propertyName = "")
        {
            return ruleBuilder
                .NotNull()
                .SetValidator(new ChirperIdInputValidator());
        }

        public static IRuleBuilderOptions<T, ChirpId> MustBeAValidChirpId<T>(this IRuleBuilder<T, ChirpId> ruleBuilder, string propertyName = "")
        {
            return ruleBuilder
                .NotNull()
                .SetValidator(new ChirpIdInputValidator());
        } 
    }
}