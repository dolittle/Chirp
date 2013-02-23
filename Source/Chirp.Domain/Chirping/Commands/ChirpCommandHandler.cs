using Bifrost.Commands;
using Bifrost.Domain;

namespace Chirp.Domain.Chirping.Commands
{
    public class ChirpCommandHandler : IHandleCommands
    {
        readonly IAggregatedRootRepository<ChirpStream> _streamRepository;

        public ChirpCommandHandler(IAggregatedRootRepository<ChirpStream> streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public void Handle(ChirpMessage  chirp)
        {
           var stream =  _streamRepository.Get(chirp.Chirper);
           stream.Publish(chirp.Chirp);
        }

        public void Handle(DeleteChirp delete)
        {
            var stream = _streamRepository.Get(delete.ChirpedBy);
            stream.Delete(delete.ChirpToDelete);
        }
    }
} 