using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    [InterceptedAtSessionLevel]
    [HandledAtLinkLevel]
    public class FlowFrame : AmqpFrame
    {
        public FlowFrame(ushort channelId) : base(channelId, PerformativeType.Flow, new byte[0])
        {
        }
    }
}

