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
        readonly IEntityContext<Chirper> _chirperEntityContext;
        readonly IEntityContext<MyFollowers> _myFollowersEntityContext;
        readonly IEntityContext<ReadingStream> _readingStreamEntityContext;

        public ReadingStreamSubscriber(IEntityContext<ReadingStream> readingStreamEntityContext, IEntityContext<Chirper> chirperEntityContext, IEntityContext<MyFollowers> myFollowersEntityContext)
        {
            _readingStreamEntityContext = readingStreamEntityContext;
            _chirperEntityContext = chirperEntityContext;
            _myFollowersEntityContext = myFollowersEntityContext;
        }

        public void Process(MessageChirped messageChirped)
        {
            var myFollowers = _myFollowersEntityContext.GetById(messageChirped.ChirpedBy);

            if (myFollowers == null || !myFollowers.Followers.Any())
                return;


            var readers = myFollowers.Followers.Select(f => f.Value).ToArray();
            var chirper = _chirperEntityContext.GetById(messageChirped.ChirpedBy);
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
                var readingStream = _readingStreamEntityContext.GetById(reader);
                if (readingStream == null) 
                    continue;
                readingStream.AppendToStream(chirpToAppend);
                _readingStreamEntityContext.Update(readingStream);
            }
            _readingStreamEntityContext.Commit();
        }
    }
}