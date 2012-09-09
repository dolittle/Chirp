
using Chirp.Domain.Users;
using Machine.Specifications;
using System;
namespace Chirp.Domain.Specs.Users.for_User.given
{
    public class a_user
    {
        protected static Guid   user_id = Guid.NewGuid();
        protected static User user;

        Establish context = () => user = new User(user_id);
    }
}
