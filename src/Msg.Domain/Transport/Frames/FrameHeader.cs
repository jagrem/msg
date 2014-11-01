using System;
using Msg.Domain.Transport.Frames.Constants;
using Msg.Domain.Transport.Frames.Assertions;

namespace Msg.Domain.Transport.Frames
{
	public class FrameHeader 
	{
		public FrameHeader(byte[] frameHeaderBytes)
		{
			FrameHeaderAssertions.AssertByteArrayLengthEqualsHeaderSize (frameHeaderBytes);

			var size = frameHeaderBytes.GetUnsignedInteger (0);
			FrameHeaderAssertions.AssertReportedSizeIsGreaterThanOrEqualToHeaderSize (size);
			Size = size;

			var dataOffset = (uint)frameHeaderBytes [4] * FrameHeaders.DataOffsetMultiplicationFactor;
			FrameHeaderAssertions.AssertDataOffsetIsGreaterThanOrEqualToHeaderSize (dataOffset);
			DataOffset = dataOffset;

			var type = frameHeaderBytes [5];
			FrameHeaderAssertions.AssertFrameHeaderTypeIsSupported (type);
			Type = (FrameHeaderType)type;

			ChannelId = frameHeaderBytes.GetUnsignedShort (6);
		}

		public uint Size { get; private set; }

		public uint DataOffset { get; private set; }

		public FrameHeaderType Type { get; private set; }

		public uint ChannelId { get; private set; }
	}
}
