using System.Linq;
using Bifrost.Entities;
using Bifrost.Events;
using Bifrost.Views;
using Chirp.Events.Chirping;

namespace Chirp.Read.Streams
{
    public class MyChirpsSubscriber : IProcessEvents
    {
        readonly IEntityContext<Chirper> _chirperEntityContext;
        readonly IEntityContext<Chirp> _chirpsEntityContext;

        public MyChirpsSubscriber(IEntityContext<Chirp> chirpsEntityContext, IEntityContext<Chirper> chirperEntityContext)
        {
            _chirpsEntityContext = chirpsEntityContext;
            _chirperEntityContext = chirperEntityContext;
        }

        public void Process(MessageChirped messageChirped)
        {
            var chirper = _chirperEntityContext.GetById(messageChirped.ChirpedBy);
            var newChirp = new Chirp()
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