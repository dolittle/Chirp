using System;
using Bifrost.Validation;
using Chirp.Concepts;
using FluentValidation;

namespace Chirp.Domain.Follow.Commands
{
    public class FollowChirperBusinessValidator : CommandBusinessValidator<FollowChirper>
    {
        readonly Func<FollowerId, ChirperId, bool> _follows;
        readonly Func<ChirperId, bool> _chirperExists;

        public FollowChirperBusinessValidator(Func<FollowerId, ChirperId, bool> follows, Func<ChirperId,bool> chirperExists)
        {
            _follows = follows;
            _chirperExists = chirperExists;
            ModelRule()
                .Must(NotBeFollowingTheChirperAlready)
                .WithMessage("You are already following this Chirper");
            RuleFor(f => f.Chirper)
                .Must(BeAnExistingChirper)
                .WithMessage("The Chirper does not exist");
        }

        bool NotBeFollowingTheChirperAlready(FollowChirper followChirper)
        {
            return !_follows.Invoke(followChirper.Follower, followChirper.Chirper);
        }

        bool BeAnExistingChirper(ChirperId chirperId)
        {
            return _chirperExists.Invoke(chirperId);
        }
    }
}