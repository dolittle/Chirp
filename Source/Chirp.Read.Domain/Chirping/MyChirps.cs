using System.Collections.Generic;
using System.Linq;
using Chirp.Concepts;

namespace Chirp.Read.Domain.Chirping
{
    public class MyChirps
    {
        HashSet<ChirpId> _chirps;

        public MyChirps(Concepts.ChirperId chirper)
        {
            _chirps = new HashSet<ChirpId>();
            Chirper = chirper;
        }

        public MyChirps()
        {
            _chirps = new HashSet<ChirpId>();
        }

        public int TotalNumberOfChirps { get; set; }

        public Concepts.ChirperId Chirper { get; set; }
      
        public IEnumerable<ChirpId> Chirps
        {
            get { return _chirps.ToArray(); }
            set { _chirps = new HashSet<ChirpId>(value); }
        }

        public void AddChirp(ChirpId newChirp)
        {
            if (Exists(newChirp)) 
                return;
            _chirps.Add(newChirp);
            TotalNumberOfChirps++;
        }

        public void RemoveChirp(ChirpId chirpToRemove)
        {
            if (!Exists(chirpToRemove)) 
                return;
            _chirps.Remove(chirpToRemove);
            TotalNumberOfChirps--;
        }

       public bool Exists(ChirpId chirp)
       {
           return _chirps.Contains(chirp);
       }
    }
}