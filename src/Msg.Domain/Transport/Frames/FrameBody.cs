using Msg.Domain.Transport.Frames.Constants;

namespace Msg.Domain.Transport.Frames
{

	public class FrameBody 
	{
		public FrameBody(PerformativeType performative, byte[] payloadBytes)
		{
			Performative = performative;
			Payload = payloadBytes;
		}

		public PerformativeType Performative { get; private set; }

		public byte[] Payload { get; private set; }
	}
}
