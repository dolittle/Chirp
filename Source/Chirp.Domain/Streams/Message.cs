using Chirp.Concepts;

namespace Chirp.Domain.Streams
{
    public class Message
    {
        public static int MaxLength = 140;

        public MessageId Id { get; set; }
        public string Content { get; set; }
    }
}