using System;

namespace Msg.Core.Transport.Frames
{
    public class FrameHeader
    {
        public FrameHeader(uint size, byte dataOffset, FrameHeaderType type, ushort channelId)
        {
            Size = size;
            DataOffset = dataOffset;
            Type = type;
            ChannelId = channelId;
        }

        public uint Size { get; private set; }

        public byte DataOffset { get; private set; }

        public FrameHeaderType Type { get; private set; }

        public ushort ChannelId { get; private set; }

        public override string ToString()
        {
            return string.Format("[FrameHeader: Size={0}, DataOffset={1}, Type={2}, ChannelId={3}]", Size, DataOffset, Type, ChannelId);
        }
    }
}
