using System;
using Bifrost.Validation;
using Chirp.Concepts;
using FluentValidation;

namespace Chirp.Domain.Messaging.Commands
{
    public class ChirpMessageBusinessValidator : CommandBusinessValidator<ChirpMessage>
    {
        readonly Func<PublisherId, bool> _publisherExists;
        readonly Func<Message, bool> _messageIsUnique;

        public ChirpMessageBusinessValidator(Func<PublisherId, bool> publisherExists, Func<Message, bool> messageIsUnique)
        {
            _publisherExists = publisherExists;
            _messageIsUnique = messageIsUnique;

            RuleFor(c => c.Publisher)
                .Must(BeAnExistingPublisher)
                .WithMessage("The publisher with Id '{PropertyValue}' does not exist");
            RuleFor(c => c.Message)
                .Must(MustBeAUniqueMessage)
                .WithMessage("A message with Id '{PropertyValue}' already exists.");
        }

        bool BeAnExistingPublisher(PublisherId publisher)
        {
            return _publisherExists.Invoke(publisher);
        }

        bool MustBeAUniqueMessage(Message messageId)
        {
            return _messageIsUnique.Invoke(messageId);
        }
    }
}