using System;
using Bifrost.Validation;
using Chirp.Concepts;
using FluentValidation;

namespace Chirp.Domain.Chirping.Commands
{
    public class DeleteChirpBusinessValidator : CommandBusinessValidator<DeleteChirp>
    {
        readonly Func<ChirperId, bool> _chirperExists;
        readonly Func<ChirperId, ChirpId, bool> _chirpHasBeenChirpedByChirper;

        public DeleteChirpBusinessValidator(Func<ChirperId, bool> chirperExists, Func<ChirperId,ChirpId, bool> chirpHasBeenChirpedByChirper)
        {
            _chirperExists = chirperExists;
            _chirpHasBeenChirpedByChirper = chirpHasBeenChirpedByChirper;
            
            RuleFor(c => c.ChirpedBy)
                .Must(BeAnExistingChirper)
                .WithMessage("The chirper with Id '{PropertyValue}' does not exist");
            ModelRule()
                .Must(BeChirpedByThisChirper)
                .WithMessage("No message with Id '{PropertyValue}' has been chirped by this chirper. ");
        }

        bool BeAnExistingChirper(ChirperId chirper)
        {
            return _chirperExists.Invoke(chirper);
        }

        bool BeChirpedByThisChirper(DeleteChirp deleteChirp)
        {
            return _chirpHasBeenChirpedByChirper.Invoke(deleteChirp.ChirpedBy,deleteChirp.ChirpToDelete);
        }
    }
}