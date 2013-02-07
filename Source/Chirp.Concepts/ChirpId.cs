using System;
using Bifrost.Concepts;

namespace Chirp.Concepts
{
    public class ChirpId : ConceptAs<Guid>
    {
        public static implicit operator ChirpId(Guid id)
        {
            return new ChirpId { Value = id };
        }

        public static implicit operator ChirpId(string chirper)
        {
            return new ChirpId { Value = Guid.Parse(chirper) };
        }
    }
}