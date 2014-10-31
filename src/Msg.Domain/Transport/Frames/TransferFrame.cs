using Msg.Domain.Transport.Frames.Behaviour;

namespace Msg.Domain.Transport.Frames
{
	public class TransferFrame : Frame, IAmInterceptedAtTheSessionLevel, IAmHandledAtTheLinkLevel
	{
	}
}

