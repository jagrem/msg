namespace Msg.Core.Transport.Frames.Amqp
{
    public struct ChannelId
    {
        public ushort Value { get; }

        public ChannelId(ushort value)
        {
            Value = value;
        }

        public static implicit operator ushort(ChannelId channelId)
        {
            return channelId.Value;
        }
    }
}
