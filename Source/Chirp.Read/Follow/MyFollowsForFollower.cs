using System.Collections.Generic;
using System.Linq;
using Bifrost.Read;
using Chirp.Concepts;

namespace Chirp.Read.Follow
{
    public class MyFollowsForFollower : IQueryFor<MyFollows>
    {
        readonly IReadModelRepositoryFor<MyFollows> _myFollowsRepository;

        public FollowerId FollowerId { get; set; }

        public MyFollowsForFollower(IReadModelRepositoryFor<MyFollows> myFollowsRepository)
        {
            _myFollowsRepository = myFollowsRepository;
        }

        public IQueryable<MyFollows> Query
        {
            get
            {
                var myFollows = _myFollowsRepository.GetById(FollowerId) ?? new MyFollows(FollowerId);
                return new List<MyFollows> { myFollows }.AsQueryable();
            }
        }
    }
}