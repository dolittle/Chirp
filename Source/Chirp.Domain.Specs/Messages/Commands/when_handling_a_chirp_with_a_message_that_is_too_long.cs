using System;
using Bifrost.Commands;
using Chirp.Domain.Messages.Commands;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Messages.Commands
{
    [Subject(typeof(MessageCommandHandler))]
    public class when_handling_a_chirp_with_a_message_that_is_too_long : given.a_scenario_with_a_<ChirpMessage>
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
                                                            Message = messages.too_long
                                                        };
                                };

        Because of = () =>
                         {
                             using (Bifrost.Time.SystemClock.SetNowTo(current_time))
                             {
                                 result = command_scenario.IsHandled(chirp_message);
                             }
                         };

        It should_not_chirp_the_message = () => chirp.ShouldBeNull();
        It should_fail_validation = () => result.Invalid.ShouldBeTrue();
    }
}