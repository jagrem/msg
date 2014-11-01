using System;
using Msg.Domain.Transport.Frames.Constants;

namespace Msg.Domain.Transport.Frames
{
	public class Frame
	{
		public Frame()
		{
		}

		public Frame(byte[] bytes)
		{
			var frameHeaderBytes = new byte[FrameHeaders.FixedLengthInBytes];
			Array.Copy (bytes, 0, frameHeaderBytes, 0, frameHeaderBytes.Length);
			Header = new FrameHeader(frameHeaderBytes);

			var extendHeaderBytes = new byte[Header.DataOffset - FrameHeaders.FixedLengthInBytes];
			Array.Copy (bytes, 8, extendHeaderBytes, 0, extendHeaderBytes.Length);
			ExtendedHeader = extendHeaderBytes;

			var frameBodyBytes = new byte[Header.Size - Header.DataOffset];
			Array.Copy (bytes, Header.DataOffset, frameBodyBytes, 0, frameBodyBytes.Length);
			FrameBody = new FrameBody(frameBodyBytes);
		}

		public FrameHeader Header { get; private set; }

		public byte[] ExtendedHeader { get; private set; }

		public FrameBody FrameBody  { get; private set; }
	}
}

