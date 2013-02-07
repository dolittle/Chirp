using Bifrost.Commands;
using Chirp.Concepts;

namespace Chirp.Domain.Chirping.Commands
{
    public class DeleteChirp : Command
    {
        public ChirperId ChirpedBy { get; set; }
        public ChirpId ChirpToDelete { get; set; }
    }
}