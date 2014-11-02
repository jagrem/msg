using Msg.Domain.Transport.Frames.Behaviour;

namespace Msg.Domain.Transport.Frames
{
	public class DispositionFrame : Frame, IAmInterceptedAtTheSessionLevel, IAmHandledAtTheLinkLevel
	{
		public DispositionFrame (Frame baseFrame)
			: base (baseFrame)
		{
		}
	}
}

