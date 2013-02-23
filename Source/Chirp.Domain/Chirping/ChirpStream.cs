using System;
using Bifrost.Domain;
using Chirp.Concepts;
using Chirp.Events.Chirping;

namespace Chirp.Domain.Chirping
{
    public class ChirpStream : AggregateRoot
    {
        public ChirpStream(Guid publishedBy)
            : base(publishedBy)
        {
        }

        public void Publish(Chirp chirp)
        {
            Apply(new MessageChirped(Id)
                      {
                          ChirpId = chirp.Id,
                          ChirpedBy = Id,
                          ChirpedAt = Bifrost.Time.SystemClock.GetCurrentTime(),
                          Content = chirp.Content
                      });
        }

        public void Delete(ChirpId chirpToDelete)
        {
            Apply(new ChirpDeleted(Id)
                      {
                          PublishedBy = Id,
                          DeletedChirp = chirpToDelete
                      });
        }
    }
}
