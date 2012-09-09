using System;
using Bifrost.MSpec.Events;
using Chirp.Events.Streams;
using Machine.Specifications;

namespace Chirp.Domain.Specs.Streams.for_Stream
{
    public class when_sending_a_direct_message : given.a_stream
    {
        const string message = "This is a direct message";
        static Guid receiver_id = Guid.NewGuid();

        Because of = () => stream.DirectMessage(receiver_id, message);

        It should_have_a_direct_message_sent_event_with_receiver_and_message = () => stream.ShouldHaveEvent<DirectMessageSent>().AtBeginning().WithValues(dm => dm.Receiver == receiver_id, dm => dm.Message == message);
    }
}
