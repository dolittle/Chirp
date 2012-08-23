using Bifrost.Commands;

namespace Chirp.Domain.Users.Commands
{
    public class ResetPassword : Command
    {
        public string UserName { get; set; }
    }
}
