using Bifrost.Validation;
using Chirp.Concepts.Validation;

namespace Chirp.Domain.Follow.Commands
{
    public class FollowChirperInputValidator : CommandInputValidator<FollowChirper>
    {
        public FollowChirperInputValidator()
        {
            RuleFor(f => f.Follower)
                .MustBeAValidFollowerId();
            RuleFor(f => f.Chirper)
                .MustBeAValidChirperId();
        }
    }
}