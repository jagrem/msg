using System;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames
{
    public class Frame
    {
        public FrameHeader Header { get; }
        public FrameExtendedHeader ExtendedHeader { get; }
        public FrameBody Body { get; }

        public Frame(FrameHeader header, FrameExtendedHeader extendedHeader, FrameBody body)
        {
            if (header.Size != FrameHeaders.FixedLengthInBytes + extendedHeader.Data.Length + body.Payload.Length)
            {
                throw new ArgumentException("Frame size must match the number of bytes in the frame.", nameof(header));
            }

            if (header.DataOffset.SizeInBytes != FrameHeaders.FixedLengthInBytes + extendedHeader.Data.Length)
            {
                throw new ArgumentException("Offset must match the number of bytes in the headers.", nameof(header));
            }

            Header = header;
            ExtendedHeader = extendedHeader;
            Body = body;
        }

        public override string ToString()
        {
            return string.Format("[Frame: Header={0}, ExtendedHeader={1}, Body={2}]", Header, ExtendedHeader, Body);
        }
    }
}
