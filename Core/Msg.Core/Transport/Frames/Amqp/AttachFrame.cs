using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    [InterceptedAtSessionLevel]
    [HandledAtLinkLevel]
    public class AttachFrame : AmqpFrame
    {
        public AttachFrame(ushort channelId) : base(channelId, PerformativeType.Attach, new byte[0])
        {
        }
    }
}

