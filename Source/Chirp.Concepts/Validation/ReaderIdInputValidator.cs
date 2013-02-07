using Bifrost.Validation;
using FluentValidation;

namespace Chirp.Concepts.Validation
{
    public class ReaderIdInputValidator : Validator<ReaderId>
    {
        public ReaderIdInputValidator()
        {
            RuleFor(p => p.Value)
                .NotEmpty().WithName("ReaderId");
        }
    }
}