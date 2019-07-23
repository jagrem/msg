using Msg.Core.Transport.Frames.Behaviour;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames.Amqp
{
    [HandledAtConnectionlevel]
    public class OpenFrame : AmqpFrame
    {
        public OpenFrame(ushort channelId)
            : base(channelId, PerformativeType.Open, new byte[0])
        {
        }
    }
}

