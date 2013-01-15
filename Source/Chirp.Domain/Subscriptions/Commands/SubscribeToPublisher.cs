using Bifrost.Commands;
using Chirp.Concepts;

namespace Chirp.Domain.Subscriptions.Commands
{
    public class SubscribeToPublisher : Command
    {
        public SubscriberId Subscriber { get; set; }
        public PublisherId Publisher { get; set; }
    }
}