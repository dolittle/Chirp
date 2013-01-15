using System;
using Chirp.Concepts;
using Chirp.Domain.Messaging;

namespace Chirp.Domain.Specs.Messaging
{
    public class Funcs
    {
        public static readonly Func<PublisherId, bool> PublisherExists = pId => pId == publishers.valid;
        public static readonly Func<MessageId, bool> MessageExists = mId => mId != messages.does_not_exist;
        public static readonly Func<Message, bool> MessageIsUnique = m => m.Id != messages.duplicate.Id; 
        public static readonly Func<MessageId, bool> MessageHasBeenPublishedByPublisher = id => id != messages.from_a_different_publisher; 
    }
}