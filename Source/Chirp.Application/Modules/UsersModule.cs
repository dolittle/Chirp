using Ninject.Modules;
using System;
using Chirp.Domain.Users.Commands;

namespace Chirp.Application.Modules
{
    public class UsersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Func<string, string, bool>>().ToMethod(a => CanLogin).WhenInjectedInto<LoginBusinessValidator>();
        }

        bool CanLogin(string userName, string password)
        {
            return false;
        }
    }
}
