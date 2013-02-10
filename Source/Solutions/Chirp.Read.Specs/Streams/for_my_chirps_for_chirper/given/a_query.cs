using System;
using System.Collections.Generic;
using System.Linq;
using Bifrost.Read;
using Chirp.Concepts;
using Chirp.Read.Streams;
using Machine.Specifications;
using Moq;

namespace Chirp.Read.Specs.Streams.for_my_chirps_for_chirper.given
{
    public class a_query
    {
        protected static MyChirpsForChirper query;
        protected static Mock<IReadModelRepositoryFor<Read.Streams.Chirp>> chirp_repository;
        protected static ChirperId chirper_who_has_chirped;
        protected static ChirperId chirper_who_has_not_chirped;

        Establish context = () =>
                                {
                                    chirper_who_has_chirped = Guid.NewGuid();
                                    chirper_who_has_not_chirped = Guid.NewGuid();
                                    chirp_repository = new Mock<IReadModelRepositoryFor<Read.Streams.Chirp>>();
                                    chirp_repository.Setup(c => c.Query).Returns(new List<Read.Streams.Chirp>
                                                                                     {
                                                                                         new Read.Streams.Chirp { ChirpedBy = new Chirper() { ChirperId = chirper_who_has_chirped }}
                                                                                     }.AsQueryable());

                                    query = new MyChirpsForChirper(chirp_repository.Object);
                                };
    }
}