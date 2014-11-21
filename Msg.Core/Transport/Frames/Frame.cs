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

		public byte[] GetBytes()
		{
			return new byte[0];
		}

		public override string ToString ()
		{
			return string.Format ("[Frame: Header={0}, ExtendedHeader={1}, Body={2}]", Header, ExtendedHeader, Body);
		}
	}
}

