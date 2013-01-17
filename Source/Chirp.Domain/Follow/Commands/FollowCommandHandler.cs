using Bifrost.Commands;
using Bifrost.Domain;

namespace Chirp.Domain.Follow.Commands
{
    public class FollowCommandHandler : ICommandHandler
    {
        IAggregatedRootRepository<Following> _subscriptionsRepository;

        public FollowCommandHandler(IAggregatedRootRepository<Following> subscriptionsRepository)
        {
            _subscriptionsRepository = subscriptionsRepository;
        }


        public void Handle(FollowChirper command )
        {
        }
    }
} 