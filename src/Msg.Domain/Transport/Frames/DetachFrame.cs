using Msg.Domain.Transport.Frames.Behaviour;

namespace Msg.Domain.Transport.Frames
{
	public class DetachFrame : Frame, IAmInterceptedAtTheSessionLevel, IAmHandledAtTheLinkLevel
	{
		public DetachFrame (Frame baseFrame)
			: base (baseFrame)
		{
		}
	}
}

