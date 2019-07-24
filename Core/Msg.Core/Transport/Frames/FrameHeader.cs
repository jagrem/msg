using System;

namespace Msg.Core.Transport.Frames
{
    public class FrameHeader
    {
        public FrameHeader(FrameSize size, DataOffset dataOffset, FrameHeaderType type, ushort channelId)
        {
            Size = size;
            DataOffset = dataOffset;
            Type = type;
            ChannelId = channelId;
        }

        public FrameSize Size { get; }

        public DataOffset DataOffset { get; }

        public FrameHeaderType Type { get; }

        public ushort ChannelId { get; }

        public override string ToString()
        {
            return string.Format("[FrameHeader: Size={0}, DataOffset={1}, Type={2}, ChannelId={3}]", Size, DataOffset, Type, ChannelId);
        }
    }
}
