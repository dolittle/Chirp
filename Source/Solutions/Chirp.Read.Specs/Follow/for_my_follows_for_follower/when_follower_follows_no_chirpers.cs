using System.Linq;
using Chirp.Read.Follow;
using Machine.Specifications;

namespace Chirp.Read.Specs.Follow.for_my_follows_for_follower
{
    [Subject(typeof(MyFollowsForFollower))]
    public class when_follower_follows_no_chirpers : given.a_query
    {
        static MyFollows my_follows;

        Establish context = () =>
                                {
                                    query.FollowerId = follower_who_does_not_follow;
                                };

        Because of = () => my_follows = query.Query.SingleOrDefault();

        It should_retrieve_follows_from_repository = () => my_follows_repository.Verify(r => r.GetById(follower_who_does_not_follow), Moq.Times.Once());
        It should_return_followers_for_this_chirper = () => my_follows.FollowerId.ShouldEqual(query.FollowerId);
        It should_have_not_populated_any_followers = () => my_follows.Following.Any().ShouldBeFalse();
    }
}