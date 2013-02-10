using Bifrost.Validation;
using Chirp.Concepts.Validation;

namespace Chirp.Domain.Follow.Commands
{
    public class UnfollowChirperInputValidator : CommandInputValidator<UnfollowChirper>
    {
        public UnfollowChirperInputValidator()
        {
            RuleFor(f => f.Follower)
                .MustBeAValidFollowerId();
            RuleFor(f => f.Chirper)
                .MustBeAValidChirperId();
        }
    }
}