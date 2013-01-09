using System;
using Bifrost.Commands;
using Chirp.Domain.Specs.Streams.for_Stream.given;
using Chirp.Domain.Streams.Commands;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Streams.for_Stream
{
    [Subject(typeof(MessageCommandHandler))]
    public class when_chirping_no_message : a_scenario_with_a_chirp_message
    {
        static ChirpMessage chirp_message;
        static DateTime current_time;
        static CommandResult result;

        Establish context = () =>
                                {
                                    current_time = DateTime.UtcNow;

                                    chirp_message = new ChirpMessage
                                                        {
                                                            PublisherId = publishers.valid
                                                        };
                                };

        Because of = () =>
                         {
                             using (Bifrost.Time.SystemClock.SetNowTo(current_time))
                             {
                                 result = command_scenario.IsHandled(chirp_message);
                             }
                         };

        It should_not_chirp_the_message = () => command_scenario.GeneratedEvents.ShouldBeEmpty();
        It should_fail_validation = () => result.Invalid.ShouldBeTrue();
    }
}