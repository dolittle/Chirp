using System.Linq;
using Bifrost.Views;
using Chirp.Concepts;

namespace Chirp.Read.Streams
{
    public class Streamer : IStreamer
    {
        readonly IView<Chirp> _chirpView;

        public Streamer(IView<Chirp> chirpView)
        {
            _chirpView = chirpView;
        }

        public IQueryable<Chirp> GetMyChirps(ChirperId chirper)
        {
            return _chirpView.Query.Where(c => c.ChirpedBy.Id == chirper);
        }
    }
}