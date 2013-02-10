using System.Linq;
using Chirp.Read.Follow;
using Machine.Specifications;

namespace Chirp.Read.Specs.Follow.for_my_followers_for_chirper
{
    [Subject(typeof(MyFollowersForChirper))]
    public class when_chirper_has_no_followers : given.a_query
    {
        static MyFollowers my_followers;

        Establish context = () =>
                                {
                                    query.ChirperId = chirper_with_no_followers;
                                };

        Because of = () => my_followers = query.Query.SingleOrDefault();

        It should_retrieve_followers_from_repository = () => my_followers_repository.Verify(r => r.GetById(chirper_with_no_followers), Moq.Times.Once());
        It should_return_followers_for_this_chirper = () => my_followers.ChirperId.ShouldEqual(query.ChirperId);
        It should_have_not_populated_any_followers = () => my_followers.Followers.Any().ShouldBeFalse();
    }
}