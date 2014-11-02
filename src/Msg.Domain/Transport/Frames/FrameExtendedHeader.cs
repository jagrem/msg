namespace Msg.Domain.Transport.Frames
{

	public class FrameExtendedHeader
	{
		public FrameExtendedHeader(byte[] data)
		{
			Data = data;
		}

		public byte[] Data { get; private set; }
	}
}
