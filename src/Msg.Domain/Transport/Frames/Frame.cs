using System;

namespace Msg.Domain.Transport.Frames
{
	public class Frame
	{
		public Frame()
		{
		}

		public Frame(FrameHeader header, byte[] extendedHeader, byte[] frameBody)
		{
			Header = header;
			ExtendedHeader = extendedHeader;
			FrameBody = frameBody;
		}

		public FrameHeader Header { get; private set; }

		public byte[] ExtendedHeader { get; private set; }

		public byte[] FrameBody  { get; private set; }
	}
}

