using System;
using Bifrost.Domain;
using Chirp.Concepts;
using Chirp.Events.Messaging;

namespace Chirp.Domain.Messaging
{
    public class MessageStream : AggregatedRoot
    {
        public MessageStream(Guid publishedBy)
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

        public void Delete(MessageId messageToDelete)
        {
            Apply(new ChirpDeleted(Id)
                      {
                          PublishedBy = Id,
                          DeletedChirp = messageToDelete
                      });
        }
    }
}
