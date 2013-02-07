using Bifrost.Read;
using Chirp.Concepts;

namespace Chirp.Read
{
    public class Chirper : IReadModel
    {
        public ChirperId ChirperId { get; set; }
        public string DisplayName { get; set; }
    }
}