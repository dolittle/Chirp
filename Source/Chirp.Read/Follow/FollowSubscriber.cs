using Bifrost.Events;
using Bifrost.Read;
using Chirp.Concepts;
using Chirp.Events.Follow;

namespace Chirp.Read.Follow
{
    public class FollowSubscriber :   IEventSubscriber
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
            ChirperId chirperId = chirperFollowed.Chirper;
            FollowerId followerId = chirperFollowed.EventSourceId;
            var chirper = _chirperRepository.GetById(chirperId);
            var follower = _followerRepository.GetById(followerId);
            UpdateMyFollowers(chirper, follower);
            UpdateMyFollows(follower,chirper);
        }

        void UpdateMyFollows(Follower follower, Chirper chirper)
        {
            var myFollows = _myFollowsRepository.GetById(follower.FollowerId);
            myFollows.AddFollow(chirper);
            _myFollowsRepository.Update(myFollows);
        }

        void UpdateMyFollowers(Chirper chirper, Follower follower)
        {
            var myFollowers = _myFollowersRepository.GetById(chirper.ChirperId);
            myFollowers.AddFollower(follower);
            _myFollowersRepository.Update(myFollowers);
        }
    }
}