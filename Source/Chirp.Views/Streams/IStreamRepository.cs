using System.Collections.Generic;

namespace Chirp.Views.Streams
{
    public interface IStreamRepository
    {
        void AddPublic(string message);
        IEnumerable<Chirp> GetPublic();
    }
}
