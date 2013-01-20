using System.Collections.Generic;
using Chirp.Concepts;

namespace Chirp.Read.Streams
{
    public class ReadingStream : MutableStream
    {
        public ReaderId Reader { get; set; }

        public ReadingStream(ReaderId reader)
        {
            Reader = reader;
        }

        public ReadingStream(ReaderId reader, IEnumerable<Chirp> chirps) : base(chirps)
        {
            Reader = reader;
        }
    }
}