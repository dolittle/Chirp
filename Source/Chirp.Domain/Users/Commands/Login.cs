using Bifrost.Commands;

namespace Chirp.Domain.Users.Commands
{
    public class Login : Command
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
