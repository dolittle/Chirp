using System;
using Chirp.Domain.Users.Commands;
using Chirp.Infrastructure.Security;
using Ninject;
using Ninject.Modules;
using Chirp.Application.Security;

namespace Chirp.Application.Modules
{
    public class UsersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<Func<string, string, bool>>().ToMethod(a => CanLogin).WhenInjectedInto<LoginBusinessValidator>();
        }

        bool CanLogin(string userName, string password)
        {
            var service = Kernel.Get<IUserService>();
            return service.CanLogin(userName, password);
        }
    }
}
