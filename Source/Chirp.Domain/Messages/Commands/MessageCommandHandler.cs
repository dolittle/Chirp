using Bifrost.Commands;
using Bifrost.Domain;

namespace Chirp.Domain.Messages.Commands
{
    public class MessageCommandHandler : ICommandHandler
    {
        readonly IAggregatedRootFactory<Chirp> _chirpFactory;

        public MessageCommandHandler(IAggregatedRootFactory<Chirp> chirpFactory )
        {
            _chirpFactory = chirpFactory;
        }

        public void Handle(ChirpMessage  publish)
        {
           var chirp =  _chirpFactory.Create(publish.Id);
            chirp.Publish(publish.Publisher, publish.Message);
        }
    }
} 