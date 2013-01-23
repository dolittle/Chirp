using System.Collections.Generic;
using System.Linq;

namespace Chirp.Read.Streams
{
    public class MutableStream : IChirpStream
    {
        public List<Chirp> Content { get;  set; }

        public MutableStream()
        {
            Content = new List<Chirp>();
        }

        public MutableStream(IEnumerable<Chirp> chirps)
        {
            Content = chirps == null ? new List<Chirp>() : chirps.ToList(); 
        }

        public void AppendToStream(Chirp chirp)
        {
            if(chirp != null)
                Content.Add(chirp);
        }

        public void DetachFromStream(Chirp chirp)
        {
            if (chirp != null && Content.Contains(chirp))
                Content.Remove(chirp);
        }

       public  IQueryable<Chirp> Chirps()
       {
           return Content.AsQueryable();
       }
    }
}