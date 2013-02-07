using System.Linq;
using Chirp.Concepts;
using Chirp.Events.Chirping;
using Chirp.Read.Streams;
using Machine.Specifications;

namespace Chirp.Read.Specs.Streams.for_reading_stream_subscriber
{
    [Subject(typeof(ReadingStreamSubscriber), Scenarios.MessageChirped)]
    public class on_message_chirped : given.a_subscriber
    {
        static MessageChirped message_chirped;

        Establish context = () =>
                                {
                                    message_chirped = Chirps.BuildCorrespondingMessageChirpedEventFrom(Chirps.valid_chirp_from_Hannah);
                                };

        Because of = () => subscriber.Process(message_chirped);

        It should_retrieve_the_chirpers_followers = () =>my_followers_repository.Verify(r => r.GetById((ChirperId)message_chirped.ChirpedBy),Moq.Times.Once());
        It should_retrieve_the_reading_stream_for_each_follower = () =>
                                                                      {
                                                                          reading_stream_repository.Verify(r => r.GetById((ReaderId)first_follower.Value), Moq.Times.Once());
                                                                          reading_stream_repository.Verify(r => r.GetById((ReaderId)second_follower.Value), Moq.Times.Once());
                                                                      };
        It should_append_the_chirp_to_the_reading_stream_of_each_follower = () =>
                                                                                {
                                                                                    stream_for_first_follower.Chirps().Count().ShouldEqual(1);
                                                                                    stream_for_second_follower.Chirps().Count().ShouldEqual(1);
                                                                                };
        It should_update_the_reading_stream_of_each_follower = () =>
                                                                   {
                                                                       reading_stream_repository.Verify(r => r.Update(stream_for_first_follower),Moq.Times.Once());
                                                                       reading_stream_repository.Verify(r => r.Update(stream_for_second_follower),Moq.Times.Once());
                                                                   };

    }
}