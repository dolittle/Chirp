using Bifrost.Read;
using Chirp.Read.Follow;
using Machine.Specifications;
using Moq;

namespace Chirp.Read.Specs.Follow.given
{
    public class a_subscriber
    {
        protected static FollowSubscriber subscriber;
        protected static Mock<IReadModelRepositoryFor<MyFollowers>>  my_followers_repository;
        protected static Mock<IReadModelRepositoryFor<MyFollows>>  my_follows_repository;
        protected static Mock<IReadModelRepositoryFor<Chirper>>  chirper_repository;
        protected static Mock<IReadModelRepositoryFor<Follower>>  follower_repository;
        protected static MyFollowers followers_for_Scott;
        protected static MyFollows follows_for_Hannah;

        Establish context = () =>
        {
            my_followers_repository = new Mock<IReadModelRepositoryFor<MyFollowers>>();
            my_follows_repository = new Mock<IReadModelRepositoryFor<MyFollows>>();
            chirper_repository = new Mock<IReadModelRepositoryFor<Chirper>>();
            follower_repository = new Mock<IReadModelRepositoryFor<Follower>>();
            subscriber = new FollowSubscriber(my_followers_repository.Object, my_follows_repository.Object, chirper_repository.Object, follower_repository.Object);

            chirper_repository.Setup(r => r.GetById(Chirpers.Scott.ChirperId)).Returns(Chirpers.Scott);
            follower_repository.Setup(r => r.GetById(followers.Hannah.FollowerId)).Returns(followers.Hannah);

            followers_for_Scott = new MyFollowers(Chirpers.Scott.ChirperId) { Chirper = Chirpers.Scott };
            follows_for_Hannah = new MyFollows(followers.Hannah.FollowerId) { Follower = followers.Hannah };

            my_followers_repository.Setup(r => r.GetById(Chirpers.Scott.ChirperId)).Returns(followers_for_Scott);
            my_follows_repository.Setup(r => r.GetById(followers.Hannah.FollowerId)).Returns(follows_for_Hannah);
        };
    }
}