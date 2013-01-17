
using System;
using Bifrost.Concepts;
using Chirp.Concepts;

namespace Chirp.Views.Streams
{
    public class Chirp
    {
        public ChirpId Id { get; set; }
        public Chirper ChirpedBy { get; set; }
        public Content Content { get; set; }
        public DateTime ChirpedAt { get; set; } 
    }

    public class Chirper : ConceptAs<string>
    { }

    public class Content : ConceptAs<string>
    { }
}
