using Msg.Domain.Transport.Frames.Behaviour;

namespace Msg.Domain.Transport.Frames
{
	public class CloseFrame : Frame, IAmHandledAtConnectionLevel
	{
		public CloseFrame(Frame baseFrame) : base (baseFrame.Header, baseFrame.ExtendedHeader, baseFrame.Body)
		{
		}
	}
}

