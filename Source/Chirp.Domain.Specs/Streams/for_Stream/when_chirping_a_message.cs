using System;
using Bifrost.Commands;
using Bifrost.MSpec.Extensions;
using Chirp.Domain.Specs.Streams.for_Stream.given;
using Chirp.Domain.Streams.Commands;
using Chirp.Events.Messages;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Streams.for_Stream
{
    [Subject(typeof (MessageCommandHandler))]
    public class when_chirping_a_message : a_scenario_with_a_chirp_message
    {
        static ChirpMessage chirp_message;
        static DateTime current_time;
        static CommandResult result;

        Establish context = () =>
                                {
                                    current_time = DateTime.UtcNow;

                                    chirp_message = new ChirpMessage
                                                {
                                                    PublisherId = publishers.valid,
                                                    Message = messages.valid_chirp_with_no_tags
                                                };
                                };

        Because of = () =>
                         {
                            using(Bifrost.Time.SystemClock.SetNowTo(current_time))
                            {
                                result = command_scenario.IsHandled(chirp_message);
                            }
                         };

        It should_persist_the_events = () => command_scenario.HasGeneratedEvents.ShouldBeTrue();
        It should_chirp_the_message = () => command_scenario.GeneratedEvents.ShouldHaveEvent<MessageChirped>().AtBeginning().Where(
            e =>
                {
                    e.Content.ShouldEqual(messages.valid_chirp_with_no_tags.Content);
                    e.PublishedBy.ShouldEqual(publishers.valid.Value);
                    e.PublishedAt.ShouldEqual(current_time);
                });
    }
}