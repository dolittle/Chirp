using System;
using Chirp.Domain.Streams;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Streams.for_Stream.given
{
    public class a_stream
    {
        protected static Guid user_id = Guid.NewGuid();
        protected static Stream stream;

        Establish context = () => stream = new Stream(user_id);
    }
}
