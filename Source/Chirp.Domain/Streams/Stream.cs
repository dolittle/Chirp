using System;
using Bifrost.Domain;
using Chirp.Events.Streams;

namespace Chirp.Domain.Streams
{
    public class Stream : AggregatedRoot
    {
        public Stream(Guid userId)
            : base(userId)
        {
        }

        public void Publish(string message)
        {
            Apply(new MessagePublished(Id) { Message = message });
        }

        public void DirectMessage(Guid receiver, string message)
        {
            Apply(new DirectMessageSent(Id) { Receiver = receiver, Message = message });
        }
    }
}
