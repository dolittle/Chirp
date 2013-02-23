using Bifrost.Commands;
using Chirp.Infrastructure.Security;
using Bifrost.Domain;

namespace Chirp.Domain.Users.Commands
{
    public class CommandHandlers : IHandleCommands
    {
        IUserService _userService;
        IAggregatedRootRepository<User> _userAggregatedRootRepository;

        public CommandHandlers(IAggregatedRootRepository<User> userAggregatedRootRepository, IUserService userService)
        {
            _userAggregatedRootRepository = userAggregatedRootRepository;
            _userService = userService;
        }

        public void Handle(Login @command)
        {
            var id = _userService.GetUserId(@command.UserName);
            var user = _userAggregatedRootRepository.Get(id);
            user.Login();
            _userService.Login(@command.UserName);
        }

        public void Handle(ResetPassword @command)
        {
            var id = _userService.GetUserId(@command.UserName);
            var user = _userAggregatedRootRepository.Get(id);
            user.ResetPassword();
        }
    }
}
