using Bifrost.Commands;
using Chirp.Infrastructure.Security;
using Bifrost.Domain;

namespace Chirp.Domain.Users.Commands
{
    public class CommandHandlers : IHandleCommands
    {
        IUserService _userService;
        IAggregateRootRepository<User> _userAggregateRootRepository;

        public CommandHandlers(IAggregateRootRepository<User> userAggregateRootRepository, IUserService userService)
        {
            _userAggregateRootRepository = userAggregateRootRepository;
            _userService = userService;
        }

        public void Handle(Login @command)
        {
            var id = _userService.GetUserId(@command.UserName);
            var user = _userAggregateRootRepository.Get(id);
            user.Login();
            _userService.Login(@command.UserName);
        }

        public void Handle(ResetPassword @command)
        {
            var id = _userService.GetUserId(@command.UserName);
            var user = _userAggregateRootRepository.Get(id);
            user.ResetPassword();
        }
    }
}
