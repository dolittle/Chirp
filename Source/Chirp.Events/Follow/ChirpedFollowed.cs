using System;
using Bifrost.Events;

namespace Chirp.Events.Follow
{
    public class ChirpedFollowed : Event
    {
        public ChirpedFollowed() : base(Guid.Empty)
        {}

        public ChirpedFollowed(Guid subscriberId) : base(subscriberId)
        {}

        public Guid Chirper { get; set; }
    }
}