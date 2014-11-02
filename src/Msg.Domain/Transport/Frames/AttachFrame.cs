using Msg.Domain.Transport.Frames.Behaviour;

namespace Msg.Domain.Transport.Frames
{
	public class AttachFrame : Frame, IAmInterceptedAtTheSessionLevel, IAmHandledAtTheLinkLevel
	{
		public AttachFrame(Frame baseFrame)
			: base(baseFrame)
		{
		}
	}
}

