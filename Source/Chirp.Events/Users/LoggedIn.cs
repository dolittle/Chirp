using System;
using Bifrost.Events;

namespace Chirp.Events.Users
{
    public class LoggedIn : Event
    {
        public LoggedIn(Guid eventSourceId) : base(eventSourceId) { }
    }
}
