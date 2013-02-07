using System.Linq;
using Chirp.Read.Streams;
using Machine.Specifications;
using Chirp = Chirp.Read.Streams.Chirp;

namespace Chirp.Read.Specs.Streams.for_mutable_stream
{
    [Subject(typeof (MutableStream))]
    public class when_creating_with_no_chirps
    {
        static MutableStream stream;

        Because of = () =>stream = new MutableStream();

        It should_create_a_mutable_stream = () => stream.ShouldNotBeNull();
        It should_should_not_have_any_chirps_in_the_stream = () => stream.Chirps().Any().ShouldBeFalse();
    }
}