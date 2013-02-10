using System.Collections.Generic;
using System.Linq;
using Bifrost.Read;
using Chirp.Concepts;

namespace Chirp.Read.Streams
{
    public class MyChirpsForChirper : IQueryFor<OrderedStream>
    {
        readonly IReadModelRepositoryFor<Chirp> _chirpsRespository;

        public ChirperId ChirperId;

        public MyChirpsForChirper(IReadModelRepositoryFor<Chirp> chirpsRespository)
        {
            _chirpsRespository = chirpsRespository;
        }

        public IQueryable<OrderedStream> Query
        {
            get
            {
                var orderedStream = new OrderedStream(_chirpsRespository.Query.Where(c => c.ChirpedBy.ChirperId == ChirperId));
                return new List<OrderedStream> {orderedStream}.AsQueryable();
            }
        }
    }
}