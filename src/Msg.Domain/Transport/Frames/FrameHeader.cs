using System;

namespace Msg.Domain.Transport.Frames
{
	public class FrameHeader 
	{
		const int FrameHeaderLengthInBytes = 8;

		const int DataOffsetMultiplicationFactor = 4;

		const int MaximumSupportedFrameHeaderType = 1;

		public FrameHeader(byte[] frameHeaderBytes)
		{
			if(frameHeaderBytes.Length != FrameHeaderLengthInBytes){
				throw new ArgumentException ("A frame header has a fixed length of 8 bytes.", "frameHeaderBytes");
			}

			var size = frameHeaderBytes.GetUnsignedInteger (0);

			if(size < FrameHeaderLengthInBytes) {
				throw new MalformedFrameException ("The reported size of the frame header is less than 8 bytes.");
			}

			Size = size;

			var dataOffset = (uint)frameHeaderBytes [4] * DataOffsetMultiplicationFactor;

			if(dataOffset < FrameHeaderLengthInBytes){
				throw new MalformedFrameException ("Data offset cannot be less than 8 bytes.");
			}

			DataOffset = dataOffset;

			var type = frameHeaderBytes [5];

			if(type > MaximumSupportedFrameHeaderType){
				throw new NotSupportedException ("The frame header type is not supported.");
			}

			Type = (FrameHeaderType)type;

			ChannelId = frameHeaderBytes.GetUnsignedShort (6);
		}

		public uint Size { get; private set; }

		public uint DataOffset { get; private set; }

		public FrameHeaderType Type { get; private set; }

		public uint ChannelId { get; private set; }
	}
}
