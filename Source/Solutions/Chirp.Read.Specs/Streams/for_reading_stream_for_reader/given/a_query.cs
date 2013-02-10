using System;
using Bifrost.Read;
using Chirp.Concepts;
using Chirp.Read.Streams;
using Machine.Specifications;
using Moq;
using Chirp = Chirp.Read.Streams.Chirp;

namespace Chirp.Read.Specs.Streams.for_reading_stream_for_reader.given
{
    public class a_query
    {
        protected static ReadingStreamForReader query;
        protected static Mock<IReadModelRepositoryFor<ReadingStream>> reading_stream_repository;
        protected static ReaderId reader_with_stream;
        protected static ReaderId reader_with_no_stream;

        Establish context = () =>
                                {
                                    reader_with_no_stream = Guid.NewGuid();
                                    reader_with_stream = Guid.NewGuid();
                                    var readingStream = new ReadingStream(reader_with_stream);
                                    readingStream.AppendToStream(new Read.Streams.Chirp());

                                    reading_stream_repository = new Mock<IReadModelRepositoryFor<ReadingStream>>();
                                    reading_stream_repository.Setup(r => r.GetById(reader_with_no_stream)).Returns((ReaderId id) => null);
                                    reading_stream_repository.Setup(r => r.GetById(reader_with_stream)).Returns(readingStream);
                                    query = new ReadingStreamForReader(reading_stream_repository.Object);
                                };

    }
}