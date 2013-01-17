using Bifrost.Commands;
using Chirp.Concepts;

namespace Chirp.Domain.Chirping.Commands
{
    public class ChirpMessage : Command
    {
        public ChirperId Chirper { get; set; }
        public Chirp Chirp { get; set; }
    }
}