using Bifrost.Commands;
using Chirp.Domain.Follow.Commands;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Follow.when_following_a_chirper
{
    [Subject(Scenarios.WhenFollowingAChirper)]
    public class that_does_not_exist : given.a_scenario_with_a_follow_chirper_command
    {
        static FollowChirper follow_chirper;
        static CommandResult result;

        Establish context = () =>
                                {
                                    follow_chirper = new FollowChirper
                                                         {
                                                             Follower = followers.valid,
                                                             Chirper = chirpers.valid_id_that_does_not_exist
                                                         };
                                };

        Because of = () => result = command_scenario.IsHandled(follow_chirper);

        It should_not_be_a_successful_scenario = () => command_scenario.IsSuccessful().ShouldBeFalse();
        It should_not_have_generated_events = () => command_scenario.HasGeneratedEvents.ShouldBeFalse();
        It should_be_invalid = () => result.Invalid.ShouldBeTrue();
    }
}