using System;
using Bifrost.Events;
using Bifrost.Read;
using Chirp.Concepts;
using Chirp.Events.Follow;

namespace Chirp.Read.Domain.Follow
{
    public class FollowSubscriber :   IEventSubscriber
    {
        readonly IReadModelRepositoryFor<ChirpersFollowers> _myFollowersRepository;
        readonly IReadModelRepositoryFor<FollowerFollows> _myFollowsRepository;

        public FollowSubscriber(IReadModelRepositoryFor<ChirpersFollowers> myFollowersRepository, IReadModelRepositoryFor<FollowerFollows> myFollowsRepository)
        {
            _myFollowersRepository = myFollowersRepository;
            _myFollowsRepository = myFollowsRepository;
        }

        public void Process(ChirperFollowed chirperFollowed)
        {
            UpdateMyFollowers(chirperFollowed.Chirper, chirperFollowed.EventSourceId);
            UpdateMyFollows(chirperFollowed.EventSourceId,chirperFollowed.Chirper);
        }

        void UpdateMyFollows(Guid eventSourceId, Guid chirper)
        {
            FollowerId follower = eventSourceId;
            var myFollows = _myFollowsRepository.GetById(follower);
            myFollows.AddFollow(chirper);
            _myFollowsRepository.Update(myFollows);
        }

        void UpdateMyFollowers(Guid chirper, Guid eventSourceId)
        {
            ChirperId chirperId = chirper;
            var myFollowers = _myFollowersRepository.GetById(chirperId);
            myFollowers.AddFollower(eventSourceId);
            _myFollowersRepository.Update(myFollowers);
        }
    }
}