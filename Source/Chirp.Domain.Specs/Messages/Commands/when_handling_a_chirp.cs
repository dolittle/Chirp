using System;
using Bifrost.Commands;
using Chirp.Domain.Messages.Commands;
using Chirp.Events.Messages;
using Machine.Specifications;
using Bifrost.MSpec.Events;

namespace Chirp.Domain.Specs.Messages.Commands
{
    [Subject(typeof (MessageCommandHandler))]
    public class when_handling_a_chirp : given.a_scenario_with_a_<ChirpMessage>
    {
        static ChirpMessage chirp_message;
        static DateTime current_time;
        static CommandResult result;

        Establish context = () =>
                                {
                                    current_time = DateTime.UtcNow;

                                    chirp_message = new ChirpMessage
                                                {
                                                    Publisher = publishers.valid,
                                                    Message = messages.valid_chirp
                                                };
                                };

        Because of = () =>
                         {
                            using(Bifrost.Time.SystemClock.SetNowTo(current_time))
                            {
                                result = command_scenario.IsHandled(chirp_message);
                            }
                         };

        It should_chirp_the_message = () => chirp.ShouldHaveEvent<MessageChirped>().AtBeginning().Where(
            e =>
                {
                    e.Content.ShouldEqual(messages.valid_chirp.Content);
                    e.PublishedBy.ShouldEqual(publishers.valid_publisher_id);
                    e.PublishedAt.ShouldEqual(current_time);
                });
    }
}