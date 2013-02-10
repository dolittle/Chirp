using System;
using Bifrost.Events;

namespace Chirp.Events.Follow
{
    public class ChirperUnfollowed : Event
    {
        public ChirperUnfollowed()
            : base(Guid.Empty)
        { }

        public ChirperUnfollowed(Guid followerId)
            : base(followerId)
        { }

        public Guid Chirper { get; set; }
    }
}