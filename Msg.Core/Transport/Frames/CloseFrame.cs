using Msg.Core.Transport.Frames.Behaviour;

namespace Msg.Core.Transport.Frames
{
	[HandledAtConnectionlevel]
	public class CloseFrame : Frame
	{
		public CloseFrame(Frame baseFrame) : base (baseFrame.Header, baseFrame.ExtendedHeader, baseFrame.Body)
		{
		}
	}
}

