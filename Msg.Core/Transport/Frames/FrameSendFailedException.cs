using System.Threading.Tasks;
using System;
using System.Runtime.Serialization;

namespace Msg.Core.Transport.Frames
{

    public class FrameSendFailedException : Exception
    {
        public FrameSendFailedException () : base ("Failed to send frame.")
        {
        }

        public FrameSendFailedException (string message) : base (message)
        {
        }

        public FrameSendFailedException (string message, Exception innerException) : base (message, innerException)
        {
        }

        public FrameSendFailedException (SerializationInfo info, StreamingContext context) : base (info, context)
        {
        }
    }
}
