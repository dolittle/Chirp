using System;

namespace Chirp.Domain.Messages
{
    public class Message
    {
        public static int MaxLength = 140;

        public string Content { get; set; }
    }
}