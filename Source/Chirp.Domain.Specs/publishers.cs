using System;
using Chirp.Domain.Messages;

namespace Chirp.Domain.Specs
{
    public class publishers
    {
        public static readonly Guid valid_publisher_id = Guid.NewGuid();

        public static Publisher valid = new Publisher {Id = valid_publisher_id };
    }
}