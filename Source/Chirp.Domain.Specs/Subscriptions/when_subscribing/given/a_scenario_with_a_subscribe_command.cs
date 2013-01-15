using System;
using Bifrost.Domain;
using Bifrost.Testing;
using Bifrost.Validation;
using Chirp.Domain.Subscriptions.Commands;
using Machine.Specifications;
using sub = Chirp.Domain.Subscriptions;
using Chirp.Concepts;
using Moq;

namespace Chirp.Domain.Specs.Subscriptions.when_subscribing.given
{
    public class a_scenario_with_a_subscribe_command
    {
        protected static SubscriberId subscriber_id;
        protected static sub.Subscriptions subscriptions;
        protected static Mock<IAggregatedRootRepository<sub.Subscriptions>> subscriptions_repository;
        static SubscriptionsCommandHandler command_handler;
        static ICanValidate<SubscribeToPublisher> input_validator;
        static ICanValidate<SubscribeToPublisher> business_validator;

        protected static CommandScenario<SubscribeToPublisher> command_scenario;

        Establish context = () =>
        {
            subscriber_id = subscribers.valid;
            subscriptions = new sub.Subscriptions(subscriber_id);
            subscriptions_repository = new Mock<IAggregatedRootRepository<sub.Subscriptions>>();
            input_validator = new SubscribeToPublisherInputValidator();
            business_validator = new SubscribeToPublisherBusinessValidator();
            command_handler = new SubscriptionsCommandHandler(subscriptions_repository.Object);

            command_scenario = new CommandScenario<SubscribeToPublisher>();
            command_scenario.ValidatedWith(input_validator, business_validator);
            command_scenario.HandledBy(command_handler);

            subscriptions_repository.Setup(r => r.Get(Moq.It.IsAny<Guid>()))
                .Returns((Guid id) => command_scenario.RegisterAggregateRoot(new sub.Subscriptions(id)));
        };
    } 
}