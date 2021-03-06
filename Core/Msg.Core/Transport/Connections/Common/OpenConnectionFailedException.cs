using System;
using System.Runtime.Serialization;

namespace Msg.Core.Transport.Connections
{

    public class OpenConnectionFailedException : Exception
    {
        public OpenConnectionFailedException ()
        {
        }

        public OpenConnectionFailedException (string message) : base (message)
        {
        }

        public OpenConnectionFailedException (string message, Exception innerException) : base (message, innerException)
        {
        }

        protected OpenConnectionFailedException (SerializationInfo info, StreamingContext context) : base (info, context)
        {
        }
    }
}