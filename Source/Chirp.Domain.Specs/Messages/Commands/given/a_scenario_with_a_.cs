using System;
using Bifrost.Commands;
using Bifrost.Domain;
using Bifrost.Validation;
using Chirp.Domain.Messages.Commands;
using Machine.Specifications;
using Moq;
using m = Chirp.Domain.Messages;

namespace Chirp.Domain.Specs.Messages.Commands.given
{
    public class a_scenario_with_a_<T> where  T: class, ICommand
    {
        static Mock<IAggregatedRootFactory<m.Chirp>> chirp_factory;
        static MessageCommandHandler command_handler;
        static ICanValidate<T> input_validator;
        protected static m.Chirp chirp;
        protected static CommandScenarioBase<T> command_scenario;

        Establish context = () =>
                                {
                                    chirp = null;
                                    input_validator = (ICanValidate<T>)new ChirpMessageInputValidator();

                                    chirp_factory = new Mock<IAggregatedRootFactory<Domain.Messages.Chirp>>();
                                    chirp_factory.Setup(f => f.Create(Moq.It.IsAny<Guid>())).Callback((Guid id) => chirp = new m.Chirp(id)).Returns(() => chirp);
                                    command_handler = new MessageCommandHandler(chirp_factory.Object);

                                    command_scenario = new CommandScenarioBase<T>();
                                    command_scenario.InputValidatedWith(input_validator);
                                    command_scenario.HandledBy(command_handler);
                                };
    }
}
