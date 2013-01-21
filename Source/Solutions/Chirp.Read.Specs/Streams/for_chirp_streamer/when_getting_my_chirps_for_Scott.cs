using System.Linq;
using Chirp.Read.Specs.Streams.for_chirp_streamer.given;
using Chirp.Read.Streams;
using Machine.Specifications;

namespace Chirp.Read.Specs.Streams.for_chirp_streamer
{
    [Subject(typeof (Streamer))]
    public class when_getting_my_chirps_for_Scott : a_chirp_streamer
    {
        static OrderedStream results;
        static OrderedStream expected_results = new OrderedStream(new []
                                                        {
                                                            Chirps.first_valid_chirp_from_Scott,
                                                            Chirps.second_valid_chirp_from_Scott,
                                                            Chirps.third_valid_chirp_from_Scott
                                                        });

        Because of = () => results = streamer.GetMyChirpsFor(Chirpers.Scott.ChirperId);

        It should_retrieve_only_chirps_from_Scott = () => results.All(c => c.ChirpedBy.ChirperId == Chirpers.Scott.ChirperId).ShouldBeTrue();
        It should_retrieve_all_chirps_from_Scott = () => Chirps.GetAll().Except(results).Any(c => c.ChirpedBy.ChirperId == Chirpers.Scott.ChirperId).ShouldBeFalse();
        It should_have_ordered_chirps_by_chirped_at_descending = () => results.SequenceEqual(expected_results).ShouldBeTrue();
    }
}