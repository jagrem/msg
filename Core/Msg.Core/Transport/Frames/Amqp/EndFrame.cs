using Msg.Core.Common;
using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;
using Msg.Core.Types;

namespace Msg.Core.Transport.Frames.Amqp
{
    [InterceptedAtConnectionLevel]
    [HandledAtSessionLevel]
    public class EndFrame : AmqpFrame
    {
        public Option<Error> Error { get; }

        public EndFrame(ChannelId channelId) : base(channelId, PerformativeType.End, new byte[0])
        {
        }
    }
}

