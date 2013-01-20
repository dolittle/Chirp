using Chirp.Concepts;

namespace Chirp.Read.Streams
{
    public interface IChirpStreamer
    {
        OrderedStream GetMyChirpsFor(ChirperId chirper);
        ReadingStream GetReadingStreamFor(ReaderId chirper);
    }
}