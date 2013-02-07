using System;
using System.Collections.Generic;
using System.Linq;
using Bifrost.Entities;
using Chirp.Concepts;
using Chirp.Read.Domain.Chirping;
using Machine.Specifications;
using Moq;
using ChirperId = Chirp.Concepts.ChirperId;
using It = Moq.It;

namespace Chirp.Read.Domain.Specs.Chirping.when_message_chirped.given
{
    public class a_chirping_subscriber
    {
        protected static ChirperId has_chirped_before = Guid.NewGuid();
        protected static ChirperId first_time_chirper = Guid.NewGuid();
        protected static MyChirps has_chirped_before_chirps;
        protected static MyChirps first_time_chirper_chirps;
        protected static int initial_chirp_count;

        protected static MyChirpsSubscriber event_subscriber;
        protected static Mock<IEntityContext<MyChirps>> my_chirps_entity_context;

        protected static IEnumerable<ChirpId> existing_chirps;

        protected static ChirpId first_existing_chirp;
        protected static ChirpId second_existing_chirp;
        protected static ChirpId third_existing_chirp;

        Establish context = () =>
                                {
                                    has_chirped_before_chirps = new MyChirps();

                                    var now = DateTime.UtcNow;

                                    first_existing_chirp = Guid.NewGuid();
                                    second_existing_chirp = Guid.NewGuid();
                                    third_existing_chirp = Guid.NewGuid();

                                    existing_chirps = new List<ChirpId>()
                                                          {
                                                              first_existing_chirp,
                                                              second_existing_chirp,
                                                              third_existing_chirp
                                                          };

                                    my_chirps_entity_context = new Mock<IEntityContext<MyChirps>>();
                                    event_subscriber = new MyChirpsSubscriber(my_chirps_entity_context.Object);

                                    has_chirped_before_chirps = new MyChirps(has_chirped_before);
                                    foreach (var existingChirp in existing_chirps)
                                    {
                                        has_chirped_before_chirps.AddChirp(existingChirp);
                                    }

                                    initial_chirp_count = has_chirped_before_chirps.TotalNumberOfChirps;

                                    var entities = new List<MyChirps> {has_chirped_before_chirps}.AsQueryable();
                                    my_chirps_entity_context.Setup(ec => ec.GetById(It.IsAny<ChirperId>()))
                                        .Returns((ChirperId id) => entities.SingleOrDefault(e => e.Chirper == id));
                                };
    }
}