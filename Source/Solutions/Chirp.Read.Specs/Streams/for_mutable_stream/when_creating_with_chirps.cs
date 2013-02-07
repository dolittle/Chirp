using System.Collections.Generic;
using System.Linq;
using Chirp.Read.Streams;
using Machine.Specifications;

namespace Chirp.Read.Specs.Streams.for_mutable_stream
{
    [Subject(typeof(MutableStream))]
    public class when_creating_with_chirps
    {
        static MutableStream stream;
        static IEnumerable<Read.Streams.Chirp> existing_chirps;

        Establish context = () =>
                                {
                                    existing_chirps = Chirps.GetAll();
                                };

        Because of = () => stream = new MutableStream(existing_chirps);

        It should_create_a_mutable_stream = () => stream.ShouldNotBeNull();
        It should_should_contain_the_supplied_chirps = () => stream.Chirps().SequenceEqual(Chirps.GetAll()).ShouldBeTrue();
    }
}