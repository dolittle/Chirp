using Bifrost.Commands;
using Bifrost.Domain;

namespace Chirp.Domain.Subscriptions.Commands
{
    public class SubscriptionsCommandHandler : ICommandHandler
    {
        IAggregatedRootRepository<Subscriptions> _subscriptionsRepository;

        public SubscriptionsCommandHandler(IAggregatedRootRepository<Subscriptions> subscriptionsRepository)
        {
            _subscriptionsRepository = subscriptionsRepository;
        }


        public void Handle(SubscribeToPublisher command )
        {
        }
    }
} 