using System;
using Bifrost.Read;
using Chirp.Concepts;

namespace Chirp.Read.Streams
{
    public class Chirp : IEquatable<ChirpId>, IReadModel
    {
        public ChirpId Id { get; set; }
        public Chirper ChirpedBy { get; set; }
        public Content Content { get; set; }
        public DateTime ChirpedAt { get; set; }

        public bool Equals(ChirpId other)
        {
            if (other == null)
                return false;
            return Id.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) 
                return false;
            if (Object.ReferenceEquals(this, obj)) 
                return true;
            if (GetType() != obj.GetType()) 
                return false;

            return Equals(obj as Chirp);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
