using System.Collections.Generic;
using System.Linq;
using Bifrost.Read;
using Chirp.Concepts;

namespace Chirp.Read.Follow
{
    public class MyFollows : IReadModel
    {
        HashSet<Chirper> _following;

        public MyFollows()
        {
            _following = new HashSet<Chirper>();
        }

        public MyFollows(FollowerId follower) : this()
        {
            FollowerId = follower;
        }

        public FollowerId FollowerId { get; set; }
        public Follower Follower { get; set; }
        
        public IEnumerable<Chirper> Following
        {
            get { return _following.ToArray(); }
            set { _following = new HashSet<Chirper>(value); }
        }

        public void AddFollow(Chirper follow)
        {
            if (!_following.Contains(follow))
                _following.Add(follow);
        }

        public void RemoveFollow(Chirper follow)
        {
            if (_following.Contains(follow))
                _following.Remove(follow);
        }
    }
}