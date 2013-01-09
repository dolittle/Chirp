
using Chirp.Domain.Streams;

namespace Chirp.Domain.Specs
{
    public class messages
    {
        public static readonly Message valid_chirp_with_no_tags = new Message { Content = "This is a chirp with no tags." };
        public static readonly Message empty =  new Message { Content = string.Empty };
        public static readonly Message max_length =  new Message { Content = new string('A',Message.MaxLength) };
        public static readonly Message too_long =  new Message { Content = new string('B',Message.MaxLength + 1) };
    }
}