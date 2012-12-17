using Chirp.Domain.Messages;

namespace Chirp.Domain.Specs
{
    public class messages
    {
        public readonly static  Message valid_chirp = new Message { Content = "This is a chirp with no tags." };
        public static readonly Message empty =  new Message { Content = string.Empty };
        public static readonly Message max_length =  new Message { Content = new string('A',Message.MaxLength) };
        public static readonly Message too_long =  new Message { Content = new string('B',Message.MaxLength + 1) };
    }
}