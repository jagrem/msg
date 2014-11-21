using System;
using System.Runtime.Serialization;

namespace Msg.Core.Transport.Frames
{
	public class MalformedFrameException : Exception
	{
		public MalformedFrameException ()
		{
		}

		public MalformedFrameException (string message)
			: base (message)
		{
		}

		public MalformedFrameException (string message, Exception innerException)
			: base (message, innerException)
		{
		}

		protected MalformedFrameException (SerializationInfo info, StreamingContext context)
			: base (info, context)
		{
		}
	}
}
