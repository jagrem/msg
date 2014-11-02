using System;
using Msg.Domain.Transport.Frames.Constants;
using Msg.Domain.Transport.Frames.Assertions;

namespace Msg.Domain.Transport.Frames.Factories
{

	static class FrameHeaderFactory
	{
		public static FrameHeader GetFrameHeaderFromBytes(byte[] frameHeaderBytes) {
			FrameHeaderAssertions.AssertByteArrayLengthEqualsHeaderSize (frameHeaderBytes);

			var size = frameHeaderBytes.GetUnsignedInteger (0);
			FrameHeaderAssertions.AssertReportedSizeIsGreaterThanOrEqualToHeaderSize (size);

			var dataOffset = (uint)frameHeaderBytes [4] * FrameHeaders.DataOffsetMultiplicationFactor;
			FrameHeaderAssertions.AssertDataOffsetIsGreaterThanOrEqualToHeaderSize (dataOffset);

			var type = frameHeaderBytes [5];
			FrameHeaderAssertions.AssertFrameHeaderTypeIsSupported (type);

			var channelId = frameHeaderBytes.GetUnsignedShort (6);

			return new FrameHeader(size, dataOffset, (FrameHeaderType)type, channelId);
		}
	}
}
