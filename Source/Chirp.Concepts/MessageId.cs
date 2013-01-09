using System;
using Bifrost.Concepts;

namespace Chirp.Concepts
{
    public class MessageId : ConceptAs<Guid>
    {
        public static implicit operator MessageId(Guid id)
        {
            return new MessageId { Value = id };
        }
    }
}