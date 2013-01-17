using System;
using Bifrost.Events;

namespace Chirp.Events.Users
{
    public class PasswordReset : Event
    {
        public PasswordReset(Guid eventSourceId) : base(eventSourceId) { }
    }
}
