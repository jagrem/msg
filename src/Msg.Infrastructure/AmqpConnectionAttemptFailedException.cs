using System;

namespace Msg.Infrastructure
{
	public class AmqpConnectionAttemptFailedException : Exception
	{
		public AmqpConnectionAttemptFailedException(Exception innerException)
			:base ("Connection attempt failed", innerException)
		{}
	}

}
