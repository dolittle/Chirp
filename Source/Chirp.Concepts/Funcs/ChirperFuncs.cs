using System;

namespace Chirp.Concepts.Funcs
{
    public abstract class ChirperFuncs
    {
        public abstract Func<ChirperId, bool> ChirperExists(); 
    }
}