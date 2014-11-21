using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames
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
