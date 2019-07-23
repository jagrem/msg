using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    [HandledAtConnectionlevel]
    public class CloseFrame : AmqpFrame
    {
        public CloseFrame(ushort channelId)
            : base(channelId, PerformativeType.Close, new byte[0])
        {
        }
    }
}

