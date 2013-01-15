using System;
using Bifrost.Domain;
using Bifrost.Testing;
using Bifrost.Validation;
using Chirp.Concepts;
using Chirp.Domain.Messaging;
using Chirp.Domain.Messaging.Commands;
using Machine.Specifications;
using Moq;

namespace Chirp.Domain.Specs.Messaging.when_deleting.given
{
    public class a_scenario_with_a_delete_chirp_command
    {
        protected static PublisherId publisher_id;
        protected static MessageStream message_stream;
        protected static Mock<IAggregatedRootRepository<MessageStream>> stream_repository;
        static MessageCommandHandler command_handler;
        static ICanValidate<DeleteChirp> input_validator;
        static ICanValidate<DeleteChirp> business_validator;

        protected static CommandScenario<DeleteChirp> command_scenario;

        Establish context = () =>
        {
            publisher_id = publishers.valid;
            message_stream = new MessageStream(publisher_id);
            stream_repository = new Mock<IAggregatedRootRepository<MessageStream>>();
            input_validator = new DeleteChirpInputValidator();
            business_validator = new DeleteChirpBusinessValidator(Funcs.PublisherExists, Funcs.MessageHasBeenPublishedByPublisher);
            command_handler = new MessageCommandHandler(stream_repository.Object);

            command_scenario = new CommandScenario<DeleteChirp>();
            command_scenario.ValidatedWith(input_validator, business_validator);
            command_scenario.HandledBy(command_handler);

            stream_repository.Setup(r => r.Get(Moq.It.IsAny<Guid>()))
                .Returns((Guid id) => command_scenario.RegisterAggregateRoot(new MessageStream(id)));
        };
    }
}