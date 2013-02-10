using System;
using Bifrost.Validation;
using Chirp.Concepts;
using FluentValidation;

namespace Chirp.Domain.Follow.Commands
{
    public class UnfollowChirperBusinessValidator : CommandBusinessValidator<UnfollowChirper>
    {
        readonly Func<FollowerId, ChirperId, bool> _follows;
        readonly Func<ChirperId, bool> _chirperExists;

        public UnfollowChirperBusinessValidator(Func<FollowerId, ChirperId, bool> follows, Func<ChirperId, bool> chirperExists)
        {
            _follows = follows;
            _chirperExists = chirperExists;
            ModelRule()
                .Must(BeFollowingTheChirperAlready)
                .WithMessage("You are not following this Chirper");
            RuleFor(f => f.Chirper)
                .Must(BeAnExistingChirper)
                .WithMessage("The Chirper does not exist");
        }

        bool BeFollowingTheChirperAlready(UnfollowChirper followChirper)
        {
            return _follows.Invoke(followChirper.Follower, followChirper.Chirper);
        }

        bool BeAnExistingChirper(ChirperId chirperId)
        {
            return _chirperExists.Invoke(chirperId);
        }
    }
}