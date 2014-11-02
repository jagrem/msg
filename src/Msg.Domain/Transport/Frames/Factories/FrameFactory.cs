using System;
using Msg.Domain.Transport.Frames.Constants;
using System.Threading.Tasks;

namespace Msg.Domain.Transport.Frames.Factories
{
	class FrameFactory 
	{
		public async Task<Frame> GetFrameFromBytes(byte[] frameBytes)
		{
			var frameHeaderBytes = new byte[FrameHeaders.FixedLengthInBytes];
			Array.Copy (frameBytes, 0, frameHeaderBytes, 0, frameHeaderBytes.Length);
			var header = FrameHeaderFactory.GetFrameHeaderFromBytes (frameHeaderBytes);

			var extendedHeaderBytes = new byte[header.DataOffset - FrameHeaders.FixedLengthInBytes];
			Array.Copy (frameBytes, FrameHeaders.FixedLengthInBytes, extendedHeaderBytes, 0, extendedHeaderBytes.Length);
			var extendedHeader = new FrameExtendedHeader (extendedHeaderBytes);

			var frameBodyBytes = new byte[header.Size - header.DataOffset];
			Array.Copy (frameBytes, header.DataOffset, frameBodyBytes, 0, frameBodyBytes.Length);
			var body = await FrameBodyFactory.GetFrameBodyFromBytes (frameBodyBytes);

			return new Frame (header, extendedHeader, body);
		}
	}
}
