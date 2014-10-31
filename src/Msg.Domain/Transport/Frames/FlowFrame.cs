using Msg.Domain.Transport.Frames.Behaviour;

namespace Msg.Domain.Transport.Frames
{
	public class FlowFrame : Frame, IAmInterceptedAtTheSessionLevel, IAmHandledAtTheLinkLevel
	{
	}
}

