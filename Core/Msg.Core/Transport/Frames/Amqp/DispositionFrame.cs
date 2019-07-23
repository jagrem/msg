using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    [InterceptedAtSessionLevel]
    [HandledAtLinkLevel]
    public class DispositionFrame : AmqpFrame
    {
        public DispositionFrame(ushort channelId) : base(channelId, PerformativeType.Disposition, new byte[0])
        {
        }
    }
}

