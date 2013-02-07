using System.Linq;
using Bifrost.Events;
using Bifrost.Read;
using Chirp.Concepts;
using Chirp.Events.Chirping;
using Chirp.Read.Domain.Follow;

namespace Chirp.Read.Streams
{
    public class ReadingStreamSubscriber : IEventSubscriber
    {
        readonly IReadModelRepositoryFor<Chirper> _chirperRepository;
        readonly IReadModelRepositoryFor<ChirpersFollowers> _followersRepository;
        readonly IReadModelRepositoryFor<ReadingStream> _readingStreamRepository;

        public ReadingStreamSubscriber(IReadModelRepositoryFor<ReadingStream> readingStreamRepository, IReadModelRepositoryFor<Chirper> chirperRepository, IReadModelRepositoryFor<ChirpersFollowers> followersRepository)
        {
            _readingStreamRepository = readingStreamRepository;
            _chirperRepository = chirperRepository;
            _followersRepository = followersRepository;
        }

        public void Process(MessageChirped messageChirped)
        {
            ChirperId chirpedBy = messageChirped.ChirpedBy;
            var myFollowers = _followersRepository.GetById(chirpedBy);

            if (myFollowers == null || !myFollowers.MyFollowers.Any())
                return;

            var readers = myFollowers.MyFollowers.Select(f => f.Value).ToArray();
            var chirper = _chirperRepository.GetById(chirpedBy);
            var chirpToAppend = new Chirp()
                               {
                                   Id = messageChirped.ChirpId,
                                   ChirpedBy = chirper,
                                   Content = messageChirped.Content,
                                   ChirpedAt = messageChirped.ChirpedAt
                               };

            //ReadingStreams are created on sign-up so we can assume that they are there...
            foreach (var readingStream in readers.Select(readerId => _readingStreamRepository.GetById((ReaderId) readerId)).Where(readingStream => readingStream != null))
            {
                readingStream.AppendToStream(chirpToAppend);
                _readingStreamRepository.Update(readingStream);
            }
        }
    }
}