using System;
using Chirp.Concepts;
using Chirp.Events.Chirping;
using Chirp.Read.Domain.Chirping;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Chirp.Read.Domain.Specs.Chirping.when_message_chirped
{
    [Subject(Scenarios.MessageChirped)]
    public class from_first_time_chirper : given.a_chirping_subscriber
    {
        static MessageChirped message_chirped;
        static ChirpId chirp;
        static DateTime chirped_at;
        static MyChirps newly_created_my_chirps;

        Establish context = () =>
                                {
                                    chirped_at = DateTime.UtcNow;
                                    chirp = Guid.NewGuid();
                                    message_chirped = new MessageChirped(first_time_chirper)
                                                          {
                                                              ChirpId = chirp,
                                                              ChirpedBy = first_time_chirper,
                                                              ChirpedAt = chirped_at
                                                          };

                                    my_chirps_entity_context.Setup(ec => ec.Insert(Moq.It.IsAny<MyChirps>()))
                                        .Callback((MyChirps mc) => newly_created_my_chirps = mc);
                                };

        Because of = () => event_subscriber.Process(message_chirped);

        It should_try_to_retrieve_an_existing_my_chirps = () => my_chirps_entity_context.Verify(ec => ec.GetById<Concepts.ChirperId>(message_chirped.ChirpedBy), Times.Once());
        It should_create_a_new_my_chirps_collection_for_this_chirper = () => newly_created_my_chirps.ShouldNotBeNull();
        It should_add_the_chirp_to_chirpers_chirps = () => newly_created_my_chirps.Exists(chirp).ShouldBeTrue();
        It should_set_the_total_number_of_chirps_to_one = () => newly_created_my_chirps.TotalNumberOfChirps.ShouldEqual(1);
        It should_insert_a_new_my_chirps = () => my_chirps_entity_context.Verify(ec => ec.Insert(newly_created_my_chirps), Times.Once());
        It should_commit_the_insert = () => my_chirps_entity_context.Verify(ec => ec.Commit(), Times.Once());
    }
}