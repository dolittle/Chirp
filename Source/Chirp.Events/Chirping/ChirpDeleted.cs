using System;
using Bifrost.Events;

namespace Chirp.Events.Chirping
{
    public class ChirpDeleted : Event
    {
        public ChirpDeleted() : base(Guid.Empty)
        {}

        public ChirpDeleted(Guid id) : base(id)
        {}

        public Guid PublishedBy { get; set; }
        public Guid DeletedChirp { get; set; }
    }
}