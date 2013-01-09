using System;
using Bifrost.Concepts;

namespace Chirp.Concepts
{
    public class PublisherId : ConceptAs<Guid>
    {
        public static implicit operator PublisherId(Guid publisher)
        {
            return new PublisherId { Value = publisher };
        }
    }
}