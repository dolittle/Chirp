using System;
using Chirp.Concepts;
using Chirp.Concepts.Funcs;

namespace Chirp.Domain.Specs.Chirping
{
    public class TestFuncs : ChirpingFuncs 
    {
        public override Func<ChirperId, bool> ChirperExists()
        {
            return pId => pId == chirpers.valid;
        }
        public override Func<ChirperId,ChirpId, bool> ChirpIsNotADuplicate()
        {
             return (x,y) => y != chirps.duplicate.Id; 
        }
        public override Func<ChirperId, ChirpId, bool> ChirpHasBeenChirpedByChirper()
        {
            return (x,y) => y != chirps.from_a_different_chirper; 
        } 
    }
}