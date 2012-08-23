using Chirp.Infrastructure.Security;
using System;

namespace Chirp.Application.Security
{
    public class UserService : IUserService
    {
        

        public bool CanLogin(string userName, string password)
        {
            if (userName == "einari")
                return true;

            return false;
        }

        public Guid GetUserId(string userName)
        {
            if (userName == "einari")
                return Guid.Parse("6731A8F9-192D-431E-B5EF-7C5A11FFFA36");

            return Guid.Empty;
        }

        public void Login(string userName)
        {
            
        }
    }
}
