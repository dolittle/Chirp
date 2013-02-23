using Bifrost.Commands;
using Bifrost.Domain;

namespace Chirp.Domain.Follow.Commands
{
    public class FollowCommandHandler : IHandleCommands
    {
        IAggregateRootRepository<Following> _subscriptionsRepository;

        public FollowCommandHandler(IAggregateRootRepository<Following> subscriptionsRepository)
        {
            _subscriptionsRepository = subscriptionsRepository;
        }

        public void Handle(FollowChirper command )
        {
            var following = _subscriptionsRepository.Get(command.Follower);
            following.Follow(command.Chirper);
        }

        public void Handle(UnfollowChirper command)
        {
            var following = _subscriptionsRepository.Get(command.Follower);
            following.Unfollow(command.Chirper);
        }
    }
} 