using System;
using Bifrost.Concepts;

namespace Chirp.Concepts
{
    public class ChirperId : ConceptAs<Guid>
    {
        public static implicit operator ChirperId(Guid publisher)
        {
            return new ChirperId { Value = publisher };
        }
    }
}