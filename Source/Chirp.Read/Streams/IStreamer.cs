using System.Linq;
using Chirp.Concepts;

namespace Chirp.Read.Streams
{
    public interface IStreamer
    {
        IQueryable<Chirp> GetMyChirps(ChirperId chirper);
    }
}