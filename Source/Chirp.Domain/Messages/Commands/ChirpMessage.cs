using System;
using Bifrost.Commands;

namespace Chirp.Domain.Messages.Commands
{
    public class ChirpMessage : Command
    {
        public Publisher Publisher { get; set; }
        public Message Message { get; set; }

    }
}