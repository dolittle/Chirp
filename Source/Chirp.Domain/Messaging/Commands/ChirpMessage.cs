using Bifrost.Commands;
using Chirp.Concepts;

namespace Chirp.Domain.Messaging.Commands
{
    public class ChirpMessage : Command
    {
        public PublisherId Publisher { get; set; }
        public Message Message { get; set; }
    }
}