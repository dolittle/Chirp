using System.Collections.Generic;
using Bifrost.Read;
using Chirp.Concepts;

namespace Chirp.Read.Streams
{
    public class ReadingStream : MutableStream, IReadModel
    {
        public ReaderId Reader { get; set; }

        public ReadingStream()
        {}

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