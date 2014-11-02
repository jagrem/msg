using Msg.Domain.Transport.Frames.Behaviour;

namespace Msg.Domain.Transport.Frames
{
	public class BeginFrame : Frame, IAmInterceptedAtConnectionLevel, IAmHandledAtSessionLevel
	{
		public BeginFrame(Frame baseFrame)
			:base(baseFrame)
		{
		}
	}
}

