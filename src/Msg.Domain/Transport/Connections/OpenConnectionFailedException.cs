using System;
using System.Runtime.Serialization;

namespace Msg.Domain.Transport.Connections
{

	public class OpenConnectionFailedException : ConnectionFailedException
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