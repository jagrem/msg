using Msg.Core.Transport.Frames.Constants;
using System.Text;

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

		public override string ToString ()
		{
			return string.Format ("[FrameBody: Performative={0}, Payload={1}]", Performative, Encoding.UTF8.GetString (Payload));
		}
	}
}
