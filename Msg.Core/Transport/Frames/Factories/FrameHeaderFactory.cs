using System;
using Msg.Core.Transport.Frames.Constants;
using Msg.Core.Transport.Frames.Assertions;
using Msg.Core.Transport.Frames.Extensions;

namespace Msg.Core.Transport.Frames.Factories
{
	public static class FrameHeaderFactory
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
