using System;
using Bifrost.Commands;
using Bifrost.Globalization;
using Bifrost.Validation;
using Moq;

namespace Chirp.Domain.Specs
{
    public class CommandScenarioBase<T>  where T :  class, ICommand
    {
        readonly Mock<ICommandValidatorProvider> command_validator_provider;
        readonly  ICommandValidationService command_validation_service;
        readonly ICommandCoordinator command_coordinator;
        readonly Mock<ILocalizer> localizer;
        readonly Mock<DynamicCommandFactory> dynamic_command_factory;
        readonly Mock<ICommandContext> command_context;
        readonly Mock<ICommandContextManager> command_context_manager;
        readonly Mock<ICommandHandlerManager> command_handler_manager;
        readonly ICanValidate<T> null_validator = new NullCommandInputValidator();
        
        dynamic command_handler;
        ICanValidate<T> input_validator;
        ICanValidate<T> business_validator;

        public CommandScenarioBase()
        {
            command_context = new Mock<ICommandContext>();
            command_context_manager = new Mock<ICommandContextManager>();
            command_context_manager.Setup(ccm => ccm.EstablishForCommand(It.IsAny<ICommand>())).Returns(command_context.Object);
            command_handler_manager = new Mock<ICommandHandlerManager>();
            command_handler_manager.Setup(m => m.Handle(It.IsAny<ICommand>())).Callback((ICommand c) => command_handler.Handle((dynamic)c));

            localizer = new Mock<ILocalizer>();
            dynamic_command_factory = new Mock<DynamicCommandFactory>();
            command_validator_provider = new Mock<ICommandValidatorProvider>();
            command_validation_service = new CommandValidationService(command_validator_provider.Object);

            command_coordinator = new CommandCoordinator(command_handler_manager.Object,command_context_manager.Object,command_validation_service,
                                                                                                                dynamic_command_factory.Object, localizer.Object);

            input_validator = null_validator;
            business_validator = null_validator;
        }

        public void ValidatedWith( ICanValidate<T> inputValidator, ICanValidate<T> businessValidator )
        {
            input_validator = inputValidator;
            business_validator = businessValidator;
        }

        public void InputValidatedWith( ICanValidate<T> inputValidator )
        {
            ValidatedWith(inputValidator,null_validator);
        }

        public void BusinessRulesValidatedWith( ICanValidate<T> businessValidator )
        {
            ValidatedWith(null_validator,businessValidator);
        }

        public void HandledBy(ICommandHandler commandHandler)
        {
            command_handler = commandHandler;
        }

        public CommandResult IsHandled(ICommand command)
        {
            if(command_handler == null)
                throw new Exception("You must specify a command handler before calling CommandIsHandled");

            command_validator_provider.Setup(p => p.GetInputValidatorFor(command)).Returns(input_validator);
            command_validator_provider.Setup(p => p.GetBusinessValidatorFor(command)).Returns(business_validator);

            return command_coordinator.Handle(command);
        }
    }
}