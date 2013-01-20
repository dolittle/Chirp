using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Chirp.Read.Streams
{
    public class OrderedStream : IChirpStream
    {
        readonly List<Chirp> _chirps;
        readonly IQueryable<Chirp> _chirpsAsQueryable; 

        public OrderedStream()
        {
            _chirps = new List<Chirp>();
            _chirpsAsQueryable = _chirps.AsQueryable(); 
        }

        public OrderedStream(IEnumerable<Chirp> chirps)
        {
            _chirps = chirps != null ?  chirps.OrderByDescending(c => c.ChirpedAt).ToList() : new List<Chirp>();
            _chirpsAsQueryable = _chirps.AsQueryable(); 
        }

        public IEnumerator<Chirp> GetEnumerator()
        {
            return _chirps.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression
        {
            get { return _chirpsAsQueryable.Expression; }
        }

        public Type ElementType
        {
            get { return _chirpsAsQueryable.ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return _chirpsAsQueryable.Provider; }
        }
    }
}