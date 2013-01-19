using System;
using System.Collections.Generic;
using System.Linq;
using Chirp.Concepts;
using Chirp.Read.Streams;

namespace Chirp.Read.Specs.Streams
{
    public class Chirpers
    {
        public static readonly Chirper Hannah = new Chirper() { Id = Guid.NewGuid(), DisplayName = "Hannah" };
        public static readonly Chirper Scott = new Chirper() { Id = Guid.NewGuid(), DisplayName = "Scott"};

        public static IQueryable<Chirper> GetAll()
        {
            return new List<Chirper>
                       {
                           Hannah,
                           Scott
                       }.AsQueryable();
        }

        public static Chirper Get(ChirperId id)
        {
            return GetAll().SingleOrDefault(c => c.Id == id);
        }
    }
}