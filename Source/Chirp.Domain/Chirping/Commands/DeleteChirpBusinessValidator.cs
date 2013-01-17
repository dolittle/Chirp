using System;
using Bifrost.Validation;
using Chirp.Concepts;
using FluentValidation;

namespace Chirp.Domain.Chirping.Commands
{
    public class DeleteChirpBusinessValidator : CommandBusinessValidator<DeleteChirp>
    {
        readonly Func<ChirperId, bool> _publisherExists;
        readonly Func<ChirpId, bool> _messageHasBeenPublishedByPublisher;

        public DeleteChirpBusinessValidator(Func<ChirperId, bool> publisherExists, Func<ChirpId, bool> messageHasBeenPublishedByPublisher)
        {
            _publisherExists = publisherExists;
            _messageHasBeenPublishedByPublisher = messageHasBeenPublishedByPublisher;
            
            RuleFor(c => c.ChirpedBy)
                .Must(BeAnExistingPublisher)
                .WithMessage("The publisher with Id '{PropertyValue}' does not exist");
            RuleFor(c => c.ChirpToDelete)
                .Must(BePublishedByThisPublisher)
                .WithMessage("No message with Id '{PropertyValue}' has been published by this publisher. ");
        }

        bool BeAnExistingPublisher(ChirperId chirper)
        {
            return _publisherExists.Invoke(chirper);
        }

        bool BePublishedByThisPublisher(ChirpId chirp_id)
        {
            return _messageHasBeenPublishedByPublisher.Invoke(chirp_id);
        }
    }
}