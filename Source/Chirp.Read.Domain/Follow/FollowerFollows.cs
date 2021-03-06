﻿using System.Collections.Generic;
using System.Linq;
using Bifrost.Read;
using Chirp.Concepts;

namespace Chirp.Read.Domain.Follow
{
    public class FollowerFollows : IReadModel
    {
        HashSet<ChirperId> _following;

        public FollowerFollows()
        {
            _following = new HashSet<ChirperId>();
        }

        public FollowerFollows(FollowerId follower) : this()
        {
            Follower = follower;
        }

        public FollowerId Follower { get; set; }
        
        public IEnumerable<ChirperId> Following
        {
            get { return _following.ToArray(); }
            set { _following = new HashSet<ChirperId>(value); }
        }

        public void AddFollow(ChirperId follow)
        {
            if (!_following.Contains(follow))
                _following.Add(follow);
        }

        public void RemoveFollow(ChirperId follow)
        {
            if (_following.Contains(follow))
                _following.Remove(follow);
        }
    }
}