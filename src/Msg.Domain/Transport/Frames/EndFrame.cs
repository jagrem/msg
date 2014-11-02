using Msg.Domain.Transport.Frames.Behaviour;

namespace Msg.Domain.Transport.Frames
{
	public class EndFrame : Frame, IAmInterceptedAtConnectionLevel, IAmHandledAtSessionLevel
	{
		public EndFrame (Frame baseFrame) : base (baseFrame.Header, baseFrame.ExtendedHeader, baseFrame.Body)
		{
		}
	}
}

