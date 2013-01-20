using System;
using System.Collections.Generic;
using Bifrost.Entities;
using Chirp.Concepts;
using Chirp.Read.Domain.Chirping;
using Moq;

namespace Chirp.Read.Domain.Specs.Chirping.when_message_chirped.given
{
    public class a_chirping_subscriber
    {
        protected static ChirperId has_chirped_before = Guid.NewGuid();
        protected static ChirperId first_time_chirper = Guid.NewGuid();
        protected static MyChirps my_chirps;
        protected static int initial_chirp_count;

        protected static MyChirpsSubscriber event_subscriber;
        protected static Mock<IEntityContext<MyChirps>> my_chirps_entity_context;

        protected static IEnumerable<ChirpId> existing_chirps;

        protected static ChirpId first_existing_chirp;
        protected static ChirpId second_existing_chirp;
        protected static ChirpId third_existing_chirp;

        public a_chirping_subscriber()
        {
            my_chirps = new MyChirps();

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

            my_chirps = new MyChirps();
            foreach (var existingChirp in existing_chirps)
            {
                my_chirps.AddChirp(existingChirp);
            }

            initial_chirp_count = my_chirps.TotalNumberOfChirps;

            my_chirps_entity_context.Setup(ec => ec.GetById(has_chirped_before))
                .Returns(my_chirps);
        }
    }
}