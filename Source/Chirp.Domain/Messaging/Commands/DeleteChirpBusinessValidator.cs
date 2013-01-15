using System;
using Bifrost.Validation;
using Chirp.Concepts;
using FluentValidation;

namespace Chirp.Domain.Messaging.Commands
{
    public class DeleteChirpBusinessValidator : CommandBusinessValidator<DeleteChirp>
    {
        readonly Func<PublisherId, bool> _publisherExists;
        readonly Func<MessageId, bool> _messageHasBeenPublishedByPublisher;

        public DeleteChirpBusinessValidator(Func<PublisherId, bool> publisherExists, Func<MessageId, bool> messageHasBeenPublishedByPublisher)
        {
            _publisherExists = publisherExists;
            _messageHasBeenPublishedByPublisher = messageHasBeenPublishedByPublisher;
            
            RuleFor(c => c.PublishedBy)
                .Must(BeAnExistingPublisher)
                .WithMessage("The publisher with Id '{PropertyValue}' does not exist");
            RuleFor(c => c.ChirpToDelete)
                .Must(BePublishedByThisPublisher)
                .WithMessage("No message with Id '{PropertyValue}' has been published by this publisher. ");
        }

        bool BeAnExistingPublisher(PublisherId publisher)
        {
            return _publisherExists.Invoke(publisher);
        }

        bool BePublishedByThisPublisher(MessageId messageId)
        {
            return _messageHasBeenPublishedByPublisher.Invoke(messageId);
        }
    }
}