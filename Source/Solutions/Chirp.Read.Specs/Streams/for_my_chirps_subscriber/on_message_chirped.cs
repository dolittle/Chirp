using Chirp.Concepts;
using Chirp.Events.Chirping;
using Chirp.Read.Specs.Streams.for_my_chirps_subscriber.given;
using Chirp.Read.Streams;
using Machine.Specifications;

namespace Chirp.Read.Specs.Streams.for_my_chirps_subscriber
{
    [Subject(typeof(MyChirpsSubscriber), Scenarios.MessageChirped)]
    public class on_message_chirped : a_subscriber
    {
        static MessageChirped message_chirped;

        Establish context = () =>
                                {
                                    message_chirped = Chirps.BuildCorrespondingMessageChirpedEventFrom(Chirps.valid_chirp_from_Hannah);
                                };

        Because of = () => subscriber.Process(message_chirped);

        It should_retrieve_the_chirper = () => chirper_entity_context.Verify(v => v.GetById(message_chirped.ChirpedBy), Moq.Times.Once());
        It should_create_a_new_chirp_with_the_correct_values = () =>
                                                                   {
                                                                       new_chirp.ShouldNotBeNull();
                                                                       new_chirp.ChirpedBy.ShouldEqual(Chirps.valid_chirp_from_Hannah.ChirpedBy);
                                                                       new_chirp.Content.ShouldEqual(Chirps.valid_chirp_from_Hannah.Content);
                                                                       new_chirp.ChirpedAt.ShouldEqual(Chirps.valid_chirp_from_Hannah.ChirpedAt);
                                                                       new_chirp.Id.ShouldEqual(Chirps.valid_chirp_from_Hannah.Id);
                                                                   };
        It should_persist_the_new_chirp = () =>
                                              {
                                                  chirp_entity_context.Verify(ec => ec.Insert(new_chirp), Moq.Times.Once());
                                                  chirp_entity_context.Verify(ec => ec.Commit(), Moq.Times.Once());
                                              };
    }
}