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
        protected static Mock<IReadModelRepositoryFor<MyFollowers>> my_followers_repository;
        protected static Mock<IReadModelRepositoryFor<MyFollows>> my_follows_repository;
        protected static MyFollowers my_followers ;
        protected static MyFollows my_follows ;

        Establish context = () =>
                                {
                                    my_followers_repository = new Mock<IReadModelRepositoryFor<MyFollowers>>();
                                    my_followers_repository.Setup(r => r.GetById(Moq.It.IsAny<ChirperId>()))
                                        .Callback((object id) => my_followers = new MyFollowers((ChirperId)id))
                                        .Returns((object id) => my_followers);

                                    my_follows_repository = new Mock<IReadModelRepositoryFor<MyFollows>>();
                                    my_follows_repository.Setup(r => r.GetById(Moq.It.IsAny<FollowerId>()))
                                        .Callback((object id) => my_follows = new MyFollows((FollowerId)id))
                                        .Returns((object id) => my_follows);
                                    
                                    subscriber = new FollowSubscriber(my_followers_repository.Object, my_follows_repository.Object);
                                };
    }
}