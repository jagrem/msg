using Msg.Domain.Transport.Frames.Behaviour;

namespace Msg.Domain.Transport.Frames
{
	public class EndFrame : Frame, IAmInterceptedAtConnectionLevel, IAmHandledAtSessionLevel
	{
	}
}

