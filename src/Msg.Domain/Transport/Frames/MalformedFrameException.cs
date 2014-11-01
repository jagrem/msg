using System;

namespace Msg.Domain.Transport.Frames
{

	public class MalformedFrameException : Exception 
	{
		public MalformedFrameException(string message)
			:base(message)
		{
		}
	}
}
