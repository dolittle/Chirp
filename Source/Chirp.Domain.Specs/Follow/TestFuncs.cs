using System;
using Chirp.Concepts;
using Chirp.Concepts.Funcs;

namespace Chirp.Domain.Specs.Follow
{
    public class TestChirperFuncs : ChirperFuncs
    {
        public override Func<ChirperId, bool> ChirperExists()
        {
            return id => id != chirpers.valid_id_that_does_not_exist;
        }
    }

    public class TestFollowingFuncs : FollowingFuncs
    {
        public override Func<FollowerId, ChirperId, bool> Follows()
        {
            return (fId,cId) => cId == chirpers.following;
        }
    }
}
