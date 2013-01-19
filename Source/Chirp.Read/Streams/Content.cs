using Bifrost.Concepts;

namespace Chirp.Read.Streams
{
    public class Content : ConceptAs<string>
    {
        public static implicit operator Content(string content)
        {
            return new Content{ Value = content };
        }
    }
}