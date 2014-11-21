using Msg.Core.Transport.Frames;

namespace Msg.Core.Transport.Frames
{
	public class FrameSendResult
	{
		public bool SendWasSuccessful { get; private set; }

		public static FrameSendResult SendSucceeded()
		{
			return new FrameSendResult { SendWasSuccessful = true };
		}

		public static FrameSendResult SendFailed() 
		{
			return new FrameSendResult { SendWasSuccessful = false };
		}
	}
}

