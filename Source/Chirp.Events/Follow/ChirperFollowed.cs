using System;
using Bifrost.Events;

namespace Chirp.Events.Follow
{
    public class ChirperFollowed : Event
    {
        public ChirperFollowed() : base(Guid.Empty)
        {}

        public ChirperFollowed(Guid followerId) : base(followerId)
        {}

        public Guid Chirper { get; set; }
    }
}