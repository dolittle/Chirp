using Chirp.Concepts;

namespace Chirp.Domain.Chirping
{
    public class Chirp
    {
        public static int MaxLength = 140;

        public ChirpId Id { get; set; }
        public string Content { get; set; }
    }
}