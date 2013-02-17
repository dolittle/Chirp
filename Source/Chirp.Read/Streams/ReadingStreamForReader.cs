using System;
using System.Collections.Generic;
using System.Linq;
using Bifrost.Read;
using Chirp.Concepts;

namespace Chirp.Read.Streams
{
    public class ReadingStreamForReader : IQueryFor<ReadingStream>
    {
        readonly IReadModelRepositoryFor<ReadingStream> _readingStreamRespository;

        public Guid ReaderId { get; set; }

        public ReadingStreamForReader(IReadModelRepositoryFor<ReadingStream> readingStreamRespository)
        {
            _readingStreamRespository = readingStreamRespository;
        }

        public IQueryable<ReadingStream> Query
        {
            get
            {
                var readingStream = _readingStreamRespository.GetById(ReaderId) ?? new ReadingStream(ReaderId);
                return new List<ReadingStream> {readingStream}.AsQueryable();
            }
        }
    }
}