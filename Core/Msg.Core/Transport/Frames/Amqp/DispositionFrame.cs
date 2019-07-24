using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    [InterceptedAtSessionLevel]
    [HandledAtLinkLevel]
    public class DispositionFrame : AmqpFrame
    {
        public DispositionFrame(ChannelId channelId) : base(channelId, PerformativeType.Disposition)
        {
        }
    }
}

