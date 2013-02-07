using Bifrost.Read;
using Chirp.Concepts;

namespace Chirp.Read
{
    public class Follower : IReadModel
    {
        public FollowerId FollowerId { get; set; }
        public string DisplayName { get; set; }
    }
}