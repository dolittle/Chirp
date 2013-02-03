using System;
using System.Linq;
using Bifrost.Views;
using Chirp.Concepts;

namespace Chirp.Read.Domain.Chirping
{
    public class ChirpingFuncs : Concepts.Funcs.ChirpingFuncs
    {
        readonly IView<MyChirps> _myChirpsView;
        readonly IView<ChirperId> _chirperView; 

        public ChirpingFuncs(IView<MyChirps> myChirpsView, IView<ChirperId> chirperView)
        {
            _myChirpsView = myChirpsView;
            _chirperView = chirperView;
        }

        public override Func<Concepts.ChirperId, bool> ChirperExists()
        {
            return id => _chirperView.Query.Any(c => c.Id == id);
        }

        public override Func<Concepts.ChirperId, ChirpId, bool> ChirpIsNotADuplicate()
        {
            return (x, y) =>
                       {
                           var myChirps = _myChirpsView.Query.SingleOrDefault(c => c.Chirper == x);
                           return myChirps == null || !myChirps.Exists(y);
                       };
        }

        public override Func<Concepts.ChirperId,ChirpId, bool> ChirpHasBeenChirpedByChirper()
        {
            return (x, y) =>
            {
                var myChirps = _myChirpsView.Query.SingleOrDefault(c => c.Chirper == x);
                return myChirps != null && myChirps.Exists(y);
            };
        }
    }
}