using System;
using System.Linq;
using Chirp.Read.Streams;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Chirp.Read.Specs.Streams.for_reading_stream_for_reader
{
    [Subject(typeof (ReadingStreamForReader))]
    public class when_reader_has_stream : given.a_query
    {
        static ReadingStream reading_stream;

        Establish context = () =>
                                {
                                    query.ReaderId = reader_with_stream;
                                };

        Because of = () => reading_stream = query.Query.FirstOrDefault();

        It should_ask_the_repository_for_this_readers_stream = () => reading_stream_repository.Verify(r => r.GetById(reader_with_stream), Times.Once());
        It should_have_a_reading_stream_for_this_reader = () => reading_stream.Reader.ShouldEqual(reader_with_stream);
        It should_have_chirps_in_the_stream = () => reading_stream.Content.Any().ShouldBeTrue();
    }
}