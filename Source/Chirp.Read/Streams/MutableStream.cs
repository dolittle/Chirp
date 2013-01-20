using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Chirp.Read.Streams
{
    public class MutableStream : IChirpStream
    {
        public IList<Chirp> Chirps { get; set; }

        public MutableStream()
        {
            Chirps = new List<Chirp>();
        }

        public MutableStream(IEnumerable<Chirp> chirps)
        {
            Chirps = chirps == null ? new List<Chirp>() : chirps.ToList(); 
        }

        public void AppendToStream(Chirp chirp)
        {
            if(chirp != null)
                Chirps.Add(chirp);
        }

        public void DetachFromStream(Chirp chirp)
        {
            if (chirp != null && Chirps.Contains(chirp))
                Chirps.Remove(chirp);
        }

        public IEnumerator<Chirp> GetEnumerator()
        {
            return Chirps.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression
        {
            get { return Chirps.AsQueryable().Expression; }
        }

        public Type ElementType
        {
            get { return Chirps.AsQueryable().ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return Chirps.AsQueryable().Provider; }
        }
    }
}