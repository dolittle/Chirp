using System;
using System.Linq;
using read = Chirp.Read.Streams;
using Machine.Specifications;
using Chirp.Read.Streams;

namespace Chirp.Read.Specs.Streams.for_streamer
{
    [Subject(typeof (Streamer))]
    public class when_getting_my_chirps_for_Scott : given.a_streamer
    {
        static IQueryable<read.Chirp> results;

        Because of = () => results = streamer.GetMyChirps(Chirpers.Scott.Id);

        It should_retrieve_only_chirps_from_Scott = () => results.All(c => c.ChirpedBy.Id == Chirpers.Scott.Id).ShouldBeTrue();
        It should_retrieve_all_chirps_from_Scott = () => Chirps.GetAll().Except(results).Any(c => c.ChirpedBy.Id == Chirpers.Scott.Id).ShouldBeFalse();
    }
}