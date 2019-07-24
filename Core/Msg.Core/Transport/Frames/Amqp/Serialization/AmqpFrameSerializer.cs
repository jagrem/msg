using System;

namespace Msg.Core.Transport.Frames.Amqp.Serialization
{
    public class AmqpFrameSerializer
    {
        public static AmqpFrame Deserialize(Frame frame)
        {
            if (frame.Header.Type != FrameHeaderType.AMQP)
            {
                throw new ArgumentException("The frame must be of type AMQP.", nameof(frame));
            }



            throw new NotImplementedException();
        }

        public static Frame Serialize(AmqpFrame frame)
        {
            throw new NotImplementedException();
        }
    }
}
