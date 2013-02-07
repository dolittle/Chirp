using System;
using Bifrost.Validation;
using Chirp.Concepts;
using FluentValidation;

namespace Chirp.Domain.Chirping.Commands
{
    public class ChirpMessageBusinessValidator : CommandBusinessValidator<ChirpMessage>
    {
        readonly Func<ChirperId, bool> _chirperExists;
        readonly Func<ChirperId, ChirpId, bool> _chirpIsNotDuplicate;

        public ChirpMessageBusinessValidator(Func<ChirperId, bool> chirperExists, Func<ChirperId, ChirpId, bool> chirpIsNotDuplicate)
        {
            _chirperExists = chirperExists;
            _chirpIsNotDuplicate = chirpIsNotDuplicate;

            RuleFor(c => c.Chirper)
                .Must(BeAnExistingChirper)
                .WithMessage("The chriper with Id '{PropertyValue}' does not exist");
            ModelRule()
                .Must(NotBeADuplicateChirp)
                .WithMessage("A message with Id '{PropertyValue}' already exists.");
        }

        bool BeAnExistingChirper(ChirperId chirper)
        {
            return _chirperExists.Invoke(chirper);
        }

        bool NotBeADuplicateChirp(ChirpMessage chirp)
        {
            return _chirpIsNotDuplicate.Invoke(chirp.Chirper, chirp.Chirp.Id);
        }
    }
}