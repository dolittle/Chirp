using System.Collections.Generic;
using System.Linq;
using Bifrost.Read;

namespace Chirp.Read.Streams
{
    public class OrderedStream : IChirpStream, IReadModel
    {
        readonly List<Chirp> _chirps;

        public OrderedStream()
        {
            _chirps = new List<Chirp>();
        }

        public OrderedStream(IEnumerable<Chirp> chirps)
        {
            _chirps = chirps != null ?  chirps.OrderByDescending(c => c.ChirpedAt).ToList() : new List<Chirp>();
        }

        public IQueryable<Chirp> Chirps()
        {
             return _chirps.AsQueryable(); 
        }
    }
}