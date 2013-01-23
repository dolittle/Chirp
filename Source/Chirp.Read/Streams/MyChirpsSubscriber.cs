using System.Linq;
using Bifrost.Entities;
using Bifrost.Events;
using Bifrost.Views;
using Chirp.Events.Chirping;
using read = Chirp.Read.Streams;

namespace Chirp.Read.Streams
{
    public class MyChirpsSubscriber : IEventSubscriber
    {
        readonly IView<Chirper> _chirperView;
        readonly IEntityContext<Chirp> _chirpsEntityContext;

        public MyChirpsSubscriber(IEntityContext<Chirp> chirpsEntityContext, IView<Chirper> chirperView)
        {
            _chirpsEntityContext = chirpsEntityContext;
            _chirperView = chirperView;
        }

        public void Process(MessageChirped messageChirped)
        {
            var chirper = _chirperView.Query.Single(c => c.ChirperId.Value == messageChirped.ChirpedBy);
            var newChirp = new read.Chirp()
                            {
                                Id = messageChirped.ChirpId,
                                ChirpedBy = chirper,
                                Content = messageChirped.Content,
                                ChirpedAt = messageChirped.ChirpedAt
                            };
            _chirpsEntityContext.Insert(newChirp);
            _chirpsEntityContext.Commit();
        }
    }
}