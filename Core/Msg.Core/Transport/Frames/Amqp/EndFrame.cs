using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    [InterceptedAtConnectionLevel]
    [HandledAtSessionLevel]
    public class EndFrame : AmqpFrame
    {
        public EndFrame(ChannelId channelId) : base(channelId, PerformativeType.End, new byte[0])
        {
        }
    }
}

