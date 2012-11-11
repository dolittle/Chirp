using System.Collections.Generic;
using System.IO;
using Bifrost.Entities;
using Bifrost.Serialization;

namespace Chirp.Views.Streams
{
    public class StreamRepository : IStreamRepository
    {
        IEntityContext<Chirp>   _entityContext;
            

        public StreamRepository(IEntityContext<Chirp> entityContext)
        {
            _entityContext = entityContext;
        }

        public void AddPublic(string message)
        {
            _entityContext.Insert(new Chirp { Message = message });
            _entityContext.Commit();
        }

        public IEnumerable<Chirp> GetPublic()
        {
            return _entityContext.Entities;
        }

    }
}
