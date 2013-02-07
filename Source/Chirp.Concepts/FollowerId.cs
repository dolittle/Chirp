using System;
using Bifrost.Concepts;

namespace Chirp.Concepts
{
    public class FollowerId : ConceptAs<Guid>
    {
        public static implicit operator FollowerId(Guid subscriber)
        {
            return new FollowerId { Value = subscriber };
        }
    }
}