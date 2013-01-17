using System;
using Bifrost.Domain;
using Chirp.Concepts;
using Chirp.Events.Follow;

namespace Chirp.Domain.Follow
{
    public class Following : AggregatedRoot
    {
        public Following(Guid id) : base(id)
        {
        }

        public void Follow(ChirperId chirper)
        {
            Apply(new ChirpedFollowed(Id)
                      {
                          Chirper = chirper
                      });
        }
    }
}