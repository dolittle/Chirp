using System.Collections.Generic;
using System.Linq;
using Chirp.Concepts;
using Chirp.Read.Streams;

namespace Chirp.Web.Services
{
    public class StreamService
    {
        readonly IStreamer _streamer;

        public StreamService(IStreamer streamer)
        {
            _streamer = streamer;
        }

        public IEnumerable<Read.Streams.Chirp> GetMyChirps(ChirperId chirper)
        {
            return _streamer.GetMyChirps(chirper).OrderByDescending(c => c.ChirpedAt);
        }
    }
}