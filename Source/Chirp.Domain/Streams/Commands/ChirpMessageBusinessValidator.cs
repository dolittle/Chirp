using System;
using Bifrost.Validation;
using Chirp.Concepts;
using FluentValidation;

namespace Chirp.Domain.Streams.Commands
{
    public class ChirpMessageBusinessValidator : CommandBusinessValidator<ChirpMessage>
    {
        readonly Func<PublisherId, bool> _publisherExists;

        public ChirpMessageBusinessValidator(Func<PublisherId, bool> publisherExists)
        {
            _publisherExists = publisherExists;
            ModelRule()
                .Must(BeAnExistingPublisher)
                .WithMessage("The publisher with Id '{PropertyValue}' does not exist");
        }

        bool BeAnExistingPublisher(ChirpMessage command)
        {
            return _publisherExists.Invoke(command.PublisherId);
        }
    }
}