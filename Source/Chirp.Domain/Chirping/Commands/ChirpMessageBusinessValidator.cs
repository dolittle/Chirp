using System;
using Bifrost.Validation;
using Chirp.Concepts;
using FluentValidation;

namespace Chirp.Domain.Chirping.Commands
{
    public class ChirpMessageBusinessValidator : CommandBusinessValidator<ChirpMessage>
    {
        readonly Func<ChirperId, bool> _publisherExists;
        readonly Func<Chirp, bool> _messageIsUnique;

        public ChirpMessageBusinessValidator(Func<ChirperId, bool> publisherExists, Func<Chirp, bool> messageIsUnique)
        {
            _publisherExists = publisherExists;
            _messageIsUnique = messageIsUnique;

            RuleFor(c => c.Chirper)
                .Must(BeAnExistingPublisher)
                .WithMessage("The publisher with Id '{PropertyValue}' does not exist");
            RuleFor(c => c.Chirp)
                .Must(MustBeAUniqueMessage)
                .WithMessage("A message with Id '{PropertyValue}' already exists.");
        }

        bool BeAnExistingPublisher(ChirperId chirper)
        {
            return _publisherExists.Invoke(chirper);
        }

        bool MustBeAUniqueMessage(Chirp chirpId)
        {
            return _messageIsUnique.Invoke(chirpId);
        }
    }
}