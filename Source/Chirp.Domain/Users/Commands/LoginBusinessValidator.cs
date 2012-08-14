using Bifrost.Validation;
using System;
using FluentValidation;

namespace Chirp.Domain.Users.Commands
{
    public class LoginBusinessValidator : CommandBusinessValidator<Login>
    {
        public LoginBusinessValidator(Func<string,string,bool> beValidUser)
        {
            ModelRule().Must(l => beValidUser(l.UserName, l.Password)).WithMessage("UserName or Password is wrong");
        }
    }
}
