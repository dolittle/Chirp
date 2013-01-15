using Bifrost.Commands;
using Bifrost.Domain;

namespace Chirp.Domain.Messaging.Commands
{
    public class MessageCommandHandler : ICommandHandler
    {
        readonly IAggregatedRootRepository<MessageStream> _streamRepository;

        public MessageCommandHandler(IAggregatedRootRepository<MessageStream> streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public void Handle(ChirpMessage  chirp)
        {
           var stream =  _streamRepository.Get(chirp.Publisher);
           stream.Publish(chirp.Message);
        }

        public void Handle(DeleteChirp delete)
        {
            var stream = _streamRepository.Get(delete.PublishedBy);
            stream.Delete(delete.ChirpToDelete);
        }
    }
} 