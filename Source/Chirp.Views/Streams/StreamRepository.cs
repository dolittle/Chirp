using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bifrost.Serialization;
using System.IO;

namespace Chirp.Views.Streams
{
    public class StreamRepository : IStreamRepository
    {
        string _publicPath;
        string _publicFile;

        ISerializer _serializer;

        public StreamRepository(ISerializer serializer, Func<string> dataPath)
        {
            _publicPath = dataPath();
            _publicFile = _publicPath + "\\public.json";

            Directory.CreateDirectory(_publicPath);
            _serializer = serializer;
        }

        public void AddPublic(string message)
        {
            var stream = new List<Chirp>(GetPublic());
            stream.Insert(0, new Chirp { Message = message });

            var json = _serializer.ToJson(stream);
            File.WriteAllText(_publicFile, json);
        }


        public IEnumerable<Chirp> GetPublic()
        {
            if (!File.Exists(_publicFile))
                return new Chirp[0];

            var json = File.ReadAllText(_publicFile);
            var chirps = _serializer.FromJson<IEnumerable<Chirp>>(json);
            return chirps;
        }

    }
}
