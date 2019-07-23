using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    public class AmqpFrame
    {
        public ushort ChannelId { get; }
        public PerformativeType Peformative { get; }
        public byte[] Payload { get; }

        public AmqpFrame(ushort channelId, PerformativeType performative, byte[] payload)
        {
            ChannelId = channelId;
            Peformative = performative;
            Payload = payload;
        }
    }
}
