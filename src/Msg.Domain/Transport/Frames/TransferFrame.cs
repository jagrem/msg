using Msg.Domain.Transport.Frames.Behaviour;

namespace Msg.Domain.Transport.Frames
{
	public class TransferFrame : Frame, IAmInterceptedAtTheSessionLevel, IAmHandledAtTheLinkLevel
	{
		public TransferFrame (Frame baseFrame) : base (baseFrame.Header, baseFrame.ExtendedHeader, baseFrame.Body)
		{
		}
	}
}

