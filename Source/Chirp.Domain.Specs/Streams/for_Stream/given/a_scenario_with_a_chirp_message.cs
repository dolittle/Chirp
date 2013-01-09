using System;
using Bifrost.Domain;
using Bifrost.Testing;
using Bifrost.Validation;
using Chirp.Concepts;
using Chirp.Domain.Streams;
using Chirp.Domain.Streams.Commands;
using Machine.Specifications;
using Moq;

namespace Chirp.Domain.Specs.Streams.for_Stream.given
{
    public class a_scenario_with_a_chirp_message 
    {
        protected static PublisherId publisher_id;
        protected static Stream stream;
        protected static Mock<IAggregatedRootRepository<Stream>> stream_repository; 
        static MessageCommandHandler command_handler;
        static ICanValidate<ChirpMessage> input_validator;
        protected static CommandScenario<ChirpMessage> command_scenario;

        Establish context = () =>
                                {
                                    publisher_id = Guid.NewGuid();
                                    stream = new Stream(publisher_id);
                                    stream_repository = new Mock<IAggregatedRootRepository<Stream>>();
                                    input_validator = new ChirpMessageInputValidator();
                                    command_handler = new MessageCommandHandler(stream_repository.Object);

                                    command_scenario = new CommandScenario<ChirpMessage>();
                                    command_scenario.InputValidatedWith(input_validator);
                                    command_scenario.HandledBy(command_handler);

                                    stream_repository.Setup(r => r.Get(Moq.It.IsAny<Guid>()))
                                        .Returns((Guid id) => command_scenario.RegisterAggregateRoot(new Stream(id)));
                                };
    }
}
