using System;
using System.Runtime.Serialization;

namespace Msg.Core.Transport.Common.Protocol
{
    public class UnexpectedProtocolException : Exception
    {
        public UnexpectedProtocolException ()
            : base ("Specified protocol is not supported.")
        {
        }

        public UnexpectedProtocolException (ProtocolId expectedProtocolId, ProtocolId actualProtocolId)
            : base ($"Expected protocol {expectedProtocolId} but received {actualProtocolId}")
        {
        }

        protected UnexpectedProtocolException (SerializationInfo info, StreamingContext context)
            : base (info, context)
        {
        }
    }
}
