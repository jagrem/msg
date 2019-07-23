namespace Msg.Core.Transport.Frames
{
    public class Frame
    {
        public FrameHeader Header { get; }
        public FrameExtendedHeader ExtendedHeader { get; }
        public FrameBody Body { get; }

        public Frame(FrameHeader header, FrameExtendedHeader extendedHeader, FrameBody body)
        {
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
