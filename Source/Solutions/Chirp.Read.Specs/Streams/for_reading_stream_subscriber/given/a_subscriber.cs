using System;
using Bifrost.Read;
using Chirp.Concepts;
using Chirp.Read.Domain.Follow;
using Chirp.Read.Follow;
using Chirp.Read.Streams;
using Machine.Specifications;
using Moq;

namespace Chirp.Read.Specs.Streams.for_reading_stream_subscriber.given
{
    public class a_subscriber
    {
        protected static Mock<IReadModelRepositoryFor<Chirper>> chirper_repository;
        protected static Mock<IReadModelRepositoryFor<ChirpersFollowers>> my_followers_repository;
        protected static Mock<IReadModelRepositoryFor<ReadingStream>> reading_stream_repository;
        protected static ReadingStreamSubscriber subscriber;
        protected static ChirpersFollowers followers_for_hannah;
        protected static FollowerId first_follower;
        protected static FollowerId second_follower;
        protected static ReadingStream stream_for_first_follower;
        protected static ReadingStream stream_for_second_follower;

        Establish context = () =>
                                {
                                    first_follower = Guid.NewGuid();
                                    second_follower = Guid.NewGuid();
                                    followers_for_hannah = new ChirpersFollowers(Chirpers.Hannah.ChirperId);
                                    followers_for_hannah.AddFollower(first_follower);
                                    followers_for_hannah.AddFollower(second_follower);

                                    stream_for_first_follower = new ReadingStream(first_follower.Value);
                                    stream_for_second_follower = new ReadingStream(second_follower.Value);

                                    chirper_repository = new Mock<IReadModelRepositoryFor<Chirper>>();
                                    my_followers_repository = new Mock<IReadModelRepositoryFor<ChirpersFollowers>>();
                                    reading_stream_repository = new Mock<IReadModelRepositoryFor<ReadingStream>>();

                                    chirper_repository.Setup(r => r.GetById(Chirpers.Hannah.ChirperId)).Returns(Chirpers.Hannah);

                                    my_followers_repository.Setup(r => r.GetById(Chirpers.Hannah.ChirperId))
                                        .Returns(followers_for_hannah);

                                    reading_stream_repository.Setup(r => r.GetById((ReaderId)first_follower.Value)).Returns(stream_for_first_follower);
                                    reading_stream_repository.Setup(r => r.GetById((ReaderId)second_follower.Value)).Returns(stream_for_second_follower);

                                    subscriber = new ReadingStreamSubscriber(reading_stream_repository.Object, chirper_repository.Object, my_followers_repository.Object);
                                };
    }
}