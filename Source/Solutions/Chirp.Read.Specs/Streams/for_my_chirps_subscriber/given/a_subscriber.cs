using System;
using Bifrost.Entities;
using Chirp.Read.Streams;
using Moq;

namespace Chirp.Read.Specs.Streams.for_my_chirps_subscriber.given
{
    public class a_subscriber
    {
        protected static MyChirpsSubscriber subscriber;
        protected static Mock<IEntityContext<Chirper>> chirper_entity_context;
        protected static Mock<IEntityContext<Read.Streams.Chirp>> chirp_entity_context;
        protected static Read.Streams.Chirp new_chirp;

        public a_subscriber()
        {
            chirper_entity_context = new Mock<IEntityContext<Chirper>>();
            chirper_entity_context.Setup(v => v.GetById(It.IsAny<Guid>()))
                .Returns((Guid id) => Chirpers.Get(id));

            chirp_entity_context = new Mock<IEntityContext<Read.Streams.Chirp>>();
            chirp_entity_context.Setup(ec => ec.Insert(It.IsAny<Read.Streams.Chirp>()))
                .Callback((Read.Streams.Chirp c) => new_chirp = c);

            subscriber = new MyChirpsSubscriber(chirp_entity_context.Object, chirper_entity_context.Object);
        }
    }
}