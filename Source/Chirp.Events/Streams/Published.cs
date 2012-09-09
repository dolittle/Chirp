using Bifrost.Events;
using System;

namespace Chirp.Events.Streams
{
    public class MessagePublished : Event
    {
        public MessagePublished(Guid eventSourceId)
            : base(eventSourceId)
        {
        }

        public string Message { get; set; }
    }
}
