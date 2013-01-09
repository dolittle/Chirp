using System;
using Bifrost.Domain;
using Chirp.Events.Messages;
using Chirp.Events.Streams;

namespace Chirp.Domain.Streams
{
    public class Stream : AggregatedRoot
    {
        public Stream(Guid publishedBy)
            : base(publishedBy)
        {
        }

        public void Publish(Message message)
        {
            Apply(new MessageChirped(Id)
                      {
                          PublishedBy = Id,
                          PublishedAt = Bifrost.Time.SystemClock.GetCurrentTime(),
                          Content = message.Content
                      });
        }
    }
}
