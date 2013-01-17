using System;
using Chirp.Concepts;
using Chirp.Domain.Chirping;

namespace Chirp.Domain.Specs.Chirping
{
    public class Funcs
    {
        public static readonly Func<ChirperId, bool> PublisherExists = pId => pId == chirpers.valid;
        public static readonly Func<ChirpId, bool> MessageExists = mId => mId != chirps.does_not_exist;
        public static readonly Func<Domain.Chirping.Chirp, bool> MessageIsUnique = m => m.Id != chirps.duplicate.Id; 
        public static readonly Func<ChirpId, bool> MessageHasBeenPublishedByPublisher = id => id != chirps.from_a_different_chirper; 
    }
}