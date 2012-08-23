using System;
namespace Chirp.Infrastructure.Security
{
    public interface IUserService
    {
        bool CanLogin(string userName, string password);
        Guid GetUserId(string userName);
        void Login(string userName);
    }
}
