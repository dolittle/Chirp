using Bifrost.Commands;
using Chirp.Concepts;

namespace Chirp.Domain.Users.Commands
{
    public class Login : Command
    {
        string _userName;
        public string UserName 
        { 
            get { return _userName; }
            set { _userName = value.StartsWith("@") ? value : "@" + value; }
        }
        public string Password { get; set; }
    }
}
