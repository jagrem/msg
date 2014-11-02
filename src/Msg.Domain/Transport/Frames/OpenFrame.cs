using Msg.Domain.Transport.Frames.Behaviour;

namespace Msg.Domain.Transport.Frames
{
	public class OpenFrame : Frame, IAmHandledAtConnectionLevel
	{
		public OpenFrame (Frame baseFrame) : base (baseFrame.Header, baseFrame.ExtendedHeader, baseFrame.Body)
		{
		}
	}
}

