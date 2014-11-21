using Msg.Core.Transport.Frames.Behaviour;

namespace Msg.Core.Transport.Frames
{
	[InterceptedAtSessionLevel]
	[HandledAtLinkLevel]
	public class DetachFrame : Frame
	{
		public DetachFrame (Frame baseFrame) : base (baseFrame.Header, baseFrame.ExtendedHeader, baseFrame.Body)
		{
		}
	}
}

