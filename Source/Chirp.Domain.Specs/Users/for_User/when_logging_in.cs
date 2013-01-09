using Bifrost.MSpec.Events;
using Chirp.Domain.Users;
using Chirp.Events.Users;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Users.for_User
{
    [Subject(typeof(User))]
    public class when_logging_in : given.a_user
    {
        Because of = () => user.Login();

        It should_apply_logged_in_event = () => user.ShouldHaveEvent<LoggedIn>();
    }
}
