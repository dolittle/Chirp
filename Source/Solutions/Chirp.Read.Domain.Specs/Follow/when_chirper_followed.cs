using System;
using System.Linq;
using Chirp.Concepts;
using Chirp.Events.Follow;
using Machine.Specifications;

namespace Chirp.Read.Domain.Specs.Follow
{
    [Subject(Scenarios.ChirperFollowed)]
    public class when_chirper_followed : given.a_follow_subscriber
    {
        static ChirperFollowed chirper_followed;
        static Guid chirper_id;
        static Guid follower_id;
        static ChirperId chirper;
        static FollowerId follower;

        Establish context = () =>
                                {
                                    chirper_id = Guid.NewGuid();
                                    chirper = chirper_id;
                                    follower_id = Guid.NewGuid();
                                    follower = follower_id;

                                    chirper_followed = new ChirperFollowed(follower_id)
                                                           {
                                                               Chirper = chirper_id
                                                           };
                                };

        Because of = () => subscriber.Process(chirper_followed);

        It should_retrieve_my_followers_for_the_chirper =  () => my_followers_repository.Verify(r => r.GetById(chirper), Moq.Times.Once());
        It should_add_the_follower_to_the_followers_for_the_chirper = () => my_followers.Followers.Any(f => f == follower_id).ShouldBeTrue();    
        It should_update_my_followers = () => my_followers_repository.Verify(r => r.Update(my_followers), Moq.Times.Once());
        It should_retrieve_follows_for_the_follower = () => my_follows_repository.Verify(r => r.GetById(follower), Moq.Times.Once());
        It should_add_the_chirper_to_the_follows_for_the_follower = () => my_follows.Following.Any(f => f == chirper_id).ShouldBeTrue();
        It should_update_my_followsr = () => my_follows_repository.Verify(r => r.Update(my_follows), Moq.Times.Once());
    }
}