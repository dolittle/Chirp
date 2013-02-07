using System;
using Bifrost.Entities;
using Chirp.Concepts;

namespace Chirp.Read.Domain.Chirping
{
    public class ChirpingFuncs : Concepts.Funcs.ChirpingFuncs
    {
        readonly IEntityContext<MyChirps> _myChirpsEntityContext;

        public ChirpingFuncs(IEntityContext<MyChirps> myChirpsEntityContext)
        {
            _myChirpsEntityContext = myChirpsEntityContext;
        }

        public override Func<Concepts.ChirperId, ChirpId, bool> ChirpIsNotADuplicate()
        {
            return (x, y) =>
                       {
                           var myChirps = _myChirpsEntityContext.GetById(x);
                           return myChirps == null || !myChirps.Exists(y);
                       };
        }

        public override Func<Concepts.ChirperId,ChirpId, bool> ChirpHasBeenChirpedByChirper()
        {
            return (x, y) =>
            {
                var myChirps = _myChirpsEntityContext.GetById(x);
                return myChirps != null && myChirps.Exists(y);
            };
        }
    }
}