using Bifrost.Commands;
using Bifrost.Domain;

namespace Chirp.Domain.Streams.Commands
{
    public class MessageCommandHandler : ICommandHandler
    {
        readonly IAggregatedRootRepository<Stream> _streamRepository;

        public MessageCommandHandler(IAggregatedRootRepository<Stream> streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public void Handle(ChirpMessage  chirp)
        {
           var stream =  _streamRepository.Get(chirp.PublisherId);
           stream.Publish(chirp.Message);
        }
    }
} 