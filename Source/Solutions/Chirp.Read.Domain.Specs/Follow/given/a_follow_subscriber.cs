using Bifrost.Read;
using Chirp.Concepts;
using Chirp.Read.Domain.Follow;
using Machine.Specifications;
using Moq;

namespace Chirp.Read.Domain.Specs.Follow.given
{
    public class a_follow_subscriber
    {
        protected static FollowSubscriber subscriber;
        protected static Mock<IReadModelRepositoryFor<ChirpersFollowers>> my_followers_repository;
        protected static Mock<IReadModelRepositoryFor<FollowerFollows>> my_follows_repository;
        protected static ChirpersFollowers chirpers_followers;
        protected static FollowerFollows follower_follows ;

        Establish context = () =>
                                {
                                    my_followers_repository = new Mock<IReadModelRepositoryFor<ChirpersFollowers>>();
                                    my_followers_repository.Setup(r => r.GetById(Moq.It.IsAny<ChirperId>()))
                                        .Callback((object id) => chirpers_followers = new ChirpersFollowers((ChirperId)id))
                                        .Returns((object id) => chirpers_followers);

                                    my_follows_repository = new Mock<IReadModelRepositoryFor<FollowerFollows>>();
                                    my_follows_repository.Setup(r => r.GetById(Moq.It.IsAny<FollowerId>()))
                                        .Callback((object id) => follower_follows = new FollowerFollows((FollowerId)id))
                                        .Returns((object id) => follower_follows);
                                    
                                    subscriber = new FollowSubscriber(my_followers_repository.Object, my_follows_repository.Object);
                                };
    }
}