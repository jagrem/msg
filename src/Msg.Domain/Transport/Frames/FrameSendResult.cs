using Msg.Domain.Transport.Frames;

namespace Msg.Domain.Transport.Frames
{
	public class FrameSendResult
	{
		public bool SendWasSuccessful { get; private set; }

		public static FrameSendResult SendSucceeded()
		{
			return new FrameSendResult () { SendWasSuccessful = true };
		}
	}
}

