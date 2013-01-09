using Bifrost.Commands;
using Chirp.Concepts;

namespace Chirp.Domain.Streams.Commands
{
    public class ChirpMessage : Command
    {
        public PublisherId PublisherId { get; set; }
        public Message Message { get; set; }
    }
}