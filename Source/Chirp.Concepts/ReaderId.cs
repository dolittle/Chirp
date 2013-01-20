using System;
using Bifrost.Concepts;

namespace Chirp.Concepts
{
    public class ReaderId : ConceptAs<Guid>
    {
        public static implicit operator ReaderId(Guid readerId)
        {
            return new ReaderId { Value = readerId };
        }
    }
}