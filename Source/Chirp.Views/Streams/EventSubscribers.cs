using Bifrost.Events;
using Chirp.Events.Streams;

namespace Chirp.Views.Streams
{
    public class EventSubscribers : IEventSubscriber
    {
        IStreamRepository _streamRepository;

        public EventSubscribers(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }

        public void Process(MessagePublished @event)
        {
            _streamRepository.AddPublic(@event.Message);
        }
    }
}
