using Msg.Domain.Transport.Frames.Constants;
using System;
using Msg.Domain.Transport.Frames.Resources;

namespace Msg.Domain.Transport.Frames.Assertions
{
	public static class FrameHeaderAssertions
	{
		public static void AssertFrameHeaderTypeIsSupported (byte type)
		{
			if (type > FrameHeaders.MaximumSupportedFrameHeaderType) {
				throw new NotSupportedException (ExceptionMessages.FrameHeaderTypeNotSupported);
			}
		}

		public static void AssertDataOffsetIsGreaterThanOrEqualToHeaderSize (uint dataOffset)
		{
			if (dataOffset < FrameHeaders.FixedLengthInBytes) {
				throw new MalformedFrameException (ExceptionMessages.MalformedFrameDataOffsetIsLessThanHeaderSize);
			}
		}

		public static void AssertReportedSizeIsGreaterThanOrEqualToHeaderSize (uint size)
		{
			if (size < FrameHeaders.FixedLengthInBytes) {
				throw new MalformedFrameException (ExceptionMessages.MalformedFrameDataOffsetIsLessThanHeaderSize);
			}
		}

		public static void AssertByteArrayLengthEqualsHeaderSize (byte[] frameHeaderBytes)
		{
			if (frameHeaderBytes.Length != FrameHeaders.FixedLengthInBytes) {
				throw new ArgumentException (ExceptionMessages.FrameHeaderByteArrayIsNotEqualToHeaderSize, "frameHeaderBytes");
			}
		}
	}
}

