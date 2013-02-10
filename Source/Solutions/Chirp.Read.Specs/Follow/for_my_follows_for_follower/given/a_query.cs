using System;
using Bifrost.Read;
using Chirp.Concepts;
using Chirp.Read.Follow;
using Machine.Specifications;
using Moq;

namespace Chirp.Read.Specs.Follow.for_my_follows_for_follower.given
{
    public class a_query
    {
        protected static MyFollowsForFollower query;
        protected static Mock<IReadModelRepositoryFor<MyFollows>> my_follows_repository;
        protected static FollowerId follower_who_follows;
        protected static FollowerId follower_who_does_not_follow;
        protected static MyFollows follows;

        Establish context = () =>
                                {
                                    follower_who_follows = Guid.NewGuid();
                                    follower_who_does_not_follow = Guid.NewGuid();

                                    follows = new MyFollows(follower_who_follows);
                                    follows.AddFollow(new Chirper() { ChirperId = Guid.NewGuid(), DisplayName = "Test"});
                                    my_follows_repository = new Mock<IReadModelRepositoryFor<MyFollows>>();
                                    my_follows_repository.Setup(r => r.GetById(follower_who_follows)).Returns(follows);

                                    query = new MyFollowsForFollower(my_follows_repository.Object);
                                };
    }
}