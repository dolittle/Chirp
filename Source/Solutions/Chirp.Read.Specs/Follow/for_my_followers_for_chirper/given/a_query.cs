using System;
using Bifrost.Read;
using Chirp.Concepts;
using Chirp.Read.Follow;
using Machine.Specifications;
using Moq;

namespace Chirp.Read.Specs.Follow.for_my_followers_for_chirper.given
{
    public class a_query
    {
        protected static MyFollowersForChirper query;
        protected static Mock<IReadModelRepositoryFor<MyFollowers>> my_followers_repository;
        protected static ChirperId chirper_with_followers;
        protected static ChirperId chirper_with_no_followers;
        protected static MyFollowers followers;

        Establish context = () =>
                                {
                                    chirper_with_followers = Guid.NewGuid();
                                    chirper_with_no_followers = Guid.NewGuid();

                                    followers = new MyFollowers(chirper_with_followers);
                                    followers.AddFollower(new Follower() { FollowerId = Guid.NewGuid(), DisplayName = "Test"});
                                    my_followers_repository = new Mock<IReadModelRepositoryFor<MyFollowers>>();
                                    my_followers_repository.Setup(r => r.GetById(chirper_with_followers)).Returns(followers);

                                    query = new MyFollowersForChirper(my_followers_repository.Object);

                                };
    }
}