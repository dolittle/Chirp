using Bifrost.Views;
using Chirp.Read.Streams;
using Moq;

namespace Chirp.Read.Specs.Streams.for_chirp_streamer.given
{
    public class a_chirp_streamer
    {
        protected static Mock<IView<Read.Streams.Chirp>> chirp_view;
        protected static Mock<IView<ReadingStream>> reading_stream_view;
        protected static Streamer streamer;

        public a_chirp_streamer()
        {
            chirp_view = Chirps.GetMockedChirpView();
            reading_stream_view = new Mock<IView<ReadingStream>>();
            streamer = new Streamer(chirp_view.Object, reading_stream_view.Object);
        }
    }
}