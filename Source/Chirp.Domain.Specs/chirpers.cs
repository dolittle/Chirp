using System;
using Chirp.Concepts;

namespace Chirp.Domain.Specs
{
    public class chirpers
    {
        public static ChirperId valid = new ChirperId { Value = Guid.NewGuid() };
        public static ChirperId valid_id_that_does_not_exist = new ChirperId { Value = Guid.NewGuid() };
        public static ChirperId invalid = new ChirperId { Value = Guid.Empty };
    }
}