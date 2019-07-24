using System;

namespace Msg.Core.Transport.Frames
{
    public struct FrameSize
    {
        public uint Value { get; }

        public FrameSize(uint value)
        {
            if (value < 8)
            {
                throw new ArgumentException("Frame size must be at least as large as the minimum allowable header size.", nameof(value));
            }

            Value = value;
        }

        public static implicit operator uint(FrameSize frameSize)
        {
            return frameSize.Value;
        }
    }
}
