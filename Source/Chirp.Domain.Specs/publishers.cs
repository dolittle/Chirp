using System;
using Chirp.Concepts;

namespace Chirp.Domain.Specs
{
    public class publishers
    {
        public static PublisherId valid = new PublisherId { Value = Guid.NewGuid() };
        public static PublisherId valid_id_that_does_not_exist = new PublisherId { Value = Guid.NewGuid() };
        public static PublisherId invalid = new PublisherId { Value = Guid.Empty };
    }
}