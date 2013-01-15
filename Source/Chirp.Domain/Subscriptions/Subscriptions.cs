using System;
using Bifrost.Domain;
using Chirp.Concepts;
using Chirp.Events.Subscriptions;

namespace Chirp.Domain.Subscriptions
{
    public class Subscriptions : AggregatedRoot
    {
        public Subscriptions(Guid id) : base(id)
        {
        }

        public void SubscriberTo(PublisherId publisher)
        {
            Apply(new PublisherSubscribedTo(Id)
                      {
                          Publisher = publisher
                      });
        }
    }
}