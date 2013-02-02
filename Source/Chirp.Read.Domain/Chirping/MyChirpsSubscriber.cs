using System.Linq;
using Bifrost.Entities;
using Bifrost.Events;
using Chirp.Concepts;
using Chirp.Events.Chirping;

namespace Chirp.Read.Domain.Chirping
{
    public class MyChirpsSubscriber : IEventSubscriber
    {
        readonly IEntityContext<MyChirps> _myChirpsEntityContext;

        public MyChirpsSubscriber(IEntityContext<MyChirps> myChirpsEntityContext)
        {
            _myChirpsEntityContext = myChirpsEntityContext;
        }

        public void Process(MessageChirped messageChirped)
        {
            ChirpId chirp = messageChirped.ChirpId;
            Concepts.ChirperId chirper = messageChirped.ChirpedBy;
            var myChirps = _myChirpsEntityContext.GetById(chirper);
            if(myChirps == null)
            {
                myChirps = new MyChirps(chirper);
                myChirps.AddChirp(chirp);
                _myChirpsEntityContext.Insert(myChirps);
                _myChirpsEntityContext.Commit();
            }
            else
            {
                myChirps.AddChirp(chirp);
                _myChirpsEntityContext.Update(myChirps);
                _myChirpsEntityContext.Commit();
            }
        }
    }
}