using System.Text;

namespace Msg.Core.Transport.Frames
{
    public class FrameBody
    {
        public byte[] Payload { get; }

        public FrameBody(byte[] payloadBytes)
        {
            Payload = payloadBytes;
        }

        public override string ToString()
        {
            return string.Format("[FrameBody: Payload={1}]", Encoding.UTF8.GetString(Payload));
        }
    }
}
