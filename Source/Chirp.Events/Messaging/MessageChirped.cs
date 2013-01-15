using System;
using Bifrost.Events;

namespace Chirp.Events.Messaging
{
    public class MessageChirped : Event
    {
        public MessageChirped(Guid eventSourceId) : base(eventSourceId)
        {
        }

        public Guid PublishedBy { get; set; }
        public string Content { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}