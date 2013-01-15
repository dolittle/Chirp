using System;
using Bifrost.Events;

namespace Chirp.Events.Subscriptions
{
    public class PublisherSubscribedTo : Event
    {
        public PublisherSubscribedTo() : base(Guid.Empty)
        {}

        public PublisherSubscribedTo(Guid subscriberId) : base(subscriberId)
        {}

        public Guid Publisher { get; set; }
    }
}