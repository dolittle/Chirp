using System;
using Bifrost.Concepts;

namespace Chirp.Concepts
{
    public class ChirperId : ConceptAs<Guid>
    {
        public static implicit operator ChirperId(Guid chirper)
        {
            return new ChirperId { Value = chirper };
        }
    }
}