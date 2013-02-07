using Bifrost.Commands;
using Chirp.Domain.Follow.Commands;
using Chirp.Events.Follow;
using Machine.Specifications;
using Bifrost.MSpec.Extensions;

namespace Chirp.Domain.Specs.Follow.when_following_a_chirper
{
    [Subject(Scenarios.WhenFollowingAChirper)]
    public class that_you_do_not_follow : given.a_scenario_with_a_follow_chirper_command
    {
        static FollowChirper follow_chirper;
        static CommandResult result;

        Establish context = () =>
                                {
                                    follow_chirper = new FollowChirper
                                                         {
                                                             Follower = followers.valid,
                                                             Chirper = chirpers.valid
                                                         };
                                };

        Because of = () => result = command_scenario.IsHandled(follow_chirper);

        It should_be_a_successful_scenario = () => command_scenario.IsSuccessful().ShouldBeTrue();
        It should_have_generated_events = () => command_scenario.HasGeneratedEvents.ShouldBeTrue();
        It should_have_a_chirper_followed_event_with_the_correct_values = () => command_scenario.GeneratedEvents.ShouldHaveEvent<ChirperFollowed>()
                                                                                                                                                .AtBeginning().Where(
                                                                                                                                                e =>
                                                                                                                                                {
                                                                                                                                                    e.Chirper.ShouldEqual(follow_chirper.Chirper.Value);
                                                                                                                                                    e.EventSourceId.ShouldEqual(follow_chirper.Follower.Value);
                                                                                                                                                });
                        
    }
}