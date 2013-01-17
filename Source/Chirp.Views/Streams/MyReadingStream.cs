using System.Collections.Generic;
using System.Linq;
using Chirp.Concepts;

namespace Chirp.Views.Streams
{
    public class MyReadingStream
    {
        HashSet<ChirpId> _chirps;

        public MyReadingStream()
        {
            _chirps = new HashSet<ChirpId>();
        }

        public ReaderId Reader { get; set; }
      
        public IEnumerable<ChirpId> Chirps
        {
            get { return _chirps.ToArray(); }
            set { _chirps = new HashSet<ChirpId>(value); }
        }

        public void AddChirp(ChirpId newChirp)
        {
            if(!_chirps.Contains(newChirp))
                _chirps.Add(newChirp);
        }

        public void RemoveChirp(ChirpId chirpToRemove)
        {
            if(_chirps.Contains(chirpToRemove))
                _chirps.Remove(chirpToRemove);
        }
    }
}