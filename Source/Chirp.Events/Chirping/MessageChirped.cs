using System;
using Bifrost.Events;

namespace Chirp.Events.Chirping
{
    public class MessageChirped : Event
    {
        public MessageChirped(Guid eventSourceId) : base(eventSourceId)
        {
        }

        public Guid ChirpedBy { get; set; }
        public string Content { get; set; }
        public DateTime ChirpedAt { get; set; }
    }
}