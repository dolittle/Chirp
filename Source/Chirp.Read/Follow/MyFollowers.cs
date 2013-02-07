using System.Collections.Generic;
using System.Linq;
using Bifrost.Read;
using Chirp.Concepts;

namespace Chirp.Read.Follow
{
    public class MyFollowers : IReadModel
    {
        HashSet<Follower> _followers;

        public MyFollowers()
        {
            _followers = new HashSet<Follower>();
        }

        public MyFollowers(ChirperId chirper) : this()
        {
            ChirperId = chirper;
        }

        public ChirperId ChirperId { get; set; }
        public Chirper Chirper { get; set; }

        public IEnumerable<Follower> Followers
        {
            get { return _followers.ToArray(); }
            set { _followers = new HashSet<Follower>(value); }
        }

        public void AddFollower(Follower follower)
        {
            if(!_followers.Contains(follower))
                _followers.Add(follower);
        }

        public void RemoveFollower(Follower follower)
        {
            if(_followers.Contains(follower))
                _followers.Remove(follower);
        }
    }
}