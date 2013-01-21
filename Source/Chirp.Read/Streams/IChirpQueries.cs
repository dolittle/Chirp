using System.Linq;
using Bifrost.Views;
using Chirp.Concepts;

namespace Chirp.Read.Streams
{
    public class Streamer : IChirpStreamer
    {
        readonly IView<Chirp> _chirpView;
        readonly IView<ReadingStream> _readingStreamView;

        public Streamer(IView<Chirp> chirpView, IView<ReadingStream> readingStreamView )
        {
            _chirpView = chirpView;
            _readingStreamView = readingStreamView;
        }

        public OrderedStream GetMyChirpsFor(ChirperId chirper)
        {
            return new OrderedStream(_chirpView.Query.Where(c => c.ChirpedBy.ChirperId == chirper).AsEnumerable());
        }

        public ReadingStream GetReadingStreamFor(ReaderId reader)
        {
            var readingStream = _readingStreamView.Query.SingleOrDefault(s => s.Reader == reader);
            return readingStream ?? new ReadingStream(reader);
        }
    }
}