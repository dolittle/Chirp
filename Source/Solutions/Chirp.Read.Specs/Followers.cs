using System.Collections.Generic;
using System.Linq;
using Chirp.Concepts;

namespace Chirp.Read.Specs
{
    public class followers
    {
        public static readonly Follower Hannah = new Follower() { FollowerId = Chirpers.Hannah.ChirperId.Value, DisplayName = Chirpers.Hannah.DisplayName };
        public static readonly Follower Scott = new Follower() { FollowerId = Chirpers.Scott.ChirperId.Value, DisplayName = Chirpers.Scott.DisplayName };

        public static IQueryable<Follower> GetAll()
        {
            return new List<Follower>
                       {
                           Hannah,
                           Scott
                       }.AsQueryable();
        }

        public static Follower Get(FollowerId id)
        {
            return GetAll().SingleOrDefault(c => c.FollowerId == id);
        }
    }
}