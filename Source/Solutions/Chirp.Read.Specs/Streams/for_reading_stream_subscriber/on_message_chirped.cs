using Chirp.Concepts;
using Chirp.Events.Chirping;
using Chirp.Read.Specs.Streams.for_my_chirps_subscriber.given;
using Chirp.Read.Streams;
using Machine.Specifications;

namespace Chirp.Read.Specs.Streams.for_reading_stream_subscriber
{
    [Subject(typeof(ReadingStreamSubscriber), Scenarios.MessageChirped)]
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

        It should_retrieve_the_chirpers_followers = () => { };
        It should_retrieve_the_reading_stream_for_each_follower = () => { };
        It should_append_the_chirp_to_the_reading_stream_of_each_follower = () => { };
        It should_update_the_reading_stream_of_each_follower = () => { };
        It should_commit_the_updates = () => { };
    }
}