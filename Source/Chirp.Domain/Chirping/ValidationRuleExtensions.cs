using FluentValidation;

namespace Chirp.Domain.Chirping
{
    public static class ValidationRuleExtensions
    {
        public static IRuleBuilderOptions<T, Chirp> MustBeAValidChirp<T>(this IRuleBuilder<T, Chirp> ruleBuilder, string propertyName = "")
        {
            return ruleBuilder
                .NotNull()
                .SetValidator(new ChirpInputValidator());
        }  
    }
}