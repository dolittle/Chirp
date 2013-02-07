using System.Linq;
using Chirp.Events.Follow;
using Chirp.Read.Follow;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Chirp.Read.Specs.Follow
{
    [Subject(typeof(FollowSubscriber), Scenarios.ChirperFollowed)]
    public class on_chirper_followed : given.a_subscriber
    {
        static ChirperFollowed chirper_followed;

        Establish context = () =>
                                {
                                    chirper_followed = new ChirperFollowed(followers.Hannah.FollowerId)
                                                           {
                                                               Chirper = Chirpers.Scott.ChirperId
                                                           };
                                };

        Because of = () => subscriber.Process(chirper_followed);

        It should_retrieve_the_chirper_followed = () => chirper_repository.Verify(r => r.GetById(Chirpers.Scott.ChirperId),Times.Once());
        It should_retrieve_the_follower = () => follower_repository.Verify(r => r.GetById(followers.Hannah.FollowerId),Times.Once());
        It should_retrieve_follows_for_the_follower= () => my_follows_repository.Verify(r => r.GetById(followers.Hannah.FollowerId),Times.Once());
        It should_add_the_chirper_to_the_followers_follows =() => follows_for_Hannah.Following.Count(c => c.ChirperId == Chirpers.Scott.ChirperId).ShouldEqual(1);
        It should_update_followers_follows = () => my_follows_repository.Verify(r => r.GetById(followers.Hannah.FollowerId), Times.Once());
        It should_retrieve_followers_for_the_chirper = () => my_follows_repository.Verify(r => r.Update(follows_for_Hannah), Times.Once());
        It should_add_the_follower_to_the_chirpers_followers = () => followers_for_Scott.Followers.Count(c => c.FollowerId == followers.Hannah.FollowerId).ShouldEqual(1);
        It should_update_chirpers_followers = () => my_followers_repository.Verify(r => r.Update(followers_for_Scott), Times.Once());

    }
}