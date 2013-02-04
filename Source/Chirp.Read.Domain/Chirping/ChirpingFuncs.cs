using System;
using System.Linq;
using Bifrost.Entities;
using Bifrost.Views;
using Chirp.Concepts;

namespace Chirp.Read.Domain.Chirping
{
    public class ChirpingFuncs : Concepts.Funcs.ChirpingFuncs
    {
        readonly IEntityContext<MyChirps> _myChirpsEntityContext;
        readonly IEntityContext<ChirperId> _chirperEntityContext;

        public ChirpingFuncs(IEntityContext<MyChirps> myChirpsEntityContext, IEntityContext<ChirperId> chirperEntityContext)
        {
            _myChirpsEntityContext = myChirpsEntityContext;
            _chirperEntityContext = chirperEntityContext;
        }

        public override Func<Concepts.ChirperId, bool> ChirperExists()
        {
            return id => _chirperEntityContext.GetById(id) != null;
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