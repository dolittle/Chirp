using System.Linq;
using Chirp.Events.Follow;
using Chirp.Read.Follow;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Chirp.Read.Specs.Follow.for_follow_subscriber
{
    [Subject(typeof(FollowSubscriber), Scenarios.ChirperUnfollowed)]
    public class on_chirper_unfollowed : given.a_subscriber
    {
        static ChirperUnfollowed chirper_unfollowed;

        Establish context = () =>
                                {
                                    followers_for_Scott.AddFollower(followers.Hannah);
                                    follows_for_Hannah.AddFollow(Chirpers.Scott);

                                    chirper_unfollowed = new ChirperUnfollowed(followers.Hannah.FollowerId)
                                                             {
                                                                 Chirper = Chirpers.Scott.ChirperId
                                                             };
                                };

        Because of = () => subscriber.Process(chirper_unfollowed);

        It should_retrieve_the_chirper_followed = () => chirper_repository.Verify(r => r.GetById(Chirpers.Scott.ChirperId), Times.Once());
        It should_retrieve_the_follower = () => follower_repository.Verify(r => r.GetById(followers.Hannah.FollowerId), Times.Once());
        It should_retrieve_follows_for_the_follower = () => my_follows_repository.Verify(r => r.GetById(followers.Hannah.FollowerId), Times.Once());
        It should_remove_the_chirper_from_the_followers_follows = () => follows_for_Hannah.Following.Any(c => c.ChirperId == Chirpers.Scott.ChirperId).ShouldBeFalse();
        It should_update_followers_follows = () => my_follows_repository.Verify(r => r.GetById(followers.Hannah.FollowerId), Times.Once());
        It should_retrieve_followers_for_the_chirper = () => my_follows_repository.Verify(r => r.Update(follows_for_Hannah), Times.Once());
        It should_remove_the_follower_from_the_chirpers_followers = () => followers_for_Scott.Followers.Any(c => c.FollowerId == followers.Hannah.FollowerId).ShouldBeFalse();
        It should_update_chirpers_followers = () => my_followers_repository.Verify(r => r.Update(followers_for_Scott), Times.Once());

    }
}