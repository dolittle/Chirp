using System.Collections.Generic;
using System.Linq;
using Bifrost.Read;
using Chirp.Concepts;

namespace Chirp.Read.Follow
{
    public class MyFollowersForChirper : IQueryFor<MyFollowers>
    {
        readonly IReadModelRepositoryFor<MyFollowers> _myFollowersRepository;

        public ChirperId ChirperId { get; set; }

        public MyFollowersForChirper(IReadModelRepositoryFor<MyFollowers> myFollowersRepository)
        {
            _myFollowersRepository = myFollowersRepository;
        }

        public IQueryable<MyFollowers> Query
        {
            get
            {
                var myFollowers = _myFollowersRepository.GetById(ChirperId) ?? new MyFollowers(ChirperId);
                return new List<MyFollowers> {myFollowers}.AsQueryable();
            }
        }
    }
}