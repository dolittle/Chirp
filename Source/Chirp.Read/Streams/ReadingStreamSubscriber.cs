using System.Collections.Generic;
using System.Linq;
using Bifrost.Entities;
using Bifrost.Events;
using Bifrost.Views;
using Chirp.Concepts;
using Chirp.Events.Chirping;
using Chirp.Read.Domain.Follow;

namespace Chirp.Read.Streams
{
    public class ReadingStreamSubscriber : IEventSubscriber
    {
        readonly IView<Chirper> _chirperView;
        readonly IView<MyFollowers> _myFollowersView;
        readonly IEntityContext<ReadingStream> _readingStreamEntityContext;

        public ReadingStreamSubscriber(IEntityContext<ReadingStream> readingStreamEntityContext, IView<Chirper> chirperView, IView<MyFollowers> myFollowersView)
        {
            _readingStreamEntityContext = readingStreamEntityContext;
            _chirperView = chirperView;
            _myFollowersView = myFollowersView;
        }

        public void Process(MessageChirped messageChirped)
        {
            var myFollowers = _myFollowersView.Query.SingleOrDefault(f => f.Chirper.Value == messageChirped.ChirpedBy);

            if (myFollowers == null || !myFollowers.Followers.Any())
                return;


            var readers = myFollowers.Followers.Select(f => f.Value).ToArray();
            var chirper = _chirperView.Query.Single(c => c.ChirperId.Value == messageChirped.ChirpedBy);
            var chirpToAppend = new Chirp()
                               {
                                   Id = messageChirped.ChirpId,
                                   ChirpedBy = chirper,
                                   Content = messageChirped.Content,
                                   ChirpedAt = messageChirped.ChirpedAt
                               };

            //ReadingStreams are created on sign-up so we can assume that they are there...
            //var followersReadingStreams = _readingStreamEntityContext.Entities.Where(rs => readers.Contains(rs.Reader.Value)).ToDictionary(r => r.Reader.Value);.Where(r => r.EmployeeId.In<string>(employeeIds)))

            foreach(var reader in readers)
            {
                var readingStream = _readingStreamEntityContext.Entities.FirstOrDefault(rs => rs.Reader.Value == reader);
                if (readingStream == null) 
                    continue;
                readingStream.AppendToStream(chirpToAppend);
                _readingStreamEntityContext.Update(readingStream);
            }
            _readingStreamEntityContext.Commit();
        }
    }
}