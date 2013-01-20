using System;

namespace Chirp.Concepts.Funcs
{
    public abstract class ChirpingFuncs
    {
        public abstract Func<ChirperId, bool> ChirperExists();
        public abstract Func<ChirperId, ChirpId, bool> ChirpIsNotADuplicate();
        public abstract Func<ChirperId, ChirpId, bool> ChirpHasBeenChirpedByChirper();  
    }
}