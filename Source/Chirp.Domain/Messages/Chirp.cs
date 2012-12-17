using System;
using Bifrost.Domain;
using Chirp.Events.Messages;

namespace Chirp.Domain.Messages
{
    public class Chirp : AggregatedRoot
    {
        public Chirp(Guid id) : base(id)
        {
        }

        public void Publish(Publisher publishFor, Message message)
        {
            Apply(new MessageChirped(Id)
                      {
                          PublishedBy = publishFor.Id,
                          PublishedAt = Bifrost.Time.SystemClock.GetCurrentTime(),
                          Content = message.Content
                      });
        }
    }
}