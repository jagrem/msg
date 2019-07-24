using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    public abstract class AmqpFrame
    {
        public ChannelId ChannelId { get; }
        public PerformativeType Peformative { get; }

        protected AmqpFrame(ChannelId channelId, PerformativeType performative)
        {
            ChannelId = channelId;
            Peformative = performative;
        }
    }
}
