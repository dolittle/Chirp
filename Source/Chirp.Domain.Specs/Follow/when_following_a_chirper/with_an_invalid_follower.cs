using Bifrost.Commands;
using Chirp.Domain.Follow.Commands;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Follow.when_following_a_chirper
{
    [Subject(Scenarios.WhenFollowingAChirper)]
    public class with_an_invalid_follower : given.a_scenario_with_a_follow_chirper_command
    {
        static FollowChirper follow_chirper;
        static CommandResult result;

        Establish context = () =>
                                {
                                    follow_chirper = new FollowChirper
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