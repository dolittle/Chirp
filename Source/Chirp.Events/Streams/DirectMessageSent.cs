using System;
using Bifrost.Events;

namespace Chirp.Events.Streams
{
    public class DirectMessageSent : Event
    {
        public DirectMessageSent(Guid eventSourceId)
            : base(eventSourceId)
        {
        }

        public Guid Receiver { get; set; }
        public string Message { get; set; }
    }
}
