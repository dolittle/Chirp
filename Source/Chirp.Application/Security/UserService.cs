using Chirp.Infrastructure.Security;
using System;
using System.Linq;
using Bifrost.Views;
using Chirp.Read;
using Chirp.Read.Streams;

namespace Chirp.Application.Security
{
    public class UserService : IUserService
    {
        IView<Chirper> _chirpersView;

        public UserService(IView<Chirper> chirpersView){
            _chirpersView = chirpersView;
        }
        

        public bool CanLogin(string userName, string password)
        {
            if (userName == "einari")
                return true;

            if (_chirpersView.Query.Any(c => c.DisplayName == userName))
                return true;

            return false;
        }

        public Guid GetUserId(string userName)
        {
            if (userName == "einari")
                return Guid.Parse("6731A8F9-192D-431E-B5EF-7C5A11FFFA36");

            var chirper = _chirpersView.Query.FirstOrDefault(c => c.DisplayName == userName);
            if (chirper != null)
                return chirper.ChirperId;

            return Guid.Empty;
        }

        public void Login(string userName)
        {
            
        }
    }
}
