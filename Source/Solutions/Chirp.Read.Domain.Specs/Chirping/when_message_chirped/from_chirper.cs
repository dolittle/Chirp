using System;
using Chirp.Concepts;
using Chirp.Events.Chirping;
using Machine.Specifications;
using It = Machine.Specifications.It;

namespace Chirp.Read.Domain.Specs.Chirping.when_message_chirped
{
    [Subject(Scenarios.MessageChirped)]
    public class from_chirper : given.a_chirping_subscriber
    {
        static MessageChirped message_chirped;
        static ChirpId chirp;
        static DateTime chirped_at;

        Establish context = () =>
                                {
                                    chirped_at = DateTime.UtcNow;
                                    chirp = Guid.NewGuid();
                                    message_chirped = new MessageChirped(has_chirped_before)
                                                          {
                                                              ChirpId = chirp,
                                                              ChirpedBy = has_chirped_before,
                                                              ChirpedAt = chirped_at
                                                          };
                                };

        Because of = () => event_subscriber.Process(message_chirped);

        It should_try_to_retrieve_an_existing_my_chirps = () => my_chirps_entity_context.Verify(ec => ec.GetById<ChirperId>(message_chirped.ChirpedBy), Moq.Times.Once());
        It should_add_the_chirp_to_chirpers_chirps = () => has_chirped_before_chirps.Exists(chirp).ShouldBeTrue();
        It should_increment_the_total_count_for_the_chirpers_chirps = () => has_chirped_before_chirps.TotalNumberOfChirps.ShouldEqual(initial_chirp_count + 1);
        It should_update_my_chirps = () => my_chirps_entity_context.Verify(ec => ec.Update(has_chirped_before_chirps), Moq.Times.Once());
        It should_commit_the_update = () => my_chirps_entity_context.Verify(ec => ec.Commit(), Moq.Times.Once());
    }
}