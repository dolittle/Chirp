using System;
using Bifrost.Concepts;

namespace Chirp.Concepts
{
    public class SubscriberId : ConceptAs<Guid>
    {
        public static implicit operator SubscriberId(Guid subscriber)
        {
            return new SubscriberId { Value = subscriber };
        }
    }
}