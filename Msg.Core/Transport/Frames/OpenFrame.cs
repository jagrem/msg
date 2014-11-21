using Msg.Core.Transport.Frames.Behaviour;

namespace Msg.Core.Transport.Frames
{
	[HandledAtConnectionlevel]
	public class OpenFrame : Frame
	{
		public OpenFrame (Frame baseFrame) : base (baseFrame.Header, baseFrame.ExtendedHeader, baseFrame.Body)
		{
		}
	}
}

