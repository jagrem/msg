using System;
using System.Runtime.Serialization;

namespace Msg.Domain.Transport.Connections
{
	public class ConnectionFailedException : Exception
	{
		public ConnectionFailedException ()
		{
		}

		public ConnectionFailedException (string message) : base (message)
		{
		}

		public ConnectionFailedException (string message, Exception innerException) : base (message, innerException)
		{
		}

		protected ConnectionFailedException (SerializationInfo info, StreamingContext context) : base (info, context)
		{
		}
	}
}

