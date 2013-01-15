
using System;
using Chirp.Concepts;
using Chirp.Domain.Messaging;

namespace Chirp.Domain.Specs
{
    public class messages
    {
        public static readonly Message valid_message_with_no_tags = new Message { Id = Guid.NewGuid(), Content = "This is a message with no tags." };
        public static readonly Message invalid_id = new Message { Content = "This message has no message Id." };
        public static readonly Message empty = new Message { Id = Guid.NewGuid(), Content = string.Empty };
        public static readonly Message max_length = new Message { Id = Guid.NewGuid(), Content = new string('A', Message.MaxLength) };
        public static readonly Message too_long = new Message { Id = Guid.NewGuid(), Content = new string('B', Message.MaxLength + 1) };
        public static readonly Message duplicate = new Message { Id = Guid.NewGuid(), Content = "This is a duplicate message" };
        public static readonly MessageId does_not_exist = Guid.NewGuid();
        public static readonly MessageId from_a_different_publisher = Guid.NewGuid();
    }
}