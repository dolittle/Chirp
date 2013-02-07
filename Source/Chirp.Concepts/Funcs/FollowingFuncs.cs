using System;

namespace Chirp.Concepts.Funcs
{
    public abstract class FollowingFuncs
    {
        public abstract Func<FollowerId, ChirperId, bool> Follows();
        //public abstract Func<ChirperId, bool> ChirperExists();
        //public abstract Func<ChirperId, ChirpId, bool> ChirpIsNotADuplicate();
        //public abstract Func<ChirperId, ChirpId, bool> ChirpHasBeenChirpedByChirper();  
    }
}