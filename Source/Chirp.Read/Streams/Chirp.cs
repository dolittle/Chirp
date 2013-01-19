using System;
using Chirp.Concepts;

namespace Chirp.Read.Streams
{
    public class Chirp
    {
        public ChirpId Id { get; set; }
        public Chirper ChirpedBy { get; set; }
        public Content Content { get; set; }
        public DateTime ChirpedAt { get; set; } 
    }
}
