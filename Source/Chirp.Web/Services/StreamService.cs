using Chirp.Views.Streams;
using System.Collections.Generic;

namespace Chirp.Web.Services
{
    public class StreamService
    {
        IStreamRepository _streamRepository;

        public StreamService(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public IEnumerable<Views.Streams.Chirp> GetPublic()
        {
            return _streamRepository.GetPublic();
        }
    }
}