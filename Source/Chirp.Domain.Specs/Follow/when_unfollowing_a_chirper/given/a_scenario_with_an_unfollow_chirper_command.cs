using System;
using Bifrost.Domain;
using Bifrost.Testing;
using Bifrost.Validation;
using Chirp.Concepts;
using Chirp.Domain.Follow;
using Chirp.Domain.Follow.Commands;
using Machine.Specifications;
using Moq;

namespace Chirp.Domain.Specs.Follow.when_unfollowing_a_chirper.given
{
    public class a_scenario_with_an_unfollow_chirper_command
    {
        protected static FollowerId follower_id;
        protected static Following following;
        protected static Mock<IAggregatedRootRepository<Following>> following_repository;
        static FollowCommandHandler command_handler;
        static ICanValidate<UnfollowChirper> input_validator;
        static ICanValidate<UnfollowChirper> business_validator;

        protected static CommandScenario<UnfollowChirper> command_scenario;

        Establish context = () =>
        {
            follower_id = followers.valid;
            following = new Following(follower_id);
            var followingFuncs = new TestFollowingFuncs();
            var chirperFuncs = new TestChirperFuncs();
            following_repository = new Mock<IAggregatedRootRepository<Following>>();
            input_validator = new UnfollowChirperInputValidator();
            business_validator = new UnfollowChirperBusinessValidator(followingFuncs.Follows(), chirperFuncs.ChirperExists());
            command_handler = new FollowCommandHandler(following_repository.Object);

            command_scenario = new CommandScenario<UnfollowChirper>();
            command_scenario.ValidatedWith(input_validator, business_validator);
            command_scenario.HandledBy(command_handler);

            following_repository.Setup(r => r.Get(Moq.It.IsAny<Guid>()))
                .Returns((Guid id) => command_scenario.RegisterAggregateRoot(new Following(id)));
        };
    } 
}