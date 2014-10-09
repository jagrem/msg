using System;

namespace Msg.Acceptance.Tests
{
	public class AmqpConnectionAttemptFailedException : Exception
	{
		public AmqpConnectionAttemptFailedException(Exception innerException)
			:base ("Connection attempt failed", innerException)
		{}
	}

}
