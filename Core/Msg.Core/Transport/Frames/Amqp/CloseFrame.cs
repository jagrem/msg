using Msg.Core.Common;
using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;
using Msg.Core.Types;

namespace Msg.Core.Transport.Frames.Amqp
{
    [HandledAtConnectionlevel]
    public class CloseFrame : AmqpFrame
    {
        public Option<Error> Error { get; }
        public CloseFrame(ChannelId channelId)
            : base(channelId, PerformativeType.Close, new byte[0])
        {
        }
    }
}

