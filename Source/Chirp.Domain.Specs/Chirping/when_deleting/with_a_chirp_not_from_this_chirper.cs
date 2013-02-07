using Bifrost.Commands;
using Bifrost.MSpec.Extensions;
using Chirp.Domain.Chirping.Commands;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Chirping.when_deleting
{
    [Subject(Scenarios.WhenDeleting)]
    public class with_a_chirp_not_from_this_chirper : given.a_scenario_with_a_delete_chirp_command
    {
        static DeleteChirp delete_chirp;
        static CommandResult result;

        Establish context = () =>
                                {
                                    delete_chirp = new DeleteChirp
                                                       {
                                                           ChirpedBy = chirpers.valid,
                                                           ChirpToDelete = chirps.from_a_different_chirper
                                                       };
                                };

        Because of = () =>
                         {
                             result = command_scenario.IsHandled(delete_chirp);
                         };

        It should_be_an_unsuccessful_scenario = () => command_scenario.ShouldBeAnUnsuccessfulScenario();
        It should_not_delete_the_message = () => command_scenario.HasGeneratedEvents.ShouldBeFalse();
        It should_fail_validation = () => result.Invalid.ShouldBeTrue();
    }
}