using Bifrost.Commands;
using System;
using Bifrost.Domain;

namespace Chirp.Domain.Streams.Commands
{
    public class CommandHandlers : ICommandHandler
    {
        static Guid GlobalGuid = Guid.Parse("5AD74143-2D17-4FAC-94D6-8B666EDB821B");

        IAggregatedRootRepository<Stream> _streamRepository;

        public CommandHandlers(IAggregatedRootRepository<Stream> streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public void Handle(Chirp chirp)
        {
            var stream = _streamRepository.Get(GlobalGuid);
            stream.Publish(chirp.Message);
        }
    }
}
