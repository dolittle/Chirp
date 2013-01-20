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
        public override Func<ChirpId, bool> ChirpExists()
        {
            return mId => mId != chirps.does_not_exist;
        }
        public override Func<ChirperId,ChirpId, bool> ChirpIsNotADuplicate()
        {
             return (x,y) => y != chirps.duplicate.Id; 
        }
        public override Func<ChirpId, bool> ChirpHasBeenChirpedByChirper()
        {
            return id => id != chirps.from_a_different_chirper; 
        } 
    }
}