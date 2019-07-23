using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    [InterceptedAtSessionLevel]
    [HandledAtLinkLevel]
    public class DetachFrame : AmqpFrame
    {
        public DetachFrame(ushort channelId) : base(channelId, PerformativeType.Detach, new byte[0])
        {
        }
    }
}

