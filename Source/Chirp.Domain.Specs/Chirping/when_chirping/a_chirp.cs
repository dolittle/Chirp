using System;
using Bifrost.Commands;
using Bifrost.MSpec.Extensions;
using Chirp.Domain.Chirping.Commands;
using Chirp.Events.Chirping;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Chirping.when_chirping
{
    [Subject(Scenarios.WhenChirping)]
    public class a_chirp : given.a_scenario_with_a_chirp_message
    {
        static ChirpMessage chirp_message;
        static DateTime current_time;
        static CommandResult result;

        Establish context = () =>
                                {
                                    current_time = DateTime.UtcNow;

                                    chirp_message = new ChirpMessage
                                                {
                                                    Chirper = chirpers.valid,
                                                    Chirp = chirps.valid_chirp_with_no_tags
                                                };
                                };

        Because of = () =>
                         {
                            using(Bifrost.Time.SystemClock.SetNowTo(current_time))
                            {
                                result = command_scenario.IsHandled(chirp_message);
                            }
                         };

        It should_be_a_successful_scenario = () => command_scenario.ShouldBeASuccessfulScenario();
        It should_generate_the_events = () => command_scenario.HasGeneratedEvents.ShouldBeTrue();
        It should_chirp_the_message = () => command_scenario.GeneratedEvents.ShouldHaveEvent<MessageChirped>().AtBeginning().Where(
            e =>
                {
                    e.Content.ShouldEqual(chirps.valid_chirp_with_no_tags.Content);
                    e.ChirpedBy.ShouldEqual(chirpers.valid.Value);
                    e.ChirpedAt.ShouldEqual(current_time);
                    e.ChirpId.ShouldEqual(chirps.valid_chirp_with_no_tags.Id.Value);
                });
    }
}