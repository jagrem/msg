using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    [InterceptedAtSessionLevel]
    [HandledAtLinkLevel]
    public class TransferFrame : AmqpFrame
    {
        public TransferFrame(ChannelId channelId) : base(channelId, PerformativeType.Transfer, new byte[0])
        {
        }
    }
}

