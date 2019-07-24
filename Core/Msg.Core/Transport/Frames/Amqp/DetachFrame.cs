using Msg.Core.Common;
using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;
using Msg.Core.Types;

namespace Msg.Core.Transport.Frames.Amqp
{
    [InterceptedAtSessionLevel]
    [HandledAtLinkLevel]
    public class DetachFrame : AmqpFrame
    {
        public Handle Handle { get; }
        public bool Closed { get; }
        public Option<Error> Error { get; }

        public DetachFrame(
            ChannelId channelId,
            bool closed,
            Option<Error> error)
            : base(channelId, PerformativeType.Detach)
        {
            Closed = closed;
            Error = error;
        }
    }
}

