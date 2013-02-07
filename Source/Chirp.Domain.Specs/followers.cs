using System;
using Chirp.Concepts;

namespace Chirp.Domain.Specs
{
    public class followers
    {
        public static FollowerId valid = new FollowerId { Value = Guid.NewGuid() };
        public static FollowerId valid_id_that_does_not_exist = new FollowerId { Value = Guid.NewGuid() };
        public static FollowerId invalid = new FollowerId { Value = Guid.Empty }; 
    }
}