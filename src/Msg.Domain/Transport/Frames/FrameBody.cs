namespace Msg.Domain.Transport.Frames
{

	public class FrameBody 
	{
		public FrameBody(byte[] frameBodyBytes)
		{

			Payload = frameBodyBytes;
		}

		public string Performative { get; private set; }

		public byte[] Payload { get; private set; }
	}
}
