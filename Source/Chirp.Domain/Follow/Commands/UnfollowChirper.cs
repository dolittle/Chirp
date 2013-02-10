using Bifrost.Commands;
using Chirp.Concepts;

namespace Chirp.Domain.Follow.Commands
{
    public class UnfollowChirper : Command
    {
        public FollowerId Follower { get; set; }
        public ChirperId Chirper { get; set; }
    }
}