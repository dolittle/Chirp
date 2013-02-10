using System.Linq;
using Chirp.Read.Follow;
using Machine.Specifications;

namespace Chirp.Read.Specs.Follow.for_my_follows_for_follower
{
    [Subject(typeof (MyFollowsForFollower))]
    public class when_follower_follows_chirpers : given.a_query
    {
        static MyFollows my_follows;

        Establish context = () =>
                                {
                                    query.FollowerId = follower_who_follows;
                                };

        Because of = () => my_follows = query.Query.SingleOrDefault();

        It should_retrieve_follows_from_repository = () => my_follows_repository.Verify(r => r.GetById(follower_who_follows), Moq.Times.Once());
        It should_return_follows_for_this_follower = () => my_follows.FollowerId.ShouldEqual(query.FollowerId);
        It should_have_populated_the_chirpers = () => my_follows.Following.Any().ShouldBeTrue();
    }
}