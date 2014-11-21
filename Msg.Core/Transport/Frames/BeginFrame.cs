using Msg.Core.Transport.Frames.Behaviour;

namespace Msg.Core.Transport.Frames
{
	[InterceptedAtConnectionLevel]
	[HandledAtSessionLevel]
	public class BeginFrame : Frame
	{
		public BeginFrame(Frame baseFrame) : base (baseFrame.Header, baseFrame.ExtendedHeader, baseFrame.Body)
		{
		}
	}
}

