using System;
using Bifrost.Domain;
using Chirp.Concepts;
using Chirp.Events.Follow;

namespace Chirp.Domain.Follow
{
    public class Following : AggregateRoot
    {
        public Following(Guid id) : base(id)
        {
        }

        public void Follow(ChirperId chirper)
        {
            Apply(new ChirperFollowed(Id)
                      {
                          Chirper = chirper
                      });
        }

        public void Unfollow(ChirperId chirper)
        {
            Apply(new ChirperUnfollowed(Id)
            {
                Chirper = chirper
            });
        }
    }
}