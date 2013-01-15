using Bifrost.Commands;
using Chirp.Concepts;

namespace Chirp.Domain.Messaging.Commands
{
    public class DeleteChirp : Command
    {
        public PublisherId PublishedBy { get; set; }
        public MessageId ChirpToDelete { get; set; }
    }
}