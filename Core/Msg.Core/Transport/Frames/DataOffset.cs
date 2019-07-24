using System;
using Msg.Core.Transport.Frames.Constants;

namespace Msg.Core.Transport.Frames
{
    public struct DataOffset
    {
        public byte Size { get; }

        public uint SizeInBytes => Size * FrameHeaders.DataOffsetMultiplicationFactor;

        public DataOffset(byte value)
        {
            if (value * FrameHeaders.DataOffsetMultiplicationFactor < FrameHeaders.FixedLengthInBytes)
            {
                throw new ArgumentException("Data offset size must be at least equivalent to the minimum allowable header size.", nameof(value));
            }

            Size = value;
        }

        public static implicit operator byte(DataOffset dataOffset)
        {
            return dataOffset.Size;
        }
    }
}
