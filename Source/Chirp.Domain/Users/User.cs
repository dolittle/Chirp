using System;
using Bifrost.Domain;
using Chirp.Events.Users;

namespace Chirp.Domain.Users
{
    public class User : AggregateRoot
    {
        public User(Guid id)
            : base(id)
        {
        }

        public void Login()
        {
            Apply(new LoggedIn(Id));
        }

        public void ResetPassword()
        {
            Apply(new PasswordReset(Id));
        }
    }
}
