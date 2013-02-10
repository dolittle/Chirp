using Bifrost.Commands;
using Chirp.Domain.Follow.Commands;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Follow.when_unfollowing_a_chirper
{
    [Subject(Scenarios.WhenUnfollowingAChirper)]
    public class with_an_invalid_follower : given.a_scenario_with_an_unfollow_chirper_command
    {
        static UnfollowChirper follow_chirper;
        static CommandResult result;

        Establish context = () =>
                                {
                                    follow_chirper = new UnfollowChirper
                                                         {
                                                             Follower = followers.invalid,
                                                             Chirper = chirpers.not_following
                                                         };
                                };

        Because of = () => result = command_scenario.IsHandled(follow_chirper);

        It should_not_be_a_successful_scenario = () => command_scenario.IsSuccessful().ShouldBeFalse();
        It should_not_have_generated_events = () => command_scenario.HasGeneratedEvents.ShouldBeFalse();
        It should_be_invalid = () => result.Invalid.ShouldBeTrue();
    }


}