using System.Collections.Generic;
using System.Linq;
using Chirp.Concepts;

namespace Chirp.Read.Domain.Follow
{
    public class MyFollowers
    {
        public HashSet<FollowerId> _followers;

        public MyFollowers()
        {
            _followers = new HashSet<FollowerId>();
        }

        public MyFollowers(ChirperId chirper) : this()
        {
            Chirper = chirper;
        }

        public ChirperId Chirper { get; set; }
        public IEnumerable<FollowerId> Followers
        {
            get { return _followers.ToArray(); }
            set { _followers = new HashSet<FollowerId>(value); }
        }

        public void AddFollower(FollowerId followerId)
        {
            if(!_followers.Contains(followerId))
                _followers.Add(followerId);
        }

        public void RemoveFollower(FollowerId followerId)
        {
            if(_followers.Contains(followerId))
                _followers.Remove(followerId);
        }
    }
}