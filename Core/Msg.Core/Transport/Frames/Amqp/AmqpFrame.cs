using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    public class AmqpFrame
    {
        public ChannelId ChannelId { get; }
        public PerformativeType Peformative { get; }
        public byte[] Payload { get; }

        public AmqpFrame(ChannelId channelId, PerformativeType performative)
        {
            ChannelId = channelId;
            Peformative = performative;
        }
    }
}
