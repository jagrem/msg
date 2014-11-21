namespace Msg.Core.Transport.Frames
{
	public class Frame
	{
		public Frame(FrameHeader header, FrameExtendedHeader extendedHeader, FrameBody body)
		{
			Header = header;
			ExtendedHeader = extendedHeader;
			Body = body;
		}

		public FrameHeader Header { get; private set; }

		public FrameExtendedHeader ExtendedHeader { get; private set; }

		public FrameBody Body  { get; private set; }
	}
}

