using System;
using Bifrost.Events;

namespace Chirp.Events.Users
{
    public class PasswordResetted : Event
    {
        public PasswordResetted(Guid eventSourceId) : base(eventSourceId) { }
    }
}
