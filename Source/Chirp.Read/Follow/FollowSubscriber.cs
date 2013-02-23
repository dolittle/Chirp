using System;
using Bifrost.Events;
using Bifrost.Read;
using Chirp.Concepts;
using Chirp.Events.Follow;

namespace Chirp.Read.Follow
{
    public class FollowSubscriber :   IProcessEvents
    {
        readonly IReadModelRepositoryFor<MyFollowers> _myFollowersRepository;
        readonly IReadModelRepositoryFor<MyFollows> _myFollowsRepository;
        readonly IReadModelRepositoryFor<Chirper> _chirperRepository;
        readonly IReadModelRepositoryFor<Follower> _followerRepository;

        public FollowSubscriber(IReadModelRepositoryFor<MyFollowers> myFollowersRepository, IReadModelRepositoryFor<MyFollows> myFollowsRepository, 
            IReadModelRepositoryFor<Chirper> chirperRepository,  IReadModelRepositoryFor<Follower> followerRepository)
        {
            _myFollowersRepository = myFollowersRepository;
            _myFollowsRepository = myFollowsRepository;
            _chirperRepository = chirperRepository;
            _followerRepository = followerRepository;
        }

        public void Process(ChirperFollowed chirperFollowed)
        {
            Process(chirperFollowed.Chirper,
                                chirperFollowed.EventSourceId,
                                (mf, c) => mf.AddFollow(c),
                                (mf, f) => mf.AddFollower(f));
        }

        public void Process(ChirperUnfollowed chirperUnfollowed)
        {
            Process(chirperUnfollowed.Chirper,
                                chirperUnfollowed.EventSourceId,
                                (mf,c) => mf.RemoveFollow(c),
                                (mf,f) => mf.RemoveFollower(f));
        }

        void Process(ChirperId chirperId, FollowerId followerId, Action<MyFollows, Chirper> updateMyFollows, Action<MyFollowers, Follower> updateMyFollowers)
        {
            var chirper = _chirperRepository.GetById(chirperId);
            var follower = _followerRepository.GetById(followerId);
            UpdateMyFollowers(chirper, follower, updateMyFollowers);
            UpdateMyFollows(follower, chirper, updateMyFollows);
        }

        void UpdateMyFollows(Follower follower, Chirper chirper, Action<MyFollows,Chirper> update)
        {
            var myFollows = _myFollowsRepository.GetById(follower.FollowerId);
            update.Invoke(myFollows,chirper);
            _myFollowsRepository.Update(myFollows);
        }

        void UpdateMyFollowers(Chirper chirper, Follower follower, Action<MyFollowers, Follower> update)
        {
            var myFollowers = _myFollowersRepository.GetById(chirper.ChirperId);
            update.Invoke(myFollowers,follower);
            _myFollowersRepository.Update(myFollowers);
        }


    }
}