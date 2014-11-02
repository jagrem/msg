namespace Msg.Domain.Transport.Frames
{

	public class FrameBody 
	{
		public FrameBody(string performative, byte[] payloadBytes)
		{
			if(string.IsNullOrEmpty(performative)){
				throw new MalformedFrameException ("Cannot determine the type of frame.");
			}

			Performative = performative;
			Payload = payloadBytes;
		}

		public string Performative { get; private set; }

		public byte[] Payload { get; private set; }
	}
}
