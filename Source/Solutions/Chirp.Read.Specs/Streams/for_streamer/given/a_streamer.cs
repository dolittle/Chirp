using Bifrost.Views;
using Chirp.Read.Streams;
using Moq;
using read = Chirp.Read.Streams;

namespace Chirp.Read.Specs.Streams.for_streamer.given
{
    public class a_streamer
    {
        protected static Mock<IView<read.Chirp>> chirp_view;
        protected static Streamer streamer;

        public a_streamer()
        {
            chirp_view = Chirps.GetMockedChirpView();
            streamer = new Streamer(chirp_view.Object);
        }
    }
}