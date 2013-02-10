using Bifrost.Commands;
using Bifrost.MSpec.Extensions;
using Chirp.Domain.Follow.Commands;
using Chirp.Events.Follow;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Follow.when_unfollowing_a_chirper
{
    [Subject(Scenarios.WhenUnfollowingAChirper)]
    public class that_you_already_follow : given.a_scenario_with_an_unfollow_chirper_command
    {
        static UnfollowChirper follow_chirper;
        static CommandResult result;

        Establish context = () =>
        {
            follow_chirper = new UnfollowChirper
            {
                Follower = followers.valid,
                Chirper = chirpers.following
            };
        };

        Because of = () => result = command_scenario.IsHandled(follow_chirper);

        It should_be_a_successful_scenario = () => command_scenario.IsSuccessful().ShouldBeTrue();
        It should_have_generated_events = () => command_scenario.HasGeneratedEvents.ShouldBeTrue();
        It should_have_a_chirper_followed_event_with_the_correct_values = () => command_scenario.GeneratedEvents.ShouldHaveEvent<ChirperUnfollowed>()
                                                                                                                                                .AtBeginning().Where(
                                                                                                                                                e =>
                                                                                                                                                {
                                                                                                                                                    e.Chirper.ShouldEqual(follow_chirper.Chirper.Value);
                                                                                                                                                    e.EventSourceId.ShouldEqual(follow_chirper.Follower.Value);
                                                                                                                                                });
    }
}