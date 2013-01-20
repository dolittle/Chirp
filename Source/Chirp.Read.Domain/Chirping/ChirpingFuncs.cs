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

        public override Func<ChirperId, bool> ChirperExists()
        {
            return x => _chirperView.Query.Any(c => c == x);
        }

        public override Func<ChirperId, ChirpId, bool> ChirpIsNotADuplicate()
        {
            return (x, y) =>
                       {
                           var myChirps = _myChirpsView.Query.SingleOrDefault(c => c.Chirper == x);
                           return myChirps == null || !myChirps.Exists(y);
                       };
        }

        public override Func<ChirperId,ChirpId, bool> ChirpHasBeenChirpedByChirper()
        {
            return (x, y) =>
            {
                var myChirps = _myChirpsView.Query.SingleOrDefault(c => c.Chirper == x);
                return myChirps != null && myChirps.Exists(y);
            };
        }
    }
}