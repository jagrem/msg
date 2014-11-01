namespace Msg.Domain.Transport.Frames
{

	public class FrameBody 
	{
		public string Performative { get; private set; }

		public byte[] Payload { get; private set; }
	}
}
