using System;
using Chirp.Concepts;

namespace Chirp.Domain.Specs
{
    public class subscribers
    {
        public static SubscriberId valid = new SubscriberId { Value = Guid.NewGuid() };
        public static SubscriberId valid_id_that_does_not_exist = new SubscriberId { Value = Guid.NewGuid() };
        public static SubscriberId invalid = new SubscriberId { Value = Guid.Empty }; 
    }
}