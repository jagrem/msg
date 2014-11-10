using System;
using System.Runtime.Serialization;

namespace Msg.Domain.Transport.Connections
{
	
	public class CloseConnectionFailedException : ConnectionFailedException
	{
		public CloseConnectionFailedException ()
		{
		}

		public CloseConnectionFailedException (string message) : base (message)
		{

		}

		public CloseConnectionFailedException (string message, Exception innerException) : base (message, innerException)
		{
		}

		public CloseConnectionFailedException (SerializationInfo info, StreamingContext context) : base (info, context)
		{
		}
	}
}