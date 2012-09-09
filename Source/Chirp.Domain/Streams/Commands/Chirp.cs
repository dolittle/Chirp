using Bifrost.Commands;

namespace Chirp.Domain.Streams.Commands
{
    public class Chirp : Command
    {
        public string Message { get; set; }
    }
}
