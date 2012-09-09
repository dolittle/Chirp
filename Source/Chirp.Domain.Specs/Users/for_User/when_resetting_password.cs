using Bifrost.MSpec.Events;
using Chirp.Events.Users;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Users.for_User
{
    public class when_resetting_password : given.a_user
    {
        Because of = () => user.ResetPassword();

        It should_apply_password_resetted_event = () => user.ShouldHaveEvent<PasswordResetted>();
    }
}
