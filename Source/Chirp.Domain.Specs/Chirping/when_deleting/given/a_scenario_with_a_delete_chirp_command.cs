using System;
using Bifrost.Domain;
using Bifrost.Testing;
using Bifrost.Validation;
using Chirp.Concepts;
using Chirp.Domain.Chirping;
using Chirp.Domain.Chirping.Commands;
using Machine.Specifications;
using Moq;

namespace Chirp.Domain.Specs.Chirping.when_deleting.given
{
    public class a_scenario_with_a_delete_chirp_command
    {
        protected static ChirperId chirper_id;
        protected static ChirpStream chirp_stream;
        protected static Mock<IAggregatedRootRepository<ChirpStream>> stream_repository;
        static ChirpCommandHandler command_handler;
        static ICanValidate<DeleteChirp> input_validator;
        static ICanValidate<DeleteChirp> business_validator;

        protected static CommandScenario<DeleteChirp> command_scenario;

        Establish context = () =>
        {
            chirper_id = chirpers.valid;
            chirp_stream = new ChirpStream(chirper_id);
            stream_repository = new Mock<IAggregatedRootRepository<ChirpStream>>();
            input_validator = new DeleteChirpInputValidator();
            business_validator = new DeleteChirpBusinessValidator(Funcs.PublisherExists, Funcs.MessageHasBeenPublishedByPublisher);
            command_handler = new ChirpCommandHandler(stream_repository.Object);

            command_scenario = new CommandScenario<DeleteChirp>();
            command_scenario.ValidatedWith(input_validator, business_validator);
            command_scenario.HandledBy(command_handler);

            stream_repository.Setup(r => r.Get(Moq.It.IsAny<Guid>()))
                .Returns((Guid id) => command_scenario.RegisterAggregateRoot(new ChirpStream(id)));
        };
    }
}