using System;
using Msg.Core.Transport.Frames.Constants;
using System.Threading.Tasks;

namespace Msg.Core.Transport.Frames.Factories
{
    public class FrameFactory
    {
        public async Task<Frame> GetFrameFromBytes (byte[] frameBytes)
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

        public static OpenFrame CreateOpenFrame ()
        {
            return new OpenFrame (new Frame (new FrameHeader (13, 8, FrameHeaderType.AMQP, 0), new FrameExtendedHeader (new byte[0]), new FrameBody (PerformativeType.Open, new byte[0])));
        }

        public static CloseFrame CreateCloseFrame ()
        {
            return new CloseFrame (new Frame (new FrameHeader (14, 8, FrameHeaderType.AMQP, 0), new FrameExtendedHeader (new byte[0]), new FrameBody (PerformativeType.Close, new byte[0])));
        }
    }
}
