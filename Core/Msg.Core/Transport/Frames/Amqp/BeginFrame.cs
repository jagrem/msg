using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    [InterceptedAtConnectionLevel]
    [HandledAtSessionLevel]
    public class BeginFrame : AmqpFrame
    {
        public BeginFrame(ChannelId channelId) : base(channelId, PerformativeType.Begin, new byte[0])
        {
        }
    }
}

