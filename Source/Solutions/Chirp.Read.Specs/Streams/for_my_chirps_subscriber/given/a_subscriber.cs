using Bifrost.Entities;
using Bifrost.Views;
using Chirp.Concepts;
using Chirp.Read.Streams;
using Moq;

namespace Chirp.Read.Specs.Streams.for_my_chirps_subscriber.given
{
    public class a_subscriber
    {
        protected static MyChirpsSubscriber subscriber;
        protected static Mock<IView<Chirper>> chirper_view;
        protected static Mock<IEntityContext<Read.Streams.Chirp>> chirp_entity_context;
        protected static Read.Streams.Chirp new_chirp;

        public a_subscriber()
        {
            chirper_view = new Mock<IView<Chirper>>();
            chirper_view.Setup(v => v.Query).Returns(Chirpers.GetAll());

            chirper_view.Setup(v => v.GetById(It.IsAny<ChirperId>()))
                .Returns((ChirperId id) => Chirpers.Get(id));

            chirp_entity_context = new Mock<IEntityContext<Read.Streams.Chirp>>();
            chirp_entity_context.Setup(ec => ec.Insert(It.IsAny<Read.Streams.Chirp>()))
                .Callback((Read.Streams.Chirp c) => new_chirp = c);

            subscriber = new MyChirpsSubscriber(chirp_entity_context.Object, chirper_view.Object);
        }
    }
}