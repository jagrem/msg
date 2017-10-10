using System.Threading.Tasks;
using System;

namespace Msg.Core.Transport.Frames
{
    public static class FrameSender
    {
        public static async Task SendFrame (Connection connection, Frame frame)
        {
            try {
                await connection.SendAsync (frame.GetBytes ());
            } catch (Exception exception) {
                throw new FrameSendFailedException ("Frame send failed.", exception);
            }
        }
    }
}

